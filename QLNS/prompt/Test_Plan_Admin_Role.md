# 📋 Prompt: Kiểm Tra Chức Năng Admin (RBAC) & Test Case Toàn Bộ

## 🎯 Mục Tiêu
Viết hướng dẫn chi tiết **kiểm tra toàn bộ chức năng của Admin** trong hệ thống RBAC 
cùng các **test case** để đảm bảo mọi tính năng hoạt động đúng sau khi đăng nhập với role ADMIN.

---

## 🔐 Tài Khoản Test Admin

```
Username: admin
Password: 123456
Role: ADMIN
MaRole: ADMIN
Quyền: Toàn bộ hệ thống (✅ Tất cả menu đều hiển thị)
```

---

## 📊 Danh Sách Đầy Đủ Chức Năng Admin (57 Chức Năng)

### **PHẦN I: HỆ THỐNG (13 Chức Năng)**

#### 1️⃣ **Quản Lý Nhân Viên (9 Chức Năng)**
```
Mã chức năng: SF004
Menu: Hệ Thống > Quản Lý Nhân Viên

☐ SF004.01 - Xem danh sách nhân viên
  - Hiển thị tất cả nhân viên trong hệ thống
  - Columns: MaNV, TenNV, GioiTinh, DienThoai, DiaChi, ChucVu, TrangThai
  - Có search/filter theo tên

☐ SF004.02 - Thêm nhân viên mới
  - Form popup với fields: Tên, Giới tính, ĐT, Địa chỉ, Chức vụ
  - Validation: Tên không trống, Điện thoại hợp lệ
  - After save: Refresh danh sách, hiển thị message "Thêm thành công"

☐ SF004.03 - Sửa thông tin nhân viên
  - Load dữ liệu nhân viên đã chọn vào form
  - Cho phép sửa: Tên, Giới tính, ĐT, Địa chỉ, Chức vụ
  - After save: Refresh danh sách, hiển thị message "Cập nhật thành công"

☐ SF004.04 - Xóa nhân viên
  - Xóa mềm: Set IsDeleted = 1 (không hiển thị trong danh sách)
  - Confirmation dialog: "Bạn chắc chắn muốn xóa?"
  - After delete: Refresh danh sách

☐ SF004.05 - Gán tài khoản cho nhân viên
  - Chọn nhân viên → Pop-up form
  - Fields: TenDangNhap, MatKhau (auto-generate hoặc nhập)
  - Validation: TenDangNhap unique
  - After save: Ghi log "Gán tài khoản cho [TenNV]"

☐ SF004.06 - Gán Role cho nhân viên
  - Chọn nhân viên → ComboBox chọn Role (ADMIN, MANAGER, NHVBH, QLKHO)
  - Update bảng TaiKhoan: SET MaRole = @MaRole
  - After update: Ghi log "Gán role [TenRole] cho [TenNV]"

☐ SF004.07 - Thay đổi mật khẩu của nhân viên
  - Chọn nhân viên → Pop-up nhập mật khẩu mới
  - Confirm: Nhập lại mật khẩu (phải trùng)
  - Hash SHA256: SET MatKhau = SHA2(MatKhau, 256)
  - After: Ghi log "Thay đổi mật khẩu [TenNV]"

☐ SF004.08 - Khoá tài khoản nhân viên
  - Chọn nhân viên → Nút "Khoá TK"
  - Update: TaiKhoan.TrangThai = 0 (disabled)
  - After: Ghi log "Khoá tài khoản [TenNV]"

☐ SF004.09 - Mở khoá tài khoản nhân viên
  - Chọn nhân viên → Nút "Mở khoá TK"
  - Update: TaiKhoan.TrangThai = 1 (enabled)
  - After: Ghi log "Mở khoá tài khoản [TenNV]"

SQL: SELECT * FROM NhanVien WHERE IsDeleted = 0 ORDER BY TenNV;
```

#### 2️⃣ **Quản Lý Tài Khoản (3 Chức Năng)**
```
Mã chức năng: SF008
Menu: Hệ Thống > Quản Lý Tài Khoản

☐ SF008.01 - Xem danh sách tài khoản
  - Hiển thị TenDangNhap, TenNV, TenRole, TrangThai
  - Status icon: 🟢 Active, 🔴 Disabled

☐ SF008.02 - Reset mật khẩu tài khoản
  - Chọn tài khoản → Nút "Reset MK"
  - Auto-generate MK: ngẫu nhiên 8 ký tự
  - Show generated password to user
  - After: Ghi log "Reset mật khẩu [TenDangNhap]"

☐ SF008.03 - Xóa tài khoản
  - Delete từ bảng TaiKhoan
  - Confirmation: "Xóa tài khoản sẽ không thể khôi phục!"
  - After: Refresh danh sách
```

