using Project1_BookStore.DAO;
using Project1_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.BUS
{
    internal class UserBUS
    {
        public static bool findUser(string username, string password)
        {
            if (username == null || username == "" || password == null || password == "")
            {
                return false;
            }
            return UserDAO.findUser(username, password);  
        }
        public static string getHashedPasswordByUsername(string username)
        {
            if (username == null || username == "")
            {
                return null;
            }
            return UserDAO.getHashedPasswordByUsername(username);
        }
    }
}
