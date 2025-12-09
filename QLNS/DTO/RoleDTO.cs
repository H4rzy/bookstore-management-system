using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    /// <summary>
    /// Data Transfer Object for Role entity
    /// </summary>
    public class RoleDTO
    {
        public string MaRole { get; set; }
        public string TenRole { get; set; }
        public string MoTa { get; set; }

        public RoleDTO()
        {
        }

        public RoleDTO(string maRole, string tenRole, string moTa)
        {
            MaRole = maRole;
            TenRole = tenRole;
            MoTa = moTa;
        }
    }
}
