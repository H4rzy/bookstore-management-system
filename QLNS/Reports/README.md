# Hướng Dẫn Tạo Crystal Report Files

## Tổng Quan
Thư mục `Reports` chứa các file Crystal Report (.rpt) để hiển thị thống kê. Bạn cần tạo 4 file báo cáo sau bằng Crystal Reports Designer.

## Các File Report Cần Tạo

### 1. RevenueReport.rpt - Báo Cáo Doanh Thu

**Parameters:**
- `StartDate` (Date) - Ngày bắt đầu
- `EndDate` (Date) - Ngày kết thúc
- `GroupBy` (String) - Nhóm theo: "Ngày", "Tháng", hoặc "Năm"

**Data Source - SQL Query:**
```sql
SELECT 
    hd.NgayBan,
    YEAR(hd.NgayBan) AS Nam,
    MONTH(hd.NgayBan) AS Thang,
    DAY(hd.NgayBan) AS Ngay,
    COUNT(DISTINCT hd.SoHD) AS SoLuongHoaDon,
    SUM(ct.SoLuong * ct.DonGiaBan) AS DoanhThu,
    SUM(ct.SoLuong * s.DonGiaNhap) AS ChiPhi,
    SUM(ct.SoLuong * ct.DonGiaBan) - SUM(ct.SoLuong * s.DonGiaNhap) AS LoiNhuan
FROM HoaDon hd
JOIN ChiTietHoaDon ct ON hd.SoHD = ct.SoHD
JOIN Sach s ON ct.MaSach = s.MaSach
WHERE hd.NgayBan BETWEEN {?StartDate} AND {?EndDate}
GROUP BY hd.NgayBan, YEAR(hd.NgayBan), MONTH(hd.NgayBan), DAY(hd.NgayBan)
ORDER BY hd.NgayBan
```

**Fields:**
- NgayBan (Date)
- SoLuongHoaDon (Number)
- DoanhThu (Currency)
- ChiPhi (Currency)
- LoiNhuan (Currency)

**Grouping:** Group by parameter `GroupBy` (Ngay/Thang/Nam)

---

### 2. TopBooksReport.rpt - Sách Bán Chạy

**Parameters:**
- `StartDate` (Date)
- `EndDate` (Date)
- `TopN` (Number) - Số lượng sách hiển thị
- `Category` (String) - Thể loại ("Tất cả" hoặc tên thể loại cụ thể)

**Data Source - SQL Query:**
```sql
SELECT TOP {?TopN}
    s.MaSach,
    s.TenSach,
    s.TacGia,
    tl.TenTheLoai,
    SUM(ct.SoLuong) AS SoLuongBan,
    SUM(ct.SoLuong * ct.DonGiaBan) AS DoanhThu
FROM ChiTietHoaDon ct
JOIN Sach s ON ct.MaSach = s.MaSach
JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
JOIN HoaDon hd ON ct.SoHD = hd.SoHD
WHERE hd.NgayBan BETWEEN {?StartDate} AND {?EndDate}
    AND (tl.TenTheLoai = {?Category} OR {?Category} = 'Tất cả')
GROUP BY s.MaSach, s.TenSach, s.TacGia, tl.TenTheLoai
ORDER BY SUM(ct.SoLuong) DESC
```

**Fields:**
- Rank (Row Number)
- MaSach (String)
- TenSach (String)
- TacGia (String)
- TenTheLoai (String)
- SoLuongBan (Number)
- DoanhThu (Currency)

---

### 3. InventoryReport.rpt - Báo Cáo Tồn Kho

**Parameters:**
- `Category` (String) - Thể loại
- `LowStockThreshold` (Number) - Ngưỡng cảnh báo

**Data Source - SQL Query:**
```sql
SELECT 
    s.MaSach,
    s.TenSach,
    tl.TenTheLoai,
    s.SoLuongTon,
    s.DonGiaNhap,
    s.DonGiaBan,
    s.SoLuongTon * s.DonGiaNhap AS GiaTriTonKho,
    CASE 
        WHEN s.SoLuongTon <= {?LowStockThreshold} THEN N'Cảnh báo'
        ELSE N'Bình thường'
    END AS TrangThai
FROM Sach s
JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
WHERE tl.TenTheLoai = {?Category} OR {?Category} = 'Tất cả'
ORDER BY s.SoLuongTon ASC
```

**Fields:**
- MaSach (String)
- TenSach (String)
- TenTheLoai (String)
- SoLuongTon (Number)
- DonGiaNhap (Currency)
- DonGiaBan (Currency)
- GiaTriTonKho (Currency)
- TrangThai (String) - Conditional formatting: Red if "Cảnh báo"

---

### 4. CustomerReport.rpt - Phân Tích Khách Hàng

**Parameters:**
- `StartDate` (Date)
- `EndDate` (Date)
- `CustomerType` (String) - Loại khách hàng

**Data Source - SQL Query:**
```sql
SELECT 
    kh.MaKH,
    kh.TenKH,
    kh.DienThoai,
    kh.LoaiKH,
    COUNT(DISTINCT hd.SoHD) AS SoLuongDonHang,
    SUM(ct.SoLuong * ct.DonGiaBan) AS TongChiTieu,
    MAX(hd.NgayBan) AS MuaHangGanNhat
FROM KhachHang kh
LEFT JOIN HoaDon hd ON kh.MaKH = hd.MaKH
LEFT JOIN ChiTietHoaDon ct ON hd.SoHD = ct.SoHD
WHERE (hd.NgayBan BETWEEN {?StartDate} AND {?EndDate} OR hd.NgayBan IS NULL)
    AND (kh.LoaiKH = {?CustomerType} OR {?CustomerType} = 'Tất cả')
GROUP BY kh.MaKH, kh.TenKH, kh.DienThoai, kh.LoaiKH
ORDER BY SUM(ct.SoLuong * ct.DonGiaBan) DESC
```

**Fields:**
- MaKH (String)
- TenKH (String)
- DienThoai (String)
- LoaiKH (String)
- SoLuongDonHang (Number)
- TongChiTieu (Currency)
- MuaHangGanNhat (Date)

---

## Cách Tạo Crystal Report trong Visual Studio

1. **Add New Item:**
   - Right-click vào thư mục `Reports`
   - Add → New Item → Crystal Reports
   - Chọn tên file (e.g., RevenueReport.rpt)

2. **Configure Report:**
   - Choose "Standard" report wizard
   - Select "Create New Connection" → ADO.NET
   - Chọn connection string tới database QuanLyNhaSach

3. **Add Parameters:**
   - Field Explorer → Parameter Fields → Right-click → New
   - Nhập tên và kiểu dữ liệu theo bảng trên

4. **Add SQL Query:**
   - Database Expert → Add Command
   - Copy query SQL từ hướng dẫn trên
   - Click OK

5. **Design Layout:**
   - Drag fields vào các sections (Report Header, Details, Report Footer)
   - Format currency fields: Right-click → Format Field → Currency
   - Add grouping nếu cần
   - Add summary totals trong Report Footer

6. **Test Report:**
   - Preview → Nhập giá trị parameters
   - Verify data hiển thị đúng

## Lưu Ý

- Tất cả file .rpt phải được lưu trong thư mục `Reports`
- Connection string phải trỏ đúng tới database `QuanLyNhaSach`
- Định dạng tiền tệ: VNĐ hoặc #,##0.00
- Định dạng ngày: dd/MM/yyyy
- Build project sau khi tạo xong các reports để copy files vào thư mục output
