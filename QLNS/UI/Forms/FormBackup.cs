using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using QLNS_DAL;

namespace QLNS.UI.Forms
{
    public partial class FormBackup : Form
    {
        public FormBackup()
        {
            InitializeComponent();
            SetupDefaultPath();
        }

        private void SetupDefaultPath()
        {
            // Default backup path: Documents\QLNS_Backups
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string backupFolder = Path.Combine(documentsPath, "QLNS_Backups");
            
            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }

            txtBackupPath.Text = backupFolder;
            UpdateBackupFileName();
        }

        private void UpdateBackupFileName()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"QLNS_Backup_{timestamp}.bak";
            txtFileName.Text = fileName;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Chọn thư mục lưu file backup";
                fbd.SelectedPath = txtBackupPath.Text;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtBackupPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBackupPath.Text))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu backup!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên file backup!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn sao lưu cơ sở dữ liệu?\n\nĐường dẫn: {txtBackupPath.Text}\nTên file: {txtFileName.Text}",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PerformBackup();
            }
        }

        private void PerformBackup()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                btnBackup.Enabled = false;
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Marquee;

                string fullPath = Path.Combine(txtBackupPath.Text, txtFileName.Text);
                
                // Get connection string from DBConnect
                string connectionString = DBConnect.connectionString;
                
                // Extract database name from connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
                string databaseName = builder.InitialCatalog;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL backup command
                    string backupQuery = $@"
                        BACKUP DATABASE [{databaseName}]
                        TO DISK = @BackupPath
                        WITH FORMAT,
                        MEDIANAME = 'QLNS_Backup',
                        NAME = 'Full Backup of QLNS Database';";

                    using (SqlCommand cmd = new SqlCommand(backupQuery, conn))
                    {
                        cmd.CommandTimeout = 300; // 5 minutes timeout
                        cmd.Parameters.AddWithValue("@BackupPath", fullPath);
                        
                        cmd.ExecuteNonQuery();
                    }
                }

                progressBar.Visible = false;
                MessageBox.Show($"Sao lưu thành công!\n\nFile: {fullPath}\nDung lượng: {GetFileSize(fullPath)}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh file list
                LoadBackupHistory();
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                MessageBox.Show($"Lỗi khi sao lưu:\n\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnBackup.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private string GetFileSize(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            long bytes = fi.Length;

            if (bytes >= 1073741824)
                return $"{bytes / 1073741824.0:F2} GB";
            else if (bytes >= 1048576)
                return $"{bytes / 1048576.0:F2} MB";
            else if (bytes >= 1024)
                return $"{bytes / 1024.0:F2} KB";
            else
                return $"{bytes} bytes";
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            LoadBackupHistory();
        }

        private void LoadBackupHistory()
        {
            try
            {
                lvBackupHistory.Items.Clear();

                if (!Directory.Exists(txtBackupPath.Text))
                    return;

                string[] backupFiles = Directory.GetFiles(txtBackupPath.Text, "*.bak");

                foreach (string file in backupFiles)
                {
                    FileInfo fi = new FileInfo(file);
                    ListViewItem item = new ListViewItem(fi.Name);
                    item.SubItems.Add(fi.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"));
                    item.SubItems.Add(GetFileSize(file));
                    item.SubItems.Add(file);
                    item.Tag = file;

                    lvBackupHistory.Items.Add(item);
                }

                // Sort by date descending
                lvBackupHistory.Sorting = System.Windows.Forms.SortOrder.Descending;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách backup: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (lvBackupHistory.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn file backup để khôi phục!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string backupFile = lvBackupHistory.SelectedItems[0].Tag.ToString();

            DialogResult result = MessageBox.Show(
                $"⚠️ CẢNH BÁO: Khôi phục sẽ ghi đè toàn bộ dữ liệu hiện tại!\n\n" +
                $"File: {Path.GetFileName(backupFile)}\n" +
                $"Ngày tạo: {lvBackupHistory.SelectedItems[0].SubItems[1].Text}\n\n" +
                $"Bạn có chắc muốn tiếp tục?",
                "Xác nhận khôi phục", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                PerformRestore(backupFile);
            }
        }

        private void PerformRestore(string backupFile)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                btnRestore.Enabled = false;
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Marquee;

                string connectionString = DBConnect.connectionString;
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
                string databaseName = builder.InitialCatalog;

                // Change connection to master database
                builder.InitialCatalog = "master";
                string masterConnectionString = builder.ToString();

                using (SqlConnection conn = new SqlConnection(masterConnectionString))
                {
                    conn.Open();

                    // Set database to single user mode
                    string setSingleUser = $@"
                        ALTER DATABASE [{databaseName}] 
                        SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

                    using (SqlCommand cmd = new SqlCommand(setSingleUser, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Restore database
                    string restoreQuery = $@"
                        RESTORE DATABASE [{databaseName}]
                        FROM DISK = @BackupPath
                        WITH REPLACE;";

                    using (SqlCommand cmd = new SqlCommand(restoreQuery, conn))
                    {
                        cmd.CommandTimeout = 300;
                        cmd.Parameters.AddWithValue("@BackupPath", backupFile);
                        cmd.ExecuteNonQuery();
                    }

                    // Set back to multi user
                    string setMultiUser = $@"
                        ALTER DATABASE [{databaseName}] 
                        SET MULTI_USER;";

                    using (SqlCommand cmd = new SqlCommand(setMultiUser, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                progressBar.Visible = false;
                MessageBox.Show("Khôi phục thành công!\n\nỨng dụng sẽ khởi động lại.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Restart application
                Application.Restart();
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                MessageBox.Show($"Lỗi khi khôi phục:\n\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnRestore.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBackupHistory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvBackupHistory.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn file backup để xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string backupFile = lvBackupHistory.SelectedItems[0].Tag.ToString();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa file backup?\n\n{Path.GetFileName(backupFile)}",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    File.Delete(backupFile);
                    MessageBox.Show("Đã xóa file backup!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBackupHistory();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
