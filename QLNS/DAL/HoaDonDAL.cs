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
    public class HoaDonDAL : DBConnect
    {
        public List<HoaDonDTO> layDanhSachHoaDon()
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM HoaDon ORDER BY NgayBan DESC";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                HoaDonDTO hd = new HoaDonDTO();
                hd.SoHD = rd["SoHD"].ToString();
                hd.NgayBan = (DateTime)rd["NgayBan"];
                hd.MaNV = rd["MaNV"].ToString();
                hd.MaKH = rd["MaKH"] != DBNull.Value ? rd["MaKH"].ToString() : null;
                hd.GhiChu = rd["GhiChu"].ToString();
                lst.Add(hd);
            }
            con.Close();
            return lst;
        }

        public HoaDonDTO layHoaDonTheoSo(string soHD)
        {
            HoaDonDTO hd = null;
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM HoaDon WHERE SoHD = @SoHD";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoHD", soHD);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                hd = new HoaDonDTO();
                hd.SoHD = rd["SoHD"].ToString();
                hd.NgayBan = (DateTime)rd["NgayBan"];
                hd.MaNV = rd["MaNV"].ToString();
                hd.MaKH = rd["MaKH"] != DBNull.Value ? rd["MaKH"].ToString() : null;
                hd.GhiChu = rd["GhiChu"].ToString();
            }
            con.Close();
            return hd;
        }

        public bool themHoaDon(HoaDonDTO hd)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO HoaDon VALUES(@SoHD, @NgayBan, @MaNV, @MaKH, @GhiChu)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoHD", hd.SoHD);
            cmd.Parameters.AddWithValue("@NgayBan", hd.NgayBan);
            cmd.Parameters.AddWithValue("@MaNV", hd.MaNV);
            cmd.Parameters.AddWithValue("@MaKH", (object)hd.MaKH ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@GhiChu", hd.GhiChu);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaHoaDon(string soHD)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM HoaDon WHERE SoHD = @SoHD";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoHD", soHD);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool kiemTraTrungSo(string soHD)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT COUNT(*) FROM HoaDon WHERE SoHD = @SoHD";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoHD", soHD);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs > 0;
        }

        public List<HoaDonDTO> layHoaDonTheoKhachHang(string maKH)
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM HoaDon WHERE MaKH = @MaKH ORDER BY NgayBan DESC";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaKH", maKH);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                HoaDonDTO hd = new HoaDonDTO();
                hd.SoHD = rd["SoHD"].ToString();
                hd.NgayBan = (DateTime)rd["NgayBan"];
                hd.MaNV = rd["MaNV"].ToString();
                hd.MaKH = rd["MaKH"] != DBNull.Value ? rd["MaKH"].ToString() : null;
                hd.GhiChu = rd["GhiChu"].ToString();
                lst.Add(hd);
            }
            con.Close();
            return lst;
        }

        public List<HoaDonDTO> layHoaDonTheoNhanVien(string maNV)
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM HoaDon WHERE MaNV = @MaNV ORDER BY NgayBan DESC";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                HoaDonDTO hd = new HoaDonDTO();
                hd.SoHD = rd["SoHD"].ToString();
                hd.NgayBan = (DateTime)rd["NgayBan"];
                hd.MaNV = rd["MaNV"].ToString();
                hd.MaKH = rd["MaKH"] != DBNull.Value ? rd["MaKH"].ToString() : null;
                hd.GhiChu = rd["GhiChu"].ToString();
                lst.Add(hd);
            }
            con.Close();
            return lst;
        }

        public DataTable timKiemHoaDonTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM HoaDon WHERE NgayBan BETWEEN @TuNgay AND @DenNgay ORDER BY NgayBan DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
