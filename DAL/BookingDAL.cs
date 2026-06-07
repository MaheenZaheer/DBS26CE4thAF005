using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System.Data;

namespace CourierDB.DAL
{
    internal class BookingDAL
    {
        // Full booking creation (booking + parcel + payment in one SP)
        public DataTable CreateBooking(int userID, string senderName,
            string recvName, string recvPhone, string recvCity,
            decimal weight, string parcelType, int zoneID,
            int addressID, string payMethod, int branchID, decimal declaredValue)
        {
            MySqlParameter[] p = {
                new MySqlParameter("p_user_id",        userID),
                new MySqlParameter("p_sender_name",    senderName),
                new MySqlParameter("p_recv_name",      recvName),
                new MySqlParameter("p_recv_phone",     recvPhone),
                new MySqlParameter("p_recv_city",      recvCity),
                new MySqlParameter("p_weight",         weight),
                new MySqlParameter("p_type",           parcelType),
                new MySqlParameter("p_zone_id",        zoneID),
                new MySqlParameter("p_address_id",     addressID),
                new MySqlParameter("p_method",         payMethod),
                new MySqlParameter("p_branch_id",      branchID),
                new MySqlParameter("p_declared_value", declaredValue)
            };
            return DatabaseHelper.ExecuteStoredProcedure("sp_CreateBooking", p);
        }

        // Get all booking (admin view)
        public DataTable GetAllbooking()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT b.order_id, b.user_id, u.name AS customer_name, " +
                "b.total_amount, b.discount_applied, b.status, b.order_date " +
                "FROM booking b " +
                "JOIN users u ON b.user_id = u.user_id " +
                "ORDER BY b.order_date DESC");
        }

        // Get booking for a specific customer
        public DataTable GetbookingByUser(int userID)
        {
            MySqlParameter[] p = { new MySqlParameter("@userID", userID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT b.order_id, b.total_amount, b.discount_applied, " +
                "b.status, b.order_date " +
                "FROM booking b " +
                "WHERE b.user_id = @userID " +
                "ORDER BY b.order_date DESC", p);
        }

        // Update booking status manually
        public int Updatebookingtatus(int bookingID, string status)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@status",    status),
                new MySqlParameter("@bookingID", bookingID)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE booking SET status = @status WHERE order_id = @bookingID", p);
        }
    }
}
