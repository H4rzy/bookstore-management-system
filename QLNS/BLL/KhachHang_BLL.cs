using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class KhachHang_BLL
    {
        private KhachHangDAL dal = new KhachHangDAL();

        public bool ThemKhachHang(KhachHangDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaKH) || string.IsNullOrEmpty(dto.TenKH))
                    return false;

                if (dal.kiemTraTrungMa(dto.MaKH))
                    return false;

                return dal.themKhachHang(dto);
            }
            catch { return false; }
        }

        public bool CapNhatKhachHang(KhachHangDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaKH) || string.IsNullOrEmpty(dto.TenKH))
                    return false;

                return dal.capNhatKhachHang(dto);
            }
            catch { return false; }
        }

        public bool XoaKhachHang(string maKH)
        {
            try
            {
                if (string.IsNullOrEmpty(maKH)) return false;

                // Kiểm tra có hóa đơn không
                HoaDonDAL hdDAL = new HoaDonDAL();
                var dsHoaDon = hdDAL.layHoaDonTheoKhachHang(maKH);
                if (dsHoaDon != null && dsHoaDon.Count > 0)
                    return false;

                return dal.xoaKhachHang(maKH);
            }
            catch { return false; }
        }

        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            try
            {
                return dal.layDanhSachKhachHang();
            }
            catch { return new List<KhachHangDTO>(); }
        }

        public KhachHangDTO LayKhachHangTheoMa(string maKH)
        {
            try
            {
                if (string.IsNullOrEmpty(maKH)) return null;
                return dal.layKhachHangTheoMa(maKH);
            }
            catch { return null; }
        }

        public System.Data.DataTable TimKiemKhachHang(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword)) return new System.Data.DataTable();
                return dal.timKiemKhachHangTheoTen(keyword);
            }
            catch { return new System.Data.DataTable(); }
        }
    }
}
