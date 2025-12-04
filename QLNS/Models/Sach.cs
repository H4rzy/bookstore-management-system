using System;

namespace QLNS.Models
{
    /// <summary>
    /// Entity class representing a book (Sách)
    /// </summary>
    public class Sach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaTheLoai { get; set; }
        public string MaNXB { get; set; }
        public string TacGia { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public int SoLuongTon { get; set; }

        // Navigation properties
        public TheLoai TheLoai { get; set; }
        public NhaXuatBan NhaXuatBan { get; set; }
    }
}
