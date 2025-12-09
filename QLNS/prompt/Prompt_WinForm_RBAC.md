# Prompt Để Cập Nhật Project WinForm .NET Với Hệ Thống Phân Quyền RBAC

## 🎯 Mục Tiêu Chính
Cập nhật ứng dụng WinForm .NET hiện tại để tích hợp hệ thống phân quyền Role-Based Access Control (RBAC) 
dựa trên database SQL Server "QuanLyNhaSach" có sẵn. Sau khi đăng nhập, giao diện chỉ hiển thị các chức năng 
tương ứng với Role của người dùng (ADMIN, MANAGER, NHVBH, QLKHO).

---

## 📊 Database Schema Hiện Có

### Bảng Quan Trọng:
```
1. TaiKhoan (TenDangNhap, MatKhau, MaNV, MaRole, TrangThai)
2. Role (MaRole, TenRole, MoTa)
3. DM_ManHinh (MaManHinh, TenManHinh, LoaiChucNang)
4. Quyen (MaRole, MaManHinh, CoQuyen) - FK tới Role & DM_ManHinh
5. NhanVien (MaNV, TenNV, GioiTinh, DienThoai, DiaChi, ChucVu)
6. AuditLog (MaLog, TenDangNhap, HanhDong, ThoiGian, ChiTiet)

Các Stored Procedures Hỗ Trợ:
- sp_GetQuyenByUser (@TenDangNhap)
- sp_CheckQuyen (@TenDangNhap, @MaManHinh)
- sp_GetTaiKhoanInfo (@TenDangNhap)
- sp_GetAllSach
- sp_GetDoanhSoThang (@Thang, @Nam)
```

### 4 Role Trong Hệ Thống:
1. **ADMIN** (admin/123456): Toàn bộ quyền hạn
2. **MANAGER** (manager/123456): Quản lý kho + Bán hàng + Báo cáo
3. **NHVBH** (nhanvien/123456): Chỉ bán hàng + Quản lý khách
4. **QLKHO** (qlkho/123456): Quản lý sách + Nhập hàng + Báo cáo kho

---

## 🏗️ Architecture & Cấu Trúc Code Cần Thực Hiện

### 1. **Tạo Class Quản Lý Session & Phân Quyền**

```csharp
// Tệp: Models/UserSession.cs
/// <summary>
/// Lưu trữ thông tin session của người dùng hiện tại
/// Được khởi tạo sau khi đăng nhập thành công
/// </summary>
public class UserSession
{
    public string TenDangNhap { get; set; }      // Tên đăng nhập
    public string MaNV { get; set; }             // Mã nhân viên
    public string TenNV { get; set; }            // Tên nhân viên
    public string MaRole { get; set; }           // Mã vai trò (ADMIN, MANAGER, NHVBH, QLKHO)
    public string TenRole { get; set; }          // Tên vai trò
    public List<string> QuyenList { get; set; }  // Danh sách quyền (danh sách MaManHinh được phép)
    public DateTime LoginTime { get; set; }      // Thời gian đăng nhập
}

// Tệp: Services/PermissionService.cs
/// <summary>
/// Quản lý quyền hạn và kiểm tra phân quyền
/// </summary>
public class PermissionService
{
    private string _connectionString = "Server=localhost;Database=QuanLyNhaSach;User Id=sa;Password=xxx;";
    
    /// <summary>
    /// Lấy danh sách quyền của người dùng từ database
    /// </summary>
    public List<string> GetUserPermissions(string tenDangNhap)
    {
        // Gọi sp_GetQuyenByUser để lấy danh sách MaManHinh được phép
        // Trả về List<string> các MaManHinh (SF001, SF002, SF003, ...)
    }
    
    /// <summary>
    /// Kiểm tra người dùng có quyền truy cập chức năng cụ thể
    /// </summary>
    public bool CheckPermission(string tenDangNhap, string maManHinh)
    {
        // Gọi sp_CheckQuyen
        // Trả về true/false
    }
    
    /// <summary>
    /// Ghi nhật ký hoạt động (Audit Log)
    /// </summary>
    public void LogActivity(string tenDangNhap, string hanhDong, string chiTiet)
    {
        // INSERT vào bảng AuditLog
        // Ví dụ: "admin" thực hiện "Tạo hóa đơn" với số HD001
    }
}

// Tệp: Services/AuthService.cs
/// <summary>
/// Xác thực người dùng (đăng nhập)
/// </summary>
public class AuthService
{
    /// <summary>
    /// Kiểm tra tên đăng nhập và mật khẩu, trả về UserSession nếu thành công
    /// </summary>
    public UserSession Login(string tenDangNhap, string matKhau)
    {
        // 1. Query: SELECT tk.TenDangNhap, tk.MaRole, r.TenRole, nv.TenNV, nv.MaNV
        //    FROM TaiKhoan tk
        //    INNER JOIN Role r ON tk.MaRole = r.MaRole
        //    INNER JOIN NhanVien nv ON tk.MaNV = nv.MaNV
        //    WHERE tk.TenDangNhap = @TenDangNhap AND tk.MatKhau = @MatKhau AND tk.TrangThai = 1
        
        // 2. Nếu không tìm thấy -> trả về null (đăng nhập thất bại)
        
        // 3. Nếu tìm thấy:
        //    - Tạo UserSession
        //    - Gọi PermissionService.GetUserPermissions() để lấy danh sách quyền
        //    - Lưu vào UserSession.QuyenList
        //    - Ghi nhật ký: "Đăng nhập thành công"
        //    - Trả về UserSession
    }
    
    /// <summary>
    /// Đăng xuất
    /// </summary>
    public void Logout(UserSession user)
    {
        // Ghi nhật ký: "Đăng xuất"
        // Xóa session
    }
}
```

