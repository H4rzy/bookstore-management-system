using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using QLNS.Forms;
using QLNS.UI.Forms;
using QLNS_BLL;
using QLNS_DTO;
using Color = System.Drawing.Color;

namespace QLNS
{
    public partial class Form1 : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private PermissionService permissionService = new PermissionService();
        private Label lblUserInfo; // Display current user info
        private IconButton btnLogout; // Logout button

        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panel1.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Resize += Form1_Resize;
            
            // Initialize RBAC
            InitializeRBAC();
        }


        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }


        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                ////Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            if (!CheckAndLogPermission("SF_DASHBOARD", "Dashboard")) return;
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormDashboard(),sender);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (!CheckAndLogPermission("SF001", "Quản lý Sách")) return;
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormNavBooks(), sender);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (!CheckAndLogPermission("SF003", "Quản lý Khách Hàng")) return;
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormCustomers(), sender);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (!CheckAndLogPermission("SF004", "Quản lý Nhân Viên")) return;
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormStaff(), sender);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (!CheckAndLogPermission("SF005", "Quản lý Nhập Hàng")) return;
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormNavImport(), sender);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (!CheckAndLogPermission("SF007", "Thống Kê/Báo Cáo")) return;
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormStatistic(), sender);
        }
        private void BtnReceipt_Click(object sender, EventArgs e)
        {
            if (!CheckAndLogPermission("SF006", "Quản lý Hóa Đơn")) return;
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormNavReceipt(), sender);
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
           iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }


        //darag 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OpenChildForm(Form childForm, object a)
        {
            IconButton temp;

            temp = (IconButton)a;

            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = temp.Text;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        /// <summary>
        /// Initialize RBAC - Load user info and set button permissions
        /// </summary>
        private void InitializeRBAC()
        {
            // Add user info label to top panel
            lblUserInfo = new Label
            {
                AutoSize = false,
                ForeColor = Color.Gainsboro,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Right,
                Width = 300,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular)
            };
            panel3.Controls.Add(lblUserInfo);
            lblUserInfo.BringToFront();

            // Add logout button to sidebar
            btnLogout = new IconButton
            {
                Dock = DockStyle.Bottom,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Gainsboro,
                IconChar = IconChar.SignOutAlt,
                IconColor = Color.Gainsboro,
                IconFont = IconFont.Auto,
                IconSize = 32,
                ImageAlign = ContentAlignment.MiddleLeft,
                Text = "Đăng xuất",
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Padding = new Padding(10, 0, 20, 0),
                Height = 60
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += BtnLogout_Click;
            panel1.Controls.Add(btnLogout);

            // Display user info
            if (CurrentUser.IsLoggedIn)
            {
                lblUserInfo.Text = $"👤 {CurrentUser.TenNV}  |  {CurrentUser.CurrentSession.TenRole}";
                
                // Set button visibility based on permissions
                SetButtonPermissions();
            }
        }

        /// <summary>
        /// Set button visibility based on user permissions
        /// </summary>
        private void SetButtonPermissions()
        {
            // Dashboard - always visible
            BtnDashboard.Visible = true;

            // Books - SF001
            BtnBooks.Visible = CurrentUser.HasPermission("SF001");

            // Customers - SF003
            BtnCustomers.Visible = CurrentUser.HasPermission("SF003");

            // Staff - SF004
            BtnStaff.Visible = CurrentUser.HasPermission("SF004");

            // Import - SF005
            BtnImport.Visible = CurrentUser.HasPermission("SF005");

            // Receipt/Invoice - SF006
            BtnReceipt.Visible = CurrentUser.HasPermission("SF006");

            // Statistics - SF007
            BtnStatistics.Visible = CurrentUser.HasPermission("SF007");
        }

        /// <summary>
        /// Check permission and log activity
        /// </summary>
        private bool CheckAndLogPermission(string maManHinh, string tenManHinh)
        {
            if (!CurrentUser.HasPermission(maManHinh))
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", 
                    "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Log access
            permissionService.LogActivity(
                CurrentUser.Username,
                $"Truy cập: {tenManHinh}",
                $"Mã màn hình: {maManHinh}"
            );

            return true;
        }

        /// <summary>
        /// Logout button click handler
        /// </summary>
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Log logout
                AuthService authService = new AuthService();
                authService.Logout(CurrentUser.CurrentSession);

                // Clear session
                CurrentUser.Clear();

                // Close main form
                this.Close();

                // Show login form
                FormLogin loginForm = new FormLogin();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // User logged in again, show new main form
                    Application.Run(new Form1());
                }
                else
                {
                    // Exit application
                    Application.Exit();
                }
            }
        }
    }
}
