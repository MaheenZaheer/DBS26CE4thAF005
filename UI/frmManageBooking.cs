using CourierDB.BLL;
using CourierDB.SoftwareClasses;
using System;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmManageBooking : Form
    {
        private BookingBLL bll = new BookingBLL();

        public frmManageBooking()
        {
            InitializeComponent();
        }

        private void frmManagebooking_Load(object sender, EventArgs e)
        {
            Loadbooking();
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[]
            {
                "Pending", "Confirmed", "Shipped", "Delivered", "Cancelled"
            });
        }

        private void Loadbooking()
        {
            dgvbooking.DataSource = bll.GetAllbooking();
            dgvbooking.AutoResizeColumns();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbooking.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an order first.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please select a status.", "No Status",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int orderID = Convert.ToInt32(dgvbooking.SelectedRows[0].Cells["order_id"].Value);
                string status = cmbStatus.SelectedItem.ToString();
                string result = bll.Updatebookingtatus(orderID, status);
                MessageBox.Show(result, "Update Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loadbooking();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManagebooking", ex.Message);
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Loadbooking();
        }

        // --- Unused stubs kept to avoid designer mismatch errors ---
        private void dgvbooking_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void UpdateStatus_Click(object sender, EventArgs e) { }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        // This stub must exist because Designer still wires btnUpdateStatus to it.
        // The real work is in btnUpdateStatus_Click above; Designer.cs is fixed to point there.
        private void btnUpdateStatus_Click_1(object sender, EventArgs e) { }
    }
}