### 2. **Quản Lý Session Toàn Cục**

```csharp
// Tệp: Utilities/GlobalSession.cs
/// <summary>
/// Static class để lưu trữ session toàn cục (accessible từ bất kỳ form nào)
/// </summary>
public static class GlobalSession
{
    public static UserSession CurrentUser { get; set; }
    
    public static bool IsLoggedIn => CurrentUser != null;
    
    /// <summary>
    /// Kiểm tra người dùng có quyền truy cập chức năng này không
    /// </summary>
    public static bool HasPermission(string maManHinh)
    {
        if (!IsLoggedIn) return false;
        return CurrentUser.QuyenList.Contains(maManHinh);
    }
}
```

### 3. **Cập Nhật Form Đăng Nhập**

```csharp
// Tệp: Forms/FrmLogin.cs
private AuthService _authService = new AuthService();

private void btnLogin_Click(object sender, EventArgs e)
{
    string tenDangNhap = txtUsername.Text.Trim();
    string matKhau = txtPassword.Text;
    
    // Kiểm tra nhập liệu
    if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
    {
        MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }
    
    try
    {
        // Gọi AuthService.Login()
        UserSession user = _authService.Login(tenDangNhap, matKhau);
        
        if (user != null)
        {
            // Lưu vào GlobalSession
            GlobalSession.CurrentUser = user;
            
            // Hiển thị form chính
            FrmMain mainForm = new FrmMain();
            mainForm.Show();
            
            // Đóng form đăng nhập
            this.Hide();
        }
        else
        {
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

### 4. **Cập Nhật Form Menu Chính**

```csharp
// Tệp: Forms/FrmMain.cs
public partial class FrmMain : Form
{
    private PermissionService _permissionService = new PermissionService();
    
    public FrmMain()
    {
        InitializeComponent();
        LoadMenuByRole();
    }
    
