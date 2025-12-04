# QLNS - Quản Lý Nhà Sách (Bookstore Management System)

## Kiến trúc 3 lớp (3-Layer Architecture)

Dự án này được xây dựng theo kiến trúc 3 lớp tuân thủ các nguyên tắc SOLID:

```
QLNS/
├── Models/          DTO - Data Transfer Objects (10 entities)
├── DAL/             Data Access Layer (18 files)
├── BLL/             Business Logic Layer (10 files)
├── Common/          ServiceContainer (Dependency Injection)
├── Examples/        Ví dụ sử dụng
└── Forms/           Giao diện Windows Forms
```

## Cấu trúc chi tiết

### 1. Models (DTO Layer)
Chứa các lớp thực thể đại diện cho cơ sở dữ liệu:
- `Sach.cs` - Sách
- `TheLoai.cs` - Thể loại
- `NhaXuatBan.cs` - Nhà xuất bản
- `KhachHang.cs` - Khách hàng
- `NhanVien.cs` - Nhân viên
- `TaiKhoan.cs` - Tài khoản
- `HoaDon.cs` - Hóa đơn
- `ChiTietHoaDon.cs` - Chi tiết hóa đơn
- `PhieuNhap.cs` - Phiếu nhập
- `ChiTietPhieuNhap.cs` - Chi tiết phiếu nhập

### 2. DAL (Data Access Layer)
Xử lý tất cả các thao tác với cơ sở dữ liệu:

**DatabaseContext.cs**: Quản lý kết nối SQL Server

