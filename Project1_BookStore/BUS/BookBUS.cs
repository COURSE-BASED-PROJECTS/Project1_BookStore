using Project1_BookStore.DAO;
using Project1_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.BUS
{
    internal class BookBUS
    {
        public static BookDTO findBookByID(string bookID)
        {
            if (bookID == null || bookID.Equals(""))
            {
                return null;
            }
            return BookDAO.findBookByID(bookID);
        }
        public static List<BookDTO> findAllBook()
        {
            return BookDAO.findAllBook();
        }
        public static bool InsertBook(BookDTO book)
        {
            if (BookBUS.findBookByID(book.bookID) != null)
            {
                return false;
            }
            return BookDAO.InsertBook(book);
        }

        public static bool UpdateBook(BookDTO book)
        {
            if (BookBUS.findBookByID(book.bookID) == null)
            {
                return false;
            }
            return BookDAO.UpdateBook(book);
        }
    }
}