#### 3️⃣ **Quản Lý Role & Quyền (1 Chức Năng)**
```
Mã chức năng: SF009
Menu: Hệ Thống > Quản Lý Role & Quyền

☐ SF009.01 - Phân quyền chi tiết
  - Danh sách 4 Role: ADMIN, MANAGER, NHVBH, QLKHO
  - Click vào Role → Hiển thị danh sách Chức Năng (DM_ManHinh)
  - Checkbox: [✓] = Có quyền, [ ] = Không có quyền
  - Save → Update bảng Quyen (SET CoQuyen = 1/0)
  - Hiển thị bảng: Role | TenManHinh | CoQuyen (Có/Không)
```

---

### **PHẦN II: QUẢN LÝ KHO (18 Chức Năng)**

#### 4️⃣ **Quản Lý Sách (11 Chức Năng)**
```
Mã chức năng: SF001
Menu: Quản Lý Kho > Quản Lý Sách

☐ SF001.01 - Xem danh sách sách
  - DataGridView: MaSach, TenSach, TacGia, TenTheLoai, TenNXB, 
                  DonGiaBan, SoLuongTon, NamXB
  - Search box: Tìm kiếm theo Tên sách
  - Filter: Thể loại (ComboBox), NXB (ComboBox)
  - Sort: Click column header để sort

☐ SF001.02 - Thêm sách mới
  - Form: MaSach, TenSach, TacGia, ISBN, NamXB, MaTheLoai, MaNXB,
          DonGiaNhap, DonGiaBan, SoLuongTon, MoTa
  - Validation: 
    • MaSach unique
    • TenSach không trống
    • DonGiaBan > 0
    • ISBN format hợp lệ (10 hoặc 13 ký tự số)
  - After insert: Ghi log "Thêm sách: [TenSach]"

☐ SF001.03 - Sửa thông tin sách
  - Load dữ liệu sách vào form
  - Cho phép sửa tất cả fields
  - After update: Ghi log "Sửa sách: [TenSach]"

☐ SF001.04 - Xóa sách
  - Xóa mềm: UPDATE Sach SET IsDeleted = 1 WHERE MaSach = @MaSach
  - Check: Nếu có hóa đơn liên quan → không xóa được
  - Confirmation dialog

☐ SF001.05 - Xem lịch sử thay đổi giá sách
  - Click sách → Popup "Lịch sử giá"
  - Hiển thị: NgayThayDoi, GiaCu, GiaMoi, NguoiThayDoi
  - Table: SachGiaHistory (nếu có)

☐ SF001.06 - Quản lý thể loại sách (CRUD)
  - View: Danh sách thể loại (MaTheLoai, TenTheLoai)
  - Create: Form "Thêm thể loại"
  - Update: Sửa tên thể loại
  - Delete: Xóa thể loại (nếu không có sách nào dùng)

☐ SF001.07 - Xem tồn kho chi tiết
  - DataGridView: MaSach, TenSach, SoLuongTon, DonGia, GiaTriTon
  - GiaTriTon = SoLuongTon * DonGia
  - Sort theo SoLuongTon (sách sắp hết ở trên)

☐ SF001.08 - Cập nhật tồn kho
  - Chọn sách → Form "Cập nhật tồn kho"
  - Fields: SoLuongTon hiện tại (read-only), Số lượng cộng/trừ
  - Option: (+) Nhập hàng, (-) Xuất hàng, (=) Điều chỉnh
  - After: UPDATE Sach SET SoLuongTon = @SoLuong
  - Ghi log: "Cập nhật tồn kho [TenSach]: [SoLuongCu] -> [SoLuongMoi]"

☐ SF001.09 - Import sách từ Excel
  - Nút "Import Excel"
  - Chọn file (.xlsx)
  - Parse columns: MaSach, TenSach, TacGia, ISBN, MaTheLoai, MaNXB, ...
  - Validate từng row
  - Insert all valid rows
  - Show report: "Thêm X sách, Lỗi Y sách"

☐ SF001.10 - Export danh sách sách ra Excel
  - Nút "Export Excel"
  - Xuất DataGridView sang file .xlsx
  - Columns: Tất cả columns hiện tại
  - File name: Sach_[NgayXuat].xlsx

☐ SF001.11 - Xem vị trí sách trong kho (nếu có kho vật lý)
  - Form: Nhân bản, Vị trí (Kệ, Tầng, ...)
  - Display kho như sơ đồ
```

