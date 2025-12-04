using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    public class SachDTO
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaTheLoai { get; set; }
        public string MaNXB { get; set; }
        public string TacGia { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public int SoLuongTon { get; set; }

        public SachDTO(string maSach, string tenSach, string maTheLoai, string maNXB, string tacGia, decimal donGiaNhap, decimal donGiaBan, int soLuongTon)
        {
            MaSach = maSach;
            TenSach = tenSach;
            MaTheLoai = maTheLoai;
            MaNXB = maNXB;
            TacGia = tacGia;
            DonGiaNhap = donGiaNhap;
            DonGiaBan = donGiaBan;
            SoLuongTon = soLuongTon;
        }

        public SachDTO()
        {
        }
    }
}
