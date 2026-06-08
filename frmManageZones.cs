using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmManageZones : Form
    {
        private int selectedZoneID = -1;

        public frmManageZones()
        {
            InitializeComponent();
        }

        private void frmManageZones_Load(object sender, EventArgs e)
        {
            LoadZones();
        }

        private void LoadZones()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT zone_id, zone_name, cities, base_rate, per_kg_rate, is_active " +
                    "FROM delivery_zone ORDER BY zone_id");
                dgvZones.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvZones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvZones.Rows[e.RowIndex];
            selectedZoneID            = Convert.ToInt32(row.Cells["zone_id"].Value);
            txtZoneName.Text          = row.Cells["zone_name"].Value?.ToString();
            txtCities.Text            = row.Cells["cities"].Value?.ToString();
            txtBaseRate.Text          = row.Cells["base_rate"].Value?.ToString();
            txtPerKgRate.Text         = row.Cells["per_kg_rate"].Value?.ToString();
            chkIsActive.Checked       = Convert.ToBoolean(row.Cells["is_active"].Value);
        }

        private bool ValidateZone()
        {
            if (string.IsNullOrWhiteSpace(txtZoneName.Text))
            { MessageBox.Show("Zone name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrWhiteSpace(txtCities.Text))
            { MessageBox.Show("Cities are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!decimal.TryParse(txtBaseRate.Text, out decimal br) || br < 0)
            { MessageBox.Show("Enter a valid base rate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!decimal.TryParse(txtPerKgRate.Text, out decimal pkr) || pkr < 0)
            { MessageBox.Show("Enter a valid per-kg rate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateZone()) return;
            try
            {
                MySqlParameter[] p = {
                    new MySqlParameter("@name",     txtZoneName.Text.Trim()),
                    new MySqlParameter("@cities",   txtCities.Text.Trim()),
                    new MySqlParameter("@base",     decimal.Parse(txtBaseRate.Text)),
                    new MySqlParameter("@perkg",    decimal.Parse(txtPerKgRate.Text)),
                    new MySqlParameter("@active",   chkIsActive.Checked ? 1 : 0)
                };
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO delivery_zone (zone_name, cities, base_rate, per_kg_rate, is_active) " +
                    "VALUES (@name, @cities, @base, @perkg, @active)", p);
                MessageBox.Show("Zone added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadZones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedZoneID < 0) { MessageBox.Show("Select a zone first.", "Info"); return; }
            if (!ValidateZone()) return;
            try
            {
                MySqlParameter[] p = {
                    new MySqlParameter("@name",   txtZoneName.Text.Trim()),
                    new MySqlParameter("@cities", txtCities.Text.Trim()),
                    new MySqlParameter("@base",   decimal.Parse(txtBaseRate.Text)),
                    new MySqlParameter("@perkg",  decimal.Parse(txtPerKgRate.Text)),
                    new MySqlParameter("@active", chkIsActive.Checked ? 1 : 0),
                    new MySqlParameter("@id",     selectedZoneID)
                };
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE delivery_zone SET zone_name=@name, cities=@cities, " +
                    "base_rate=@base, per_kg_rate=@perkg, is_active=@active WHERE zone_id=@id", p);
                MessageBox.Show("Zone updated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadZones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedZoneID < 0) { MessageBox.Show("Select a zone first.", "Info"); return; }
            if (MessageBox.Show("Delete this zone?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                MySqlParameter[] p = { new MySqlParameter("@id", selectedZoneID) };
                DatabaseHelper.ExecuteNonQuery("DELETE FROM delivery_zone WHERE zone_id=@id", p);
                MessageBox.Show("Zone deleted.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadZones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            selectedZoneID    = -1;
            txtZoneName.Clear();
            txtCities.Clear();
            txtBaseRate.Clear();
            txtPerKgRate.Clear();
            chkIsActive.Checked = true;
            dgvZones.ClearSelection();
        }
    }
}
