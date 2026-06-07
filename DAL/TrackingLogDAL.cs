using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System.Data;

namespace CourierDB.DAL
{
    internal class TrackingLogDAL
    {
        // ── Full tracking history for a parcel (used by frmTrackingLog) ───
        public DataTable GetLogByParcelID(int parcelID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", parcelID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT tl.log_id, tl.status, tl.location, tl.remarks, " +
                "tl.updated_at, u.name AS updated_by " +
                "FROM tracking_log tl " +
                "JOIN users u ON tl.updated_by = u.user_id " +
                "WHERE tl.parcel_id = @id " +
                "ORDER BY tl.updated_at ASC", p);
        }

        // ── Parcel header info for the frmTrackingLog summary panel ───────
        public DataTable GetParcelHeader(int parcelID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", parcelID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT p.shipment_id AS parcel_id, p.tracking_code, " +
                "p.sender_name, p.receiver_name, p.receiver_city, " +
                "p.status AS current_status, p.parcel_type, p.weight_kg " +
                "FROM parcel p " +
                "WHERE p.shipment_id = @id", p);
        }

        // ── Most recent log entry for a parcel ────────────────────────────
        public DataTable GetLatestLogEntry(int parcelID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", parcelID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT tl.log_id, tl.status, tl.location, tl.remarks, " +
                "tl.updated_at, u.name AS updated_by " +
                "FROM tracking_log tl " +
                "JOIN users u ON tl.updated_by = u.user_id " +
                "WHERE tl.parcel_id = @id " +
                "ORDER BY tl.updated_at DESC LIMIT 1", p);
        }

        // ── Count log entries for a parcel ────────────────────────────────
        public int GetLogCount(int parcelID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", parcelID) };
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "SELECT COUNT(*) AS cnt FROM tracking_log WHERE parcel_id = @id", p);
            if (dt.Rows.Count > 0)
                return System.Convert.ToInt32(dt.Rows[0]["cnt"]);
            return 0;
        }
    }
}
