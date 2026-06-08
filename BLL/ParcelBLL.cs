using CourierDB.DAL;
using System.Data;

namespace CourierDB.BLL
{
    internal class ParcelBLL
    {
        private ParcelDAL dal = new ParcelDAL();

        public DataTable GetAllparcel() => dal.GetAllparcel();

        public DataTable GetPendingDeliveries() => dal.GetPendingDeliveries();

        public DataTable GetParcelByID(int parcelID) => dal.GetParcelByID(parcelID);

        public DataTable GetparcelByUser(int userID)
        {
            if (userID <= 0) throw new System.Exception("Invalid user ID.");
            return dal.GetparcelByUser(userID);
        }

        // Public tracking — no login required
        public DataTable TrackParcel(string trackingCode)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
                throw new System.Exception("Please enter a tracking code.");
            return dal.GetParcelByTrackingCode(trackingCode.Trim());
        }

        public string Updateparceltatus(int parcelID, string status,
                                         string location, string remarks, int updatedBy)
        {
            string[] valid = { "Processing", "Shipped", "OutForDelivery", "Delivered", "Cancelled" };
            if (System.Array.IndexOf(valid, status) < 0)
                return "Invalid status. Choose: Processing, Shipped, OutForDelivery, Delivered, Cancelled.";
            if (string.IsNullOrWhiteSpace(location))
                return "Location is required.";

            dal.Updateparceltatus(parcelID, status, location, remarks ?? "", updatedBy);
            return "Parcel status updated successfully.";
        }

        public DataTable GetTrackingLog(int parcelID)
        {
            if (parcelID <= 0) throw new System.Exception("Invalid parcel ID.");
            return dal.GetTrackingLog(parcelID);
        }
    }
}
