using CourierDB.BLL;
using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmManagepayment : Form
    {
        private PaymentBLL bll = new PaymentBLL();

        public frmManagepayment()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
        }

        private void frmManagepayment_Load(object sender, EventArgs e)
        {
            try
            {
                cmbMethod.Items.Clear();

                cmbMethod.Items.AddRange(new string[]
                {
                    "Cash",
                    "Card",
                    "EasyPaisa",
                    "JazzCash"
                });

                cmbMethod.SelectedIndex = 0;

                Loadpayment();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManagepayment_Load", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void Loadpayment()
        {
            try
            {
                dgvpayment.DataSource =
                    DatabaseHelper.ExecuteQuery(
                    "SELECT * FROM payment ORDER BY paid_at DESC");

                dgvpayment.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvpayment.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvpayment.ReadOnly = true;
                dgvpayment.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManagepayment", ex.Message);
                MessageBox.Show("Failed to load payment.");
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                int orderID;
                decimal amount;

                if (!int.TryParse(txtOrderID.Text, out orderID))
                {
                    MessageBox.Show("Enter valid Order ID.");
                    return;
                }

                if (!decimal.TryParse(txtAmount.Text, out amount))
                {
                    MessageBox.Show("Enter valid amount.");
                    return;
                }

                if (amount <= 0)
                {
                    MessageBox.Show("Amount must be greater than zero.");
                    return;
                }

                Payment pay = new Payment
                {
                    OrderID = orderID,
                    Amount = amount,
                    Method = cmbMethod.SelectedItem.ToString(),
                    Status = "Completed"
                };

                string result = bll.AddPayment(pay);

                MessageBox.Show(result);

                Loadpayment();

                txtOrderID.Clear();
                txtAmount.Clear();

                txtOrderID.Focus();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManagepayment", ex.Message);
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            try
            {
                int refundOrderID;

                if (!int.TryParse(txtRefundOrderID.Text, out refundOrderID))
                {
                    MessageBox.Show("Enter valid Order ID.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRefundReason.Text))
                {
                    MessageBox.Show("Enter refund reason.");
                    return;
                }

                DataTable result =
                    bll.ProcessRefund(
                    refundOrderID,
                    txtRefundReason.Text.Trim());

                if (result.Rows.Count > 0)
                {
                    MessageBox.Show(result.Rows[0][0].ToString());
                }

                Loadpayment();

                txtRefundOrderID.Clear();
                txtRefundReason.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManagepayment", ex.Message);
                MessageBox.Show("Refund failed : " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Loadpayment();
        }

        private void dgvpayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}