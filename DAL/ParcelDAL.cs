using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System.Data;

namespace CourierDB.DAL
{
    internal class ParcelDAL
    {
        // Get all parcel via view (used by frmManageParcel)
        public DataTable GetAllparcel()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM vw_parcelummary");
        }

        // Public tracking by tracking code (used by frmTrackParcel)
        public DataTable GetParcelByTrackingCode(string trackingCode)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@code", trackingCode)
            };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM vw_parcelummary WHERE tracking_code = @code", p);
        }

        // Get all parcel for a specific customer (uses SP)
        public DataTable GetparcelByUser(int userID)
        {
            MySqlParameter[] p = {
                new MySqlParameter("p_user_id", userID)
            };
            return DatabaseHelper.ExecuteStoredProcedure("sp_GetparcelByUser", p);
        }

        // Get parcel by ID
        public DataTable GetParcelByID(int parcelID)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@id", parcelID)
            };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM vw_parcelummary WHERE shipment_id = @id", p);
        }

        // Update parcel status + write tracking log (uses SP)
        public DataTable Updateparceltatus(int parcelID, string status,
                                            string location, string remarks, int updatedBy)
        {
            MySqlParameter[] p = {
                new MySqlParameter("p_parcel_id", parcelID),
                new MySqlParameter("p_status",    status),
                new MySqlParameter("p_location",  location),
                new MySqlParameter("p_remarks",   remarks),
                new MySqlParameter("p_user_id",   updatedBy)
            };
            return DatabaseHelper.ExecuteStoredProcedure("sp_Updateparceltatus", p);
        }

        // Get pending deliveries (used by frmDashboard / frmManageParcel)
        public DataTable GetPendingDeliveries()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM vw_PendingDeliveries");
        }

        // Get tracking log history for a parcel (used by frmTrackingLog)
        public DataTable GetTrackingLog(int parcelID)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@id", parcelID)
            };
            return DatabaseHelper.ExecuteQuery(
                "SELECT tl.log_id, tl.status, tl.location, tl.remarks, " +
                "tl.updated_at, u.name AS updated_by " +
                "FROM tracking_log tl " +
                "JOIN users u ON tl.updated_by = u.user_id " +
                "WHERE tl.parcel_id = @id " +
                "ORDER BY tl.updated_at ASC", p);
        }
    }
}
