using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLNS.DAL.Repositories
{
    /// <summary>
    /// Repository implementation for Category (TheLoai) entity
    /// </summary>
    public class TheLoaiRepository : ITheLoaiRepository
    {
        private readonly DatabaseContext _context;

        public TheLoaiRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<TheLoai> GetAll()
        {
            var categories = new List<TheLoai>();
            string query = "SELECT * FROM TheLoai";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    categories.Add(MapToEntity(reader));
                }
            }
            return categories;
        }

        public TheLoai GetById(string id)
        {
            string query = "SELECT * FROM TheLoai WHERE MaTheLoai = @MaTheLoai";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaTheLoai", id);
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

        public bool Add(TheLoai entity)
        {
            string query = "INSERT INTO TheLoai (MaTheLoai, TenTheLoai) VALUES (@MaTheLoai, @TenTheLoai)";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaTheLoai", entity.MaTheLoai);
                cmd.Parameters.AddWithValue("@TenTheLoai", entity.TenTheLoai);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(TheLoai entity)
        {
            string query = "UPDATE TheLoai SET TenTheLoai = @TenTheLoai WHERE MaTheLoai = @MaTheLoai";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaTheLoai", entity.MaTheLoai);
                cmd.Parameters.AddWithValue("@TenTheLoai", entity.TenTheLoai);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM TheLoai WHERE MaTheLoai = @MaTheLoai";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaTheLoai", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private TheLoai MapToEntity(SqlDataReader reader)
        {
            return new TheLoai
            {
                MaTheLoai = reader["MaTheLoai"].ToString(),
                TenTheLoai = reader["TenTheLoai"].ToString()
            };
        }
    }
}
