using QLNS.Models;

namespace QLNS.DAL.Interfaces
{
    /// <summary>
    /// Repository interface for Account (TaiKhoan) entity
    /// </summary>
    public interface ITaiKhoanRepository : IRepository<TaiKhoan>
    {
        /// <summary>
        /// Validates user login credentials
        /// </summary>
        /// <param name="tenDangNhap">Username</param>
        /// <param name="matKhau">Password</param>
        /// <returns>Account if credentials are valid, null otherwise</returns>
        TaiKhoan ValidateLogin(string tenDangNhap, string matKhau);

        /// <summary>
        /// Changes user password
        /// </summary>
        /// <param name="tenDangNhap">Username</param>
        /// <param name="matKhauCu">Old password</param>
        /// <param name="matKhauMoi">New password</param>
        /// <returns>True if successful, false otherwise</returns>
        bool ChangePassword(string tenDangNhap, string matKhauCu, string matKhauMoi);
    }
}
