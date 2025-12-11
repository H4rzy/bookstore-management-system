using System;

namespace QLNS_DTO
{
    /// <summary>
    /// Data Transfer Object for VIP Card
    /// </summary>
    public class TheVIPDTO
    {
        public string MaTheVIP { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayCapPhat { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int DiemTichLuy { get; set; }
        public decimal ChiTieu { get; set; }  // Tổng chi tiêu
        public bool TrangThai { get; set; }   // Active/Inactive

        // Computed properties
        public bool IsActive
        {
            get
            {
                return TrangThai && NgayHetHan >= DateTime.Now;
            }
        }

        public bool IsExpired
        {
            get
            {
                return NgayHetHan < DateTime.Now;
            }
        }

        public int SoNgayConLai
        {
            get
            {
                if (NgayHetHan < DateTime.Now)
                    return 0;
                return (NgayHetHan - DateTime.Now).Days;
            }
        }

        public string HangVIP
        {
            get
            {
                if (DiemTichLuy >= 1000 || ChiTieu >= 10000000) // 10 triệu
                    return "Platinum";
                else if (DiemTichLuy >= 500 || ChiTieu >= 5000000) // 5 triệu
                    return "Gold";
                else
                    return "Silver";
            }
        }

        public TheVIPDTO()
        {
            NgayCapPhat = DateTime.Now;
            NgayHetHan = DateTime.Now.AddYears(1);
            DiemTichLuy = 0;
            ChiTieu = 0;
            TrangThai = true;
        }

        public TheVIPDTO(string maTheVIP, string maKH, DateTime ngayCapPhat, DateTime ngayHetHan, 
                         int diemTichLuy, decimal chiTieu, bool trangThai)
        {
            MaTheVIP = maTheVIP;
            MaKH = maKH;
            NgayCapPhat = ngayCapPhat;
            NgayHetHan = ngayHetHan;
            DiemTichLuy = diemTichLuy;
            ChiTieu = chiTieu;
            TrangThai = trangThai;
        }
    }
}
