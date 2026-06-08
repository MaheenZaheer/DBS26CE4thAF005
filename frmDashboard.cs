using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmDashboard : Form
    {
        public static int LoggedInUserID = 0;
        public static string LoggedInUserName = "";
        public static string LoggedInRole = "";

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "CourierDB — Admin Dashboard";
            lblWelcome.Text = LoggedInUserName;
            lblRoleBadge.Text = LoggedInRole.ToUpper();

            // Hide all nav items first
            navUsers.Visible = false;
            navReports.Visible = false;
            navRateCards.Visible = false;
            navZones.Visible = false;
            //navRates.Visible = false;
            navComplaints.Visible = false;
            navBookings.Visible = false;
            navParcels.Visible = false;
            navPayments.Visible = false;
            navTrack.Visible = false;
            navStaff.Visible = false;

            if (LoggedInRole == "Admin")
            {
                navUsers.Visible = true;
                navReports.Visible = true;
                navRateCards.Visible = true;
                navZones.Visible = true;
                //navRates.Visible = true;
                navComplaints.Visible = true;
                navBookings.Visible = true;
                navParcels.Visible = true;
                navPayments.Visible = true;
                navTrack.Visible = true;
                navStaff.Visible = true;
            }
            else if (LoggedInRole == "Seller" || LoggedInRole == "Staff")
            {
                navParcels.Visible = true;
                navBookings.Visible = true;
                navTrack.Visible = true;
                navPayments.Visible = true;
                navComplaints.Visible = true;
            }
            else if (LoggedInRole == "Customer")
            {
                navTrack.Visible = true;
                navBookings.Visible = true;
                navComplaints.Visible = true;
                navPayments.Visible = true;
            }

            LoadDashboardStats();
            LoadRecentParcels();
        }

        private void LoadDashboardStats()
        {
            try
            {
                string filter = (LoggedInRole == "Customer")
                    ? $" JOIN booking b ON p.shipment_id = (SELECT shipment_id FROM parcel WHERE order_id = b.order_id LIMIT 1) WHERE b.user_id = {LoggedInUserID}"
                    : "";

                // Simpler approach — just count from parcel with user filter
                string uid = LoggedInUserID.ToString();
                string userJoin = (LoggedInRole == "Customer")
                    ? $"JOIN booking b ON p.order_id = b.order_id WHERE b.user_id = {uid} AND "
                    : "WHERE ";

                DataTable dtProcessing = DatabaseHelper.ExecuteQuery(
                    $"SELECT COUNT(*) AS cnt FROM parcel p {userJoin} p.status='Processing'");
                DataTable dtShipped = DatabaseHelper.ExecuteQuery(
                    $"SELECT COUNT(*) AS cnt FROM parcel p {userJoin} p.status='Shipped'");
                DataTable dtDelivered = DatabaseHelper.ExecuteQuery(
                    $"SELECT COUNT(*) AS cnt FROM parcel p {userJoin} p.status='Delivered'");
                DataTable dtCancelled = DatabaseHelper.ExecuteQuery(
                    $"SELECT COUNT(*) AS cnt FROM parcel p {userJoin} p.status='Cancelled'");

                string bookingWhere = (LoggedInRole == "Customer")
                    ? $"WHERE user_id = {uid}" : "";
                DataTable dtBookings = DatabaseHelper.ExecuteQuery(
                    $"SELECT COUNT(*) AS cnt FROM booking {bookingWhere}");
                DataTable dtTotal = DatabaseHelper.ExecuteQuery(
                    $"SELECT COUNT(*) AS cnt FROM parcel p " +
                    (LoggedInRole == "Customer"
                        ? $"JOIN booking b ON p.order_id = b.order_id WHERE b.user_id = {uid}"
                        : ""));

                lblStatProcessing.Text = dtProcessing.Rows[0]["cnt"].ToString();
                lblStatShipped.Text = dtShipped.Rows[0]["cnt"].ToString();
                lblStatDelivered.Text = dtDelivered.Rows[0]["cnt"].ToString();
                lblStatCancelled.Text = dtCancelled.Rows[0]["cnt"].ToString();
                lblStatBookings.Text = dtBookings.Rows[0]["cnt"].ToString();
                lblStatTotal.Text = dtTotal.Rows[0]["cnt"].ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmDashboard", ex.Message);
            }
        }
        //private void LoadDashboardStats()
        //{
        //    try
        //    {
        //        DataTable dtProcessing = DatabaseHelper.ExecuteQuery(
        //            "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Processing'");
        //        DataTable dtShipped = DatabaseHelper.ExecuteQuery(
        //            "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Shipped'");
        //        DataTable dtDelivered = DatabaseHelper.ExecuteQuery(
        //            "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Delivered'");
        //        DataTable dtTotal = DatabaseHelper.ExecuteQuery(
        //            "SELECT COUNT(*) AS cnt FROM parcel");
        //        DataTable dtCancelled = DatabaseHelper.ExecuteQuery(
        //            "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Cancelled'");
        //        DataTable dtBookings = DatabaseHelper.ExecuteQuery(
        //            "SELECT COUNT(*) AS cnt FROM booking");

        //        lblStatProcessing.Text = dtProcessing.Rows[0]["cnt"].ToString();
        //        lblStatShipped.Text = dtShipped.Rows[0]["cnt"].ToString();
        //        lblStatDelivered.Text = dtDelivered.Rows[0]["cnt"].ToString();
        //        lblStatTotal.Text = dtTotal.Rows[0]["cnt"].ToString();
        //        lblStatCancelled.Text = dtCancelled.Rows[0]["cnt"].ToString();
        //        lblStatBookings.Text = dtBookings.Rows[0]["cnt"].ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError("frmDashboard", ex.Message);
        //    }
        //}

        private void LoadRecentParcels()
        {
            try
            {
                DataTable dt;

                if (LoggedInRole == "Admin")
                {
                    // Admin sees all parcels
                    dt = DatabaseHelper.ExecuteQuery(
                        "SELECT p.shipment_id AS 'ID', p.tracking_code AS 'Tracking #', " +
                        "p.sender_name AS 'Sender', p.receiver_name AS 'Receiver', " +
                        "p.receiver_city AS 'City', p.status AS 'Status', " +
                        "b.order_date AS 'Booked On' " +
                        "FROM parcel p " +
                        "LEFT JOIN booking b ON p.order_id = b.order_id " +
                        "ORDER BY p.shipment_id DESC LIMIT 10");
                }
                else if (LoggedInRole == "Seller" || LoggedInRole == "Staff")
                {
                    // Staff sees parcels from their branch
                    MySqlParameter[] p = {
                new MySqlParameter("@uid", LoggedInUserID)
            };
                    dt = DatabaseHelper.ExecuteQuery(
                        "SELECT p.shipment_id AS 'ID', p.tracking_code AS 'Tracking #', " +
                        "p.sender_name AS 'Sender', p.receiver_name AS 'Receiver', " +
                        "p.receiver_city AS 'City', p.status AS 'Status', " +
                        "b.order_date AS 'Booked On' " +
                        "FROM parcel p " +
                        "LEFT JOIN booking b ON p.order_id = b.order_id " +
                        "JOIN branch br ON b.user_id = br.user_id " +
                        "WHERE br.user_id = @uid " +
                        "ORDER BY p.shipment_id DESC LIMIT 10", p);
                }
                else
                {
                    // Customer sees ONLY their own parcels
                    MySqlParameter[] p = {
                new MySqlParameter("@uid", LoggedInUserID)
            };
                    dt = DatabaseHelper.ExecuteQuery(
                        "SELECT p.shipment_id AS 'ID', p.tracking_code AS 'Tracking #', " +
                        "p.sender_name AS 'Sender', p.receiver_name AS 'Receiver', " +
                        "p.receiver_city AS 'City', p.status AS 'Status', " +
                        "b.order_date AS 'Booked On' " +
                        "FROM parcel p " +
                        "JOIN booking b ON p.order_id = b.order_id " +
                        "WHERE b.user_id = @uid " +
                        "ORDER BY p.shipment_id DESC LIMIT 10", p);
                }

                dgvRecent.DataSource = dt;
                dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Color-code status
                foreach (DataGridViewRow row in dgvRecent.Rows)
                {
                    if (row.Cells["Status"].Value != null)
                    {
                        string status = row.Cells["Status"].Value.ToString();
                        switch (status)
                        {
                            case "Delivered":
                                row.Cells["Status"].Style.ForeColor = Color.LimeGreen; break;
                            case "Cancelled":
                                row.Cells["Status"].Style.ForeColor = Color.Tomato; break;
                            case "Shipped":
                            case "OutForDelivery":
                                row.Cells["Status"].Style.ForeColor = Color.Orange; break;
                            default:
                                row.Cells["Status"].Style.ForeColor = Color.SkyBlue; break;
                        }
                    }
                }

                lblRecentCount.Text = "Showing " + dt.Rows.Count + " recent parcels";
            }
            catch (Exception ex)
            {
                Logger.LogError("frmDashboard.LoadRecentParcels", ex.Message);
            }
        }

        //private void LoadRecentParcels()
        //{
        //    try
        //    {
        //        DataTable dt = DatabaseHelper.ExecuteQuery(
        //            "SELECT p.shipment_id AS 'ID', p.tracking_code AS 'Tracking #', " +
        //            "p.sender_name AS 'Sender', p.receiver_name AS 'Receiver', " +
        //            "p.receiver_city AS 'City', p.status AS 'Status', " +
        //            "b.order_date AS 'Booked On' " +
        //            "FROM parcel p " +
        //            "LEFT JOIN booking b ON p.order_id = b.order_id " +
        //            "ORDER BY p.shipment_id DESC LIMIT 10");
        //        dgvRecent.DataSource = dt;
        //        dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //        // Color-code status column
        //        foreach (DataGridViewRow row in dgvRecent.Rows)
        //        {
        //            if (row.Cells["Status"].Value != null)
        //            {
        //                string status = row.Cells["Status"].Value.ToString();
        //                switch (status)
        //                {
        //                    case "Delivered":
        //                        row.Cells["Status"].Style.ForeColor = Color.LimeGreen;
        //                        break;
        //                    case "Cancelled":
        //                        row.Cells["Status"].Style.ForeColor = Color.Tomato;
        //                        break;
        //                    case "Shipped":
        //                    case "OutForDelivery":
        //                        row.Cells["Status"].Style.ForeColor = Color.Orange;
        //                        break;
        //                    default:
        //                        row.Cells["Status"].Style.ForeColor = Color.SkyBlue;
        //                        break;
        //                }
        //            }
        //        }

        //        lblRecentCount.Text = "Showing " + dt.Rows.Count + " recent parcels";
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError("frmDashboard.LoadRecentParcels", ex.Message);
        //    }
        //}

        // ── Nav click handlers ────────────────────────────────────────────
        private void navUsers_Click(object sender, EventArgs e) => new frmManageUsers().Show();
        private void navReports_Click(object sender, EventArgs e) => new frmReports().Show();
        private void navRateCards_Click(object sender, EventArgs e) => new frmManageRates().Show();
        private void navZones_Click(object sender, EventArgs e) => new frmManageZones().Show();
        //private void navRates_Click(object sender, EventArgs e) => new frmManageRates().Show();
        private void navComplaints_Click(object sender, EventArgs e) => new frmManageComplaints().Show();
        private void navBookings_Click(object sender, EventArgs e) => new frmManageBooking().Show();
        private void navParcels_Click(object sender, EventArgs e) => new frmManageParcel().Show();
        private void navPayments_Click(object sender, EventArgs e) => new frmManagepayment().Show();
        private void navTrack_Click(object sender, EventArgs e) => new frmTrackParcel().Show();
        private void navStaff_Click(object sender, EventArgs e) => new frmManageStaff().Show();

        private void navLogout_Click(object sender, EventArgs e)
        {
            LoggedInUserID = 0;
            LoggedInUserName = "";
            LoggedInRole = "";
            new frmLogin().Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardStats();
            LoadRecentParcels();
        }
    }
}

