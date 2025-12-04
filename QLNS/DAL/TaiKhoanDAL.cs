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
                tk.Quyen = rd["Quyen"].ToString();
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
                tk.Quyen = rd["Quyen"].ToString();
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
            string sql = "INSERT INTO TaiKhoan VALUES(@TenDangNhap, @MatKhau, @MaNV, @Quyen)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
            cmd.Parameters.AddWithValue("@MaNV", tk.MaNV);
            cmd.Parameters.AddWithValue("@Quyen", tk.Quyen);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool capNhatTaiKhoan(TaiKhoanDTO tk)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE TaiKhoan SET MatKhau = @MatKhau, MaNV = @MaNV, Quyen = @Quyen WHERE TenDangNhap = @TenDangNhap";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
            cmd.Parameters.AddWithValue("@MaNV", tk.MaNV);
            cmd.Parameters.AddWithValue("@Quyen", tk.Quyen);
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
    }
}