SQL Queries:
```sql
-- 1. Lấy danh sách sách
SELECT s.MaSach, s.TenSach, s.TacGia, tl.TenTheLoai, nxb.TenNXB, 
       s.DonGiaBan, s.SoLuongTon, s.NamXB
FROM Sach s
LEFT JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
WHERE s.IsDeleted = 0
ORDER BY s.TenSach;

-- 2. Thêm sách
INSERT INTO Sach (MaSach, TenSach, TacGia, ISBN, NamXB, MaTheLoai, MaNXB, 
                  DonGiaNhap, DonGiaBan, SoLuongTon, MoTa, IsDeleted)
VALUES (@MaSach, @TenSach, @TacGia, @ISBN, @NamXB, @MaTheLoai, @MaNXB,
        @DonGiaNhap, @DonGiaBan, @SoLuongTon, @MoTa, 0);

-- 3. Cập nhật tồn kho
UPDATE Sach SET SoLuongTon = @SoLuongTon WHERE MaSach = @MaSach;

-- 4. Xóa mềm sách
UPDATE Sach SET IsDeleted = 1 WHERE MaSach = @MaSach;

-- 5. Tìm sách
SELECT * FROM Sach
WHERE TenSach LIKE '%' + @TenSach + '%'
  AND (@MaTheLoai IS NULL OR MaTheLoai = @MaTheLoai)
  AND (@MaNXB IS NULL OR MaNXB = @MaNXB)
  AND IsDeleted = 0;
```

#### 5️⃣ **Quản Lý NXB (4 Chức Năng)**
```
Mã chức năng: SF002
Menu: Quản Lý Kho > Quản Lý NXB

☐ SF002.01 - Xem danh sách NXB
  - DataGridView: MaNXB, TenNXB, DienThoai, Email, DiaChi
  - Search: Tìm kiếm theo Tên NXB

☐ SF002.02 - Thêm NXB mới
  - Form: MaNXB, TenNXB, DienThoai, Email, DiaChi
  - Validation: MaNXB unique, TenNXB không trống, Email hợp lệ

☐ SF002.03 - Sửa thông tin NXB
  - Load dữ liệu vào form, cho phép sửa

☐ SF002.04 - Xóa NXB
  - Check: Nếu có sách từ NXB này → không xóa được
  - Message: "Không thể xóa, vẫn có sách từ NXB này"
```

#### 6️⃣ **Nhập Hàng (3 Chức Năng)**
```
Mã chức năng: SF005
Menu: Quản Lý Kho > Nhập Hàng

☐ SF005.01 - Tạo phiếu nhập mới
  - Form: MaPN (auto-generate), NgayNhap (default GETDATE()), 
          MaNV (current user), MaNXB (ComboBox)
  - Insert INTO PhieuNhap
  - Sau khi tạo → Cho phép thêm chi tiết

☐ SF005.02 - Thêm chi tiết phiếu nhập (sách)
  - Danh sách sách (DataGridView trong form Phiếu nhập)
  - Columns: MaSach, TenSach, SoLuong, DonGiaNhap, ThanhTien
  - Double-click → Nhập SoLuong, DonGiaNhap
  - Calculate ThanhTien = SoLuong * DonGiaNhap
  - Insert INTO ChiTietPhieuNhap

☐ SF005.03 - Hoàn thành phiếu nhập
  - Nút "Hoàn thành"
  - Validation: Phiếu phải có ít nhất 1 chi tiết
  - Update PhieuNhap SET TrangThai = 'Hoàn thành'
  - Trigger: Update tồn kho từ chi tiết phiếu nhập
  - SQL: UPDATE Sach SET SoLuongTon = SoLuongTon + @SoLuong 
         FROM ChiTietPhieuNhap WHERE MaPN = @MaPN
```

---

### **PHẦN III: BÁN HÀNG (15 Chức Năng)**

