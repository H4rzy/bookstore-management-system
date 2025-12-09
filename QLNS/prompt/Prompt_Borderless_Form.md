# Prompt: Thêm Nút Close/Resize/Minimize Ở Góc Phải WinForm

## 🎯 Mục Tiêu
Tự định nghĩa nút **Close**, **Minimize**, **Maximize/Restore** ở góc phải trên cùng của WinForm, 
thay thế các nút mặc định của Windows. Hiển thị theo kiểu modern (Material Design), 
áp dụng cho tất cả form trong ứng dụng.

---

## 📐 Thiết Kế
```
┌─────────────────────────────────────────────────┬─────┬─────┬────┐
│ Form Title                                      │  _  │  □  │ ✕  │
└─────────────────────────────────────────────────┴─────┴─────┴────┘
                                                  Minimize Maximize Close
```

---

## 🏗️ Architecture

### 1. **Form Không Viền (Borderless)**
- ✅ Set `FormBorderStyle = FormBorderStyle.None`
- ✅ Set `ControlBox = false` (Ẩn nút mặc định)
- ✅ Custom title bar với 3 nút

### 2. **Custom Title Bar Control**
- Tạo 1 custom control `CustomTitleBar.cs`
- Hoặc tạo 1 base class `BorderlessForm.cs` để reuse

### 3. **3 Nút Điều Khiển**
- 🔘 **Minimize** (_) → `WindowState = FormWindowState.Minimized`
- 🔘 **Maximize/Restore** (□) → Toggle `WindowState` giữa `Normal` & `Maximized`
- 🔘 **Close** (✕) → `this.Close()`

---

## 📝 Phương Án 1: Base Class BorderlessForm (Khuyên Dùng)

### Tệp: `QLNS/UI/Forms/BorderlessForm.cs`

```csharp
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
            btnMinimize = CreateControlButton("_", 2);  // Vị trí 2 (trái nhất)
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            btnMinimize.BackColor = Color.FromArgb(60, 60, 65);  // Xám
            btnMinimize.MouseEnter += (s, e) => btnMinimize.BackColor = Color.FromArgb(90, 90, 95);
            btnMinimize.MouseLeave += (s, e) => btnMinimize.BackColor = Color.FromArgb(60, 60, 65);
            
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
```

---

## 🔧 Cách Sử Dụng: Cập Nhật Các Form Hiện Tại

### Trước (Cũ):
```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
}
```

### Sau (Mới):
```csharp
// Thay đổi thừa kế từ Form → BorderlessForm
public partial class Form1 : BorderlessForm
{
    public Form1()
    {
        InitializeComponent();
    }
}
```

**Các bước:**
1. Mở Designer của Form
2. Xóa các Panel/Label cũ (nếu có viền/title bar custom)
3. Đổi `Form` thành `BorderlessForm` trong code-behind
4. Save & Rebuild

---

## 📝 Phương Án 2: Custom Control (Tùy Chọn)

Nếu muốn reuse title bar cho nhiều control khác nhau:

### Tệp: `QLNS/UI/Controls/CustomTitleBar.cs`

```csharp
public class CustomTitleBar : UserControl
{
    public event EventHandler MinimizeClick;
    public event EventHandler MaximizeClick;
    public event EventHandler CloseClick;
    public event MouseEventHandler TitleBarMouseDown;
    
    private Button btnMinimize, btnMaximize, btnClose;
    private Label lblTitle;
    
    public CustomTitleBar()
    {
        InitializeComponent();
        InitializeButtons();
    }
    
    // ... (Tương tự BorderlessForm nhưng là UserControl)
    
    public string TitleText
    {
        get => lblTitle.Text;
        set => lblTitle.Text = value;
    }
}
```

---

## 🎨 Tùy Chỉnh Màu Sắc & Style

### Thay đổi theme trong `BorderlessForm.cs`:

```csharp
// Theme xám (Mặc định)
pnlTitleBar.BackColor = Color.FromArgb(45, 45, 50);

// Theme xanh dương
pnlTitleBar.BackColor = Color.FromArgb(33, 150, 243);

// Theme tối
pnlTitleBar.BackColor = Color.FromArgb(30, 30, 30);

// Theme đỏ
pnlTitleBar.BackColor = Color.FromArgb(220, 53, 69);
```

### Lớp con tuỳ chỉnh:

```csharp
public class DarkThemeForm : BorderlessForm
{
    public DarkThemeForm() : base()
    {
        this.TitleBarBackColor = Color.FromArgb(30, 30, 30);
    }
}

public class BlueThemeForm : BorderlessForm
{
    public BlueThemeForm() : base()
    {
        this.TitleBarBackColor = Color.FromArgb(33, 150, 243);
    }
}
```

---

## 🚀 Hướng Dẫn Triển Khai

### Bước 1: Copy Code
```
Tệp: BorderlessForm.cs
Vị trí: QLNS/UI/Forms/BorderlessForm.cs (tạo mới)
```

### Bước 2: Cập Nhật Các Form Hiện Tại
```
Form1.cs:      Form → BorderlessForm
FormLogin.cs:  Form → BorderlessForm
(... các form khác)
```

