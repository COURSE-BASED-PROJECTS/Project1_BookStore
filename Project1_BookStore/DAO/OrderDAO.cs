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
    internal class OrderDAO
    {
        internal static OrderDTO findOrderByID(string orderID)
        {
            var con = ConnectDB.openConnection();

            var sql = $"SELECT * FROM ORDERS WHERE ordersID = '{orderID}'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string cusPhoneNumber = (string)reader["cusPhoneNumber"];
                string accUsername = (string)reader["accUsername"];
                string tobID = (string)reader["tobID"];
                decimal ordersPrice = (decimal)reader["ordersPrice"];
                var ordersTime = (DateTime)reader["ordersTime"];
                
                var order = new OrderDTO()
                {
                    ordersID = orderID,
                    cusPhoneNumber = cusPhoneNumber,
                    accUsername = accUsername,
                    ordersPrices = ordersPrice,
                    ordersTime = ordersTime
                };
                return order;
            }
            reader.Close();
            return null;
        }

        internal static List<OrderDTO> findOrderByRangeDate(DateTime start, DateTime end)
        {
            var con = ConnectDB.openConnection();

            var sql = $"SELECT * FROM ORDERS WHERE ordersTime BETWEEN '{start}' AND '{end}'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            List<OrderDTO> orders = new List<OrderDTO>();

            while (reader.Read())
            {
                string ordersID = (string)reader["ordersID"];
                string cusPhoneNumber = (string)reader["cusPhoneNumber"];
                string accUsername = (string)reader["accUsername"];
                string tobID = (string)reader["tobID"];
                int ordersPrice = (int)reader["ordersPrice"];
                var ordersTime = (DateTime)reader["ordersTime"];

                var order = new OrderDTO()
                {
                    ordersID = ordersID,
                    cusPhoneNumber = cusPhoneNumber,
                    accUsername = accUsername,
                    ordersPrices = ordersPrice,
                    ordersTime = ordersTime
                };
                orders.Add(order);
            }
            reader.Close();
            return orders;
        }

        internal static List<OrderDTO> findAllOrder()
        {
            var con = ConnectDB.openConnection();

            var sql = "SELECT * FROM ORDERS";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();
            List<OrderDTO> orders = new List<OrderDTO>();

            while (reader.Read())
            {
                string ordersID = (string)reader["ordersID"];
                string cusPhoneNumber = (string)reader["cusPhoneNumber"];
                string accUsername = (string)reader["accUsername"];
                //string tobID = (string)reader["tobID"];

                //uncomment when data is completed
                decimal ordersPrice = (decimal)reader["ordersPrice"];

                //uncomment when data is completed
                var ordersTime = (DateTime)reader["ordersTime"];

                var order = new OrderDTO()
                {
                    ordersID = ordersID,
                    cusPhoneNumber = cusPhoneNumber,
                    accUsername = accUsername,
                    ordersPrices = ordersPrice,
                    ordersTime = ordersTime
                };
                orders.Add(order);
            }
            reader.Close();
            return orders;
        }

        internal static bool InsertOrder(OrderDTO order)
        {
            var con = ConnectDB.openConnection();

            var sql = "INSERT INTO ORDERS(ordersID, cusPhoneNumber, accUsername, ordersPrice, ordersTime)" +
                $"VALUES('{order.ordersID}', '{order.cusPhoneNumber}', '{order.accUsername}', {order.ordersPrices}, '{order.ordersTime}')";
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

        internal static bool UpdateOrder(OrderDTO order)
        {
            var con = ConnectDB.openConnection();

            var sql = $"UPDATE ORDERS SET cusPhoneNumber = '{order.cusPhoneNumber}', accUsername = '{order.accUsername}', ordersPrices = {order.ordersPrices}, ordersTime = '{order.ordersTime}' "
                + $"WHERE ordersID = {order.ordersID}";

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