#### 7️⃣ **Bán Hàng (9 Chức Năng)**
```
Mã chức năng: SF006
Menu: Bán Hàng > Tạo Hóa Đơn

☐ SF006.01 - Tạo hóa đơn mới
  - Form: SoHD (auto-generate: HD_[YYYYMMDD_HHmmss]), 
          NgayBan (default GETDATE()), MaNV (current user)
  - Insert INTO HoaDon
  - Status: Draft → pending hoàn thành

☐ SF006.02 - Chọn khách hàng
  - Button "Chọn KH" → Form danh sách khách
  - Có thể bán lẻ (không chọn khách)
  - If chọn KH: hóa đơn gắn với MaKH

☐ SF006.03 - Thêm chi tiết hóa đơn (sách)
  - Grid: MaSach, TenSach, SoLuong, DonGia, ThanhTien
  - Click "Thêm sách" → Dialog chọn sách
  - Validation: SoLuong ≤ SoLuongTon (tồn kho có sẵn)
  - Calculate ThanhTien = SoLuong * DonGia
  - Insert INTO ChiTietHoaDon

☐ SF006.04 - Xóa chi tiết hóa đơn
  - Select row → Nút "Xóa sách"
  - DELETE FROM ChiTietHoaDon
  - Recalculate TongTien

☐ SF006.05 - Áp dụng chiết khấu
  - ComboBox "Chiết khấu": Chọn từ bảng ChietKhau
  - Display: TenChietKhau, TyLeChietKhau
  - Calculate TienGiam = TongTien * TyLeChietKhau / 100
  - ThanhTien = TongTien - TienGiam
  - Update HoaDon SET MaChietKhau = @MaChietKhau, ChietKhau = @TienGiam

☐ SF006.06 - Tính toán tổng tiền
  - Real-time: Khi thêm/xóa sách, tự động recalculate
  - Fields: TongTien (trước giảm), ChietKhau (tiền giảm), ThanhTien (phải trả)
  - Display: TongTien + ChietKhau | ChietKhau (TyLe%) | ThanhTien

☐ SF006.07 - Thanh toán hóa đơn
  - Form "Thanh toán" với options:
    • Mặt tiền (Tiền mặt)
    • Chuyển khoản (Số TK, Ngân hàng)
    • Khác (Ghi chú)
  - Nhập Số tiền thanh toán
  - Calculate: Tiền thối = Số tiền - ThanhTien
  - After thanh toán: Hóa đơn → Status "Hoàn thành"

☐ SF006.08 - Hoàn thành hóa đơn
  - Update HoaDon SET TrangThai = 'Hoàn thành'
  - Trigger 1: Update tồn kho (giảm hàng bán)
    UPDATE Sach SET SoLuongTon = SoLuongTon - @SoLuong
    FROM ChiTietHoaDon WHERE SoHD = @SoHD
  - Trigger 2: Ghi công nợ nếu có (khách hàng trả nợ)
    INSERT/UPDATE CongNo
  - Ghi log: "Hoàn thành hóa đơn [SoHD]"

☐ SF006.09 - In hóa đơn
  - Nút "In"
  - Crystal Reports hoặc Export PDF
  - Format: Header (Cửa hàng info), Details (chi tiết), Footer (tổng)
  - Print hoặc Save PDF
```

#### 8️⃣ **Quản Lý Hóa Đơn (3 Chức Năng)**
```
Mã chức năng: SF006
Menu: Bán Hàng > Danh Sách Hóa Đơn

☐ SF006.10 - Xem danh sách hóa đơn
  - DataGridView: SoHD, NgayBan, TenNV, TenKH, TongTien, ThanhTien, TrangThai
  - Search: Số hóa đơn, Ngày ban
  - Filter: Trạng thái (Draft, Hoàn thành), Nhân viên
  - Sort: Ngày (mới nhất trước)

☐ SF006.11 - Sửa hóa đơn (nếu chưa hoàn thành)
  - Status Draft: Cho phép sửa số lượng, giá, chiết khấu
  - Status Hoàn thành: Read-only
  - After update: Ghi log "Sửa hóa đơn [SoHD]"

☐ SF006.12 - Xóa hóa đơn (nếu chưa hoàn thành)
  - Status Draft: Cho phép xóa
  - Status Hoàn thành: Không xóa
  - Confirmation dialog
  - DELETE FROM ChiTietHoaDon + HoaDon
```

#### 9️⃣ **Quản Lý Chiết Khấu (3 Chức Năng)**
```
Mã chức năng: SF010
Menu: Bán Hàng > Quản Lý Chiết Khấu

☐ SF010.01 - Xem danh sách chiết khấu
  - DataGridView: MaChietKhau, TenChietKhau, TyLeChietKhau, 
                  TuNgay, DenNgay, GhiChu
  - Highlight: Chiết khấu hết hạn (DenNgay < GETDATE())
  - Filter: Đang hoạt động / Hết hạn

☐ SF010.02 - Thêm chiết khấu mới
  - Form: MaChietKhau, TenChietKhau, TyLeChietKhau (%), 
          TuNgay, DenNgay (optional), GhiChu
  - Validation: TyLeChietKhau > 0 và < 100
  - Insert INTO ChietKhau

☐ SF010.03 - Sửa/Xóa chiết khấu
  - Update/Delete từ bảng ChietKhau
  - Check: Nếu đang được dùng trong hóa đơn → không xóa được
```

---

### **PHẦN IV: KHÁCH HÀNG (9 Chức Năng)**

