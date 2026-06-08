using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            // ── Colors ───────────────────────────────────────────────────
            Color bg = Color.FromArgb(18, 18, 18);
            Color sidebar = Color.FromArgb(28, 28, 28);
            Color card = Color.FromArgb(38, 38, 38);
            Color accent = Color.FromArgb(230, 180, 80);   // gold
            Color textMain = Color.FromArgb(240, 240, 240);
            Color textDim = Color.FromArgb(160, 160, 160);
            Color gridBg = Color.FromArgb(32, 32, 32);

            this.SuspendLayout();
            this.BackColor = bg;
            this.ForeColor = textMain;
            this.ClientSize = new Size(1250, 700);
            this.MinimumSize = new Size(1150, 700);
            this.Text = "CourierDB Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f);
            this.Load += new System.EventHandler(this.frmDashboard_Load);

            // ════════════════════════════════════════════════════
            // SIDEBAR  (x=0, w=220, full height)
            // ════════════════════════════════════════════════════
            pnlSidebar = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(220, 700),
                BackColor = sidebar
            };

            // Logo area
            pnlLogo = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(220, 80),
                BackColor = Color.FromArgb(22, 22, 22)
            };
            lblAppName = new Label
            {
                Text = "Parcel Tracker",
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(0, 15),
                Size = new Size(220, 28),
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblAppSub = new Label
            {
                Text = "Courier Service",
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = textDim,
                Location = new Point(0, 45),
                Size = new Size(220, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlLogo.Controls.Add(lblAppName);
            pnlLogo.Controls.Add(lblAppSub);

            // User info strip
            pnlUserStrip = new Panel
            {
                Location = new Point(0, 80),
                Size = new Size(220, 55),
                BackColor = Color.FromArgb(35, 35, 35)
            };
            lblWelcome = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = textMain,
                Location = new Point(10, 8),
                Size = new Size(140, 20),
                AutoSize = false
            };
            lblRoleBadge = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(10, 30),
                Size = new Size(100, 16),
                AutoSize = false
            };
            pnlUserStrip.Controls.Add(lblWelcome);
            pnlUserStrip.Controls.Add(lblRoleBadge);

            // ── Nav items (navRates removed — navRateCards covers this) ──
            int ny = 148; int nh = 40;
            navUsers = MakeNav("👥  Manage Users", ny, accent, textMain, sidebar); ny += nh;
            navBookings = MakeNav("📋  Bookings", ny, accent, textMain, sidebar); ny += nh;
            navParcels = MakeNav("📦  Parcels", ny, accent, textMain, sidebar); ny += nh;
            navTrack = MakeNav("🔍  Track Parcel", ny, accent, textMain, sidebar); ny += nh;
            navPayments = MakeNav("💳  Payments", ny, accent, textMain, sidebar); ny += nh;
            navComplaints = MakeNav("📣  Complaints", ny, accent, textMain, sidebar); ny += nh;
            navZones = MakeNav("🗺️  Zones", ny, accent, textMain, sidebar); ny += nh;
            navRateCards = MakeNav("💰  Rate Cards", ny, accent, textMain, sidebar); ny += nh;  // Rates live inside Rate Cards
            navReports = MakeNav("📈  Reports", ny, accent, textMain, sidebar); ny += nh;
            navStaff = MakeNav("🧑‍💼  Staff", ny, accent, textMain, sidebar); ny += nh + 10;

            // Divider
            pnlDivider = new Panel
            {
                Location = new Point(15, ny),
                Size = new Size(190, 1),
                BackColor = Color.FromArgb(60, 60, 60)
            };

            navLogout = MakeNav("🚪  Logout", ny + 10, Color.Tomato, textMain, sidebar);

            // ── Wire up click handlers ──
            navUsers.Click += new System.EventHandler(this.navUsers_Click);
            navBookings.Click += new System.EventHandler(this.navBookings_Click);
            navParcels.Click += new System.EventHandler(this.navParcels_Click);
            navTrack.Click += new System.EventHandler(this.navTrack_Click);
            navPayments.Click += new System.EventHandler(this.navPayments_Click);
            navComplaints.Click += new System.EventHandler(this.navComplaints_Click);
            navZones.Click += new System.EventHandler(this.navZones_Click);
            navRateCards.Click += new System.EventHandler(this.navRateCards_Click);
            navReports.Click += new System.EventHandler(this.navReports_Click);
            navStaff.Click += new System.EventHandler(this.navStaff_Click);
            navLogout.Click += new System.EventHandler(this.navLogout_Click);

            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Controls.Add(pnlUserStrip);
            pnlSidebar.Controls.Add(navUsers);
            pnlSidebar.Controls.Add(navBookings);
            pnlSidebar.Controls.Add(navParcels);
            pnlSidebar.Controls.Add(navTrack);
            pnlSidebar.Controls.Add(navPayments);
            pnlSidebar.Controls.Add(navComplaints);
            pnlSidebar.Controls.Add(navZones);
            pnlSidebar.Controls.Add(navRateCards);
            pnlSidebar.Controls.Add(navReports);
            pnlSidebar.Controls.Add(navStaff);
            pnlSidebar.Controls.Add(pnlDivider);
            pnlSidebar.Controls.Add(navLogout);

            // ════════════════════════════════════════════════════
            // MAIN CONTENT  (x=220)
            // ════════════════════════════════════════════════════
            pnlMain = new Panel
            {
                Location = new Point(220, 0),
                Size = new Size(1030, 700),
                BackColor = bg
            };

            // Top header bar
            pnlHeader = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1030, 55),
                BackColor = Color.FromArgb(24, 24, 24)
            };
            lblPageTitle = new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = textMain,
                Location = new Point(20, 12),
                AutoSize = true
            };
            btnRefresh = new Button
            {
                Text = "↻  Refresh",
                Location = new Point(920, 12),
                Size = new Size(90, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = textMain,
                Font = new Font("Segoe UI", 9f),
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            pnlHeader.Controls.Add(lblPageTitle);
            pnlHeader.Controls.Add(btnRefresh);

            // ── STAT CARDS row ────────────────────────────────────────
            pnlCards = new Panel
            {
                Location = new Point(20, 70),
                Size = new Size(990, 120),
                BackColor = bg
            };

            int cx = 0; int cw = 148; int cgap = 18;
            MakeStatCard(pnlCards, ref cx, cw, cgap, card, accent, textDim, "PROCESSING", ref lblStatProcessing);
            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.CornflowerBlue, textDim, "SHIPPED", ref lblStatShipped);
            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.LimeGreen, textDim, "DELIVERED", ref lblStatDelivered);
            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.Tomato, textDim, "CANCELLED", ref lblStatCancelled);
            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.Orchid, textDim, "BOOKINGS", ref lblStatBookings);
            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.SkyBlue, textDim, "TOTAL", ref lblStatTotal);

            // ── Recent Operations ────────────────────────────────────────
            pnlRecentHeader = new Panel
            {
                Location = new Point(20, 205),
                Size = new Size(990, 40),
                BackColor = bg
            };
            lblRecentTitle = new Label
            {
                Text = "Recent Operations",
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = textMain,
                Location = new Point(0, 8),
                AutoSize = true
            };
            lblRecentCount = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = textDim,
                Location = new Point(790, 12),
                Size = new Size(200, 20),
                TextAlign = ContentAlignment.MiddleRight
            };
            pnlRecentHeader.Controls.Add(lblRecentTitle);
            pnlRecentHeader.Controls.Add(lblRecentCount);

            dgvRecent = new DataGridView
            {
                Location = new Point(20, 250),
                Size = new Size(990, 415),
                BackgroundColor = gridBg,
                ForeColor = textMain,
                GridColor = Color.FromArgb(50, 50, 50),
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 9f),
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                EnableHeadersVisualStyles = false
            };
            dgvRecent.DefaultCellStyle.BackColor = gridBg;
            dgvRecent.DefaultCellStyle.ForeColor = textMain;
            dgvRecent.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            dgvRecent.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRecent.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgvRecent.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            dgvRecent.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvRecent.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
            dgvRecent.RowTemplate.Height = 30;

            pnlMain.Controls.Add(pnlHeader);
            pnlMain.Controls.Add(pnlCards);
            pnlMain.Controls.Add(pnlRecentHeader);
            pnlMain.Controls.Add(dgvRecent);

            this.Controls.Add(pnlSidebar);
            this.Controls.Add(pnlMain);

            this.ResumeLayout(false);
        }

        // ── Helper: sidebar nav button ────────────────────────────────
        private Button MakeNav(string text, int y, Color accent, Color fg, Color bg)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(0, y),
                Size = new Size(220, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = bg,
                ForeColor = fg,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(16, 0, 0, 0),
                Font = new Font("Segoe UI", 9.5f),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 48, 48);
            btn.MouseEnter += (s, e) => ((Button)s).ForeColor = accent;
            btn.MouseLeave += (s, e) => ((Button)s).ForeColor = fg;
            return btn;
        }

        // ── Helper: stat card ─────────────────────────────────────────
        private void MakeStatCard(Panel parent, ref int x, int w, int gap,
            Color cardBg, Color numColor, Color labelColor, string labelText,
            ref Label numLabel)
        {
            var pnl = new Panel
            {
                Location = new Point(x, 0),
                Size = new Size(w, 110),
                BackColor = cardBg
            };
            numLabel = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 22f, FontStyle.Bold),
                ForeColor = numColor,
                Location = new Point(0, 15),
                Size = new Size(w, 45),
                TextAlign = ContentAlignment.MiddleCenter
            };
            var lbl = new Label
            {
                Text = labelText,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = labelColor,
                Location = new Point(0, 62),
                Size = new Size(w, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnl.Controls.Add(numLabel);
            pnl.Controls.Add(lbl);
            parent.Controls.Add(pnl);
            x += w + gap;
        }

        #endregion

        // ── Controls ──────────────────────────────────────────────────
        private Panel pnlSidebar, pnlLogo, pnlUserStrip, pnlMain;
        private Panel pnlHeader, pnlCards, pnlRecentHeader, pnlDivider;
        private Label lblAppName, lblAppSub, lblWelcome, lblRoleBadge;
        private Label lblPageTitle, lblRecentTitle, lblRecentCount;
        private Label lblStatProcessing, lblStatShipped, lblStatDelivered;
        private Label lblStatCancelled, lblStatBookings, lblStatTotal;
        private Button navUsers, navBookings, navParcels, navTrack;
        private Button navPayments, navComplaints, navZones, navRateCards;
        private Button navReports, navStaff, navLogout;   // navRates removed
        private Button btnRefresh;
        private DataGridView dgvRecent;
    }
}





