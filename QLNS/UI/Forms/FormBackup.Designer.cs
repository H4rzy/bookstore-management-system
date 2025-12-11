namespace QLNS.UI.Forms
{
    partial class FormBackup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.ListView lvBackupHistory;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ProgressBar progressBar;

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.lvBackupHistory = new System.Windows.Forms.ListView();
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelTop.SuspendLayout();
            this.grpBackup.SuspendLayout();
            this.grpHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "💾 SAO LƯU & KHÔI PHỤC DATABASE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBackup
            // 
            this.grpBackup.Controls.Add(this.btnBackup);
            this.grpBackup.Controls.Add(this.txtFileName);
            this.grpBackup.Controls.Add(this.lblFileName);
            this.grpBackup.Controls.Add(this.btnBrowse);
            this.grpBackup.Controls.Add(this.txtBackupPath);
            this.grpBackup.Controls.Add(this.lblBackupPath);
            this.grpBackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBackup.Location = new System.Drawing.Point(20, 80);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(860, 180);
            this.grpBackup.TabIndex = 1;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Sao Lưu Database";
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBackupPath.Location = new System.Drawing.Point(20, 35);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(107, 15);
            this.lblBackupPath.TabIndex = 0;
            this.lblBackupPath.Text = "Thư mục lưu file:";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBackupPath.Location = new System.Drawing.Point(20, 55);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new System.Drawing.Size(700, 23);
            this.txtBackupPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowse.Location = new System.Drawing.Point(730, 55);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(110, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "📁 Chọn thư mục";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFileName.Location = new System.Drawing.Point(20, 95);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(56, 15);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "Tên file:";
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFileName.Location = new System.Drawing.Point(20, 115);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(700, 23);
            this.txtFileName.TabIndex = 4;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(730, 108);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(110, 35);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "💾 Sao Lưu";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.btnRefresh);
            this.grpHistory.Controls.Add(this.btnDelete);
            this.grpHistory.Controls.Add(this.btnRestore);
            this.grpHistory.Controls.Add(this.lvBackupHistory);
            this.grpHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpHistory.Location = new System.Drawing.Point(20, 270);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(860, 350);
            this.grpHistory.TabIndex = 2;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "Lịch Sử Backup";
            // 
            // lvBackupHistory
            // 
            this.lvBackupHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colDate,
            this.colSize,
            this.colPath});
            this.lvBackupHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvBackupHistory.FullRowSelect = true;
            this.lvBackupHistory.GridLines = true;
            this.lvBackupHistory.HideSelection = false;
            this.lvBackupHistory.Location = new System.Drawing.Point(20, 30);
            this.lvBackupHistory.MultiSelect = false;
            this.lvBackupHistory.Name = "lvBackupHistory";
            this.lvBackupHistory.Size = new System.Drawing.Size(820, 260);
            this.lvBackupHistory.TabIndex = 0;
            this.lvBackupHistory.UseCompatibleStateImageBehavior = false;
            this.lvBackupHistory.View = System.Windows.Forms.View.Details;
            // 
            // colFileName
            // 
            this.colFileName.Text = "Tên File";
            this.colFileName.Width = 300;
            // 
            // colDate
            // 
            this.colDate.Text = "Ngày Tạo";
            this.colDate.Width = 160;
            // 
            // colSize
            // 
            this.colSize.Text = "Dung Lượng";
            this.colSize.Width = 120;
            // 
            // colPath
            // 
            this.colPath.Text = "Đường Dẫn";
            this.colPath.Width = 0;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(20, 300);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(130, 35);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "🔄 Khôi Phục";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(160, 300);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(710, 300);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(20, 635);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(860, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 680);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao Lưu & Khôi Phục Database";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            this.panelTop.ResumeLayout(false);
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            this.grpHistory.ResumeLayout(false);
            this.SuspendLayout();
        }

        #endregion
    }
}