//using CourierDB.SoftwareClasses;
//using System;
//using System.Data;
//using System.Drawing;
//using System.Windows.Forms;

//namespace CourierDB.UI
//{
//    public partial class frmDashboard : Form
//    {
//        public static int LoggedInUserID = 0;
//        public static string LoggedInUserName = "";
//        public static string LoggedInRole = "";

//        public frmDashboard()
//        {
//            InitializeComponent();
//        }

//        private void frmDashboard_Load(object sender, EventArgs e)
//        {
//            this.Text = "CourierDB — " + (LoggedInRole == "Admin" ? "Admin" : "User") + " Dashboard";
//            lblWelcome.Text = LoggedInUserName;
//            lblRoleBadge.Text = LoggedInRole.ToUpper();

//            // Hide all nav items first
//            HideAllNavItems();

//            // Show nav items based on role
//            if (LoggedInRole == "Admin")
//            {
//                ShowAdminNavItems();
//            }
//            else if (LoggedInRole == "Seller" || LoggedInRole == "Staff")
//            {
//                ShowStaffNavItems();
//            }
//            else if (LoggedInRole == "Customer")
//            {
//                ShowCustomerNavItems();
//            }

//            LoadDashboardStats();
//            LoadRecentParcels();
//        }

//        private void HideAllNavItems()
//        {
//            navUsers.Visible = false;
//            navReports.Visible = false;
//            navRateCards.Visible = false;
//            navZones.Visible = false;
//            navRates.Visible = false;
//            navComplaints.Visible = false;
//            navBookings.Visible = false;
//            navParcels.Visible = false;
//            navPayments.Visible = false;
//            navTrack.Visible = false;
//            navStaff.Visible = false;
//        }

