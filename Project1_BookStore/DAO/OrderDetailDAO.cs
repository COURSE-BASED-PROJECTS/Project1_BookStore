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

            var sql = $"SELECT * FROM ORDERSDETAILS WHERE ordersID = '{orderID}'";

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
    }
}
