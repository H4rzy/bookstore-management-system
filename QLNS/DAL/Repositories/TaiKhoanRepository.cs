using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Data.SqlClient;

namespace QLNS.DAL.Repositories
{
    /// <summary>
    /// Repository implementation for Account (TaiKhoan) entity
    /// </summary>
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly DatabaseContext _context;

        public TaiKhoanRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public System.Collections.Generic.IEnumerable<TaiKhoan> GetAll()
        {
            var accounts = new System.Collections.Generic.List<TaiKhoan>();
            string query = @"SELECT tk.*, nv.TenNV 
                           FROM TaiKhoan tk
                           LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    accounts.Add(MapToEntity(reader));
                }
            }
            return accounts;
        }

        public TaiKhoan GetById(string id)
        {
            string query = @"SELECT tk.*, nv.TenNV 
                           FROM TaiKhoan tk
                           LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                           WHERE tk.TenDangNhap = @TenDangNhap";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", id);
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

        public bool Add(TaiKhoan entity)
        {
            string query = @"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNV, Quyen) 
                           VALUES (@TenDangNhap, @MatKhau, @MaNV, @Quyen)";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(TaiKhoan entity)
        {
            string query = @"UPDATE TaiKhoan SET 
                           MatKhau = @MatKhau,
                           MaNV = @MaNV,
                           Quyen = @Quyen
                           WHERE TenDangNhap = @TenDangNhap";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                AddParameters(cmd, entity);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public TaiKhoan ValidateLogin(string tenDangNhap, string matKhau)
        {
            string query = @"SELECT tk.*, nv.TenNV 
                           FROM TaiKhoan tk
                           LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                           WHERE tk.TenDangNhap = @TenDangNhap AND tk.MatKhau = @MatKhau";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
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

        public bool ChangePassword(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            // First validate old password
            var account = ValidateLogin(tenDangNhap, matKhauCu);
            if (account == null)
                return false;

            // Update to new password
            string query = "UPDATE TaiKhoan SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";

            using (var cmd = new SqlCommand(query, _context.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private TaiKhoan MapToEntity(SqlDataReader reader)
        {
            return new TaiKhoan
            {
                TenDangNhap = reader["TenDangNhap"].ToString(),
                MatKhau = reader["MatKhau"].ToString(),
                MaNV = reader["MaNV"].ToString(),
                Quyen = reader["Quyen"] != DBNull.Value ? reader["Quyen"].ToString() : string.Empty,
                NhanVien = new NhanVien
                {
                    MaNV = reader["MaNV"].ToString(),
                    TenNV = reader["TenNV"] != DBNull.Value ? reader["TenNV"].ToString() : string.Empty
                }
            };
        }

        private void AddParameters(SqlCommand cmd, TaiKhoan entity)
        {
            cmd.Parameters.AddWithValue("@TenDangNhap", entity.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", entity.MatKhau);
            cmd.Parameters.AddWithValue("@MaNV", entity.MaNV);
            cmd.Parameters.AddWithValue("@Quyen", string.IsNullOrEmpty(entity.Quyen) ? (object)DBNull.Value : entity.Quyen);
        }
    }
}
