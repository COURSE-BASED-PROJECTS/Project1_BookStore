﻿using Project1_BookStore.DTO;
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
        internal static bool findUser(string username, string password)
        {
            var con = ConnectDB.openConnection();
          
            var sql = $"Select * From Account Where accUsername = '{username}'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                string accPassword = (string) reader["accPassword"];
                if (accPassword.Equals(password))
                {
                    return true;
                }
                return false;
            }
            reader.Close();
            return false;
        }
    }
}
