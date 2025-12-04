# TÓM TẮT UI HELPER CLASSES - HỆ THỐNG QUẢN LÝ NHÀ SÁCH

> **Namespace:** `QLNS_UI.Common`  
> **Mục đích:** Hỗ trợ WinForm UI, đơn giản hóa code trong Forms  
> **Location:** `UI/Helper/`

---

## 📋 TỔNG QUAN

Đã tạo **5 Helper Classes** để hỗ trợ phát triển UI:

| File | Mục Đích | Methods | Dependencies |
|------|----------|---------|--------------|
| FormDataHelper | Load dữ liệu từ BLL | 13 | BLL, DTO |
| ControlHelper | Binding controls | 25+ | WinForms |
| ValidationHelper | Validate input | 17 | Regex |
| ComboDataProvider | Cache ComboBox data | 9 | BLL, DTO |
| MessageHelper | Hiển thị messages | 20+ | MessageBox |

---

## 1️⃣ FORMDATAHELPER.CS

### Mục đích
Trung gian giữa Form và BLL, xử lý exception, trả về dữ liệu an toàn.

### Load Methods (8)

| Method | Return | Mô Tả |
|--------|--------|-------|
| `LoadTheLoai()` | `List<TheLoaiDTO>` | Lấy tất cả thể loại |
| `LoadNhaXuatBan()` | `List<NhaXuatBanDTO>` | Lấy tất cả nhà xuất bản |
| `LoadSach()` | `List<SachDTO>` | Lấy sách còn tồn |
| `LoadTatCaSach()` | `List<SachDTO>` | Lấy tất cả sách |
| `LoadKhachHang()` | `List<KhachHangDTO>` | Lấy tất cả khách hàng |
| `LoadNhanVien()` | `List<NhanVienDTO>` | Lấy tất cả nhân viên |
| `LoadPhieuNhap()` | `List<PhieuNhapDTO>` | Lấy tất cả phiếu nhập |
| `LoadHoaDon()` | `List<HoaDonDTO>` | Lấy tất cả hóa đơn |

### Search Methods (5)

| Method | Return | Mô Tả |
|--------|--------|-------|
| `SearchTheLoai(keyword)` | `DataTable` | Tìm thể loại theo tên |
| `SearchSach(keyword)` | `DataTable` | Tìm sách theo tên |
| `SearchKhachHang(keyword)` | `DataTable` | Tìm KH theo tên |
| `SearchNhanVien(keyword)` | `DataTable` | Tìm NV theo tên |
| `SearchNhaXuatBan(keyword)` | `DataTable` | Tìm NXB theo tên |

### Pattern Code
```csharp
public static List<SachDTO> LoadSach()
{
    try
    {
        Sach_BLL bll = new Sach_BLL();
        return bll.LayDanhSachSach() ?? new List<SachDTO>();
    }
    catch (Exception ex)
    {
        MessageHelper.ShowLoadDataError("sách", ex.Message);
        return new List<SachDTO>();
    }
}
```

### Sử dụng
```csharp
// Load dữ liệu
var dsSach = FormDataHelper.LoadSach();
dgvSach.DataSource = dsSach;

// Search
var result = FormDataHelper.SearchSach(txtSearch.Text);
dgvResult.DataSource = result;
```

---

## 2️⃣ CONTROLHELPER.CS

### Mục đích
Binding và thao tác với WinForm controls một cách an toàn.

### DataGridView Methods (7)

| Method | Tham Số | Mô Tả |
|--------|---------|-------|
| `BindDataGridView<T>()` | `dgv, List<T>` | Bind list vào DGV |
| `BindDataGridView()` | `dgv, DataTable` | Bind DataTable vào DGV |
| `ClearDataGridView()` | `dgv` | Xóa data source |
| `GetSelectedRow<T>()` | `dgv` | Lấy dòng đang chọn |
| `IsRowSelected()` | `dgv` | Check có chọn dòng không |
| `HighlightInvalidCell()` | `dgv, row, col` | Highlight ô lỗi |
| `ClearHighlight()` | `dgv` | Xóa highlight |