    /// <summary>
    /// Load menu dựa trên Role của người dùng
    /// </summary>
    private void LoadMenuByRole()
    {
        // Xóa tất cả menu cũ
        menuStrip.Items.Clear();
        
        // Lấy danh sách chức năng được phép từ database
        List<MenuFeature> features = GetMenuFeaturesByRole(GlobalSession.CurrentUser.MaRole);
        
        // Nhóm theo LoaiChucNang
        var groupedFeatures = features.GroupBy(f => f.LoaiChucNang);
        
        foreach (var group in groupedFeatures)
        {
            // Tạo menu item cha (ví dụ: "Quản Lý Kho", "Bán Hàng", ...)
            ToolStripMenuItem parentMenu = new ToolStripMenuItem(group.Key);
            
            foreach (var feature in group)
            {
                // Tạo menu item con (ví dụ: "Danh sách sách", "Thêm sách", ...)
                ToolStripMenuItem childMenu = new ToolStripMenuItem(feature.TenManHinh);
                childMenu.Tag = feature.MaManHinh;  // Lưu MaManHinh để check quyền sau
                childMenu.Click += (s, e) => OnMenuItemClick(feature.MaManHinh, feature.TenManHinh);
                
                parentMenu.DropDownItems.Add(childMenu);
            }
            
            menuStrip.Items.Add(parentMenu);
        }
        
        // Thêm menu "Cài Đặt" (Thay mật khẩu, Thông tin cá nhân, Đăng xuất)
        AddSettingsMenu();
        
        // Hiển thị thông tin người dùng
        lblUser.Text = $"Xin chào: {GlobalSession.CurrentUser.TenNV} ({GlobalSession.CurrentUser.TenRole})";
    }
    
