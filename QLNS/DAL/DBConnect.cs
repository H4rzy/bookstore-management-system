using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
namespace QLNS_DAL
{
    public class DBConnect
    {
        public static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyNhaSach;User Id=sa;Password=123;TrustServerCertificate=True;";
        protected SqlConnection con = new SqlConnection(connectionString);
    }
}
