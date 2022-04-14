using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.DTO
{
    internal class OrderDTO
    {
        public string ordersID { get; set; }
        public string cusPhoneNumber { get; set; }
        public string accUsername { get; set; }
        public string setting { get; set; } = "/Resource/Images/Icons/info.png";
        public decimal ordersPrices { get; set; }
        public DateTime ordersTime { get; set; }
    }
}
