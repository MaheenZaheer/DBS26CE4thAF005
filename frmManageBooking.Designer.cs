using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManageBooking
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Color bg = Color.FromArgb(18, 18, 18);
            Color card = Color.FromArgb(38, 38, 38);
            Color header = Color.FromArgb(24, 24, 24);
            Color gridBg = Color.FromArgb(32, 32, 32);
            Color gridAlt = Color.FromArgb(36, 36, 36);
            Color accent = Color.FromArgb(230, 180, 80);
            Color txtMain = Color.FromArgb(240, 240, 240);
            Color txtDim = Color.FromArgb(160, 160, 160);
            Color border = Color.FromArgb(60, 60, 60);

            this.dgvbooking = new DataGridView();
            this.cmbStatus = new ComboBox();
            this.lblUpdateStatus = new Label();
            this.btnRefresh = new Button();
            this.btnUpdateStatus = new Button();
            this.lblTitle = new Label();
            this.pnlTop = new Panel();
            this.pnlBottom = new Panel();
            this.lblSelectedOrder = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────
            this.BackColor = bg;
            this.ForeColor = txtMain;
            this.ClientSize = new Size(1100, 650);   // sensible default
            this.MinimumSize = new Size(900, 550);
            this.Font = new Font("Segoe UI", 9.5F);
            this.Text = "Manage Bookings — CourierDB";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized; // fills screen at runtime
            this.Load += new System.EventHandler(this.frmManagebooking_Load);

            // ── pnlTop (header bar, Dock.Top) ─────────────────────────
            this.pnlTop.BackColor = header;
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Text = "📋  Manage Bookings";
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = txtMain;
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new Padding(20, 0, 0, 0);

            // ── pnlBottom (action bar, Dock.Bottom) ───────────────────
            this.pnlBottom.BackColor = card;
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 70;
            this.pnlBottom.Controls.AddRange(new Control[] {
                this.lblSelectedOrder,
                this.lblUpdateStatus,
                this.cmbStatus,
                this.btnUpdateStatus,
                this.btnRefresh
            });

            // lblSelectedOrder
            this.lblSelectedOrder.AutoSize = false;
            this.lblSelectedOrder.Location = new Point(16, 23);
            this.lblSelectedOrder.Size = new Size(260, 24);
            this.lblSelectedOrder.Text = "No booking selected";
            this.lblSelectedOrder.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblSelectedOrder.ForeColor = txtDim;

            // lblUpdateStatus
            this.lblUpdateStatus.AutoSize = false;
            this.lblUpdateStatus.Location = new Point(400, 22);
            this.lblUpdateStatus.Size = new Size(110, 26);
            this.lblUpdateStatus.Text = "New Status:";
            this.lblUpdateStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblUpdateStatus.ForeColor = txtMain;
            this.lblUpdateStatus.TextAlign = ContentAlignment.MiddleRight;

            // cmbStatus
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = FlatStyle.Flat;
            this.cmbStatus.Font = new Font("Segoe UI", 9.5F);
            this.cmbStatus.BackColor = Color.FromArgb(30, 30, 30);
            this.cmbStatus.ForeColor = txtMain;
            this.cmbStatus.Location = new Point(518, 21);
            this.cmbStatus.Size = new Size(160, 28);
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);

            // btnUpdateStatus
            this.btnUpdateStatus.BackColor = Color.FromArgb(100, 130, 220);
            this.btnUpdateStatus.ForeColor = Color.White;
            this.btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnUpdateStatus.Location = new Point(694, 17);
            this.btnUpdateStatus.Size = new Size(150, 36);
            this.btnUpdateStatus.Text = "✔  Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Cursor = Cursors.Hand;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            // btnRefresh
            this.btnRefresh.BackColor = Color.FromArgb(90, 180, 130);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnRefresh.Location = new Point(858, 17);
            this.btnRefresh.Size = new Size(110, 36);
            this.btnRefresh.Text = "⟳  Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── dgvbooking (fills space between header and bottom bar) 
            // Anchor all 4 sides so it resizes with the window
            this.dgvbooking.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;
            this.dgvbooking.Location = new Point(16, 71);
            this.dgvbooking.Size = new Size(1068, 509); // fills 1100x650 with margins

            this.dgvbooking.AllowUserToAddRows = false;
            this.dgvbooking.AllowUserToDeleteRows = false;
            this.dgvbooking.ReadOnly = true;
            this.dgvbooking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvbooking.MultiSelect = false;
            this.dgvbooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbooking.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbooking.RowTemplate.Height = 32;
            this.dgvbooking.BorderStyle = BorderStyle.None;
            this.dgvbooking.BackgroundColor = gridBg;
            this.dgvbooking.GridColor = border;
            this.dgvbooking.EnableHeadersVisualStyles = false;
            this.dgvbooking.Font = new Font("Segoe UI", 9.5F);

            this.dgvbooking.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvbooking.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvbooking.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);

            this.dgvbooking.DefaultCellStyle.BackColor = gridBg;
            this.dgvbooking.DefaultCellStyle.ForeColor = txtMain;
            this.dgvbooking.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvbooking.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvbooking.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

            this.dgvbooking.CellContentClick +=
                new DataGridViewCellEventHandler(this.dgvbooking_CellContentClick);

            // ── Wire controls to form ─────────────────────────────────
            // Order matters: add Dock.Top first, Dock.Bottom second, then the grid
            this.Controls.Add(this.dgvbooking);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);

            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvbooking;
        private ComboBox cmbStatus;
        private Label lblUpdateStatus;
        private Button btnRefresh;
        private Button btnUpdateStatus;
        private Label lblTitle;
        private Panel pnlTop;
        private Panel pnlBottom;
        private Label lblSelectedOrder;
    }
}










