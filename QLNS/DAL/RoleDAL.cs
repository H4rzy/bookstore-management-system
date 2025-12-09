using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;

namespace QLNS_DAL
{
    public class RoleDAL : DBConnect
    {
        /// <summary>
        /// Get all roles from database
        /// </summary>
        public List<RoleDTO> LayDanhSachRole()
        {
            List<RoleDTO> lst = new List<RoleDTO>();
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                string sql = "SELECT MaRole, TenRole, MoTa FROM Role";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                
                while (rd.Read())
                {
                    RoleDTO role = new RoleDTO();
                    role.MaRole = rd["MaRole"].ToString();
                    role.TenRole = rd["TenRole"].ToString();
                    role.MoTa = rd["MoTa"].ToString();
                    lst.Add(role);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayDanhSachRole: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return lst;
        }

        /// <summary>
        /// Get role by code
        /// </summary>
        public RoleDTO LayRoleTheoMa(string maRole)
        {
            RoleDTO role = null;
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                string sql = "SELECT MaRole, TenRole, MoTa FROM Role WHERE MaRole = @MaRole";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaRole", maRole);
                SqlDataReader rd = cmd.ExecuteReader();
                
                if (rd.Read())
                {
                    role = new RoleDTO();
                    role.MaRole = rd["MaRole"].ToString();
                    role.TenRole = rd["TenRole"].ToString();
                    role.MoTa = rd["MoTa"].ToString();
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayRoleTheoMa: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return role;
        }
    }
}
