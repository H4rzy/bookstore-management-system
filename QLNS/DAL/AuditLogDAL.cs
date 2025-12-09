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
    public class AuditLogDAL : DBConnect
    {
        /// <summary>
        /// Insert audit log entry
        /// </summary>
        public bool ThemLogHoatDong(AuditLogDTO log)
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                string sql = @"INSERT INTO AuditLog (MaLog, TenDangNhap, HanhDong, ThoiGian, ChiTiet)
                              VALUES (@MaLog, @TenDangNhap, @HanhDong, @ThoiGian, @ChiTiet)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaLog", log.MaLog);
                cmd.Parameters.AddWithValue("@TenDangNhap", log.TenDangNhap);
                cmd.Parameters.AddWithValue("@HanhDong", log.HanhDong);
                cmd.Parameters.AddWithValue("@ThoiGian", log.ThoiGian);
                cmd.Parameters.AddWithValue("@ChiTiet", log.ChiTiet ?? "");
                
                int rs = cmd.ExecuteNonQuery();
                return rs > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ThemLogHoatDong: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        /// <summary>
        /// Get activity history for a user
        /// </summary>
        public List<AuditLogDTO> LayLichSuHoatDong(string tenDangNhap, DateTime? fromDate = null, DateTime? toDate = null)
        {
            List<AuditLogDTO> lst = new List<AuditLogDTO>();
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT MaLog, TenDangNhap, HanhDong, ThoiGian, ChiTiet FROM AuditLog WHERE 1=1");
                
                if (!string.IsNullOrEmpty(tenDangNhap))
                    sql.Append(" AND TenDangNhap = @TenDangNhap");
                
                if (fromDate.HasValue)
                    sql.Append(" AND ThoiGian >= @FromDate");
                
                if (toDate.HasValue)
                    sql.Append(" AND ThoiGian <= @ToDate");
                
                sql.Append(" ORDER BY ThoiGian DESC");
                
                SqlCommand cmd = new SqlCommand(sql.ToString(), con);
                
                if (!string.IsNullOrEmpty(tenDangNhap))
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                
                if (fromDate.HasValue)
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Value);
                
                if (toDate.HasValue)
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Value);
                
                SqlDataReader rd = cmd.ExecuteReader();
                
                while (rd.Read())
                {
                    AuditLogDTO log = new AuditLogDTO();
                    log.MaLog = rd["MaLog"].ToString();
                    log.TenDangNhap = rd["TenDangNhap"].ToString();
                    log.HanhDong = rd["HanhDong"].ToString();
                    log.ThoiGian = Convert.ToDateTime(rd["ThoiGian"]);
                    log.ChiTiet = rd["ChiTiet"].ToString();
                    lst.Add(log);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayLichSuHoatDong: " + ex.Message);
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
