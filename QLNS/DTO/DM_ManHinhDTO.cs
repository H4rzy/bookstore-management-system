using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    /// <summary>
    /// Data Transfer Object for Screen/Feature management
    /// </summary>
    public class DM_ManHinhDTO
    {
        public string MaManHinh { get; set; }
        public string TenManHinh { get; set; }
        public string LoaiChucNang { get; set; }

        public DM_ManHinhDTO()
        {
        }

        public DM_ManHinhDTO(string maManHinh, string tenManHinh, string loaiChucNang)
        {
            MaManHinh = maManHinh;
            TenManHinh = tenManHinh;
            LoaiChucNang = loaiChucNang;
        }
    }
}
