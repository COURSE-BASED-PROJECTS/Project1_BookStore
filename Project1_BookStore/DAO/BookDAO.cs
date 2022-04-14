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
    internal class BookDAO
    {
        public static BookDTO findBookByID(string bookID)
        {
            var con = ConnectDB.openConnection();

            var sql = $"SELECT * FROM BOOK WHERE bookID = '{bookID}'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string bookName = (string)reader["bookName"];
                string bookAuthor = (string)reader["bookAuthor"];
                string tobID = (string)reader["tobID"];
                int bookPrice = (int)reader["bookPrice"];
                int bookQuantity = (int)reader["bookQuantity"];
                int bookPublishedYear = (int)reader["bookPublishedYear"];
                var  book = new BookDTO()
                {
                    bookID = bookID,
                    bookName = bookName,
                    tobID = tobID,
                    bookAuthor = bookAuthor,
                    bookPrice = bookPrice,
                    bookQuantity = bookQuantity,
                    bookPublishedYear = bookPublishedYear
                };
                return book;
            }
            reader.Close();
            return null;
        }

        internal static List<BookDTO> findBookByName(string bookName)
        {
            var con = ConnectDB.openConnection();

            var sql = $"SELECT * FROM BOOK WHERE bookName LIKE N'%{bookName}%'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            List<BookDTO> books = new List<BookDTO>();
            while (reader.Read())
            {
                string bookID = (string)reader["bookID"];
                string name = (string)reader["bookName"];
                string bookAuthor = (string)reader["bookAuthor"];
                string tobID = (string)reader["tobID"];
                decimal bookPrice = (decimal)reader["bookPrice"];
                //int bookPrice = 0;
                int bookQuantity = (int)reader["bookQuantity"];
                int bookPublishedYear = (int)reader["bookPublishedYear"];
                var book = new BookDTO()
                {
                    bookID = bookID,
                    bookName = name,
                    tobID = tobID,
                    bookAuthor = bookAuthor,
                    bookPrice = bookPrice,
                    bookQuantity = bookQuantity,
                    bookPublishedYear = bookPublishedYear
                };
                books.Add(book);
            }
            reader.Close();
            return books;
        }

        internal static List<BookDTO> findBestSellerBook()
        {
            var con = ConnectDB.openConnection();

            var sql = "SELECT * FROM BOOK WHERE bookID = (" +
                "SELECT bookID FROM ORDERSDETAIL" +
                "GROUP BY bookID" +
                "HAVING SUM(odQuantity) > 5)";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            List<BookDTO> books = new List<BookDTO>();
            while (reader.Read())
            {
                string bookID = (string)reader["bookID"];
                string name = (string)reader["bookName"];
                string bookAuthor = (string)reader["bookAuthor"];
                string tobID = (string)reader["tobID"];
                decimal bookPrice = (decimal)reader["bookPrice"];
                //int bookPrice = 0;
                int bookQuantity = (int)reader["bookQuantity"];
                int bookPublishedYear = (int)reader["bookPublishedYear"];
                var book = new BookDTO()
                {
                    bookID = bookID,
                    bookName = name,
                    tobID = tobID,
                    bookAuthor = bookAuthor,
                    bookPrice = bookPrice,
                    bookQuantity = bookQuantity,
                    bookPublishedYear = bookPublishedYear
                };
                books.Add(book);
            }
            reader.Close();
            return books;
        }

        internal static int countBookSold()
        {
            var con = ConnectDB.openConnection();

            var sql = "SELECT SUM(odQuantity) FROM ORDERSDETAIL";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteScalar();

            Int32 result = (Int32) reader;

            return (int) result;
        }

        internal static List<BookDTO> findBookByRangePrice(int min, int max)
        {
            var con = ConnectDB.openConnection();

            var sql = $"SELECT * FROM BOOK WHERE bookPrice BETWEEN {min} AND {max}";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            List<BookDTO> books = new List<BookDTO>();
            while (reader.Read())
            {
                string bookID = (string)reader["bookID"];
                string bookName = (string)reader["bookName"];
                string bookAuthor = (string)reader["bookAuthor"];
                string tobID = (string)reader["tobID"];
                decimal bookPrice = (decimal)reader["bookPrice"];
                //int bookPrice = 0;
                int bookQuantity = (int)reader["bookQuantity"];
                int bookPublishedYear = (int)reader["bookPublishedYear"];
                var book = new BookDTO()
                {
                    bookID = bookID,
                    bookName = bookName,
                    tobID = tobID,
                    bookAuthor = bookAuthor,
                    bookPrice = bookPrice,
                    bookQuantity = bookQuantity,
                    bookPublishedYear = bookPublishedYear
                };
                books.Add(book);
            }
            reader.Close();
            return books;
        }

        internal static List<BookDTO> findBookByTypeOfBook(string tob)
        {
            var con = ConnectDB.openConnection();

            var sql = $"SELECT * FROM BOOK WHERE tobID = '{tob}'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            List<BookDTO> books = new List<BookDTO>();
            while (reader.Read())
            {
                string bookID = (string)reader["bookID"];
                string bookName = (string)reader["bookName"];
                string bookAuthor = (string)reader["bookAuthor"];
                string tobID = (string)reader["tobID"];
                decimal bookPrice = (decimal)reader["bookPrice"];
                //int bookPrice = 0;
                int bookQuantity = (int)reader["bookQuantity"];
                int bookPublishedYear = (int)reader["bookPublishedYear"];
                var book = new BookDTO()
                {
                    bookID = bookID,
                    bookName = bookName,
                    tobID = tobID,
                    bookAuthor = bookAuthor,
                    bookPrice = bookPrice,
                    bookQuantity = bookQuantity,
                    bookPublishedYear = bookPublishedYear
                };
                books.Add(book);
            }
            reader.Close();
            return books;
        }

        internal static List<BookDTO> findTop5()
        {
            var con = ConnectDB.openConnection();

            var sql = "SELECT TOP 5 * FROM BOOK WHERE bookQuantity < 5 ORDER BY bookQuantity ASC";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            List<BookDTO> books = new List<BookDTO>();
            while (reader.Read())
            {
                string bookID = (string)reader["bookID"];
                string bookName = (string)reader["bookName"];
                string bookAuthor = (string)reader["bookAuthor"];
                string tobID = (string)reader["tobID"];
                decimal bookPrice = (decimal)reader["bookPrice"];
                //int bookPrice = 0;
                int bookQuantity = (int)reader["bookQuantity"];
                int bookPublishedYear = (int)reader["bookPublishedYear"];
                var book = new BookDTO()
                {
                    bookID = bookID,
                    bookName = bookName,
                    tobID = tobID,
                    bookAuthor = bookAuthor,
                    bookPrice = bookPrice,
                    bookQuantity = bookQuantity,
                    bookPublishedYear = bookPublishedYear
                };
                books.Add(book);
            }
            reader.Close();
            return books;
        }

        public static List<BookDTO> findAllBook()
        {
            var con = ConnectDB.openConnection();

            var sql = "SELECT * FROM BOOK";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            List<BookDTO> books = new List<BookDTO>();
            while (reader.Read())
            {
                string bookID = (string)reader["bookID"];
                string bookName = (string)reader["bookName"];
                string bookAuthor = (string)reader["bookAuthor"];
                string tobID = (string)reader["tobID"];
                decimal bookPrice = (decimal)reader["bookPrice"];
                //int bookPrice = 0;
                int bookQuantity = (int)reader["bookQuantity"];
                int bookPublishedYear = (int)reader["bookPublishedYear"];
                var book = new BookDTO()
                {
                    bookID = bookID,
                    bookName = bookName,
                    tobID = tobID,
                    bookAuthor = bookAuthor,
                    bookPrice = bookPrice,
                    bookQuantity = bookQuantity,
                    bookPublishedYear = bookPublishedYear
                };
                books.Add(book);
            }
            reader.Close();
            return books;
        }

        public static bool InsertBook(BookDTO book)
        {
            var con = ConnectDB.openConnection();

            var sql = "INSERT INTO BOOK(bookID, tobID, bookName, bookAuthor, bookPrice, bookPublishedYear, bookQuantity)" +
                $"VALUES('{book.bookID}', '{book.tobID}', N'{book.bookName}', N'{book.bookAuthor}', {book.bookPrice}, {book.bookPublishedYear}, {book.bookQuantity})";

            var command = new SqlCommand(sql, con);
            try
            {
                command.ExecuteNonQuery();
            } catch (Exception ex)
            {
                return false;
            }
            
            return true;
        }
        public static bool UpdateBook(BookDTO book)
        {
            var con = ConnectDB.openConnection();

            var sql = $"UPDATE BOOK SET tobID = '{book.tobID}', bookName = '{book.bookName}', bookAuthor = '{book.bookAuthor}', " +
                $"bookPrice = {book.bookPrice}, bookPublishedYear = {book.bookPublishedYear}, bookQuantity = {book.bookQuantity}" +
                $"WHERE bookID = {book.bookID}";

            var command = new SqlCommand(sql, con);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
