using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    public class ChiTietPhieuNhapDTO
    {
        public string SoPN { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }

        public ChiTietPhieuNhapDTO(string soPN, string maSach, int soLuong, decimal donGiaNhap)
        {
            SoPN = soPN;
            MaSach = maSach;
            SoLuong = soLuong;
            DonGiaNhap = donGiaNhap;
        }

        public ChiTietPhieuNhapDTO()
        {
        }
    }
}