### ComboBox Methods (5)

| Method | Tham Số | Mô Tả |
|--------|---------|-------|
| `BindComboBox<T>()` | `cbo, List<T>, display, value` | Bind list |
| `BindComboBox()` | `cbo, DataTable, display, value` | Bind table |
| `SetComboBoxValue()` | `cbo, value` | Set giá trị |
| `GetComboBoxValue()` | `cbo` | Lấy giá trị |
| `ClearComboBox()` | `cbo` | Clear combo |

### TextBox Methods (3)

| Method | Tham Số | Mô Tả |
|--------|---------|-------|
| `BindTextBox<T>()` | `txt, obj, propertyName` | Bind property |
| `ClearTextBoxes()` | `container` | Clear tất cả TextBox |
| `ValidateRequiredTextBox()` | `txt, fieldName` | Validate bắt buộc |

### ListView Methods (3)

| Method | Tham Số | Mô Tả |
|--------|---------|-------|
| `BindListView<T>()` | `lv, List<T>, columns` | Bind list |
| `GetSelectedListViewItem()` | `lv` | Lấy item chọn |
| `ClearListView()` | `lv` | Clear ListView |

### NumericUpDown & DateTimePicker (5)

| Method | Tham Số | Mô Tả |
|--------|---------|-------|
| `ValidateNumericUpDown()` | `num, fieldName` | Validate > 0 |
| `GetNumericUpDownValue()` | `num` | Lấy giá trị int |
| `SetNumericUpDownValue()` | `num, value` | Set giá trị |
| `BindDateTimePicker()` | `dtp, DateTime?` | Bind ngày |
| `GetDateTimePickerValue()` | `dtp` | Lấy DateTime |

### Sử dụng
```csharp
// DataGridView
ControlHelper.BindDataGridView(dgvSach, dsSach);
SachDTO selected = ControlHelper.GetSelectedRow<SachDTO>(dgvSach);

// ComboBox
ControlHelper.BindComboBox(cboTheLoai, dsTheLoai, "TenTheLoai", "MaTheLoai");

// TextBox
if (!ControlHelper.ValidateRequiredTextBox(txtTenSach, "Tên sách"))
    return;

// DateTimePicker
ControlHelper.BindDateTimePicker(dtpNgayNhap, DateTime.Now);
```

---

## 3️⃣ VALIDATIONHELPER.CS

### Mục đích
Validate dữ liệu đầu vào trước khi gửi BLL.

### General Validation (6)

| Method | Return | Mô Tả |
|--------|--------|-------|
| `IsNullOrEmpty(value)` | `bool` | Check null/empty |
| `IsValidEmail(email)` | `bool` | Validate email |
| `IsValidPhone(phone)` | `bool` | Validate số ĐT VN (10-11 số) |
| `IsValidNumber(value)` | `bool` | Check số hợp lệ |
| `IsValidDate(date)` | `bool` | Check ngày hợp lệ |
| `IsValidInteger(value)` | `bool` | Check số nguyên |

### Bookstore Specific (4)

| Method | Return | Mô Tả |
|--------|--------|-------|
| `IsValidPrice(giaBan, giaNhap)` | `bool` | Giá bán > giá nhập |
| `IsValidQuantity(soLuong)` | `bool` | Số lượng > 0 |
| `IsValidCode(code)` | `bool` | Mã hợp lệ (chữ, số, ≤20) |
| `IsValidName(name)` | `bool` | Tên hợp lệ (≤200 ký tự) |

### Password & Username (2)

| Method | Return | Mô Tả |
|--------|--------|-------|
| `IsValidPassword(pwd)` | `bool` | Password ≥ 6 ký tự |
| `IsValidUsername(user)` | `bool` | Username 3-50 ký tự |

### Validation With Message (4)

