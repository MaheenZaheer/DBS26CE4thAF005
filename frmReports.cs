using CourierDB.DAL;
using CourierDB.SoftwareClasses;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmReports : Form
    {
        private ReportDAL reportDAL = new ReportDAL();

        public frmReports() { InitializeComponent(); }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // Set default date range — last 30 days
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            lblReportTitle.Text = "Select a report from the buttons above";
        }

        // ── Helper — applies standard grid settings after every load ──────
        private void ApplyGridSettings()
        {
            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ── Sales Report (uses date pickers) ──────────────────────────────
        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpStartDate.Value > dtpEndDate.Value)
                { MessageBox.Show("Start date cannot be after end date."); return; }

                DataTable dt = reportDAL.GetRevenueReport(
    dtpStartDate.Value, dtpEndDate.Value);
                dgvReport.DataSource = null;
                dgvReport.DataSource = dt;
                ApplyGridSettings();

                lblReportTitle.Text = string.Format(
                    "Sales Report  |  {0:dd-MMM-yyyy}  to  {1:dd-MMM-yyyy}  |  {2} records",
                    dtpStartDate.Value, dtpEndDate.Value, dt.Rows.Count);

                if (dt.Rows.Count == 0)
                    MessageBox.Show("No sales found in this date range.");
            }
            catch (Exception ex)
            {
                Logger.LogError("frmReports", ex.Message);
                MessageBox.Show("Error loading sales report: " + ex.Message);
            }
        }

        // ── Inventory Report ──────────────────────────────────────────────
        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReport.DataSource = null;
                dgvReport.DataSource = reportDAL.GetZonePerformance();
                ApplyGridSettings();
                lblReportTitle.Text = "Inventory Report  |  All products with stock levels";
            }
            catch (Exception ex)
            {
                Logger.LogError("frmReports", ex.Message);
                MessageBox.Show("Error loading inventory report: " + ex.Message);
            }
        }

        // ── Top 10 Selling Products ───────────────────────────────────────
        private void btnTopProducts_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReport.DataSource = null;
                dgvReport.DataSource = reportDAL.GetStaffWorkload();
                ApplyGridSettings();
                lblReportTitle.Text = "Top 10 Best Selling Products";
            }
            catch (Exception ex)
            {
                Logger.LogError("frmReports", ex.Message);
                MessageBox.Show("Error loading top products: " + ex.Message);
            }
        }

        // ── Low Stock Alert ───────────────────────────────────────────────
        private void btnLowStock_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReport.DataSource = null;
                dgvReport.DataSource = reportDAL.GetRevenueByBranch();
                ApplyGridSettings();
                lblReportTitle.Text = "Low Stock Alert  |  Products at or below threshold";
            }
            catch (Exception ex)
            {
                Logger.LogError("frmReports", ex.Message);
                MessageBox.Show("Error loading low stock report: " + ex.Message);
            }
        }

        // ── Revenue by Category ───────────────────────────────────────────
        private void btnRevenueByCategory_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReport.DataSource = null;
                dgvReport.DataSource = reportDAL.GetRevenueByBranch();
                ApplyGridSettings();
                lblReportTitle.Text = "Revenue by Branch";
            }
            catch (Exception ex)
            {
                Logger.LogError("frmReports", ex.Message);
                MessageBox.Show("Error loading revenue report: " + ex.Message);
            }
        }

        // ── Customer Purchase History ─────────────────────────────────────
        private void btnCustomerHistory_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReport.DataSource = null;
                dgvReport.DataSource = reportDAL.GetStaffWorkload();
                ApplyGridSettings();
                lblReportTitle.Text = "Staff Workload";
            }
            catch (Exception ex)
            {
                Logger.LogError("frmReports", ex.Message);
                MessageBox.Show("Error loading customer history: " + ex.Message);
            }
        }

        // ── Export current grid to CSV ────────────────────────────────────
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dgvReport.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                { MessageBox.Show("No report loaded to export."); return; }

                // Build CSV content
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                // Header row
                foreach (DataColumn col in dt.Columns)
                {
                    sb.Append(col.ColumnName);
                    sb.Append(",");
                }
                sb.AppendLine();

                // Data rows
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        sb.Append(item.ToString().Replace(",", ";"));
                        sb.Append(",");
                    }
                    sb.AppendLine();
                }

                // Save file to Desktop so you can find it easily
                string fileName = "Report_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                string filePath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    fileName);

                System.IO.File.WriteAllText(filePath, sb.ToString());
                MessageBox.Show("Report saved to Desktop:\n" + fileName);
            }
            catch (Exception ex)
            {
                Logger.LogError("frmReports", ex.Message);
                MessageBox.Show("Export failed: " + ex.Message);
            }
        }
    }
}