//using System.Drawing;
//using System.Windows.Forms;

//namespace CourierDB.UI
//{
//    partial class frmDashboard
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null)) components.Dispose();
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code
//        private void InitializeComponent()
//        {
//            // ── Colors ───────────────────────────────────────────────────
//            Color bg = Color.FromArgb(18, 18, 18);
//            Color sidebar = Color.FromArgb(28, 28, 28);
//            Color card = Color.FromArgb(38, 38, 38);
//            Color accent = Color.FromArgb(230, 180, 80);   // gold
//            Color textMain = Color.FromArgb(240, 240, 240);
//            Color textDim = Color.FromArgb(160, 160, 160);
//            Color gridBg = Color.FromArgb(32, 32, 32);
//            Color navHover = Color.FromArgb(50, 50, 50);

//            this.SuspendLayout();
//            this.BackColor = bg;
//            this.ForeColor = textMain;
//            this.ClientSize = new Size(1250, 700);
//            this.MinimumSize = new Size(1150, 700);
//            this.Text = "CourierDB Dashboard";
//            this.StartPosition = FormStartPosition.CenterScreen;
//            this.Font = new Font("Segoe UI", 9.5f);
//            this.Load += new System.EventHandler(this.frmDashboard_Load);

//            // ════════════════════════════════════════════════════
//            // SIDEBAR  (x=0, w=220, full height)
//            // ════════════════════════════════════════════════════
//            pnlSidebar = new Panel
//            {
//                Location = new Point(0, 0),
//                Size = new Size(220, 680),
//                BackColor = sidebar
//            };

//            // Logo area
//            pnlLogo = new Panel
//            {
//                Location = new Point(0, 0),
//                Size = new Size(220, 80),
//                BackColor = Color.FromArgb(22, 22, 22)
//            };
//            lblAppName = new Label
//            {
//                Text = "Parcel Tracker",
//                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
//                ForeColor = accent,
//                Location = new Point(0, 15),
//                Size = new Size(220, 28),
//                TextAlign = ContentAlignment.MiddleCenter
//            };
//            lblAppSub = new Label
//            {
//                Text = "Courier Service",
//                Font = new Font("Segoe UI", 8.5f),
//                ForeColor = textDim,
//                Location = new Point(0, 45),
//                Size = new Size(220, 20),
//                TextAlign = ContentAlignment.MiddleCenter
//            };
//            pnlLogo.Controls.Add(lblAppName);
//            pnlLogo.Controls.Add(lblAppSub);

//            // User info strip
//            pnlUserStrip = new Panel
//            {
//                Location = new Point(0, 80),
//                Size = new Size(220, 55),
//                BackColor = Color.FromArgb(35, 35, 35)
//            };
//            lblWelcome = new Label
//            {
//                Text = "",
//                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
//                ForeColor = textMain,
//                Location = new Point(10, 8),
//                Size = new Size(140, 20),
//                AutoSize = false
//            };
//            lblRoleBadge = new Label
//            {
//                Text = "",
//                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
//                ForeColor = accent,
//                Location = new Point(10, 30),
//                Size = new Size(100, 16),
//                AutoSize = false
//            };
//            pnlUserStrip.Controls.Add(lblWelcome);
//            pnlUserStrip.Controls.Add(lblRoleBadge);

//            // Nav items
//            int ny = 148; int nh = 40;
//            navUsers = MakeNav("👥  Manage Users", ny, accent, textMain, sidebar); ny += nh;
//            navBookings = MakeNav("📋  Bookings", ny, accent, textMain, sidebar); ny += nh;
//            navParcels = MakeNav("📦  Parcels", ny, accent, textMain, sidebar); ny += nh;
//            navTrack = MakeNav("🔍  Track Parcel", ny, accent, textMain, sidebar); ny += nh;
//            navPayments = MakeNav("💳  Payments", ny, accent, textMain, sidebar); ny += nh;
//            navComplaints = MakeNav("📣  Complaints", ny, accent, textMain, sidebar); ny += nh;
//            navZones = MakeNav("🗺️  Zones", ny, accent, textMain, sidebar); ny += nh;
//            navRateCards = MakeNav("💰  Rate Cards", ny, accent, textMain, sidebar); ny += nh;
//            navRates = MakeNav("📊  Rates", ny, accent, textMain, sidebar); ny += nh;
//            navReports = MakeNav("📈  Reports", ny, accent, textMain, sidebar); ny += nh;
//            navStaff = MakeNav("🧑‍💼  Staff", ny, accent, textMain, sidebar); ny += nh + 10;

//            // Divider
//            pnlDivider = new Panel
//            {
//                Location = new Point(15, ny),
//                Size = new Size(190, 1),
//                BackColor = Color.FromArgb(60, 60, 60)
//            };

//            navLogout = MakeNav("🚪  Logout", ny + 10, Color.Tomato, textMain, sidebar);
//            navLogout.Click += new System.EventHandler(this.navLogout_Click);

