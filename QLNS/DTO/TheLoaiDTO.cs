using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    public class TheLoaiDTO
    {
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }

        public TheLoaiDTO(string maTheLoai, string tenTheLoai)
        {
            MaTheLoai = maTheLoai;
            TenTheLoai = tenTheLoai;
        }

        public TheLoaiDTO()
        {
        }
    }
}
