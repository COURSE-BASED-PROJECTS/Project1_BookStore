using Project1_BookStore.DAO;
using Project1_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.BUS
{
    internal class PromotionDetailBUS
    {
        public static bool InsertPromotionDetail(PromotionDetailDTO promo)
        {
            return PromotionDetailDAO.InsertPromotionDetail(promo);
        }
    }
}
