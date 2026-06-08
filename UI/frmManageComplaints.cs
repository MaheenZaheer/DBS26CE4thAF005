using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmManageComplaints : Form
    {
        private int selectedComplaintID = -1;
        private bool isAdminMode = false;

        public frmManageComplaints()
        {
            InitializeComponent();
        }

        private void frmManageComplaints_Load(object sender, EventArgs e)
        {
            string role = frmDashboard.LoggedInRole;
            isAdminMode = (role == "Admin" || role == "Seller");

            grpFileComplaint.Visible = !isAdminMode;
            grpResolve.Visible = isAdminMode;
            btnResolve.Visible = isAdminMode;

            LoadComplaints();
        }

        private void LoadComplaints()
        {
            try
            {
                DataTable dt;
                if (isAdminMode)
                {
                    dt = DatabaseHelper.ExecuteQuery(
                        "SELECT * FROM vw_ComplaintSummary ORDER BY filed_at DESC");
                }
                else
                {
                    MySqlParameter[] p = {
                        new MySqlParameter("@uid", frmDashboard.LoggedInUserID)
                    };
                    dt = DatabaseHelper.ExecuteQuery(
                        "SELECT * FROM vw_ComplaintSummary " +
                        "WHERE user_id = @uid ORDER BY filed_at DESC", p);
                }
                dgvComplaints.DataSource = dt;
                dgvComplaints.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvComplaints_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvComplaints.Rows[e.RowIndex];
            selectedComplaintID = Convert.ToInt32(row.Cells["complaint_id"].Value);
            lblSelComplaintID.Text = selectedComplaintID.ToString();
            lblSelSubject.Text = row.Cells["subject"].Value?.ToString() ?? "-";
            lblSelStatus.Text = row.Cells["status"].Value?.ToString() ?? "-";
        }

        private void btnFileComplaint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Subject is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? parcelID = null;
            if (!string.IsNullOrWhiteSpace(txtParcelID.Text))
            {
                if (int.TryParse(txtParcelID.Text, out int pid))
                    parcelID = pid;
                else
                {
                    MessageBox.Show("Parcel ID must be a number (or leave blank).");
                    return;
                }
            }

            try
            {
                // FIX: parameter names match sp_FileComplaint exactly:
                // p_user_id, p_parcel_id, p_subject, p_description
                MySqlParameter[] p = {
                    new MySqlParameter("p_user_id",     frmDashboard.LoggedInUserID),
                    new MySqlParameter("p_parcel_id",   parcelID.HasValue
                                                        ? (object)parcelID.Value
                                                        : DBNull.Value),
                    new MySqlParameter("p_subject",     txtSubject.Text.Trim()),
                    new MySqlParameter("p_description", txtDescription.Text.Trim())
                };
                DatabaseHelper.ExecuteStoredProcedure("sp_FileComplaint", p);
                MessageBox.Show("Complaint filed successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFileForm();
                LoadComplaints();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            if (selectedComplaintID < 0)
            {
                MessageBox.Show("Select a complaint first.", "Info");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Remarks are required for resolution.", "Validation");
                return;
            }

            try
            {
                MySqlParameter[] p = {
                    new MySqlParameter("p_complaint_id", selectedComplaintID),
                    new MySqlParameter("p_resolved_by",  frmDashboard.LoggedInUserID),
                    new MySqlParameter("p_remarks",      txtRemarks.Text.Trim())
                };
                DatabaseHelper.ExecuteStoredProcedure("sp_ResolveComplaint", p);
                MessageBox.Show("Complaint marked as resolved.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRemarks.Clear();
                selectedComplaintID = -1;
                lblSelComplaintID.Text = lblSelSubject.Text = lblSelStatus.Text = "-";
                LoadComplaints();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadComplaints();

        private void ClearFileForm()
        {
            txtParcelID.Clear();
            txtSubject.Clear();
            txtDescription.Clear();
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
//    public partial class frmManageComplaints : Form
//    {
//        private int selectedComplaintID = -1;
//        // True = Admin view (can resolve); False = Customer view (can file)
//        private bool isAdminMode = false;

//        public frmManageComplaints()
//        {
//            InitializeComponent();
//        }

//        private void frmManageComplaints_Load(object sender, EventArgs e)
//        {
//            string role = frmDashboard.LoggedInRole;
//            isAdminMode = (role == "Admin" || role == "Seller");

//            // Show/hide panels based on role
//            grpFileComplaint.Visible   = !isAdminMode;  // Only customers file
//            grpResolve.Visible         = isAdminMode;   // Only admin resolves
//            btnResolve.Visible         = isAdminMode;

//            LoadComplaints();
//        }

//        private void LoadComplaints()
//        {
//            try
//            {
//                DataTable dt;
//                if (isAdminMode)
//                {
//                    dt = DatabaseHelper.ExecuteQuery("SELECT * FROM vw_ComplaintSummary ORDER BY filed_at DESC");
//                }
//                else
//                {
//                    // Customer sees only their own complaints
//                    MySqlParameter[] p = { new MySqlParameter("@uid", frmDashboard.LoggedInUserID) };
//                    dt = DatabaseHelper.ExecuteQuery(
//                        "SELECT * FROM vw_ComplaintSummary WHERE user_id = @uid ORDER BY filed_at DESC", p);
//                }
//                dgvComplaints.DataSource = dt;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Load error: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void dgvComplaints_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0) return;
//            DataGridViewRow row = dgvComplaints.Rows[e.RowIndex];
//            selectedComplaintID  = Convert.ToInt32(row.Cells["complaint_id"].Value);
//            // Populate resolve panel
//            lblSelComplaintID.Text = selectedComplaintID.ToString();
//            lblSelSubject.Text     = row.Cells["subject"].Value?.ToString();
//            lblSelStatus.Text      = row.Cells["status"].Value?.ToString();
//        }

//        // ── File Complaint (Customer) ──────────────────────────────────────
//        private void btnFileComplaint_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtSubject.Text))
//            { MessageBox.Show("Subject is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
//            if (string.IsNullOrWhiteSpace(txtDescription.Text))
//            { MessageBox.Show("Description is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

//            int? parcelID = null;
//            if (!string.IsNullOrWhiteSpace(txtParcelID.Text))
//            {
//                if (int.TryParse(txtParcelID.Text, out int pid)) parcelID = pid;
//                else { MessageBox.Show("Parcel ID must be a number (or leave blank).", "Validation"); return; }
//            }

//            try
//            {
//                MySqlParameter[] p = {
//                    new MySqlParameter("p_user_id",    frmDashboard.LoggedInUserID),
//                    new MySqlParameter("p_parcel_id",  parcelID.HasValue ? (object)parcelID.Value : DBNull.Value),
//                    new MySqlParameter("p_subject",    txtSubject.Text.Trim()),
//                    new MySqlParameter("p_description",txtDescription.Text.Trim())
//                };
//                DatabaseHelper.ExecuteStoredProcedure("sp_FileComplaint", p);
//                MessageBox.Show("Complaint filed successfully.", "Success",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                ClearFileForm();
//                LoadComplaints();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // ── Resolve Complaint (Admin) ──────────────────────────────────────
//        private void btnResolve_Click(object sender, EventArgs e)
//        {
//            if (selectedComplaintID < 0) { MessageBox.Show("Select a complaint first.", "Info"); return; }
//            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
//            { MessageBox.Show("Remarks are required for resolution.", "Validation"); return; }

//            try
//            {
//                MySqlParameter[] p = {
//                    new MySqlParameter("p_complaint_id", selectedComplaintID),
//                    new MySqlParameter("p_resolved_by",  frmDashboard.LoggedInUserID),
//                    new MySqlParameter("p_remarks",      txtRemarks.Text.Trim())
//                };
//                DatabaseHelper.ExecuteStoredProcedure("sp_ResolveComplaint", p);
//                MessageBox.Show("Complaint marked as resolved.", "Success",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                txtRemarks.Clear();
//                selectedComplaintID = -1;
//                lblSelComplaintID.Text = lblSelSubject.Text = lblSelStatus.Text = "-";
//                LoadComplaints();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnRefresh_Click(object sender, EventArgs e) => LoadComplaints();

//        private void ClearFileForm()
//        {
//            txtParcelID.Clear();
//            txtSubject.Clear();
//            txtDescription.Clear();
//        }
//    }
//}
