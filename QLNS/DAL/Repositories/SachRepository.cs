using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLNS.DAL.Repositories
{
    /// <summary>
    /// Repository implementation for Book (Sach) entity
    /// Handles all database operations for books
    /// </summary>
    public class SachRepository : ISachRepository
    {
        private readonly DatabaseContext _context;

        public SachRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Sach> GetAll()
        {
            var books = new List<Sach>();
            string query = @"SELECT s.*, tl.TenTheLoai, nxb.TenNXB 
                           FROM Sach s
                           LEFT JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                           LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    books.Add(MapToEntity(reader));
                }
            }
            return books;
        }

        public Sach GetById(string id)
        {
            string query = @"SELECT s.*, tl.TenTheLoai, nxb.TenNXB 
                           FROM Sach s
                           LEFT JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                           LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
                           WHERE s.MaSach = @MaSach";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaSach", id);
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

        public bool Add(Sach entity)
        {
            string query = @"INSERT INTO Sach (MaSach, TenSach, MaTheLoai, MaNXB, TacGia, DonGiaNhap, DonGiaBan, SoLuongTon)
                           VALUES (@MaSach, @TenSach, @MaTheLoai, @MaNXB, @TacGia, @DonGiaNhap, @DonGiaBan, @SoLuongTon)";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(Sach entity)
        {
            string query = @"UPDATE Sach SET 
                           TenSach = @TenSach, 
                           MaTheLoai = @MaTheLoai,
                           MaNXB = @MaNXB,
                           TacGia = @TacGia,
                           DonGiaNhap = @DonGiaNhap,
                           DonGiaBan = @DonGiaBan,
                           SoLuongTon = @SoLuongTon
                           WHERE MaSach = @MaSach";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM Sach WHERE MaSach = @MaSach";
            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaSach", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public IEnumerable<Sach> GetByTheLoai(string maTheLoai)
        {
            var books = new List<Sach>();
            string query = @"SELECT s.*, tl.TenTheLoai, nxb.TenNXB 
                           FROM Sach s
                           LEFT JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                           LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
                           WHERE s.MaTheLoai = @MaTheLoai";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(MapToEntity(reader));
                    }
                }
            }
            return books;
        }

        public IEnumerable<Sach> GetByNXB(string maNXB)
        {
            var books = new List<Sach>();
            string query = @"SELECT s.*, tl.TenTheLoai, nxb.TenNXB 
                           FROM Sach s
                           LEFT JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                           LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
                           WHERE s.MaNXB = @MaNXB";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaNXB", maNXB);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(MapToEntity(reader));
                    }
                }
            }
            return books;
        }

        public IEnumerable<Sach> Search(string keyword)
        {
            var books = new List<Sach>();
            string query = @"SELECT s.*, tl.TenTheLoai, nxb.TenNXB 
                           FROM Sach s
                           LEFT JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai
                           LEFT JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
                           WHERE s.TenSach LIKE @Keyword OR s.TacGia LIKE @Keyword OR s.MaSach LIKE @Keyword";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(MapToEntity(reader));
                    }
                }
            }
            return books;
        }

        public bool UpdateStock(string maSach, int quantity)
        {
            string query = "UPDATE Sach SET SoLuongTon = SoLuongTon + @Quantity WHERE MaSach = @MaSach";
            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private Sach MapToEntity(SqlDataReader reader)
        {
            return new Sach
            {
                MaSach = reader["MaSach"].ToString(),
                TenSach = reader["TenSach"].ToString(),
                MaTheLoai = reader["MaTheLoai"].ToString(),
                MaNXB = reader["MaNXB"].ToString(),
                TacGia = reader["TacGia"] != DBNull.Value ? reader["TacGia"].ToString() : string.Empty,
                DonGiaNhap = Convert.ToDecimal(reader["DonGiaNhap"]),
                DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                SoLuongTon = Convert.ToInt32(reader["SoLuongTon"]),
                TheLoai = new TheLoai
                {
                    MaTheLoai = reader["MaTheLoai"].ToString(),
                    TenTheLoai = reader["TenTheLoai"] != DBNull.Value ? reader["TenTheLoai"].ToString() : string.Empty
                },
                NhaXuatBan = new NhaXuatBan
                {
                    MaNXB = reader["MaNXB"].ToString(),
                    TenNXB = reader["TenNXB"] != DBNull.Value ? reader["TenNXB"].ToString() : string.Empty
                }
            };
        }

        private void AddParameters(SqlCommand cmd, Sach entity)
        {
            cmd.Parameters.AddWithValue("@MaSach", entity.MaSach);
            cmd.Parameters.AddWithValue("@TenSach", entity.TenSach);
            cmd.Parameters.AddWithValue("@MaTheLoai", entity.MaTheLoai);
            cmd.Parameters.AddWithValue("@MaNXB", entity.MaNXB);
            cmd.Parameters.AddWithValue("@TacGia", string.IsNullOrEmpty(entity.TacGia) ? (object)DBNull.Value : entity.TacGia);
            cmd.Parameters.AddWithValue("@DonGiaNhap", entity.DonGiaNhap);
            cmd.Parameters.AddWithValue("@DonGiaBan", entity.DonGiaBan);
            cmd.Parameters.AddWithValue("@SoLuongTon", entity.SoLuongTon);
        }
    }
}
