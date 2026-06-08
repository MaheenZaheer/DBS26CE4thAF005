using CourierDB.DAL;
using CourierDB.SoftwareClasses;
using System.Data;

namespace CourierDB.BLL
{
    internal class BookingBLL
    {
        private BookingDAL dal = new BookingDAL();

        // Called from frmManageBooking — creates full booking in one SP call
        public string CreateBooking(int userID, string senderName,
            string recvName, string recvPhone, string recvCity,
            decimal weight, string parcelType, int zoneID,
            int addressID, string payMethod, int branchID, decimal declaredValue,
            out DataTable result)
        {
            result = null;

            if (!Validator.IsNotEmpty(senderName))  return "Sender name is required.";
            if (!Validator.IsNotEmpty(recvName))     return "Receiver name is required.";
            if (!Validator.IsValidPhone(recvPhone))  return "Receiver phone must be 11 digits starting 03.";
            if (!Validator.IsNotEmpty(recvCity))     return "Receiver city is required.";
            if (weight <= 0)                         return "Weight must be greater than 0.";
            if (!Validator.IsNotEmpty(parcelType))   return "Parcel type is required.";

            string[] methods = { "Cash", "Card", "EasyPaisa", "JazzCash" };
            if (System.Array.IndexOf(methods, payMethod) < 0)
                return "Invalid payment method.";

            result = dal.CreateBooking(userID, senderName, recvName, recvPhone,
                         recvCity, weight, parcelType, zoneID,
                         addressID, payMethod, branchID, declaredValue);
            return "Booking created successfully.";
        }

        public DataTable GetAllbooking() => dal.GetAllbooking();

        public DataTable GetbookingByUser(int userID) => dal.GetbookingByUser(userID);

        public string Updatebookingtatus(int bookingID, string status)
        {
            string[] valid = { "Pending", "Confirmed", "Shipped", "Delivered", "Cancelled" };
            if (System.Array.IndexOf(valid, status) < 0)
                return "Invalid status.";
            dal.Updatebookingtatus(bookingID, status);
            return "Booking status updated.";
        }
    }
}
