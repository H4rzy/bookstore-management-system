using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLNS.DAL.Repositories
{
    /// <summary>
    /// Repository implementation for Customer (KhachHang) entity
    /// </summary>
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly DatabaseContext _context;

        public KhachHangRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<KhachHang> GetAll()
        {
            var customers = new List<KhachHang>();
            string query = "SELECT * FROM KhachHang";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    customers.Add(MapToEntity(reader));
                }
            }
            return customers;
        }

        public KhachHang GetById(string id)
        {
            string query = "SELECT * FROM KhachHang WHERE MaKH = @MaKH";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaKH", id);
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

        public bool Add(KhachHang entity)
        {
            string query = @"INSERT INTO KhachHang (MaKH, TenKH, DienThoai, DiaChi, LoaiKH) 
                           VALUES (@MaKH, @TenKH, @DienThoai, @DiaChi, @LoaiKH)";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(KhachHang entity)
        {
            string query = @"UPDATE KhachHang SET 
                           TenKH = @TenKH,
                           DienThoai = @DienThoai,
                           DiaChi = @DiaChi,
                           LoaiKH = @LoaiKH
                           WHERE MaKH = @MaKH";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaKH", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public IEnumerable<KhachHang> Search(string keyword)
        {
            var customers = new List<KhachHang>();
            string query = "SELECT * FROM KhachHang WHERE TenKH LIKE @Keyword OR DienThoai LIKE @Keyword OR MaKH LIKE @Keyword";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(MapToEntity(reader));
                    }
                }
            }
            return customers;
        }

        public IEnumerable<KhachHang> GetByType(string loaiKH)
        {
            var customers = new List<KhachHang>();
            string query = "SELECT * FROM KhachHang WHERE LoaiKH = @LoaiKH";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@LoaiKH", loaiKH);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(MapToEntity(reader));
                    }
                }
            }
            return customers;
        }

        private KhachHang MapToEntity(SqlDataReader reader)
        {
            return new KhachHang
            {
                MaKH = reader["MaKH"].ToString(),
                TenKH = reader["TenKH"].ToString(),
                DienThoai = reader["DienThoai"] != DBNull.Value ? reader["DienThoai"].ToString() : string.Empty,
                DiaChi = reader["DiaChi"] != DBNull.Value ? reader["DiaChi"].ToString() : string.Empty,
                LoaiKH = reader["LoaiKH"] != DBNull.Value ? reader["LoaiKH"].ToString() : string.Empty
            };
        }

        private void AddParameters(SqlCommand cmd, KhachHang entity)
        {
            cmd.Parameters.AddWithValue("@MaKH", entity.MaKH);
            cmd.Parameters.AddWithValue("@TenKH", entity.TenKH);
            cmd.Parameters.AddWithValue("@DienThoai", string.IsNullOrEmpty(entity.DienThoai) ? (object)DBNull.Value : entity.DienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(entity.DiaChi) ? (object)DBNull.Value : entity.DiaChi);
            cmd.Parameters.AddWithValue("@LoaiKH", string.IsNullOrEmpty(entity.LoaiKH) ? (object)DBNull.Value : entity.LoaiKH);
        }
    }
}
