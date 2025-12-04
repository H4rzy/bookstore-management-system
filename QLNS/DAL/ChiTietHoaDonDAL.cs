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
    public class ChiTietHoaDonDAL : DBConnect
    {
        public List<ChiTietHoaDonDTO> layDanhSachChiTietTheoSoHD(string soHD)
        {
            List<ChiTietHoaDonDTO> lst = new List<ChiTietHoaDonDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM ChiTietHoaDon WHERE SoHD = @SoHD";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoHD", soHD);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ChiTietHoaDonDTO ct = new ChiTietHoaDonDTO();
                ct.SoHD = rd["SoHD"].ToString();
                ct.MaSach = rd["MaSach"].ToString();
                ct.SoLuong = (int)rd["SoLuong"];
                ct.DonGiaBan = (decimal)rd["DonGiaBan"];
                lst.Add(ct);
            }
            con.Close();
            return lst;
        }

        public bool themChiTietHoaDon(ChiTietHoaDonDTO ct)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO ChiTietHoaDon VALUES(@SoHD, @MaSach, @SoLuong, @DonGiaBan)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoHD", ct.SoHD);
            cmd.Parameters.AddWithValue("@MaSach", ct.MaSach);
            cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
            cmd.Parameters.AddWithValue("@DonGiaBan", ct.DonGiaBan);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaChiTietHoaDon(string soHD, string maSach)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM ChiTietHoaDon WHERE SoHD = @SoHD AND MaSach = @MaSach";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoHD", soHD);
            cmd.Parameters.AddWithValue("@MaSach", maSach);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public decimal tinhTongTienHoaDon(string soHD)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT SUM(SoLuong * DonGiaBan) FROM ChiTietHoaDon WHERE SoHD = @SoHD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoHD", soHD);
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (decimal)result : 0;
            }
        }
        public DataTable laySachBanChay(int top)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT TOP (@Top) s.MaSach, s.TenSach, SUM(ct.SoLuong) AS TongSoLuongBan, 
                               SUM(ct.SoLuong * ct.DonGiaBan) AS TongDoanhThu
                               FROM ChiTietHoaDon ct
                               INNER JOIN Sach s ON ct.MaSach = s.MaSach
                               GROUP BY s.MaSach, s.TenSach
                               ORDER BY TongSoLuongBan DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Top", top);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