//            navUsers.Click += new System.EventHandler(this.navUsers_Click);
//            navBookings.Click += new System.EventHandler(this.navBookings_Click);
//            navParcels.Click += new System.EventHandler(this.navParcels_Click);
//            navTrack.Click += new System.EventHandler(this.navTrack_Click);
//            navPayments.Click += new System.EventHandler(this.navPayments_Click);
//            navComplaints.Click += new System.EventHandler(this.navComplaints_Click);
//            navZones.Click += new System.EventHandler(this.navZones_Click);
//            navRateCards.Click += new System.EventHandler(this.navRateCards_Click);
//            navRates.Click += new System.EventHandler(this.navRates_Click);
//            navReports.Click += new System.EventHandler(this.navReports_Click);
//            navStaff.Click += new System.EventHandler(this.navStaff_Click);

//            pnlSidebar.Controls.Add(pnlLogo);
//            pnlSidebar.Controls.Add(pnlUserStrip);
//            pnlSidebar.Controls.Add(navUsers);
//            pnlSidebar.Controls.Add(navBookings);
//            pnlSidebar.Controls.Add(navParcels);
//            pnlSidebar.Controls.Add(navTrack);
//            pnlSidebar.Controls.Add(navPayments);
//            pnlSidebar.Controls.Add(navComplaints);
//            pnlSidebar.Controls.Add(navZones);
//            pnlSidebar.Controls.Add(navRateCards);
//            pnlSidebar.Controls.Add(navRates);
//            pnlSidebar.Controls.Add(navReports);
//            pnlSidebar.Controls.Add(navStaff);
//            pnlSidebar.Controls.Add(pnlDivider);
//            pnlSidebar.Controls.Add(navLogout);

//            // ════════════════════════════════════════════════════
//            // MAIN CONTENT  (x=220)
//            // ════════════════════════════════════════════════════
//            pnlMain = new Panel
//            {
//                Location = new Point(220, 0),
//                Size = new Size(880, 680),
//                BackColor = bg
//            };

//            // Top header bar
//            pnlHeader = new Panel
//            {
//                Location = new Point(0, 0),
//                Size = new Size(880, 55),
//// add here more length 
//                BackColor = Color.FromArgb(24, 24, 24)
//            };
//            lblPageTitle = new Label
//            {
//                Text = "Dashboard",
//                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
//                ForeColor = textMain,
//                Location = new Point(20, 12),
//                AutoSize = true
//            };
//            btnRefresh = new Button
//            {
//                Text = "↻  Refresh",
//                Location = new Point(770, 12),
//                // change location
//                Size = new Size(90, 30),
//                FlatStyle = FlatStyle.Flat,
//                BackColor = Color.FromArgb(50, 50, 50),
//                ForeColor = textMain,
//                Font = new Font("Segoe UI", 9f),
//                Cursor = Cursors.Hand
//            };
//            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
//            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
//            pnlHeader.Controls.Add(lblPageTitle);
//            pnlHeader.Controls.Add(btnRefresh);

//            // ── STAT CARDS row ────────────────────────────────────────
//            pnlCards = new Panel
//            {
//                Location = new Point(20, 70),
//                Size = new Size(840, 120),
//                BackColor = bg
//            };

//            int cx = 0; int cw = 130; int cgap = 12;
//            // increase cgap
//            MakeStatCard(pnlCards, ref cx, cw, cgap, card, accent, textDim, "PROCESSING", ref lblStatProcessing);
//            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.CornflowerBlue, textDim, "SHIPPED", ref lblStatShipped);
//            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.LimeGreen, textDim, "DELIVERED", ref lblStatDelivered);
//            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.Tomato, textDim, "CANCELLED", ref lblStatCancelled);
//            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.Orchid, textDim, "BOOKINGS", ref lblStatBookings);
//            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.SkyBlue, textDim, "TOTAL", ref lblStatTotal);

//            // ── Recent Parcels ────────────────────────────────────────
//            pnlRecentHeader = new Panel
//            {
//                Location = new Point(20, 205),
//                Size = new Size(840, 40),
//                // cahnge it's size also 
//                BackColor = bg
//            };
//            lblRecentTitle = new Label
//            {
//                Text = "Recent Operations",
//                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
//                ForeColor = textMain,
//                Location = new Point(0, 8),
//                AutoSize = true
//            };
//            lblRecentCount = new Label
//            {
//                Text = "",
//                Font = new Font("Segoe UI", 8.5f),
//                ForeColor = textDim,
//                Location = new Point(660, 12),
//                Size = new Size(180, 20),
//                TextAlign = ContentAlignment.MiddleRight
//            };
//            pnlRecentHeader.Controls.Add(lblRecentTitle);
//            pnlRecentHeader.Controls.Add(lblRecentCount);

//            dgvRecent = new DataGridView
//            {
//                Location = new Point(20, 250),
//                // change it's location 
//                Size = new Size(840, 390),
//                BackgroundColor = gridBg,
//                ForeColor = textMain,
//                GridColor = Color.FromArgb(50, 50, 50),
//                BorderStyle = BorderStyle.None,
//                RowHeadersVisible = false,
//                AllowUserToAddRows = false,
//                ReadOnly = true,
//                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
//                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
//                Font = new Font("Segoe UI", 9f),
//                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
//                EnableHeadersVisualStyles = false
//            };
//            dgvRecent.DefaultCellStyle.BackColor = gridBg;
//            dgvRecent.DefaultCellStyle.ForeColor = textMain;
//            dgvRecent.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
//            dgvRecent.DefaultCellStyle.SelectionForeColor = Color.White;
//            dgvRecent.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
//            dgvRecent.ColumnHeadersDefaultCellStyle.ForeColor = accent;
//            dgvRecent.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
//            dgvRecent.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
//            dgvRecent.RowTemplate.Height = 30;

//            pnlMain.Controls.Add(pnlHeader);
//            pnlMain.Controls.Add(pnlCards);
//            pnlMain.Controls.Add(pnlRecentHeader);
//            pnlMain.Controls.Add(dgvRecent);

//            this.Controls.Add(pnlSidebar);
//            this.Controls.Add(pnlMain);

//            this.ResumeLayout(false);
//        }

//        // ── Helper: sidebar nav button ────────────────────────────────
//        private Button MakeNav(string text, int y, Color accent, Color fg, Color bg)
//        {
//            var btn = new Button
//            {
//                Text = text,
//                Location = new Point(0, y),
//                Size = new Size(220, 40),
//                FlatStyle = FlatStyle.Flat,
//                BackColor = bg,
//                ForeColor = fg,
//                TextAlign = ContentAlignment.MiddleLeft,
//                Padding = new Padding(16, 0, 0, 0),
//                Font = new Font("Segoe UI", 9.5f),
//                Cursor = Cursors.Hand
//            };
//            btn.FlatAppearance.BorderSize = 0;
//            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 48, 48);
//            btn.MouseEnter += (s, e) => ((Button)s).ForeColor = accent;
//            btn.MouseLeave += (s, e) => ((Button)s).ForeColor = fg;
//            return btn;
//        }

//        // ── Helper: stat card ─────────────────────────────────────────
//        private void MakeStatCard(Panel parent, ref int x, int w, int gap,
//            Color cardBg, Color numColor, Color labelColor, string labelText,
//            ref Label numLabel)
//        {
//            var pnl = new Panel
//            {
//                Location = new Point(x, 0),
//                Size = new Size(w, 110),
//                BackColor = cardBg
//            };
//            numLabel = new Label
//            {
//                Text = "0",
//                Font = new Font("Segoe UI", 22f, FontStyle.Bold),
//                ForeColor = numColor,
//                Location = new Point(0, 15),
//                Size = new Size(w, 45),
//                TextAlign = ContentAlignment.MiddleCenter
//            };
//            var lbl = new Label
//            {
//                Text = labelText,
//                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
//                ForeColor = labelColor,
//                Location = new Point(0, 62),
//                Size = new Size(w, 30),
//                TextAlign = ContentAlignment.MiddleCenter
//            };
//            pnl.Controls.Add(numLabel);
//            pnl.Controls.Add(lbl);
//            parent.Controls.Add(pnl);
//            x += w + gap;
//        }

//        #endregion

