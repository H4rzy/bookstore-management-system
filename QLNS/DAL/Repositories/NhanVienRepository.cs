using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLNS.DAL.Repositories
{
    /// <summary>
    /// Repository implementation for Employee (NhanVien) entity
    /// </summary>
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly DatabaseContext _context;

        public NhanVienRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<NhanVien> GetAll()
        {
            var employees = new List<NhanVien>();
            string query = "SELECT * FROM NhanVien";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    employees.Add(MapToEntity(reader));
                }
            }
            return employees;
        }

        public NhanVien GetById(string id)
        {
            string query = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaNV", id);
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

        public bool Add(NhanVien entity)
        {
            string query = @"INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, DienThoai, DiaChi, ChucVu) 
                           VALUES (@MaNV, @TenNV, @GioiTinh, @DienThoai, @DiaChi, @ChucVu)";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(NhanVien entity)
        {
            string query = @"UPDATE NhanVien SET 
                           TenNV = @TenNV,
                           GioiTinh = @GioiTinh,
                           DienThoai = @DienThoai,
                           DiaChi = @DiaChi,
                           ChucVu = @ChucVu
                           WHERE MaNV = @MaNV";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaNV", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public IEnumerable<NhanVien> Search(string keyword)
        {
            var employees = new List<NhanVien>();
            string query = "SELECT * FROM NhanVien WHERE TenNV LIKE @Keyword OR MaNV LIKE @Keyword";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(MapToEntity(reader));
                    }
                }
            }
            return employees;
        }

        public IEnumerable<NhanVien> GetByPosition(string chucVu)
        {
            var employees = new List<NhanVien>();
            string query = "SELECT * FROM NhanVien WHERE ChucVu = @ChucVu";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(MapToEntity(reader));
                    }
                }
            }
            return employees;
        }

        private NhanVien MapToEntity(SqlDataReader reader)
        {
            return new NhanVien
            {
                MaNV = reader["MaNV"].ToString(),
                TenNV = reader["TenNV"].ToString(),
                GioiTinh = reader["GioiTinh"] != DBNull.Value && Convert.ToBoolean(reader["GioiTinh"]),
                DienThoai = reader["DienThoai"] != DBNull.Value ? reader["DienThoai"].ToString() : string.Empty,
                DiaChi = reader["DiaChi"] != DBNull.Value ? reader["DiaChi"].ToString() : string.Empty,
                ChucVu = reader["ChucVu"] != DBNull.Value ? reader["ChucVu"].ToString() : string.Empty
            };
        }

        private void AddParameters(SqlCommand cmd, NhanVien entity)
        {
            cmd.Parameters.AddWithValue("@MaNV", entity.MaNV);
            cmd.Parameters.AddWithValue("@TenNV", entity.TenNV);
            cmd.Parameters.AddWithValue("@GioiTinh", entity.GioiTinh);
            cmd.Parameters.AddWithValue("@DienThoai", string.IsNullOrEmpty(entity.DienThoai) ? (object)DBNull.Value : entity.DienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(entity.DiaChi) ? (object)DBNull.Value : entity.DiaChi);
            cmd.Parameters.AddWithValue("@ChucVu", string.IsNullOrEmpty(entity.ChucVu) ? (object)DBNull.Value : entity.ChucVu);
        }
    }
}
