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
    public class TheLoaiDAL : DBConnect
    {
        public List<TheLoaiDTO> layDanhSachTheLoai()
        {
            List<TheLoaiDTO> lst = new List<TheLoaiDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM TheLoai ORDER BY TenTheLoai ASC";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                TheLoaiDTO tl = new TheLoaiDTO();
                tl.MaTheLoai = rd["MaTheLoai"].ToString();
                tl.TenTheLoai = rd["TenTheLoai"].ToString();
                lst.Add(tl);
            }
            con.Close();
            return lst;
        }

        public TheLoaiDTO layTheLoaiTheoMa(string maTheLoai)
        {
            TheLoaiDTO tl = null;
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM TheLoai WHERE MaTheLoai = @MaTheLoai";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                tl = new TheLoaiDTO();
                tl.MaTheLoai = rd["MaTheLoai"].ToString();
                tl.TenTheLoai = rd["TenTheLoai"].ToString();
            }
            con.Close();
            return tl;
        }

        public bool themTheLoai(TheLoaiDTO tl)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO TheLoai VALUES(@MaTheLoai, @TenTheLoai)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaTheLoai", tl.MaTheLoai);
            cmd.Parameters.AddWithValue("@TenTheLoai", tl.TenTheLoai);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool capNhatTheLoai(TheLoaiDTO tl)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE TheLoai SET TenTheLoai = @TenTheLoai WHERE MaTheLoai = @MaTheLoai";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaTheLoai", tl.MaTheLoai);
            cmd.Parameters.AddWithValue("@TenTheLoai", tl.TenTheLoai);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaTheLoai(string maTheLoai)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM TheLoai WHERE MaTheLoai = @MaTheLoai";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public DataTable timKiemTheLoaiTheoTen(string tenTheLoai)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM TheLoai WHERE TenTheLoai LIKE @TenTheLoai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenTheLoai", "%" + tenTheLoai + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool kiemTraTrungMa(string maTheLoai)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT COUNT(*) FROM TheLoai WHERE MaTheLoai = @MaTheLoai";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs > 0;
        }
    }
}
