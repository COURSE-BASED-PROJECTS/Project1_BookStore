using Project1_BookStore.DTO;
using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.DAO
{
    internal class UserDAO
    {
        internal static UserDTO findUser(string username)
        {
            var con = ConnectDB.openConnection();
          
            var sql = $"Select * From Account Where username = '{username}'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                string password = (string) reader["password"];
                UserDTO user = new UserDTO()
                {
                    username = username,
                    password = password
                };
                return user;
            }
            reader.Close();
            return null;
        }
    }
}
