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

        // Overload for simple password change (already verified old password)
        public bool DoiMatKhau(string username, string matKhauMoi)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(matKhauMoi))
                    return false;

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

        public bool CapNhatTaiKhoan(TaiKhoanDTO dto, bool updatePassword)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.TenDangNhap)) return false;

                // If updating password, hash it
                if (updatePassword && !string.IsNullOrEmpty(dto.MatKhau))
                {
                    dto.MatKhau = MaHoaPassword(dto.MatKhau);
                }

                return dal.capNhatTaiKhoan(dto);
            }
            catch { return false; }
        }

        /// <summary>
        /// Gán tài khoản cho nhân viên (SF004.05)
        /// </summary>
        public bool GanTaiKhoanChoNhanVien(string maNV, string tenDangNhap, string matKhau, string maRole, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                {
                    errorMessage = "Vui lòng điền đầy đủ thông tin!";
                    return false;
                }

                var existingAccount = dal.LayTaiKhoanTheoMaNV(maNV);
                if (existingAccount != null)
                {
                    errorMessage = "Nhân viên này đã có tài khoản: " + existingAccount.TenDangNhap;
                    return false;
                }

                if (dal.kiemTraTrungTenDangNhap(tenDangNhap))
                {
                    errorMessage = "Tên đăng nhập đã tồn tại!";
                    return false;
                }

                var newAccount = new TaiKhoanDTO
                {
                    TenDangNhap = tenDangNhap,
                    MatKhau = MaHoaPassword(matKhau),
                    MaNV = maNV,
                    MaRole = maRole,
                    TrangThai = true
                };

                bool result = dal.themTaiKhoan(newAccount);
                
                if (result)
                {
                    try
                    {
                        AuditLogDAL auditDal = new AuditLogDAL();
                        auditDal.ThemLogHoatDong(new AuditLogDTO { 
                        MaLog = Guid.NewGuid().ToString(), 
                        TenDangNhap = QLNS.CurrentUser.Username, 
                        HanhDong = $"Gán tài khoản '{tenDangNhap}' cho nhân viên {maNV}", 
                        ThoiGian = DateTime.Now });
                    }
                    catch { }
                }

                return result;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Khoá tài khoản (SF004.08)
        /// </summary>
        public bool KhoaTaiKhoan(string tenDangNhap, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    errorMessage = "Tên đăng nhập không được rỗng!";
                    return false;
                }

                if (tenDangNhap.ToLower() == "admin")
                {
                    errorMessage = "Không thể khoá tài khoản admin!";
                    return false;
                }

                var account = dal.layTaiKhoanTheoTenDangNhap(tenDangNhap);
                if (account == null)
                {
                    errorMessage = "Không tìm thấy tài khoản!";
                    return false;
                }

                bool result = dal.KhoaTaiKhoan(tenDangNhap);
                
                if (result)
                {
                    try
                    {
                        AuditLogDAL auditDal = new AuditLogDAL();
                        auditDal.ThemLogHoatDong(new AuditLogDTO { 
                        MaLog = Guid.NewGuid().ToString(), 
                        TenDangNhap = QLNS.CurrentUser.Username, 
                        HanhDong = $"Khoá tài khoản: {tenDangNhap}", 
                        ThoiGian = DateTime.Now });
                    }
                    catch { }
                }

                return result;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Mở khoá tài khoản (SF004.09)
        /// </summary>
        public bool MoKhoaTaiKhoan(string tenDangNhap, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    errorMessage = "Tên đăng nhập không được rỗng!";
                    return false;
                }

                var account = dal.layTaiKhoanTheoTenDangNhap(tenDangNhap);
                if (account == null)
                {
                    errorMessage = "Không tìm thấy tài khoản!";
                    return false;
                }

                bool result = dal.MoKhoaTaiKhoan(tenDangNhap);
                
                if (result)
                {
                    try
                    {
                        AuditLogDAL auditDal = new AuditLogDAL();
                        auditDal.ThemLogHoatDong(new AuditLogDTO { 
                        MaLog = Guid.NewGuid().ToString(), 
                        TenDangNhap = QLNS.CurrentUser.Username, 
                        HanhDong = $"Mở khoá tài khoản: {tenDangNhap}", 
                        ThoiGian = DateTime.Now });
                    }
                    catch { }
                }

                return result;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Reset mật khẩu (SF004.07, SF008.02)
        /// </summary>
        public string ResetMatKhau(string tenDangNhap, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    errorMessage = "Tên đăng nhập không được rỗng!";
                    return null;
                }

                var account = dal.layTaiKhoanTheoTenDangNhap(tenDangNhap);
                if (account == null)
                {
                    errorMessage = "Không tìm thấy tài khoản!";
                    return null;
                }

                string newPassword = GenerateRandomPassword(8);
                string hashedPassword = MaHoaPassword(newPassword);

                bool result = dal.ResetMatKhau(tenDangNhap, hashedPassword);
                
                if (result)
                {
                    try
                    {
                        AuditLogDAL auditDal = new AuditLogDAL();
                        auditDal.ThemLogHoatDong(new AuditLogDTO { 
                        MaLog = Guid.NewGuid().ToString(), 
                        TenDangNhap = QLNS.CurrentUser.Username, 
                        HanhDong = $"Reset mật khẩu cho: {tenDangNhap}", 
                        ThoiGian = DateTime.Now });
                    }
                    catch { }

                    return newPassword;
                }

                errorMessage = "Không thể reset mật khẩu!";
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi: " + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Lấy tài khoản của nhân viên
        /// </summary>
        public TaiKhoanDTO LayTaiKhoanCuaNhanVien(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV)) return null;
                return dal.LayTaiKhoanTheoMaNV(maNV);
            }
            catch { return null; }
        }

        /// <summary>
        /// Tạo mật khẩu ngẫu nhiên
        /// </summary>
        private string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
