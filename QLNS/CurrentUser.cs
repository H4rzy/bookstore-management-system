using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;

namespace QLNS
{
    /// <summary>
    /// Global session manager (Static class for application-wide access)
    /// Replaces the old CurrentUser implementation with RBAC support
    /// </summary>
    public static class CurrentUser
    {
        /// <summary>
        /// Current logged-in user session with permissions
        /// </summary>
        public static UserSessionDTO CurrentSession { get; set; }

        /// <summary>
        /// Check if user is logged in
        /// </summary>
        public static bool IsLoggedIn => CurrentSession != null;

        // Legacy properties for backward compatibility
        public static string Username => CurrentSession?.TenDangNhap;
        public static string MaNV => CurrentSession?.MaNV;
        public static string TenNV => CurrentSession?.TenNV;
        public static string VaiTro => CurrentSession?.MaRole;

        /// <summary>
        /// Check if current user is admin
        /// </summary>
        public static bool IsAdmin => CurrentSession?.MaRole == "ADMIN";

        /// <summary>
        /// Check if user has permission to access a specific screen
        /// </summary>
        /// <param name="maManHinh">Screen code (e.g., SF001, SF002)</param>
        /// <returns>True if user has permission</returns>
        public static bool HasPermission(string maManHinh)
        {
            if (!IsLoggedIn) return false;
            return CurrentSession.QuyenList != null && CurrentSession.QuyenList.Contains(maManHinh);
        }

        /// <summary>
        /// Clear current session (logout)
        /// </summary>
        public static void Clear()
        {
            CurrentSession = null;
        }
    }
}