//        private void ShowAdminNavItems()
//        {
//            navUsers.Visible = true;
//            navReports.Visible = true;
//            navRateCards.Visible = true;
//            navZones.Visible = true;
//            navRates.Visible = true;
//            navComplaints.Visible = true;
//            navBookings.Visible = true;
//            navParcels.Visible = true;
//            navPayments.Visible = true;
//            navTrack.Visible = true;
//            navStaff.Visible = true;
//        }

//        private void ShowStaffNavItems()
//        {
//            navParcels.Visible = true;
//            navBookings.Visible = true;
//            navTrack.Visible = true;
//            navPayments.Visible = true;
//            navComplaints.Visible = true;
//        }

//        private void ShowCustomerNavItems()
//        {
//            navTrack.Visible = true;
//            navBookings.Visible = true;
//            navComplaints.Visible = true;
//            navPayments.Visible = true;
//        }

//        private void LoadDashboardStats()
//        {
//            try
//            {
//                // For SQL Server use TOP, for MySQL use LIMIT
//                // Using SQL Server syntax (TOP)
//                DataTable dtProcessing = DatabaseHelper.ExecuteQuery(
//                    "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Processing'");
//                DataTable dtShipped = DatabaseHelper.ExecuteQuery(
//                    "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Shipped'");
//                DataTable dtDelivered = DatabaseHelper.ExecuteQuery(
//                    "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Delivered'");
//                DataTable dtTotal = DatabaseHelper.ExecuteQuery(
//                    "SELECT COUNT(*) AS cnt FROM parcel");
//                DataTable dtCancelled = DatabaseHelper.ExecuteQuery(
//                    "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Cancelled'");
//                DataTable dtBookings = DatabaseHelper.ExecuteQuery(
//                    "SELECT COUNT(*) AS cnt FROM booking");

