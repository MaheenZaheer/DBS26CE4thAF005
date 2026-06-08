using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManageComplaints
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
            Color bg = Color.FromArgb(18, 18, 18);
            Color card = Color.FromArgb(38, 38, 38);
            Color accent = Color.FromArgb(230, 180, 80);
            Color textMain = Color.FromArgb(240, 240, 240);
            Color textDim = Color.FromArgb(160, 160, 160);
            Color gridBg = Color.FromArgb(32, 32, 32);
            Color green = Color.FromArgb(76, 175, 80);

            this.grpFileComplaint = new Panel();
            this.lblParcelID = new Label();
            this.txtParcelID = new TextBox();
            this.lblSubject = new Label();
            this.txtSubject = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.btnFileComplaint = new Button();
            this.grpResolve = new Panel();
            this.lblSelComplaintID = new Label();
            this.lblSelSubject = new Label();
            this.lblSelStatus = new Label();
            this.lblRemarks = new Label();
            this.txtRemarks = new TextBox();
            this.btnResolve = new Button();
            this.dgvComplaints = new DataGridView();
            this.btnRefresh = new Button();
            this.pnlHeader = new Panel();
            this.lblPageTitle = new Label();
            // resolve info labels
            this.lblCIDcap = new Label();
            this.lblSubjCap = new Label();
            this.lblStCap = new Label();
            // file section label
            this.lblFileSec = new Label();
            this.lblResolveSec = new Label();

            this.grpFileComplaint.SuspendLayout();
            this.grpResolve.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).BeginInit();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────
            this.BackColor = bg;
            this.ForeColor = textMain;
            this.ClientSize = new Size(1280, 800);
            this.Text = "Manage Complaints — CourierDB";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1280, 800);
            this.Font = new Font("Segoe UI", 9.5f);
            this.Load += new System.EventHandler(this.frmManageComplaints_Load);

            // ── Header bar ────────────────────────────────────────────
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 55;
            this.pnlHeader.BackColor = Color.FromArgb(24, 24, 24);

            this.lblPageTitle.Text = "📣  Manage Complaints";
            this.lblPageTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            this.lblPageTitle.ForeColor = textMain;
            this.lblPageTitle.Dock = DockStyle.Fill;
            this.lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;
            this.lblPageTitle.Padding = new Padding(20, 0, 0, 0);
            this.pnlHeader.Controls.Add(this.lblPageTitle);

            // ══════════════════════════════════════════════════════════
            // FILE COMPLAINT panel (Customer)
            // ══════════════════════════════════════════════════════════
            this.grpFileComplaint.Location = new Point(16, 65);
            this.grpFileComplaint.Size = new Size(828, 160);
            this.grpFileComplaint.BackColor = card;

            this.lblFileSec.Text = "FILE A NEW COMPLAINT";
            this.lblFileSec.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            this.lblFileSec.ForeColor = accent;
            this.lblFileSec.Location = new Point(12, 10);
            this.lblFileSec.AutoSize = true;

            // Parcel ID row
            FL(this.lblParcelID, "Parcel ID (optional):", 12, 36, 148, textDim);
            FT(this.txtParcelID, 165, 34, 100, card, textMain);

            // Subject row
            FL(this.lblSubject, "Subject:", 12, 70, 148, textDim);
            FT(this.txtSubject, 165, 68, 645, card, textMain);

            // Description row
            FL(this.lblDescription, "Description:", 12, 104, 148, textDim);
            FT(this.txtDescription, 165, 102, 645, card, textMain);

            // Submit button — bottom right of panel, NO overlap
            this.btnFileComplaint.Location = new Point(660, 126);
            this.btnFileComplaint.Size = new Size(155, 30);
            this.btnFileComplaint.Text = "📨  Submit Complaint";
            this.btnFileComplaint.FlatStyle = FlatStyle.Flat;
            this.btnFileComplaint.FlatAppearance.BorderSize = 0;
            this.btnFileComplaint.BackColor = Color.FromArgb(25, 100, 180);
            this.btnFileComplaint.ForeColor = Color.White;
            this.btnFileComplaint.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.btnFileComplaint.Cursor = Cursors.Hand;
            this.btnFileComplaint.Click += new System.EventHandler(this.btnFileComplaint_Click);

            this.grpFileComplaint.Controls.AddRange(new Control[] {
                this.lblFileSec,
                this.lblParcelID,    this.txtParcelID,
                this.lblSubject,     this.txtSubject,
                this.lblDescription, this.txtDescription,
                this.btnFileComplaint
            });

            // ══════════════════════════════════════════════════════════
            // RESOLVE panel (Admin/Seller)
            // ══════════════════════════════════════════════════════════
            this.grpResolve.Location = new Point(16, 65);
            this.grpResolve.Size = new Size(828, 130);
            this.grpResolve.BackColor = card;
            this.grpResolve.Visible = false;

            this.lblResolveSec.Text = "RESOLVE SELECTED COMPLAINT";
            this.lblResolveSec.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            this.lblResolveSec.ForeColor = accent;
            this.lblResolveSec.Location = new Point(12, 10);
            this.lblResolveSec.AutoSize = true;

            // Row 1: complaint info
            FL(this.lblCIDcap, "Complaint ID:", 12, 38, 105, textDim);
            this.lblSelComplaintID.Text = "-";
            this.lblSelComplaintID.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            this.lblSelComplaintID.ForeColor = accent;
            this.lblSelComplaintID.Location = new Point(120, 38);
            this.lblSelComplaintID.Size = new Size(60, 22);

            FL(this.lblSubjCap, "Subject:", 195, 38, 65, textDim);
            this.lblSelSubject.Text = "-";
            this.lblSelSubject.Font = new Font("Segoe UI", 9.5f);
            this.lblSelSubject.ForeColor = textMain;
            this.lblSelSubject.Location = new Point(263, 38);
            this.lblSelSubject.Size = new Size(260, 22);

            FL(this.lblStCap, "Status:", 535, 38, 55, textDim);
            this.lblSelStatus.Text = "-";
            this.lblSelStatus.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            this.lblSelStatus.ForeColor = green;
            this.lblSelStatus.Location = new Point(593, 38);
            this.lblSelStatus.Size = new Size(120, 22);

            // Row 2: remarks + resolve button
            FL(this.lblRemarks, "Remarks:", 12, 76, 75, textDim);
            FT(this.txtRemarks, 90, 74, 560, card, textMain);

            this.btnResolve.Location = new Point(660, 72);
            this.btnResolve.Size = new Size(155, 30);
            this.btnResolve.Text = "✔  Mark Resolved";
            this.btnResolve.FlatStyle = FlatStyle.Flat;
            this.btnResolve.FlatAppearance.BorderSize = 0;
            this.btnResolve.BackColor = Color.FromArgb(46, 125, 50);
            this.btnResolve.ForeColor = Color.White;
            this.btnResolve.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.btnResolve.Cursor = Cursors.Hand;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);

            this.grpResolve.Controls.AddRange(new Control[] {
                this.lblResolveSec,
                this.lblCIDcap,  this.lblSelComplaintID,
                this.lblSubjCap, this.lblSelSubject,
                this.lblStCap,   this.lblSelStatus,
                this.lblRemarks, this.txtRemarks,
                this.btnResolve
            });

            // ── Refresh button ────────────────────────────────────────
            this.btnRefresh.Location = new Point(732, 234);
            this.btnRefresh.Size = new Size(112, 30);
            this.btnRefresh.Text = "⟳  Refresh";
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.BackColor = Color.FromArgb(55, 55, 55);
            this.btnRefresh.ForeColor = textMain;
            this.btnRefresh.Font = new Font("Segoe UI", 9f);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── Grid ──────────────────────────────────────────────────
            this.dgvComplaints.Location = new Point(16, 272);
            this.dgvComplaints.Size = new Size(828, 355);
            this.dgvComplaints.BackgroundColor = gridBg;
            this.dgvComplaints.ForeColor = textMain;
            this.dgvComplaints.GridColor = Color.FromArgb(50, 50, 50);
            this.dgvComplaints.BorderStyle = BorderStyle.None;
            this.dgvComplaints.RowHeadersVisible = false;
            this.dgvComplaints.AllowUserToAddRows = false;
            this.dgvComplaints.ReadOnly = true;
            this.dgvComplaints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComplaints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvComplaints.EnableHeadersVisualStyles = false;
            this.dgvComplaints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComplaints.Font = new Font("Segoe UI", 9f);
            this.dgvComplaints.RowTemplate.Height = 30;
            this.dgvComplaints.DefaultCellStyle.BackColor = gridBg;
            this.dgvComplaints.DefaultCellStyle.ForeColor = textMain;
            this.dgvComplaints.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvComplaints.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvComplaints.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvComplaints.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvComplaints.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.dgvComplaints.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
            this.dgvComplaints.CellClick += new DataGridViewCellEventHandler(this.dgvComplaints_CellClick);

            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.grpFileComplaint);
            this.Controls.Add(this.grpResolve);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvComplaints);

            this.grpFileComplaint.ResumeLayout(false);
            this.grpResolve.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // helpers
        private void FL(Label l, string t, int x, int y, int w, Color fg)
        {
            l.AutoSize = false; l.Text = t; l.Location = new Point(x, y + 3);
            l.Size = new Size(w, 20); l.ForeColor = fg;
            l.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            l.TextAlign = ContentAlignment.MiddleLeft;
        }
        private void FT(TextBox tb, int x, int y, int w, Color bgCard, Color fg)
        {
            tb.Location = new Point(x, y); tb.Size = new Size(w, 26);
            tb.BackColor = Color.FromArgb(28, 28, 28);
            tb.ForeColor = fg; tb.BorderStyle = BorderStyle.FixedSingle;
            tb.Font = new Font("Segoe UI", 9.5f);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblPageTitle;
        private Panel grpFileComplaint;
        private Label lblFileSec, lblResolveSec;
        private Label lblParcelID, lblSubject, lblDescription;
        private TextBox txtParcelID, txtSubject, txtDescription;
        private Button btnFileComplaint;
        private Panel grpResolve;
        private Label lblCIDcap, lblSubjCap, lblStCap;
        private Label lblSelComplaintID, lblSelSubject, lblSelStatus;
        private Label lblRemarks;
        private TextBox txtRemarks;
        private Button btnResolve;
        private DataGridView dgvComplaints;
        private Button btnRefresh;
    }
}


