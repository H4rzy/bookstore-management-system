using System;

namespace QLNS.Models
{
    /// <summary>
    /// Entity class representing a user account (Tài khoản)
    /// </summary>
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string MaNV { get; set; }
        public string Quyen { get; set; }

        // Navigation property
        public NhanVien NhanVien { get; set; }
    }
}
