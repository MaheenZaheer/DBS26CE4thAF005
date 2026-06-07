using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System.Data;

namespace CourierDB.DAL
{
    internal class RateCardDAL
    {
        public DataTable GetAllRateCards()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM rate_card ORDER BY discount_id DESC");
        }

        public DataTable GetRateCardByCode(string code)
        {
            MySqlParameter[] p = { new MySqlParameter("@code", code) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM rate_card WHERE code = @code", p);
        }

        // Discount class is still reused — it maps directly to rate_card columns
        public int AddRateCard(Discount d)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@code",       d.Code),
                new MySqlParameter("@type",       d.Type),
                new MySqlParameter("@value",      d.Value),
                new MySqlParameter("@expiry",     d.ExpiryDate),
                new MySqlParameter("@usageLimit", d.UsageLimit)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO rate_card (code, type, value, expiry_date, usage_limit) " +
                "VALUES (@code, @type, @value, @expiry, @usageLimit)", p);
        }

        public int UpdateRateCard(Discount d)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@type",       d.Type),
                new MySqlParameter("@value",      d.Value),
                new MySqlParameter("@expiry",     d.ExpiryDate),
                new MySqlParameter("@usageLimit", d.UsageLimit),
                new MySqlParameter("@id",         d.DiscountID)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE rate_card SET type=@type, value=@value, " +
                "expiry_date=@expiry, usage_limit=@usageLimit " +
                "WHERE discount_id=@id", p);
        }

        public int DeleteRateCard(int rateCardID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", rateCardID) };
            return DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM rate_card WHERE discount_id = @id", p);
        }
    }
}