//                if (dtProcessing.Rows.Count > 0)
//                    lblStatProcessing.Text = dtProcessing.Rows[0]["cnt"].ToString();
//                if (dtShipped.Rows.Count > 0)
//                    lblStatShipped.Text = dtShipped.Rows[0]["cnt"].ToString();
//                if (dtDelivered.Rows.Count > 0)
//                    lblStatDelivered.Text = dtDelivered.Rows[0]["cnt"].ToString();
//                if (dtTotal.Rows.Count > 0)
//                    lblStatTotal.Text = dtTotal.Rows[0]["cnt"].ToString();
//                if (dtCancelled.Rows.Count > 0)
//                    lblStatCancelled.Text = dtCancelled.Rows[0]["cnt"].ToString();
//                if (dtBookings.Rows.Count > 0)
//                    lblStatBookings.Text = dtBookings.Rows[0]["cnt"].ToString();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError("frmDashboard.LoadDashboardStats", ex.Message);
//                // Set default values on error
//                lblStatProcessing.Text = "0";
//                lblStatShipped.Text = "0";
//                lblStatDelivered.Text = "0";
//                lblStatTotal.Text = "0";
//                lblStatCancelled.Text = "0";
//                lblStatBookings.Text = "0";
//            }
//        }

//        private void LoadRecentParcels()
//        {
//            try
//            {
//                // For SQL Server (use TOP 10)
//                // For MySQL (use LIMIT 10) - change as per your database
//                string query = @"
//                    SELECT TOP 10 
//                        p.shipment_id AS 'ID', 
//                        p.tracking_code AS 'Tracking #', 
//                        p.sender_name AS 'Sender', 
//                        p.receiver_name AS 'Receiver', 
//                        p.receiver_city AS 'City', 
//                        p.status AS 'Status', 
//                        b.order_date AS 'Booked On' 
//                    FROM parcel p 
//                    LEFT JOIN booking b ON p.order_id = b.order_id 
//                    ORDER BY p.shipment_id DESC";

//                // Use this for MySQL instead:
//                // string query = @"
//                //     SELECT p.shipment_id AS 'ID', p.tracking_code AS 'Tracking #', 
//                //     p.sender_name AS 'Sender', p.receiver_name AS 'Receiver', 
//                //     p.receiver_city AS 'City', p.status AS 'Status', 
//                //     b.order_date AS 'Booked On' 
//                //     FROM parcel p 
//                //     LEFT JOIN booking b ON p.order_id = b.order_id 
//                //     ORDER BY p.shipment_id DESC LIMIT 10";

//                DataTable dt = DatabaseHelper.ExecuteQuery(query);
//                dgvRecent.DataSource = dt;
//                dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

//                // Color-code status column
//                foreach (DataGridViewRow row in dgvRecent.Rows)
//                {
//                    if (row.Cells["Status"].Value != null)
//                    {
//                        string status = row.Cells["Status"].Value.ToString();
//                        switch (status)
//                        {
//                            case "Delivered":
//                                row.Cells["Status"].Style.ForeColor = Color.LimeGreen;
//                                row.Cells["Status"].Style.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
//                                break;
//                            case "Cancelled":
//                                row.Cells["Status"].Style.ForeColor = Color.Tomato;
//                                row.Cells["Status"].Style.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
//                                break;
//                            case "Shipped":
//                            case "OutForDelivery":
//                                row.Cells["Status"].Style.ForeColor = Color.Orange;
//                                row.Cells["Status"].Style.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
//                                break;
//                            default:
//                                row.Cells["Status"].Style.ForeColor = Color.SkyBlue;
//                                row.Cells["Status"].Style.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
//                                break;
//                        }
//                    }
//                }

//                lblRecentCount.Text = "Showing " + dt.Rows.Count + " recent parcels";
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError("frmDashboard.LoadRecentParcels", ex.Message);
//                lblRecentCount.Text = "Error loading recent parcels";
//            }
//        }

//        // ── Nav click handlers ────────────────────────────────────────────
//        private void navUsers_Click(object sender, EventArgs e)
//        {
//            new frmManageUsers().ShowDialog();
//        }



//        private void navReports_Click(object sender, EventArgs e)
//        {
//            new frmReports().ShowDialog();
//        }

//        private void navRateCards_Click(object sender, EventArgs e)
//        {
//            new frmManageRates().ShowDialog();
//        }

//        private void navZones_Click(object sender, EventArgs e)
//        {
//            new frmManageZones().ShowDialog();
//        }

