-- =============================================
-- Script thêm dữ liệu mẫu cho Khách Hàng và Thẻ VIP
-- Chạy script này trong SQL Server Management Studio
-- =============================================

-- Tạo bảng TheVIP nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TheVIP' AND xtype='U')
BEGIN
    CREATE TABLE TheVIP (
        MaTheVIP NVARCHAR(20) PRIMARY KEY,
        MaKH NVARCHAR(20) NOT NULL,
        NgayCapPhat DATE NOT NULL DEFAULT GETDATE(),
        NgayHetHan DATE NOT NULL,
        DiemTichLuy INT NOT NULL DEFAULT 0,
        ChiTieu DECIMAL(18,2) NOT NULL DEFAULT 0,
        TrangThai BIT NOT NULL DEFAULT 1,
        FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
    );
    PRINT N'✅ Đã tạo bảng TheVIP';
END
GO

-- Xóa dữ liệu cũ (nếu có) để tránh trùng lặp
DELETE FROM TheVIP;
DELETE FROM KhachHang WHERE MaKH LIKE 'KH0%';
GO

-- Thêm khách hàng mẫu
INSERT INTO KhachHang (MaKH, TenKH, DienThoai, DiaChi, LoaiKH) VALUES
('KH001', N'Nguyễn Văn An', '0901234567', N'123 Nguyễn Huệ, Quận 1, TP.HCM', N'VIP'),
('KH002', N'Trần Thị Bình', '0912345678', N'456 Lê Lợi, Quận 1, TP.HCM', N'Thường'),
('KH003', N'Lê Hoàng Cường', '0923456789', N'789 Trần Hưng Đạo, Quận 5, TP.HCM', N'VIP'),
('KH004', N'Phạm Thị Dung', '0934567890', N'321 Hai Bà Trưng, Quận 3, TP.HCM', N'Thường'),
('KH005', N'Hoàng Văn Em', '0945678901', N'654 Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', N'VIP'),
('KH006', N'Võ Thị Phượng', '0956789012', N'987 Cách Mạng Tháng 8, Quận 10, TP.HCM', N'Thường'),
('KH007', N'Đặng Minh Giang', '0967890123', N'147 Nguyễn Thị Minh Khai, Quận 3, TP.HCM', N'Doanh Nghiệp'),
('KH008', N'Ngô Thanh Hà', '0978901234', N'258 Võ Văn Tần, Quận 3, TP.HCM', N'VIP'),
('KH009', N'Bùi Văn Ích', '0989012345', N'369 Lý Tự Trọng, Quận 1, TP.HCM', N'Thường'),
('KH010', N'Mai Thị Kim', '0990123456', N'741 Phan Xích Long, Quận Phú Nhuận, TP.HCM', N'VIP');

GO

-- Thêm thẻ VIP cho các khách hàng VIP
INSERT INTO TheVIP (MaTheVIP, MaKH, NgayCapPhat, NgayHetHan, DiemTichLuy, ChiTieu, TrangThai) VALUES
('VIP001', 'KH001', '2024-01-15', '2025-01-15', 850, 8500000, 1),  -- Gold
('VIP002', 'KH003', '2024-03-20', '2025-03-20', 1200, 12000000, 1), -- Platinum
('VIP003', 'KH005', '2024-06-10', '2025-06-10', 350, 3500000, 1),  -- Silver
('VIP004', 'KH008', '2024-08-01', '2025-08-01', 680, 6800000, 1),  -- Gold
('VIP005', 'KH010', '2024-10-25', '2025-10-25', 150, 1500000, 1);  -- Silver

GO

-- Cập nhật loại KH cho khách hàng có thẻ VIP
UPDATE KhachHang SET LoaiKH = N'VIP' WHERE MaKH IN ('KH001', 'KH003', 'KH005', 'KH008', 'KH010');

GO

PRINT N'✅ Đã thêm 10 khách hàng và 5 thẻ VIP mẫu thành công!';

-- Kiểm tra dữ liệu
SELECT * FROM KhachHang;
SELECT v.*, k.TenKH FROM TheVIP v INNER JOIN KhachHang k ON v.MaKH = k.MaKH;
