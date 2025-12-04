using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class NhanVien_BLL
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public bool ThemNhanVien(NhanVienDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaNV) || string.IsNullOrEmpty(dto.TenNV))
                    return false;

                if (dal.kiemTraTrungMa(dto.MaNV))
                    return false;

                return dal.themNhanVien(dto);
            }
            catch { return false; }
        }

        public bool CapNhatNhanVien(NhanVienDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaNV) || string.IsNullOrEmpty(dto.TenNV))
                    return false;

                return dal.capNhatNhanVien(dto);
            }
            catch { return false; }
        }

        public bool XoaNhanVien(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV)) return false;

                // Kiểm tra có phiếu nhập/hóa đơn không
                PhieuNhapDAL pnDAL = new PhieuNhapDAL();
                var dsPhieuNhap = pnDAL.layPhieuNhapTheoNhanVien(maNV);
                if (dsPhieuNhap != null && dsPhieuNhap.Count > 0)
                    return false;

                HoaDonDAL hdDAL = new HoaDonDAL();
                var dsHoaDon = hdDAL.layHoaDonTheoNhanVien(maNV);
                if (dsHoaDon != null && dsHoaDon.Count > 0)
                    return false;

                return dal.xoaNhanVien(maNV);
            }
            catch { return false; }
        }

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            try
            {
                return dal.layDanhSachNhanVien();
            }
            catch { return new List<NhanVienDTO>(); }
        }

        public NhanVienDTO LayNhanVienTheoMa(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV)) return null;
                return dal.layNhanVienTheoMa(maNV);
            }
            catch { return null; }
        }

        public System.Data.DataTable TimKiemNhanVien(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword)) return new System.Data.DataTable();
                return dal.timKiemNhanVienTheoTen(keyword);
            }
            catch { return new System.Data.DataTable(); }
        }
    }
}