//using System.Drawing;
//using System.Windows.Forms;
//using CourierDB.SoftwareClasses;

//namespace CourierDB.UI
//{
//    partial class frmManageComplaints
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
//            this.SuspendLayout();

//            // ── Palette shortcuts ─────────────────────────────────────
//            Color bg = UITheme.BgDark;
//            Color card = UITheme.BgCard;
//            Color panel = UITheme.BgPanel;
//            Color border = UITheme.BorderColor;
//            Color gold = UITheme.Accent;
//            Color txt = UITheme.TextMain;
//            Color dim = UITheme.TextDim;

//            // ── 1. Form chrome ────────────────────────────────────────
//            UITheme.ApplyForm(this, "Manage Complaints", width: 860, height: 680);

//            // ══════════════════════════════════════════════════════════
//            // HEADER  (Dock.Top, 55px)
//            // ══════════════════════════════════════════════════════════
//            Label _titleLbl;
//            var pnlHeader = UITheme.MakeHeaderPanel("📣  Manage Complaints",
//                                                    this.ClientSize.Width,
//                                                    out _titleLbl);

//            // ══════════════════════════════════════════════════════════
//            // grpFileComplaint  — dark card panel, y=65
//            // Visible only for Customer role (toggled in .cs Load)
//            // ══════════════════════════════════════════════════════════
//            grpFileComplaint = new Panel
//            {
//                Location = new Point(16, 65),
//                Size = new Size(828, 175),
//                BackColor = card
//            };