#### 🔟 **Quản Lý Khách Hàng (6 Chức Năng)**
```
Mã chức năng: SF003
Menu: Khách Hàng > Danh Sách Khách

☐ SF003.01 - Xem danh sách khách hàng
  - DataGridView: MaKH, TenKH, DienThoai, DiaChi, LoaiKH, NgayTaoDon
  - LoaiKH: Thường / VIP
  - Search: Tên khách, ĐT
  - Filter: Loại (Thường/VIP), Ngày tạo

☐ SF003.02 - Thêm khách hàng mới
  - Form: MaKH (auto-generate), TenKH, DienThoai, DiaChi, Email, 
          LoaiKH (default "Thường")
  - Validation: TenKH không trống, DienThoai hợp lệ (10-11 số)
  - Insert INTO KhachHang

☐ SF003.03 - Sửa thông tin khách hàng
  - Load dữ liệu vào form
  - Cho phép sửa tất cả fields
  - Update KhachHang

☐ SF003.04 - Xóa khách hàng
  - Soft delete: UPDATE KhachHang SET IsDeleted = 1
  - Check: Nếu có hóa đơn liên quan → không xóa được

☐ SF003.05 - Cấp thẻ VIP cho khách
  - Chọn khách → Nút "Cấp VIP"
  - Form: Ngày bắt đầu, Ngày hết hạn, Mô tả
  - Insert INTO TheVIP (MaTheVIP, MaKH, NgayCapPhat, NgayHetHan, DiemTichLuy)
  - Update: KhachHang.LoaiKH = 'VIP'
  - Ghi log: "Cấp VIP cho [TenKH]"

☐ SF003.06 - Xem lịch sử mua hàng
  - Chọn khách → Nút "Lịch sử mua"
  - Hiển thị danh sách hóa đơn của khách
  - Columns: SoHD, NgayBan, TongTien, ThanhTien
  - Sort: Ngày mới nhất
```

#### 1️⃣1️⃣ **Quản Lý Công Nợ (3 Chức Năng)**
```
Mã chức năng: SF011
Menu: Khách Hàng > Quản Lý Công Nợ

☐ SF011.01 - Xem danh sách công nợ
  - DataGridView: MaKH, TenKH, TongNo, DaThanhToan, ConNo, NgayDuPhaiTra
  - Filter: Chưa thanh toán (ConNo > 0), Quá hạn
  - Sort: ConNo giảm dần (nợ nhiều nhất ở trên)
  - Highlight: Quá hạn thanh toán (NgayDuPhaiTra < GETDATE())

☐ SF011.02 - Xem chi tiết công nợ từng khách
  - Chọn khách → Popup "Chi tiết công nợ"
  - Hiển thị: TongNo, DaThanhToan, ConNo, LichSuThanhToan
  - Table LichSuThanhToan: NgayThanhToan, SoTienThanhToan, GhiChu, NguoiGhi

☐ SF011.03 - Ghi nhận thanh toán
  - Form: MaKH, SoTienThanhToan, NgayThanhToan (default GETDATE()), 
          HinhThucThanhToan (Mặt tiền/Chuyển khoản), GhiChu
  - Validation: SoTienThanhToan > 0, ≤ ConNo
  - After save:
    • Insert INTO LichSuThanhToan
    • Update CongNo SET DaThanhToan = DaThanhToan + @SoTienThanhToan,
                       ConNo = ConNo - @SoTienThanhToan
    • Ghi log: "Ghi nhận thanh toán [SoTien] cho [TenKH]"
```

---

### **PHẦN V: BÁO CÁO & THỐNG KÊ (8 Chức Năng)**

#### 1️⃣2️⃣ **Báo Cáo Doanh Số (2 Chức Năng)**
```
Mã chức năng: SF012
Menu: Báo Cáo > Doanh Số

☐ SF012.01 - Báo cáo doanh số theo ngày
  - Form: Chọn từ ngày + đến ngày
  - Hiển thị:
    • Danh sách hóa đơn từng ngày
    • Columns: Ngày, SoHD, TenNV, TenKH, TongTien, ChietKhau, ThanhTien
    • Subtotal theo ngày: Số HĐ, Doanh số, Giảm giá, Thực thu
    • Grand total tất cả
  - Nút: Xuất Excel, In, Refresh
  - SQL: SELECT CONVERT(DATE, NgayBan) AS Ngay, ...
        FROM HoaDon WHERE NgayBan BETWEEN @TuNgay AND @DenNgay

☐ SF012.02 - Báo cáo doanh số theo tháng
  - Option: Chọn tháng + năm
  - Hiển thị theo tuần hoặc theo nhân viên
  - Biểu đồ: Cột (doanh số từng ngày/tuần)
  - SQL: SELECT MONTH(NgayBan), YEAR(NgayBan), ...
```

