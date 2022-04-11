using Project1_BookStore.DAO;
using Project1_BookStore.DTO;
using System;
using System.Collections.Generic;
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
    }
}
