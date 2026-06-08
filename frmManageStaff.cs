using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmManageStaff : Form
    {
        private int selectedStaffID = -1;

        public frmManageStaff()
        {
            InitializeComponent();
        }

        private void frmManageStaff_Load(object sender, EventArgs e)
        {
            LoadBranches();
            LoadUsers();
            LoadStaff();
        }

        private void LoadBranches()
        {
            try
            {
                // FIX: branch table uses seller_id and shop_name, not branch_id/branch_name
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT seller_id, shop_name FROM branch ORDER BY shop_name");
                cmbBranch.DisplayMember = "shop_name";
                cmbBranch.ValueMember = "seller_id";
                cmbBranch.DataSource = dt;
                cmbBranch.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Branch load error: " + ex.Message);
            }
        }

        private void LoadUsers()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT user_id, name FROM users " +
                    "WHERE role IN ('Admin','Seller') ORDER BY name");
                cmbUser.DisplayMember = "name";
                cmbUser.ValueMember = "user_id";
                cmbUser.DataSource = dt;
                cmbUser.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("User load error: " + ex.Message);
            }
        }

        private void LoadStaff()
        {
            try
            {
                // FIX: JOIN branch using seller_id and show shop_name
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT cs.staff_id, u.name AS staff_name, " +
                    "b.shop_name AS branch_name, " +
                    "cs.designation, cs.cnic, cs.join_date, cs.is_active " +
                    "FROM courier_staff cs " +
                    "JOIN users  u ON cs.user_id   = u.user_id " +
                    "LEFT JOIN branch b ON cs.branch_id = b.seller_id " +
                    "ORDER BY cs.staff_id DESC");
                dgvStaff.DataSource = dt;
                dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
            selectedStaffID = Convert.ToInt32(row.Cells["staff_id"].Value);
            txtDesignation.Text = row.Cells["designation"].Value?.ToString();
            txtCNIC.Text = row.Cells["cnic"].Value?.ToString();
            if (DateTime.TryParse(row.Cells["join_date"].Value?.ToString(), out DateTime jd))
                dtpJoinDate.Value = jd;
            chkIsActive.Checked = Convert.ToBoolean(row.Cells["is_active"].Value);
        }

        private bool ValidateInput()
        {
            if (cmbUser.SelectedValue == null)
            { MessageBox.Show("Select a user.", "Validation"); return false; }
            if (cmbBranch.SelectedValue == null)
            { MessageBox.Show("Select a branch.", "Validation"); return false; }
            if (string.IsNullOrWhiteSpace(txtDesignation.Text))
            { MessageBox.Show("Designation is required.", "Validation"); return false; }
            if (string.IsNullOrWhiteSpace(txtCNIC.Text) || txtCNIC.Text.Length != 13)
            { MessageBox.Show("CNIC must be 13 digits (no dashes).", "Validation"); return false; }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                MySqlParameter[] p = {
                    new MySqlParameter("@uid",    cmbUser.SelectedValue),
                    new MySqlParameter("@branch", cmbBranch.SelectedValue),
                    new MySqlParameter("@desig",  txtDesignation.Text.Trim()),
                    new MySqlParameter("@cnic",   txtCNIC.Text.Trim()),
                    new MySqlParameter("@join",   dtpJoinDate.Value.Date),
                    new MySqlParameter("@active", chkIsActive.Checked ? 1 : 0)
                };
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO courier_staff " +
                    "(user_id, branch_id, designation, cnic, join_date, is_active) " +
                    "VALUES (@uid, @branch, @desig, @cnic, @join, @active)", p);
                MessageBox.Show("Staff member added.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadStaff();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStaffID < 0)
            { MessageBox.Show("Select a staff record first.", "Info"); return; }
            if (!ValidateInput()) return;
            try
            {
                MySqlParameter[] p = {
                    new MySqlParameter("@branch", cmbBranch.SelectedValue),
                    new MySqlParameter("@desig",  txtDesignation.Text.Trim()),
                    new MySqlParameter("@cnic",   txtCNIC.Text.Trim()),
                    new MySqlParameter("@join",   dtpJoinDate.Value.Date),
                    new MySqlParameter("@active", chkIsActive.Checked ? 1 : 0),
                    new MySqlParameter("@id",     selectedStaffID)
                };
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE courier_staff SET branch_id=@branch, designation=@desig, " +
                    "cnic=@cnic, join_date=@join, is_active=@active " +
                    "WHERE staff_id=@id", p);
                MessageBox.Show("Staff record updated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadStaff();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStaffID < 0)
            { MessageBox.Show("Select a staff record first.", "Info"); return; }
            if (MessageBox.Show("Delete this staff record?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                MySqlParameter[] p = { new MySqlParameter("@id", selectedStaffID) };
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM courier_staff WHERE staff_id=@id", p);
                MessageBox.Show("Record deleted.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadStaff();
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
            selectedStaffID = -1;
            cmbUser.SelectedIndex = -1;
            cmbBranch.SelectedIndex = -1;
            txtDesignation.Clear();
            txtCNIC.Clear();
            dtpJoinDate.Value = DateTime.Today;
            chkIsActive.Checked = true;
            dgvStaff.ClearSelection();
        }
    }
}


//using CourierDB.SoftwareClasses;
//using MySql.Data.MySqlClient;
//using System;
//using System.Data;
//using System.Windows.Forms;

//namespace CourierDB.UI
//{
//    public partial class frmManageStaff : Form
//    {
//        private int selectedStaffID = -1;

//        public frmManageStaff()
//        {
//            InitializeComponent();
//        }

//        private void frmManageStaff_Load(object sender, EventArgs e)
//        {
//            LoadBranches();
//            LoadUsers();
//            LoadStaff();
//        }

//        private void LoadBranches()
//        {
//            try
//            {
//                DataTable dt = DatabaseHelper.ExecuteQuery(
//                    "SELECT branch_id, branch_name FROM branch ORDER BY branch_name");
//                cmbBranch.DisplayMember = "branch_name";
//                cmbBranch.ValueMember   = "branch_id";
//                cmbBranch.DataSource    = dt;
//                cmbBranch.SelectedIndex = -1;
//            }
//            catch { }
//        }

//        private void LoadUsers()
//        {
//            try
//            {
//                DataTable dt = DatabaseHelper.ExecuteQuery(
//                    "SELECT user_id, name FROM users WHERE role != 'Customer' ORDER BY name");
//                cmbUser.DisplayMember = "name";
//                cmbUser.ValueMember   = "user_id";
//                cmbUser.DataSource    = dt;
//                cmbUser.SelectedIndex = -1;
//            }
//            catch { }
//        }

//        private void LoadStaff()
//        {
//            try
//            {
//                DataTable dt = DatabaseHelper.ExecuteQuery(
//                    "SELECT cs.staff_id, u.name AS staff_name, b.branch_name, " +
//                    "cs.designation, cs.cnic, cs.join_date, cs.is_active " +
//                    "FROM courier_staff cs " +
//                    "JOIN users u ON cs.user_id = u.user_id " +
//                    "LEFT JOIN branch b ON cs.branch_id = b.branch_id " +
//                    "ORDER BY cs.staff_id DESC");
//                dgvStaff.DataSource = dt;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Load error: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0) return;
//            DataGridViewRow row    = dgvStaff.Rows[e.RowIndex];
//            selectedStaffID        = Convert.ToInt32(row.Cells["staff_id"].Value);
//            txtDesignation.Text    = row.Cells["designation"].Value?.ToString();
//            txtCNIC.Text           = row.Cells["cnic"].Value?.ToString();
//            if (DateTime.TryParse(row.Cells["join_date"].Value?.ToString(), out DateTime jd))
//                dtpJoinDate.Value  = jd;
//            chkIsActive.Checked    = Convert.ToBoolean(row.Cells["is_active"].Value);
//        }

//        private bool ValidateInput()
//        {
//            if (cmbUser.SelectedValue == null)
//            { MessageBox.Show("Select a user.", "Validation"); return false; }
//            if (cmbBranch.SelectedValue == null)
//            { MessageBox.Show("Select a branch.", "Validation"); return false; }
//            if (string.IsNullOrWhiteSpace(txtDesignation.Text))
//            { MessageBox.Show("Designation is required.", "Validation"); return false; }
//            if (string.IsNullOrWhiteSpace(txtCNIC.Text) || txtCNIC.Text.Length != 13)
//            { MessageBox.Show("CNIC must be 13 digits (no dashes).", "Validation"); return false; }
//            return true;
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            if (!ValidateInput()) return;
//            try
//            {
//                MySqlParameter[] p = {
//                    new MySqlParameter("@uid",    cmbUser.SelectedValue),
//                    new MySqlParameter("@branch", cmbBranch.SelectedValue),
//                    new MySqlParameter("@desig",  txtDesignation.Text.Trim()),
//                    new MySqlParameter("@cnic",   txtCNIC.Text.Trim()),
//                    new MySqlParameter("@join",   dtpJoinDate.Value.Date),
//                    new MySqlParameter("@active", chkIsActive.Checked ? 1 : 0)
//                };
//                DatabaseHelper.ExecuteNonQuery(
//                    "INSERT INTO courier_staff (user_id, branch_id, designation, cnic, join_date, is_active) " +
//                    "VALUES (@uid, @branch, @desig, @cnic, @join, @active)", p);
//                MessageBox.Show("Staff member added.", "Success",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                ClearForm();
//                LoadStaff();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Add error: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnUpdate_Click(object sender, EventArgs e)
//        {
//            if (selectedStaffID < 0) { MessageBox.Show("Select a staff record first.", "Info"); return; }
//            if (!ValidateInput()) return;
//            try
//            {
//                MySqlParameter[] p = {
//                    new MySqlParameter("@branch", cmbBranch.SelectedValue),
//                    new MySqlParameter("@desig",  txtDesignation.Text.Trim()),
//                    new MySqlParameter("@cnic",   txtCNIC.Text.Trim()),
//                    new MySqlParameter("@join",   dtpJoinDate.Value.Date),
//                    new MySqlParameter("@active", chkIsActive.Checked ? 1 : 0),
//                    new MySqlParameter("@id",     selectedStaffID)
//                };
//                DatabaseHelper.ExecuteNonQuery(
//                    "UPDATE courier_staff SET branch_id=@branch, designation=@desig, " +
//                    "cnic=@cnic, join_date=@join, is_active=@active WHERE staff_id=@id", p);
//                MessageBox.Show("Staff record updated.", "Success",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                ClearForm();
//                LoadStaff();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Update error: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (selectedStaffID < 0) { MessageBox.Show("Select a staff record first.", "Info"); return; }
//            if (MessageBox.Show("Delete this staff record?", "Confirm",
//                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
//            try
//            {
//                MySqlParameter[] p = { new MySqlParameter("@id", selectedStaffID) };
//                DatabaseHelper.ExecuteNonQuery("DELETE FROM courier_staff WHERE staff_id=@id", p);
//                MessageBox.Show("Record deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                ClearForm();
//                LoadStaff();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Delete error: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

//        private void ClearForm()
//        {
//            selectedStaffID         = -1;
//            cmbUser.SelectedIndex   = -1;
//            cmbBranch.SelectedIndex = -1;
//            txtDesignation.Clear();
//            txtCNIC.Clear();
//            dtpJoinDate.Value       = DateTime.Today;
//            chkIsActive.Checked     = true;
//            dgvStaff.ClearSelection();
//        }
//    }
//}
