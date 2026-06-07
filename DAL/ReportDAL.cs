using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CourierDB.DAL
{
    /// <summary>
    /// ReportDAL — CourierDB version.
    /// Replaces old EC stored procedures (sp_GetSalesReport, sp_GetInventoryReport,
    /// sp_GetTopSellingProducts) and EC views (vw_LowStockAlert, vw_RevenueByCategory,
    /// vw_CustomerHistory) with courier-specific equivalents.
    /// </summary>
    internal class ReportDAL
    {
        // ── 1. Revenue Report via sp_GetRevenueReport ──────────────────────
        // Returns per-booking revenue in a date range (replaces sp_GetSalesReport).
        // ReportDAL.cs — Fix GetRevenueReport()
        public DataTable GetRevenueReport(DateTime startDate, DateTime endDate)
        {
            MySqlParameter[] p = {
        new MySqlParameter("p_from_date", startDate),  // ✅ matches SP
        new MySqlParameter("p_to_date",   endDate)     // ← was "p_end_date"
    };
            return DatabaseHelper.ExecuteStoredProcedure("sp_GetRevenueReport", p);
        }

        //public DataTable GetRevenueReport(DateTime startDate, DateTime endDate)
        //{
        //    MySqlParameter[] p = {
        //        new MySqlParameter("p_start_date", startDate),
        //        new MySqlParameter("p_end_date",   endDate)
        //    };
        //    return DatabaseHelper.ExecuteStoredProcedure("sp_GetRevenueReport", p);
        //}

        // ── 2. Revenue by Branch via vw_RevenueByBranch ───────────────────
        // Replaces vw_RevenueByCategory.
        public DataTable GetRevenueByBranch()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM vw_RevenueByBranch");
        }

        // ── 3. Zone Performance via vw_ZonePerformance ────────────────────
        // Replaces vw_LowStockAlert — shows parcel counts / avg weight per zone.
        public DataTable GetZonePerformance()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM vw_ZonePerformance");
        }

        // ── 4. Staff Workload via vw_StaffWorkload ────────────────────────
        // Replaces vw_CustomerHistory — shows parcel updates handled per staff member.
        public DataTable GetStaffWorkload()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM vw_StaffWorkload");
        }

        // ── 5. Complaint Summary via vw_ComplaintSummary ──────────────────
        public DataTable GetComplaintSummary()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM vw_ComplaintSummary ORDER BY filed_at DESC");
        }

        // ── 6. Pending Deliveries (already used by frmDashboard) ──────────
        public DataTable GetPendingDeliveries()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM vw_PendingDeliveries");
        }

        // ── 7. Parcel Volume by Date Range ────────────────────────────────
        // Quick operational report: how many parcel were booked/delivered.
        public DataTable GetParcelVolumeReport(DateTime startDate, DateTime endDate)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@start", startDate),
                new MySqlParameter("@end",   endDate)
            };
            return DatabaseHelper.ExecuteQuery(
                "SELECT DATE(b.order_date)  AS booking_date, " +
                "       COUNT(p.shipment_id) AS total_parcel, " +
                "       SUM(b.total_amount)  AS total_revenue, " +
                "       SUM(CASE WHEN p.status = 'Delivered' THEN 1 ELSE 0 END) AS delivered, " +
                "       SUM(CASE WHEN p.status = 'Cancelled' THEN 1 ELSE 0 END) AS cancelled " +
                "FROM booking b " +
                "JOIN parcel p ON b.order_id = p.order_id " +
                "WHERE b.order_date BETWEEN @start AND @end " +
                "GROUP BY DATE(b.order_date) " +
                "ORDER BY booking_date DESC", p);
        }
    }
}
