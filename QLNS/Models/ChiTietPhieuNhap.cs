using System;

namespace QLNS.Models
{
    /// <summary>
    /// Entity class representing purchase order details (Chi tiết phiếu nhập)
    /// </summary>
    public class ChiTietPhieuNhap
    {
        public string SoPN { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }

        // Navigation properties
        public PhieuNhap PhieuNhap { get; set; }
        public Sach Sach { get; set; }

        // Calculated property
        public decimal ThanhTien
        {
            get { return SoLuong * DonGiaNhap; }
        }
    }
}