//        // ── Controls ──────────────────────────────────────────────────
//        private Panel pnlSidebar, pnlLogo, pnlUserStrip, pnlMain;
//        private Panel pnlHeader, pnlCards, pnlRecentHeader, pnlDivider;
//        private Label lblAppName, lblAppSub, lblWelcome, lblRoleBadge;
//        private Label lblPageTitle, lblRecentTitle, lblRecentCount;
//        private Label lblStatProcessing, lblStatShipped, lblStatDelivered;
//        private Label lblStatCancelled, lblStatBookings, lblStatTotal;
//        private Button navUsers, navBookings, navParcels, navTrack;
//        private Button navPayments, navComplaints, navZones, navRateCards;
//        private Button navRates, navReports, navStaff, navLogout;
//        private Button btnRefresh;
//        private DataGridView dgvRecent;
//    }
//}










////using System.Drawing;
////using System.Windows.Forms;

////namespace CourierDB.UI
////{
////    partial class frmDashboard
////    {
////        private System.ComponentModel.IContainer components = null;

////        protected override void Dispose(bool disposing)
////        {
////            if (disposing && (components != null)) components.Dispose();
////            base.Dispose(disposing);
////        }

////        #region Windows Form Designer generated code
////        private void InitializeComponent()
////        {
////            // ── Colors ───────────────────────────────────────────────────
////            Color bg = Color.FromArgb(18, 18, 18);
////            Color sidebar = Color.FromArgb(28, 28, 28);
////            Color card = Color.FromArgb(38, 38, 38);
////            Color accent = Color.FromArgb(230, 180, 80);   // gold
////            Color textMain = Color.FromArgb(240, 240, 240);
////            Color textDim = Color.FromArgb(160, 160, 160);
////            Color gridBg = Color.FromArgb(32, 32, 32);

////            this.SuspendLayout();
////            this.BackColor = bg;
////            this.ForeColor = textMain;
////            this.ClientSize = new Size(1300, 700);
////            this.MinimumSize = new Size(1080, 500);
////            this.Text = "CourierDB Dashboard";
////            this.StartPosition = FormStartPosition.CenterScreen;
////            this.Font = new Font("Segoe UI", 9.5f);
////            this.Load += new System.EventHandler(this.frmDashboard_Load);

////            // ════════════════════════════════════════════════════
////            // SIDEBAR (x=0, w=260, full height)
////            // ════════════════════════════════════════════════════
////            pnlSidebar = new Panel
////            {
////                Location = new Point(0, 0),
////                Size = new Size(260, 1080),
////                BackColor = sidebar,
////                Dock = DockStyle.Left
////            };

////            // Logo area
////            pnlLogo = new Panel
////            {
////                Location = new Point(0, 0),
////                Size = new Size(260, 100),
////                BackColor = Color.FromArgb(22, 22, 22),
////                Dock = DockStyle.Top
////            };
////            lblAppName = new Label
////            {
////                Text = "Parcel Tracker",
////                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
////                ForeColor = accent,
////                Location = new Point(0, 25),
////                Size = new Size(260, 30),
////                TextAlign = ContentAlignment.MiddleCenter
////            };
////            lblAppSub = new Label
////            {
////                Text = "Courier Service",
////                Font = new Font("Segoe UI", 10f),
////                ForeColor = textDim,
////                Location = new Point(0, 60),
////                Size = new Size(260, 25),
////                TextAlign = ContentAlignment.MiddleCenter
////            };
////            pnlLogo.Controls.Add(lblAppName);
////            pnlLogo.Controls.Add(lblAppSub);

////            // User info strip
////            pnlUserStrip = new Panel
////            {
////                Location = new Point(0, 100),
////                Size = new Size(260, 70),
////                BackColor = Color.FromArgb(35, 35, 35),
////                Dock = DockStyle.Top
////            };
////            lblWelcome = new Label
////            {
////                Text = "",
////                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
////                ForeColor = textMain,
////                Location = new Point(15, 15),
////                Size = new Size(230, 25),
////                AutoSize = false
////            };
////            lblRoleBadge = new Label
////            {
////                Text = "",
////                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
////                ForeColor = accent,
////                Location = new Point(15, 42),
////                Size = new Size(230, 20),
////                AutoSize = false
////            };
////            pnlUserStrip.Controls.Add(lblWelcome);
////            pnlUserStrip.Controls.Add(lblRoleBadge);

////            // Navigation items container
////            pnlNavContainer = new Panel
////            {
////                Location = new Point(0, 170),
////                Size = new Size(260, 800),
////                BackColor = sidebar,
////                AutoScroll = true
////            };

////            int ny = 10; int nh = 45;
////            navUsers = MakeNav("👥  Manage Users", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navBookings = MakeNav("📋  Bookings", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navParcels = MakeNav("📦  Parcels", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navTrack = MakeNav("🔍  Track Parcel", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navPayments = MakeNav("💳  Payments", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navComplaints = MakeNav("📣  Complaints", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navZones = MakeNav("🗺️  Zones", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navRateCards = MakeNav("💰  Rate Cards", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navRates = MakeNav("📊  Rates", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navReports = MakeNav("📈  Reports", ny, nh, accent, textMain, sidebar); ny += nh + 5;
////            navStaff = MakeNav("🧑‍💼  Staff", ny, nh, accent, textMain, sidebar); ny += nh + 15;

////            // Divider
////            pnlDivider = new Panel
////            {
////                Location = new Point(15, ny),
////                Size = new Size(230, 1),
////                BackColor = Color.FromArgb(60, 60, 60)
////            };

////            navLogout = MakeNav("🚪  Logout", ny + 15, nh, Color.Tomato, textMain, sidebar);

////            pnlNavContainer.Controls.Add(navUsers);
////            pnlNavContainer.Controls.Add(navBookings);
////            pnlNavContainer.Controls.Add(navParcels);
////            pnlNavContainer.Controls.Add(navTrack);
////            pnlNavContainer.Controls.Add(navPayments);
////            pnlNavContainer.Controls.Add(navComplaints);
////            pnlNavContainer.Controls.Add(navZones);
////            pnlNavContainer.Controls.Add(navRateCards);
////            pnlNavContainer.Controls.Add(navRates);
////            pnlNavContainer.Controls.Add(navReports);
////            pnlNavContainer.Controls.Add(navStaff);
////            pnlNavContainer.Controls.Add(pnlDivider);
////            pnlNavContainer.Controls.Add(navLogout);

////            // Event handlers
////            navUsers.Click += new System.EventHandler(this.navUsers_Click);
////            navBookings.Click += new System.EventHandler(this.navBookings_Click);
////            navParcels.Click += new System.EventHandler(this.navParcels_Click);
////            navTrack.Click += new System.EventHandler(this.navTrack_Click);
////            navPayments.Click += new System.EventHandler(this.navPayments_Click);
////            navComplaints.Click += new System.EventHandler(this.navComplaints_Click);
////            navZones.Click += new System.EventHandler(this.navZones_Click);
////            navRateCards.Click += new System.EventHandler(this.navRateCards_Click);
////            navRates.Click += new System.EventHandler(this.navRates_Click);
////            navReports.Click += new System.EventHandler(this.navReports_Click);
////            navStaff.Click += new System.EventHandler(this.navStaff_Click);
////            navLogout.Click += new System.EventHandler(this.navLogout_Click);

////            pnlSidebar.Controls.Add(pnlLogo);
////            pnlSidebar.Controls.Add(pnlUserStrip);
////            pnlSidebar.Controls.Add(pnlNavContainer);

////            // ════════════════════════════════════════════════════
////            // MAIN CONTENT
////            // ════════════════════════════════════════════════════
////            pnlMain = new Panel
////            {
////                Location = new Point(260, 0),
////                Size = new Size(1660, 1080),
////                BackColor = bg,
////                Dock = DockStyle.Fill,
////                Padding = new Padding(25)
////            };