//        private void navRates_Click(object sender, EventArgs e)
//        {
//            // If this should open a different form, change it
//            // Currently opens same as Rate Cards
//            new frmManageRates().ShowDialog();
//        }

//        private void navComplaints_Click(object sender, EventArgs e)
//        {
//            new frmManageComplaints().ShowDialog();
//        }

//        private void navBookings_Click(object sender, EventArgs e)
//        {
//            new frmManageBooking().ShowDialog();
//        }

//        private void navParcels_Click(object sender, EventArgs e)
//        {
//            new frmManageParcel().ShowDialog();
//        }

//        private void navPayments_Click(object sender, EventArgs e)
//        {
//            new frmManagepayment().ShowDialog();  // Fixed: Capital P
//        }

//        private void navTrack_Click(object sender, EventArgs e)
//        {
//            new frmTrackParcel().ShowDialog();
//        }

//        private void navStaff_Click(object sender, EventArgs e)
//        {
//            new frmManageStaff().ShowDialog();
//        }

//        private void navLogout_Click(object sender, EventArgs e)
//        {
//            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
//                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//            if (result == DialogResult.Yes)
//            {
//                LoggedInUserID = 0;
//                LoggedInUserName = "";
//                LoggedInRole = "";

//                frmLogin login = new frmLogin();
//                login.Show();
//                this.Close();
//            }
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            LoadDashboardStats();
//            LoadRecentParcels();
//        }
//    }
//}





////using CourierDB.SoftwareClasses;
////using System;
////using System.Data;
////using System.Drawing;
////using System.Windows.Forms;

////namespace CourierDB.UI
////{
////    public partial class frmDashboard : Form
////    {
////        public static int LoggedInUserID = 0;
////        public static string LoggedInUserName = "";
////        public static string LoggedInRole = "";

////        public frmDashboard()
////        {
////            InitializeComponent();
////        }

////        private void frmDashboard_Load(object sender, EventArgs e)
////        {
////            this.Text = "CourierDB — Admin Dashboard";
////            lblWelcome.Text = LoggedInUserName;
////            lblRoleBadge.Text = LoggedInRole.ToUpper();

////            // Hide all nav items first
////            navUsers.Visible = false;
////            navReports.Visible = false;
////            navRateCards.Visible = false;
////            navZones.Visible = false;
////            navRates.Visible = false;
////            navComplaints.Visible = false;
////            navBookings.Visible = false;
////            navParcels.Visible = false;
////            navPayments.Visible = false;
////            navTrack.Visible = false;
////            navStaff.Visible = false;

////            if (LoggedInRole == "Admin")
////            {
////                navUsers.Visible = true;
////                navReports.Visible = true;
////                navRateCards.Visible = true;
////                navZones.Visible = true;
////                navRates.Visible = true;
////                navComplaints.Visible = true;
////                navBookings.Visible = true;
////                navParcels.Visible = true;
////                navPayments.Visible = true;
////                navTrack.Visible = true;
////                navStaff.Visible = true;
////            }
////            else if (LoggedInRole == "Seller" || LoggedInRole == "Staff")
////            {
////                navParcels.Visible = true;
////                navBookings.Visible = true;
////                navTrack.Visible = true;
////                navPayments.Visible = true;
////                navComplaints.Visible = true;
////            }
////            else if (LoggedInRole == "Customer")
////            {
////                navTrack.Visible = true;
////                navBookings.Visible = true;
////                navComplaints.Visible = true;
////                navPayments.Visible = true;
////            }

////            LoadDashboardStats();
////            LoadRecentParcels();
////        }

////        private void LoadDashboardStats()
////        {
////            try
////            {
////                DataTable dtProcessing = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Processing'");
////                DataTable dtShipped = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Shipped'");
////                DataTable dtDelivered = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Delivered'");
////                DataTable dtTotal = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM parcel");
////                DataTable dtCancelled = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM parcel WHERE status='Cancelled'");
////                DataTable dtBookings = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM booking");

////                lblStatProcessing.Text = dtProcessing.Rows[0]["cnt"].ToString();
////                lblStatShipped.Text = dtShipped.Rows[0]["cnt"].ToString();
////                lblStatDelivered.Text = dtDelivered.Rows[0]["cnt"].ToString();
////                lblStatTotal.Text = dtTotal.Rows[0]["cnt"].ToString();
////                lblStatCancelled.Text = dtCancelled.Rows[0]["cnt"].ToString();
////                lblStatBookings.Text = dtBookings.Rows[0]["cnt"].ToString();
////            }
////            catch (Exception ex)
////            {
////                Logger.LogError("frmDashboard", ex.Message);
////            }
////        }

////        private void LoadRecentParcels()
////        {
////            try
////            {
////                DataTable dt = DatabaseHelper.ExecuteQuery(
////                    "SELECT p.shipment_id AS 'ID', p.tracking_code AS 'Tracking #', " +
////                    "p.sender_name AS 'Sender', p.receiver_name AS 'Receiver', " +
////                    "p.receiver_city AS 'City', p.status AS 'Status', " +
////                    "b.order_date AS 'Booked On' " +
////                    "FROM parcel p " +
////                    "LEFT JOIN booking b ON p.order_id = b.order_id " +
////                    "ORDER BY p.shipment_id DESC LIMIT 10");
////                dgvRecent.DataSource = dt;
////                dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