| Method | Return | Out | Mô Tả |
|--------|--------|-----|-------|
| `ValidateRequired(value, name, out msg)` | `bool` | `string` | Validate + message |
| `ValidatePrice(giaBan, giaNhap, out msg)` | `bool` | `string` | Validate giá |
| `ValidateQuantity(soLuong, out msg)` | `bool` | `string` | Validate SL |
| `ValidatePasswordMatch(pwd, confirm, out msg)` | `bool` | `string` | So khớp MK |

### Sử dụng
```csharp
// Simple validation
if (!ValidationHelper.IsValidPhone(txtPhone.Text))
{
    MessageBox.Show("Số điện thoại không hợp lệ");
    return;
}

// With message
string msg;
if (!ValidationHelper.ValidateRequired(txtTenSach.Text, "Tên sách", out msg))
{
    MessageBox.Show(msg);
    return;
}

// Price validation
if (!ValidationHelper.IsValidPrice(numGiaBan.Value, numGiaNhap.Value))
{
    MessageBox.Show("Giá bán phải lớn hơn giá nhập");
    return;
}
```

---

## 4️⃣ COMBODATAPROVIDER.CS

### Mục đích
Cache dữ liệu ComboBox, tránh gọi BLL nhiều lần.

### Get Methods (Lazy Load + Cache) (4)

| Method | Return | Mô Tả |
|--------|--------|-------|
| `GetTheLoai()` | `List<TheLoaiDTO>` | Lấy thể loại (cache) |
| `GetNhaXuatBan()` | `List<NhaXuatBanDTO>` | Lấy NXB (cache) |
| `GetKhachHang()` | `List<KhachHangDTO>` | Lấy KH (cache) |
| `GetNhanVien()` | `List<NhanVienDTO>` | Lấy NV (cache) |

### Refresh Methods (5)

| Method | Mô Tả |
|--------|-------|
| `RefreshTheLoai()` | Làm mới cache thể loại |
| `RefreshNhaXuatBan()` | Làm mới cache NXB |
| `RefreshKhachHang()` | Làm mới cache KH |
| `RefreshNhanVien()` | Làm mới cache NV |
| `RefreshAll()` | Làm mới tất cả cache |

### Utility

| Method | Mô Tả |
|--------|-------|
| `ClearCache()` | Xóa tất cả cache |

### Cơ chế hoạt động
```
Lần 1: GetTheLoai() → Gọi BLL → Lưu cache → Return
Lần 2: GetTheLoai() → Dùng cache → Return (NHANH)
Lần 3: GetTheLoai() → Dùng cache → Return (NHANH)

Sau khi thêm/sửa/xóa → RefreshTheLoai() → Cache mới
```

### Sử dụng
```csharp
// Load ComboBox (lần đầu gọi BLL, các lần sau dùng cache)
var dsTheLoai = ComboDataProvider.GetTheLoai();
ControlHelper.BindComboBox(cboTheLoai, dsTheLoai, "TenTheLoai", "MaTheLoai");

// Sau khi thêm thể loại mới
if (bll.ThemTheLoai(dto))
{
    ComboDataProvider.RefreshTheLoai(); // Làm mới cache
    MessageHelper.ShowAddSuccess("thể loại");
}

// Làm mới tất cả khi mở form
private void Form_Load(object sender, EventArgs e)
{
    ComboDataProvider.RefreshAll();
    LoadData();
}
```

---

## 5️⃣ MESSAGEHELPER.CS

### Mục đích
Hiển thị message box nhất quán, dễ sử dụng.

### Success Messages (4)

| Method | Icon | Mô Tả |
|--------|------|-------|
| `ShowSuccess(action)` | ℹ️ | Hiện thông báo thành công |
| `ShowAddSuccess(entity)` | ℹ️ | "Thêm {entity} thành công" |
| `ShowUpdateSuccess(entity)` | ℹ️ | "Cập nhật {entity} thành công" |
| `ShowDeleteSuccess(entity)` | ℹ️ | "Xóa {entity} thành công" |

### Error Messages (6)