//using System.Drawing;
//using System.Windows.Forms;

//namespace CourierDB.UI
//{
//    partial class frmManageBooking
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        private void InitializeComponent()
//        {
//            // ── Colors (matches frmDashboard exactly) ─────────────────
//            Color bg = Color.FromArgb(18, 18, 18);
//            Color card = Color.FromArgb(38, 38, 38);
//            Color header = Color.FromArgb(24, 24, 24);
//            Color gridBg = Color.FromArgb(32, 32, 32);
//            Color gridAlt = Color.FromArgb(36, 36, 36);
//            Color accent = Color.FromArgb(230, 180, 80);
//            Color txtMain = Color.FromArgb(240, 240, 240);
//            Color txtDim = Color.FromArgb(160, 160, 160);
//            Color border = Color.FromArgb(60, 60, 60);

//            this.dgvbooking = new System.Windows.Forms.DataGridView();
//            this.cmbStatus = new System.Windows.Forms.ComboBox();
//            this.lblUpdateStatus = new System.Windows.Forms.Label();
//            this.btnRefresh = new System.Windows.Forms.Button();
//            this.btnUpdateStatus = new System.Windows.Forms.Button();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.pnlTop = new System.Windows.Forms.Panel();
//            this.pnlBottom = new System.Windows.Forms.Panel();
//            this.lblSelectedOrder = new System.Windows.Forms.Label();

//            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).BeginInit();
//            this.pnlTop.SuspendLayout();
//            this.pnlBottom.SuspendLayout();
//            this.SuspendLayout();

//            // ── pnlTop ────────────────────────────────────────────────
//            this.pnlTop.BackColor = header;
//            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
//            this.pnlTop.Height = 55;
//            this.pnlTop.Controls.Add(this.lblTitle);

//            this.lblTitle.AutoSize = false;
//            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.lblTitle.Text = "📋  Manage Bookings";
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = txtMain;
//            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

//            // ── dgvbooking ────────────────────────────────────────────
//            this.dgvbooking.AllowUserToAddRows = false;
//            this.dgvbooking.AllowUserToDeleteRows = false;
//            this.dgvbooking.ReadOnly = true;
//            this.dgvbooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvbooking.MultiSelect = false;
//            this.dgvbooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvbooking.ColumnHeadersHeightSizeMode =
//                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvbooking.RowTemplate.Height = 30;
//            this.dgvbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
//            this.dgvbooking.BackgroundColor = gridBg;
//            this.dgvbooking.GridColor = border;
//            this.dgvbooking.EnableHeadersVisualStyles = false;
//            this.dgvbooking.Font = new System.Drawing.Font("Segoe UI", 9.5F);

//            // Header
//            this.dgvbooking.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
//            this.dgvbooking.ColumnHeadersDefaultCellStyle.ForeColor = accent;
//            this.dgvbooking.ColumnHeadersDefaultCellStyle.Font =
//                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