////                // Color-code status column
////                foreach (DataGridViewRow row in dgvRecent.Rows)
////                {
////                    if (row.Cells["Status"].Value != null)
////                    {
////                        string status = row.Cells["Status"].Value.ToString();
////                        switch (status)
////                        {
////                            case "Delivered":
////                                row.Cells["Status"].Style.ForeColor = Color.LimeGreen;
////                                break;
////                            case "Cancelled":
////                                row.Cells["Status"].Style.ForeColor = Color.Tomato;
////                                break;
////                            case "Shipped":
////                            case "OutForDelivery":
////                                row.Cells["Status"].Style.ForeColor = Color.Orange;
////                                break;
////                            default:
////                                row.Cells["Status"].Style.ForeColor = Color.SkyBlue;
////                                break;
////                        }
////                    }
////                }

////                lblRecentCount.Text = "Showing " + dt.Rows.Count + " recent parcels";
////            }
////            catch (Exception ex)
////            {
////                Logger.LogError("frmDashboard.LoadRecentParcels", ex.Message);
////            }
////        }

////        // ── Nav click handlers ────────────────────────────────────────────
////        private void navUsers_Click(object sender, EventArgs e) => new frmManageUsers().Show();
////        private void navReports_Click(object sender, EventArgs e) => new frmReports().Show();
////        private void navRateCards_Click(object sender, EventArgs e) => new frmManageRates().Show();
////        private void navZones_Click(object sender, EventArgs e) => new frmManageZones().Show();
////        private void navRates_Click(object sender, EventArgs e) => new frmManageRates().Show();
////        private void navComplaints_Click(object sender, EventArgs e) => new frmManageComplaints().Show();
////        private void navBookings_Click(object sender, EventArgs e) => new frmManageBooking().Show();
////        private void navParcels_Click(object sender, EventArgs e) => new frmManageParcel().Show();
////        private void navPayments_Click(object sender, EventArgs e) => new frmManagepayment().Show();
////        private void navTrack_Click(object sender, EventArgs e) => new frmTrackParcel().Show();
////        private void navStaff_Click(object sender, EventArgs e) => new frmManageStaff().Show();

////        private void navLogout_Click(object sender, EventArgs e)
////        {
////            LoggedInUserID = 0;
////            LoggedInUserName = "";
////            LoggedInRole = "";
////            new frmLogin().Show();
////            this.Close();
////        }

////        private void btnRefresh_Click(object sender, EventArgs e)
////        {
////            LoadDashboardStats();
////            LoadRecentParcels();
////        }
////    }
////}



////my actual code 

////using CourierDB.SoftwareClasses;
////using System;
////using System.Data;
////using System.Windows.Forms;

////namespace CourierDB.UI
////{
////    public partial class frmDashboard : Form
////    {
////        public static int LoggedInUserID = 0;
////        public static string LoggedInUserName = "";
////        public static string LoggedInRole = "";

////        public frmDashboard()
////        {
////            InitializeComponent();
////        }

////        private void frmDashboard_Load(object sender, EventArgs e)
////        {
////            this.Text = "CourierDB Dashboard";
////            lblWelcome.Text = "Welcome, " + LoggedInUserName;

////            // Hide ALL buttons first
////            btnUsers.Visible = false;
////            btnReports.Visible = false;
////            btnProducts.Visible = false;
////            btnInventory.Visible = false;
////            btnDiscounts.Visible = false;
////            btnReviews.Visible = false;
////            btnbooking.Visible = false;
////            btnShipments.Visible = false;
////            btnpayment.Visible = false;
////            btnCart.Visible = false;

////            // Fix button labels
////            btnProducts.Text = "Rate Cards";
////            btnbooking.Text = "Bookings";
////            btnInventory.Text = "Zones";
////            btnShipments.Text = "Parcels";
////            btnDiscounts.Text = "Rates";
////            btnCart.Text = "Track Parcel";

////            if (LoggedInRole == "Admin")
////            {
////                btnUsers.Visible = true;
////                btnReports.Visible = true;
////                btnProducts.Visible = true;
////                btnInventory.Visible = true;
////                btnDiscounts.Visible = true;
////                btnReviews.Visible = true;
////                btnbooking.Visible = true;
////                btnShipments.Visible = true;
////                btnpayment.Visible = true;
////                btnCart.Visible = true;
////            }
////            else if (LoggedInRole == "Seller" || LoggedInRole == "Staff")
////            {
////                btnShipments.Visible = true;   // Parcels
////                btnbooking.Visible = true;   // Bookings
////                btnCart.Visible = true;   // Track Parcel
////                btnpayment.Visible = true;   // Payments
////                btnReviews.Visible = true;   // Complaints
////            }
////            else if (LoggedInRole == "Customer")
////            {
////                btnCart.Visible = true;   // Track Parcel
////                btnbooking.Visible = true;   // Bookings
////                btnReviews.Visible = true;   // Complaints
////                btnpayment.Visible = true;   // Payments
////            }

