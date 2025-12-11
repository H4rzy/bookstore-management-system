using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class Sach_BLL
    {
        private SachDAL dal = new SachDAL();

        public bool ThemSach(SachDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaSach) || string.IsNullOrEmpty(dto.TenSach))
                    return false;

                // Validate giá bán > giá nhập
                if (dto.DonGiaBan <= dto.DonGiaNhap)
                    return false;

                if (dal.kiemTraTrungMa(dto.MaSach))
                    return false;

                return dal.themSach(dto);
            }
            catch { return false; }
        }

        public bool CapNhatSach(SachDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaSach) || string.IsNullOrEmpty(dto.TenSach))
                    return false;

                if (dto.DonGiaBan <= dto.DonGiaNhap)
                    return false;

                // Track price history if price changed
                var oldSach = LaySachTheoMa(dto.MaSach);
                if (oldSach != null && oldSach.DonGiaBan != dto.DonGiaBan)
                {
                    // Create price history entry
                    string priceHistory = $"[{DateTime.Now:dd/MM/yyyy HH:mm}] " +
                        $"Giá: {oldSach.DonGiaBan:N0} → {dto.DonGiaBan:N0} VNĐ | ";
                    
                    // Prepend to existing GhiChu
                    dto.GhiChu = priceHistory + (dto.GhiChu ?? "");
                    
                    // Keep only last ~400 chars to avoid overflow
                    if (dto.GhiChu.Length > 400)
                        dto.GhiChu = dto.GhiChu.Substring(0, 400);
                }

                return dal.capNhatSach(dto);
            }
            catch { return false; }
        }

        public bool XoaSach(string maSach)
        {
            try
            {
                if (string.IsNullOrEmpty(maSach)) return false;

                // Kiểm tra có trong chi tiết phiếu nhập không
                ChiTietPhieuNhapDAL ctpnDAL = new ChiTietPhieuNhapDAL();
                // Kiểm tra có trong chi tiết hóa đơn không
                ChiTietHoaDonDAL cthdDAL = new ChiTietHoaDonDAL();

                return dal.xoaSach(maSach);
            }
            catch { return false; }
        }

        public List<SachDTO> LayDanhSachSach()
        {
            try
            {
                return dal.layDanhSachSach();
            }
            catch { return new List<SachDTO>(); }
        }

        public List<SachDTO> LayTatCaSach()
        {
            try
            {
                return dal.layTatCaSach();
            }
            catch { return new List<SachDTO>(); }
        }

        public SachDTO LaySachTheoMa(string maSach)
        {
            try
            {
                if (string.IsNullOrEmpty(maSach)) return null;
                return dal.laySachTheoMa(maSach);
            }
            catch { return null; }
        }

        public bool CapNhatTonKho(string maSach, int soLuong, bool laNhap)
        {
            try
            {
                if (string.IsNullOrEmpty(maSach)) return false;

                int tonKhoHienTai = dal.laySoLuongTon(maSach);
                int tonKhoMoi = laNhap ? tonKhoHienTai + soLuong : tonKhoHienTai - soLuong;

                if (tonKhoMoi < 0) return false;

                return dal.capNhatSoLuongTon(maSach, tonKhoMoi);
            }
            catch { return false; }
        }

        public bool KiemTraTonKhoDu(string maSach, int soLuong)
        {
            try
            {
                if (string.IsNullOrEmpty(maSach)) return false;
                int tonKho = dal.laySoLuongTon(maSach);
                return tonKho >= soLuong;
            }
            catch { return false; }
        }

        public System.Data.DataTable TimKiemSach(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword)) return new System.Data.DataTable();
                return dal.timKiemSachTheoTen(keyword);
            }
            catch { return new System.Data.DataTable(); }
        }
    }
}
