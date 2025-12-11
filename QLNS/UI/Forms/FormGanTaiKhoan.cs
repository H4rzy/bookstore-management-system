using System;
using System.Windows.Forms;
using QLNS_BLL;
using QLNS_DAL;

namespace QLNS.UI.Forms
{
    public partial class FormGanTaiKhoan : Form
    {
        private string _maNV;
        private string _tenNV;

        public FormGanTaiKhoan(string maNV, string tenNV)
        {
            InitializeComponent();
            _maNV = maNV;
            _tenNV = tenNV;
            
            LoadRoles();
            lblTenNV.Text = "Nhân viên: " + tenNV;
        }

        private void LoadRoles()
        {
            try
            {
                RoleDAL roleDAL = new RoleDAL();
                var roles = roleDAL.LayDanhSachRole();
                
                cboRole.DataSource = roles;
                cboRole.DisplayMember = "TenRole";
                cboRole.ValueMember = "MaRole";
                
                if (cboRole.Items.Count > 0)
                    cboRole.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load roles: " + ex.Message, "Lỗi", MessageBoxButtons.OK,  MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string xacNhanMatKhau = txtXacNhanMatKhau.Text.Trim();
                
                // Validation
                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                    return;
                }
                
                if (string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return;
                }
                
                if (matKhau.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return;
                }
                
                if (matKhau != xacNhanMatKhau)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtXacNhanMatKhau.Focus();
                    return;
                }
                
                if (cboRole.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                string maRole = cboRole.SelectedValue.ToString();
                
                // Call BLL
                TaiKhoan_BLL bll = new TaiKhoan_BLL();
                string errorMessage;
                bool result = bll.GanTaiKhoanChoNhanVien(_maNV, tenDangNhap, matKhau, maRole, out errorMessage);
                
                if (result)
                {
                    MessageBox.Show("Gán tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
