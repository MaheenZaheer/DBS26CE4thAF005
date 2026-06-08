using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmTrackParcel : Form
    {
        public frmTrackParcel()
        {
            InitializeComponent();
        }

        private void btnTrack_Click(object sender, EventArgs e)
        {
            string code = txtTrackingCode.Text.Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please enter a tracking code.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlParameter[] p = { new MySqlParameter("@code", code) };
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT p.shipment_id, p.tracking_code, p.sender_name, " +
                    "p.receiver_name, p.receiver_city, p.weight_kg, p.parcel_type, " +
                    "p.status, " +
                    "COALESCE(dz.zone_name, 'N/A')           AS zone_name, " +
                    "COALESCE(pay.amount, 0)                  AS total_amount, " +
                    "COALESCE(b.order_date, p.shipped_at)     AS booking_date " +
                    "FROM parcel p " +
                    "LEFT JOIN delivery_zone dz  ON p.zone_id  = dz.zone_id " +
                    "LEFT JOIN booking       b   ON p.order_id = b.order_id " +
                    "LEFT JOIN payment       pay ON b.order_id = pay.order_id " +
                    "WHERE p.tracking_code = @code", p);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No parcel found with tracking code: " + code,
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvResult.DataSource = null;
                    ClearDetails();
                    return;
                }

                dgvResult.DataSource = dt;
                LoadParcelDetails(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadParcelDetails(DataRow row)
        {
            lblTrackingCodeVal.Text = row["tracking_code"]?.ToString() ?? "-";
            lblSenderVal.Text       = row["sender_name"]?.ToString()   ?? "-";
            lblReceiverVal.Text     = row["receiver_name"]?.ToString() ?? "-";
            lblReceiverCityVal.Text = row["receiver_city"]?.ToString() ?? "-";
            lblWeightVal.Text       = row["weight_kg"]?.ToString()     ?? "-";
            lblParcelTypeVal.Text   = row["parcel_type"]?.ToString()   ?? "-";
            lblStatusVal.Text       = row["status"]?.ToString()        ?? "-";
            lblZoneVal.Text         = row["zone_name"]?.ToString()     ?? "-";
            lblAmountVal.Text       = row["total_amount"]?.ToString()  ?? "-";
            lblBookedOnVal.Text     = row["booking_date"]?.ToString()  ?? "-";

            // Color-code status value
            switch (lblStatusVal.Text)
            {
                case "Delivered":      lblStatusVal.ForeColor = Color.LimeGreen; break;
                case "Cancelled":      lblStatusVal.ForeColor = Color.Tomato;    break;
                case "OutForDelivery": lblStatusVal.ForeColor = Color.Orange;    break;
                default:               lblStatusVal.ForeColor = Color.FromArgb(230, 180, 80); break;
            }

            if (row["shipment_id"] != DBNull.Value)
                LoadTrackingLog(Convert.ToInt32(row["shipment_id"]));
        }

        private void LoadTrackingLog(int parcelID)
        {
            try
            {
                MySqlParameter[] p = { new MySqlParameter("@id", parcelID) };
                DataTable log = DatabaseHelper.ExecuteQuery(
                    "SELECT tl.log_id, tl.status, tl.location, tl.remarks, " +
                    "tl.updated_at, u.name AS updated_by " +
                    "FROM tracking_log tl " +
                    "JOIN users u ON tl.updated_by = u.user_id " +
                    "WHERE tl.parcel_id = @id " +
                    "ORDER BY tl.updated_at DESC", p);

                dgvLog.DataSource = log;

                // Friendly column headers
                if (dgvLog.Columns.Contains("log_id"))      dgvLog.Columns["log_id"].HeaderText      = "Log ID";
                if (dgvLog.Columns.Contains("updated_at"))  dgvLog.Columns["updated_at"].HeaderText  = "Date/Time";
                if (dgvLog.Columns.Contains("status"))      dgvLog.Columns["status"].HeaderText      = "Status";
                if (dgvLog.Columns.Contains("location"))    dgvLog.Columns["location"].HeaderText    = "Location";
                if (dgvLog.Columns.Contains("remarks"))     dgvLog.Columns["remarks"].HeaderText     = "Remarks";
                if (dgvLog.Columns.Contains("updated_by"))  dgvLog.Columns["updated_by"].HeaderText  = "Updated By";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tracking log error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDetails()
        {
            lblTrackingCodeVal.Text = lblSenderVal.Text   = lblReceiverVal.Text =
            lblReceiverCityVal.Text = lblWeightVal.Text   = lblParcelTypeVal.Text =
            lblStatusVal.Text       = lblZoneVal.Text     =
            lblAmountVal.Text       = lblBookedOnVal.Text = "-";
            lblStatusVal.ForeColor  = Color.FromArgb(240, 240, 240);
            dgvLog.DataSource       = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTrackingCode.Clear();
            dgvResult.DataSource = null;
            dgvLog.DataSource    = null;
            ClearDetails();
            txtTrackingCode.Focus();
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvResult.DataSource == null) return;
            DataRow row = ((DataTable)dgvResult.DataSource).Rows[e.RowIndex];
            LoadParcelDetails(row);
        }
    }
}
