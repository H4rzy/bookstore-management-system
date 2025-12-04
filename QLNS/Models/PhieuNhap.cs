using System;
using System.Collections.Generic;

namespace QLNS.Models
{
    /// <summary>
    /// Entity class representing a purchase order (Phiếu nhập)
    /// </summary>
    public class PhieuNhap
    {
        public string SoPN { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNV { get; set; }
        public string GhiChu { get; set; }

        // Navigation properties
        public NhanVien NhanVien { get; set; }
        public List<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
    }
}
