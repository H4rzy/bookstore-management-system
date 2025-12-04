using System;

namespace QLNS.Models
{
    /// <summary>
    /// Entity class representing a customer (Khách hàng)
    /// </summary>
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string LoaiKH { get; set; }
    }
}
