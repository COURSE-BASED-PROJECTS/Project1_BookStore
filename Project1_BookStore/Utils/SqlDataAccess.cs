using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.Utils
{
    internal class SqlDataAccess
    {
        private SqlConnection _connection;
        public SqlDataAccess(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Kiểm tra xem có thể kết nối hay không
        /// </summary>
        /// <returns></returns>
        public bool CanConnect()
        {
            bool result = true;

            try
            {
                _connection.Open();
                _connection.Close();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public void Connect()
        {
            _connection.Open();
        }
    }
}
