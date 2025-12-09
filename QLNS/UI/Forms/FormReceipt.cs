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

namespace QLNS.Forms
{
    public partial class FormReceipt : Form
    {
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL();
        private ChiTietHoaDon_BLL chiTietBLL = new ChiTietHoaDon_BLL();
        private KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();
        private Sach_BLL sachBLL = new Sach_BLL();
        
        private string selectedSoHD = string.Empty;
        
        public FormReceipt()
        {
            InitializeComponent();
        }

        private void FormReceipt_Load(object sender, EventArgs e)
        {
            InitializeControls();
            LoadNhanVien();
            LoadKhachHang();
            LoadHoaDon();
            SetupDataGridViews();
        }

        #region Initialization

        private void InitializeControls()
        {
            // Set default date range (last 30 days)
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            
            // Disable detail buttons initially
            btnAddDetail.Enabled = false;
            btnDeleteDetail.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void SetupDataGridViews()
        {
            // Configure HoaDon DataGridView
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

            // Configure ChiTiet DataGridView
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();
            
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSach",
                HeaderText = "Mã sách",
                Name = "MaSach",
                Width = 120
            });
            
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSach",
                HeaderText = "Tên sách",
                Name = "TenSach",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số lượng",
                Name = "SoLuong",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGiaBan",
                HeaderText = "Đơn giá bán",
                Name = "DonGiaBan",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành tiền",
                Name = "ThanhTien",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
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
                
