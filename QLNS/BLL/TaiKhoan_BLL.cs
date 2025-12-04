using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class TaiKhoan_BLL
    {
        private TaiKhoanDAL dal = new TaiKhoanDAL();

        private string MaHoaPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public bool DangNhap(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return false;

                string matKhauMaHoa = MaHoaPassword(password);
                return dal.kiemTraDangNhap(username, matKhauMaHoa);
            }
            catch { return false; }
        }

        public TaiKhoanDTO LayTaiKhoan(string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username)) return null;
                return dal.layTaiKhoanTheoTenDangNhap(username);
            }
            catch { return null; }
        }

        public bool ThemTaiKhoan(TaiKhoanDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.TenDangNhap) || string.IsNullOrEmpty(dto.MatKhau))
                    return false;

                if (dal.kiemTraTrungTenDangNhap(dto.TenDangNhap))
                    return false;

                // Mã hóa password
                dto.MatKhau = MaHoaPassword(dto.MatKhau);
                return dal.themTaiKhoan(dto);
            }
            catch { return false; }
        }

        public bool DoiMatKhau(string username, string matKhauCu, string matKhauMoi)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi))
                    return false;

                // Kiểm tra mật khẩu cũ
                string mkCuMaHoa = MaHoaPassword(matKhauCu);
                if (!dal.kiemTraDangNhap(username, mkCuMaHoa))
                    return false;

                // Đổi mật khẩu mới
                string mkMoiMaHoa = MaHoaPassword(matKhauMoi);
                return dal.doiMatKhau(username, mkMoiMaHoa);
            }
            catch { return false; }
        }

        public bool XoaTaiKhoan(string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username)) return false;
                return dal.xoaTaiKhoan(username);
            }
            catch { return false; }
        }

        public List<TaiKhoanDTO> LayDanhSachTaiKhoan()
        {
            try
            {
                return dal.layDanhSachTaiKhoan();
            }
            catch { return new List<TaiKhoanDTO>(); }
        }
    }
}
