using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//===
using System.Data.SqlClient;
using QLBS_DTO;
 namespace QLBS_DAL
{
    public class DBConnect
    {
        public static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=_BookStore_;User Id=sa;Password=123;TrustServerCertificate=True;";
        protected SqlConnection con = new SqlConnection(connectionString);
    }
}