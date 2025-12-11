using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLNS_DTO;

namespace QLNS_DAL
{
    public class TheVIPDAL : DBConnect
    {
        /// <summary>
        /// Get all VIP cards
        /// </summary>
        public List<TheVIPDTO> LayDanhSachTheVIP()
        {
            List<TheVIPDTO> lst = new List<TheVIPDTO>();
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = "SELECT * FROM TheVIP ORDER BY NgayCapPhat DESC";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lst.Add(new TheVIPDTO
                    {
                        MaTheVIP = rd["MaTheVIP"].ToString().Trim(),
                        MaKH = rd["MaKH"].ToString().Trim(),
                        NgayCapPhat = Convert.ToDateTime(rd["NgayCapPhat"]),
                        NgayHetHan = Convert.ToDateTime(rd["NgayHetHan"]),
                        DiemTichLuy = Convert.ToInt32(rd["DiemTichLuy"]),
                        ChiTieu = Convert.ToDecimal(rd["ChiTieu"]),
                        TrangThai = Convert.ToBoolean(rd["TrangThai"])
                    });
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayDanhSachTheVIP: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return lst;
        }

        /// <summary>
        /// Get VIP card by customer ID
        /// </summary>
        public TheVIPDTO LayTheVIPTheoKhachHang(string maKH)
        {
            TheVIPDTO vip = null;
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = "SELECT * FROM TheVIP WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    vip = new TheVIPDTO
                    {
                        MaTheVIP = rd["MaTheVIP"].ToString().Trim(),
                        MaKH = rd["MaKH"].ToString().Trim(),
                        NgayCapPhat = Convert.ToDateTime(rd["NgayCapPhat"]),
                        NgayHetHan = Convert.ToDateTime(rd["NgayHetHan"]),
                        DiemTichLuy = Convert.ToInt32(rd["DiemTichLuy"]),
                        ChiTieu = Convert.ToDecimal(rd["ChiTieu"]),
                        TrangThai = Convert.ToBoolean(rd["TrangThai"])
                    };
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LayTheVIPTheoKhachHang: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return vip;
        }

        /// <summary>
        /// Add new VIP card
        /// </summary>
        public bool ThemTheVIP(TheVIPDTO vip)
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = @"INSERT INTO TheVIP (MaTheVIP, MaKH, NgayCapPhat, NgayHetHan, DiemTichLuy, ChiTieu, TrangThai)
                              VALUES (@MaTheVIP, @MaKH, @NgayCapPhat, @NgayHetHan, @DiemTichLuy, @ChiTieu, @TrangThai)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaTheVIP", vip.MaTheVIP);
                cmd.Parameters.AddWithValue("@MaKH", vip.MaKH);
                cmd.Parameters.AddWithValue("@NgayCapPhat", vip.NgayCapPhat);
                cmd.Parameters.AddWithValue("@NgayHetHan", vip.NgayHetHan);
                cmd.Parameters.AddWithValue("@DiemTichLuy", vip.DiemTichLuy);
                cmd.Parameters.AddWithValue("@ChiTieu", vip.ChiTieu);
                cmd.Parameters.AddWithValue("@TrangThai", vip.TrangThai);

                int rs = cmd.ExecuteNonQuery();
                return rs > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ThemTheVIP: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        /// <summary>
        /// Update VIP card
        /// </summary>
        public bool CapNhatTheVIP(TheVIPDTO vip)
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = @"UPDATE TheVIP 
                              SET NgayHetHan = @NgayHetHan, 
                                  DiemTichLuy = @DiemTichLuy,
                                  ChiTieu = @ChiTieu,
                                  TrangThai = @TrangThai
                              WHERE MaTheVIP = @MaTheVIP";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaTheVIP", vip.MaTheVIP);
                cmd.Parameters.AddWithValue("@NgayHetHan", vip.NgayHetHan);
                cmd.Parameters.AddWithValue("@DiemTichLuy", vip.DiemTichLuy);
                cmd.Parameters.AddWithValue("@ChiTieu", vip.ChiTieu);
                cmd.Parameters.AddWithValue("@TrangThai", vip.TrangThai);

                int rs = cmd.ExecuteNonQuery();
                return rs > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CapNhatTheVIP: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        /// <summary>
        /// Delete VIP card
        /// </summary>
        public bool XoaTheVIP(string maTheVIP)
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = "DELETE FROM TheVIP WHERE MaTheVIP = @MaTheVIP";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaTheVIP", maTheVIP);

                int rs = cmd.ExecuteNonQuery();
                return rs > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in XoaTheVIP: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        /// <summary>
        /// Generate new VIP card number
        /// </summary>
        public string TaoMaTheVIPMoi()
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(MaTheVIP, 4, 10) AS INT)), 0) + 1 AS NextNumber
                              FROM TheVIP WHERE MaTheVIP LIKE 'VIP%'";

                SqlCommand cmd = new SqlCommand(sql, con);
                int nextNumber = (int)cmd.ExecuteScalar();

                return "VIP" + nextNumber.ToString("D5"); // VIP00001, VIP00002, etc.
            }
            catch (Exception ex)
            {
                throw new Exception("Error in TaoMaTheVIPMoi: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        /// <summary>
        /// Check if customer already has VIP card
        /// </summary>
        public bool KiemTraKhachHangCoTheVIP(string maKH)
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = "SELECT COUNT(*) FROM TheVIP WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        /// <summary>
        /// Update loyalty points
        /// </summary>
        public bool CapNhatDiemTichLuy(string maKH, int diem, bool isCong)
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                string sql = isCong 
                    ? "UPDATE TheVIP SET DiemTichLuy = DiemTichLuy + @Diem WHERE MaKH = @MaKH"
                    : "UPDATE TheVIP SET DiemTichLuy = DiemTichLuy - @Diem WHERE MaKH = @MaKH AND DiemTichLuy >= @Diem";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@Diem", Math.Abs(diem));

                int rs = cmd.ExecuteNonQuery();
                return rs > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CapNhatDiemTichLuy: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        /// <summary>
        /// Update spending and automatically add loyalty points
        /// </summary>
        public bool CapNhatChiTieu(string maKH, decimal soTienChiTieu)
        {
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();

                // Update ChiTieu and add points (1 point per 1000 VND)
                int diemThemVao = (int)(soTienChiTieu / 1000);

                string sql = @"UPDATE TheVIP 
                              SET ChiTieu = ChiTieu + @SoTienChiTieu,
                                  DiemTichLuy = DiemTichLuy + @DiemThemVao
                              WHERE MaKH = @MaKH AND TrangThai = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@SoTienChiTieu", soTienChiTieu);
                cmd.Parameters.AddWithValue("@DiemThemVao", diemThemVao);

                int rs = cmd.ExecuteNonQuery();
                return rs > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CapNhatChiTieu: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
