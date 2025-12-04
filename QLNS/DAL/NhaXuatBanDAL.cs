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
    public class NhaXuatBanDAL : DBConnect
    {
        public List<NhaXuatBanDTO> layDanhSachNhaXuatBan()
        {
            List<NhaXuatBanDTO> lst = new List<NhaXuatBanDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM NhaXuatBan ORDER BY TenNXB ASC";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                NhaXuatBanDTO nxb = new NhaXuatBanDTO();
                nxb.MaNXB = rd["MaNXB"].ToString();
                nxb.TenNXB = rd["TenNXB"].ToString();
                nxb.DiaChi = rd["DiaChi"].ToString();
                nxb.DienThoai = rd["DienThoai"].ToString();
                lst.Add(nxb);
            }
            con.Close();
            return lst;
        }

        public NhaXuatBanDTO layNhaXuatBanTheoMa(string maNXB)
        {
            NhaXuatBanDTO nxb = null;
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM NhaXuatBan WHERE MaNXB = @MaNXB";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNXB", maNXB);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                nxb = new NhaXuatBanDTO();
                nxb.MaNXB = rd["MaNXB"].ToString();
                nxb.TenNXB = rd["TenNXB"].ToString();
                nxb.DiaChi = rd["DiaChi"].ToString();
                nxb.DienThoai = rd["DienThoai"].ToString();
            }
            con.Close();
            return nxb;
        }

        public bool themNhaXuatBan(NhaXuatBanDTO nxb)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO NhaXuatBan VALUES(@MaNXB, @TenNXB, @DiaChi, @DienThoai)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNXB", nxb.MaNXB);
            cmd.Parameters.AddWithValue("@TenNXB", nxb.TenNXB);
            cmd.Parameters.AddWithValue("@DiaChi", nxb.DiaChi);
            cmd.Parameters.AddWithValue("@DienThoai", nxb.DienThoai);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool capNhatNhaXuatBan(NhaXuatBanDTO nxb)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE NhaXuatBan SET TenNXB = @TenNXB, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaNXB = @MaNXB";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNXB", nxb.MaNXB);
            cmd.Parameters.AddWithValue("@TenNXB", nxb.TenNXB);
            cmd.Parameters.AddWithValue("@DiaChi", nxb.DiaChi);
            cmd.Parameters.AddWithValue("@DienThoai", nxb.DienThoai);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaNhaXuatBan(string maNXB)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM NhaXuatBan WHERE MaNXB = @MaNXB";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNXB", maNXB);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public DataTable timKiemNhaXuatBanTheoTen(string tenNXB)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM NhaXuatBan WHERE TenNXB LIKE @TenNXB";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenNXB", "%" + tenNXB + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool kiemTraTrungMa(string maNXB)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT COUNT(*) FROM NhaXuatBan WHERE MaNXB = @MaNXB";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNXB", maNXB);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs > 0;
        }
    }
}