//            // Rows
//            this.dgvbooking.DefaultCellStyle.BackColor = gridBg;
//            this.dgvbooking.DefaultCellStyle.ForeColor = txtMain;
//            this.dgvbooking.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
//            this.dgvbooking.DefaultCellStyle.SelectionForeColor = Color.White;
//            this.dgvbooking.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

//            this.dgvbooking.Anchor =
//                System.Windows.Forms.AnchorStyles.Top |
//                System.Windows.Forms.AnchorStyles.Bottom |
//                System.Windows.Forms.AnchorStyles.Left |
//                System.Windows.Forms.AnchorStyles.Right;
//            this.dgvbooking.Location = new System.Drawing.Point(16, 71);
//            this.dgvbooking.Size = new System.Drawing.Size(968, 400);
//            this.dgvbooking.TabIndex = 0;
//            this.dgvbooking.CellContentClick +=
//                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbooking_CellContentClick);

//            // ── pnlBottom ─────────────────────────────────────────────
//            this.pnlBottom.BackColor = card;
//            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
//            this.pnlBottom.Height = 70;
//            this.pnlBottom.Controls.Add(this.lblSelectedOrder);
//            this.pnlBottom.Controls.Add(this.lblUpdateStatus);
//            this.pnlBottom.Controls.Add(this.cmbStatus);
//            this.pnlBottom.Controls.Add(this.btnUpdateStatus);
//            this.pnlBottom.Controls.Add(this.btnRefresh);

//            // lblSelectedOrder
//            this.lblSelectedOrder.AutoSize = false;
//            this.lblSelectedOrder.Location = new System.Drawing.Point(16, 24);
//            this.lblSelectedOrder.Size = new System.Drawing.Size(240, 24);
//            this.lblSelectedOrder.Text = "No booking selected";
//            this.lblSelectedOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
//            this.lblSelectedOrder.ForeColor = txtDim;

//            // lblUpdateStatus
//            this.lblUpdateStatus.AutoSize = false;
//            this.lblUpdateStatus.Location = new System.Drawing.Point(400, 24);
//            this.lblUpdateStatus.Size = new System.Drawing.Size(110, 26);
//            this.lblUpdateStatus.Text = "New Status:";
//            this.lblUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
//            this.lblUpdateStatus.ForeColor = txtMain;
//            this.lblUpdateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

//            // cmbStatus
//            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.cmbStatus.BackColor = Color.FromArgb(30, 30, 30);
//            this.cmbStatus.ForeColor = txtMain;
//            this.cmbStatus.Location = new System.Drawing.Point(518, 22);
//            this.cmbStatus.Size = new System.Drawing.Size(160, 28);
//            this.cmbStatus.TabIndex = 1;
//            this.cmbStatus.SelectedIndexChanged +=
//                new System.EventHandler(this.cmbStatus_SelectedIndexChanged);

//            // btnUpdateStatus
//            this.btnUpdateStatus.BackColor = Color.FromArgb(100, 130, 220);
//            this.btnUpdateStatus.ForeColor = Color.White;
//            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
//            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
//            this.btnUpdateStatus.Location = new System.Drawing.Point(694, 17);
//            this.btnUpdateStatus.Size = new System.Drawing.Size(150, 36);
//            this.btnUpdateStatus.Text = "✔  Update Status";
//            this.btnUpdateStatus.UseVisualStyleBackColor = false;
//            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btnUpdateStatus.Click +=
//                new System.EventHandler(this.btnUpdateStatus_Click);

//            // btnRefresh
//            this.btnRefresh.BackColor = Color.FromArgb(90, 180, 130);
//            this.btnRefresh.ForeColor = Color.White;
//            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnRefresh.FlatAppearance.BorderSize = 0;
//            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
//            this.btnRefresh.Location = new System.Drawing.Point(858, 17);
//            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
//            this.btnRefresh.Text = "⟳  Refresh";
//            this.btnRefresh.UseVisualStyleBackColor = false;
//            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btnRefresh.Click +=
//                new System.EventHandler(this.btnRefresh_Click);

//            // ── frmManageBooking ──────────────────────────────────────
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = bg;
//            this.ForeColor = txtMain;
//            this.ClientSize = new System.Drawing.Size(1920, 1080);
//            this.MinimumSize = new System.Drawing.Size(1200, 800);
//            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.Name = "frmManageBooking";
//            this.Text = "Manage Bookings — CourierDB";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

//            this.Controls.Add(this.dgvbooking);
//            this.Controls.Add(this.pnlTop);
//            this.Controls.Add(this.pnlBottom);