////            LoadDashboardStats();
////        }

////        private void LoadDashboardStats()
////        {
////            try
////            {
////                DataTable dtBookings = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM booking");
////                DataTable dtParcels = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM parcel");
////                DataTable dtUsers = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM users");

////                lblTotalbooking.Text = "Total Bookings: " + dtBookings.Rows[0]["cnt"];
////                lblTotalProducts.Text = "Total Parcels: " + dtParcels.Rows[0]["cnt"];
////                lblTotalUsers.Text = "Total Users: " + dtUsers.Rows[0]["cnt"];
////            }
////            catch (Exception ex)
////            {
////                Logger.LogError("frmDashboard", ex.Message);
////            }
////        }

////        private void btnUsers_Click(object sender, EventArgs e)
////            => new frmManageUsers().Show();

////        private void btnProducts_Click(object sender, EventArgs e)
////            => new frmManageRates().Show();

////        private void btnbooking_Click(object sender, EventArgs e)
////            => new frmManageBooking().Show();

////        private void btnInventory_Click(object sender, EventArgs e)
////            => new frmManageZones().Show();

////        private void btnCart_Click(object sender, EventArgs e)
////            => new frmTrackParcel().Show();

////        private void btnpayment_Click(object sender, EventArgs e)
////            => new frmManagepayment().Show();

////        private void btnShipments_Click(object sender, EventArgs e)
////            => new frmManageParcel().Show();

////        private void btnDiscounts_Click(object sender, EventArgs e)
////            => new frmManageRates().Show();

////        private void btnReviews_Click(object sender, EventArgs e)
////            => new frmManageComplaints().Show();

////        private void btnReports_Click(object sender, EventArgs e)
////            => new frmReports().Show();

////        private void btnLogout_Click(object sender, EventArgs e)
////        {
////            LoggedInUserID = 0;
////            LoggedInUserName = "";
////            LoggedInRole = "";
////            new frmLogin().Show();
////            this.Close();
////        }

////        private void lblTotalbooking_Click(object sender, EventArgs e) { }
////        private void lblTotalProducts_Click(object sender, EventArgs e) { }
////        private void lblTotalUsers_Click(object sender, EventArgs e) { }
////        private void lblWelcome_Click(object sender, EventArgs e) { }
////    }
////}



////using CourierDB.SoftwareClasses;
////using System;
////using System.Data;
////using System.Windows.Forms;

////namespace CourierDB.UI
////{
////    public partial class frmDashboard : Form
////    {
////        // Store logged-in user info
////        public static int LoggedInUserID = 0;
////        public static string LoggedInUserName = "";
////        public static string LoggedInRole = "";


////        public frmDashboard()
////        {
////            InitializeComponent();
////            // Change these Text properties in InitializeComponent():
////            this.btnProducts.Text = "Rate Cards";    // was "Products"
////            this.btnbooking.Text = "booking";      // was "booking"
////            this.btnInventory.Text = "Track Parcel";  // was "Inventory"
////            this.btnShipments.Text = "parcel";       // was "Shipments"
////            this.btnDiscounts.Text = "Rates";         // was "Discounts"
////            this.btnReviews.Visible = false;          // hide reviews button
////            this.btnCart.Text = "Track";         // was "Cart"
////        }

////        private void frmDashboard_Load(object sender, EventArgs e)
////        {
////            lblWelcome.Text = "Welcome, " + LoggedInUserName;

////            // Hide all role-sensitive buttons first
////            btnUsers.Visible = false;
////            btnReports.Visible = false;
////            btnProducts.Visible = false;   // Zones
////            btnInventory.Visible = false;   // Rate Cards / Zones
////            btnDiscounts.Visible = false;   // Rates
////            btnReviews.Visible = false;   // Complaints
////            btnbooking.Visible = false;   // booking
////            btnShipments.Visible = false;   // parcel
////            btnpayment.Visible = false;
////            btnCart.Visible = false;   // Track

////            if (LoggedInRole == "Admin")
////            {
////                btnUsers.Visible = true;
////                btnReports.Visible = true;
////                btnProducts.Visible = true;
////                btnInventory.Visible = true;
////                btnDiscounts.Visible = true;
////                btnReviews.Visible = true;
////                btnbooking.Visible = true;
////                btnShipments.Visible = true;
////                btnpayment.Visible = true;
////                btnCart.Visible = true;
////            }

////            else if (LoggedInRole == "Seller" || LoggedInRole == "Staff") // Staff
////                {
////                    btnShipments.Visible = true;   // Manage Parcels
////                    btnbooking.Visible = true;   // Manage Bookings
////                    btnCart.Visible = true;   // Track Parcel
////                    btnpayment.Visible = true;   // Manage Payments
////                    btnReviews.Visible = true;   // Complaints
////                }

