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
    public class TaiKhoanDAL : DBConnect
    {
        public List<TaiKhoanDTO> layDanhSachTaiKhoan()
        {
            List<TaiKhoanDTO> lst = new List<TaiKhoanDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM TaiKhoan";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                TaiKhoanDTO tk = new TaiKhoanDTO();
                tk.TenDangNhap = rd["TenDangNhap"].ToString();
                tk.MatKhau = rd["MatKhau"].ToString();
                tk.MaNV = rd["MaNV"].ToString();
                tk.MaRole = rd["MaRole"].ToString();
                // Try to read TrangThai if column exists, default to true if not
                try { tk.TrangThai = rd["TrangThai"] != DBNull.Value ? Convert.ToBoolean(rd["TrangThai"]) : true; }
                catch { tk.TrangThai = true; }
                lst.Add(tk);
            }
            con.Close();
            return lst;
        }

        public TaiKhoanDTO layTaiKhoanTheoTenDangNhap(string tenDangNhap)
        {
            TaiKhoanDTO tk = null;
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                tk = new TaiKhoanDTO();
                tk.TenDangNhap = rd["TenDangNhap"].ToString();
                tk.MatKhau = rd["MatKhau"].ToString();
                tk.MaNV = rd["MaNV"].ToString();
                tk.MaRole = rd["MaRole"].ToString();
                // Try to read TrangThai if column exists, default to true if not
                try { tk.TrangThai = rd["TrangThai"] != DBNull.Value ? Convert.ToBoolean(rd["TrangThai"]) : true; }
                catch { tk.TrangThai = true; }
            }
            con.Close();
            return tk;
        }

        public bool kiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", matKhau);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs > 0;
        }

        public bool themTaiKhoan(TaiKhoanDTO tk)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO TaiKhoan VALUES(@TenDangNhap, @MatKhau, @MaNV, @MaRole, @TrangThai)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
            cmd.Parameters.AddWithValue("@MaNV", tk.MaNV);
            cmd.Parameters.AddWithValue("@MaRole", tk.MaRole);
            cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool capNhatTaiKhoan(TaiKhoanDTO tk)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE TaiKhoan SET MatKhau = @MatKhau, MaNV = @MaNV, MaRole = @MaRole, TrangThai = @TrangThai WHERE TenDangNhap = @TenDangNhap";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
            cmd.Parameters.AddWithValue("@MaNV", tk.MaNV);
            cmd.Parameters.AddWithValue("@MaRole", tk.MaRole);
            cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool doiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE TaiKhoan SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaTaiKhoan(string tenDangNhap)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool kiemTraTrungTenDangNhap(string tenDangNhap)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs > 0;
        }

        /// <summary>
        /// Get user info with Role and NhanVien details for login
        /// </summary>
        public DataRow LayThongTinDangNhap(string tenDangNhap, string matKhau)
        {
            DataRow result = null;
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                
                // Removed TrangThai check for backward compatibility with existing database
                string sql = @"SELECT tk.TenDangNhap, tk.MaRole, r.TenRole, nv.MaNV, nv.TenNV, nv.ChucVu
                              FROM TaiKhoan tk
                              INNER JOIN Role r ON tk.MaRole = r.MaRole
                              INNER JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                              WHERE tk.TenDangNhap = @TenDangNhap AND tk.MatKhau = @MatKhau";
                
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                if (dt.Rows.Count > 0)
                    result = dt.Rows[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayThongTinDangNhap: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return result;
        }
    }
}
