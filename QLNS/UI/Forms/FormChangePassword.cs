using System;
using System.Windows.Forms;
using QLNS;
using QLNS_BLL;
using QLNS_DTO;

namespace QLNS.UI.Forms
{
    public partial class FormChangePassword : Form
    {
        private TaiKhoan_BLL taiKhoanBLL = new TaiKhoan_BLL();

        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {
            lblUsername.Text = $"Tài khoản: {CurrentUser.Username}";
            lblFullName.Text = $"Họ tên: {CurrentUser.TenNV}";
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (txtOldPassword.Text == txtNewPassword.Text)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            // Verify old password
            try
            {
                var taiKhoan = taiKhoanBLL.DangNhap(CurrentUser.Username, txtOldPassword.Text);
                
                if (taiKhoan == null)
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOldPassword.SelectAll();
                    txtOldPassword.Focus();
                    return;
                }

                // Change password
                bool success = taiKhoanBLL.DoiMatKhau(CurrentUser.Username, txtNewPassword.Text);

                if (success)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!\n\nVui lòng đăng nhập lại.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Application will restart - user needs to login again
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    // Show login form
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char passwordChar = chkShowPassword.Checked ? '\0' : '●';
            txtOldPassword.PasswordChar = passwordChar;
            txtNewPassword.PasswordChar = passwordChar;
            txtConfirmPassword.PasswordChar = passwordChar;
        }

        private void txtOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNewPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtConfirmPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnChangePassword_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