    private void OnMenuItemClick(string maManHinh, string tenManHinh)
    {
        // Kiểm tra lại quyền (để chắc chắn)
        if (!GlobalSession.HasPermission(maManHinh))
        {
            MessageBox.Show("Bạn không có quyền truy cập chức năng này", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        try
        {
            // Ghi nhật ký
            _permissionService.LogActivity(
                GlobalSession.CurrentUser.TenDangNhap,
                $"Truy cập: {tenManHinh}",
                $"Chức năng: {maManHinh}"
            );
            
            // Mở form tương ứng dựa trên MaManHinh
            OpenFormByFeature(maManHinh, tenManHinh);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void OpenFormByFeature(string maManHinh, string tenManHinh)
    {
        Form formToOpen = null;
        
        switch (maManHinh)
        {
            // SF001 = Quản lý Sách
            case "SF001":
                formToOpen = new FrmQuanLySach();
                break;
            
            // SF002 = Quản lý NXB
            case "SF002":
                formToOpen = new FrmQuanLyNXB();
                break;
            
            // SF003 = Quản lý Khách Hàng
            case "SF003":
                formToOpen = new FrmQuanLyKhachHang();
                break;
            
            // SF004 = Quản lý Nhân Viên
            case "SF004":
                formToOpen = new FrmQuanLyNhanVien();
                break;
            
            // SF005 = Phiếu Nhập
            case "SF005":
                formToOpen = new FrmPhieuNhap();
                break;
            
            // SF006 = Hóa Đơn Bán Hàng
            case "SF006":
                formToOpen = new FrmHoaDon();
                break;
            
            // SF007 = Báo Cáo
            case "SF007":
                formToOpen = new FrmBaoCao();
                break;
            
            default:
                MessageBox.Show($"Chức năng '{tenManHinh}' chưa được khai báo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
        }
        
        if (formToOpen != null)
        {
            formToOpen.MdiParent = this;  // Nếu dùng MDI
            formToOpen.Show();
        }
    }
    
    private void AddSettingsMenu()
    {
        ToolStripMenuItem settingsMenu = new ToolStripMenuItem("⚙️ Cài Đặt");
        
        // Thay mật khẩu
        ToolStripMenuItem changePasswordMenu = new ToolStripMenuItem("🔒 Thay Mật Khẩu");
        changePasswordMenu.Click += (s, e) => 
        {
            FrmChangePassword form = new FrmChangePassword();
            form.ShowDialog();
        };
        
        // Thông tin cá nhân
        ToolStripMenuItem userInfoMenu = new ToolStripMenuItem("👤 Thông Tin Cá Nhân");
        userInfoMenu.Click += (s, e) => 
        {
            FrmUserInfo form = new FrmUserInfo();
            form.ShowDialog();
        };
        
        // Đăng xuất
        ToolStripMenuItem logoutMenu = new ToolStripMenuItem("🚪 Đăng Xuất");
        logoutMenu.Click += (s, e) => 
        {
            _permissionService.LogActivity(
                GlobalSession.CurrentUser.TenDangNhap,
                "Đăng xuất",
                ""
            );
            GlobalSession.CurrentUser = null;
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
            this.Close();
        };
        
        settingsMenu.DropDownItems.Add(changePasswordMenu);
        settingsMenu.DropDownItems.Add(userInfoMenu);
        settingsMenu.DropDownItems.Add(new ToolStripSeparator());
        settingsMenu.DropDownItems.Add(logoutMenu);
        
        menuStrip.Items.Add(settingsMenu);
    }
    
    private List<MenuFeature> GetMenuFeaturesByRole(string maRole)
    {
        // Query database để lấy danh sách chức năng theo Role
        // SELECT dm.MaManHinh, dm.TenManHinh, dm.LoaiChucNang
        // FROM Quyen q
        // INNER JOIN DM_ManHinh dm ON q.MaManHinh = dm.MaManHinh
        // WHERE q.MaRole = @MaRole AND q.CoQuyen = 1
        // ORDER BY dm.LoaiChucNang, dm.TenManHinh
    }
}

// Model giới hạn
public class MenuFeature
{
    public string MaManHinh { get; set; }
    public string TenManHinh { get; set; }
    public string LoaiChucNang { get; set; }
}
```

### 5. **Kiểm Tra Quyền Trong Các Form Con**

```csharp
// Ví dụ: FrmQuanLySach.cs
public partial class FrmQuanLySach : Form
{
    public FrmQuanLySach()
    {
        InitializeComponent();
        CheckAndSetPermissions();
    }
    
    /// <summary>
    /// Kiểm tra quyền và ẩn/hiện các nút tương ứng
    /// </summary>
    private void CheckAndSetPermissions()
    {
        // Quyền xem: Luôn có (đã check ở menu)
        // btnThemSach (SF001 - Thêm sách)
        btnThemSach.Enabled = GlobalSession.HasPermission("SF001");
        
        // btnSuaSach (SF001 - Sửa sách)
        btnSuaSach.Enabled = GlobalSession.HasPermission("SF001");
        
        // btnXoaSach (SF001 - Xóa sách) - Chỉ ADMIN có
        btnXoaSach.Enabled = GlobalSession.CurrentUser.MaRole == "ADMIN";
        
        // Ví dụ khác: Nếu là NHVBH thì chỉ cho xem tên sách và giá, không cho sửa/xóa
        if (GlobalSession.CurrentUser.MaRole == "NHVBH")
        {
            btnThemSach.Enabled = false;
            btnSuaSach.Enabled = false;
            btnXoaSach.Enabled = false;
            dgvSach.Columns["TenSach"].ReadOnly = true;
            dgvSach.Columns["DonGiaBan"].ReadOnly = true;
        }
    }
    
    private void btnThemSach_Click(object sender, EventArgs e)
    {
        if (!GlobalSession.HasPermission("SF001"))
        {
            MessageBox.Show("Bạn không có quyền thêm sách", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        // Code thêm sách...
        
        // Ghi nhật ký
        PermissionService ps = new PermissionService();
        ps.LogActivity(
            GlobalSession.CurrentUser.TenDangNhap,
            "Thêm sách",
            $"Tên sách: {txtTenSach.Text}"
        );
    }
}
```

---

## 🔑 Các Lưu Ý Quan Trọng

### 1. **Mã Hóa Mật Khẩu**
- **Đang Dùng**: Plain text (123456)
- **Nên Cập Nhật**: Dùng SHA256 hoặc bcrypt
- Cơ sở dữ liệu lưu hash, không lưu plain text

### 2. **Timeout Session**
- Thêm tính năng auto-logout sau 30 phút không hoạt động
- Kiểm tra session trước mỗi lần truy cập form

### 3. **Ghi Nhật Ký Audit**
- Ghi lại tất cả hoạt động: Đăng nhập, Truy cập chức năng, Tạo/Sửa/Xóa dữ liệu
- Dùng AuditLog để review sau

### 4. **Cache Quyền**
- Lấy quyền lần đầu, lưu vào session
- Không cần query lại mỗi lần kiểm tra (ngoại trừ nếu admin đổi quyền)

### 5. **Error Handling**
- Catch Exception khi query database
- Log lỗi để debug sau

---

## 📋 SQL Queries Cần Sử Dụng

```sql
-- 1. Lấy thông tin user & Role khi đăng nhập
SELECT tk.TenDangNhap, tk.MaRole, r.TenRole, nv.TenNV, nv.MaNV, tk.TrangThai
FROM TaiKhoan tk
INNER JOIN Role r ON tk.MaRole = r.MaRole
INNER JOIN NhanVien nv ON tk.MaNV = nv.MaNV
WHERE tk.TenDangNhap = @TenDangNhap AND tk.TrangThai = 1;

-- 2. Lấy danh sách quyền của user
SELECT dm.MaManHinh, dm.TenManHinh, dm.LoaiChucNang
FROM Quyen q
INNER JOIN DM_ManHinh dm ON q.MaManHinh = dm.MaManHinh
WHERE q.MaRole = @MaRole AND q.CoQuyen = 1
ORDER BY dm.LoaiChucNang, dm.TenManHinh;

-- 3. Kiểm tra quyền cụ thể
SELECT COUNT(*) AS CoQuyen
FROM Quyen q
WHERE q.MaRole = @MaRole 
  AND q.MaManHinh = @MaManHinh 
  AND q.CoQuyen = 1;

-- 4. Ghi nhật ký
INSERT INTO AuditLog (MaLog, TenDangNhap, HanhDong, ThoiGian, ChiTiet)
VALUES (NEWID(), @TenDangNhap, @HanhDong, GETDATE(), @ChiTiet);
```

---

## 🎓 Tóm Tắt Các Bước Thực Hiện

1. ✅ **Tạo UserSession class** - Lưu thông tin user hiện tại
2. ✅ **Tạo PermissionService** - Quản lý quyền
3. ✅ **Tạo AuthService** - Xác thực đăng nhập
4. ✅ **Cập nhật FrmLogin** - Gọi AuthService, lưu session
5. ✅ **Cập nhật FrmMain** - Load menu theo Role
6. ✅ **Tạo GlobalSession** - Lưu user toàn cục
7. ✅ **Cập nhật form con** - Check quyền trước khi hành động
8. ✅ **Thêm ghi nhật ký** - Log mỗi hoạt động quan trọng

---

## 💡 Ví Dụ Thực Tế

**Khi NHVBH đăng nhập:**
- ✅ Thấy menu: Bán Hàng, Khách Hàng, Báo Cáo (Doanh số của tôi), Cài Đặt
- ❌ Không thấy: Quản Lý Kho, Quản Lý NXB, Quản Lý Nhân Viên
- ❌ Form Quản lý Sách: Nút Thêm/Sửa/Xóa bị disable

**Khi QLKHO đăng nhập:**
- ✅ Thấy menu: Quản Lý Kho (Sách, NXB, Nhập Hàng), Báo Cáo (Tồn Kho), Cài Đặt
- ❌ Không thấy: Bán Hàng, Quản Lý Khách Hàng, Quản Lý Nhân Viên
- ✅ Form Quản lý Sách: Có nút Thêm/Sửa, nhưng không có Xóa

---

## 🔗 Dữ Liệu Test

```
Đăng nhập test:
- admin / 123456 → ADMIN (toàn quyền)
- manager / 123456 → MANAGER (quản lý)
- nhanvien / 123456 → NHVBH (bán hàng)
- qlkho / 123456 → QLKHO (kho)
```

---

## 📌 Câu Hỏi Để Làm Rõ (Nếu có)

1. Database connection string là gì?
2. Project hiện tại có dùng Entity Framework không hay dùng ADO.NET?
3. Có dùng WPF hay WinForms (có vẻ là WinForms)?
4. Cần encrypt mật khẩu không hay dùng plain text tạm thời?
5. Dùng MDI (Multiple Document Interface) hay Single Document?
6. Có cần in hoá đơn không?
7. Timeout session bao lâu?