#### 1️⃣3️⃣ **Báo Cáo Tồn Kho (2 Chức Năng)**
```
Mã chức năng: SF013
Menu: Báo Cáo > Tồn Kho

☐ SF013.01 - Báo cáo tồn kho chi tiết
  - Danh sách sách:
    • MaSach, TenSach, TheLoai, SoLuongTon, DonGia, GiaTriTon
    • GiaTriTon = SoLuongTon * DonGia
  - Sort: Theo GiaTriTon (cao nhất trước)
  - Subtotal: Tổng số sách, Tổng giá trị tồn kho

☐ SF013.02 - Cảnh báo hàng sắp hết
  - Filter: SoLuongTon < 10
  - Highlight:
    • RED: SoLuongTon < 5 (Nguy hiểm)
    • YELLOW: SoLuongTon < 10 (Cảnh báo)
  - Recommendation: Cần nhập hàng
  - SQL: SELECT * FROM Sach WHERE SoLuongTon < 10 AND IsDeleted = 0
```

#### 1️⃣4️⃣ **Báo Cáo Công Nợ (1 Chức Năng)**
```
Mã chức năng: SF014
Menu: Báo Cáo > Công Nợ

☐ SF014.01 - Báo cáo công nợ
  - Danh sách khách nợ:
    • MaKH, TenKH, TongNo, DaThanhToan, ConNo, TyLeThanhToan (%)
  - Sort: ConNo giảm dần
  - Filter: Chưa thanh toán hết, Quá hạn
  - Subtotal: Tổng công nợ toàn hệ thống
  - Highlight: Quá hạn (đỏ), Sắp quá hạn (vàng)
```

#### 1️⃣5️⃣ **Audit Log Viewer (1 Chức Năng)**
```
Mã chức năng: SF015
Menu: Báo Cáo > Lịch Sử Hoạt Động

☐ SF015.01 - Xem lịch sử hoạt động (Audit Log)
  - DataGridView: TenDangNhap, HanhDong, ThoiGian, ChiTiet
  - Search: Theo người dùng, hành động
  - Filter: Ngày, loại hành động (Đăng nhập, Thêm, Sửa, Xóa)
  - Sort: ThoiGian giảm dần (mới nhất trước)
  - Nút: Export Excel, Xóa log cũ hơn N ngày

  Actions logged:
  • Đăng nhập / Đăng xuất
  • Thêm/Sửa/Xóa Sách, Khách, Nhân viên, Hóa đơn, ...
  • Thay đổi cấu hình, Role, Quyền
```

#### 1️⃣6️⃣ **Xuất Báo Cáo (2 Chức Năng)**
```
Mã chức năng: SF016
Menu: Báo Cáo > Xuất Báo Cáo

☐ SF016.01 - Xuất báo cáo ra Excel
  - Nút "Xuất Excel" có trong mỗi báo cáo
  - Save file: BaoCao_[TenBaoCao]_[Ngay].xlsx
  - Format: Header với tiêu đề, Columns, Data, Subtotal

☐ SF016.02 - Xuất báo cáo ra PDF
  - Nút "Xuất PDF" (hoặc In → Save as PDF)
  - Save file: BaoCao_[TenBaoCao]_[Ngay].pdf
  - Format: In đẹp, có trang số, ngày in
```

---

### **PHẦN VI: HỆ THỐNG & CẤU HÌNH (2 Chức Năng)**

#### 1️⃣7️⃣ **Backup Database**
```
Mã chức năng: SF017
Menu: Hệ Thống > Backup Database

☐ SF017.01 - Sao lưu database
  - Nút "Backup ngay"
  - Form: Chọn thư mục lưu
  - Execute: BACKUP DATABASE QuanLyNhaSach TO DISK = ...
  - Show progress bar
  - After: "Backup thành công tại [Path]"
  - Tự động backup hàng ngày lúc 02:00 AM (nếu có scheduler)
```

#### 1️⃣8️⃣ **Thay Đổi Mật Khẩu**
```
Mã chức năng: SF018
Menu: Cài Đặt > Thay Mật Khẩu

☐ SF018.01 - Đổi mật khẩu của mình
  - Form: Mật khẩu cũ, Mật khẩu mới, Xác nhận MK mới
  - Validation:
    • MK cũ đúng (so sánh hash SHA256)
    • MK mới ≠ MK cũ
    • MK mới confirm trùng
  - After update: Ghi log "Thay đổi mật khẩu"
```

---

## 🧪 TEST PLAN - Chi Tiết Kiểm Tra

### **Test Strategy:**
```
1. Đăng nhập: admin / 123456
2. Verify: Tất cả menu hiển thị (không bị disable)
3. Test: Từng chức năng theo thứ tự
4. Verify: Database được update đúng
5. Verify: Audit log được ghi
6. Check: Error handling, validation
7. Performance: Tốc độ load, query
```

---

## 📋 Test Case Chi Tiết

### **TC01: Kiểm Tra Menu Hiển Thị**

