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
    public class KhachHangDAL : DBConnect
    {
        public List<KhachHangDTO> layDanhSachKhachHang()
        {
            List<KhachHangDTO> lst = new List<KhachHangDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM KhachHang ORDER BY TenKH ASC";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.MaKH = rd["MaKH"].ToString();
                kh.TenKH = rd["TenKH"].ToString();
                kh.DienThoai = rd["DienThoai"].ToString();
                kh.DiaChi = rd["DiaChi"].ToString();
                kh.LoaiKH = rd["LoaiKH"].ToString();
                lst.Add(kh);
            }
            con.Close();
            return lst;
        }

        public KhachHangDTO layKhachHangTheoMa(string maKH)
        {
            KhachHangDTO kh = null;
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM KhachHang WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaKH", maKH);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                kh = new KhachHangDTO();
                kh.MaKH = rd["MaKH"].ToString();
                kh.TenKH = rd["TenKH"].ToString();
                kh.DienThoai = rd["DienThoai"].ToString();
                kh.DiaChi = rd["DiaChi"].ToString();
                kh.LoaiKH = rd["LoaiKH"].ToString();
            }
            con.Close();
            return kh;
        }

        public bool themKhachHang(KhachHangDTO kh)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO KhachHang VALUES(@MaKH, @TenKH, @DienThoai, @DiaChi, @LoaiKH)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
            cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
            cmd.Parameters.AddWithValue("@DienThoai", kh.DienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
            cmd.Parameters.AddWithValue("@LoaiKH", kh.LoaiKH);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool capNhatKhachHang(KhachHangDTO kh)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE KhachHang SET TenKH = @TenKH, DienThoai = @DienThoai, DiaChi = @DiaChi, LoaiKH = @LoaiKH WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
            cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
            cmd.Parameters.AddWithValue("@DienThoai", kh.DienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
            cmd.Parameters.AddWithValue("@LoaiKH", kh.LoaiKH);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaKhachHang(string maKH)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaKH", maKH);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool kiemTraTrungMa(string maKH)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaKH", maKH);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs > 0;
        }

        public List<KhachHangDTO> layKhachHangTheoLoai(string loaiKH)
        {
            List<KhachHangDTO> lst = new List<KhachHangDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM KhachHang WHERE LoaiKH = @LoaiKH ORDER BY TenKH ASC";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@LoaiKH", loaiKH);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.MaKH = rd["MaKH"].ToString();
                kh.TenKH = rd["TenKH"].ToString();
                kh.DienThoai = rd["DienThoai"].ToString();
                kh.DiaChi = rd["DiaChi"].ToString();
                kh.LoaiKH = rd["LoaiKH"].ToString();
                lst.Add(kh);
            }
            con.Close();
            return lst;
        }

        public DataTable timKiemKhachHangTheoTen(string tenKH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM KhachHang WHERE TenKH LIKE @TenKH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenKH", "%" + tenKH + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
