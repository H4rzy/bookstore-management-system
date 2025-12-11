using System;
using System.Collections.Generic;
using System.Data;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class BaoCao_BLL
    {
        private BaoCaoDAL dal = new BaoCaoDAL();

        #region Revenue Reports

        /// <summary>
        /// Lấy báo cáo doanh thu theo ngày
        /// </summary>
        public DataTable LayDoanhThuTheoNgay(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                return dal.LayDoanhThuTheoNgay(startDate, endDate);
            }
            catch
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// Lấy báo cáo doanh thu theo tháng
        /// </summary>
        public DataTable LayDoanhThuTheoThang(int year)
        {
            try
            {
                if (year < 2000 || year > DateTime.Now.Year + 1)
                    throw new ArgumentException("Năm không hợp lệ");

                return dal.LayDoanhThuTheoThang(year);
            }
            catch
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// Lấy báo cáo doanh thu theo quý
        /// </summary>
        public DataTable LayDoanhThuTheoQuy(int year)
        {
            try
            {
                if (year < 2000 || year > DateTime.Now.Year + 1)
                    throw new ArgumentException("Năm không hợp lệ");

                return dal.LayDoanhThuTheoQuy(year);
            }
            catch
            {
                return new DataTable();
            }
        }

        #endregion

        #region Top Books Reports

        /// <summary>
        /// Lấy danh sách sách bán chạy nhất
        /// </summary>
        public DataTable LayTopSachBanChay(DateTime startDate, DateTime endDate, int topN, string maTheLoai = null)
        {
            try
            {
                if (startDate > endDate)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                if (topN <= 0 || topN > 100)
                    topN = 10; // Default to top 10

                return dal.LayTopSachBanChay(startDate, endDate, topN, maTheLoai);
            }
            catch
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// Lấy thống kê thể loại bán chạy
        /// </summary>
        public DataTable LayTopTheLoaiBanChay(DateTime startDate, DateTime endDate, int topN)
        {
            try
            {
                if (startDate > endDate)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                if (topN <= 0 || topN > 50)
                    topN = 10;

                return dal.LayTopTheLoaiBanChay(startDate, endDate, topN);
            }
            catch
            {
                return new DataTable();
            }
        }

        #endregion

        #region Inventory Reports

        /// <summary>
        /// Lấy báo cáo tồn kho chi tiết
        /// </summary>
        public DataTable LayTonKhoChiTiet(string maTheLoai = null)
        {
            try
            {
                return dal.LayTonKhoChiTiet(maTheLoai);
            }
            catch
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// Lấy danh sách sách sắp hết
        /// </summary>
        public DataTable LaySachSapHet(int threshold)
        {
            try
            {
                if (threshold <= 0)
                    threshold = 10; // Default threshold

                return dal.LaySachSapHet(threshold);
            }
            catch
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// Lấy thống kê tồn kho theo thể loại
        /// </summary>
        public DataTable LayTonKhoTheoTheLoai()
        {
            try
            {
                return dal.LayTonKhoTheoTheLoai();
            }
            catch
            {
                return new DataTable();
            }
        }

        #endregion

        #region Customer Reports

        /// <summary>
        /// Lấy danh sách khách hàng mua nhiều nhất
        /// </summary>
        public DataTable LayTopKhachHang(DateTime startDate, DateTime endDate, int topN)
        {
            try
            {
                if (startDate > endDate)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                if (topN <= 0 || topN > 100)
                    topN = 10;

                return dal.LayTopKhachHang(startDate, endDate, topN);
            }
            catch
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// Lấy thống kê thẻ VIP
        /// </summary>
        public DataTable LayThongKeVIP()
        {
            try
            {
                return dal.LayThongKeVIP();
            }
            catch
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// Lấy lịch sử mua hàng của khách hàng
        /// </summary>
        public DataTable LayLichSuMuaHangKhachHang(string maKH, DateTime startDate, DateTime endDate)
        {
            try
            {
                if (string.IsNullOrEmpty(maKH))
                    throw new ArgumentException("Mã khách hàng không được rỗng");

                if (startDate > endDate)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                return dal.LayLichSuMuaHangKhachHang(maKH, startDate, endDate);
            }
            catch
            {
                return new DataTable();
            }
        }

        #endregion

        #region Staff Reports

        /// <summary>
        /// Lấy báo cáo doanh số theo nhân viên
        /// </summary>
        public DataTable LayDoanhSoTheoNhanVien(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                return dal.LayDoanhSoTheoNhanVien(startDate, endDate);
            }
            catch
            {
                return new DataTable();
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Tính tỷ lệ lợi nhuận (%)
        /// </summary>
        public decimal TinhTyLeLoiNhuan(decimal doanhThu, decimal loiNhuan)
        {
            if (doanhThu == 0) return 0;
            return Math.Round((loiNhuan / doanhThu) * 100, 2);
        }

        /// <summary>
        /// Format currency string for display
        /// </summary>
        public string FormatCurrency(decimal value)
        {
            return string.Format("{0:N0} ₫", value);
        }

        #endregion
    }
}