//            this.Load += new System.EventHandler(this.frmManagebooking_Load);

//            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).EndInit();
//            this.pnlTop.ResumeLayout(false);
//            this.pnlBottom.ResumeLayout(false);
//            this.ResumeLayout(false);
//        }

//        #endregion

//        private System.Windows.Forms.DataGridView dgvbooking;
//        private System.Windows.Forms.ComboBox cmbStatus;
//        private System.Windows.Forms.Label lblUpdateStatus;
//        private System.Windows.Forms.Button btnRefresh;
//        private System.Windows.Forms.Button btnUpdateStatus;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Panel pnlTop;
//        private System.Windows.Forms.Panel pnlBottom;
//        private System.Windows.Forms.Label lblSelectedOrder;
//    }
//}


//////// ═══════════════════════════════════════════════════════════════
////////  frmManageBooking.Designer.cs  —  REFACTORED to use UITheme
////////  Pattern to follow for ALL other child forms.
//////// ═══════════════════════════════════════════════════════════════
//////using CourierDB.SoftwareClasses;

//////namespace CourierDB.UI
//////{
//////    partial class frmManageBooking
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
//////            this.SuspendLayout();

//////            // ── 1. Form chrome ────────────────────────────────────────
//////            UITheme.ApplyForm(this, "Manage Bookings", width: 1000, height: 580);

//////            // ── 2. Header bar (top) ───────────────────────────────────
//////            System.Windows.Forms.Label titleLabel;
//////            var pnlHeader = UITheme.MakeHeaderPanel("📋  Manage Bookings",
//////                                                    this.ClientSize.Width,
//////                                                    out titleLabel);

//////            // ── 3. Bottom action bar ──────────────────────────────────
//////            pnlBottom = UITheme.MakeBottomBar();

//////            lblSelectedOrder = UITheme.MakeLabel("No booking selected",
//////                                                  16, 22, 240);
//////            lblSelectedOrder.ForeColor = UITheme.TextDim;
//////            lblSelectedOrder.Font = UITheme.FontSmall;

//////            lblUpdateStatus = UITheme.MakeLabel("New Status:", 400, 22, 110, bold: true);
//////            lblUpdateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

//////            cmbStatus = UITheme.MakeComboBox(518, 20, 160);
//////            cmbStatus.Items.AddRange(new object[]
//////                { "Pending", "Confirmed", "Dispatched", "Delivered", "Cancelled" });
//////            cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);

//////            btnUpdateStatus = UITheme.MakeButton("✔  Update Status", 694, 17,
//////                                                  UITheme.BtnStyle.Primary, 150, 36);
//////            btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

//////            btnRefresh = UITheme.MakeButton("⟳  Refresh", 858, 17,
//////                                             UITheme.BtnStyle.Success, 110, 36);
//////            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

//////            pnlBottom.Controls.Add(lblSelectedOrder);
//////            pnlBottom.Controls.Add(lblUpdateStatus);
//////            pnlBottom.Controls.Add(cmbStatus);
//////            pnlBottom.Controls.Add(btnUpdateStatus);
//////            pnlBottom.Controls.Add(btnRefresh);

//////            // ── 4. DataGridView ───────────────────────────────────────
//////            dgvBooking = new System.Windows.Forms.DataGridView
//////            {
//////                Location = new System.Drawing.Point(16, 70),
//////                Size = new System.Drawing.Size(968, 430),
//////                Anchor = System.Windows.Forms.AnchorStyles.Top
//////                         | System.Windows.Forms.AnchorStyles.Bottom
//////                         | System.Windows.Forms.AnchorStyles.Left
//////                         | System.Windows.Forms.AnchorStyles.Right,
//////                TabIndex = 0
//////            };
//////            UITheme.ApplyDataGridView(dgvBooking);
//////            dgvBooking.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(
//////                this.dgvBooking_CellContentClick);

//////            // ── 5. Wire controls to form ──────────────────────────────
//////            this.Controls.Add(pnlHeader);       // must be first (Dock.Top)
//////            this.Controls.Add(pnlBottom);       // Dock.Bottom
//////            this.Controls.Add(dgvBooking);      // fills remaining space

//////            this.Load += new System.EventHandler(this.frmManageBooking_Load);
//////            this.ResumeLayout(false);
//////        }

//////        #endregion

