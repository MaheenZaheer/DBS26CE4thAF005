using CourierDB.DAL;
using CourierDB.DomainClasses;
using System.Data;

namespace CourierDB.BLL
{
    internal class RateCardBLL
    {
        private RateCardDAL dal = new RateCardDAL();

        public DataTable GetAllRateCards() => dal.GetAllRateCards();

        public DataTable GetRateCardByCode(string code) => dal.GetRateCardByCode(code);

        public string AddRateCard(Discount d)
        {
            if (string.IsNullOrWhiteSpace(d.Code))  return "Rate code is required.";
            if (d.Value <= 0)                        return "Value must be greater than 0.";
            if (d.UsageLimit <= 0)                   return "Usage limit must be greater than 0.";

            string[] types = { "Percentage", "Fixed" };
            if (System.Array.IndexOf(types, d.Type) < 0)
                return "Type must be Percentage or Fixed.";

            if (d.ExpiryDate <= System.DateTime.Now)
                return "Expiry date must be in the future.";

            dal.AddRateCard(d);
            return "Rate card added successfully.";
        }

        public string UpdateRateCard(Discount d)
        {
            if (d.Value <= 0)      return "Value must be greater than 0.";
            if (d.UsageLimit <= 0) return "Usage limit must be greater than 0.";
            dal.UpdateRateCard(d);
            return "Rate card updated successfully.";
        }

        public void DeleteRateCard(int id) => dal.DeleteRateCard(id);
    }
}
