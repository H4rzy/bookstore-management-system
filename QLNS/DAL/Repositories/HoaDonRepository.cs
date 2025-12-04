using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLNS.DAL.Repositories
{
    /// <summary>
    /// Repository implementation for Invoice (HoaDon) entity
    /// </summary>
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly DatabaseContext _context;

        public HoaDonRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<HoaDon> GetAll()
        {
            var invoices = new List<HoaDon>();
            string query = @"SELECT hd.*, nv.TenNV, kh.TenKH 
                           FROM HoaDon hd
                           LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                           LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    invoices.Add(MapToEntity(reader));
                }
            }
            return invoices;
        }

        public HoaDon GetById(string id)
        {
            string query = @"SELECT hd.*, nv.TenNV, kh.TenKH 
                           FROM HoaDon hd
                           LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                           LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                           WHERE hd.SoHD = @SoHD";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@SoHD", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapToEntity(reader);
                    }
                }
            }
            return null;
        }

        public bool Add(HoaDon entity)
        {
            string query = @"INSERT INTO HoaDon (SoHD, NgayBan, MaNV, MaKH, GhiChu) 
                           VALUES (@SoHD, @NgayBan, @MaNV, @MaKH, @GhiChu)";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(HoaDon entity)
        {
            string query = @"UPDATE HoaDon SET 
                           NgayBan = @NgayBan,
                           MaNV = @MaNV,
                           MaKH = @MaKH,
                           GhiChu = @GhiChu
                           WHERE SoHD = @SoHD";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM HoaDon WHERE SoHD = @SoHD";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@SoHD", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public IEnumerable<HoaDon> GetByEmployee(string maNV)
        {
            var invoices = new List<HoaDon>();
            string query = @"SELECT hd.*, nv.TenNV, kh.TenKH 
                           FROM HoaDon hd
                           LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                           LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                           WHERE hd.MaNV = @MaNV";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoices.Add(MapToEntity(reader));
                    }
                }
            }
            return invoices;
        }

        public IEnumerable<HoaDon> GetByCustomer(string maKH)
        {
            var invoices = new List<HoaDon>();
            string query = @"SELECT hd.*, nv.TenNV, kh.TenKH 
                           FROM HoaDon hd
                           LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                           LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                           WHERE hd.MaKH = @MaKH";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoices.Add(MapToEntity(reader));
                    }
                }
            }
            return invoices;
        }

        public IEnumerable<HoaDon> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            var invoices = new List<HoaDon>();
            string query = @"SELECT hd.*, nv.TenNV, kh.TenKH 
                           FROM HoaDon hd
                           LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                           LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                           WHERE hd.NgayBan BETWEEN @FromDate AND @ToDate";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoices.Add(MapToEntity(reader));
                    }
                }
            }
            return invoices;
        }

        public IEnumerable<ChiTietHoaDon> GetDetails(string soHD)
        {
            var details = new List<ChiTietHoaDon>();
            string query = @"SELECT ct.*, s.TenSach 
                           FROM ChiTietHoaDon ct
                           LEFT JOIN Sach s ON ct.MaSach = s.MaSach
                           WHERE ct.SoHD = @SoHD";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@SoHD", soHD);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        details.Add(new ChiTietHoaDon
                        {
                            SoHD = reader["SoHD"].ToString(),
                            MaSach = reader["MaSach"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                            Sach = new Sach
                            {
                                MaSach = reader["MaSach"].ToString(),
                                TenSach = reader["TenSach"] != DBNull.Value ? reader["TenSach"].ToString() : string.Empty
                            }
                        });
                    }
                }
            }
            return details;
        }

        public bool AddWithDetails(HoaDon hoaDon, List<ChiTietHoaDon> chiTiet)
        {
            SqlTransaction transaction = null;
            try
            {
                var connection = _context.GetConnection();
                transaction = connection.BeginTransaction();

                // Add HoaDon
                string queryHD = @"INSERT INTO HoaDon (SoHD, NgayBan, MaNV, MaKH, GhiChu) 
                                 VALUES (@SoHD, @NgayBan, @MaNV, @MaKH, @GhiChu)";

                using (var cmd = new SqlCommand(queryHD, connection, transaction))
                {
                    AddParameters(cmd, hoaDon);
                    cmd.ExecuteNonQuery();
                }

                // Add ChiTietHoaDon
                string queryCT = @"INSERT INTO ChiTietHoaDon (SoHD, MaSach, SoLuong, DonGiaBan) 
                                 VALUES (@SoHD, @MaSach, @SoLuong, @DonGiaBan)";

                foreach (var detail in chiTiet)
                {
                    using (var cmd = new SqlCommand(queryCT, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@SoHD", detail.SoHD);
                        cmd.Parameters.AddWithValue("@MaSach", detail.MaSach);
                        cmd.Parameters.AddWithValue("@SoLuong", detail.SoLuong);
                        cmd.Parameters.AddWithValue("@DonGiaBan", detail.DonGiaBan);
                        cmd.ExecuteNonQuery();
                    }

                    // Update stock (decrease)
                    string updateStock = "UPDATE Sach SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSach = @MaSach";
                    using (var cmd = new SqlCommand(updateStock, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaSach", detail.MaSach);
                        cmd.Parameters.AddWithValue("@SoLuong", detail.SoLuong);
                        cmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction?.Rollback();
                throw;
            }
        }

        private HoaDon MapToEntity(SqlDataReader reader)
        {
            return new HoaDon
            {
                SoHD = reader["SoHD"].ToString(),
                NgayBan = Convert.ToDateTime(reader["NgayBan"]),
                MaNV = reader["MaNV"].ToString(),
                MaKH = reader["MaKH"] != DBNull.Value ? reader["MaKH"].ToString() : null,
                GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : string.Empty,
                NhanVien = new NhanVien
                {
                    MaNV = reader["MaNV"].ToString(),
                    TenNV = reader["TenNV"] != DBNull.Value ? reader["TenNV"].ToString() : string.Empty
                },
                KhachHang = reader["MaKH"] != DBNull.Value ? new KhachHang
                {
                    MaKH = reader["MaKH"].ToString(),
                    TenKH = reader["TenKH"] != DBNull.Value ? reader["TenKH"].ToString() : string.Empty
                } : null
            };
        }

        private void AddParameters(SqlCommand cmd, HoaDon entity)
        {
            cmd.Parameters.AddWithValue("@SoHD", entity.SoHD);
            cmd.Parameters.AddWithValue("@NgayBan", entity.NgayBan);
            cmd.Parameters.AddWithValue("@MaNV", entity.MaNV);
            cmd.Parameters.AddWithValue("@MaKH", string.IsNullOrEmpty(entity.MaKH) ? (object)DBNull.Value : entity.MaKH);
            cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(entity.GhiChu) ? (object)DBNull.Value : entity.GhiChu);
        }
    }
}
