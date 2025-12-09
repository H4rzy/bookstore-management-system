using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    /// <summary>
    /// Data Transfer Object for Permission (Quyen) entity
    /// Maps roles to screens/features with permission flags
    /// </summary>
    public class QuyenDTO
    {
        public string MaRole { get; set; }
        public string MaManHinh { get; set; }
        public bool CoQuyen { get; set; }

        public QuyenDTO()
        {
        }

        public QuyenDTO(string maRole, string maManHinh, bool coQuyen)
        {
            MaRole = maRole;
            MaManHinh = maManHinh;
            CoQuyen = coQuyen;
        }
    }
}
