using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Markup;

namespace QLNS.DAL
{
    /// <summary>
    /// Database context for managing SQL Server connections
    /// Implements IDisposable for proper resource cleanup
    /// </summary>
    public class DatabaseContext : IDisposable
    {
        private SqlConnection _connection;
        private readonly string _connectionString;

        public DatabaseContext()
        {
            // Get connection string from App.config
            //_connectionString = ConfigurationManager.ConnectionStrings["QuanLyNhaSach"]?.ConnectionString;
            _connectionString = $"Data Source = DESKTOP-941SMBF\\SQLEXPRESS; Initial Catalog = QuanLyNhaSach; Integrated Security = True;";




            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string 'QuanLyNhaSach' not found in App.config");
            }
        }

        /// <summary>
        /// Gets an open database connection
        /// </summary>
        /// <returns>Open SqlConnection</returns>
        public SqlConnection GetConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }

        /// <summary>
        /// Closes and disposes the database connection
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