//            // Section label
//            var lblFileSec = new Label
//            {
//                Text = "FILE A NEW COMPLAINT",
//                Font = UITheme.FontSmallBold,
//                ForeColor = gold,
//                Location = new Point(12, 10),
//                AutoSize = true
//            };

//            // Row 1 — Parcel ID
//            lblParcelID = UITheme.MakeLabel("Parcel ID (optional):", 12, 40, 145);
//            lblParcelID.ForeColor = dim;
//            txtParcelID = UITheme.MakeTextBox(160, 38, 100);

//            // Row 2 — Subject
//            lblSubject = UITheme.MakeLabel("Subject:", 12, 76, 145);
//            lblSubject.ForeColor = dim;
//            txtSubject = UITheme.MakeTextBox(160, 74, 646);

//            // Row 3 — Description
//            lblDescription = UITheme.MakeLabel("Description:", 12, 112, 145);
//            lblDescription.ForeColor = dim;
//            txtDescription = UITheme.MakeTextBox(160, 110, 646);

//            // Submit button
//            btnFileComplaint = UITheme.MakeButton("📨  Submit Complaint",
//                674, 138, UITheme.BtnStyle.Primary, 152, 30);
//            btnFileComplaint.Click += new System.EventHandler(this.btnFileComplaint_Click);

