
CREATE DATABASE QuanLyNhaSach;
GO
USE QuanLyNhaSach;
GO

-- Thể loại sách
CREATE TABLE TheLoai (
    MaTheLoai     CHAR(5)      PRIMARY KEY,
    TenTheLoai    NVARCHAR(100) NOT NULL
);

-- Nhà xuất bản
CREATE TABLE NhaXuatBan (
    MaNXB     CHAR(5)       PRIMARY KEY,
    TenNXB    NVARCHAR(100) NOT NULL,
    DiaChi    NVARCHAR(200),
    DienThoai VARCHAR(20)
);

-- Sách
CREATE TABLE Sach (
    MaSach       CHAR(10)       PRIMARY KEY,
    TenSach      NVARCHAR(200)  NOT NULL,
    MaTheLoai    CHAR(5)        NOT NULL,
    MaNXB        CHAR(5)        NOT NULL,
    TacGia       NVARCHAR(100),
    DonGiaNhap   DECIMAL(18,2)  NOT NULL,
    DonGiaBan    DECIMAL(18,2)  NOT NULL,
    SoLuongTon   INT            NOT NULL DEFAULT 0,
    CONSTRAINT FK_Sach_TheLoai FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai),
    CONSTRAINT FK_Sach_NXB     FOREIGN KEY (MaNXB)     REFERENCES NhaXuatBan(MaNXB)
);

-- ============================================================
-- BẢNG KHÁCH HÀNG, NHÂN VIÊN, TÀI KHOẢN
-- ============================================================

-- Khách hàng
CREATE TABLE KhachHang (
    MaKH      CHAR(10)       PRIMARY KEY,
    TenKH     NVARCHAR(100)  NOT NULL,
    DienThoai VARCHAR(20),
    DiaChi    NVARCHAR(200),
    LoaiKH    NVARCHAR(50)
);

-- Nhân viên
CREATE TABLE NhanVien (
    MaNV      CHAR(10)       PRIMARY KEY,
    TenNV     NVARCHAR(100)  NOT NULL,
    GioiTinh  BIT,
    DienThoai VARCHAR(20),
    DiaChi    NVARCHAR(200),
    ChucVu    NVARCHAR(50)
);

-- Tài khoản đăng nhập
CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau     VARCHAR(255) NOT NULL,
    MaNV        CHAR(10)      NOT NULL,
    Quyen       NVARCHAR(50),
    CONSTRAINT FK_TK_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- ============================================================
-- BẢNG PHIẾU NHẬP
-- ============================================================

-- Phiếu nhập
CREATE TABLE PhieuNhap (
    SoPN       CHAR(10)      PRIMARY KEY,
    NgayNhap   DATE          NOT NULL,
    MaNV       CHAR(10)      NOT NULL,
    GhiChu     NVARCHAR(200),
    CONSTRAINT FK_PN_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Chi tiết phiếu nhập
CREATE TABLE ChiTietPhieuNhap (
    SoPN       CHAR(10)      NOT NULL,
    MaSach     CHAR(10)      NOT NULL,
    SoLuong    INT           NOT NULL,
    DonGiaNhap DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (SoPN, MaSach),
    CONSTRAINT FK_CTPN_PN   FOREIGN KEY (SoPN)   REFERENCES PhieuNhap(SoPN),
    CONSTRAINT FK_CTPN_Sach FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- ============================================================
-- BẢNG HÓA ĐƠN BÁN SÁCH
-- ============================================================

-- Hóa đơn
CREATE TABLE HoaDon (
    SoHD      CHAR(10)      PRIMARY KEY,
    NgayBan   DATE          NOT NULL,
    MaNV      CHAR(10)      NOT NULL,
    MaKH      CHAR(10)      NULL,
    GhiChu    NVARCHAR(200),
    CONSTRAINT FK_HD_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_HD_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

-- Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    SoHD      CHAR(10)      NOT NULL,
    MaSach    CHAR(10)      NOT NULL,
    SoLuong   INT           NOT NULL,
    DonGiaBan DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (SoHD, MaSach),
    CONSTRAINT FK_CTHD_HD   FOREIGN KEY (SoHD)   REFERENCES HoaDon(SoHD),
    CONSTRAINT FK_CTHD_Sach FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- ============================================================
-- DỮ LIỆU MẪU
-- ============================================================

-- Thêm thể loại
INSERT INTO TheLoai VALUES ('TL001', N'Văn học');
INSERT INTO TheLoai VALUES ('TL002', N'Kinh tế');
INSERT INTO TheLoai VALUES ('TL003', N'Công nghệ');

-- Thêm nhà xuất bản
INSERT INTO NhaXuatBan VALUES ('NXB01', N'NXB Trẻ', N'Hà Nội', '024-1234567');
INSERT INTO NhaXuatBan VALUES ('NXB02', N'NXB Kim Đồng', N'TP.HCM', '028-7654321');

-- Thêm sách
INSERT INTO Sach VALUES ('S001', N'Đắc Nhân Tâm', 'TL001', 'NXB01', N'Dale Carnegie', 50000, 120000, 10);
INSERT INTO Sach VALUES ('S002', N'Lean Startup', 'TL002', 'NXB02', N'Eric Ries', 80000, 180000, 5);
INSERT INTO Sach VALUES ('S003', N'Clean Code', 'TL003', 'NXB01', N'Robert Martin', 100000, 250000, 8);

-- Thêm khách hàng
INSERT INTO KhachHang VALUES ('KH001', N'Nguyễn Văn A', '0901234567', N'Hà Nội', N'Thường');
INSERT INTO KhachHang VALUES ('KH002', N'Trần Thị B', '0987654321', N'TP.HCM', N'VIP');

-- Thêm nhân viên
INSERT INTO NhanVien VALUES ('NV001', N'Lê Văn C', 1, '0912345678', N'Hà Nội', N'Quản lý');
INSERT INTO NhanVien VALUES ('NV002', N'Phạm Thị D', 0, '0923456789', N'TP.HCM', N'Nhân viên bán hàng');

-- Thêm tài khoản
INSERT INTO TaiKhoan VALUES ('admin', '123456', 'NV001', N'Admin');
INSERT INTO TaiKhoan VALUES ('nhanvien', '123456', 'NV002', N'BanHang');

-- Thêm phiếu nhập
INSERT INTO PhieuNhap VALUES ('PN001', '2025-12-01', 'NV001', N'Nhập sách lần 1');

-- Thêm chi tiết phiếu nhập
INSERT INTO ChiTietPhieuNhap VALUES ('PN001', 'S001', 20, 50000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN001', 'S002', 10, 80000);

-- Thêm hóa đơn
INSERT INTO HoaDon VALUES ('HD001', '2025-12-02', 'NV002', 'KH001', N'Bán hàng bình thường');

-- Thêm chi tiết hóa đơn
INSERT INTO ChiTietHoaDon VALUES ('HD001', 'S001', 2, 120000);
INSERT INTO ChiTietHoaDon VALUES ('HD001', 'S003', 1, 250000);

