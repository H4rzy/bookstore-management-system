using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLNS.DAL.Repositories
{
    /// <summary>
    /// Repository implementation for Publisher (NhaXuatBan) entity
    /// </summary>
    public class NhaXuatBanRepository : INhaXuatBanRepository
    {
        private readonly DatabaseContext _context;

        public NhaXuatBanRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<NhaXuatBan> GetAll()
        {
            var publishers = new List<NhaXuatBan>();
            string query = "SELECT * FROM NhaXuatBan";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    publishers.Add(MapToEntity(reader));
                }
            }
            return publishers;
        }

        public NhaXuatBan GetById(string id)
        {
            string query = "SELECT * FROM NhaXuatBan WHERE MaNXB = @MaNXB";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaNXB", id);
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

        public bool Add(NhaXuatBan entity)
        {
            string query = @"INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, DienThoai) 
                           VALUES (@MaNXB, @TenNXB, @DiaChi, @DienThoai)";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(NhaXuatBan entity)
        {
            string query = @"UPDATE NhaXuatBan SET 
                           TenNXB = @TenNXB,
                           DiaChi = @DiaChi,
                           DienThoai = @DienThoai
                           WHERE MaNXB = @MaNXB";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM NhaXuatBan WHERE MaNXB = @MaNXB";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaNXB", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private NhaXuatBan MapToEntity(SqlDataReader reader)
        {
            return new NhaXuatBan
            {
                MaNXB = reader["MaNXB"].ToString(),
                TenNXB = reader["TenNXB"].ToString(),
                DiaChi = reader["DiaChi"] != DBNull.Value ? reader["DiaChi"].ToString() : string.Empty,
                DienThoai = reader["DienThoai"] != DBNull.Value ? reader["DienThoai"].ToString() : string.Empty
            };
        }

        private void AddParameters(SqlCommand cmd, NhaXuatBan entity)
        {
            cmd.Parameters.AddWithValue("@MaNXB", entity.MaNXB);
            cmd.Parameters.AddWithValue("@TenNXB", entity.TenNXB);
            cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(entity.DiaChi) ? (object)DBNull.Value : entity.DiaChi);
            cmd.Parameters.AddWithValue("@DienThoai", string.IsNullOrEmpty(entity.DienThoai) ? (object)DBNull.Value : entity.DienThoai);
        }
    }
}
