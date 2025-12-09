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

namespace QLNS.UI.Forms.ReceiptDetails
{
    public partial class FormReceiptList : Form
    {
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL();
        private KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();

        public FormReceiptList()
        {
            InitializeComponent();
        }

        private void FormReceiptList_Load(object sender, EventArgs e)
        {
            InitializeControls();
            LoadNhanVien();
            LoadKhachHang();
            LoadHoaDon();
            SetupDataGridView();
        }

        #region Initialization

        private void InitializeControls()
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void SetupDataGridView()
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.Columns.Clear();

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoHD",
                HeaderText = "Số hóa đơn",
                Name = "SoHD",
                Width = 150
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayBan",
                HeaderText = "Ngày bán",
                Name = "NgayBan",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNV",
                HeaderText = "Mã nhân viên",
                Name = "MaNV",
                Width = 120
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaKH",
                HeaderText = "Mã khách hàng",
                Name = "MaKH",
                Width = 120
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
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

        private void LoadKhachHang()
        {
            try
            {
                var dsKhachHang = khachHangBLL.LayDanhSachKhachHang();

                cboKhachHang.Items.Clear();
                cboKhachHang.Items.Add("-- Tất cả khách hàng --");

                foreach (var kh in dsKhachHang)
                {
                    cboKhachHang.Items.Add($"{kh.MaKH} - {kh.TenKH}");
                }

                cboKhachHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khách hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHoaDon()
        {
            try
            {
                var dsHoaDon = hoaDonBLL.LayDanhSachHoaDon();

                // Apply filters
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    dsHoaDon = dsHoaDon.Where(p => p.SoHD.Contains(txtSearch.Text)).ToList();
                }

                if (cboNhanVien.SelectedIndex > 0)
                {
                    string maNV = cboNhanVien.SelectedItem.ToString().Split('-')[0].Trim();
                    dsHoaDon = dsHoaDon.Where(p => p.MaNV == maNV).ToList();
                }

                if (cboKhachHang.SelectedIndex > 0)
                {
                    string maKH = cboKhachHang.SelectedItem.ToString().Split('-')[0].Trim();
                    dsHoaDon = dsHoaDon.Where(p => p.MaKH == maKH).ToList();
                }

                dsHoaDon = dsHoaDon.Where(p =>
                    p.NgayBan.Date >= dtpStartDate.Value.Date &&
                    p.NgayBan.Date <= dtpEndDate.Value.Date).ToList();

                dgvHoaDon.DataSource = dsHoaDon;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                
                // Auto-fill selected SoHD into search textbox
                var row = dgvHoaDon.SelectedRows[0];
                string soHD = row.Cells["SoHD"].Value?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(soHD))
                {
                    txtSearch.Text = soHD;
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
            LoadHoaDon();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboNhanVien.SelectedIndex = 0;
            cboKhachHang.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadHoaDon();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new FormReceiptEdit(null))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadHoaDon();
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvHoaDon.SelectedRows[0];
            string soHD = row.Cells["SoHD"].Value?.ToString() ?? string.Empty;

            var hoaDon = hoaDonBLL.LayHoaDonTheoSo(soHD);
            using (var dialog = new FormReceiptEdit(hoaDon))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadHoaDon();
                    MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvHoaDon.SelectedRows[0];
            string soHD = row.Cells["SoHD"].Value?.ToString() ?? string.Empty;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hóa đơn {soHD}?\n" +
                "Thao tác này sẽ hoàn lại tồn kho và không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (hoaDonBLL.XoaHoaDon(soHD))
                    {
                        MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHoaDon();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hóa đơn thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }

    #region Dialog Form

    public class FormReceiptEdit : Form
    {
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL();
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();
        private KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        private HoaDonDTO hoaDon;
        private bool isEditMode;

        private TextBox txtSoHD;
        private DateTimePicker dtpNgayBan;
        private ComboBox cboNhanVien;
        private ComboBox cboKhachHang;
        private TextBox txtGhiChu;
        private Button btnSave;
        private Button btnCancel;

        public FormReceiptEdit(HoaDonDTO hoaDon)
        {
            this.hoaDon = hoaDon;
            isEditMode = hoaDon != null;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = isEditMode ? "Sửa hóa đơn" : "Thêm hóa đơn";
            this.Size = new Size(500, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int y = 20;
            int labelWidth = 120;
            int controlWidth = 340;
            int spacing = 40;

            var lblSoHD = new Label { Text = "Số hóa đơn:", Location = new Point(20, y), Width = labelWidth };
            txtSoHD = new TextBox { Location = new Point(145, y), Width = controlWidth };
            txtSoHD.ReadOnly = isEditMode;
            this.Controls.Add(lblSoHD);
            this.Controls.Add(txtSoHD);
            y += spacing;

            var lblNgayBan = new Label { Text = "Ngày bán:", Location = new Point(20, y), Width = labelWidth };
            dtpNgayBan = new DateTimePicker
            {
                Location = new Point(145, y),
                Width = controlWidth,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy"
            };
            this.Controls.Add(lblNgayBan);
            this.Controls.Add(dtpNgayBan);
            y += spacing;

            var lblNhanVien = new Label { Text = "Nhân viên:", Location = new Point(20, y), Width = labelWidth };
            cboNhanVien = new ComboBox
            {
                Location = new Point(145, y),
                Width = controlWidth,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(lblNhanVien);
            this.Controls.Add(cboNhanVien);
            y += spacing;

            var lblKhachHang = new Label { Text = "Khách hàng:", Location = new Point(20, y), Width = labelWidth };
            cboKhachHang = new ComboBox
            {
                Location = new Point(145, y),
                Width = controlWidth,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(lblKhachHang);
            this.Controls.Add(cboKhachHang);
            y += spacing;

            var lblGhiChu = new Label { Text = "Ghi chú:", Location = new Point(20, y), Width = labelWidth };
            txtGhiChu = new TextBox
            {
                Location = new Point(145, y),
                Width = controlWidth,
                Height = 60,
                Multiline = true
            };
            this.Controls.Add(lblGhiChu);
            this.Controls.Add(txtGhiChu);
            y += 80;

            btnSave = new Button
            {
                Text = "Lưu",
                Location = new Point(285, y),
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
                Location = new Point(395, y),
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
            var dsNhanVien = nhanVienBLL.LayDanhSachNhanVien();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DataSource = dsNhanVien;

            var dsKhachHang = khachHangBLL.LayDanhSachKhachHang();
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.DataSource = dsKhachHang;

            if (isEditMode && hoaDon != null)
            {
                txtSoHD.Text = hoaDon.SoHD;
                dtpNgayBan.Value = hoaDon.NgayBan;
                cboNhanVien.SelectedValue = hoaDon.MaNV;
                cboKhachHang.SelectedValue = hoaDon.MaKH;
                txtGhiChu.Text = hoaDon.GhiChu;
            }
            else
            {
                dtpNgayBan.Value = DateTime.Now;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoHD.Text))
            {
                MessageBox.Show("Vui lòng nhập số hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHD.Focus();
                return;
            }

            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dto = new HoaDonDTO
                {
                    SoHD = txtSoHD.Text.Trim(),
                    NgayBan = dtpNgayBan.Value,
                    MaNV = cboNhanVien.SelectedValue.ToString(),
                    MaKH = cboKhachHang.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                bool success;
                if (isEditMode)
                {
                    MessageBox.Show("Chức năng sửa hóa đơn chưa được hỗ trợ!\nVui lòng xóa và tạo hóa đơn mới.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    success = hoaDonBLL.ThemHoaDon(dto);
                }

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lưu hóa đơn thất bại!\nKiểm tra lại thông tin hoặc số hóa đơn đã tồn tại.",
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
