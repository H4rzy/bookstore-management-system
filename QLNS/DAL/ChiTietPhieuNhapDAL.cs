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
    public class ChiTietPhieuNhapDAL : DBConnect
    {
        public List<ChiTietPhieuNhapDTO> layDanhSachChiTietTheoSoPN(string soPN)
        {
            List<ChiTietPhieuNhapDTO> lst = new List<ChiTietPhieuNhapDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM ChiTietPhieuNhap WHERE SoPN = @SoPN";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoPN", soPN);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ChiTietPhieuNhapDTO ct = new ChiTietPhieuNhapDTO();
                ct.SoPN = rd["SoPN"].ToString();
                ct.MaSach = rd["MaSach"].ToString();
                ct.SoLuong = (int)rd["SoLuong"];
                ct.DonGiaNhap = (decimal)rd["DonGiaNhap"];
                lst.Add(ct);
            }
            con.Close();
            return lst;
        }

        public bool themChiTietPhieuNhap(ChiTietPhieuNhapDTO ct)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO ChiTietPhieuNhap VALUES(@SoPN, @MaSach, @SoLuong, @DonGiaNhap)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoPN", ct.SoPN);
            cmd.Parameters.AddWithValue("@MaSach", ct.MaSach);
            cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
            cmd.Parameters.AddWithValue("@DonGiaNhap", ct.DonGiaNhap);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaChiTietPhieuNhap(string soPN, string maSach)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM ChiTietPhieuNhap WHERE SoPN = @SoPN AND MaSach = @MaSach";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoPN", soPN);
            cmd.Parameters.AddWithValue("@MaSach", maSach);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public decimal tinhTongTienPhieuNhap(string soPN)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT SUM(SoLuong * DonGiaNhap) FROM ChiTietPhieuNhap WHERE SoPN = @SoPN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoPN", soPN);
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (decimal)result : 0;
            }
        }
    }
}