////            // Top header bar
////            pnlHeader = new Panel
////            {
////                Location = new Point(0, 0),
////                Size = new Size(1660, 70),
////                BackColor = Color.FromArgb(24, 24, 24),
////                Dock = DockStyle.Top
////            };
////            lblPageTitle = new Label
////            {
////                Text = "Dashboard",
////                Font = new Font("Segoe UI", 18f, FontStyle.Bold),
////                ForeColor = textMain,
////                Location = new Point(25, 18),
////                AutoSize = true
////            };
////            btnRefresh = new Button
////            {
////                Text = "↻  Refresh",
////                Location = new Point(1510, 18),
////                Size = new Size(120, 35),
////                FlatStyle = FlatStyle.Flat,
////                BackColor = Color.FromArgb(50, 50, 50),
////                ForeColor = textMain,
////                Font = new Font("Segoe UI", 10f),
////                Cursor = Cursors.Hand
////            };
////            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
////            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
////            pnlHeader.Controls.Add(lblPageTitle);
////            pnlHeader.Controls.Add(btnRefresh);

////            // ── STAT CARDS row ────────────────────────────────────────
////            pnlCards = new Panel
////            {
////                Location = new Point(0, 90),
////                Size = new Size(1610, 140),
////                BackColor = bg,
////                Dock = DockStyle.Top
////            };

////            int cw = 245, cgap = 20;
////            int startX = (1610 - (cw * 6 + cgap * 5)) / 2;
////            int cx = startX;

////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, accent, textDim, "PROCESSING", ref lblStatProcessing);
////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.CornflowerBlue, textDim, "SHIPPED", ref lblStatShipped);
////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.LimeGreen, textDim, "DELIVERED", ref lblStatDelivered);
////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.Tomato, textDim, "CANCELLED", ref lblStatCancelled);
////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.Orchid, textDim, "BOOKINGS", ref lblStatBookings);
////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.SkyBlue, textDim, "TOTAL", ref lblStatTotal);

////            // ── Recent Operations Section ────────────────────────────────────────
////            pnlRecentContainer = new Panel
////            {
////                Location = new Point(0, 250),
////                Size = new Size(1610, 500),
////                BackColor = bg,
////                Dock = DockStyle.Fill
////            };

////            pnlRecentHeader = new Panel
////            {
////                Location = new Point(0, 0),
////                Size = new Size(1610, 50),
////                BackColor = bg,
////                Dock = DockStyle.Top
////            };
////            lblRecentTitle = new Label
////            {
////                Text = "Recent Operations",
////                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
////                ForeColor = textMain,
////                Location = new Point(25, 12),
////                AutoSize = true
////            };
////            lblRecentCount = new Label
////            {
////                Text = "",
////                Font = new Font("Segoe UI", 10f),
////                ForeColor = textDim,
////                Location = new Point(1450, 15),
////                Size = new Size(135, 25),
////                TextAlign = ContentAlignment.MiddleRight
////            };
////            pnlRecentHeader.Controls.Add(lblRecentTitle);
////            pnlRecentHeader.Controls.Add(lblRecentCount);

////            dgvRecent = new DataGridView
////            {
////                Location = new Point(25, 60),
////                Size = new Size(1560, 430),
////                BackgroundColor = gridBg,
////                ForeColor = textMain,
////                GridColor = Color.FromArgb(50, 50, 50),
////                BorderStyle = BorderStyle.None,
////                RowHeadersVisible = false,
////                AllowUserToAddRows = false,
////                ReadOnly = true,
////                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
////                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
////                Font = new Font("Segoe UI", 10f),
////                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
////                EnableHeadersVisualStyles = false,
////                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
////            };
////            dgvRecent.DefaultCellStyle.BackColor = gridBg;
////            dgvRecent.DefaultCellStyle.ForeColor = textMain;
////            dgvRecent.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
////            dgvRecent.DefaultCellStyle.SelectionForeColor = Color.White;
////            dgvRecent.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
////            dgvRecent.ColumnHeadersDefaultCellStyle.ForeColor = accent;
////            dgvRecent.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
////            dgvRecent.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
////            dgvRecent.RowTemplate.Height = 35;

////            pnlRecentContainer.Controls.Add(pnlRecentHeader);
////            pnlRecentContainer.Controls.Add(dgvRecent);

////            pnlMain.Controls.Add(pnlHeader);
////            pnlMain.Controls.Add(pnlCards);
////            pnlMain.Controls.Add(pnlRecentContainer);

////            this.Controls.Add(pnlSidebar);
////            this.Controls.Add(pnlMain);

////            this.ResumeLayout(false);
////            this.PerformLayout();
////        }

////        // ── Helper: sidebar nav button ────────────────────────────────
////        private Button MakeNav(string text, int y, int height, Color accent, Color fg, Color bg)
////        {
////            var btn = new Button
////            {
////                Text = text,
////                Location = new Point(0, y),
////                Size = new Size(260, height),
////                FlatStyle = FlatStyle.Flat,
////                BackColor = bg,
////                ForeColor = fg,
////                TextAlign = ContentAlignment.MiddleLeft,
////                Padding = new Padding(20, 0, 0, 0),
////                Font = new Font("Segoe UI", 10f),
////                Cursor = Cursors.Hand
////            };
////            btn.FlatAppearance.BorderSize = 0;
////            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 48, 48);
////            btn.MouseEnter += (s, e) => ((Button)s).ForeColor = accent;
////            btn.MouseLeave += (s, e) => ((Button)s).ForeColor = fg;
////            return btn;
////        }

////        // ── Helper: stat card ─────────────────────────────────────────
////        private void MakeStatCard(Panel parent, ref int x, int w, int gap,
////            Color cardBg, Color numColor, Color labelColor, string labelText,
////            ref Label numLabel)
////        {
////            var pnl = new Panel
////            {
////                Location = new Point(x, 15),
////                Size = new Size(w, 110),
////                BackColor = cardBg
////            };
////            numLabel = new Label
////            {
////                Text = "0",
////                Font = new Font("Segoe UI", 24f, FontStyle.Bold),
////                ForeColor = numColor,
////                Location = new Point(0, 15),
////                Size = new Size(w, 50),
////                TextAlign = ContentAlignment.MiddleCenter
////            };
////            var lbl = new Label
////            {
////                Text = labelText,
////                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
////                ForeColor = labelColor,
////                Location = new Point(0, 70),
////                Size = new Size(w, 25),
////                TextAlign = ContentAlignment.MiddleCenter
////            };
////            pnl.Controls.Add(numLabel);
////            pnl.Controls.Add(lbl);
////            parent.Controls.Add(pnl);
////            x += w + gap;
////        }

////        #endregion

////        // ── Controls ──────────────────────────────────────────────────
////        private Panel pnlSidebar, pnlLogo, pnlUserStrip, pnlMain;
////        private Panel pnlHeader, pnlCards, pnlRecentHeader, pnlDivider;
////        private Panel pnlNavContainer, pnlRecentContainer;
////        private Label lblAppName, lblAppSub, lblWelcome, lblRoleBadge;
////        private Label lblPageTitle, lblRecentTitle, lblRecentCount;
////        private Label lblStatProcessing, lblStatShipped, lblStatDelivered;
////        private Label lblStatCancelled, lblStatBookings, lblStatTotal;
////        private Button navUsers, navBookings, navParcels, navTrack;
////        private Button navPayments, navComplaints, navZones, navRateCards;
////        private Button navRates, navReports, navStaff, navLogout;
////        private Button btnRefresh;
////        private DataGridView dgvRecent;
////    }
////}










//////using System.Drawing;
//////using System.Windows.Forms;


//////namespace CourierDB.UI
//////{
//////    partial class frmDashboard
//////    {
//////        private System.ComponentModel.IContainer components = null;

//////        protected override void Dispose(bool disposing)
//////        {
//////            if (disposing && (components != null)) components.Dispose();
//////            base.Dispose(disposing);
//////        }