| # | Test | Input | Expected Result | Pass/Fail |
|---|------|-------|-----------------|-----------|
| 1.1 | Login ADMIN | admin/123456 | Menu đầy đủ, Tất cả item visible | ☐ |
| 1.2 | Click "Hệ Thống" | Click menu | Submenu: Nhân Viên, TK, Role, Audit, Backup | ☐ |
| 1.3 | Click "Quản Lý Kho" | Click menu | Submenu: Sách, NXB, Nhập Hàng | ☐ |
| 1.4 | Click "Bán Hàng" | Click menu | Submenu: Tạo HĐ, Danh sách HĐ, Chiết Khấu | ☐ |
| 1.5 | Click "Khách Hàng" | Click menu | Submenu: Danh sách, Công Nợ | ☐ |
| 1.6 | Click "Báo Cáo" | Click menu | Submenu: Doanh Số, Tồn Kho, Công Nợ, Log | ☐ |

### **TC02: Quản Lý Sách (SF001)**

| # | Test | Input | Expected Result | Pass/Fail |
|---|------|-------|-----------------|-----------|
| 2.1 | Xem danh sách | Click SF001 | Grid hiển thị ≥ 1 sách | ☐ |
| 2.2 | Search sách | Search "Lập trình" | Filter kết quả đúng | ☐ |
| 2.3 | Thêm sách | MaSach=S999, Tên=Test, ... | Insert thành công, Grid refresh | ☐ |
| 2.4 | Verify DB | Query Sach | S999 có trong bảng | ☐ |
| 2.5 | Verify Log | Query AuditLog | "Thêm sách" được log | ☐ |
| 2.6 | Sửa sách | Change Giá → 99000 | Update thành công | ☐ |
| 2.7 | Xóa sách | Delete S999 | Update IsDeleted=1 | ☐ |
| 2.8 | Export Excel | Click "Xuất Excel" | File được tạo, có dữ liệu | ☐ |
| 2.9 | Import Excel | Upload file | Sách được thêm vào DB | ☐ |

### **TC03: Quản Lý Nhân Viên (SF004)**

| # | Test | Input | Expected Result | Pass/Fail |
|---|------|-------|-----------------|-----------|
| 3.1 | Xem danh sách | Click SF004 | Grid hiển thị tất cả NV | ☐ |
| 3.2 | Thêm NV | Tên=Test, ĐT=0912345678 | Insert thành công | ☐ |
| 3.3 | Gán TK | Select NV → "Gán TK" | Form pop-up, có fields TenDN, MK | ☐ |
| 3.4 | Gán Role | Select NV → Change role → NHVBH | Role được update, Audit log | ☐ |
| 3.5 | Khoá TK | Select NV → "Khoá" | TrangThai = 0, NV không login được | ☐ |
| 3.6 | Mở khoá TK | Select NV → "Mở khoá" | TrangThai = 1, NV login được | ☐ |
| 3.7 | Reset MK | Select NV → "Reset MK" | Show new password, update DB | ☐ |
| 3.8 | Xóa NV | Select NV → Delete | Soft delete (IsDeleted=1) | ☐ |

### **TC04: Bán Hàng (SF006)**

| # | Test | Input | Expected Result | Pass/Fail |
|---|------|-------|-----------------|-----------|
| 4.1 | Tạo HĐ | Click "Tạo HĐ" | SoHD auto-gen, Draft status | ☐ |
| 4.2 | Chọn KH | Click "Chọn KH" | Form KH pop-up, select KH | ☐ |
| 4.3 | Thêm sách | Select sách, SL=5 | Add to grid, TongTien update | ☐ |
| 4.4 | Validation | SL > Tồn kho | Error message, không add được | ☐ |
| 4.5 | Chiết khấu | Select CK 5% | ChietKhau = TongTien * 0.05 | ☐ |
| 4.6 | Hoàn thành | Click "Hoàn thành" | Status=Hoàn thành, tồn kho update | ☐ |
| 4.7 | Verify tồn kho | Query Sach | SoLuongTon giảm đúng số lượng | ☐ |
| 4.8 | In HĐ | Click "In" | PDF/Print dialog | ☐ |
| 4.9 | Verify Log | Query AuditLog | "Hoàn thành HĐ" được log | ☐ |

### **TC05: Công Nợ (SF011)**

| # | Test | Input | Expected Result | Pass/Fail |
|---|------|-------|-----------------|-----------|
| 5.1 | Xem công nợ | Click SF011 | Grid hiển thị KH nợ | ☐ |
| 5.2 | Ghi nhận TT | Select KH, SoTien=100k | Insert LichSuThanhToan, ConNo giảm | ☐ |
| 5.3 | Verify DB | Query CongNo | DaThanhToan, ConNo update đúng | ☐ |
| 5.4 | Cảnh báo hạn | Check filter "Quá hạn" | Highlight đỏ những KH quá hạn | ☐ |

### **TC06: Báo Cáo (SF012-015)**

