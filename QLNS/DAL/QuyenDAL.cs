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
    public class QuyenDAL : DBConnect
    {
        /// <summary>
        /// Get all permissions for a specific role
        /// </summary>
        public List<QuyenDTO> LayQuyenTheoRole(string maRole)
        {
            List<QuyenDTO> lst = new List<QuyenDTO>();
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                string sql = "SELECT MaRole, MaManHinh, CoQuyen FROM Quyen WHERE MaRole = @MaRole";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaRole", maRole);
                SqlDataReader rd = cmd.ExecuteReader();
                
                while (rd.Read())
                {
                    QuyenDTO q = new QuyenDTO();
                    q.MaRole = rd["MaRole"].ToString();
                    q.MaManHinh = rd["MaManHinh"].ToString();
                    q.CoQuyen = Convert.ToBoolean(rd["CoQuyen"]);
                    lst.Add(q);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayQuyenTheoRole: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return lst;
        }

        /// <summary>
        /// Get user permissions (via their account's role)
        /// Returns list of permitted screen codes (MaManHinh)
        /// </summary>
        public List<string> LayQuyenTheoUser(string tenDangNhap)
        {
            List<string> lst = new List<string>();
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                string sql = @"SELECT q.MaManHinh 
                              FROM Quyen q
                              INNER JOIN TaiKhoan tk ON q.MaRole = tk.MaRole
                              WHERE tk.TenDangNhap = @TenDangNhap AND q.CoQuyen = 1";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                SqlDataReader rd = cmd.ExecuteReader();
                
                while (rd.Read())
                {
                    lst.Add(rd["MaManHinh"].ToString());
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayQuyenTheoUser: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return lst;
        }

        /// <summary>
        /// Check if a role has permission to access a specific screen
        /// </summary>
        public bool KiemTraQuyen(string maRole, string maManHinh)
        {
            bool result = false;
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                string sql = "SELECT COUNT(*) FROM Quyen WHERE MaRole = @MaRole AND MaManHinh = @MaManHinh AND CoQuyen = 1";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaRole", maRole);
                cmd.Parameters.AddWithValue("@MaManHinh", maManHinh);
                
                int count = (int)cmd.ExecuteScalar();
                result = count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in KiemTraQuyen: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return result;
        }

        /// <summary>
        /// Get screens with permissions for a specific role (for menu building)
        /// </summary>
        public List<DM_ManHinhDTO> LayManHinhTheoQuyen(string maRole)
        {
            List<DM_ManHinhDTO> lst = new List<DM_ManHinhDTO>();
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                string sql = @"SELECT dm.MaManHinh, dm.TenManHinh, dm.LoaiChucNang
                              FROM Quyen q
                              INNER JOIN DM_ManHinh dm ON q.MaManHinh = dm.MaManHinh
                              WHERE q.MaRole = @MaRole AND q.CoQuyen = 1
                              ORDER BY dm.LoaiChucNang, dm.TenManHinh";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaRole", maRole);
                SqlDataReader rd = cmd.ExecuteReader();
                
                while (rd.Read())
                {
                    DM_ManHinhDTO mh = new DM_ManHinhDTO();
                    mh.MaManHinh = rd["MaManHinh"].ToString();
                    mh.TenManHinh = rd["TenManHinh"].ToString();
                    mh.LoaiChucNang = rd["LoaiChucNang"].ToString();
                    lst.Add(mh);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayManHinhTheoQuyen: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return lst;
        }
    }
}
