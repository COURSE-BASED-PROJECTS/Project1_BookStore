using Project1_BookStore.DAO;
using Project1_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public static bool DeleteBook(string bookID)
        {
            if (bookID == null || bookID.Equals(""))
            {
                return false;
            }
            if (BookBUS.findBookByID(bookID) == null)
            {
                return false;
            }
            return BookDAO.DeleteBook(bookID);
        }
        public static List<BookDTO> findTop5()
        {
            return BookDAO.findTop5();
        }
        public static List<BookDTO> findBookByTypeOfBook(string tob)
        {
            return BookDAO.findBookByTypeOfBook(tob);
        }
        public static List<BookDTO> findBookByName(string bookName)
        {
            return BookDAO.findBookByName(bookName);
        }
        public static List<BookDTO> findBookByRangePrice(int min, int max)
        {
            return BookDAO.findBookByRangePrice(min, max);
        }

        public static int countBookSold()
        {
            return BookDAO.countBookSold();
        }

        public static int countBookOnSell()
        {
            return BookDAO.countBookOnSell();
        }

        //date có định dạng yyyy-MM-dd
        public static int countBookSoldInDate(string date)
        {
            if (date == null || date.Equals(""))
            {
                return -1;
            }

            DateTime d;
            string dateFormat = "yyyy-MM-dd";
            bool checkDateFormat = DateTime.TryParseExact(
                date,
                dateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out d
            );
            if (!checkDateFormat)
            {
                return -1;
            }
            return BookDAO.countBookSoldInDate(date);
        }

        public static List<BookDTO> findBestSellerBook()
        {
            return BookDAO.findBestSellerBook();
        }
        
    }
}
