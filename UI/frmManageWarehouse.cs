using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmManageWarehouse : Form
    {
        private int selectedWarehouseID = -1;

        public frmManageWarehouse()
        {
            InitializeComponent();
        }

        private void frmManageWarehouse_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
        }

        private void LoadWarehouses()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT warehouse_id, name, city, address, " +
                    "capacity_units, used_units, is_active FROM warehouse ORDER BY warehouse_id");
                dgvWarehouses.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvWarehouses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvWarehouses.Rows[e.RowIndex];
            selectedWarehouseID          = Convert.ToInt32(row.Cells["warehouse_id"].Value);
            txtWHName.Text               = row.Cells["warehouse_name"].Value?.ToString();
            txtCity.Text                 = row.Cells["city"].Value?.ToString();
            txtAddress.Text              = row.Cells["address"].Value?.ToString();
            txtCapacity.Text             = row.Cells["capacity_units"].Value?.ToString();
            txtUsed.Text                 = row.Cells["used_units"].Value?.ToString();
            chkIsActive.Checked          = Convert.ToBoolean(row.Cells["is_active"].Value);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtWHName.Text))
            { MessageBox.Show("Warehouse name is required.", "Validation"); return false; }
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            { MessageBox.Show("City is required.", "Validation"); return false; }
            if (!int.TryParse(txtCapacity.Text, out int cap) || cap <= 0)
            { MessageBox.Show("Enter a valid capacity.", "Validation"); return false; }
            if (!int.TryParse(txtUsed.Text, out int used) || used < 0 || used > cap)
            { MessageBox.Show("Used units must be 0 or more and ≤ capacity.", "Validation"); return false; }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                MySqlParameter[] p = {
                    new MySqlParameter("@name",    txtWHName.Text.Trim()),
                    new MySqlParameter("@city",    txtCity.Text.Trim()),
                    new MySqlParameter("@addr",    txtAddress.Text.Trim()),
                    new MySqlParameter("@cap",     int.Parse(txtCapacity.Text)),
                    new MySqlParameter("@used",    int.Parse(txtUsed.Text)),
                    new MySqlParameter("@active",  chkIsActive.Checked ? 1 : 0)
                };
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO warehouse (warehouse_name, city, address, capacity_units, used_units, is_active) " +
                    "VALUES (@name, @city, @addr, @cap, @used, @active)", p);
                MessageBox.Show("Warehouse added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadWarehouses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedWarehouseID < 0) { MessageBox.Show("Select a warehouse first.", "Info"); return; }
            if (!ValidateInput()) return;
            try
            {
                MySqlParameter[] p = {
                    new MySqlParameter("@name",   txtWHName.Text.Trim()),
                    new MySqlParameter("@city",   txtCity.Text.Trim()),
                    new MySqlParameter("@addr",   txtAddress.Text.Trim()),
                    new MySqlParameter("@cap",    int.Parse(txtCapacity.Text)),
                    new MySqlParameter("@used",   int.Parse(txtUsed.Text)),
                    new MySqlParameter("@active", chkIsActive.Checked ? 1 : 0),
                    new MySqlParameter("@id",     selectedWarehouseID)
                };
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE warehouse SET warehouse_name=@name, city=@city, address=@addr, " +
                    "capacity_units=@cap, used_units=@used, is_active=@active WHERE warehouse_id=@id", p);
                MessageBox.Show("Warehouse updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadWarehouses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedWarehouseID < 0) { MessageBox.Show("Select a warehouse first.", "Info"); return; }
            if (MessageBox.Show("Delete this warehouse?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                MySqlParameter[] p = { new MySqlParameter("@id", selectedWarehouseID) };
                DatabaseHelper.ExecuteNonQuery("DELETE FROM warehouse WHERE warehouse_id=@id", p);
                MessageBox.Show("Warehouse deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadWarehouses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            selectedWarehouseID  = -1;
            txtWHName.Clear();
            txtCity.Clear();
            txtAddress.Clear();
            txtCapacity.Clear();
            txtUsed.Text         = "0";
            chkIsActive.Checked  = true;
            dgvWarehouses.ClearSelection();
        }
    }
}
