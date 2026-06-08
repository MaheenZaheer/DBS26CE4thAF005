using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmManageParcel : Form
    {
        // Holds the shipment_id of the row selected in the grid
        private int selectedParcelID = 0;

        public frmManageParcel()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────────────────────
        private void frmManageParcel_Load(object sender, EventArgs e)
        {
            // Status dropdown
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[]
            {
                "Processing", "Shipped", "OutForDelivery", "Delivered"
            });
            cmbStatus.SelectedIndex = 0;

            // Parcel type dropdown
            cmbParcelType.Items.Clear();
            cmbParcelType.Items.AddRange(new string[]
            {
                "Document", "Fragile", "Electronics",
                "Clothing", "Medicine", "General"
            });
            cmbParcelType.SelectedIndex = 5;

            // Zone dropdown — loaded from DB
            LoadZones();

            // Grid settings
            dgvparcel.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvparcel.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvparcel.MultiSelect = false;
            dgvparcel.ReadOnly = true;

            // Parcel ID is auto-generated — readonly
            txtParcelID.ReadOnly = true;

            // Role-based UI restriction
            ApplyRoleRestrictions();

            Loadparcel();
        }

        // ─────────────────────────────────────────────────────────────
        // ROLE RESTRICTIONS
        // Customer can only see their own parcel and cannot add/edit
        // ─────────────────────────────────────────────────────────────
        private void ApplyRoleRestrictions()
        {
            if (frmDashboard.LoggedInRole == "Customer")
            {
                btnAddParcel.Visible = false;
                btnUpdateStatus.Visible = false;
                btnMarkDelivered.Visible = false;
                grpAddParcel.Text = "Your parcel (Read Only)";
            }
        }

        // ─────────────────────────────────────────────────────────────
        // LOAD ZONES INTO COMBOBOX
        // ─────────────────────────────────────────────────────────────
        private void LoadZones()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT zone_id, zone_name FROM delivery_zone WHERE is_active=1");
                cmbZone.DisplayMember = "zone_name";
                cmbZone.ValueMember = "zone_id";
                cmbZone.DataSource = dt;
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageParcel.LoadZones", ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // LOAD parcel INTO GRID
        // ─────────────────────────────────────────────────────────────
        private void Loadparcel()
        {
            try
            {
                string query;

                if (frmDashboard.LoggedInRole == "Admin")
                {
                    // Admin sees every parcel
                    query = @"SELECT
                                p.shipment_id     AS ParcelID,
                                p.tracking_code   AS TrackingCode,
                                p.sender_name     AS Sender,
                                p.receiver_name   AS Receiver,
                                p.receiver_phone  AS Phone,
                                p.receiver_city   AS City,
                                p.weight_kg       AS WeightKg,
                                p.parcel_type     AS Type,
                                p.status          AS Status,
                                p.courier_name    AS Courier,
                                p.shipped_at      AS ShippedAt,
                                p.delivered_at    AS DeliveredAt,
                                dz.zone_name      AS Zone
                              FROM parcel p
                              LEFT JOIN delivery_zone dz
                                ON p.zone_id = dz.zone_id
                              ORDER BY p.shipment_id DESC";
                }
                else if (frmDashboard.LoggedInRole == "Seller")
                {
                    // Staff sees parcel linked to their branch
                    query = @"SELECT
                                p.shipment_id     AS ParcelID,
                                p.tracking_code   AS TrackingCode,
                                p.sender_name     AS Sender,
                                p.receiver_name   AS Receiver,
                                p.receiver_phone  AS Phone,
                                p.receiver_city   AS City,
                                p.weight_kg       AS WeightKg,
                                p.parcel_type     AS Type,
                                p.status          AS Status,
                                p.courier_name    AS Courier,
                                p.shipped_at      AS ShippedAt,
                                p.delivered_at    AS DeliveredAt,
                                dz.zone_name      AS Zone
                              FROM parcel p
                              LEFT JOIN delivery_zone dz
                                ON p.zone_id = dz.zone_id
                              JOIN booking b ON p.order_id = b.order_id
                              JOIN branch br ON b.user_id  = br.user_id
                              WHERE br.user_id = @uid
                              ORDER BY p.shipment_id DESC";

                    dgvparcel.DataSource = DatabaseHelper.ExecuteQuery(
                        query,
                        new MySqlParameter[] {
                            new MySqlParameter("@uid",
                                frmDashboard.LoggedInUserID)
                        });
                    dgvparcel.ClearSelection();
                    return;
                }
                else
                {
                    // Customer sees only their own booking' parcel
                    query = @"SELECT
                                p.shipment_id     AS ParcelID,
                                p.tracking_code   AS TrackingCode,
                                p.sender_name     AS Sender,
                                p.receiver_name   AS Receiver,
                                p.receiver_city   AS City,
                                p.weight_kg       AS WeightKg,
                                p.parcel_type     AS Type,
                                p.status          AS Status,
                                p.shipped_at      AS ShippedAt,
                                p.delivered_at    AS DeliveredAt
                              FROM parcel p
                              JOIN booking b ON p.order_id = b.order_id
                              WHERE b.user_id = @uid
                              ORDER BY p.shipment_id DESC";

                    dgvparcel.DataSource = DatabaseHelper.ExecuteQuery(
                        query,
                        new MySqlParameter[] {
                            new MySqlParameter("@uid",
                                frmDashboard.LoggedInUserID)
                        });
                    dgvparcel.ClearSelection();
                    return;
                }

                dgvparcel.DataSource =
                    DatabaseHelper.ExecuteQuery(query);
                dgvparcel.ClearSelection();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageParcel.Loadparcel", ex.Message);
                MessageBox.Show("Error loading parcel:\n" + ex.Message,
                    "Load Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // GRID ROW CLICK — populate fields from selected row
        // ─────────────────────────────────────────────────────────────
        private void dgvparcel_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvparcel.Rows[e.RowIndex];

                selectedParcelID = Convert.ToInt32(
                    row.Cells["ParcelID"].Value);

                txtParcelID.Text = selectedParcelID.ToString();
                txtSenderName.Text = row.Cells["Sender"].Value?.ToString();
                txtReceiverName.Text = row.Cells["Receiver"].Value?.ToString();
                txtReceiverPhone.Text = row.Cells["Phone"] != null
                    ? row.Cells["Phone"].Value?.ToString() : "";
                txtReceiverCity.Text = row.Cells["City"].Value?.ToString();
                txtWeight.Text = row.Cells["WeightKg"].Value?.ToString();
                txtTrackingCode.Text = row.Cells["TrackingCode"].Value?.ToString();

                // Set combobox values safely
                string type = row.Cells["Type"].Value?.ToString();
                if (cmbParcelType.Items.Contains(type))
                    cmbParcelType.SelectedItem = type;

                string status = row.Cells["Status"].Value?.ToString();
                if (cmbStatus.Items.Contains(status))
                    cmbStatus.SelectedItem = status;

                lblSelectedInfo.Text =
                    $"Selected: {row.Cells["TrackingCode"].Value} " +
                    $"| {row.Cells["Receiver"].Value} " +
                    $"| {row.Cells["Status"].Value}";
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageParcel.CellClick", ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // ADD PARCEL — calls sp_CreateBooking stored procedure
        // ─────────────────────────────────────────────────────────────
        private void btnAddParcel_Click(object sender, EventArgs e)
        {
            try
            {
                // ── Validation ──
                if (string.IsNullOrWhiteSpace(txtSenderName.Text))
                { ShowWarning("Sender name is required."); return; }

                if (string.IsNullOrWhiteSpace(txtReceiverName.Text))
                { ShowWarning("Receiver name is required."); return; }

                if (string.IsNullOrWhiteSpace(txtReceiverPhone.Text))
                { ShowWarning("Receiver phone is required."); return; }

                if (string.IsNullOrWhiteSpace(txtReceiverCity.Text))
                { ShowWarning("Receiver city is required."); return; }

                if (!decimal.TryParse(txtWeight.Text.Trim(),
                    out decimal weight) || weight <= 0)
                { ShowWarning("Enter a valid weight (kg)."); return; }

                if (cmbZone.SelectedValue == null)
                { ShowWarning("Select a delivery zone."); return; }

                if (cmbParcelType.SelectedItem == null)
                { ShowWarning("Select a parcel type."); return; }

                // ── Get default address for logged-in user ──
                DataTable addrDT = DatabaseHelper.ExecuteQuery(
                    "SELECT address_id FROM address WHERE user_id=@uid LIMIT 1",
                    new MySqlParameter[] {
                        new MySqlParameter("@uid",
                            frmDashboard.LoggedInUserID)
                    });

                if (addrDT.Rows.Count == 0)
                {
                    ShowWarning("No address found for this user.\n" +
                        "Please add an address first.");
                    return;
                }

                int addressID = Convert.ToInt32(
                    addrDT.Rows[0]["address_id"]);

                // ── Call stored procedure sp_CreateBooking ──

                DataTable result = DatabaseHelper.ExecuteStoredProcedure(
    "sp_CreateBooking",
    new MySqlParameter[] {
        new MySqlParameter("p_user_id",      frmDashboard.LoggedInUserID),
        new MySqlParameter("p_sender_name",  txtSenderName.Text.Trim()),
        new MySqlParameter("p_recv_name",    txtReceiverName.Text.Trim()),
        new MySqlParameter("p_recv_phone",   txtReceiverPhone.Text.Trim()),
        new MySqlParameter("p_recv_city",    txtReceiverCity.Text.Trim()),
        new MySqlParameter("p_weight",       weight),
        new MySqlParameter("p_type",         cmbParcelType.SelectedItem.ToString()),
        new MySqlParameter("p_zone_id",      Convert.ToInt32(cmbZone.SelectedValue)),
        new MySqlParameter("p_address_id",   addressID),
        new MySqlParameter("p_method",       "Cash"),
        new MySqlParameter("p_branch_id",    1),   // default branch
        new MySqlParameter("p_declared_value", 0)  // default declared value
    });

                //DataTable result = DatabaseHelper.ExecuteStoredProcedure(
                //    "sp_CreateBooking",
                //    new MySqlParameter[] {
                //        new MySqlParameter("p_user_id",
                //            frmDashboard.LoggedInUserID),
                //        new MySqlParameter("p_sender_name",
                //            txtSenderName.Text.Trim()),
                //        new MySqlParameter("p_recv_name",
                //            txtReceiverName.Text.Trim()),
                //        new MySqlParameter("p_recv_phone",
                //            txtReceiverPhone.Text.Trim()),
                //        new MySqlParameter("p_recv_city",
                //            txtReceiverCity.Text.Trim()),
                //        new MySqlParameter("p_weight",    weight),
                //        new MySqlParameter("p_type",
                //            cmbParcelType.SelectedItem.ToString()),
                //        new MySqlParameter("p_zone_id",
                //            Convert.ToInt32(cmbZone.SelectedValue)),
                //        new MySqlParameter("p_address_id", addressID),
                //        new MySqlParameter("p_method",    "Cash")
                //    });

                if (result != null && result.Rows.Count > 0)
                {
                    string trackCode =
                        result.Rows[0]["TrackingCode"].ToString();
                    decimal charge =
                        Convert.ToDecimal(result.Rows[0]["Charge"]);

                    MessageBox.Show(
                        $"✔ Parcel booked successfully!\n\n" +
                        $"Tracking Code : {trackCode}\n" +
                        $"Delivery Charge: Rs. {charge:N0}",
                        "Booking Confirmed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                ClearFields();
                Loadparcel();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageParcel.btnAddParcel", ex.Message);
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // UPDATE STATUS — calls sp_Updateparceltatus
        // ─────────────────────────────────────────────────────────────
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedParcelID == 0)
                { ShowWarning("Select a parcel from the grid first."); return; }

                if (cmbStatus.SelectedItem == null)
                { ShowWarning("Select a status."); return; }

                string newStatus = cmbStatus.SelectedItem.ToString();
                string location = txtReceiverCity.Text.Trim();
                string remarks = $"Status changed to {newStatus} " +
                                   $"by {frmDashboard.LoggedInUserName}";

                DataTable result = DatabaseHelper.ExecuteStoredProcedure(
                    "sp_UpdateParcelStatus",
                    new MySqlParameter[] {
                        new MySqlParameter("p_parcel_id",
                            selectedParcelID),
                        new MySqlParameter("p_status",   newStatus),
                        new MySqlParameter("p_location", location),
                        new MySqlParameter("p_remarks",  remarks),
                        new MySqlParameter("p_user_id",
                            frmDashboard.LoggedInUserID)
                    });

                MessageBox.Show("✔ Status updated to: " + newStatus,
                    "Updated", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Loadparcel();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageParcel.btnUpdateStatus",
                    ex.Message);
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // MARK DELIVERED — sets delivered_at, trigger updates booking
        // ─────────────────────────────────────────────────────────────
        private void btnMarkDelivered_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedParcelID == 0)
                { ShowWarning("Select a parcel from the grid first."); return; }

                DialogResult confirm = MessageBox.Show(
                    "Mark this parcel as Delivered?\n" +
                    "This cannot be undone.",
                    "Confirm Delivery",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                // Uses sp_Updateparceltatus which also sets delivered_at
                DatabaseHelper.ExecuteStoredProcedure(
                    "sp_UpdateParcelStatus",
                    new MySqlParameter[] {
                        new MySqlParameter("p_parcel_id",
                            selectedParcelID),
                        new MySqlParameter("p_status",   "Delivered"),
                        new MySqlParameter("p_location",
                            txtReceiverCity.Text.Trim()),
                        new MySqlParameter("p_remarks",
                            "Delivered by " +
                            frmDashboard.LoggedInUserName),
                        new MySqlParameter("p_user_id",
                            frmDashboard.LoggedInUserID)
                    });

                MessageBox.Show(
                    "✔ Parcel marked as Delivered.\n" +
                    "Booking status updated automatically.",
                    "Delivered",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearFields();
                Loadparcel();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageParcel.btnMarkDelivered",
                    ex.Message);
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // REFRESH
        // ─────────────────────────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            Loadparcel();
        }

        // ─────────────────────────────────────────────────────────────
        // CLEAR FIELDS
        // ─────────────────────────────────────────────────────────────
        private void ClearFields()
        {
            selectedParcelID = 0;
            txtParcelID.Text = "";
            txtSenderName.Text = "";
            txtReceiverName.Text = "";
            txtReceiverPhone.Text = "";
            txtReceiverCity.Text = "";
            txtWeight.Text = "";
            txtTrackingCode.Text = "";
            lblSelectedInfo.Text = "No parcel selected";
            cmbStatus.SelectedIndex = 0;
            cmbParcelType.SelectedIndex = 5;
            if (cmbZone.Items.Count > 0)
                cmbZone.SelectedIndex = 0;
        }

        // ─────────────────────────────────────────────────────────────
        // HELPER
        // ─────────────────────────────────────────────────────────────
        private void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ── Unused stubs kept so Designer compiles ──
        private void cmbStatus_SelectedIndexChanged(object sender,
            EventArgs e)
        { }
        private void cmbParcelType_SelectedIndexChanged(object sender,
            EventArgs e)
        { }
        private void cmbZone_SelectedIndexChanged(object sender,
            EventArgs e)
        { }
        private void txtWeight_TextChanged(object sender, EventArgs e) { }
        private void txtSenderName_TextChanged(object sender,
            EventArgs e)
        { }
        private void txtReceiverName_TextChanged(object sender,
            EventArgs e)
        { }
        private void txtReceiverPhone_TextChanged(object sender,
            EventArgs e)
        { }
        private void txtReceiverCity_TextChanged(object sender,
            EventArgs e)
        { }
        private void txtTrackingCode_TextChanged(object sender,
            EventArgs e)
        { }
        private void txtParcelID_TextChanged(object sender,
            EventArgs e)
        { }

        // Old _Click_1 stubs (designer compatibility)
        private void btnAddShipment_Click_1(object sender,
            EventArgs e)
        { }
        private void btnUpdateStatus_Click_1(object sender,
            EventArgs e)
        { }
        private void btnMarkDelivered_Click_1(object sender,
            EventArgs e)
        { }
        private void btnRefresh_Click_1(object sender, EventArgs e) { }
        private void frmManageParcel_Load_1(object sender,
            EventArgs e)
        { }
    }
}
