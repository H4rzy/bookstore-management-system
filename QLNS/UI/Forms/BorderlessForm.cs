using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLNS.UI.Forms
{
    /// <summary>
    /// Form base class với title bar custom và 3 nút (_, □, ✕)
    /// Tất cả form khác thừa kế class này
    /// </summary>
    public class BorderlessForm : Form
    {
        // ============ BIẾN TOÀN CỤC ============
        
        private Panel pnlTitleBar;           // Panel chứa title bar
        private Button btnMinimize;          // Nút minimize
        private Button btnMaximize;          // Nút maximize/restore
        private Button btnClose;             // Nút close
        private Label lblTitle;              // Label hiển thị tên form
        
        private Point lastMousePos;          // Vị trí chuột cuối cùng (để drag form)
        private bool isDragging = false;     // Flag để detect drag
        private bool isMaximized = false;    // Flag để track trạng thái maximize
        
        // ============ CONSTRUCTOR ============
        
        public BorderlessForm()
        {
            // Cấu hình form borderless
            this.FormBorderStyle = FormBorderStyle.None;    // Không viền
            this.ControlBox = false;                        // Ẩn nút mặc định Windows
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = true;                      // Hiển thị trong taskbar
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Tạo custom title bar
            InitializeTitleBar();
        }
        
        // ============ KHỞI TẠO TITLE BAR ============
        
        /// <summary>
        /// Tạo title bar custom với 3 nút ở góc phải
        /// </summary>
        private void InitializeTitleBar()
        {
            // Tạo panel chứa title bar
            pnlTitleBar = new Panel
            {
                Height = 40,                                // Chiều cao title bar
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(45, 45, 50),    // Màu xám đen (theme)
                Cursor = Cursors.Default
            };
            
            // Tạo label hiển thị tên form
            lblTitle = new Label
            {
                AutoSize = false,
                Text = this.Text,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Padding = new Padding(15, 0, 0, 0)
            };
            
            // ===== TẠO 3 NÚT ĐIỀU KHIỂN =====
            
            // Nút CLOSE (ở phải nhất)
            btnClose = CreateControlButton("✕", 0);  // Vị trí 0 (phải nhất)
            btnClose.Click += (s, e) => this.Close();
            btnClose.BackColor = Color.FromArgb(232, 17, 35);  // Đỏ
            btnClose.MouseEnter += (s, e) => btnClose.BackColor = Color.FromArgb(241, 112, 122);
            btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.FromArgb(232, 17, 35);
            
            // Nút MAXIMIZE (ở giữa)
            btnMaximize = CreateControlButton("□", 1);  // Vị trí 1
            btnMaximize.Click += BtnMaximize_Click;
            btnMaximize.BackColor = Color.FromArgb(60, 60, 65);  // Xám
            btnMaximize.MouseEnter += (s, e) => btnMaximize.BackColor = Color.FromArgb(90, 90, 95);
            btnMaximize.MouseLeave += (s, e) => btnMaximize.BackColor = Color.FromArgb(60, 60, 65);
            
            // Nút MINIMIZE (ở trái nhất)
            btnMinimize = CreateControlButton("─", 2);  // Vị trí 2 (trái nhất) - Unicode horizontal line
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            btnMinimize.BackColor = Color.FromArgb(60, 60, 65);  // Xám
            btnMinimize.MouseEnter += (s, e) => btnMinimize.BackColor = Color.FromArgb(90, 90, 95);
            btnMinimize.MouseLeave += (s, e) => btnMinimize.BackColor = Color.FromArgb(60, 60, 65);
            btnMinimize.TextAlign = ContentAlignment.MiddleCenter;  // Center the icon
            btnMinimize.Padding = new Padding(0, 0, 0, 8);  // Shift up slightly
            
            // Thêm các nút vào title bar
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Controls.Add(btnMinimize);
            pnlTitleBar.Controls.Add(btnMaximize);
            pnlTitleBar.Controls.Add(btnClose);
            
            // Thêm title bar vào form
            this.Controls.Add(pnlTitleBar);
            this.Controls.SetChildIndex(pnlTitleBar, 0);  // Đưa lên trên
            
            // ===== SỰ KIỆN DRAG FORM =====
            pnlTitleBar.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left && !isMaximized)
                {
                    isDragging = true;
                    lastMousePos = e.Location;
                }
            };
            
            pnlTitleBar.MouseMove += (s, e) =>
            {
                if (isDragging && !isMaximized)
                {
                    int dx = e.X - lastMousePos.X;
                    int dy = e.Y - lastMousePos.Y;
                    this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
                }
            };
            
            pnlTitleBar.MouseUp += (s, e) =>
            {
                isDragging = false;
            };
            
            // Double-click title bar để maximize/restore
            pnlTitleBar.DoubleClick += (s, e) => BtnMaximize_Click(null, null);
        }
        
        // ============ HỖ TRỢ TẠO NÚT ============
        
        /// <summary>
        /// Tạo nút điều khiển (Minimize, Maximize, Close)
        /// </summary>
        private Button CreateControlButton(string symbol, int position)
        {
            Button btn = new Button
            {
                Text = symbol,
                Width = 45,
                Height = 40,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Right,
                Margin = new Padding(0)
            };
            
            btn.FlatAppearance.BorderSize = 0;
            
            return btn;
        }
        
        // ============ SỰ KIỆN NÚT MAXIMIZE ============
        
        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "❐";  // Thay icon khi maximize
                isMaximized = true;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Text = "□";  // Đổi lại icon
                isMaximized = false;
            }
        }
        
        // ============ CẬP NHẬT TITLE ============
        
        /// <summary>
        /// Ghi đè Text property để cập nhật label title
        /// </summary>
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                if (lblTitle != null)
                {
                    lblTitle.Text = value;
                }
            }
        }
        
        // ============ THUỘC TÍNH TÙYCHỈNH ============
        
        /// <summary>
        /// Đặt màu cho title bar
        /// </summary>
        public Color TitleBarBackColor
        {
            get => pnlTitleBar.BackColor;
            set => pnlTitleBar.BackColor = value;
        }
        
        /// <summary>
        /// Đặt chiều cao title bar
        /// </summary>
        public int TitleBarHeight
        {
            get => pnlTitleBar.Height;
            set => pnlTitleBar.Height = value;
        }
        
        /// <summary>
        /// Đặt font title
        /// </summary>
        public Font TitleFont
        {
            get => lblTitle.Font;
            set => lblTitle.Font = value;
        }
    }
}