//            grpFileComplaint.Controls.AddRange(new Control[] {
//                lblFileSec,
//                lblParcelID, txtParcelID,
//                lblSubject,  txtSubject,
//                lblDescription, txtDescription,
//                btnFileComplaint
//            });

//            // ══════════════════════════════════════════════════════════
//            // grpResolve  — dark card panel, same y=65
//            // Visible only for Admin role (toggled in .cs Load)
//            // ══════════════════════════════════════════════════════════
//            grpResolve = new Panel
//            {
//                Location = new Point(16, 65),
//                Size = new Size(828, 140),
//                BackColor = card,
//                Visible = false   // .cs Load() sets visibility by role
//            };

//            var lblResolveSec = new Label
//            {
//                Text = "RESOLVE SELECTED COMPLAINT",
//                Font = UITheme.FontSmallBold,
//                ForeColor = gold,
//                Location = new Point(12, 10),
//                AutoSize = true
//            };

//            // Row 1 — complaint info labels
//            var lblCIDlbl = UITheme.MakeLabel("Complaint ID:", 12, 38, 110);
//            lblCIDlbl.ForeColor = dim;
//            lblSelComplaintID = new Label
//            {
//                Text = "-",
//                Font = UITheme.FontBold,
//                ForeColor = gold,
//                Location = new Point(126, 38),
//                Size = new Size(70, 24),
//                TextAlign = ContentAlignment.MiddleLeft
//            };

//            var lblSubjLbl2 = UITheme.MakeLabel("Subject:", 210, 38, 65);
//            lblSubjLbl2.ForeColor = dim;
//            lblSelSubject = new Label
//            {
//                Text = "-",
//                Font = UITheme.FontBase,
//                ForeColor = txt,
//                Location = new Point(278, 38),
//                Size = new Size(240, 24),
//                TextAlign = ContentAlignment.MiddleLeft
//            };

//            var lblStLbl = UITheme.MakeLabel("Status:", 530, 38, 60);
//            lblStLbl.ForeColor = dim;
//            lblSelStatus = new Label
//            {
//                Text = "-",
//                Font = UITheme.FontBold,
//                ForeColor = UITheme.AccentGreen,
//                Location = new Point(593, 38),
//                Size = new Size(120, 24),
//                TextAlign = ContentAlignment.MiddleLeft
//            };

//            // Row 2 — remarks + resolve button
//            lblRemarks = UITheme.MakeLabel("Resolution Remarks:", 12, 80, 145);
//            lblRemarks.ForeColor = dim;
//            txtRemarks = UITheme.MakeTextBox(160, 78, 480);

//            btnResolve = UITheme.MakeButton("✔  Mark Resolved",
//                654, 76, UITheme.BtnStyle.Success, 160, 32);
//            btnResolve.Click += new System.EventHandler(this.btnResolve_Click);

//            grpResolve.Controls.AddRange(new Control[] {
//                lblResolveSec,
//                lblCIDlbl,  lblSelComplaintID,
//                lblSubjLbl2, lblSelSubject,
//                lblStLbl,   lblSelStatus,
//                lblRemarks, txtRemarks,
//                btnResolve
//            });