| Method | Icon | Mô Tả |
|--------|------|-------|
| `ShowError(title, message)` | ❌ | Hiện lỗi tùy chỉnh |
| `ShowAddError(entity, detail)` | ❌ | "Thêm {entity} thất bại" |
| `ShowUpdateError(entity, detail)` | ❌ | "Cập nhật {entity} thất bại" |
| `ShowDeleteError(entity, detail)` | ❌ | "Xóa {entity} thất bại" |
| `ShowLoadDataError(entity, detail)` | ❌ | "Tải {entity} thất bại" |
| `ShowSearchError(entity, detail)` | ❌ | "Tìm {entity} thất bại" |

### Validation Messages (3)

| Method | Icon | Mô Tả |
|--------|------|-------|
| `ShowRequiredFieldError(field)` | ⚠️ | "{field} không được trống" |
| `ShowInvalidDataError(field, reason)` | ⚠️ | "{field} không hợp lệ" |
| `ShowDuplicateError(entity, value)` | ⚠️ | "{entity} đã tồn tại" |

### Confirmation Messages (3)

| Method | Icon | Return | Mô Tả |
|--------|------|--------|-------|
| `ShowConfirm(message, title)` | ❓ | `bool` | Xác nhận tùy chỉnh |
| `ShowDeleteConfirm(entity)` | ❓ | `bool` | Xác nhận xóa |
| `ShowUpdateConfirm(entity)` | ❓ | `bool` | Xác nhận cập nhật |

### Warning Messages (4)

| Method | Icon | Mô Tả |
|--------|------|-------|
| `ShowWarning(message, title)` | ⚠️ | Cảnh báo tùy chỉnh |
| `ShowNoSelectionWarning()` | ⚠️ | "Vui lòng chọn dòng" |
| `ShowInsufficientStockWarning()` | ⚠️ | "Không đủ tồn kho" |

### Info Messages (2)

| Method | Icon | Mô Tả |
|--------|------|-------|
| `ShowInfo(message, title)` | ℹ️ | Thông báo tùy chỉnh |
| `ShowNoDataFound()` | ℹ️ | "Không tìm thấy dữ liệu" |

### Sử dụng
```csharp
// Success
if (bll.ThemSach(dto))
    MessageHelper.ShowAddSuccess("sách");

// Error
catch (Exception ex)
{
    MessageHelper.ShowLoadDataError("sách", ex.Message);
}

// Confirm
if (MessageHelper.ShowDeleteConfirm("sách"))
{
    if (bll.XoaSach(maSach))
        MessageHelper.ShowDeleteSuccess("sách");
}

// Validation
if (string.IsNullOrEmpty(txtTenSach.Text))
{
    MessageHelper.ShowRequiredFieldError("Tên sách");
    return;
}

// Warning
if (!ControlHelper.IsRowSelected(dgvSach))
{
    MessageHelper.ShowNoSelectionWarning();
    return;
}
```

---

## 📊 THỐNG KÊ

| Helper Class | Static Methods | Lines of Code | Complexity |
|--------------|----------------|---------------|------------|
| FormDataHelper | 13 | ~200 | ⭐⭐⭐ |
| ControlHelper | 25 | ~280 | ⭐⭐⭐⭐ |
| ValidationHelper | 17 | ~200 | ⭐⭐⭐ |
| ComboDataProvider | 9 | ~100 | ⭐⭐ |
| MessageHelper | 22 | ~250 | ⭐⭐ |

**Tổng: 86 methods, ~1030 lines**

---

## 🎯 WORKFLOW ĐIỂN HÌNH

### Load Form
```csharp
private void FormSach_Load(object sender, EventArgs e)
{
    try
    {
        // Load ComboBox (cache)
        var dsTheLoai = ComboDataProvider.GetTheLoai();
        ControlHelper.BindComboBox(cboTheLoai, dsTheLoai, "TenTheLoai", "MaTheLoai");
        
        // Load DataGridView
        var dsSach = FormDataHelper.LoadSach();
        ControlHelper.BindDataGridView(dgvSach, dsSach);
    }
    catch (Exception ex)
    {
        MessageHelper.ShowError("Lỗi", ex.Message);
    }
}
```

