using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    /// <summary>
    /// Entity class representing a sales invoice (Hóa đơn)
    /// </summary>
    public class HoaDon
    {
        public string SoHD { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public string GhiChu { get; set; }

        // Navigation properties
        public NhanVien NhanVien { get; set; }
        public KhachHang KhachHang { get; set; }
        public List<ChiTietHoaDon> ChiTietHoaDon { get; set; }
    }
}
