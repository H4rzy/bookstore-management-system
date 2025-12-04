using System;

namespace QLNS.Models
{
    /// <summary>
    /// Entity class representing an employee (Nhân viên)
    /// </summary>
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public bool GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }
    }
}
