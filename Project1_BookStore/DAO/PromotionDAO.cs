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
    internal class PromotionDAO
    {
        internal static PromotionDTO findPromotionByID(string promoID)
        {
            var con = ConnectDB.openConnection();

            var sql = $"SELECT * FROM PROMOTION WHERE promoID = '{promoID}'";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string promoName = (string)reader["promoName"];
                float promoDiscount = (float)reader["promoDiscount"];
                string promoDesciption = (string)reader["promoDesciption"];
                var promoStartTime = (DateTime)reader["promoStartTime"];
                var promoEndTime = (DateTime)reader["promoEndTime"];
                
                var promo = new PromotionDTO()
                {
                    promoID = promoID,
                    promoName = promoName,
                    promoDiscount = promoDiscount,
                    promoDesciption = promoDesciption,
                    promoStartTime = promoStartTime,
                    promoEndTime = promoEndTime
                    
                };
                return promo;
            }
            reader.Close();
            return null;
        }

        internal static List<PromotionDTO> findAllPromotion()
        {
            var con = ConnectDB.openConnection();

            var sql = "SELECT * FROM PROMOTION";

            var command = new SqlCommand(sql, con);
            var reader = command.ExecuteReader();

            var promos = new List<PromotionDTO>();
            while (reader.Read())
            {
                string promoID = (string)reader["promoID"];         
                string promoName = (string)reader["promoName"];
                float promoDiscount = (float)reader["promoDiscount"];
                string promoDesciption = (string)reader["promoDescription"];
                var promoStartTime = (DateTime)reader["promoStartTime"];
                var promoEndTime = (DateTime)reader["promoEndTime"];

                var promo = new PromotionDTO()
                {
                    promoID = promoID,
                    promoName = promoName,
                    promoDiscount = promoDiscount,
                    promoDesciption = promoDesciption,
                    promoStartTime = promoStartTime,
                    promoEndTime = promoEndTime

                };
                promos.Add(promo);
            }
            reader.Close();
            return promos;
        }

        internal static bool InsertPromotion(PromotionDTO promo)
        {
            var con = ConnectDB.openConnection();

            var sql = "INSERT INTO PROMOTION(promoID, promoName,promoDiscount, promoDescription, promoStartTime, promoEndTime) " +
                $"VALUES('{promo.promoID}', N'{promo.promoName}', {promo.promoDiscount}, " +
                $"N'{promo.promoDesciption}', '{promo.promoStartTime}', '{promo.promoEndTime}')";
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

        internal static bool UpdatePromotion(PromotionDTO promo)
        {
            var con = ConnectDB.openConnection();

            var sql = $"UPDATE PROMOTION SET promoName = '{promo.promoName}', promoDiscount = {promo.promoDiscount}, promoDesciption = '{promo.promoDesciption}', " +
                $"promoStartTime = '{promo.promoStartTime}', promoEndTime = '{promo.promoEndTime}'" +
                $"WHERE promoID = {promo.promoID}";

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