//////        #region Windows Form Designer generated code
//////        private void InitializeComponent()
//////        {
//////            // ── Colors ───────────────────────────────────────────────────
//////            Color bg = Color.FromArgb(18, 18, 18);
//////            Color sidebar = Color.FromArgb(28, 28, 28);
//////            Color card = Color.FromArgb(38, 38, 38);
//////            Color accent = Color.FromArgb(230, 180, 80);   // gold
//////            Color textMain = Color.FromArgb(240, 240, 240);
//////            Color textDim = Color.FromArgb(160, 160, 160);
//////            Color gridBg = Color.FromArgb(32, 32, 32);
//////            Color navHover = Color.FromArgb(50, 50, 50);

//////            this.SuspendLayout();
//////            this.BackColor = bg;
//////            this.ForeColor = textMain;
//////            this.ClientSize = new Size(1920, 1080);
//////            this.MinimumSize = new Size(1200, 800);
//////            this.Text = "CourierDB Dashboard";
//////            this.StartPosition = FormStartPosition.CenterScreen;
//////            this.Font = new Font("Segoe UI", 9.5f);
//////            this.Load += new System.EventHandler(this.frmDashboard_Load);

//////            // ════════════════════════════════════════════════════
//////            // SIDEBAR  (x=0, w=220, full height)
//////            // ════════════════════════════════════════════════════
//////            pnlSidebar = new Panel
//////            {
//////                Location = new Point(0, 0),
//////                Size = new Size(220, 680),
//////                BackColor = sidebar
//////            };

//////            // Logo area
//////            pnlLogo = new Panel
//////            {
//////                Location = new Point(0, 0),
//////                Size = new Size(220, 80),
//////                BackColor = Color.FromArgb(22, 22, 22)
//////            };
//////            lblAppName = new Label
//////            {
//////                Text = "Parcel Tracker",
//////                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
//////                ForeColor = accent,
//////                Location = new Point(0, 15),
//////                Size = new Size(220, 28),
//////                TextAlign = ContentAlignment.MiddleCenter
//////            };
//////            lblAppSub = new Label
//////            {
//////                Text = "Courier Service",
//////                Font = new Font("Segoe UI", 8.5f),
//////                ForeColor = textDim,
//////                Location = new Point(0, 45),
//////                Size = new Size(220, 20),
//////                TextAlign = ContentAlignment.MiddleCenter
//////            };
//////            pnlLogo.Controls.Add(lblAppName);
//////            pnlLogo.Controls.Add(lblAppSub);

//////            // User info strip
//////            pnlUserStrip = new Panel
//////            {
//////                Location = new Point(0, 80),
//////                Size = new Size(220, 55),
//////                BackColor = Color.FromArgb(35, 35, 35)
//////            };
//////            lblWelcome = new Label
//////            {
//////                Text = "",
//////                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
//////                ForeColor = textMain,
//////                Location = new Point(10, 8),
//////                Size = new Size(140, 20),
//////                AutoSize = false
//////            };
//////            lblRoleBadge = new Label
//////            {
//////                Text = "",
//////                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
//////                ForeColor = accent,
//////                Location = new Point(10, 30),
//////                Size = new Size(100, 16),
//////                AutoSize = false
//////            };
//////            pnlUserStrip.Controls.Add(lblWelcome);
//////            pnlUserStrip.Controls.Add(lblRoleBadge);

//////            // Nav items
//////            int ny = 148; int nh = 40;
//////            navUsers = MakeNav("👥  Manage Users", ny, accent, textMain, sidebar); ny += nh;
//////            navBookings = MakeNav("📋  Bookings", ny, accent, textMain, sidebar); ny += nh;
//////            navParcels = MakeNav("📦  Parcels", ny, accent, textMain, sidebar); ny += nh;
//////            navTrack = MakeNav("🔍  Track Parcel", ny, accent, textMain, sidebar); ny += nh;
//////            navPayments = MakeNav("💳  Payments", ny, accent, textMain, sidebar); ny += nh;
//////            navComplaints = MakeNav("📣  Complaints", ny, accent, textMain, sidebar); ny += nh;
//////            navZones = MakeNav("🗺️  Zones", ny, accent, textMain, sidebar); ny += nh;
//////            navRateCards = MakeNav("💰  Rate Cards", ny, accent, textMain, sidebar); ny += nh;
//////            navRates = MakeNav("📊  Rates", ny, accent, textMain, sidebar); ny += nh;
//////            navReports = MakeNav("📈  Reports", ny, accent, textMain, sidebar); ny += nh;
//////            navStaff = MakeNav("🧑‍💼  Staff", ny, accent, textMain, sidebar); ny += nh + 10;

//////            // Divider
//////            pnlDivider = new Panel
//////            {
//////                Location = new Point(15, ny),
//////                Size = new Size(190, 1),
//////                BackColor = Color.FromArgb(60, 60, 60)
//////            };

//////            navLogout = MakeNav("🚪  Logout", ny + 10, Color.Tomato, textMain, sidebar);
//////            navLogout.Click += new System.EventHandler(this.navLogout_Click);

//////            navUsers.Click += new System.EventHandler(this.navUsers_Click);
//////            navBookings.Click += new System.EventHandler(this.navBookings_Click);
//////            navParcels.Click += new System.EventHandler(this.navParcels_Click);
//////            navTrack.Click += new System.EventHandler(this.navTrack_Click);
//////            navPayments.Click += new System.EventHandler(this.navPayments_Click);
//////            navComplaints.Click += new System.EventHandler(this.navComplaints_Click);
//////            navZones.Click += new System.EventHandler(this.navZones_Click);
//////            navRateCards.Click += new System.EventHandler(this.navRateCards_Click);
//////            navRates.Click += new System.EventHandler(this.navRates_Click);
//////            navReports.Click += new System.EventHandler(this.navReports_Click);
//////            navStaff.Click += new System.EventHandler(this.navStaff_Click);

//////            pnlSidebar.Controls.Add(pnlLogo);
//////            pnlSidebar.Controls.Add(pnlUserStrip);
//////            pnlSidebar.Controls.Add(navUsers);
//////            pnlSidebar.Controls.Add(navBookings);
//////            pnlSidebar.Controls.Add(navParcels);
//////            pnlSidebar.Controls.Add(navTrack);
//////            pnlSidebar.Controls.Add(navPayments);
//////            pnlSidebar.Controls.Add(navComplaints);
//////            pnlSidebar.Controls.Add(navZones);
//////            pnlSidebar.Controls.Add(navRateCards);
//////            pnlSidebar.Controls.Add(navRates);
//////            pnlSidebar.Controls.Add(navReports);
//////            pnlSidebar.Controls.Add(navStaff);
//////            pnlSidebar.Controls.Add(pnlDivider);
//////            pnlSidebar.Controls.Add(navLogout);

//////            // ════════════════════════════════════════════════════
//////            // MAIN CONTENT  (x=220)
//////            // ════════════════════════════════════════════════════
//////            pnlMain = new Panel
//////            {
//////                Location = new Point(220, 0),
//////                Size = new Size(880, 680),
//////                BackColor = bg
//////            };

//////            // Top header bar
//////            pnlHeader = new Panel
//////            {
//////                Location = new Point(0, 0),
//////                Size = new Size(880, 55),
//////                BackColor = Color.FromArgb(24, 24, 24)
//////            };
//////            lblPageTitle = new Label
//////            {
//////                Text = "Dashboard",
//////                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
//////                ForeColor = textMain,
//////                Location = new Point(20, 12),
//////                AutoSize = true
//////            };
//////            btnRefresh = new Button
//////            {
//////                Text = "↻  Refresh",
//////                Location = new Point(770, 12),
//////                Size = new Size(90, 30),
//////                FlatStyle = FlatStyle.Flat,
//////                BackColor = Color.FromArgb(50, 50, 50),
//////                ForeColor = textMain,
//////                Font = new Font("Segoe UI", 9f),
//////                Cursor = Cursors.Hand
//////            };
//////            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
//////            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
//////            pnlHeader.Controls.Add(lblPageTitle);
//////            pnlHeader.Controls.Add(btnRefresh);

