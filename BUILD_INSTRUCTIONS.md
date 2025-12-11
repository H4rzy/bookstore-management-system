# 🔧 Hướng Dẫn Build Project và Cài Đặt EPPlus

## Bước 1: Mở Project trong Visual Studio

1. Mở Visual Studio 2019/2022
2. File → Open → Project/Solution
3. Chọn file: `c:\Users\PC\Documents\baitap\asp\QLNS\QLNS.sln`

## Bước 2: Build Project (Kiểm Tra Lỗi)

1. Nhấn `Ctrl + Shift + B` hoặc Build → Build Solution
2. Project **nên build thành công** vì đã remove EPPlus dependency
3. Kiểm tra Output window: Should see "Build succeeded"

**Nếu có lỗi:**
- Kiểm tra Error List (View → Error List)
- Đảm bảo .NET Framework 4.8 đã cài đặt
- Clean solution: Build → Clean Solution, sau đó Rebuild

## Bước 3: Test FormRevenueStatistic

1. Chạy project: Nhấn `F5`
2. Login vào hệ thống
3. Vào Dashboard → Click "Báo cáo doanh thu"
4. FormRevenueStatistic sẽ mở với:
   - Filter panel (Từ ngày, Đến ngày, Nhóm theo)
   - Summary panel (Tổng doanh thu, lợi nhuận, tỷ lệ)
   - DataGridView hiển thị dữ liệu
   - Chart hiển thị biểu đồ cột và đường
   - Button "Xuất CSV" để export data

## Bước 4: Test Export CSV

1. Trong FormRevenueStatistic, click "📊 Xuất CSV"
2. Chọn nơi lưu file
3. File CSV sẽ được tạo với encoding UTF-8 (hỗ trợ tiếng Việt)
4. Mở file bằng Excel để xem

**Lưu ý:** File CSV có thể mở bằng Excel, nhưng formatting không đẹp bằng file .xlsx

## Bước 5: (Tùy chọn) Cài Đặt EPPlus để Export Excel

Nếu muốn export file Excel (.xlsx) đầy đủ với formatting:

### Cách 1: Qua NuGet Package Manager UI

1. Trong Visual Studio: Tools → NuGet Package Manager → Manage NuGet Packages for Solution
2. Click tab "Browse"
3. Tìm "EPPlus"
4. Chọn version **4.5.3.3** (quan trọng - phiên bản miễn phí LGPL)
5. Chọn project "QLNS"
6. Click "Install"

### Cách 2: Qua Package Manager Console

1. Tools → NuGet Package Manager → Package Manager Console
2. Chạy lệnh:
   ```
   Install-Package EPPlus -Version 4.5.3.3
   ```

### Sau khi cài EPPlus:

Tôi sẽ cung cấp code để upgrade lại từ CSV export sang Excel export với EPPlus.

## Troubleshooting

### Lỗi: "The type or namespace name 'EPPlus' could not be found"
**Nguyên nhân:** Package chưa được cài  
**Giải pháp:** Làm theo Bước 5 ở trên

### Lỗi: "Could not load file or assembly 'System.Windows.Forms.DataVisualization'"
**Nguyên nhân:** .NET Framework reference thiếu  
**Giải pháp:**  
1. Right-click project QLNS → Add → Reference
2. Assemblies → Framework
3. Tìm "System.Windows.Forms.DataVisualization"
4. Check vào và click OK

### Lỗi: "Connection string not found"
**Nguyên nhân:** Database chưa được setup  
**Giải pháp:**  
1. Mở file `DBConnect.cs`
2. Kiểm tra connection string
3 Đảm bảo SQL Server đang chạy
4. Database "QuanLyNhaSach" đã được tạo

### Form không hiển thị dữ liệu
**Nguyên nhân:** Database trống hoặc không có dữ liệu trong khoảng thời gian đã chọn  
**Giải pháp:**  
1. Thêm dữ liệu mẫu vào database (HoaDon, ChiTietHoaDon, Sach)
2. Hoặc thay đổi date range để bao gồm dữ liệu có sẵn

## Kiểm Tra Kết Quả

Sau khi build thành công, bạn nên thấy:

✅ Form mở không bị lỗi  
✅ DataGridView hiển thị dữ liệu (nếu có data trong DB)  
✅ Chart hiển thị biểu đồ  
✅ Summary panel hiển thị tổng hợp  
✅ Export CSV hoạt động

## Next Steps

Khi FormRevenueStatistic đã hoạt động tốt, tôi sẽ tiếp tục:

1. Redesign FormInventoryStatistic
2. Redesign FormTopBooksStatistic
3. Tạo FormSalesReport mới
4. Tạo FormCustomerReport mới
5. Remove Crystal Reports references hoàn toàn

---

**Lưu ý quan trọng:**  
- CSV export hiện tại **đã hoạt động** và không cần EPPlus
- EPPlus chỉ cần thiết nếu muốn file Excel (.xlsx) với formatting đẹp
- Version 4.5.3.3 của EPPlus là LGPL license (miễn phí cho mọi mục đích)
