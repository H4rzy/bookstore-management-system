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
    public class NhanVienDAL : DBConnect
    {
        public List<NhanVienDTO> layDanhSachNhanVien()
        {
            List<NhanVienDTO> lst = new List<NhanVienDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM NhanVien ORDER BY TenNV ASC";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = rd["MaNV"].ToString();
                nv.TenNV = rd["TenNV"].ToString();
                nv.GioiTinh = rd["GioiTinh"] != DBNull.Value && (bool)rd["GioiTinh"];
                nv.DienThoai = rd["DienThoai"].ToString();
                nv.DiaChi = rd["DiaChi"].ToString();
                nv.ChucVu = rd["ChucVu"].ToString();
                lst.Add(nv);
            }
            con.Close();
            return lst;
        }

        public NhanVienDTO layNhanVienTheoMa(string maNV)
        {
            NhanVienDTO nv = null;
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                nv = new NhanVienDTO();
                nv.MaNV = rd["MaNV"].ToString();
                nv.TenNV = rd["TenNV"].ToString();
                nv.GioiTinh = rd["GioiTinh"] != DBNull.Value && (bool)rd["GioiTinh"];
                nv.DienThoai = rd["DienThoai"].ToString();
                nv.DiaChi = rd["DiaChi"].ToString();
                nv.ChucVu = rd["ChucVu"].ToString();
            }
            con.Close();
            return nv;
        }

        public bool themNhanVien(NhanVienDTO nv)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "INSERT INTO NhanVien VALUES(@MaNV, @TenNV, @GioiTinh, @DienThoai, @DiaChi, @ChucVu)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
            cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
            cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool capNhatNhanVien(NhanVienDTO nv)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "UPDATE NhanVien SET TenNV = @TenNV, GioiTinh = @GioiTinh, DienThoai = @DienThoai, DiaChi = @DiaChi, ChucVu = @ChucVu WHERE MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
            cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
            cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool xoaNhanVien(string maNV)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public bool kiemTraTrungMa(string maNV)
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs > 0;
        }

        public List<NhanVienDTO> layNhanVienTheoChucVu(string chucVu)
        {
            List<NhanVienDTO> lst = new List<NhanVienDTO>();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string sql = "SELECT * FROM NhanVien WHERE ChucVu = @ChucVu ORDER BY TenNV ASC";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ChucVu", chucVu);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = rd["MaNV"].ToString();
                nv.TenNV = rd["TenNV"].ToString();
                nv.GioiTinh = rd["GioiTinh"] != DBNull.Value && (bool)rd["GioiTinh"];
                nv.DienThoai = rd["DienThoai"].ToString();
                nv.DiaChi = rd["DiaChi"].ToString();
                nv.ChucVu = rd["ChucVu"].ToString();
                lst.Add(nv);
            }
            con.Close();
            return lst;
        }

        public DataTable timKiemNhanVienTheoTen(string tenNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM NhanVien WHERE TenNV LIKE @TenNV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenNV", "%" + tenNV + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
