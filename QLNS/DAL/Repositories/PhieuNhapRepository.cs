using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLNS.DAL.Repositories
{
    /// <summary>
    /// Repository implementation for Purchase Order (PhieuNhap) entity
    /// </summary>
    public class PhieuNhapRepository : IPhieuNhapRepository
    {
        private readonly DatabaseContext _context;

        public PhieuNhapRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<PhieuNhap> GetAll()
        {
            var orders = new List<PhieuNhap>();
            string query = @"SELECT pn.*, nv.TenNV 
                           FROM PhieuNhap pn
                           LEFT JOIN NhanVien nv ON pn.MaNV = nv.MaNV";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orders.Add(MapToEntity(reader));
                }
            }
            return orders;
        }

        public PhieuNhap GetById(string id)
        {
            string query = @"SELECT pn.*, nv.TenNV 
                           FROM PhieuNhap pn
                           LEFT JOIN NhanVien nv ON pn.MaNV = nv.MaNV
                           WHERE pn.SoPN = @SoPN";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@SoPN", id);
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

        public bool Add(PhieuNhap entity)
        {
            string query = @"INSERT INTO PhieuNhap (SoPN, NgayNhap, MaNV, GhiChu) 
                           VALUES (@SoPN, @NgayNhap, @MaNV, @GhiChu)";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(PhieuNhap entity)
        {
            string query = @"UPDATE PhieuNhap SET 
                           NgayNhap = @NgayNhap,
                           MaNV = @MaNV,
                           GhiChu = @GhiChu
                           WHERE SoPN = @SoPN";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM PhieuNhap WHERE SoPN = @SoPN";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@SoPN", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public IEnumerable<PhieuNhap> GetByEmployee(string maNV)
        {
            var orders = new List<PhieuNhap>();
            string query = @"SELECT pn.*, nv.TenNV 
                           FROM PhieuNhap pn
                           LEFT JOIN NhanVien nv ON pn.MaNV = nv.MaNV
                           WHERE pn.MaNV = @MaNV";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(MapToEntity(reader));
                    }
                }
            }
            return orders;
        }

        public IEnumerable<PhieuNhap> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            var orders = new List<PhieuNhap>();
            string query = @"SELECT pn.*, nv.TenNV 
                           FROM PhieuNhap pn
                           LEFT JOIN NhanVien nv ON pn.MaNV = nv.MaNV
                           WHERE pn.NgayNhap BETWEEN @FromDate AND @ToDate";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(MapToEntity(reader));
                    }
                }
            }
            return orders;
        }

        public IEnumerable<ChiTietPhieuNhap> GetDetails(string soPN)
        {
            var details = new List<ChiTietPhieuNhap>();
            string query = @"SELECT ct.*, s.TenSach 
                           FROM ChiTietPhieuNhap ct
                           LEFT JOIN Sach s ON ct.MaSach = s.MaSach
                           WHERE ct.SoPN = @SoPN";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@SoPN", soPN);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        details.Add(new ChiTietPhieuNhap
                        {
                            SoPN = reader["SoPN"].ToString(),
                            MaSach = reader["MaSach"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            DonGiaNhap = Convert.ToDecimal(reader["DonGiaNhap"]),
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

        public bool AddWithDetails(PhieuNhap phieuNhap, List<ChiTietPhieuNhap> chiTiet)
        {
            SqlTransaction transaction = null;
            try
            {
                var connection = _context.GetConnection();
                transaction = connection.BeginTransaction();

                // Add PhieuNhap
                string queryPN = @"INSERT INTO PhieuNhap (SoPN, NgayNhap, MaNV, GhiChu) 
                                 VALUES (@SoPN, @NgayNhap, @MaNV, @GhiChu)";

                using (var cmd = new SqlCommand(queryPN, connection, transaction))
                {
                    AddParameters(cmd, phieuNhap);
                    cmd.ExecuteNonQuery();
                }

                // Add ChiTietPhieuNhap
                string queryCT = @"INSERT INTO ChiTietPhieuNhap (SoPN, MaSach, SoLuong, DonGiaNhap) 
                                 VALUES (@SoPN, @MaSach, @SoLuong, @DonGiaNhap)";

                foreach (var detail in chiTiet)
                {
                    using (var cmd = new SqlCommand(queryCT, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@SoPN", detail.SoPN);
                        cmd.Parameters.AddWithValue("@MaSach", detail.MaSach);
                        cmd.Parameters.AddWithValue("@SoLuong", detail.SoLuong);
                        cmd.Parameters.AddWithValue("@DonGiaNhap", detail.DonGiaNhap);
                        cmd.ExecuteNonQuery();
                    }

                    // Update stock
                    string updateStock = "UPDATE Sach SET SoLuongTon = SoLuongTon + @SoLuong WHERE MaSach = @MaSach";
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

        private PhieuNhap MapToEntity(SqlDataReader reader)
        {
            return new PhieuNhap
            {
                SoPN = reader["SoPN"].ToString(),
                NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                MaNV = reader["MaNV"].ToString(),
                GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : string.Empty,
                NhanVien = new NhanVien
                {
                    MaNV = reader["MaNV"].ToString(),
                    TenNV = reader["TenNV"] != DBNull.Value ? reader["TenNV"].ToString() : string.Empty
                }
            };
        }

        private void AddParameters(SqlCommand cmd, PhieuNhap entity)
        {
            cmd.Parameters.AddWithValue("@SoPN", entity.SoPN);
            cmd.Parameters.AddWithValue("@NgayNhap", entity.NgayNhap);
            cmd.Parameters.AddWithValue("@MaNV", entity.MaNV);
            cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(entity.GhiChu) ? (object)DBNull.Value : entity.GhiChu);
        }
    }
}