| # | Test | Input | Expected Result | Pass/Fail |
|---|------|-------|-----------------|-----------|
| 6.1 | Doanh số theo ngày | Ngày 09/12 | Hiển thị HĐ ngày 09/12, subtotal | ☐ |
| 6.2 | Tồn kho cảnh báo | Filter < 10 | Highlight sách sắp hết | ☐ |
| 6.3 | Xuất Excel | Click "Xuất Excel" | File Excel được tạo, dữ liệu đầy đủ | ☐ |
| 6.4 | Audit Log | View log | Tất cả hoạt động được log | ☐ |
| 6.5 | Filter Log | Search "admin" | Chỉ show admin's actions | ☐ |

### **TC07: Permission Check**

| # | Test | Input | Expected Result | Pass/Fail |
|---|------|-------|-----------------|-----------|
| 7.1 | ADMIN menu | Login admin | Tất cả menu visible | ☐ |
| 7.2 | ADMIN buttons | Tất cả form | Nút Thêm/Sửa/Xóa visible | ☐ |
| 7.3 | ADMIN role | Logout, login MANAGER | MANAGER menu ít hơn ADMIN | ☐ |
| 7.4 | ADMIN access | Try direct SQL hack | SQL Injection prevention | ☐ |

---

## ✅ Checklist Kiểm Tra ADMIN

```
MENU HIỂN THỊ:
☐ Hệ Thống menu
☐ Quản Lý Kho menu
☐ Bán Hàng menu
☐ Khách Hàng menu
☐ Báo Cáo menu
☐ Cài Đặt menu

HỆ THỐNG:
☐ Quản lý Nhân Viên (9 chức năng)
☐ Quản lý TK (3 chức năng)
☐ Quản lý Role (1 chức năng)
☐ Audit Log (1 chức năng)
☐ Backup DB (1 chức năng)

QUẢN LÝ KHO:
☐ Quản lý Sách (11 chức năng)
☐ Quản lý NXB (4 chức năng)
☐ Nhập Hàng (3 chức năng)

BÁN HÀNG:
☐ Tạo HĐ (9 chức năng)
☐ Danh sách HĐ (3 chức năng)
☐ Quản lý Chiết Khấu (3 chức năng)

KHÁCH HÀNG:
☐ Quản lý KH (6 chức năng)
☐ Quản lý Công Nợ (3 chức năng)

BÁO CÁO:
☐ Doanh Số (2 chức năng)
☐ Tồn Kho (2 chức năng)
☐ Công Nợ (1 chức năng)
☐ Audit Log (1 chức năng)
☐ Xuất báo cáo (2 chức năng)

DATABASE:
☐ Tất cả INSERT/UPDATE/DELETE đúng
☐ Tồn kho update đúng
☐ Công nợ update đúng
☐ Audit log ghi đầy đủ

VALIDATION:
☐ Kiểm tra input (Email, Phone, ...)
☐ Error message hiển thị
☐ Confirmation dialog trước delete

PERFORMANCE:
☐ Grid load < 2 giây
☐ Search kết quả nhanh
☐ Excel export < 5 giây

SECURITY:
☐ SQL Injection prevention
☐ Password SHA256
☐ Session timeout (30 phút)
☐ Unauthorized access denied
```

---

## 🎯 Hướng Dẫn Sử Dụng Prompt Này

### **Với Claude 4.5:**

```
Copy toàn bộ file này vào Claude và yêu cầu:

"Dựa vào danh sách 57 chức năng của ADMIN, hãy:
1. Generate automated test cases (Unit tests + Integration tests)
2. Create test data preparation scripts (SQL)
3. Generate UI test automation code
4. Create manual testing checklist
5. Identify edge cases & error scenarios"
```

### **Hoặc theo từng phần:**

```
"Tạo test case chi tiết cho chức năng Bán Hàng (9 test cases)
bao gồm:
- Input data
- Expected result
- Pass/Fail criteria
- SQL verification query"
```

---

## 📊 Test Execution Summary

**Total Test Cases: 40+ Test Cases**
- Menu Tests: 6 TC
- Data Management: 20 TC
- Permission Tests: 4 TC
- Performance Tests: 5 TC
- Security Tests: 5 TC

**Estimate Test Time: 2-3 hours**

---

## 🚨 Critical Issues to Watch For

1. **Permission Bypass:** Check nếu NHVBH có thể access ADMIN menu
2. **Data Corruption:** Verify tồn kho, công nợ update đúng
3. **SQL Injection:** Try ' or 1=1 -- trong search
4. **Session Timeout:** Check logout sau 30 phút inactivity
5. **Audit Trail:** Verify tất cả changes được log
6. **Concurrent Access:** 2 users edit cùng record
7. **Performance:** Grid 10k+ records có lag không

---

**Status:** ✅ Ready for Testing
**Last Updated:** December 9, 2025
