using System;

namespace QLNS.Models
{
    /// <summary>
    /// Entity class representing invoice details (Chi tiết hóa đơn)
    /// </summary>
    public class ChiTietHoaDon
    {
        public string SoHD { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaBan { get; set; }

        // Navigation properties
        public HoaDon HoaDon { get; set; }
        public Sach Sach { get; set; }

        // Calculated property
        public decimal ThanhTien
        {
            get { return SoLuong * DonGiaBan; }
        }
    }
}