//////        // ── Controls ──────────────────────────────────────────────────
//////        private System.Windows.Forms.DataGridView dgvBooking;
//////        private System.Windows.Forms.ComboBox cmbStatus;
//////        private System.Windows.Forms.Label lblUpdateStatus;
//////        private System.Windows.Forms.Label lblSelectedOrder;
//////        private System.Windows.Forms.Button btnRefresh;
//////        private System.Windows.Forms.Button btnUpdateStatus;
//////        private System.Windows.Forms.Panel pnlBottom;
//////    }
//////}


////namespace CourierDB.UI
////{
////    partial class frmManageBooking
////    {
////        private System.ComponentModel.IContainer components = null;

////        protected override void Dispose(bool disposing)
////        {
////            if (disposing && (components != null))
////                components.Dispose();
////            base.Dispose(disposing);
////        }

////        #region Windows Form Designer generated code

////        private void InitializeComponent()
////        {
////            this.dgvbooking = new System.Windows.Forms.DataGridView();
////            this.cmbStatus = new System.Windows.Forms.ComboBox();
////            this.lblUpdateStatus = new System.Windows.Forms.Label();
////            this.btnRefresh = new System.Windows.Forms.Button();
////            this.btnUpdateStatus = new System.Windows.Forms.Button();
////            this.lblTitle = new System.Windows.Forms.Label();
////            this.pnlTop = new System.Windows.Forms.Panel();
////            this.pnlBottom = new System.Windows.Forms.Panel();
////            this.lblSelectedOrder = new System.Windows.Forms.Label();

////            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).BeginInit();
////            this.pnlTop.SuspendLayout();
////            this.pnlBottom.SuspendLayout();
////            this.SuspendLayout();

////            // ──────────────────────────────────────────
////            // pnlTop  (title bar)
////            // ──────────────────────────────────────────
////            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 30, 60);
////            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
////            this.pnlTop.Height = 64;
////            this.pnlTop.Controls.Add(this.lblTitle);

////            // lblTitle
////            this.lblTitle.AutoSize = false;
////            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
////            this.lblTitle.Text = "🛒  Manage booking";
////            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
////            this.lblTitle.ForeColor = System.Drawing.Color.White;
////            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
////            this.lblTitle.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);

////            // ──────────────────────────────────────────
////            // dgvbooking
////            // ──────────────────────────────────────────
////            this.dgvbooking.AllowUserToAddRows = false;
////            this.dgvbooking.AllowUserToDeleteRows = false;
////            this.dgvbooking.ReadOnly = true;
////            this.dgvbooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
////            this.dgvbooking.MultiSelect = false;
////            this.dgvbooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
////            this.dgvbooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
////            this.dgvbooking.RowTemplate.Height = 30;
////            this.dgvbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
////            this.dgvbooking.BackgroundColor = System.Drawing.Color.White;
////            this.dgvbooking.GridColor = System.Drawing.Color.FromArgb(220, 225, 235);

////            // Header style
////            this.dgvbooking.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(50, 55, 100);
////            this.dgvbooking.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
////            this.dgvbooking.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
////            this.dgvbooking.EnableHeadersVisualStyles = false;

////            // Row styles
////            this.dgvbooking.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
////            this.dgvbooking.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(100, 130, 220);
////            this.dgvbooking.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
////            this.dgvbooking.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 255);

////            // Position — fills space between pnlTop and pnlBottom
////            this.dgvbooking.Anchor =
////                System.Windows.Forms.AnchorStyles.Top |
////                System.Windows.Forms.AnchorStyles.Bottom |
////                System.Windows.Forms.AnchorStyles.Left |
////                System.Windows.Forms.AnchorStyles.Right;
////            this.dgvbooking.Location = new System.Drawing.Point(16, 80);
////            this.dgvbooking.Size = new System.Drawing.Size(968, 390);
////            this.dgvbooking.TabIndex = 0;
////            this.dgvbooking.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbooking_CellContentClick);

////            // ──────────────────────────────────────────
////            // pnlBottom  (action bar)
////            // ──────────────────────────────────────────
////            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 242, 250);
////            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
////            this.pnlBottom.Height = 80;
////            this.pnlBottom.Controls.Add(this.lblSelectedOrder);
////            this.pnlBottom.Controls.Add(this.lblUpdateStatus);
////            this.pnlBottom.Controls.Add(this.cmbStatus);
////            this.pnlBottom.Controls.Add(this.btnUpdateStatus);
////            this.pnlBottom.Controls.Add(this.btnRefresh);

