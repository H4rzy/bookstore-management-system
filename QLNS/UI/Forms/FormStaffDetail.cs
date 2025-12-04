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
using QLNS_UI.Common;

namespace QLNS.UI.Forms
{
    public partial class FormStaffDetail : Form
    {
        private string maNV;
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();
        private TaiKhoan_BLL taiKhoanBLL = new TaiKhoan_BLL();
        private NhanVienDTO currentNhanVien;
        private TaiKhoanDTO currentTaiKhoan;

        public FormStaffDetail(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void FormStaffDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Load employee data
                currentNhanVien = nhanVienBLL.LayNhanVienTheoMa(maNV);
                if (currentNhanVien == null)
                {
                    MessageHelper.ShowError("Lỗi", "Không tìm thấy nhân viên");
                    this.Close();
                    return;
                }

                // Load account data
                var dsTaiKhoan = taiKhoanBLL.LayDanhSachTaiKhoan();
                currentTaiKhoan = dsTaiKhoan.FirstOrDefault(tk => tk.MaNV == maNV);

                // Fill employee info
                txtMaNV.Text = currentNhanVien.MaNV;
                txtTenNV.Text = currentNhanVien.TenNV;
                cboGioiTinh.Text = currentNhanVien.GioiTinh ? "Nam" : "Nữ";
                txtDienThoai.Text = currentNhanVien.DienThoai;
                txtDiaChi.Text = currentNhanVien.DiaChi;
                txtChucVu.Text = currentNhanVien.ChucVu;

                // Fill account info
                if (currentTaiKhoan != null)
                {
                    txtTenDangNhap.Text = currentTaiKhoan.TenDangNhap;
                    cboQuyen.Text = currentTaiKhoan.Quyen;
                }
                else
                {
                    txtTenDangNhap.Text = "Chưa có tài khoản";
                    cboQuyen.SelectedIndex = 1; // Default to User
                }

                // Clear password fields
                txtPassword.Clear();
                txtConfirmPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi tải dữ liệu", ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate employee fields
                if (!ControlHelper.ValidateRequiredTextBox(txtTenNV, "Tên nhân viên"))
                    return;

                if (!ValidationHelper.IsValidName(txtTenNV.Text.Trim()))
                {
                    MessageHelper.ShowInvalidDataError("Tên nhân viên", "Chỉ chấp nhận chữ cái");
                    txtTenNV.Focus();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtDienThoai.Text) &&
                    !ValidationHelper.IsValidPhone(txtDienThoai.Text.Trim()))
                {
                    MessageHelper.ShowInvalidDataError("Điện thoại", "Số điện thoại không hợp lệ");
                    txtDienThoai.Focus();
                    return;
                }

                // Validate password if changed
                bool updatePassword = false;
                if (!string.IsNullOrWhiteSpace(txtPassword.Text) || !string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageHelper.ShowError("Lỗi", "Mật khẩu xác nhận không khớp");
                        txtConfirmPassword.Focus();
                        return;
                    }

                    if (txtPassword.Text.Length < 6)
                    {
                        MessageHelper.ShowError("Lỗi", "Mật khẩu phải có ít nhất 6 ký tự");
                        txtPassword.Focus();
                        return;
                    }

                    updatePassword = true;
                }

                // Update employee
                NhanVienDTO nv = new NhanVienDTO
                {
                    MaNV = txtMaNV.Text.Trim(),
                    TenNV = txtTenNV.Text.Trim(),
                    GioiTinh = cboGioiTinh.Text == "Nam",
                    DienThoai = txtDienThoai.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    ChucVu = txtChucVu.Text.Trim()
                };

                if (!nhanVienBLL.CapNhatNhanVien(nv))
                {
                    MessageHelper.ShowUpdateError("nhân viên");
                    return;
                }

                // Update account if exists
                if (currentTaiKhoan != null)
                {
                    TaiKhoanDTO tk = new TaiKhoanDTO
                    {
                        TenDangNhap = currentTaiKhoan.TenDangNhap,
                        MaNV = txtMaNV.Text.Trim(),
                        Quyen = cboQuyen.Text,
                        MatKhau = updatePassword ? txtPassword.Text : currentTaiKhoan.MatKhau
                    };

                    if (!taiKhoanBLL.CapNhatTaiKhoan(tk, updatePassword))
                    {
                        MessageHelper.ShowUpdateError("tài khoản");
                        return;
                    }
                }

                MessageHelper.ShowUpdateSuccess("nhân viên và tài khoản");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi lưu dữ liệu", ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
