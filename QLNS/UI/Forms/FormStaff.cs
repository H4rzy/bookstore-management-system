using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.UI.Forms;
using QLNS_BLL;
using QLNS_DTO;
using QLNS_UI.Common;

namespace QLNS.Forms
{
    public partial class FormStaff : Form
    {
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();
        private TaiKhoan_BLL taiKhoanBLL = new TaiKhoan_BLL();
        private bool isEditMode = false;

        public FormStaff()
        {
            InitializeComponent();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            LoadFilters();
            LoadData();
            cboGioiTinh.SelectedIndex = 0; // Default to Nam
            
            // Check admin permission
            CheckPermission();
        }
        
        private void LoadFilters()
        {
            // Load position filter using BLL method
            var positions = nhanVienBLL.LayDanhSachChucVu();
            cboFilterChucVu.Items.Clear();
            cboFilterChucVu.Items.Add("Tất cả");
            foreach (var pos in positions)
            {
                cboFilterChucVu.Items.Add(pos);
            }
            cboFilterChucVu.SelectedIndex = 0;
            
            // Gender filter already has items from Designer
            cboFilterGioiTinh.SelectedIndex = 0;
        }
        
        private void cboFilterChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        
        private void cboFilterGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        
        private void ApplyFilters()
        {
            try
            {
                List<NhanVienDTO> dsNhanVien;
                
                // Filter by gender first using BLL methods
                string selectedGender = cboFilterGioiTinh.SelectedItem?.ToString() ?? "Tất cả";
                if (selectedGender == "Nam")
                {
                    dsNhanVien = nhanVienBLL.LayDanhSachNhanVienNam();
                }
                else if (selectedGender == "Nữ")
                {
                    dsNhanVien = nhanVienBLL.LayDanhSachNhanVienNu();
                }
                else
                {
                    dsNhanVien = nhanVienBLL.LayDanhSachNhanVien();
                }
                
                // Then filter by position using BLL method
                string selectedPosition = cboFilterChucVu.SelectedItem?.ToString() ?? "Tất cả";
                if (selectedPosition != "Tất cả" && !string.IsNullOrEmpty(selectedPosition))
                {
                    var filteredByPosition = nhanVienBLL.LayNhanVienTheoChucVu(selectedPosition);
                    dsNhanVien = dsNhanVien.Where(nv => filteredByPosition.Any(fp => fp.MaNV == nv.MaNV)).ToList();
                }
                
                // Get account info
                var dsTaiKhoan = taiKhoanBLL.LayDanhSachTaiKhoan();
                
                // Join data
                var staffData = from nv in dsNhanVien
                                join tk in dsTaiKhoan on nv.MaNV equals tk.MaNV into tkGroup
                                from tk in tkGroup.DefaultIfEmpty()
                                select new
                                {
                                    MaNV = nv.MaNV,
                                    TenNV = nv.TenNV,
                                    GioiTinh = nv.GioiTinh ? "Nam" : "Nữ",
                                    DienThoai = nv.DienThoai,
                                    DiaChi = nv.DiaChi,
                                    ChucVu = nv.ChucVu,
                                    TenDangNhap = tk != null ? tk.TenDangNhap : "",
                                    Quyen = tk != null ? tk.Quyen : ""
                                };
                
                ControlHelper.BindDataGridView(dgvStaff, staffData.ToList());
                
                if (dgvStaff.Columns.Count > 0)
                {
                    dgvStaff.Columns["MaNV"].HeaderText = "Mã NV";
                    dgvStaff.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
                    dgvStaff.Columns["GioiTinh"].HeaderText = "Giới Tính";
                    dgvStaff.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvStaff.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvStaff.Columns["ChucVu"].HeaderText = "Chức Vụ";
                    dgvStaff.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
                    dgvStaff.Columns["Quyen"].HeaderText = "Quyền";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi lọc dữ liệu", ex.Message);
            }
        }
        
        private void CheckPermission()
        {
            bool isAdmin = CurrentUser.IsAdmin;
            
            // Disable buttons for non-admin users
            btnAdd.Enabled = isAdmin;
            btnSave.Enabled = isAdmin;
            btnDelete.Enabled = isAdmin;
            btnEdit.Enabled = isAdmin;
            
            // Advanced tab buttons
            btnGanTaiKhoan.Enabled = isAdmin;
            btnResetPass.Enabled = isAdmin;
            btnKhoaTK.Enabled = isAdmin;
            btnMoKhoaTK.Enabled = isAdmin;
            btnXoaTK.Enabled = isAdmin;
            
            // Disable input fields for non-admin users
            txtMaNV.Enabled = isAdmin;
            txtTenNV.Enabled = isAdmin;
            cboGioiTinh.Enabled = isAdmin;
            txtDienThoai.Enabled = isAdmin;
            txtDiaChi.Enabled = isAdmin;
            txtChucVu.Enabled = isAdmin;
            
            if (!isAdmin)
            {
                MessageBox.Show("Bạn chỉ có quyền xem danh sách nhân viên.\nChỉ Admin mới có quyền thêm/sửa/xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadData()
        {
            try
            {
                // Get employee list
                var dsNhanVien = nhanVienBLL.LayDanhSachNhanVien();
                var dsTaiKhoan = taiKhoanBLL.LayDanhSachTaiKhoan();

                // Join data
                var staffData = from nv in dsNhanVien
                                join tk in dsTaiKhoan on nv.MaNV equals tk.MaNV into tkGroup
                                from tk in tkGroup.DefaultIfEmpty()
                                select new
                                {
                                    MaNV = nv.MaNV,
                                    TenNV = nv.TenNV,
                                    GioiTinh = nv.GioiTinh ? "Nam" : "Nữ",
                                    DienThoai = nv.DienThoai,
                                    DiaChi = nv.DiaChi,
                                    ChucVu = nv.ChucVu,
                                    TenDangNhap = tk != null ? tk.TenDangNhap : "",
                                    Quyen = tk != null ? tk.Quyen : ""
                                };

                ControlHelper.BindDataGridView(dgvStaff, staffData.ToList());

                if (dgvStaff.Columns.Count > 0)
                {
                    dgvStaff.Columns["MaNV"].HeaderText = "Mã NV";
                    dgvStaff.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
                    dgvStaff.Columns["GioiTinh"].HeaderText = "Giới Tính";
                    dgvStaff.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvStaff.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvStaff.Columns["ChucVu"].HeaderText = "Chức Vụ";
                    dgvStaff.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
                    dgvStaff.Columns["Quyen"].HeaderText = "Quyền";
                }

                if (dgvStaff.Rows.Count > 0)
                {
                    dgvStaff.CurrentCell = dgvStaff.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load dữ liệu", ex.Message);
            }
        }

        private void dgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvStaff))
                return;

            try
            {
                var selectedRow = dgvStaff.CurrentRow;
                if (selectedRow == null) return;

                string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                NhanVienDTO nv = nhanVienBLL.LayNhanVienTheoMa(maNV);

                if (nv != null)
                {
                    isEditMode = true;
                    txtMaNV.Text = nv.MaNV;
                    txtMaNV.Enabled = false;
                    txtTenNV.Text = nv.TenNV;
                    cboGioiTinh.Text = nv.GioiTinh ? "Nam" : "Nữ";
                    txtDienThoai.Text = nv.DienThoai;
                    txtDiaChi.Text = nv.DiaChi;
                    txtChucVu.Text = nv.ChucVu;
                }
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền thêm nhân viên!", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            ClearInputs();
            isEditMode = false;
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền lưu thông tin nhân viên!", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                // Create DTO
                NhanVienDTO nv = new NhanVienDTO
                {
                    MaNV = txtMaNV.Text.Trim(),
                    TenNV = txtTenNV.Text.Trim(),
                    GioiTinh = cboGioiTinh.Text == "Nam",
                    DienThoai = txtDienThoai.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    ChucVu = txtChucVu.Text.Trim()
                };

                // Validate using BLL method
                string errorMessage;
                if (!nhanVienBLL.KiemTraDuLieuHopLe(nv, out errorMessage))
                {
                    MessageHelper.ShowError("Dữ liệu không hợp lệ", errorMessage);
                    return;
                }

                if (isEditMode)
                {
                    // Update
                    if (nhanVienBLL.CapNhatNhanVien(nv))
                    {
                        MessageHelper.ShowUpdateSuccess("nhân viên");
                        string currentMaNV = txtMaNV.Text.Trim();
                        LoadData();
                        
                        // Reselect the updated row
                        foreach (DataGridViewRow row in dgvStaff.Rows)
                        {
                            if (row.Cells["MaNV"].Value?.ToString() == currentMaNV)
                            {
                                row.Selected = true;
                                dgvStaff.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageHelper.ShowUpdateError("nhân viên");
                    }
                }
                else
                {
                    // Add
                    if (nhanVienBLL.KiemTraTrungMa(nv.MaNV))
                    {
                        MessageHelper.ShowError("Lỗi", "Mã nhân viên đã tồn tại");
                        txtMaNV.Focus();
                        return;
                    }

                    if (nhanVienBLL.ThemNhanVien(nv))
                    {
                        MessageHelper.ShowAddSuccess("nhân viên");
                        LoadData();
                        ClearInputs();
                    }
                    else
                    {
                        MessageHelper.ShowAddError("nhân viên", "Không thể thêm nhân viên");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi lưu dữ liệu", ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền xóa nhân viên!", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                if (!ControlHelper.IsRowSelected(dgvStaff))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                var selectedRow = dgvStaff.CurrentRow;
                if (selectedRow == null) return;

                string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                string tenNV = selectedRow.Cells["TenNV"].Value.ToString();

                // Check if can delete using BLL method
                if (!nhanVienBLL.KiemTraCoTheXoa(maNV))
                {
                    MessageHelper.ShowError("Không thể xóa", 
                        "Nhân viên này có phiếu nhập hoặc hóa đơn.\nKhông thể xóa.");
                    return;
                }

                if (!MessageHelper.ShowDeleteConfirm($"nhân viên '{tenNV}'"))
                    return;

                if (nhanVienBLL.XoaNhanVien(maNV))
                {
                    MessageHelper.ShowDeleteSuccess("nhân viên");
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageHelper.ShowDeleteError("nhân viên", "Không thể xóa nhân viên");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi xóa nhân viên", ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền sửa thông tin nhân viên!", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                if (!ControlHelper.IsRowSelected(dgvStaff))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                var selectedRow = dgvStaff.CurrentRow;
                if (selectedRow == null) return;

                string maNV = selectedRow.Cells["MaNV"].Value.ToString();

                // Open detail form (FormStaffDetail for account editing)
                FormStaffDetail frmDetail = new FormStaffDetail(maNV);
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Reload data after edit
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi mở form chi tiết", ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    LoadData();
                    return;
                }

                var result = nhanVienBLL.TimKiemNhanVien(txtTimKiem.Text.Trim());

                if (result.Rows.Count == 0)
                    MessageHelper.ShowNoDataFound();

                ControlHelper.BindDataGridView(dgvStaff, result);

                // Update column headers
                if (dgvStaff.Columns.Count > 0)
                {
                    dgvStaff.Columns["MaNV"].HeaderText = "Mã NV";
                    dgvStaff.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
                    dgvStaff.Columns["GioiTinh"].HeaderText = "Giới Tính";
                    dgvStaff.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvStaff.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvStaff.Columns["ChucVu"].HeaderText = "Chức Vụ";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi tìm kiếm", ex.Message);
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.Handled = true;
            }
        }

        private void ClearInputs()
        {
            txtMaNV.Clear();
            txtMaNV.Enabled = true;
            txtTenNV.Clear();
            cboGioiTinh.SelectedIndex = 0;
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtChucVu.Clear();
            txtMaNV.Focus();
            isEditMode = false;
        }

        /// <summary>
        ///Gán tài khoản cho nhân viên (SF004.05)
        /// </summary>
        private void btnGanTaiKhoan_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền gán tài khoản!", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!ControlHelper.IsRowSelected(dgvStaff))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                var selectedRow = dgvStaff.CurrentRow;
                string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                string tenNV = selectedRow.Cells["TenNV"].Value.ToString();
                string tenDangNhap = selectedRow.Cells["TenDangNhap"].Value?.ToString();

                // Kiểm tra đã có tài khoản chưa
                if (!string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show($"Nhân viên này đã có tài khoản: {tenDangNhap}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mở form gán tài khoản
                FormGanTaiKhoan frmGan = new FormGanTaiKhoan(maNV, tenNV);
                if (frmGan.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Reload to show new account
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi gán tài khoản", ex.Message);
            }
        }

        /// <summary>
        /// Reset mật khẩu (SF004.07, SF008.02)
        /// </summary>
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền reset mật khẩu!", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!ControlHelper.IsRowSelected(dgvStaff))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                var selectedRow = dgvStaff.CurrentRow;
                string tenDangNhap = selectedRow.Cells["TenDangNhap"].Value?.ToString();
                string tenNV = selectedRow.Cells["TenNV"].Value.ToString();

                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Nhân viên này chưa có tài khoản!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn reset mật khẩu cho '{tenNV}'?" + Environment.NewLine + Environment.NewLine +
                    "Mật khẩu mới sẽ được tạo tự động.",
                    "Xác nhận reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                string errorMessage;
                string newPassword = taiKhoanBLL.ResetMatKhau(tenDangNhap, out errorMessage);

                if (newPassword != null)
                {
                    MessageBox.Show(
                        $"Reset mật khẩu thành công!" + Environment.NewLine + Environment.NewLine +
                        $"Mật khẩu mới: {newPassword}" + Environment.NewLine + Environment.NewLine +
                        "Vui lòng ghi nhớ và chuyển cho nhân viên.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi reset mật khẩu", ex.Message);
            }
        }

        /// <summary>
        /// Khoá tài khoản (SF004.08)
        /// </summary>
        private void btnKhoaTK_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền khoá tài khoản!", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!ControlHelper.IsRowSelected(dgvStaff))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                var selectedRow = dgvStaff.CurrentRow;
                string tenDangNhap = selectedRow.Cells["TenDangNhap"].Value?.ToString();
                string tenNV = selectedRow.Cells["TenNV"].Value.ToString();

                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Nhân viên này chưa có tài khoản!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn khoá tài khoản '{tenDangNhap}'?" + Environment.NewLine +
                    "Nhân viên sẽ không thể đăng nhập sau khi bị khoá.",
                    "Xác nhận khoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                string errorMessage;
                if (taiKhoanBLL.KhoaTaiKhoan(tenDangNhap, out errorMessage))
                {
                    MessageBox.Show("Khoá tài khoản thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi khoá tài khoản", ex.Message);
            }
        }

        /// <summary>
        /// Mở khoá tài khoản (SF004.09)
        /// </summary>
        private void btnMoKhoaTK_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền mở khoá tài khoản!", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!ControlHelper.IsRowSelected(dgvStaff))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                var selectedRow = dgvStaff.CurrentRow;
                string tenDangNhap = selectedRow.Cells["TenDangNhap"].Value?.ToString();

                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Nhân viên này chưa có tài khoản!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string errorMessage;
                if (taiKhoanBLL.MoKhoaTaiKhoan(tenDangNhap, out errorMessage))
                {
                    MessageBox.Show("Mở khoá tài khoản thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi mở khoá tài khoản", ex.Message);
            }
        }

        /// <summary>
        /// Xóa tài khoản (SF008.03)
        /// </summary>
        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Chỉ Admin mới có quyền xóa tài khoản!", "Không có quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!ControlHelper.IsRowSelected(dgvStaff))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                var selectedRow = dgvStaff.CurrentRow;
                string tenDangNhap = selectedRow.Cells["TenDangNhap"].Value?.ToString();
                string tenNV = selectedRow.Cells["TenNV"].Value.ToString();

                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Nhân viên này chưa có tài khoản!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"BẠN CHẮC CHẮN MUỐN XÓA TÀI KHOẢN '{tenDangNhap}'?" + Environment.NewLine + Environment.NewLine +
                    "⚠️ CẢNH BÁO: Hành động này KHÔNG THỂ HOÀN TÁC!" + Environment.NewLine +
                    $"Nhân viên '{tenNV}' sẽ không thể đăng nhập nữa." + Environment.NewLine + Environment.NewLine +
                    "Nhấn Yes để xác nhận xóa.",
                    "⚠️ Xác nhận xóa tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                if (taiKhoanBLL.XoaTaiKhoan(tenDangNhap))
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể xóa tài khoản!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi xóa tài khoản", ex.Message);
            }
        }
    }
}
