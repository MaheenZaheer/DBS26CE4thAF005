using CourierDB.BLL;
using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmTrackingLog : Form
    {
        private ParcelBLL bll = new ParcelBLL();

        public frmTrackingLog(int parcelID = 0)
        {
            InitializeComponent();
            if (parcelID > 0)
            {
                txtParcelID.Text = parcelID.ToString();
                LoadLog(parcelID);
            }
        }

        private void btnLoadLog_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtParcelID.Text.Trim(), out int pid) || pid <= 0)
            {
                MessageBox.Show("Enter a valid Parcel ID.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadLog(pid);
        }

        private void LoadLog(int parcelID)
        {
            try
            {
                // FIX: use parcel table directly instead of vw_PendingDeliveries
                DataTable parcel = DatabaseHelper.ExecuteQuery(
                    "SELECT p.tracking_code, p.sender_name, p.receiver_name, p.status " +
                    "FROM parcel p WHERE p.shipment_id = @id",
                    new MySqlParameter[] { new MySqlParameter("@id", parcelID) });

                if (parcel.Rows.Count > 0)
                {
                    DataRow r = parcel.Rows[0];
                    lblTrackingVal.Text = r["tracking_code"]?.ToString() ?? "-";
                    lblSenderVal.Text = r["sender_name"]?.ToString() ?? "-";
                    lblReceiverVal.Text = r["receiver_name"]?.ToString() ?? "-";
                    lblCurrStatusVal.Text = r["status"]?.ToString() ?? "-";

                    // Color code status
                    switch (lblCurrStatusVal.Text)
                    {
                        case "Delivered":
                            lblCurrStatusVal.ForeColor = System.Drawing.Color.LimeGreen;
                            break;
                        case "Cancelled":
                            lblCurrStatusVal.ForeColor = System.Drawing.Color.Red;
                            break;
                        case "OutForDelivery":
                            lblCurrStatusVal.ForeColor = System.Drawing.Color.Orange;
                            break;
                        default:
                            lblCurrStatusVal.ForeColor = System.Drawing.Color.Gold;
                            break;
                    }
                }
                else
                {
                    lblTrackingVal.Text = lblSenderVal.Text =
                    lblReceiverVal.Text = lblCurrStatusVal.Text = "Parcel Not Found";
                }

                // Load tracking log
                DataTable log = bll.GetTrackingLog(parcelID);
                dgvLog.DataSource = log;
                lblLogCount.Text = "📊 Entries: " + log.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading log: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtParcelID.Clear();
            dgvLog.DataSource = null;
            lblTrackingVal.Text = lblSenderVal.Text =
            lblReceiverVal.Text = lblCurrStatusVal.Text = "-";
            lblLogCount.Text = "📊 Entries: 0";
            txtParcelID.Focus();
        }
    }
}








//using CourierDB.BLL;
//using CourierDB.SoftwareClasses;
//using MySql.Data.MySqlClient;
//using System;
//using System.Data;
//using System.Windows.Forms;

//namespace CourierDB.UI
//{
//    public partial class frmTrackingLog : Form
//    {
//        private ParcelBLL bll = new ParcelBLL();

//        public frmTrackingLog(int parcelID = 0)
//        {
//            InitializeComponent();
//            if (parcelID > 0)
//            {
//                txtParcelID.Text = parcelID.ToString();
//                LoadLog(parcelID);
//            }
//        }

//        private void btnLoadLog_Click(object sender, EventArgs e)
//        {
//            if (!int.TryParse(txtParcelID.Text.Trim(), out int pid) || pid <= 0)
//            {
//                MessageBox.Show("Enter a valid Parcel ID.", "Validation",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }
//            LoadLog(pid);
//        }

//        private void LoadLog(int parcelID)
//        {
//            try
//            {
//                // FIX: use parcel table directly instead of vw_PendingDeliveries
//                // vw_PendingDeliveries only has parcels with status Processing/Shipped/OutForDelivery
//                // and does not have sender_name or receiver_name
//                DataTable parcel = DatabaseHelper.ExecuteQuery(
//                    "SELECT p.tracking_code, p.sender_name, p.receiver_name, p.status " +
//                    "FROM parcel p WHERE p.shipment_id = @id",
//                    new MySqlParameter[] { new MySqlParameter("@id", parcelID) });

