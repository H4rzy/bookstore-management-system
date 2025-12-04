# Hướng dẫn sử dụng FormBooks

## Tính năng

FormBooks là form quản lý sách với đầy đủ chức năng CRUD và tìm kiếm.

### Giao diện

```
┌─────────────────────────────────────────────────────────┐
│ QUẢN LÝ SÁCH                    [Tìm kiếm] [Tìm kiếm]  │
├──────────────┬──────────────────────────────────────────┤
│ Mã sách      │                                          │
│ Tên sách     │         ListView hiển thị sách           │
│ Thể loại     │                                          │
│ Nhà xuất bản │         (8 cột thông tin)                │
│ Tác giả      │                                          │
│ Giá nhập     │                                          │
│ Giá bán      │                                          │
│ Số lượng     │                                          │
│              │                                          │
│ [Thêm] [Cập nhật]                                       │
│ [Xóa]  [Làm mới]                                        │
├──────────────┴──────────────────────────────────────────┤
│ Tổng số: X sách                        [Làm mới]       │
└─────────────────────────────────────────────────────────┘
```

## Chức năng chi tiết

### 1. Xem danh sách sách
- ListView hiển thị 8 cột:
  - Mã sách
  - Tên sách
  - Thể loại
  - Nhà xuất bản
  - Tác giả
  - Giá nhập (định dạng số)
  - Giá bán (định dạng số)
  - Tồn kho
- Click vào sách để xem chi tiết

### 2. Thêm sách mới
1. Nhập đầy đủ thông tin vào các trường bên trái
2. Chọn thể loại từ ComboBox
3. Chọn nhà xuất bản từ ComboBox
4. Click nút **"Thêm mới"**

**Validation tự động:**
- Kiểm tra mã sách trùng
- Kiểm tra giá bán >= giá nhập
- Kiểm tra số lượng >= 0
- Kiểm tra thể loại và NXB tồn tại

### 3. Cập nhật sách
1. Click vào sách trong ListView
2. Thông tin tự động hiển thị ở panel bên trái
3. Chỉnh sửa thông tin cần thiết
4. Click nút **"Cập nhật"**

**Lưu ý:**
- Mã sách không thể sửa (disabled khi chọn)
- Nút "Thêm mới" bị disabled khi đang sửa
- Nút "Cập nhật" chỉ enabled khi chọn sách

### 4. Xóa sách
1. Click vào sách trong ListView
2. Click nút **"Xóa"**
3. Xác nhận xóa

**Cảnh báo:**
- Không thể xóa nếu sách đã có trong hóa đơn/phiếu nhập
- Hệ thống sẽ thông báo lỗi nếu có constraint

### 5. Tìm kiếm
- Nhập từ khóa vào ô tìm kiếm (góc phải trên)
- Tìm kiếm tự động khi gõ (TextChanged event)
- Hoặc click nút "Tìm kiếm"
- Tìm theo: Mã sách, Tên sách, Tác giả

### 6. Làm mới
- Nút "Làm mới" ở panel trái: Xóa dữ liệu nhập liệu
- Nút "Làm mới" ở panel dưới: Tải lại danh sách sách

## Màu sắc và thiết kế

### Màu chủ đạo
- **Header**: `#1A2035` (Xanh đen đậm)
- **Panel trái**: `#F0F2F5` (Xám nhạt)
- **Nút Thêm**: `#28A745` (Xanh lá)
- **Nút Cập nhật**: `#FFC107` (Vàng)
- **Nút Xóa**: `#DC3545` (Đỏ)
- **Nút Làm mới**: `#6C757D` (Xám)
- **Nút Tìm kiếm**: `#18A1FB` (Xanh dương)

### Font chữ
- **Tiêu đề**: Segoe UI, 16pt, Bold
- **Label**: Segoe UI, 9pt, Bold
- **Input**: Segoe UI, 10pt
- **Button**: Segoe UI, 9-10pt, Bold

## Sử dụng kiến trúc 3 lớp

Form sử dụng đầy đủ 3 lớp đã được xây dựng:

```csharp
// BLL Layer - Business Logic
private readonly ISachService _sachService;

// DAL Layer - Data Access
private readonly ITheLoaiRepository _theLoaiRepository;
private readonly INhaXuatBanRepository _nxbRepository;

// Dependency Injection
_sachService = ServiceContainer.Instance.Resolve<ISachService>();
```

### Ví dụ thêm sách
```csharp
var newBook = new Sach
{
    MaSach = "S005",
    TenSach = "SOLID Principles",
    MaTheLoai = "TL003",
    MaNXB = "NXB01",
    TacGia = "Robert C. Martin",
    DonGiaNhap = 150000,
    DonGiaBan = 299000,
    SoLuongTon = 20
};

if (_sachService.AddBook(newBook, out string errorMessage))
{
    // Thành công
    LoadBooks();
}
else
{
    // Hiển thị lỗi từ BLL
    MessageBox.Show(errorMessage);
}
```

## Thông báo lỗi

Tất cả lỗi đều được xử lý và hiển thị rõ ràng:

1. **Validation errors** (từ BLL):
   - "Mã sách không được để trống"
   - "Giá bán phải lớn hơn giá nhập"
   - "Thể loại không tồn tại trong hệ thống"

2. **Format errors**:
   - "Vui lòng nhập đúng định dạng số cho giá và số lượng"

3. **Database errors**:
   - "Lỗi khi thêm sách: [chi tiết lỗi]"

## Tích hợp với hệ thống

Form này có thể được mở từ:

```csharp
// Từ Form1 hoặc form khác
var formBooks = new FormBooks();
formBooks.Show(); // Hoặc ShowDialog()
```

## Lưu ý khi sử dụng

1. **Database phải tồn tại**: Chạy script `sql_quan_ly_nha_sach.sql` trước
2. **Connection string**: Đã được cấu hình trong `DatabaseContext.cs`
3. **Thể loại và NXB**: Phải có dữ liệu trước khi thêm sách
4. **Format số**: Nhập số không có dấu phẩy (e.g., 150000 không phải 150,000)

## Keyboard shortcuts

- **Tab**: Di chuyển giữa các trường
- **Enter**: Kích hoạt nút focus
- **Esc**: Có thể thêm để clear hoặc đóng form

## Cải tiến trong tương lai

- [ ] Export danh sách ra Excel
- [ ] Import sách từ file
- [ ] In báo cáo tồn kho
- [ ] Thông báo sách sắp hết
- [ ] Lọc theo nhiều điều kiện
- [ ] Sắp xếp theo cột
- [ ] Phân trang cho danh sách lớn