### Bước 3: Build & Test
```
Ctrl+Shift+B
F5 (Run)
```

### Bước 4: Kiểm Tra Chức Năng
- ✅ Click nút Minimize → Form bị ẩn (vào taskbar)
- ✅ Click nút Maximize → Form phóng to toàn màn hình
- ✅ Click nút Close → Form đóng
- ✅ Kéo title bar → Form di chuyển
- ✅ Double-click title bar → Toggle maximize/normal

---

## 📋 Danh Sách Form Cần Update

```
□ Form1.cs                    (Main form)
□ FormLogin.cs                (Login form)
□ FormNavBooks.cs             (Quản lý Sách)
□ FormStaff.cs                (Quản lý Nhân Viên)
□ FormCustomers.cs            (Quản lý Khách Hàng)
□ FormNavImport.cs            (Nhập Hàng)
□ FormNavReceipt.cs           (Hóa Đơn)
□ FormStatistic.cs            (Báo Cáo)
```

---

## 🎯 Kết Quả Mong Đợi

### Trước:
```
┌─────────────────────────────────────┐
│ 🔘 Form Title           [_][□][✕]   │  ← Nút mặc định Windows
├─────────────────────────────────────┤
│                                     │
│            Nội dung form            │
│                                     │
└─────────────────────────────────────┘
```

### Sau:
```
┌─────────────────────────────────────────┐
│ Form Title                      [_][□][✕]│ ← Custom buttons
├─────────────────────────────────────────┤
│                                         │
│            Nội dung form                │
│                                         │
└─────────────────────────────────────────┘
```

---

## ✨ Tính Năng Bổ Sung (Tùy Chọn)

### 1. **Drag Anywhere (Không Chỉ Title Bar)**
```csharp
// Cho phép kéo từ bất kỳ chỗ nào trên form
this.MouseDown += (s, e) =>
{
    if (e.Button == MouseButtons.Left && this.WindowState == FormWindowState.Normal)
    {
        isDragging = true;
        lastMousePos = e.Location;
    }
};
```

### 2. **Snap to Screen Edges**
```csharp
// Khi maximize, form snap vào edge
private void SnapToEdge()
{
    // Code để snap form vào cạnh màn hình
}
```

### 3. **Custom Button Icons (Sử Dụng Font Awesome)**
```csharp
// Thay vì text "✕", dùng icon từ font
// Font.Name = "FontAwesome"
// btnClose.Text = "\uf00d"  // Icon X
```

---

## 🔍 Troubleshooting

### Problem 1: Title bar bị che khuất
**Solution:** Kiểm tra `Controls.SetChildIndex(pnlTitleBar, 0)`

### Problem 2: Form không thể resize
**Solution:** Thêm resize logic:
```csharp
private const int RESIZE_BORDER = 5;
// Thêm sự kiện MouseMove để resize
```

### Problem 3: Menu/Toolbar bị ẩn
**Solution:** Đặt `Dock = DockStyle.Fill` cho control chính (Panel)

---

## 📚 Dependencies

- `System.Drawing` (Colors, Font)
- `System.Windows.Forms` (Form, Button, Panel, Label)
- **Không cần thư viện bên ngoài** ✅

---

## 💾 File Cấu Trúc

```
QLNS/
├── UI/
│   └── Forms/
│       ├── BorderlessForm.cs          ← TẠO MỚI
│       ├── Form1.cs                   ← CẬP NHẬT
│       ├── FormLogin.cs               ← CẬP NHẬT
│       ├── FormNavBooks.cs            ← CẬP NHẬT
│       ├── FormStaff.cs               ← CẬP NHẬT
│       └── ... (các form khác)
```

---

## 🎓 Tóm Tắt

| Bước | Công Việc |
|------|----------|
| 1 | Tạo `BorderlessForm.cs` |
| 2 | Cập nhật các form để thừa kế `BorderlessForm` |
| 3 | Build & Test |
| 4 | Tuỳ chỉnh màu sắc/theme (tùy chọn) |
| 5 | Thêm tính năng bổ sung (tùy chọn) |

---

## ✅ Checklist

- [ ] Đã tạo BorderlessForm.cs
- [ ] Đã cập nhật Form1.cs → BorderlessForm
- [ ] Đã cập nhật FormLogin.cs → BorderlessForm
- [ ] Build thành công (Ctrl+Shift+B)
- [ ] Test nút Minimize
- [ ] Test nút Maximize/Restore
- [ ] Test nút Close
- [ ] Test drag form (kéo title bar)
- [ ] Test double-click title bar
- [ ] Tuỳ chỉnh màu sắc nếu cần
- [ ] Deploy & test trên máy khác

---

## 📞 Liên Hệ

Nếu gặp lỗi hay vấn đề:
1. Check `FormBorderStyle = FormBorderStyle.None`
2. Check `ControlBox = false`
3. Verify `Controls.SetChildIndex(pnlTitleBar, 0)`
4. Debug: Thêm breakpoint để track sự kiện

---

**Status:** ✅ Ready to Implement  
**Time Estimate:** 2-3 giờ để update tất cả form  
**Difficulty:** ⭐⭐ (Dễ - Trung bình)