//////            // ── STAT CARDS row ────────────────────────────────────────
//////            pnlCards = new Panel
//////            {
//////                Location = new Point(20, 70),
//////                Size = new Size(840, 120),
//////                BackColor = bg
//////            };

//////            int cx = 0; int cw = 130; int cgap = 12;
//////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, accent, textDim, "PROCESSING", ref lblStatProcessing);
//////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.CornflowerBlue, textDim, "SHIPPED", ref lblStatShipped);
//////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.LimeGreen, textDim, "DELIVERED", ref lblStatDelivered);
//////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.Tomato, textDim, "CANCELLED", ref lblStatCancelled);
//////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.Orchid, textDim, "BOOKINGS", ref lblStatBookings);
//////            MakeStatCard(pnlCards, ref cx, cw, cgap, card, Color.SkyBlue, textDim, "TOTAL", ref lblStatTotal);

//////            // ── Recent Parcels ────────────────────────────────────────
//////            pnlRecentHeader = new Panel
//////            {
//////                Location = new Point(20, 205),
//////                Size = new Size(840, 40),
//////                BackColor = bg
//////            };
//////            lblRecentTitle = new Label
//////            {
//////                Text = "Recent Operations",
//////                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
//////                ForeColor = textMain,
//////                Location = new Point(0, 8),
//////                AutoSize = true
//////            };
//////            lblRecentCount = new Label
//////            {
//////                Text = "",
//////                Font = new Font("Segoe UI", 8.5f),
//////                ForeColor = textDim,
//////                Location = new Point(660, 12),
//////                Size = new Size(180, 20),
//////                TextAlign = ContentAlignment.MiddleRight
//////            };
//////            pnlRecentHeader.Controls.Add(lblRecentTitle);
//////            pnlRecentHeader.Controls.Add(lblRecentCount);

//////            dgvRecent = new DataGridView
//////            {
//////                Location = new Point(20, 250),
//////                Size = new Size(840, 390),
//////                BackgroundColor = gridBg,
//////                ForeColor = textMain,
//////                GridColor = Color.FromArgb(50, 50, 50),
//////                BorderStyle = BorderStyle.None,
//////                RowHeadersVisible = false,
//////                AllowUserToAddRows = false,
//////                ReadOnly = true,
//////                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
//////                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
//////                Font = new Font("Segoe UI", 9f),
//////                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
//////                EnableHeadersVisualStyles = false
//////            };
//////            dgvRecent.DefaultCellStyle.BackColor = gridBg;
//////            dgvRecent.DefaultCellStyle.ForeColor = textMain;
//////            dgvRecent.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
//////            dgvRecent.DefaultCellStyle.SelectionForeColor = Color.White;
//////            dgvRecent.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
//////            dgvRecent.ColumnHeadersDefaultCellStyle.ForeColor = accent;
//////            dgvRecent.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
//////            dgvRecent.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
//////            dgvRecent.RowTemplate.Height = 30;

//////            pnlMain.Controls.Add(pnlHeader);
//////            pnlMain.Controls.Add(pnlCards);
//////            pnlMain.Controls.Add(pnlRecentHeader);
//////            pnlMain.Controls.Add(dgvRecent);

//////            this.Controls.Add(pnlSidebar);
//////            this.Controls.Add(pnlMain);

//////            this.ResumeLayout(false);
//////        }

//////        // ── Helper: sidebar nav button ────────────────────────────────
//////        private Button MakeNav(string text, int y, Color accent, Color fg, Color bg)
//////        {
//////            var btn = new Button
//////            {
//////                Text = text,
//////                Location = new Point(0, y),
//////                Size = new Size(220, 40),
//////                FlatStyle = FlatStyle.Flat,
//////                BackColor = bg,
//////                ForeColor = fg,
//////                TextAlign = ContentAlignment.MiddleLeft,
//////                Padding = new Padding(16, 0, 0, 0),
//////                Font = new Font("Segoe UI", 9.5f),
//////                Cursor = Cursors.Hand
//////            };
//////            btn.FlatAppearance.BorderSize = 0;
//////            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 48, 48);
//////            btn.MouseEnter += (s, e) => ((Button)s).ForeColor = accent;
//////            btn.MouseLeave += (s, e) => ((Button)s).ForeColor = fg;
//////            return btn;
//////        }

//////        // ── Helper: stat card ─────────────────────────────────────────
//////        private void MakeStatCard(Panel parent, ref int x, int w, int gap,
//////            Color cardBg, Color numColor, Color labelColor, string labelText,
//////            ref Label numLabel)
//////        {
//////            var pnl = new Panel
//////            {
//////                Location = new Point(x, 0),
//////                Size = new Size(w, 110),
//////                BackColor = cardBg
//////            };
//////            numLabel = new Label
//////            {
//////                Text = "0",
//////                Font = new Font("Segoe UI", 22f, FontStyle.Bold),
//////                ForeColor = numColor,
//////                Location = new Point(0, 15),
//////                Size = new Size(w, 45),
//////                TextAlign = ContentAlignment.MiddleCenter
//////            };
//////            var lbl = new Label
//////            {
//////                Text = labelText,
//////                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
//////                ForeColor = labelColor,
//////                Location = new Point(0, 62),
//////                Size = new Size(w, 30),
//////                TextAlign = ContentAlignment.MiddleCenter
//////            };
//////            pnl.Controls.Add(numLabel);
//////            pnl.Controls.Add(lbl);
//////            parent.Controls.Add(pnl);
//////            x += w + gap;
//////        }

//////        #endregion

//////        // ── Controls ──────────────────────────────────────────────────
//////        private Panel pnlSidebar, pnlLogo, pnlUserStrip, pnlMain;
//////        private Panel pnlHeader, pnlCards, pnlRecentHeader, pnlDivider;
//////        private Label lblAppName, lblAppSub, lblWelcome, lblRoleBadge;
//////        private Label lblPageTitle, lblRecentTitle, lblRecentCount;
//////        private Label lblStatProcessing, lblStatShipped, lblStatDelivered;
//////        private Label lblStatCancelled, lblStatBookings, lblStatTotal;
//////        private Button navUsers, navBookings, navParcels, navTrack;
//////        private Button navPayments, navComplaints, navZones, navRateCards;
//////        private Button navRates, navReports, navStaff, navLogout;
//////        private Button btnRefresh;
//////        private DataGridView dgvRecent;
//////    }
//////}

////// my actual code


//////namespace CourierDB.UI
//////{
//////    partial class frmDashboard
//////    {
//////        private System.ComponentModel.IContainer components = null;

//////        protected override void Dispose(bool disposing)
//////        {
//////            if (disposing && (components != null))
//////                components.Dispose();
//////            base.Dispose(disposing);
//////        }

//////        #region Windows Form Designer generated code

//////        private void InitializeComponent()
//////        {
//////            this.lblWelcome = new System.Windows.Forms.Label();
//////            this.lblTotalbooking = new System.Windows.Forms.Label();
//////            this.lblTotalProducts = new System.Windows.Forms.Label();
//////            this.lblTotalUsers = new System.Windows.Forms.Label();
//////            this.btnUsers = new System.Windows.Forms.Button();
//////            this.btnProducts = new System.Windows.Forms.Button();
//////            this.btnbooking = new System.Windows.Forms.Button();
//////            this.btnInventory = new System.Windows.Forms.Button();
//////            this.btnpayment = new System.Windows.Forms.Button();
//////            this.btnReviews = new System.Windows.Forms.Button();
//////            this.btnDiscounts = new System.Windows.Forms.Button();
//////            this.btnShipments = new System.Windows.Forms.Button();
//////            this.btnCart = new System.Windows.Forms.Button();
//////            this.btnLogout = new System.Windows.Forms.Button();
//////            this.btnReports = new System.Windows.Forms.Button();
//////            this.SuspendLayout();

