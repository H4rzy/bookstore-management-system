using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class ChiTietHoaDon_BLL
    {
        private ChiTietHoaDonDAL dal = new ChiTietHoaDonDAL();

        public bool ThemChiTiet(ChiTietHoaDonDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.SoHD) || string.IsNullOrEmpty(dto.MaSach))
                    return false;
                if (dto.SoLuong <= 0) return false;

                // Kiểm tra tồn kho
                Sach_BLL sachBLL = new Sach_BLL();
                if (!sachBLL.KiemTraTonKhoDu(dto.MaSach, dto.SoLuong))
                    return false;

                // Trừ tồn kho
                if (!sachBLL.CapNhatTonKho(dto.MaSach, dto.SoLuong, false)) // false = xuất
                    return false;

                return dal.themChiTietHoaDon(dto);
            }
            catch { return false; }
        }

        public bool XoaChiTiet(string soHD, string maSach)
        {
            try
            {
                if (string.IsNullOrEmpty(soHD) || string.IsNullOrEmpty(maSach))
                    return false;

                // Lấy thông tin chi tiết để biết số lượng
                var dsChiTiet = dal.layDanhSachChiTietTheoSoHD(soHD);
                var chiTiet = dsChiTiet.FirstOrDefault(x => x.MaSach == maSach);
                if (chiTiet == null) return false;

                // Cộng lại tồn kho
                Sach_BLL sachBLL = new Sach_BLL();
                if (!sachBLL.CapNhatTonKho(maSach, chiTiet.SoLuong, true)) // true = cộng lại
                    return false;

                return dal.xoaChiTietHoaDon(soHD, maSach);
            }
            catch { return false; }
        }

        public List<ChiTietHoaDonDTO> LayChiTiet(string soHD)
        {
            try
            {
                if (string.IsNullOrEmpty(soHD)) return new List<ChiTietHoaDonDTO>();
                return dal.layDanhSachChiTietTheoSoHD(soHD);
            }
            catch { return new List<ChiTietHoaDonDTO>(); }
        }

        public decimal TinhTongTien(string soHD)
        {
            try
            {
                if (string.IsNullOrEmpty(soHD)) return 0;
                return dal.tinhTongTienHoaDon(soHD);
            }
            catch { return 0; }
        }

        public bool XoaTatCaChiTiet(string soHD)
        {
            try
            {
                if (string.IsNullOrEmpty(soHD)) return false;

                // Lấy danh sách chi tiết để cộng lại tồn kho
                var dsChiTiet = dal.layDanhSachChiTietTheoSoHD(soHD);

                // Cộng lại tồn kho cho từng sách
                Sach_BLL sachBLL = new Sach_BLL();
                foreach (var chiTiet in dsChiTiet)
                {
                    if (!sachBLL.CapNhatTonKho(chiTiet.MaSach, chiTiet.SoLuong, true)) // true = cộng lại
                        return false;
                }

                // Xóa từng chi tiết
                foreach (var chiTiet in dsChiTiet)
                {
                    if (!dal.xoaChiTietHoaDon(soHD, chiTiet.MaSach))
                        return false;
                }

                return true;
            }
            catch { return false; }
        }

        public System.Data.DataTable ThongKeSachBanChay(int top)
        {
            try
            {
                if (top <= 0) return new System.Data.DataTable();
                return dal.laySachBanChay(top);
            }
            catch { return new System.Data.DataTable(); }
        }
    }
}
