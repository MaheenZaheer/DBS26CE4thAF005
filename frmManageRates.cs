using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using System;
using System.Windows.Forms;
using CourierDB.BLL;
namespace CourierDB.UI
{
    public partial class frmManageRates : Form
    {
        private RateCardBLL bll = new RateCardBLL();
        private int selectedDiscID = 0;

        public frmManageRates()
        {
            InitializeComponent();
        }

        private void frmManageRates_Load(object sender, EventArgs e)
        {
            try
            {
                cmbType.Items.Clear();
                cmbType.Items.AddRange(new string[] { "Percentage", "Fixed" });
                cmbType.SelectedIndex = 0;
                dtpExpiry.MinDate = DateTime.Today;
                dtpExpiry.Value = DateTime.Today.AddMonths(1);
                LoadDiscounts();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageRates", ex.Message);
                MessageBox.Show("Failed to load form: " + ex.Message);
            }
        }

        private void LoadDiscounts()
        {
            try
            {
                dgvDiscounts.DataSource = bll.GetAllRateCards();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageRates", ex.Message);
                MessageBox.Show("Failed to load Discounts.");
            }
        }

        private void dgvDiscounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedDiscID = Convert.ToInt32(
                dgvDiscounts.Rows[e.RowIndex].Cells["Discount_id"].Value);
            txtCode.Text = dgvDiscounts.Rows[e.RowIndex].Cells["code"].Value.ToString();
            txtValue.Text = dgvDiscounts.Rows[e.RowIndex].Cells["value"].Value.ToString();
            txtUsageLimit.Text = dgvDiscounts.Rows[e.RowIndex].Cells["usage_limit"].Value.ToString();
            cmbType.Text = dgvDiscounts.Rows[e.RowIndex].Cells["type"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                decimal value;
                int usageLimit;

                if (string.IsNullOrWhiteSpace(txtCode.Text))
                { MessageBox.Show("Enter a Discount code."); return; }

                if (!decimal.TryParse(txtValue.Text, out value) || value <= 0)
                { MessageBox.Show("Enter valid Discount value."); return; }

                if (!int.TryParse(txtUsageLimit.Text, out usageLimit) || usageLimit <= 0)
                { MessageBox.Show("Enter valid usage limit."); return; }

                Discount d = new Discount
                {
                    Code = txtCode.Text.Trim().ToUpper(),
                    Type = cmbType.SelectedItem.ToString(),
                    Value = value,
                    ExpiryDate = dtpExpiry.Value,
                    UsageLimit = usageLimit
                };

                string result = bll.AddRateCard(d);
                MessageBox.Show(result);
                LoadDiscounts();
                ClearFields();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageRates", ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedDiscID == 0)
                { MessageBox.Show("Select a Discount from the grid first."); return; }

                DialogResult confirm = MessageBox.Show(
                    "Delete this Discount code?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    bll.DeleteRateCard(selectedDiscID);
                    MessageBox.Show("Discount deleted successfully.");
                    LoadDiscounts();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageRates", ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDiscounts();
            ClearFields();
        }

        private void ClearFields()
        {
            selectedDiscID = 0;
            txtCode.Clear();
            txtValue.Clear();
            txtUsageLimit.Clear();
            cmbType.SelectedIndex = 0;
            dtpExpiry.Value = DateTime.Today.AddMonths(1);
        }
    }
}