using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLNS_DAL
{
    public class BaoCaoDAL
    {
        private string connectionString = DBConnect.connectionString;

        #region Revenue Reports

        /// <summary>
        /// Lấy báo cáo doanh thu theo ngày trong khoảng thời gian
        /// </summary>
        public DataTable LayDoanhThuTheoNgay(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        CAST(hd.NgayLap AS DATE) as Ngay,
                        COUNT(DISTINCT hd.SoHD) as SoHoaDon,
                        SUM(ct.SoLuong) as SoSanPham,
                        SUM(ct.SoLuong * ct.DonGiaBan) as TongDoanhThu,
                        SUM(ct.SoLuong * (ct.DonGiaBan - s.DonGiaNhap)) as LoiNhuan
                    FROM HoaDon hd
                    JOIN ChiTietHoaDon ct ON hd.SoHD = ct.SoHD
                    JOIN Sach s ON ct.MaSach = s.MaSach
                    WHERE hd.NgayLap BETWEEN @StartDate AND @EndDate
                    GROUP BY CAST(hd.NgayLap AS DATE)
                    ORDER BY Ngay DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Lấy báo cáo doanh thu theo tháng trong năm
        /// </summary>
        public DataTable LayDoanhThuTheoThang(int year)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        MONTH(hd.NgayLap) as Thang,
                        COUNT(DISTINCT hd.SoHD) as SoHoaDon,
                        SUM(ct.SoLuong) as SoSanPham,
                        SUM(ct.SoLuong * ct.DonGiaBan) as TongDoanhThu,
                        SUM(ct.SoLuong * (ct.DonGiaBan - s.DonGiaNhap)) as LoiNhuan
                    FROM HoaDon hd
                    JOIN ChiTietHoaDon ct ON hd.SoHD = ct.SoHD
                    JOIN Sach s ON ct.MaSach = s.MaSach
                    WHERE YEAR(hd.NgayLap) = @Year
                    GROUP BY MONTH(hd.NgayLap)
                    ORDER BY Thang";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Year", year);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Lấy báo cáo doanh thu theo quý trong năm
        /// </summary>
        public DataTable LayDoanhThuTheoQuy(int year)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        DATEPART(QUARTER, hd.NgayLap) as Quy,
                        COUNT(DISTINCT hd.SoHD) as SoHoaDon,
                        SUM(ct.SoLuong) as SoSanPham,
                        SUM(ct.SoLuong * ct.DonGiaBan) as TongDoanhThu,
                        SUM(ct.SoLuong * (ct.DonGiaBan - s.DonGiaNhap)) as LoiNhuan
                    FROM HoaDon hd
                    JOIN ChiTietHoaDon ct ON hd.SoHD = ct.SoHD
                    JOIN Sach s ON ct.MaSach = s.MaSach
                    WHERE YEAR(hd.NgayLap) = @Year
                    GROUP BY DATEPART(QUARTER, hd.NgayLap)
                    ORDER BY Quy";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Year", year);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        #endregion

        #region Top Books Reports

        /// <summary>
        /// Lấy danh sách sách bán chạy nhất
        /// </summary>
        public DataTable LayTopSachBanChay(DateTime startDate, DateTime endDate, int topN, string maTheLoai = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TOP (@TopN)
                        s.MaSach, 
                        s.TenSach, 
                        tl.TenTheLoai,
                        nxb.TenNXB,
                        SUM(ct.SoLuong) as SoLuongBan,
                        SUM(ct.SoLuong * ct.DonGiaBan) as DoanhThu,
                        SUM(ct.SoLuong * (ct.DonGiaBan - s.DonGiaNhap)) as LoiNhuan
                    FROM ChiTietHoaDon ct
                    JOIN Sach s ON ct.MaSach = s.MaSach
                    JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                    LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
                    JOIN HoaDon hd ON ct.SoHD = hd.SoHD
                    WHERE hd.NgayLap BETWEEN @StartDate AND @EndDate
                    " + (string.IsNullOrEmpty(maTheLoai) ? "" : "AND s.MaTheLoai = @MaTheLoai") + @"
                    GROUP BY s.MaSach, s.TenSach, tl.TenTheLoai, nxb.TenNXB
                    ORDER BY SoLuongBan DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@TopN", topN);
                if (!string.IsNullOrEmpty(maTheLoai))
                    cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Lấy thống kê thể loại bán chạy nhất
        /// </summary>
        public DataTable LayTopTheLoaiBanChay(DateTime startDate, DateTime endDate, int topN)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TOP (@TopN)
                        tl.MaTheLoai,
                        tl.TenTheLoai,
                        COUNT(DISTINCT s.MaSach) as SoSach,
                        SUM(ct.SoLuong) as SoLuongBan,
                        SUM(ct.SoLuong * ct.DonGiaBan) as DoanhThu
                    FROM ChiTietHoaDon ct
                    JOIN Sach s ON ct.MaSach = s.MaSach
                    JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                    JOIN HoaDon hd ON ct.SoHD = hd.SoHD
                    WHERE hd.NgayLap BETWEEN @StartDate AND @EndDate
                    GROUP BY tl.MaTheLoai, tl.TenTheLoai
                    ORDER BY SoLuongBan DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@TopN", topN);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        #endregion

        #region Inventory Reports

        /// <summary>
        /// Lấy báo cáo tồn kho chi tiết
        /// </summary>
        public DataTable LayTonKhoChiTiet(string maTheLoai = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        s.MaSach, 
                        s.TenSach, 
                        s.SoLuongTon,
                        s.DonGiaNhap,
                        s.DonGiaBan,
                        (s.SoLuongTon * s.DonGiaNhap) as GiaTriTonKho,
                        tl.TenTheLoai,
                        nxb.TenNXB
                    FROM Sach s
                    JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                    LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
                    WHERE 1=1
                    " + (string.IsNullOrEmpty(maTheLoai) ? "" : "AND s.MaTheLoai = @MaTheLoai") + @"
                    ORDER BY s.SoLuongTon ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(maTheLoai))
                    cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Lấy danh sách sách sắp hết (tồn kho dưới ngưỡng)
        /// </summary>
        public DataTable LaySachSapHet(int threshold)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        s.MaSach, 
                        s.TenSach, 
                        s.SoLuongTon,
                        s.DonGiaBan,
                        tl.TenTheLoai,
                        nxb.TenNXB,
                        nxb.DienThoai as SDTNhaXuatBan
                    FROM Sach s
                    JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                    LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
                    WHERE s.SoLuongTon < @Threshold
                    ORDER BY s.SoLuongTon ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Threshold", threshold);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Lấy thống kê tồn kho theo thể loại
        /// </summary>
        public DataTable LayTonKhoTheoTheLoai()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        tl.TenTheLoai,
                        COUNT(s.MaSach) as SoSach,
                        SUM(s.SoLuongTon) as TongSoLuong,
                        SUM(s.SoLuongTon * s.DonGiaNhap) as GiaTriTonKho
                    FROM Sach s
                    JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                    GROUP BY tl.TenTheLoai
                    ORDER BY TongSoLuong DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        #endregion

        #region Customer Reports

        /// <summary>
        /// Lấy danh sách khách hàng mua nhiều nhất
        /// </summary>
        public DataTable LayTopKhachHang(DateTime startDate, DateTime endDate, int topN)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TOP (@TopN)
                        kh.MaKH,
                        kh.TenKH,
                        kh.DienThoai,
                        kh.DiaChi,
                        COUNT(DISTINCT hd.SoHD) as SoHoaDon,
                        SUM(ct.SoLuong) as SoSanPhamMua,
                        SUM(ct.SoLuong * ct.DonGiaBan) as TongChiTieu,
                        MAX(hd.NgayLap) as LanMuaGanNhat
                    FROM KhachHang kh
                    JOIN HoaDon hd ON kh.MaKH = hd.MaKH
                    JOIN ChiTietHoaDon ct ON hd.SoHD = ct.SoHD
                    WHERE hd.NgayLap BETWEEN @StartDate AND @EndDate
                    GROUP BY kh.MaKH, kh.TenKH, kh.DienThoai, kh.DiaChi
                    ORDER BY TongChiTieu DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@TopN", topN);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Lấy thống kê thẻ VIP
        /// </summary>
        public DataTable LayThongKeVIP()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        CASE 
                            WHEN v.DiemTichLuy >= 1000 OR v.ChiTieu >= 10000000 THEN 'Platinum'
                            WHEN v.DiemTichLuy >= 500 OR v.ChiTieu >= 5000000 THEN 'Gold'
                            ELSE 'Silver'
                        END as HangThe,
                        COUNT(*) as SoLuong,
                        AVG(v.DiemTichLuy) as DiemTrungBinh,
                        AVG(v.ChiTieu) as ChiTieuTrungBinh,
                        SUM(v.ChiTieu) as TongChiTieu
                    FROM TheVIP v
                    WHERE v.TrangThai = N'Đang hoạt động'
                    GROUP BY 
                        CASE 
                            WHEN v.DiemTichLuy >= 1000 OR v.ChiTieu >= 10000000 THEN 'Platinum'
                            WHEN v.DiemTichLuy >= 500 OR v.ChiTieu >= 5000000 THEN 'Gold'
                            ELSE 'Silver'
                        END
                    ORDER BY 
                        CASE HangThe
                            WHEN 'Platinum' THEN 1
                            WHEN 'Gold' THEN 2
                            WHEN 'Silver' THEN 3
                        END";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Lấy lịch sử mua hàng của khách hàng
        /// </summary>
        public DataTable LayLichSuMuaHangKhachHang(string maKH, DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        hd.SoHD,
                        hd.NgayLap,
                        nv.TenNV as NhanVienBan,
                        COUNT(ct.MaSach) as SoMatHang,
                        SUM(ct.SoLuong) as TongSoLuong,
                        SUM(ct.SoLuong * ct.DonGiaBan) as TongTien
                    FROM HoaDon hd
                    LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                    LEFT JOIN ChiTietHoaDon ct ON hd.SoHD = ct.SoHD
                    WHERE hd.MaKH = @MaKH
                    AND hd.NgayLap BETWEEN @StartDate AND @EndDate
                    GROUP BY hd.SoHD, hd.NgayLap, nv.TenNV
                    ORDER BY hd.NgayLap DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        #endregion

        #region Staff Reports

        /// <summary>
        /// Lấy báo cáo doanh số theo nhân viên
        /// </summary>
        public DataTable LayDoanhSoTheoNhanVien(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        nv.MaNV,
                        nv.TenNV,
                        nv.ChucVu,
                        COUNT(DISTINCT hd.SoHD) as SoHoaDon,
                        SUM(ct.SoLuong) as SoSanPhamBan,
                        SUM(ct.SoLuong * ct.DonGiaBan) as TongDoanhSo,
                        AVG(ct.SoLuong * ct.DonGiaBan) as DoanhSoTrungBinh
                    FROM NhanVien nv
                    LEFT JOIN HoaDon hd ON nv.MaNV = hd.MaNV 
                        AND hd.NgayLap BETWEEN @StartDate AND @EndDate
                    LEFT JOIN ChiTietHoaDon ct ON hd.SoHD = ct.SoHD
                    GROUP BY nv.MaNV, nv.TenNV, nv.ChucVu
                    HAVING COUNT(DISTINCT hd.SoHD) > 0
                    ORDER BY TongDoanhSo DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        #endregion
    }
}