**Interfaces/**: 9 interfaces cho repositories
- `IRepository<T>` - Interface chung
- `ISachRepository` - Sách
- `ITheLoaiRepository` - Thể loại
- `INhaXuatBanRepository` - Nhà xuất bản
- `IKhachHangRepository` - Khách hàng
- `INhanVienRepository` - Nhân viên
- `ITaiKhoanRepository` - Tài khoản
- `IHoaDonRepository` - Hóa đơn
- `IPhieuNhapRepository` - Phiếu nhập

**Repositories/**: 8 triển khai repository
- Tất cả các repository đều triển khai CRUD operations
- Sử dụng parameterized queries để tránh SQL Injection
- Hỗ trợ transaction cho các thao tác phức tạp

### 3. BLL (Business Logic Layer)
Chứa logic nghiệp vụ và validation:

**Interfaces/**: 5 service interfaces
- `ISachService` - Quản lý sách
- `IKhachHangService` - Quản lý khách hàng
- `INhanVienService` - Quản lý nhân viên
- `IHoaDonService` - Quản lý hóa đơn
- `IPhieuNhapService` - Quản lý phiếu nhập

**Services/**: 5 service implementations
- Validation dữ liệu đầu vào
- Kiểm tra business rules
- Xử lý lỗi và trả về thông báo chi tiết

### 4. Common
**ServiceContainer.cs**: Dependency Injection container
- Quản lý các dependencies
- Singleton pattern
- Tự động đăng ký tất cả services và repositories

## Cài đặt

### Yêu cầu
- Visual Studio 2019 trở lên
- .NET Framework 4.8
- SQL Server (LocalDB, Express, hoặc Full)

### Bước 1: Tạo cơ sở dữ liệu
Chạy script `sql_quan_ly_nha_sach.sql` để tạo database và dữ liệu mẫu.

### Bước 2: Cấu hình connection string
Cập nhật `App.config`:

```xml
<connectionStrings>
    <add name="QuanLyNhaSach" 
         connectionString="Data Source=TÊN_SERVER;Initial Catalog=QuanLyNhaSach;Integrated Security=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

Thay `TÊN_SERVER` bằng:
- `localhost` - SQL Server đầy đủ
- `(localdb)\MSSQLLocalDB` - LocalDB
- `.\SQLEXPRESS` - SQL Server Express

### Bước 3: Thêm reference
Đảm bảo project có reference đến `System.Configuration`:

1. Right-click References trong Solution Explorer
2. Add Reference
3. Tìm và chọn `System.Configuration`
4. OK

### Bước 4: Build project
```
Build > Build Solution (Ctrl+Shift+B)
```

## Sử dụng

### Ví dụ 1: Sử dụng Service trong Form

```csharp
using QLNS.BLL.Interfaces;
using QLNS.Common;
using QLNS.Models;

public partial class FormBooks : Form
{
    private readonly ISachService _sachService;

    public FormBooks()
    {
        InitializeComponent();
        
        // Lấy service từ container
        _sachService = ServiceContainer.Instance.Resolve<ISachService>();
        
        LoadBooks();
    }

    private void LoadBooks()
    {
        var books = _sachService.GetAllBooks();
        dataGridView.DataSource = books;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var newBook = new Sach
        {
            MaSach = txtMaSach.Text,
            TenSach = txtTenSach.Text,
            MaTheLoai = cmbTheLoai.SelectedValue.ToString(),
            MaNXB = cmbNXB.SelectedValue.ToString(),
            TacGia = txtTacGia.Text,
            DonGiaNhap = decimal.Parse(txtDonGiaNhap.Text),
            DonGiaBan = decimal.Parse(txtDonGiaBan.Text),
            SoLuongTon = int.Parse(txtSoLuong.Text)
        };

        if (_sachService.AddBook(newBook, out string errorMessage))
        {
            MessageBox.Show("Thêm sách thành công!", "Thông báo");
            LoadBooks();
        }
        else
        {
            MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
```

### Ví dụ 2: Tạo hóa đơn

```csharp
var hoaDonService = ServiceContainer.Instance.Resolve<IHoaDonService>();

var hoaDon = new HoaDon
{
    SoHD = "HD001",
    NgayBan = DateTime.Now,
    MaNV = "NV001",
    MaKH = "KH001",
    GhiChu = "Khách hàng VIP"
};

var chiTiet = new List<ChiTietHoaDon>
{
    new ChiTietHoaDon
    {
        SoHD = "HD001",
        MaSach = "S001",
        SoLuong = 2,
        DonGiaBan = 120000
    }
};

if (hoaDonService.CreateInvoice(hoaDon, chiTiet, out string errorMessage))
{
    MessageBox.Show("Tạo hóa đơn thành công!");
    var total = hoaDonService.CalculateInvoiceTotal("HD001");
    MessageBox.Show($"Tổng tiền: {total:N0} VNĐ");
}
else
{
    MessageBox.Show(errorMessage, "Lỗi");
}
```

## Nguyên tắc SOLID

### ✅ Single Responsibility Principle (SRP)
Mỗi class chỉ có một trách nhiệm duy nhất:
- Models: Chỉ chứa dữ liệu
- Repositories: Chỉ xử lý database
- Services: Chỉ chứa business logic
- Forms: Chỉ xử lý UI

### ✅ Open/Closed Principle (OCP)
- Sử dụng interfaces cho tất cả components
- Có thể mở rộng chức năng mà không sửa code cũ

### ✅ Liskov Substitution Principle (LSP)
- Tất cả implementations có thể thay thế cho interface
- Có thể thay SQL Server bằng database khác

### ✅ Interface Segregation Principle (ISP)
- Interface riêng biệt cho từng repository
- Không có interface "béo" với methods không cần thiết

### ✅ Dependency Inversion Principle (DIP)
- Services phụ thuộc vào interfaces, không phải implementations
- ServiceContainer quản lý dependencies

## Tính năng

✅ Quản lý sách (CRUD)
✅ Quản lý thể loại và nhà xuất bản
✅ Quản lý khách hàng
✅ Quản lý nhân viên
✅ Tạo hóa đơn bán hàng (tự động giảm tồn kho)
✅ Tạo phiếu nhập (tự động tăng tồn kho)
✅ Tìm kiếm và lọc dữ liệu
✅ Validation đầy đủ
✅ Business rules enforcement
✅ Transaction support
✅ SQL Injection prevention

## Tài liệu

- **Implementation Plan**: `C:\Users\PC\.gemini\antigravity\brain\...\implementation_plan.md`
- **Walkthrough**: `C:\Users\PC\.gemini\antigravity\brain\...\walkthrough.md`
- **Usage Examples**: `Examples/UsageExample.cs`

## Liên hệ

Nếu có thắc mắc hoặc cần hỗ trợ, vui lòng tham khảo các file documentation hoặc xem code examples.