                // Clear details if no selection
                if (dsHoaDon.Count == 0)
                {
                    dgvChiTiet.DataSource = null;
                    lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTiet(string soHD)
        {
            try
            {
                var dsChiTiet = chiTietBLL.LayChiTiet(soHD);
                
                // Create display list with book names
                var displayList = new List<dynamic>();
                foreach (var ct in dsChiTiet)
                {
                    var sach = sachBLL.LaySachTheoMa(ct.MaSach);
                    displayList.Add(new
                    {
                        ct.SoHD,
                        ct.MaSach,
                        TenSach = sach != null ? sach.TenSach : "N/A",
                        ct.SoLuong,
                        ct.DonGiaBan,
                        ThanhTien = ct.SoLuong * ct.DonGiaBan
                    });
                }
                
                dgvChiTiet.DataSource = displayList;
                
                // Update total
                decimal tongTien = chiTietBLL.TinhTongTien(soHD);
                lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                var row = dgvHoaDon.SelectedRows[0];
                selectedSoHD = row.Cells["SoHD"].Value?.ToString() ?? string.Empty;
                
                if (!string.IsNullOrEmpty(selectedSoHD))
                {
                    LoadChiTiet(selectedSoHD);
                    btnAddDetail.Enabled = true;
                    btnDeleteDetail.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                selectedSoHD = string.Empty;
                dgvChiTiet.DataSource = null;
                lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                btnAddDetail.Enabled = false;
                btnDeleteDetail.Enabled = false;
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
            if (string.IsNullOrEmpty(selectedSoHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var hoaDon = hoaDonBLL.LayHoaDonTheoSo(selectedSoHD);
            using (var dialog = new FormReceiptEdit(hoaDon))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadHoaDon();
                    LoadChiTiet(selectedSoHD);
                    MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hóa đơn {selectedSoHD}?\n" +
                "Thao tác này sẽ hoàn lại tồn kho của tất cả các sách trong hóa đơn và không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (hoaDonBLL.XoaHoaDon(selectedSoHD))
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

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            using (var dialog = new FormReceiptDetailEdit(selectedSoHD, null))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadChiTiet(selectedSoHD);
                    LoadHoaDon(); // Refresh to update any totals
                    MessageBox.Show("Thêm chi tiết bán hàng thành công!\nTồn kho đã được cập nhật.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chi tiết cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var row = dgvChiTiet.SelectedRows[0];
            string maSach = row.Cells["MaSach"].Value?.ToString() ?? string.Empty;
            
            if (string.IsNullOrEmpty(maSach))
                return;
            
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa chi tiết này?\n" +
                "Thao tác này sẽ hoàn lại tồn kho của sách và không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (chiTietBLL.XoaChiTiet(selectedSoHD, maSach))
                    {
                        MessageBox.Show("Xóa chi tiết thành công!\nTồn kho đã được cập nhật.", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadChiTiet(selectedSoHD);
                        LoadHoaDon(); // Refresh to update any totals
                    }
                    else
                    {
                        MessageBox.Show("Xóa chi tiết thất bại!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa chi tiết: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }

    #region Dialog Forms

    /// <summary>
    /// Form for adding/editing invoices (HoaDon)
    /// </summary>
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
            int controlHeight = 25;
            int spacing = 40;
            
            // Số hóa đơn
            var lblSoHD = new Label { Text = "Số hóa đơn:", Location = new Point(20, y), Width = labelWidth };
            txtSoHD = new TextBox { Location = new Point(145, y), Width = controlWidth, Height = controlHeight };
            txtSoHD.ReadOnly = isEditMode;
            this.Controls.Add(lblSoHD);
            this.Controls.Add(txtSoHD);
            y += spacing;
            
            // Ngày bán
            var lblNgayBan = new Label { Text = "Ngày bán:", Location = new Point(20, y), Width = labelWidth };
            dtpNgayBan = new DateTimePicker { 
                Location = new Point(145, y), 
                Width = controlWidth, 
                Height = controlHeight,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy"
            };
            this.Controls.Add(lblNgayBan);
            this.Controls.Add(dtpNgayBan);
            y += spacing;
            
            // Nhân viên
            var lblNhanVien = new Label { Text = "Nhân viên:", Location = new Point(20, y), Width = labelWidth };
            cboNhanVien = new ComboBox { 
                Location = new Point(145, y), 
                Width = controlWidth, 
                Height = controlHeight,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(lblNhanVien);
            this.Controls.Add(cboNhanVien);
            y += spacing;
            
            // Khách hàng
            var lblKhachHang = new Label { Text = "Khách hàng:", Location = new Point(20, y), Width = labelWidth };
            cboKhachHang = new ComboBox { 
                Location = new Point(145, y), 
                Width = controlWidth, 
                Height = controlHeight,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(lblKhachHang);
            this.Controls.Add(cboKhachHang);
            y += spacing;
            
            // Ghi chú
            var lblGhiChu = new Label { Text = "Ghi chú:", Location = new Point(20, y), Width = labelWidth };
            txtGhiChu = new TextBox { 
                Location = new Point(145, y), 
                Width = controlWidth, 
                Height = 60,
                Multiline = true
            };
            this.Controls.Add(lblGhiChu);
            this.Controls.Add(txtGhiChu);
            y += 80;
            
            // Buttons
            btnSave = new Button { 
                Text = "Lưu", 
                Location = new Point(285, y), 
                Width = 100, 
                Height = 35,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += btnSave_Click;
            
            btnCancel = new Button { 
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
            // Load nhân viên
            var dsNhanVien = nhanVienBLL.LayDanhSachNhanVien();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DataSource = dsNhanVien;
            
            // Load khách hàng
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
            // Validation
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
                    // Note: HoaDon_BLL doesn't have update method, only add/delete
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

    /// <summary>
    /// Form for adding/editing invoice details (ChiTietHoaDon)
    /// </summary>
    public class FormReceiptDetailEdit : Form
    {
        private ChiTietHoaDon_BLL chiTietBLL = new ChiTietHoaDon_BLL();
        private Sach_BLL sachBLL = new Sach_BLL();
        private string soHD;
        private ChiTietHoaDonDTO chiTiet;
        private bool isEditMode;
        
        private ComboBox cboSach;
        private NumericUpDown nudSoLuong;
        private TextBox txtDonGiaBan;
        private Label lblTonKho;
        private Label lblThanhTien;
        private Button btnSave;
        private Button btnCancel;
        
        public FormReceiptDetailEdit(string soHD, ChiTietHoaDonDTO chiTiet)
        {
            this.soHD = soHD;
            this.chiTiet = chiTiet;
            isEditMode = chiTiet != null;
            InitializeComponent();
            LoadData();
        }
        
        private void InitializeComponent()
        {
            this.Text = "Thêm chi tiết bán hàng";
            this.Size = new Size(500, 350);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            int y = 20;
            int labelWidth = 120;
            int controlWidth = 330;
            int spacing = 45;
            
            // Sách
            var lblSach = new Label { Text = "Sách:", Location = new Point(20, y), Width = labelWidth };
            cboSach = new ComboBox { 
                Location = new Point(150, y), 
                Width = controlWidth,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboSach.SelectedIndexChanged += (s, e) => UpdateTonKho();
            this.Controls.Add(lblSach);
            this.Controls.Add(cboSach);
            y += spacing;
            
            // Tồn kho
            var lblTonKhoLabel = new Label { Text = "Tồn kho:", Location = new Point(20, y), Width = labelWidth };
            lblTonKho = new Label { 
                Location = new Point(150, y), 
                Width = controlWidth,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204)
            };
            this.Controls.Add(lblTonKhoLabel);
            this.Controls.Add(lblTonKho);
            y += spacing;
            
            // Số lượng
            var lblSoLuong = new Label { Text = "Số lượng:", Location = new Point(20, y), Width = labelWidth };
            nudSoLuong = new NumericUpDown { 
                Location = new Point(150, y), 
                Width = controlWidth,
                Minimum = 1,
                Maximum = 10000,
                Value = 1
            };
            nudSoLuong.ValueChanged += (s, e) => UpdateThanhTien();
            this.Controls.Add(lblSoLuong);
            this.Controls.Add(nudSoLuong);
            y += spacing;
            
            // Đơn giá bán
            var lblDonGia = new Label { Text = "Đơn giá bán:", Location = new Point(20, y), Width = labelWidth };
            txtDonGiaBan = new TextBox { Location = new Point(150, y), Width = controlWidth };
            txtDonGiaBan.TextChanged += (s, e) => UpdateThanhTien();
            this.Controls.Add(lblDonGia);
            this.Controls.Add(txtDonGiaBan);
            y += spacing;
            
            // Thành tiền
            var lblThanhTienLabel = new Label { Text = "Thành tiền:", Location = new Point(20, y), Width = labelWidth };
            lblThanhTien = new Label { 
                Location = new Point(150, y), 
                Width = controlWidth,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 167, 69)
            };
            this.Controls.Add(lblThanhTienLabel);
            this.Controls.Add(lblThanhTien);
            y += spacing + 5;
            
            // Buttons
            btnSave = new Button { 
                Text = "Lưu", 
                Location = new Point(270, y), 
                Width = 100, 
                Height = 35,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += btnSave_Click;
            
            btnCancel = new Button { 
                Text = "Hủy", 
                Location = new Point(380, y), 
                Width = 100, 
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
            // Load sách
            var dsSach = sachBLL.LayTatCaSach();
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
            cboSach.DataSource = dsSach;
            
            if (isEditMode && chiTiet != null)
            {
                cboSach.SelectedValue = chiTiet.MaSach;
                cboSach.Enabled = false; // Cannot change book in edit mode
                nudSoLuong.Value = chiTiet.SoLuong;
                txtDonGiaBan.Text = chiTiet.DonGiaBan.ToString();
            }
            
            UpdateTonKho();
            UpdateThanhTien();
        }
        
        private void UpdateTonKho()
        {
            if (cboSach.SelectedValue != null)
            {
                var sach = sachBLL.LaySachTheoMa(cboSach.SelectedValue.ToString());
                if (sach != null)
                {
                    lblTonKho.Text = $"{sach.SoLuongTon} cuốn";
                    lblTonKho.ForeColor = sach.SoLuongTon > 0 ? Color.FromArgb(40, 167, 69) : Color.FromArgb(220, 53, 69);
                    
                    // Auto-fill price
                    if (!isEditMode && string.IsNullOrWhiteSpace(txtDonGiaBan.Text))
                    {
                        txtDonGiaBan.Text = sach.DonGiaBan.ToString();
                    }
                }
                else
                {
                    lblTonKho.Text = "N/A";
                }
            }
            else
            {
                lblTonKho.Text = "N/A";
            }
        }
        
        private void UpdateThanhTien()
        {
            if (decimal.TryParse(txtDonGiaBan.Text, out decimal donGia))
            {
                decimal thanhTien = (decimal)nudSoLuong.Value * donGia;
                lblThanhTien.Text = $"{thanhTien:N0} VNĐ";
            }
            else
            {
                lblThanhTien.Text = "0 VNĐ";
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (cboSach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!decimal.TryParse(txtDonGiaBan.Text, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Focus();
                return;
            }
            
            // Check stock availability
            string maSach = cboSach.SelectedValue.ToString();
            int soLuong = (int)nudSoLuong.Value;
            
            if (!sachBLL.KiemTraTonKhoDu(maSach, soLuong))
            {
                MessageBox.Show($"Không đủ tồn kho!\nSố lượng yêu cầu: {soLuong}\nHiện tại chỉ còn: {sachBLL.LaySachTheoMa(maSach).SoLuongTon}", 
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                var dto = new ChiTietHoaDonDTO
                {
                    SoHD = soHD,
                    MaSach = maSach,
                    SoLuong = soLuong,
                    DonGiaBan = donGia
                };
                
                bool success = chiTietBLL.ThemChiTiet(dto);
                
                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết thất bại!\nKiểm tra lại thông tin hoặc tồn kho không đủ.", 
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