//            // ══════════════════════════════════════════════════════════
//            // Refresh button  (top-right, just above grid)
//            // ══════════════════════════════════════════════════════════
//            btnRefresh = UITheme.MakeButton("⟳  Refresh",
//                728, 216, UITheme.BtnStyle.Secondary, 116, 30);
//            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

//            // ══════════════════════════════════════════════════════════
//            // DataGridView
//            // ══════════════════════════════════════════════════════════
//            dgvComplaints = new DataGridView
//            {
//                Location = new Point(16, 254),
//                Size = new Size(828, 390),
//                Anchor = AnchorStyles.Top | AnchorStyles.Bottom
//                         | AnchorStyles.Left | AnchorStyles.Right
//            };
//            UITheme.ApplyDataGridView(dgvComplaints);
//            dgvComplaints.CellClick += new DataGridViewCellEventHandler(
//                this.dgvComplaints_CellClick);

//            // ── Wire all controls to form ─────────────────────────────
//            this.Controls.Add(pnlHeader);        // Dock.Top — must be first
//            this.Controls.Add(grpFileComplaint);
//            this.Controls.Add(grpResolve);
//            this.Controls.Add(btnRefresh);
//            this.Controls.Add(dgvComplaints);

//            this.Load += new System.EventHandler(this.frmManageComplaints_Load);
//            this.ResumeLayout(false);
//        }

//        #endregion

//        // ── Controls ──────────────────────────────────────────────────
//        private Panel grpFileComplaint;
//        private System.Windows.Forms.Label lblParcelID;
//        private System.Windows.Forms.TextBox txtParcelID;
//        private System.Windows.Forms.Label lblSubject;
//        private System.Windows.Forms.TextBox txtSubject;
//        private System.Windows.Forms.Label lblDescription;
//        private System.Windows.Forms.TextBox txtDescription;
//        private System.Windows.Forms.Button btnFileComplaint;

//        private Panel grpResolve;
//        private System.Windows.Forms.Label lblSelComplaintID;
//        private System.Windows.Forms.Label lblSelSubject;
//        private System.Windows.Forms.Label lblSelStatus;
//        private System.Windows.Forms.Label lblRemarks;
//        private System.Windows.Forms.TextBox txtRemarks;
//        private System.Windows.Forms.Button btnResolve;

//        private System.Windows.Forms.DataGridView dgvComplaints;
//        private System.Windows.Forms.Button btnRefresh;
//    }
//}


////using CourierDB.SoftwareClasses;

////namespace CourierDB.UI
////{
////    partial class frmManageComplaints
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
////            this.lblTitle            = new System.Windows.Forms.Label();
////            // File Complaint group (Customer)
////            this.grpFileComplaint    = new System.Windows.Forms.GroupBox();
////            this.lblParcelID         = new System.Windows.Forms.Label();
////            this.txtParcelID         = new System.Windows.Forms.TextBox();
////            this.lblSubject          = new System.Windows.Forms.Label();
////            this.txtSubject          = new System.Windows.Forms.TextBox();
////            this.lblDescription      = new System.Windows.Forms.Label();
////            this.txtDescription      = new System.Windows.Forms.TextBox();
////            this.btnFileComplaint    = new System.Windows.Forms.Button();
////            // Resolve group (Admin)
////            this.grpResolve          = new System.Windows.Forms.GroupBox();
////            this.lblSelComplaint     = new System.Windows.Forms.Label();
////            this.lblSelComplaintID   = new System.Windows.Forms.Label();
////            this.lblSelSubjectLbl    = new System.Windows.Forms.Label();
////            this.lblSelSubject       = new System.Windows.Forms.Label();
////            this.lblSelStatusLbl     = new System.Windows.Forms.Label();
////            this.lblSelStatus        = new System.Windows.Forms.Label();
////            this.lblRemarks          = new System.Windows.Forms.Label();
////            this.txtRemarks          = new System.Windows.Forms.TextBox();
////            this.btnResolve          = new System.Windows.Forms.Button();
////            // Grid & Refresh
////            this.dgvComplaints       = new System.Windows.Forms.DataGridView();
////            this.btnRefresh          = new System.Windows.Forms.Button();