### Thêm mới
```csharp
private void btnThem_Click(object sender, EventArgs e)
{
    // Validate
    if (!ControlHelper.ValidateRequiredTextBox(txtTenSach, "Tên sách"))
        return;
        
    if (!ValidationHelper.IsValidPrice(numGiaBan.Value, numGiaNhap.Value))
    {
        MessageHelper.ShowInvalidDataError("Giá", "Giá bán phải lớn hơn giá nhập");
        return;
    }
    
    // Tạo DTO
    SachDTO sach = new SachDTO();
    sach.MaSach = txtMaSach.Text.Trim();
    sach.TenSach = txtTenSach.Text.Trim();
    sach.MaTheLoai = ControlHelper.GetComboBoxValue(cboTheLoai).ToString();
    sach.DonGiaBan = numGiaBan.Value;
    sach.DonGiaNhap = numGiaNhap.Value;
    
    // Call BLL
    Sach_BLL bll = new Sach_BLL();
    if (bll.ThemSach(sach))
    {
        MessageHelper.ShowAddSuccess("sách");
        LoadData(); // Refresh
    }
    else
    {
        MessageHelper.ShowAddError("sách");
    }
}
```

### Xóa
```csharp
private void btnXoa_Click(object sender, EventArgs e)
{
    // Check selection
    if (!ControlHelper.IsRowSelected(dgvSach))
    {
        MessageHelper.ShowNoSelectionWarning();
        return;
    }
    
    // Get selected
    SachDTO selected = ControlHelper.GetSelectedRow<SachDTO>(dgvSach);
    
    // Confirm
    if (!MessageHelper.ShowDeleteConfirm("sách"))
        return;
    
    // Delete
    Sach_BLL bll = new Sach_BLL();
    if (bll.XoaSach(selected.MaSach))
    {
        MessageHelper.ShowDeleteSuccess("sách");
        LoadData();
    }
    else
    {
        MessageHelper.ShowDeleteError("sách", "Có thể sách đang được sử dụng");
    }
}
```

### Tìm kiếm
```csharp
private void btnSearch_Click(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtSearch.Text))
    {
        LoadData(); // Hiển thị tất cả
        return;
    }
    
    var result = FormDataHelper.SearchSach(txtSearch.Text.Trim());
    
    if (result.Rows.Count == 0)
        MessageHelper.ShowNoDataFound();
    
    ControlHelper.BindDataGridView(dgvSach, result);
}
```

---

## ✅ LỢI ÍCH

### 1. **Code Ngắn Gọn**
- 1 dòng thay vì 5-10 dòng
- Tái sử dụng cao

### 2. **Nhất Quán**
- Message format giống nhau
- Validation rules thống nhất
- Error handling đồng bộ

### 3. **Dễ Bảo Trì**
- Sửa 1 chỗ → áp dụng toàn bộ
- Centralized logic

### 4. **Performance**
- Cache giảm database calls
- Lazy loading

### 5. **Giảm Lỗi**
- Try-catch tự động
- Null-safe
- Type-safe với Generics

---

## ⚠️ LƯU Ý

### Khi nào Refresh Cache?
```csharp
// SAU KHI: Thêm/Sửa/Xóa thể loại
ComboDataProvider.RefreshTheLoai();

// KHI MỞ FORM chính
ComboDataProvider.RefreshAll();

// KHÔNG CẦN refresh mỗi lần load form con
```

### Exception Handling
- Tất cả Helper methods đã có try-catch
- Return giá trị mặc định nếu lỗi
- Hiển thị error message tự động

### Performance Tips
- Dùng `ComboDataProvider` cho dữ liệu ít thay đổi
- Dùng `FormDataHelper` cho dữ liệu thường xuyên cập nhật
- Clear cache khi cần thiết

---

> **Tạo bởi:** Antigravity AI  
> **Ngày:** 2025-12-04  
> **Version:** 1.0  
> **Framework:** WinForms .NET
