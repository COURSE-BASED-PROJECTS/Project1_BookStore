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
    internal class OrderDetailDAO
    {
        internal static List<OrderDetailDTO> findOrderDetailByOrderID(string orderID)
        {
            var con = ConnectDB.openConnection();

            var sql = $"SELECT * FROM ORDERSDETAIL WHERE ordersID = '{orderID}'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            List<OrderDetailDTO> list = new List<OrderDetailDTO>();

            while (reader.Read())
            {
                string bookID = (string)reader["bookID"];
                decimal odCurrentPrice = (decimal)reader["odCurrentPrice"];
                int odQuantity = (int)reader["odQuantity"];
            
                var odDetail = new OrderDetailDTO()
                {
                    ordersID = orderID,
                    bookID = bookID,
                    odCurrentPrice = odCurrentPrice,
                    odQuantity = odQuantity                    
                };
                list.Add(odDetail);
            }
            reader.Close();
            return list;
        }

        internal static int findTotalBookByOrderID(string orderID)
        {
            var con = ConnectDB.openConnection();

            var sql = $"SELECT SUM(odQuantity) FROM ORDERSDETAIL WHERE ordersID = '{orderID}'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteScalar();

            Int32 result = (Int32)reader;

            return (int)result;
        }
    }
}
