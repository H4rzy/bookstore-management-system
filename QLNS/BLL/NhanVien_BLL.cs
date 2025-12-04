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

        /// <summary>
        /// Thêm nhân viên mới
        /// </summary>
        public bool ThemNhanVien(NhanVienDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaNV) || string.IsNullOrEmpty(dto.TenNV))
                    return false;

                // Validate phone number if provided
                if (!string.IsNullOrEmpty(dto.DienThoai))
                {
                    // Basic phone validation (can be enhanced)
                    dto.DienThoai = dto.DienThoai.Trim();
                }

                if (dal.kiemTraTrungMa(dto.MaNV))
                    return false;

                return dal.themNhanVien(dto);
            }
            catch { return false; }
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        public bool CapNhatNhanVien(NhanVienDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaNV) || string.IsNullOrEmpty(dto.TenNV))
                    return false;

                // Validate phone number if provided
                if (!string.IsNullOrEmpty(dto.DienThoai))
                {
                    dto.DienThoai = dto.DienThoai.Trim();
                }

                return dal.capNhatNhanVien(dto);
            }
            catch { return false; }
        }

        /// <summary>
        /// Xóa nhân viên (kiểm tra ràng buộc với phiếu nhập/hóa đơn)
        /// </summary>
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

                // Kiểm tra có tài khoản không
                TaiKhoanDAL tkDAL = new TaiKhoanDAL();
                var dsTaiKhoan = tkDAL.layDanhSachTaiKhoan();
                var taiKhoan = dsTaiKhoan.FirstOrDefault(tk => tk.MaNV == maNV);
                if (taiKhoan != null)
                {
                    // Xóa tài khoản trước
                    tkDAL.xoaTaiKhoan(taiKhoan.TenDangNhap);
                }

                return dal.xoaNhanVien(maNV);
            }
            catch { return false; }
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            try
            {
                return dal.layDanhSachNhanVien();
            }
            catch { return new List<NhanVienDTO>(); }
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo mã
        /// </summary>
        public NhanVienDTO LayNhanVienTheoMa(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV)) return null;
                return dal.layNhanVienTheoMa(maNV);
            }
            catch { return null; }
        }

        /// <summary>
        /// Tìm kiếm nhân viên theo tên
        /// </summary>
        public System.Data.DataTable TimKiemNhanVien(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword)) return new System.Data.DataTable();
                return dal.timKiemNhanVienTheoTen(keyword);
            }
            catch { return new System.Data.DataTable(); }
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo chức vụ
        /// </summary>
        public List<NhanVienDTO> LayNhanVienTheoChucVu(string chucVu)
        {
            try
            {
                if (string.IsNullOrEmpty(chucVu)) return new List<NhanVienDTO>();
                return dal.layNhanVienTheoChucVu(chucVu);
            }
            catch { return new List<NhanVienDTO>(); }
        }

        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại chưa
        /// </summary>
        public bool KiemTraTrungMa(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV)) return false;
                return dal.kiemTraTrungMa(maNV);
            }
            catch { return false; }
        }

        /// <summary>
        /// Đếm số lượng nhân viên
        /// </summary>
        public int DemSoLuongNhanVien()
        {
            try
            {
                var ds = dal.layDanhSachNhanVien();
                return ds != null ? ds.Count : 0;
            }
            catch { return 0; }
        }

        /// <summary>
        /// Đếm số lượng nhân viên theo giới tính
        /// </summary>
        public int DemNhanVienTheoGioiTinh(bool gioiTinh)
        {
            try
            {
                var ds = dal.layDanhSachNhanVien();
                return ds != null ? ds.Count(nv => nv.GioiTinh == gioiTinh) : 0;
            }
            catch { return 0; }
        }

        /// <summary>
        /// Đếm số lượng nhân viên theo chức vụ
        /// </summary>
        public int DemNhanVienTheoChucVu(string chucVu)
        {
            try
            {
                var ds = dal.layNhanVienTheoChucVu(chucVu);
                return ds != null ? ds.Count : 0;
            }
            catch { return 0; }
        }

        /// <summary>
        /// Lấy danh sách chức vụ (distinct)
        /// </summary>
        public List<string> LayDanhSachChucVu()
        {
            try
            {
                var ds = dal.layDanhSachNhanVien();
                if (ds == null || ds.Count == 0) return new List<string>();

                return ds.Where(nv => !string.IsNullOrEmpty(nv.ChucVu))
                        .Select(nv => nv.ChucVu)
                        .Distinct()
                        .OrderBy(cv => cv)
                        .ToList();
            }
            catch { return new List<string>(); }
        }

        /// <summary>
        /// Kiểm tra nhân viên có tài khoản chưa
        /// </summary>
        public bool KiemTraCoTaiKhoan(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV)) return false;
                
                TaiKhoanDAL tkDAL = new TaiKhoanDAL();
                var dsTaiKhoan = tkDAL.layDanhSachTaiKhoan();
                return dsTaiKhoan.Any(tk => tk.MaNV == maNV);
            }
            catch { return false; }
        }

        /// <summary>
        /// Kiểm tra nhân viên có thể xóa được không (không có phiếu nhập/hóa đơn)
        /// </summary>
        public bool KiemTraCoTheXoa(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV)) return false;

                // Kiểm tra phiếu nhập
                PhieuNhapDAL pnDAL = new PhieuNhapDAL();
                var dsPhieuNhap = pnDAL.layPhieuNhapTheoNhanVien(maNV);
                if (dsPhieuNhap != null && dsPhieuNhap.Count > 0)
                    return false;

                // Kiểm tra hóa đơn
                HoaDonDAL hdDAL = new HoaDonDAL();
                var dsHoaDon = hdDAL.layHoaDonTheoNhanVien(maNV);
                if (dsHoaDon != null && dsHoaDon.Count > 0)
                    return false;

                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Lấy danh sách nhân viên nam
        /// </summary>
        public List<NhanVienDTO> LayDanhSachNhanVienNam()
        {
            try
            {
                var ds = dal.layDanhSachNhanVien();
                return ds != null ? ds.Where(nv => nv.GioiTinh == true).ToList() : new List<NhanVienDTO>();
            }
            catch { return new List<NhanVienDTO>(); }
        }

        /// <summary>
        /// Lấy danh sách nhân viên nữ
        /// </summary>
        public List<NhanVienDTO> LayDanhSachNhanVienNu()
        {
            try
            {
                var ds = dal.layDanhSachNhanVien();
                return ds != null ? ds.Where(nv => nv.GioiTinh == false).ToList() : new List<NhanVienDTO>();
            }
            catch { return new List<NhanVienDTO>(); }
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhân viên hợp lệ
        /// </summary>
        public bool KiemTraDuLieuHopLe(NhanVienDTO dto, out string errorMessage)
        {
            errorMessage = "";

            if (dto == null)
            {
                errorMessage = "Dữ liệu nhân viên không được null";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.MaNV))
            {
                errorMessage = "Mã nhân viên không được để trống";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.TenNV))
            {
                errorMessage = "Tên nhân viên không được để trống";
                return false;
            }

            if (dto.TenNV.Trim().Length < 2)
            {
                errorMessage = "Tên nhân viên phải có ít nhất 2 ký tự";
                return false;
            }

            if (!string.IsNullOrEmpty(dto.DienThoai))
            {
                string phone = dto.DienThoai.Trim();
                if (phone.Length < 10 || phone.Length > 11)
                {
                    errorMessage = "Số điện thoại phải có 10-11 số";
                    return false;
                }

                if (!phone.All(char.IsDigit))
                {
                    errorMessage = "Số điện thoại chỉ được chứa chữ số";
                    return false;
                }
            }

            return true;
        }
    }
}
