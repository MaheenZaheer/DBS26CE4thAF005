using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmManageVehicles : Form
    {
        private int selectedVehicleID = -1;

        public frmManageVehicles()
        {
            InitializeComponent();
        }

        private void frmManageVehicles_Load(object sender, EventArgs e)
        {
            LoadBranches();
            LoadVehicles();
        }

        private void LoadBranches()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT branch_id, branch_name FROM branch ORDER BY branch_name");
                cmbBranch.DisplayMember = "branch_name";
                cmbBranch.ValueMember   = "branch_id";
                cmbBranch.DataSource    = dt;
                cmbBranch.SelectedIndex = -1;
            }
            catch { /* branches table may not exist — handled gracefully */ }
        }

        private void LoadVehicles()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT v.vehicle_id, v.registration_no, v.vehicle_type, " +
                    "v.capacity_kg, b.branch_name, v.is_available " +
                    "FROM vehicle v " +
                    "LEFT JOIN branch b ON v.branch_id = b.branch_id " +
                    "ORDER BY v.vehicle_id");
                dgvVehicles.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvVehicles.Rows[e.RowIndex];
            selectedVehicleID          = Convert.ToInt32(row.Cells["vehicle_id"].Value);
            txtRegNo.Text              = row.Cells["registration_no"].Value?.ToString();
            txtVehicleType.Text        = row.Cells["vehicle_type"].Value?.ToString();
            txtCapacityKg.Text         = row.Cells["capacity_kg"].Value?.ToString();
            chkAvailable.Checked       = Convert.ToBoolean(row.Cells["is_available"].Value);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtRegNo.Text))
            { MessageBox.Show("Registration number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrWhiteSpace(txtVehicleType.Text))
            { MessageBox.Show("Vehicle type is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!decimal.TryParse(txtCapacityKg.Text, out decimal cap) || cap <= 0)
            { MessageBox.Show("Enter a valid capacity (kg).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (cmbBranch.SelectedValue == null)
            { MessageBox.Show("Please select a branch.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                MySqlParameter[] p = {
                    new MySqlParameter("@reg",       txtRegNo.Text.Trim().ToUpper()),
                    new MySqlParameter("@type",      txtVehicleType.Text.Trim()),
                    new MySqlParameter("@cap",       decimal.Parse(txtCapacityKg.Text)),
                    new MySqlParameter("@branch",    cmbBranch.SelectedValue),
                    new MySqlParameter("@avail",     chkAvailable.Checked ? 1 : 0)
                };
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO vehicle (registration_no, vehicle_type, capacity_kg, branch_id, is_available) " +
                    "VALUES (@reg, @type, @cap, @branch, @avail)", p);
                MessageBox.Show("Vehicle added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadVehicles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedVehicleID < 0) { MessageBox.Show("Select a vehicle first.", "Info"); return; }
            if (!ValidateInput()) return;
            try
            {
                MySqlParameter[] p = {
                    new MySqlParameter("@reg",    txtRegNo.Text.Trim().ToUpper()),
                    new MySqlParameter("@type",   txtVehicleType.Text.Trim()),
                    new MySqlParameter("@cap",    decimal.Parse(txtCapacityKg.Text)),
                    new MySqlParameter("@branch", cmbBranch.SelectedValue),
                    new MySqlParameter("@avail",  chkAvailable.Checked ? 1 : 0),
                    new MySqlParameter("@id",     selectedVehicleID)
                };
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE vehicle SET registration_no=@reg, vehicle_type=@type, " +
                    "capacity_kg=@cap, branch_id=@branch, is_available=@avail WHERE vehicle_id=@id", p);
                MessageBox.Show("Vehicle updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadVehicles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedVehicleID < 0) { MessageBox.Show("Select a vehicle first.", "Info"); return; }
            if (MessageBox.Show("Delete this vehicle?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                MySqlParameter[] p = { new MySqlParameter("@id", selectedVehicleID) };
                DatabaseHelper.ExecuteNonQuery("DELETE FROM vehicle WHERE vehicle_id=@id", p);
                MessageBox.Show("Vehicle deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadVehicles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            selectedVehicleID     = -1;
            txtRegNo.Clear();
            txtVehicleType.Clear();
            txtCapacityKg.Clear();
            chkAvailable.Checked  = true;
            cmbBranch.SelectedIndex = -1;
            dgvVehicles.ClearSelection();
        }
    }
}
