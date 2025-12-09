using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS_BLL;
using QLNS_DTO;

namespace QLNS.UI.Forms.ImportDetails
{
    public partial class FormImportList : Form
    {
        private PhieuNhap_BLL phieuNhapBLL = new PhieuNhap_BLL();
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();

        public FormImportList()
        {
            InitializeComponent();
        }

        private void FormImportList_Load(object sender, EventArgs e)
        {
            InitializeControls();
            LoadNhanVien();
            LoadPhieuNhap();
            SetupDataGridView();
        }

        #region Initialization

        private void InitializeControls()
        {
            // Set default date range (last 30 days)
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;

            // Disable buttons initially
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void SetupDataGridView()
        {
            // Configure PhieuNhap DataGridView
            dgvPhieuNhap.AutoGenerateColumns = false;
            dgvPhieuNhap.Columns.Clear();

            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoPN",
                HeaderText = "Số phiếu nhập",
                Name = "SoPN",
                Width = 150
            });

            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayNhap",
                HeaderText = "Ngày nhập",
                Name = "NgayNhap",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNV",
                HeaderText = "Mã nhân viên",
                Name = "MaNV",
                Width = 120
            });

            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GhiChu",
                HeaderText = "Ghi chú",
                Name = "GhiChu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        #endregion

        #region Load Data

        private void LoadNhanVien()
        {
            try
            {
                var dsNhanVien = nhanVienBLL.LayDanhSachNhanVien();

                cboNhanVien.Items.Clear();
                cboNhanVien.Items.Add("-- Tất cả nhân viên --");

                foreach (var nv in dsNhanVien)
                {
                    cboNhanVien.Items.Add($"{nv.MaNV} - {nv.TenNV}");
                }

                cboNhanVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhieuNhap()
        {
            try
            {
                var dsPhieuNhap = phieuNhapBLL.LayDanhSachPhieuNhap();

                // Apply filters
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    dsPhieuNhap = dsPhieuNhap.Where(p => p.SoPN.Contains(txtSearch.Text)).ToList();
                }

                if (cboNhanVien.SelectedIndex > 0)
                {
                    string maNV = cboNhanVien.SelectedItem.ToString().Split('-')[0].Trim();
                    dsPhieuNhap = dsPhieuNhap.Where(p => p.MaNV == maNV).ToList();
                }

                dsPhieuNhap = dsPhieuNhap.Where(p =>
                    p.NgayNhap.Date >= dtpStartDate.Value.Date &&
                    p.NgayNhap.Date <= dtpEndDate.Value.Date).ToList();

                dgvPhieuNhap.DataSource = dsPhieuNhap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phiếu nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void dgvPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count > 0)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                
                // Auto-fill selected SoPN into search textbox
                var row = dgvPhieuNhap.SelectedRows[0];
                string soPN = row.Cells["SoPN"].Value?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(soPN))
                {
                    txtSearch.Text = soPN;
                }
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPhieuNhap();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboNhanVien.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadPhieuNhap();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new FormImportEdit(null))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadPhieuNhap();
                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvPhieuNhap.SelectedRows[0];
            string soPN = row.Cells["SoPN"].Value?.ToString() ?? string.Empty;

            var phieuNhap = phieuNhapBLL.LayPhieuNhapTheoSo(soPN);
            using (var dialog = new FormImportEdit(phieuNhap))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadPhieuNhap();
                    MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvPhieuNhap.SelectedRows[0];
            string soPN = row.Cells["SoPN"].Value?.ToString() ?? string.Empty;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phiếu nhập {soPN}?\n" +
                "Thao tác này sẽ trừ tồn kho của tất cả các sách trong phiếu nhập và không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (phieuNhapBLL.XoaPhieuNhap(soPN))
                    {
                        MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPhieuNhap();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu nhập thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa phiếu nhập: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void tableLayoutMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    #region Dialog Form

    /// <summary>
    /// Form for adding/editing import orders (PhieuNhap)
    /// </summary>
    public class FormImportEdit : Form
    {
        private PhieuNhap_BLL phieuNhapBLL = new PhieuNhap_BLL();
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();
        private PhieuNhapDTO phieuNhap;
        private bool isEditMode;

        private TextBox txtSoPN;
        private DateTimePicker dtpNgayNhap;
        private ComboBox cboNhanVien;
        private TextBox txtGhiChu;
        private Button btnSave;
        private Button btnCancel;

        public FormImportEdit(PhieuNhapDTO phieuNhap)
        {
            this.phieuNhap = phieuNhap;
            isEditMode = phieuNhap != null;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = isEditMode ? "Sửa phiếu nhập" : "Thêm phiếu nhập";
            this.Size = new Size(500, 350);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int y = 20;
            int labelWidth = 100;
            int controlWidth = 350;
            int controlHeight = 25;
            int spacing = 40;

            // Số phiếu nhập
            var lblSoPN = new Label { Text = "Số phiếu:", Location = new Point(20, y), Width = labelWidth };
            txtSoPN = new TextBox { Location = new Point(130, y), Width = controlWidth, Height = controlHeight };
            txtSoPN.ReadOnly = isEditMode;
            this.Controls.Add(lblSoPN);
            this.Controls.Add(txtSoPN);
            y += spacing;

            // Ngày nhập
            var lblNgayNhap = new Label { Text = "Ngày nhập:", Location = new Point(20, y), Width = labelWidth };
            dtpNgayNhap = new DateTimePicker
            {
                Location = new Point(130, y),
                Width = controlWidth,
                Height = controlHeight,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy"
            };
            this.Controls.Add(lblNgayNhap);
            this.Controls.Add(dtpNgayNhap);
            y += spacing;

            // Nhân viên
            var lblNhanVien = new Label { Text = "Nhân viên:", Location = new Point(20, y), Width = labelWidth };
            cboNhanVien = new ComboBox
            {
                Location = new Point(130, y),
                Width = controlWidth,
                Height = controlHeight,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(lblNhanVien);
            this.Controls.Add(cboNhanVien);
            y += spacing;

            // Ghi chú
            var lblGhiChu = new Label { Text = "Ghi chú:", Location = new Point(20, y), Width = labelWidth };
            txtGhiChu = new TextBox
            {
                Location = new Point(130, y),
                Width = controlWidth,
                Height = 60,
                Multiline = true
            };
            this.Controls.Add(lblGhiChu);
            this.Controls.Add(txtGhiChu);
            y += 80;

            // Buttons
            btnSave = new Button
            {
                Text = "Lưu",
                Location = new Point(280, y),
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += btnSave_Click;

            btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(390, y),
                Width = 90,
                Height = 35,
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private void LoadData()
        {
            // Load nhân viên
            var dsNhanVien = nhanVienBLL.LayDanhSachNhanVien();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DataSource = dsNhanVien;

            if (isEditMode && phieuNhap != null)
            {
                txtSoPN.Text = phieuNhap.SoPN;
                dtpNgayNhap.Value = phieuNhap.NgayNhap;
                cboNhanVien.SelectedValue = phieuNhap.MaNV;
                txtGhiChu.Text = phieuNhap.GhiChu;
            }
            else
            {
                dtpNgayNhap.Value = DateTime.Now;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtSoPN.Text))
            {
                MessageBox.Show("Vui lòng nhập số phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPN.Focus();
                return;
            }

            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dto = new PhieuNhapDTO
                {
                    SoPN = txtSoPN.Text.Trim(),
                    NgayNhap = dtpNgayNhap.Value,
                    MaNV = cboNhanVien.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                bool success;
                if (isEditMode)
                {
                    // Note: PhieuNhap_BLL doesn't have update method, only add/delete
                    MessageBox.Show("Chức năng sửa phiếu nhập chưa được hỗ trợ!\nVui lòng xóa và tạo phiếu mới.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    success = phieuNhapBLL.ThemPhieuNhap(dto);
                }

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lưu phiếu nhập thất bại!\nKiểm tra lại thông tin hoặc số phiếu đã tồn tại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion
}
