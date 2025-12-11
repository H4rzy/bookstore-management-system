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
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.SoHD) || string.IsNullOrEmpty(dto.MaNV))
                    return false;

                if (dal.kiemTraTrungSo(dto.SoHD))
                    return false;

                return dal.themHoaDon(dto);
            }
            catch { return false; }
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
                // Format: HD + YYYYMMDDHHmmss
                return "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
