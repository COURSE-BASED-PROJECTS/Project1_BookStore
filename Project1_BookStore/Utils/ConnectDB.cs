using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.Utils
{
    internal class ConnectDB
    {
        public static SqlConnection openConnection()
        {
            var connectionString = "Server=.\\SQLEXPRESS;Database=BookStoreDB;Trusted_Connection=True;";
            var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return connection;
        }
    }
}
