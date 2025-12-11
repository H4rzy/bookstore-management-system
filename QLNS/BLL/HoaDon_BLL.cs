using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class HoaDon_BLL
    {
        private HoaDonDAL dal = new HoaDonDAL();

        public bool ThemHoaDon(HoaDonDTO dto)
        {
            if (dto == null) 
                throw new Exception("DTO is null");
            if (string.IsNullOrEmpty(dto.SoHD)) 
                throw new Exception("SoHD is empty");
            if (string.IsNullOrEmpty(dto.MaNV))
                throw new Exception("MaNV is empty");

            if (dal.kiemTraTrungSo(dto.SoHD))
                throw new Exception("SoHD đã tồn tại: " + dto.SoHD);

            return dal.themHoaDon(dto);
        }

        public bool XoaHoaDon(string soHD)
        {
            try
            {
                if (string.IsNullOrEmpty(soHD)) return false;

                // Lấy danh sách chi tiết để cộng lại tồn kho
                ChiTietHoaDonDAL ctDAL = new ChiTietHoaDonDAL();
                var dsChiTiet = ctDAL.layDanhSachChiTietTheoSoHD(soHD);

                // Cộng lại tồn kho cho từng sách
                Sach_BLL sachBLL = new Sach_BLL();
                foreach (var ct in dsChiTiet)
                {
                    sachBLL.CapNhatTonKho(ct.MaSach, ct.SoLuong, true); // true = cộng lại
                }

                return dal.xoaHoaDon(soHD);
            }
            catch { return false; }
        }

        public List<HoaDonDTO> LayDanhSachHoaDon()
        {
            try
            {
                return dal.layDanhSachHoaDon();
            }
            catch { return new List<HoaDonDTO>(); }
        }

        public HoaDonDTO LayHoaDonTheoSo(string soHD)
        {
            try
            {
                if (string.IsNullOrEmpty(soHD)) return null;
                return dal.layHoaDonTheoSo(soHD);
            }
            catch { return null; }
        }

        public bool CapNhatHoaDon(HoaDonDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.SoHD) || string.IsNullOrEmpty(dto.MaNV))
                    return false;

                return dal.capNhatHoaDon(dto);
            }
            catch { return false; }
        }

        public string TaoSoHDMoi()
        {
            try
            {
                // Format: HD + 8 số (từ timestamp để đảm bảo unique)
                // Database yêu cầu CHAR(10)
                long ticks = DateTime.Now.Ticks;
                string suffix = (ticks % 100000000).ToString("D8"); // 8 số
                return "HD" + suffix; // HD + 8 số = 10 ký tự
            }
            catch { return string.Empty; }
        }

        public List<HoaDonDTO> LayHoaDonTheoKhachHang(string maKH)
        {
            try
            {
                if (string.IsNullOrEmpty(maKH)) return new List<HoaDonDTO>();
                return dal.layHoaDonTheoKhachHang(maKH);
            }
            catch { return new List<HoaDonDTO>(); }
        }
    }
}
