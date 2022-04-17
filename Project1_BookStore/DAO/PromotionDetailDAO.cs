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
    internal class PromotionDetailDAO
    {
        internal static bool InsertPromotionDetail(PromotionDetailDTO promo)
        {
            var con = ConnectDB.openConnection();

            var sql = "INSERT INTO PROMOTIONDETAIL(promoID, tobID) " +
                $"VALUES('{promo.promoID}', '{promo.tobID}')";

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
