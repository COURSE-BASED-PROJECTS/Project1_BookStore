﻿using Project1_BookStore.DAO;
using Project1_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.BUS
{
    internal class TypeOfBookBUS
    {
        public static TypeOfBookDTO findTypeOfBookByID(string tobID)
        {
            if (tobID == null || tobID.Equals(""))
            {
                return null;
            }
            return TypeOfBookDAO.findTypeOfBookByID(tobID);
        }

        public static List<TypeOfBookDTO> findAllTypeOfBook()
        {
            return TypeOfBookDAO.findAllTypeOfBook();
        }
        public static List<BookDTO> findAllBook()
        {
            return BookDAO.findAllBook();
        }
        public static bool InsertTypeOfBook(TypeOfBookDTO tob)
        {
            if (TypeOfBookBUS.findTypeOfBookByID(tob.tobID) != null)
            {
                return false;
            }
            return TypeOfBookDAO.InsertTypeOfBook(tob);
        }

        public static bool UpdateTypeOfBook(TypeOfBookDTO tob)
        {
            if (TypeOfBookBUS.findTypeOfBookByID(tob.tobID) == null)
            {
                return false;
            }
            return TypeOfBookDAO.UpdateTypeOfBook(tob);
        }
    }
}
