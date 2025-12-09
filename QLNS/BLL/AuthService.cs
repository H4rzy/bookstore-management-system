using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    /// <summary>
    /// Authentication Service - Handles user login and session creation
    /// </summary>
    public class AuthService
    {
        private TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
        private PermissionService permissionService = new PermissionService();

        /// <summary>
        /// Authenticate user and create session
        /// Returns UserSessionDTO if successful, null otherwise
        /// </summary>
        public UserSessionDTO Login(string tenDangNhap, string matKhau)
        {
            try
            {
                // Encrypt password (using existing TaiKhoan_BLL logic)
                TaiKhoan_BLL tkBLL = new TaiKhoan_BLL();
                string matKhauMaHoa = MaHoaPassword(matKhau);

                // Get user info with role and employee details
                DataRow userInfo = taiKhoanDAL.LayThongTinDangNhap(tenDangNhap, matKhauMaHoa);

                if (userInfo == null)
                {
                    // Login failed
                    permissionService.LogActivity(tenDangNhap, "Đăng nhập thất bại", "Tên đăng nhập hoặc mật khẩu không đúng");
                    return null;
                }

                // Create user session
                UserSessionDTO session = new UserSessionDTO
                {
                    TenDangNhap = userInfo["TenDangNhap"].ToString(),
                    MaNV = userInfo["MaNV"].ToString(),
                    TenNV = userInfo["TenNV"].ToString(),
                    MaRole = userInfo["MaRole"].ToString(),
                    TenRole = userInfo["TenRole"].ToString(),
                    LoginTime = DateTime.Now
                };

                // Load user permissions
                session.QuyenList = permissionService.GetUserPermissions(tenDangNhap);

                // Log successful login
                permissionService.LogActivity(tenDangNhap, "Đăng nhập thành công", 
                    $"Role: {session.TenRole}, Nhân viên: {session.TenNV}");

                return session;
            }
            catch (Exception ex)
            {
                permissionService.LogActivity(tenDangNhap, "Lỗi đăng nhập", ex.Message);
                throw new Exception("Login error: " + ex.Message);
            }
        }

        /// <summary>
        /// Logout user and log activity
        /// </summary>
        public void Logout(UserSessionDTO user)
        {
            try
            {
                if (user != null)
                {
                    TimeSpan sessionDuration = DateTime.Now - user.LoginTime;
                    permissionService.LogActivity(user.TenDangNhap, "Đăng xuất", 
                        $"Thời gian đăng nhập: {sessionDuration.TotalMinutes:F1} phút");
                }
            }
            catch (Exception ex)
            {
                // Don't throw on logout error
                System.Diagnostics.Debug.WriteLine($"Logout error: {ex.Message}");
            }
        }

        /// <summary>
        /// Hash password using SHA256 (matches existing implementation)
        /// </summary>
        private string MaHoaPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
