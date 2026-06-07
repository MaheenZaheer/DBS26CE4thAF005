using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System.Data;

namespace CourierDB.DAL
{
    internal class ComplaintDAL
    {
        // ── File a complaint via sp_FileComplaint ──────────────────────────
        public DataTable FileComplaint(int userID, int? parcelID,
                                       string subject, string description)
        {
            MySqlParameter[] p = {
                new MySqlParameter("p_user_id",     userID),
                new MySqlParameter("p_parcel_id",   parcelID.HasValue ? (object)parcelID.Value : System.DBNull.Value),
                new MySqlParameter("p_subject",     subject),
                new MySqlParameter("p_description", description)
            };
            return DatabaseHelper.ExecuteStoredProcedure("sp_FileComplaint", p);
        }

        // ── Resolve a complaint via sp_ResolveComplaint ────────────────────
        public DataTable ResolveComplaint(int complaintID, int resolvedBy, string remarks)
        {
            MySqlParameter[] p = {
                new MySqlParameter("p_complaint_id", complaintID),
                new MySqlParameter("p_resolved_by",  resolvedBy),
                new MySqlParameter("p_remarks",      remarks)
            };
            return DatabaseHelper.ExecuteStoredProcedure("sp_ResolveComplaint", p);
        }

        // ── All complaints via vw_ComplaintSummary (Admin) ─────────────────
        public DataTable GetAllComplaints()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM vw_ComplaintSummary ORDER BY filed_at DESC");
        }

        // ── Complaints for a specific user ────────────────────────────────
        public DataTable GetComplaintsByUser(int userID)
        {
            MySqlParameter[] p = { new MySqlParameter("@uid", userID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM vw_ComplaintSummary WHERE user_id = @uid ORDER BY filed_at DESC", p);
        }

        // ── Single complaint by ID ─────────────────────────────────────────
        public DataTable GetComplaintByID(int complaintID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", complaintID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM vw_ComplaintSummary WHERE complaint_id = @id", p);
        }
    }
}
