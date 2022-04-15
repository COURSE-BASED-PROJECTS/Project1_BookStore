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
    internal class OrderBUS
    {
        public static OrderDTO findOrderByID(string orderID)
        {
            if (orderID == null || orderID.Equals(""))
            {
                return null;
            }
            return OrderDAO.findOrderByID(orderID);
        }
        public static List<OrderDTO> findAllOrder()
        {
            return OrderDAO.findAllOrder();
        }
        public static List<OrderDTO> findOrderByRangeDate(DateTime start, DateTime end)
        {
            return OrderDAO.findOrderByRangeDate(start, end);
        }
        public static bool InsertOrder(OrderDTO order)
        {
            if (OrderBUS.findOrderByID(order.ordersID) != null)
            {
                return false;
            }
            return OrderDAO.InsertOrder(order);
        }

        public static bool UpdateOrder(OrderDTO order)
        {
            if (OrderBUS.findOrderByID(order.ordersID) == null)
            {
                return false;
            }
            return OrderDAO.UpdateOrder(order);
        }
        public static bool DeleteOrder(string orderID)
        {
            if (orderID == null || orderID.Equals(""))
            {
                return false;
            }
            if (OrderBUS.findOrderByID(orderID) == null)
            {
                return false;
            }
            return OrderDAO.DeleteOrder(orderID);
        }
        // định dạng date: yyyy-MM-dd
        public static int countOrderInDate(string date)
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
            return OrderDAO.countOrderInDate(date);
        }
    }
}
