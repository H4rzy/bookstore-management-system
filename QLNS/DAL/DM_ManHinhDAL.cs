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
    public class DM_ManHinhDAL : DBConnect
    {
        /// <summary>
        /// Get all screens/features
        /// </summary>
        public List<DM_ManHinhDTO> LayDanhSachManHinh()
        {
            List<DM_ManHinhDTO> lst = new List<DM_ManHinhDTO>();
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                string sql = "SELECT MaManHinh, TenManHinh, LoaiChucNang FROM DM_ManHinh ORDER BY LoaiChucNang, TenManHinh";
                SqlCommand cmd = new SqlCommand(sql, con);
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
                throw new Exception("Error in LayDanhSachManHinh: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return lst;
        }

        /// <summary>
        /// Get screen by code
        /// </summary>
        public DM_ManHinhDTO LayManHinhTheoMa(string maManHinh)
        {
            DM_ManHinhDTO mh = null;
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                string sql = "SELECT MaManHinh, TenManHinh, LoaiChucNang FROM DM_ManHinh WHERE MaManHinh = @MaManHinh";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaManHinh", maManHinh);
                SqlDataReader rd = cmd.ExecuteReader();
                
                if (rd.Read())
                {
                    mh = new DM_ManHinhDTO();
                    mh.MaManHinh = rd["MaManHinh"].ToString();
                    mh.TenManHinh = rd["TenManHinh"].ToString();
                    mh.LoaiChucNang = rd["LoaiChucNang"].ToString();
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayManHinhTheoMa: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return mh;
        }
    }
}
