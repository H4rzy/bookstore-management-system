using System;
using System.Collections.Generic;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class TheVIP_BLL
    {
        private TheVIPDAL dal = new TheVIPDAL();

        /// <summary>
        /// Issue new VIP card to customer
        /// </summary>
        public bool CapTheVIP(string maKH, int soThangHieuLuc = 12)
        {
            try
            {
                if (string.IsNullOrEmpty(maKH))
                    return false;

                // Check if customer already has VIP card
                if (dal.KiemTraKhachHangCoTheVIP(maKH))
                    return false;

                //  Verify customer exists
                KhachHangDAL khDAL = new KhachHangDAL();
                var kh = khDAL.layKhachHangTheoMa(maKH);
                if (kh == null)
                    return false;

                // Generate new VIP card number
                string maTheVIP = dal.TaoMaTheVIPMoi();

                // Create VIP card
                TheVIPDTO vip = new TheVIPDTO
                {
                    MaTheVIP = maTheVIP,
                    MaKH = maKH,
                    NgayCapPhat = DateTime.Now,
                    NgayHetHan = DateTime.Now.AddMonths(soThangHieuLuc),
                    DiemTichLuy = 0,
                    TrangThai = true
                };

                return dal.ThemTheVIP(vip);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Renew VIP card
        /// </summary>
        public bool GiaHanTheVIP(string maTheVIP, int soThangGiaHan = 12)
        {
            try
            {
                if (string.IsNullOrEmpty(maTheVIP))
                    return false;

                var vipList = dal.LayDanhSachTheVIP();
                var vip = vipList.Find(v => v.MaTheVIP == maTheVIP);

                if (vip == null)
                    return false;

                // Extend from current expiry date or now (whichever is later)
                DateTime baseDate = vip.NgayHetHan > DateTime.Now ? vip.NgayHetHan : DateTime.Now;
                vip.NgayHetHan = baseDate.AddMonths(soThangGiaHan);
                vip.TrangThai = true;

                return dal.CapNhatTheVIP(vip);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cancel/Deactivate VIP card
        /// </summary>
        public bool HuyTheVIP(string maTheVIP)
        {
            try
            {
                if (string.IsNullOrEmpty(maTheVIP))
                    return false;

                var vipList = dal.LayDanhSachTheVIP();
                var vip = vipList.Find(v => v.MaTheVIP == maTheVIP);

                if (vip == null)
                    return false;

                vip.TrangThai = false;
                return dal.CapNhatTheVIP(vip);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete VIP card (permanent)
        /// </summary>
        public bool XoaTheVIP(string maTheVIP)
        {
            try
            {
                if (string.IsNullOrEmpty(maTheVIP))
                    return false;

                return dal.XoaTheVIP(maTheVIP);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get VIP card by customer
        /// </summary>
        public TheVIPDTO LayTheVIPTheoKhachHang(string maKH)
        {
            try
            {
                if (string.IsNullOrEmpty(maKH))
                    return null;

                return dal.LayTheVIPTheoKhachHang(maKH);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get all VIP cards
        /// </summary>
        public List<TheVIPDTO> LayDanhSachTheVIP()
        {
            try
            {
                return dal.LayDanhSachTheVIP();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi LayDanhSachTheVIP: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Check if customer is VIP
        /// </summary>
        public bool KiemTraKhachHangLaVIP(string maKH)
        {
            try
            {
                var vip = dal.LayTheVIPTheoKhachHang(maKH);
                return vip != null && vip.IsActive;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Add loyalty points (e.g., from purchases)
        /// </summary>
        public bool CongDiemTichLuy(string maKH, int diem)
        {
            try
            {
                if (diem <= 0)
                    return false;

                return dal.CapNhatDiemTichLuy(maKH, diem, true);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Redeem loyalty points
        /// </summary>
        public bool TruDiemTichLuy(string maKH, int diem)
        {
            try
            {
                if (diem <= 0)
                    return false;

                var vip = dal.LayTheVIPTheoKhachHang(maKH);
                if (vip == null || vip.DiemTichLuy < diem)
                    return false;

                return dal.CapNhatDiemTichLuy(maKH, diem, false);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update spending and auto-add loyalty points
        /// </summary>
        public bool CapNhatChiTieu(string maKH, decimal soTienChiTieu)
        {
            try
            {
                if (soTienChiTieu <= 0)
                    return false;

                return dal.CapNhatChiTieu(maKH, soTienChiTieu);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Calculate VIP discount percentage based on points AND spending
        /// </summary>
        public decimal TinhPhanTramGiamGia(string maKH)
        {
            try
            {
                var vip = dal.LayTheVIPTheoKhachHang(maKH);
                if (vip == null || !vip.IsActive)
                    return 0;

                // VIP discount tiers based on loyalty points OR spending
                if (vip.DiemTichLuy >= 1000 || vip.ChiTieu >= 10000000)
                    return 15; // 15% for platinum (1000+ points or 10M+)
                else if (vip.DiemTichLuy >= 500 || vip.ChiTieu >= 5000000)
                    return 10; // 10% for gold (500+ points or 5M+)
                else
                    return 5;  // 5% for standard VIP
            }
            catch
            {
                return 0;
            }
        }
    }
}
