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
    public class SachDAL : DBConnect
    {
        public List<SachDTO> layDanhSachSach()
        {
            List<SachDTO> lst = new List<SachDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM Sach WHERE SoLuongTon > 0";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SachDTO sach = new SachDTO();
                sach.MaSach = rd["MaSach"].ToString();
                sach.TenSach = rd["TenSach"].ToString();
                sach.MaTheLoai = rd["MaTheLoai"].ToString();
                sach.MaNXB = rd["MaNXB"].ToString();
                sach.TacGia = rd["TacGia"].ToString();
                sach.DonGiaNhap = (decimal)rd["DonGiaNhap"];
                sach.DonGiaBan = (decimal)rd["DonGiaBan"];
                sach.SoLuongTon = (int)rd["SoLuongTon"];
                lst.Add(sach);
            }
            con.Close();
            return lst;
        }

        public List<SachDTO> layTatCaSach()
        {
            List<SachDTO> lst = new List<SachDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM Sach";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SachDTO sach = new SachDTO();
                sach.MaSach = rd["MaSach"].ToString();
                sach.TenSach = rd["TenSach"].ToString();
                sach.MaTheLoai = rd["MaTheLoai"].ToString();
                sach.MaNXB = rd["MaNXB"].ToString();
                sach.TacGia = rd["TacGia"].ToString();
                sach.DonGiaNhap = (decimal)rd["DonGiaNhap"];
                sach.DonGiaBan = (decimal)rd["DonGiaBan"];
                sach.SoLuongTon = (int)rd["SoLuongTon"];
                lst.Add(sach);
            }
            con.Close();
            return lst;
        }

        public SachDTO laySachTheoMa(string maSach)
        {
            SachDTO sach = null;
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM Sach WHERE MaSach = @MaSach";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaSach", maSach);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                sach = new SachDTO();
                sach.MaSach = rd["MaSach"].ToString();
                sach.TenSach = rd["TenSach"].ToString();
                sach.MaTheLoai = rd["MaTheLoai"].ToString();
                sach.MaNXB = rd["MaNXB"].ToString();
                sach.TacGia = rd["TacGia"].ToString();
                sach.DonGiaNhap = (decimal)rd["DonGiaNhap"];
                sach.DonGiaBan = (decimal)rd["DonGiaBan"];
                sach.SoLuongTon = (int)rd["SoLuongTon"];
            }
            con.Close();
            return sach;
        }

        public bool themSach(SachDTO sach)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO Sach VALUES(@MaSach, @TenSach, @MaTheLoai, @MaNXB, @TacGia, @DonGiaNhap, @DonGiaBan, @SoLuongTon)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaSach", sach.MaSach);
            cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
            cmd.Parameters.AddWithValue("@MaTheLoai", sach.MaTheLoai);
            cmd.Parameters.AddWithValue("@MaNXB", sach.MaNXB);
            cmd.Parameters.AddWithValue("@TacGia", sach.TacGia);
            cmd.Parameters.AddWithValue("@DonGiaNhap", sach.DonGiaNhap);
            cmd.Parameters.AddWithValue("@DonGiaBan", sach.DonGiaBan);
            cmd.Parameters.AddWithValue("@SoLuongTon", sach.SoLuongTon);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool capNhatSach(SachDTO sach)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE Sach SET TenSach = @TenSach, MaTheLoai = @MaTheLoai, MaNXB = @MaNXB, TacGia = @TacGia, " +
                         "DonGiaNhap = @DonGiaNhap, DonGiaBan = @DonGiaBan, SoLuongTon = @SoLuongTon WHERE MaSach = @MaSach";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaSach", sach.MaSach);
            cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
            cmd.Parameters.AddWithValue("@MaTheLoai", sach.MaTheLoai);
            cmd.Parameters.AddWithValue("@MaNXB", sach.MaNXB);
            cmd.Parameters.AddWithValue("@TacGia", sach.TacGia);
            cmd.Parameters.AddWithValue("@DonGiaNhap", sach.DonGiaNhap);
            cmd.Parameters.AddWithValue("@DonGiaBan", sach.DonGiaBan);
            cmd.Parameters.AddWithValue("@SoLuongTon", sach.SoLuongTon);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaSach(string maSach)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM Sach WHERE MaSach = @MaSach";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaSach", maSach);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool kiemTraTrungMa(string maSach)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT COUNT(*) FROM Sach WHERE MaSach = @MaSach";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaSach", maSach);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs > 0;
        }

        public DataTable timKiemSachTheoTen(string tenSach)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Sach WHERE TenSach LIKE @TenSach";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenSach", "%" + tenSach + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public List<SachDTO> laySachTheoTheLoai(string maTheLoai)
        {
            List<SachDTO> lst = new List<SachDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM Sach WHERE MaTheLoai = @MaTheLoai";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SachDTO sach = new SachDTO();
                sach.MaSach = rd["MaSach"].ToString();
                sach.TenSach = rd["TenSach"].ToString();
                sach.MaTheLoai = rd["MaTheLoai"].ToString();
                sach.MaNXB = rd["MaNXB"].ToString();
                sach.TacGia = rd["TacGia"].ToString();
                sach.DonGiaNhap = (decimal)rd["DonGiaNhap"];
                sach.DonGiaBan = (decimal)rd["DonGiaBan"];
                sach.SoLuongTon = (int)rd["SoLuongTon"];
                lst.Add(sach);
            }
            con.Close();
            return lst;
        }

        public List<SachDTO> laySachTheoNXB(string maNXB)
        {
            List<SachDTO> lst = new List<SachDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM Sach WHERE MaNXB = @MaNXB";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNXB", maNXB);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SachDTO sach = new SachDTO();
                sach.MaSach = rd["MaSach"].ToString();
                sach.TenSach = rd["TenSach"].ToString();
                sach.MaTheLoai = rd["MaTheLoai"].ToString();
                sach.MaNXB = rd["MaNXB"].ToString();
                sach.TacGia = rd["TacGia"].ToString();
                sach.DonGiaNhap = (decimal)rd["DonGiaNhap"];
                sach.DonGiaBan = (decimal)rd["DonGiaBan"];
                sach.SoLuongTon = (int)rd["SoLuongTon"];
                lst.Add(sach);
            }
            con.Close();
            return lst;
        }

        public bool capNhatSoLuongTon(string maSach, int soLuong)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE Sach SET SoLuongTon = @SoLuong WHERE MaSach = @MaSach";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaSach", maSach);
            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public int laySoLuongTon(string maSach)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT SoLuongTon FROM Sach WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                int rs = (int)cmd.ExecuteScalar();
                return rs;
            }
        }
    }
}
