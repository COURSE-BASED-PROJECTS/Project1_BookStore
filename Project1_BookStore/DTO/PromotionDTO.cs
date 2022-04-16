using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.DTO
{
    internal class PromotionDTO
    {
        public string promoID { get; set; }
        public string promoName { get; set; }
        public float promoDiscount { get; set; }
        public string promoDesciption { get; set; }
        public DateTime promoStartTime { get; set; }
        public DateTime promoEndTime { get; set; }

    }
}