//                if (parcel.Rows.Count > 0)
//                {
//                    DataRow r = parcel.Rows[0];
//                    lblTrackingVal.Text = r["tracking_code"]?.ToString() ?? "-";
//                    lblSenderVal.Text = r["sender_name"]?.ToString() ?? "-";
//                    lblReceiverVal.Text = r["receiver_name"]?.ToString() ?? "-";
//                    lblCurrStatusVal.Text = r["status"]?.ToString() ?? "-";
//                }
//                else
//                {
//                    lblTrackingVal.Text = lblSenderVal.Text =
//                    lblReceiverVal.Text = lblCurrStatusVal.Text = "Parcel Not Found";
//                }

//                // Load tracking log
//                DataTable log = bll.GetTrackingLog(parcelID);
//                dgvLog.DataSource = log;
//                lblLogCount.Text = "Entries: " + log.Rows.Count;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading log: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnClear_Click(object sender, EventArgs e)
//        {
//            txtParcelID.Clear();
//            dgvLog.DataSource = null;
//            lblTrackingVal.Text = lblSenderVal.Text =
//            lblReceiverVal.Text = lblCurrStatusVal.Text = "-";
//            lblLogCount.Text = "Entries: 0";
//        }
//    }
//}

////using CourierDB.BLL;
////using CourierDB.SoftwareClasses;
////using MySql.Data.MySqlClient;
////using System;
////using System.Data;
////using System.Windows.Forms;

////namespace CourierDB.UI
////{
////    public partial class frmTrackingLog : Form
////    {
////        private ParcelBLL bll = new ParcelBLL();

////        // Allow opening directly with a parcel ID from frmManageParcel
////        public frmTrackingLog(int parcelID = 0)
////        {
////            InitializeComponent();
////            if (parcelID > 0)
////            {
////                txtParcelID.Text = parcelID.ToString();
////                LoadLog(parcelID);
////            }
////        }

////        private void btnLoadLog_Click(object sender, EventArgs e)
////        {
////            if (!int.TryParse(txtParcelID.Text.Trim(), out int pid) || pid <= 0)
////            {
////                MessageBox.Show("Enter a valid Parcel ID.", "Validation",
////                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
////                return;
////            }
////            LoadLog(pid);
////        }

////        private void LoadLog(int parcelID)
////        {
////            try
////            {
////                // Load parcel summary header
////                DataTable parcel = DatabaseHelper.ExecuteQuery(
////                    "SELECT tracking_code, sender_name, receiver_name, status " +
////                    "FROM vw_PendingDeliveries WHERE parcel_id = @id",
////                    new MySqlParameter[] { new MySqlParameter("@id", parcelID) });

////                if (parcel.Rows.Count > 0)
////                {
////                    DataRow r = parcel.Rows[0];
////                    lblTrackingVal.Text  = r["tracking_code"]?.ToString() ?? "-";
////                    lblSenderVal.Text    = r["sender_name"]?.ToString()   ?? "-";
////                    lblReceiverVal.Text  = r["receiver_name"]?.ToString() ?? "-";
////                    lblCurrStatusVal.Text = r["status"]?.ToString()       ?? "-";
////                }
////                else
////                {
////                    lblTrackingVal.Text = lblSenderVal.Text =
////                    lblReceiverVal.Text = lblCurrStatusVal.Text = "Not Found";
////                }

////                // Load tracking log
////                DataTable log = bll.GetTrackingLog(parcelID);
////                dgvLog.DataSource = log;

////                lblLogCount.Text = "Entries: " + log.Rows.Count;
////            }
////            catch (Exception ex)
////            {
////                MessageBox.Show("Error loading log: " + ex.Message, "Error",
////                    MessageBoxButtons.OK, MessageBoxIcon.Error);
////            }
////        }

////        private void btnClear_Click(object sender, EventArgs e)
////        {
////            txtParcelID.Clear();
////            dgvLog.DataSource = null;
////            lblTrackingVal.Text = lblSenderVal.Text =
////            lblReceiverVal.Text = lblCurrStatusVal.Text = "-";
////            lblLogCount.Text = "Entries: 0";
////        }
////    }
////}
