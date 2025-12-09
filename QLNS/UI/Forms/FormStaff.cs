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
            LoadData();
            cboGioiTinh.SelectedIndex = 0; // Default to Nam
            
            // Check admin permission
            CheckPermission();
        }
        
        private void CheckPermission()
        {
            bool isAdmin = CurrentUser.IsAdmin;
            
            // Disable buttons for non-admin users
            btnAdd.Enabled = isAdmin;
            btnSave.Enabled = isAdmin;
            btnDelete.Enabled = isAdmin;
            btnEdit.Enabled = isAdmin;
            
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
    }
}