////            // lblSelectedOrder
////            this.lblSelectedOrder.AutoSize = false;
////            this.lblSelectedOrder.Location = new System.Drawing.Point(16, 28);
////            this.lblSelectedOrder.Size = new System.Drawing.Size(220, 24);
////            this.lblSelectedOrder.Text = "No order selected";
////            this.lblSelectedOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
////            this.lblSelectedOrder.ForeColor = System.Drawing.Color.FromArgb(100, 100, 130);
////            this.lblSelectedOrder.TabIndex = 5;

////            // lblUpdateStatus
////            this.lblUpdateStatus.AutoSize = false;
////            this.lblUpdateStatus.Location = new System.Drawing.Point(400, 28);
////            this.lblUpdateStatus.Size = new System.Drawing.Size(110, 26);
////            this.lblUpdateStatus.Text = "New Status:";
////            this.lblUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
////            this.lblUpdateStatus.ForeColor = System.Drawing.Color.FromArgb(40, 40, 80);
////            this.lblUpdateStatus.TabIndex = 2;
////            this.lblUpdateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

////            // cmbStatus
////            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
////            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
////            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
////            this.cmbStatus.FormattingEnabled = true;
////            this.cmbStatus.Location = new System.Drawing.Point(518, 26);
////            this.cmbStatus.Size = new System.Drawing.Size(160, 28);
////            this.cmbStatus.TabIndex = 1;
////            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);

////            // btnUpdateStatus  ← FIXED: wired to btnUpdateStatus_Click (not _Click_1)
////            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(50, 100, 200);
////            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
////            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
////            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
////            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
////            this.btnUpdateStatus.Location = new System.Drawing.Point(694, 22);
////            this.btnUpdateStatus.Size = new System.Drawing.Size(150, 36);
////            this.btnUpdateStatus.TabIndex = 4;
////            this.btnUpdateStatus.Text = "✔  Update Status";
////            this.btnUpdateStatus.UseVisualStyleBackColor = false;
////            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
////            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);   // ← FIXED

////            // btnRefresh
////            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(90, 180, 130);
////            this.btnRefresh.ForeColor = System.Drawing.Color.White;
////            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
////            this.btnRefresh.FlatAppearance.BorderSize = 0;
////            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
////            this.btnRefresh.Location = new System.Drawing.Point(858, 22);
////            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
////            this.btnRefresh.TabIndex = 3;
////            this.btnRefresh.Text = "⟳  Refresh";
////            this.btnRefresh.UseVisualStyleBackColor = false;
////            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
////            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

////            // ──────────────────────────────────────────
////            // frmManagebooking
////            // ──────────────────────────────────────────
////            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
////            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
////            this.BackColor = System.Drawing.Color.White;
////            this.ClientSize = new System.Drawing.Size(1000, 560);
////            this.MinimumSize = new System.Drawing.Size(800, 500);
////            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
////            this.Name = "frmManagebooking";
////            this.Text = "Manage booking — E-Commerce System";
////            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

////            this.Controls.Add(this.dgvbooking);
////            this.Controls.Add(this.pnlTop);
////            this.Controls.Add(this.pnlBottom);

////            // ── FIXED: Load event wired to correct method (not _Load_1) ──
////            this.Load += new System.EventHandler(this.frmManagebooking_Load);

////            ((System.ComponentModel.ISupportInitialize)(this.dgvbooking)).EndInit();
////            this.pnlTop.ResumeLayout(false);
////            this.pnlBottom.ResumeLayout(false);
////            this.ResumeLayout(false);
////        }

////        #endregion

////        private System.Windows.Forms.DataGridView dgvbooking;
////        private System.Windows.Forms.ComboBox cmbStatus;
////        private System.Windows.Forms.Label lblUpdateStatus;
////        // Old field name was "UpdateStatus" — renamed to lblUpdateStatus
////        // If your .cs file references "UpdateStatus" as a field name, rename it to lblUpdateStatus too.
////        private System.Windows.Forms.Button btnRefresh;
////        private System.Windows.Forms.Button btnUpdateStatus;
////        private System.Windows.Forms.Label lblTitle;
////        private System.Windows.Forms.Panel pnlTop;
////        private System.Windows.Forms.Panel pnlBottom;
////        private System.Windows.Forms.Label lblSelectedOrder;
////    }
////}