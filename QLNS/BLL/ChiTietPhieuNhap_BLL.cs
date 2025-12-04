using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class ChiTietPhieuNhap_BLL
    {
        private ChiTietPhieuNhapDAL dal = new ChiTietPhieuNhapDAL();

        public bool ThemChiTiet(ChiTietPhieuNhapDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.SoPN) || string.IsNullOrEmpty(dto.MaSach))
                    return false;
                if (dto.SoLuong <= 0) return false;

                // Cập nhật tồn kho
                Sach_BLL sachBLL = new Sach_BLL();
                if (!sachBLL.CapNhatTonKho(dto.MaSach, dto.SoLuong, true)) // true = nhập
                    return false;

                return dal.themChiTietPhieuNhap(dto);
            }
            catch { return false; }
        }

        public bool XoaChiTiet(string soPN, string maSach)
        {
            try
            {
                if (string.IsNullOrEmpty(soPN) || string.IsNullOrEmpty(maSach))
                    return false;

                // Lấy thông tin chi tiết để biết số lượng
                var dsChiTiet = dal.layDanhSachChiTietTheoSoPN(soPN);
                var chiTiet = dsChiTiet.FirstOrDefault(x => x.MaSach == maSach);
                if (chiTiet == null) return false;

                // Trừ tồn kho
                Sach_BLL sachBLL = new Sach_BLL();
                if (!sachBLL.CapNhatTonKho(maSach, chiTiet.SoLuong, false)) // false = trừ
                    return false;

                return dal.xoaChiTietPhieuNhap(soPN, maSach);
            }
            catch { return false; }
        }

        public List<ChiTietPhieuNhapDTO> LayChiTiet(string soPN)
        {
            try
            {
                if (string.IsNullOrEmpty(soPN)) return new List<ChiTietPhieuNhapDTO>();
                return dal.layDanhSachChiTietTheoSoPN(soPN);
            }
            catch { return new List<ChiTietPhieuNhapDTO>(); }
        }

        public decimal TinhTongTien(string soPN)
        {
            try
            {
                if (string.IsNullOrEmpty(soPN)) return 0;
                return dal.tinhTongTienPhieuNhap(soPN);
            }
            catch { return 0; }
        }
    }
}
