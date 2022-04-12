using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.DTO
{
    internal class OrderDetailDTO
    {
        public string ordersID { get; set; }
        public string bookID { get; set; }
        public decimal odCurrentPrice { get; set; }
        public int odQuantity { get; set; }

    }
}