////            else if (LoggedInRole == "Customer")
////            {
////                btnCart.Visible = true;
////                btnbooking.Visible = true;
////                btnReviews.Visible = true;
////                btnpayment.Visible = true;
////            }

////            LoadDashboardStats();
////        }

////        private void LoadDashboardStats()
////        {
////            try
////            {
////                DataTable dtBookings = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM booking");
////                DataTable dtParcels = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM parcel");
////                DataTable dtUsers = DatabaseHelper.ExecuteQuery(
////                    "SELECT COUNT(*) AS cnt FROM users");

////                lblTotalbooking.Text = "Total Bookings: " + dtBookings.Rows[0]["cnt"];
////                lblTotalProducts.Text = "Total Parcels: " + dtParcels.Rows[0]["cnt"];
////                lblTotalUsers.Text = "Total Users: " + dtUsers.Rows[0]["cnt"];
////            }
////            catch (Exception ex)
////            {
////                SoftwareClasses.Logger.LogError("frmDashboard", ex.Message);
////            }
////        }

////        //private void LoadDashboardStats()
////        //{
////        //    try
////        //    {
////        //        DataTable dtBookings = DatabaseHelper.ExecuteQuery(
////        //            "SELECT COUNT(*) AS cnt FROM booking");
////        //        DataTable dtParcels = DatabaseHelper.ExecuteQuery(
////        //            "SELECT COUNT(*) AS cnt FROM parcel");
////        //        DataTable dtUsers = DatabaseHelper.ExecuteQuery(
////        //            "SELECT COUNT(*) AS cnt FROM users");

////        //        lblTotalbooking.Text = "Total Bookings: " + dtBookings.Rows[0]["cnt"];
////        //        lblTotalProducts.Text = "Total Parcels: " + dtParcels.Rows[0]["cnt"];
////        //        lblTotalUsers.Text = "Total Users: " + dtUsers.Rows[0]["cnt"];
////        //    }
////        //    catch (Exception ex)
////        //    {
////        //        SoftwareClasses.Logger.LogError("frmDashboard", ex.Message);
////        //    }
////        //}
////        //private void LoadDashboardStats()
////        //{
////        //    DataTable dtbooking = DatabaseHelper.ExecuteQuery(
////        //        "SELECT COUNT(*) AS cnt FROM booking");
////        //    DataTable dtProducts = DatabaseHelper.ExecuteQuery(
////        //        "SELECT COUNT(*) AS cnt FROM product WHERE is_active=1");
////        //    DataTable dtUsers = DatabaseHelper.ExecuteQuery(
////        //        "SELECT COUNT(*) AS cnt FROM users");

////        //    lblTotalbooking.Text = "Total booking: " + dtbooking.Rows[0]["cnt"];
////        //    lblTotalProducts.Text = "Total Products: " + dtProducts.Rows[0]["cnt"];
////        //    lblTotalUsers.Text = "Total Users: " + dtUsers.Rows[0]["cnt"];
////        //}

////        private void btnUsers_Click(object sender, EventArgs e)
////        {
////            new frmManageUsers().Show();
////        }


////        private void btnProducts_Click(object sender, EventArgs e)
////        {
////            new frmManageRates().Show();
////        }

////        private void btnbooking_Click(object sender, EventArgs e)
////        {
////            new frmManageBooking().Show();

////        }



////        //private void btnInventory_Click(object sender, EventArgs e)
////        //{
////        //    new frmManageInventory().Show();

////        //}

////        // Change btnInventory_Click to open tracking form:
////        private void btnInventory_Click(object sender, EventArgs e)
////        {
////            new frmManageZones().Show();
////        }

////        // Change btnCart_Click to also open tracking:
////        private void btnCart_Click(object sender, EventArgs e)
////        {
////            new frmTrackParcel().Show();
////        }

////        private void btnpayment_Click(object sender, EventArgs e)
////        {
////            new frmManagepayment().Show();
////        }

////        private void btnShipments_Click(object sender, EventArgs e)
////        {
////            new frmManageParcel().Show();
////        }

////        private void btnDiscounts_Click(object sender, EventArgs e)
////        {
////            new frmManageRates().Show();
////        }

////        private void btnReviews_Click(object sender, EventArgs e)
////        {
////            new frmManageComplaints().Show();
////        }

////        //private void btnCart_Click(object sender, EventArgs e)
////        //{
////        //    new frmCart().Show();
////        //}

////        private void btnReports_Click(object sender, EventArgs e)
////        {
////            new frmReports().Show();
////        }

////        private void btnLogout_Click(object sender, EventArgs e)
////        {
////            LoggedInUserID = 0;
////            LoggedInUserName = "";
////            LoggedInRole = "";
////            new frmLogin().Show();
////            this.Close();
////        }

////        private void lblTotalbooking_Click(object sender, EventArgs e)
////        {

////        }

////        private void lblTotalProducts_Click(object sender, EventArgs e)
////        {

////        }

////        private void lblTotalUsers_Click(object sender, EventArgs e)
////        {

////        }

////        private void lblWelcome_Click(object sender, EventArgs e)
////        {

////        }
////    }
////}

