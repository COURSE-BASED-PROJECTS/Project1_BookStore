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
        public static UserDTO findUser(string username)
        {
            if (username == null || username == "")
            {
                return null;
            }
            return UserDAO.findUser(username);  
        }
    }
}
