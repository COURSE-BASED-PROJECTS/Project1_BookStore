using Project1_BookStore.DAO;
using Project1_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.BUS
{
    internal class OrderDetailBUS
    {
        public static List<OrderDetailDTO> findOrderDetailByOrderID(string orderID)
        {
            if (orderID == null || orderID.Equals(""))
            {
                return null;
            }
            return OrderDetailDAO.findOrderDetailByOrderID(orderID);
        }
        public static int findTotalBookByOrderID(string orderID)
        {
            if (orderID == null || orderID.Equals(""))
            {
                return 0;
            }
            return OrderDetailDAO.findTotalBookByOrderID(orderID);
        }
    }
}
