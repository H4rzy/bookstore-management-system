using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class PhieuNhap_BLL
    {
        private PhieuNhapDAL dal = new PhieuNhapDAL();

        public bool ThemPhieuNhap(PhieuNhapDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.SoPN) || string.IsNullOrEmpty(dto.MaNV))
                    return false;

                if (dal.kiemTraTrungSo(dto.SoPN))
                    return false;

                return dal.themPhieuNhap(dto);
            }
            catch { return false; }
        }

        public bool XoaPhieuNhap(string soPN)
        {
            try
            {
                if (string.IsNullOrEmpty(soPN)) return false;

                // Lấy danh sách chi tiết để trừ tồn kho
                ChiTietPhieuNhapDAL ctDAL = new ChiTietPhieuNhapDAL();
                var dsChiTiet = ctDAL.layDanhSachChiTietTheoSoPN(soPN);

                // Trừ tồn kho cho từng sách
                Sach_BLL sachBLL = new Sach_BLL();
                foreach (var ct in dsChiTiet)
                {
                    sachBLL.CapNhatTonKho(ct.MaSach, ct.SoLuong, false); // false = trừ
                }

                return dal.xoaPhieuNhap(soPN);
            }
            catch { return false; }
        }

        public List<PhieuNhapDTO> LayDanhSachPhieuNhap()
        {
            try
            {
                return dal.layDanhSachPhieuNhap();
            }
            catch { return new List<PhieuNhapDTO>(); }
        }

        public PhieuNhapDTO LayPhieuNhapTheoSo(string soPN)
        {
            try
            {
                if (string.IsNullOrEmpty(soPN)) return null;
                return dal.layPhieuNhapTheoSo(soPN);
            }
            catch { return null; }
        }
    }
}
