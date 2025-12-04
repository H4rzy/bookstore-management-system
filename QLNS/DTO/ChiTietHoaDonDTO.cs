using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    public class ChiTietHoaDonDTO
    {
        public string SoHD { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaBan { get; set; }

        public ChiTietHoaDonDTO(string soHD, string maSach, int soLuong, decimal donGiaBan)
        {
            SoHD = soHD;
            MaSach = maSach;
            SoLuong = soLuong;
            DonGiaBan = donGiaBan;
        }

        public ChiTietHoaDonDTO()
        {
        }
    }
}