////            this.grpFileComplaint.SuspendLayout();
////            this.grpResolve.SuspendLayout();
////            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).BeginInit();
////            this.SuspendLayout();

////            // lblTitle
////            this.lblTitle.AutoSize = true;
////            this.lblTitle.Font     = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
////            this.lblTitle.Location = new System.Drawing.Point(240, 12);
////            this.lblTitle.Text     = "Manage Complaints";

////            // ── grpFileComplaint ──────────────────────────────────
////            this.grpFileComplaint.Location = new System.Drawing.Point(20, 45);
////            this.grpFileComplaint.Size     = new System.Drawing.Size(750, 175);
////            this.grpFileComplaint.Text     = "File a New Complaint";

////            this.lblParcelID.AutoSize  = true;
////            this.lblParcelID.Location  = new System.Drawing.Point(10, 28);
////            this.lblParcelID.Text      = "Parcel ID (optional):";
////            this.txtParcelID.Location  = new System.Drawing.Point(140, 25);
////            this.txtParcelID.Size      = new System.Drawing.Size(100, 26);

////            this.lblSubject.AutoSize   = true;
////            this.lblSubject.Location   = new System.Drawing.Point(10, 62);
////            this.lblSubject.Text       = "Subject:";
////            this.txtSubject.Location   = new System.Drawing.Point(140, 59);
////            this.txtSubject.Size       = new System.Drawing.Size(580, 26);

////            this.lblDescription.AutoSize = true;
////            this.lblDescription.Location = new System.Drawing.Point(10, 97);
////            this.lblDescription.Text     = "Description:";
////            this.txtDescription.Location = new System.Drawing.Point(140, 94);
////            this.txtDescription.Size     = new System.Drawing.Size(580, 26);
////            this.txtDescription.Multiline = false;

////            this.btnFileComplaint.Location = new System.Drawing.Point(540, 133);
////            this.btnFileComplaint.Size     = new System.Drawing.Size(180, 30);
////            this.btnFileComplaint.Text     = "Submit Complaint";
////            this.btnFileComplaint.BackColor = System.Drawing.Color.SteelBlue;
////            this.btnFileComplaint.ForeColor = System.Drawing.Color.White;
////            this.btnFileComplaint.UseVisualStyleBackColor = false;
////            this.btnFileComplaint.Click   += new System.EventHandler(this.btnFileComplaint_Click);

////            this.grpFileComplaint.Controls.AddRange(new System.Windows.Forms.Control[] {
////                this.lblParcelID, this.txtParcelID,
////                this.lblSubject,  this.txtSubject,
////                this.lblDescription, this.txtDescription,
////                this.btnFileComplaint
////            });

////            // ── grpResolve ────────────────────────────────────────
////            this.grpResolve.Location = new System.Drawing.Point(20, 45);
////            this.grpResolve.Size     = new System.Drawing.Size(750, 140);
////            this.grpResolve.Text     = "Resolve Selected Complaint";

////            this.lblSelComplaint.AutoSize  = true;
////            this.lblSelComplaint.Location  = new System.Drawing.Point(10, 28);
////            this.lblSelComplaint.Text      = "Complaint ID:";
////            this.lblSelComplaintID.AutoSize = true;
////            this.lblSelComplaintID.Location = new System.Drawing.Point(120, 28);
////            this.lblSelComplaintID.Text     = "-";
////            this.lblSelComplaintID.Font     = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);

////            this.lblSelSubjectLbl.AutoSize = true;
////            this.lblSelSubjectLbl.Location = new System.Drawing.Point(220, 28);
////            this.lblSelSubjectLbl.Text     = "Subject:";
////            this.lblSelSubject.AutoSize    = true;
////            this.lblSelSubject.Location    = new System.Drawing.Point(285, 28);
////            this.lblSelSubject.Text        = "-";

////            this.lblSelStatusLbl.AutoSize  = true;
////            this.lblSelStatusLbl.Location  = new System.Drawing.Point(550, 28);
////            this.lblSelStatusLbl.Text      = "Status:";
////            this.lblSelStatus.AutoSize     = true;
////            this.lblSelStatus.Location     = new System.Drawing.Point(610, 28);
////            this.lblSelStatus.Text         = "-";
////            this.lblSelStatus.Font         = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);

