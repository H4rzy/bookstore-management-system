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

                // Validate role
                if (string.IsNullOrWhiteSpace(cboQuyen.Text))
                {
                    MessageHelper.ShowError("Lỗi", "Vui lòng chọn quyền");
                    cboQuyen.Focus();
                    return;
                }

                // Update account
                if (currentTaiKhoan == null)
                {
                    MessageHelper.ShowError("Lỗi", "Nhân viên chưa có tài khoản");
                    return;
                }

                // Prepare DTO for update
                TaiKhoanDTO updatedAccount = new TaiKhoanDTO
                {
                    TenDangNhap = currentTaiKhoan.TenDangNhap,
                    MaNV = currentTaiKhoan.MaNV,
                    Quyen = cboQuyen.Text,
                    MatKhau = updatePassword ? txtPassword.Text : currentTaiKhoan.MatKhau
                };

                // Call BLL to update
                if (taiKhoanBLL.CapNhatTaiKhoan(updatedAccount, updatePassword))
                {
                    MessageHelper.ShowUpdateSuccess("tài khoản");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageHelper.ShowUpdateError("tài khoản");
                }
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
