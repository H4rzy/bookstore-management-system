-- =============================================
-- VIP Card Management System - Database Schema (UPDATED)
-- Includes both ChiTieu and TrangThai
-- =============================================

-- 1. Check and create TheVIP table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TheVIP')
BEGIN
    CREATE TABLE TheVIP (
        MaTheVIP NVARCHAR(10) PRIMARY KEY,
        MaKH NVARCHAR(10) NOT NULL,
        NgayCapPhat DATE NOT NULL DEFAULT GETDATE(),
        NgayHetHan DATE NOT NULL,
        DiemTichLuy INT DEFAULT 0,
        ChiTieu DECIMAL(18,2) DEFAULT 0,    -- Tổng chi tiêu
        TrangThai BIT DEFAULT 1,             -- 1: Hoạt động, 0: Khóa
        CONSTRAINT FK_TheVIP_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
    );
    PRINT N'✓ Bảng TheVIP đã được tạo thành công!';
END
ELSE
BEGIN
    PRINT N'! Bảng TheVIP đã tồn tại';
    
    -- Thêm column TrangThai nếu chưa có
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('TheVIP') AND name = 'TrangThai')
    BEGIN
        ALTER TABLE TheVIP ADD TrangThai BIT DEFAULT 1;
        PRINT N'✓ Đã thêm cột TrangThai vào bảng TheVIP';
    END
    ELSE
        PRINT N'✓ Cột TrangThai đã tồn tại';
    
    -- Thêm column ChiTieu nếu chưa có
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('TheVIP') AND name = 'ChiTieu')
    BEGIN
        ALTER TABLE TheVIP ADD ChiTieu DECIMAL(18,2) DEFAULT 0;
        PRINT N'✓ Đã thêm cột ChiTieu vào bảng TheVIP';
    END
    ELSE
        PRINT N'✓ Cột ChiTieu đã tồn tại';
END
GO

-- 2. Add indexes for performance
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_TheVIP_MaKH')
    CREATE INDEX IX_TheVIP_MaKH ON TheVIP(MaKH);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_TheVIP_TrangThai')
    CREATE INDEX IX_TheVIP_TrangThai ON TheVIP(TrangThai);
GO

-- 3. Stored procedure to auto-generate VIP card number
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_TaoMaTheVIPMoi')
    DROP PROCEDURE sp_TaoMaTheVIPMoi;
GO

CREATE PROCEDURE sp_TaoMaTheVIPMoi
    @MaTheVIP NVARCHAR(10) OUTPUT
AS
BEGIN
    DECLARE @MaxNumber INT;
    
    SELECT @MaxNumber = ISNULL(MAX(CAST(SUBSTRING(MaTheVIP, 4, 10) AS INT)), 0)
    FROM TheVIP
    WHERE MaTheVIP LIKE 'VIP%';
    
    SET @MaTheVIP = 'VIP' + RIGHT('00000' + CAST(@MaxNumber + 1 AS NVARCHAR), 5);
END
GO

-- 4. Stored procedure to update spending and points
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_CapNhatChiTieuVIP')
    DROP PROCEDURE sp_CapNhatChiTieuVIP;
GO

CREATE PROCEDURE sp_CapNhatChiTieuVIP
    @MaKH NVARCHAR(10),
    @SoTienChiTieu DECIMAL(18,2)
AS
BEGIN
    -- Update Chi Tiêu
    UPDATE TheVIP 
    SET ChiTieu = ChiTieu + @SoTienChiTieu,
        DiemTichLuy = DiemTichLuy + CAST(@SoTienChiTieu / 1000 AS INT) -- 1 point per 1000 VND
    WHERE MaKH = @MaKH AND TrangThai = 1;
    
    RETURN @@ROWCOUNT;
END
GO

-- 5. Function to calculate VIP discount percentage
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'fn_TinhPhanTramGiamGiaVIP')
    DROP FUNCTION fn_TinhPhanTramGiamGiaVIP;
GO

CREATE FUNCTION fn_TinhPhanTramGiamGiaVIP(@MaKH NVARCHAR(10))
RETURNS DECIMAL(5,2)
AS
BEGIN
    DECLARE @PhanTramGiamGia DECIMAL(5,2) = 0;
    DECLARE @DiemTichLuy INT;
    DECLARE @ChiTieu DECIMAL(18,2);
    
    SELECT @DiemTichLuy = DiemTichLuy, @ChiTieu = ChiTieu
    FROM TheVIP
    WHERE MaKH = @MaKH AND TrangThai = 1 AND NgayHetHan >= GETDATE();
    
    IF @DiemTichLuy IS NOT NULL
    BEGIN
        -- Platinum: 1000+ points OR 10M+ spending
        IF @DiemTichLuy >= 1000 OR @ChiTieu >= 10000000
            SET @PhanTramGiamGia = 15;
        -- Gold: 500+ points OR 5M+ spending
        ELSE IF @DiemTichLuy >= 500 OR @ChiTieu >= 5000000
            SET @PhanTramGiamGia = 10;
        -- Silver: VIP members
        ELSE
            SET @PhanTramGiamGia = 5;
    END
    
    RETURN @PhanTramGiamGia;
END
GO

-- 6. Sample data (optional - comment out if not needed)
/*
-- Test VIP card
DECLARE @MaVIP NVARCHAR(10);
EXEC sp_TaoMaTheVIPMoi @MaVIP OUTPUT;

INSERT INTO TheVIP (MaTheVIP, MaKH, NgayCapPhat, NgayHetHan, DiemTichLuy, ChiTieu, TrangThai)
VALUES (@MaVIP, 'KH001', GETDATE(), DATEADD(YEAR, 1, GETDATE()), 100, 500000, 1);

SELECT * FROM TheVIP;
*/

-- 7. Query to check VIP customers with discount
SELECT 
    kh.MaKH,
    kh.TenKH,
    kh.DienThoai,
    vip.MaTheVIP,
    vip.NgayCapPhat,
    vip.NgayHetHan,
    vip.DiemTichLuy,
    vip.ChiTieu,
    CASE 
        WHEN vip.DiemTichLuy >= 1000 OR vip.ChiTieu >= 10000000 THEN N'Platinum (15%)'
        WHEN vip.DiemTichLuy >= 500 OR vip.ChiTieu >= 5000000 THEN N'Gold (10%)'
        ELSE N'Silver (5%)'
    END AS HangVIP,
    dbo.fn_TinhPhanTramGiamGiaVIP(kh.MaKH) AS PhanTramGiamGia,
    CASE 
        WHEN vip.TrangThai = 1 AND vip.NgayHetHan >= GETDATE() THEN N'Còn hiệu lực'
        WHEN vip.NgayHetHan < GETDATE() THEN N'Hết hạn'
        ELSE N'Không hoạt động'
    END AS TinhTrangThe
FROM KhachHang kh
LEFT JOIN TheVIP vip ON kh.MaKH = vip.MaKH
WHERE vip.MaTheVIP IS NOT NULL
ORDER BY vip.DiemTichLuy DESC, vip.ChiTieu DESC;

PRINT 'VIP Card System Database Schema Created Successfully!';