//////            // lblWelcome
//////            this.lblWelcome.AutoSize = true;
//////            this.lblWelcome.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
//////            this.lblWelcome.Location = new System.Drawing.Point(280, 20);
//////            this.lblWelcome.Name = "lblWelcome";
//////            this.lblWelcome.Text = "Welcome";

//////            // lblTotalbooking
//////            this.lblTotalbooking.AutoSize = true;
//////            this.lblTotalbooking.Font = new System.Drawing.Font("Arial", 10F);
//////            this.lblTotalbooking.Location = new System.Drawing.Point(280, 65);
//////            this.lblTotalbooking.Name = "lblTotalbooking";
//////            this.lblTotalbooking.Text = "Total booking: 0";

//////            // lblTotalProducts
//////            this.lblTotalProducts.AutoSize = true;
//////            this.lblTotalProducts.Font = new System.Drawing.Font("Arial", 10F);
//////            this.lblTotalProducts.Location = new System.Drawing.Point(280, 95);
//////            this.lblTotalProducts.Name = "lblTotalProducts";
//////            this.lblTotalProducts.Text = "Total Products: 0";

//////            // lblTotalUsers
//////            this.lblTotalUsers.AutoSize = true;
//////            this.lblTotalUsers.Font = new System.Drawing.Font("Arial", 10F);
//////            this.lblTotalUsers.Location = new System.Drawing.Point(280, 125);
//////            this.lblTotalUsers.Name = "lblTotalUsers";
//////            this.lblTotalUsers.Text = "Total Users: 0";

//////            // ── ROW 1  y=175 ──
//////            this.btnUsers.Location = new System.Drawing.Point(20, 175);
//////            this.btnUsers.Name = "btnUsers";
//////            this.btnUsers.Size = new System.Drawing.Size(155, 38);
//////            this.btnUsers.Text = "Manage Users";
//////            this.btnUsers.UseVisualStyleBackColor = true;
//////            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);

//////            this.btnProducts.Location = new System.Drawing.Point(185, 175);
//////            this.btnProducts.Name = "btnProducts";
//////            this.btnProducts.Size = new System.Drawing.Size(155, 38);
//////            this.btnProducts.Text = "Rate Cards";
//////            this.btnProducts.UseVisualStyleBackColor = true;
//////            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);

//////            this.btnbooking.Location = new System.Drawing.Point(350, 175);
//////            this.btnbooking.Name = "btnbooking";
//////            this.btnbooking.Size = new System.Drawing.Size(155, 38);
//////            this.btnbooking.Text = "booking";
//////            this.btnbooking.UseVisualStyleBackColor = true;
//////            this.btnbooking.Click += new System.EventHandler(this.btnbooking_Click);

//////            this.btnInventory.Location = new System.Drawing.Point(515, 175);
//////            this.btnInventory.Name = "btnInventory";
//////            this.btnInventory.Size = new System.Drawing.Size(155, 38);
//////            this.btnInventory.Text = "Zones";
//////            this.btnInventory.UseVisualStyleBackColor = true;
//////            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);

//////            this.btnReports.Location = new System.Drawing.Point(680, 175);
//////            this.btnReports.Name = "btnReports";
//////            this.btnReports.Size = new System.Drawing.Size(155, 38);
//////            this.btnReports.Text = "Reports";
//////            this.btnReports.UseVisualStyleBackColor = true;
//////            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

//////            // ── ROW 2  y=225 ──
//////            this.btnpayment.Location = new System.Drawing.Point(20, 225);
//////            this.btnpayment.Name = "btnpayment";
//////            this.btnpayment.Size = new System.Drawing.Size(155, 38);
//////            this.btnpayment.Text = "Manage payment";
//////            this.btnpayment.UseVisualStyleBackColor = true;
//////            this.btnpayment.Click += new System.EventHandler(this.btnpayment_Click);

//////            this.btnShipments.Location = new System.Drawing.Point(185, 225);
//////            this.btnShipments.Name = "btnShipments";
//////            this.btnShipments.Size = new System.Drawing.Size(155, 38);
//////            this.btnShipments.Text = "parcel";
//////            this.btnShipments.UseVisualStyleBackColor = true;
//////            this.btnShipments.Click += new System.EventHandler(this.btnShipments_Click);

//////            this.btnDiscounts.Location = new System.Drawing.Point(350, 225);
//////            this.btnDiscounts.Name = "btnDiscounts";
//////            this.btnDiscounts.Size = new System.Drawing.Size(155, 38);
//////            this.btnDiscounts.Text = "Rates";
//////            this.btnDiscounts.UseVisualStyleBackColor = true;
//////            this.btnDiscounts.Click += new System.EventHandler(this.btnDiscounts_Click);

//////            this.btnReviews.Location = new System.Drawing.Point(515, 225);
//////            this.btnReviews.Name = "btnReviews";
//////            this.btnReviews.Size = new System.Drawing.Size(155, 38);
//////            this.btnReviews.Text = "Complaints";
//////            this.btnReviews.UseVisualStyleBackColor = true;
//////            this.btnReviews.Click += new System.EventHandler(this.btnReviews_Click);

//////            // ── ROW 3  y=275 ──
//////            this.btnCart.Location = new System.Drawing.Point(20, 275);
//////            this.btnCart.Name = "btnCart";
//////            this.btnCart.Size = new System.Drawing.Size(155, 38);
//////            this.btnCart.Text = "Track Parcel";
//////            this.btnCart.UseVisualStyleBackColor = true;
//////            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);

//////            this.btnLogout.Location = new System.Drawing.Point(680, 275);
//////            this.btnLogout.Name = "btnLogout";
//////            this.btnLogout.Size = new System.Drawing.Size(155, 38);
//////            this.btnLogout.Text = "Logout";
//////            this.btnLogout.UseVisualStyleBackColor = true;
//////            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

//////            // ── Form settings ──
//////            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//////            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//////            this.ClientSize = new System.Drawing.Size(870, 350);
//////            this.Controls.Add(this.lblWelcome);
//////            this.Controls.Add(this.lblTotalbooking);
//////            this.Controls.Add(this.lblTotalProducts);
//////            this.Controls.Add(this.lblTotalUsers);
//////            this.Controls.Add(this.btnUsers);
//////            this.Controls.Add(this.btnProducts);
//////            this.Controls.Add(this.btnbooking);
//////            this.Controls.Add(this.btnInventory);
//////            this.Controls.Add(this.btnReports);
//////            this.Controls.Add(this.btnpayment);
//////            this.Controls.Add(this.btnShipments);
//////            this.Controls.Add(this.btnDiscounts);
//////            this.Controls.Add(this.btnReviews);
//////            this.Controls.Add(this.btnCart);
//////            this.Controls.Add(this.btnLogout);
//////            this.Text = "CourierDB Dashboard";
//////            this.Load += new System.EventHandler(this.frmDashboard_Load);
//////            this.ResumeLayout(false);
//////            this.PerformLayout();
//////        }

//////        #endregion

//////        private System.Windows.Forms.Label lblWelcome;
//////        private System.Windows.Forms.Label lblTotalbooking;
//////        private System.Windows.Forms.Label lblTotalProducts;
//////        private System.Windows.Forms.Label lblTotalUsers;
//////        private System.Windows.Forms.Button btnUsers;
//////        private System.Windows.Forms.Button btnProducts;
//////        private System.Windows.Forms.Button btnbooking;
//////        private System.Windows.Forms.Button btnInventory;
//////        private System.Windows.Forms.Button btnpayment;
//////        private System.Windows.Forms.Button btnReviews;
//////        private System.Windows.Forms.Button btnDiscounts;
//////        private System.Windows.Forms.Button btnShipments;
//////        private System.Windows.Forms.Button btnCart;
//////        private System.Windows.Forms.Button btnLogout;
//////        private System.Windows.Forms.Button btnReports;
//////    }
//////}