////            this.lblRemarks.AutoSize  = true;
////            this.lblRemarks.Location  = new System.Drawing.Point(10, 65);
////            this.lblRemarks.Text      = "Resolution Remarks:";
////            this.txtRemarks.Location  = new System.Drawing.Point(155, 62);
////            this.txtRemarks.Size      = new System.Drawing.Size(440, 26);

////            this.btnResolve.Location  = new System.Drawing.Point(610, 62);
////            this.btnResolve.Size      = new System.Drawing.Size(120, 30);
////            this.btnResolve.Text      = "Mark Resolved";
////            this.btnResolve.BackColor = System.Drawing.Color.ForestGreen;
////            this.btnResolve.ForeColor = System.Drawing.Color.White;
////            this.btnResolve.UseVisualStyleBackColor = false;
////            this.btnResolve.Click    += new System.EventHandler(this.btnResolve_Click);

////            this.grpResolve.Controls.AddRange(new System.Windows.Forms.Control[] {
////                this.lblSelComplaint,  this.lblSelComplaintID,
////                this.lblSelSubjectLbl, this.lblSelSubject,
////                this.lblSelStatusLbl,  this.lblSelStatus,
////                this.lblRemarks,       this.txtRemarks,
////                this.btnResolve
////            });

////            // btnRefresh
////            this.btnRefresh.Location  = new System.Drawing.Point(660, 200);
////            this.btnRefresh.Size      = new System.Drawing.Size(110, 30);
////            this.btnRefresh.Text      = "Refresh";
////            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

////            // dgvComplaints
////            this.dgvComplaints.Location            = new System.Drawing.Point(20, 240);
////            this.dgvComplaints.Size                = new System.Drawing.Size(750, 300);
////            this.dgvComplaints.AllowUserToAddRows  = false;
////            this.dgvComplaints.ReadOnly            = true;
////            this.dgvComplaints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
////            this.dgvComplaints.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
////            this.dgvComplaints.CellClick          += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComplaints_CellClick);

////            // Form
////            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
////            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
////            this.ClientSize          = new System.Drawing.Size(800, 565);
////            this.Text                = "Manage Complaints — CourierDB";
////            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
////            this.Load               += new System.EventHandler(this.frmManageComplaints_Load);
////            this.Controls.AddRange(new System.Windows.Forms.Control[] {
////                this.lblTitle, this.grpFileComplaint, this.grpResolve,
////                this.btnRefresh, this.dgvComplaints
////            });

////            this.grpFileComplaint.ResumeLayout(false);
////            this.grpResolve.ResumeLayout(false);
////            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).EndInit();
////            this.ResumeLayout(false);
////            this.PerformLayout();
////        }

////        #endregion

////        private System.Windows.Forms.Label         lblTitle;
////        private System.Windows.Forms.GroupBox      grpFileComplaint;
////        private System.Windows.Forms.Label         lblParcelID;
////        private System.Windows.Forms.TextBox       txtParcelID;
////        private System.Windows.Forms.Label         lblSubject;
////        private System.Windows.Forms.TextBox       txtSubject;
////        private System.Windows.Forms.Label         lblDescription;
////        private System.Windows.Forms.TextBox       txtDescription;
////        private System.Windows.Forms.Button        btnFileComplaint;
////        private System.Windows.Forms.GroupBox      grpResolve;
////        private System.Windows.Forms.Label         lblSelComplaint;
////        private System.Windows.Forms.Label         lblSelComplaintID;
////        private System.Windows.Forms.Label         lblSelSubjectLbl;
////        private System.Windows.Forms.Label         lblSelSubject;
////        private System.Windows.Forms.Label         lblSelStatusLbl;
////        private System.Windows.Forms.Label         lblSelStatus;
////        private System.Windows.Forms.Label         lblRemarks;
////        private System.Windows.Forms.TextBox       txtRemarks;
////        private System.Windows.Forms.Button        btnResolve;
////        private System.Windows.Forms.DataGridView  dgvComplaints;
////        private System.Windows.Forms.Button        btnRefresh;
////    }
////}
