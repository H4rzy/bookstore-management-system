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
    public class PhieuNhapDAL : DBConnect
    {
        public List<PhieuNhapDTO> layDanhSachPhieuNhap()
        {
            List<PhieuNhapDTO> lst = new List<PhieuNhapDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM PhieuNhap ORDER BY NgayNhap DESC";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                PhieuNhapDTO pn = new PhieuNhapDTO();
                pn.SoPN = rd["SoPN"].ToString();
                pn.NgayNhap = (DateTime)rd["NgayNhap"];
                pn.MaNV = rd["MaNV"].ToString();
                pn.GhiChu = rd["GhiChu"].ToString();
                lst.Add(pn);
            }
            con.Close();
            return lst;
        }

        public PhieuNhapDTO layPhieuNhapTheoSo(string soPN)
        {
            PhieuNhapDTO pn = null;
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM PhieuNhap WHERE SoPN = @SoPN";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoPN", soPN);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                pn = new PhieuNhapDTO();
                pn.SoPN = rd["SoPN"].ToString();
                pn.NgayNhap = (DateTime)rd["NgayNhap"];
                pn.MaNV = rd["MaNV"].ToString();
                pn.GhiChu = rd["GhiChu"].ToString();
            }
            con.Close();
            return pn;
        }

        public bool themPhieuNhap(PhieuNhapDTO pn)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO PhieuNhap VALUES(@SoPN, @NgayNhap, @MaNV, @GhiChu)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoPN", pn.SoPN);
            cmd.Parameters.AddWithValue("@NgayNhap", pn.NgayNhap);
            cmd.Parameters.AddWithValue("@MaNV", pn.MaNV);
            cmd.Parameters.AddWithValue("@GhiChu", pn.GhiChu);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool capNhatPhieuNhap(PhieuNhapDTO pn)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE PhieuNhap SET NgayNhap = @NgayNhap, MaNV = @MaNV, GhiChu = @GhiChu WHERE SoPN = @SoPN";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoPN", pn.SoPN);
            cmd.Parameters.AddWithValue("@NgayNhap", pn.NgayNhap);
            cmd.Parameters.AddWithValue("@MaNV", pn.MaNV);
            cmd.Parameters.AddWithValue("@GhiChu", pn.GhiChu);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaPhieuNhap(string soPN)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM PhieuNhap WHERE SoPN = @SoPN";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoPN", soPN);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool kiemTraTrungSo(string soPN)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT COUNT(*) FROM PhieuNhap WHERE SoPN = @SoPN";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SoPN", soPN);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs > 0;
        }

        public List<PhieuNhapDTO> layPhieuNhapTheoNhanVien(string maNV)
        {
            List<PhieuNhapDTO> lst = new List<PhieuNhapDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM PhieuNhap WHERE MaNV = @MaNV ORDER BY NgayNhap DESC";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                PhieuNhapDTO pn = new PhieuNhapDTO();
                pn.SoPN = rd["SoPN"].ToString();
                pn.NgayNhap = (DateTime)rd["NgayNhap"];
                pn.MaNV = rd["MaNV"].ToString();
                pn.GhiChu = rd["GhiChu"].ToString();
                lst.Add(pn);
            }
            con.Close();
            return lst;
        }

        public DataTable timKiemPhieuNhapTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM PhieuNhap WHERE NgayNhap BETWEEN @TuNgay AND @DenNgay ORDER BY NgayNhap DESC";
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
