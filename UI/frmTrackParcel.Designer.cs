using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmTrackParcel
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
            Color bg       = Color.FromArgb(18, 18, 18);
            Color card     = Color.FromArgb(38, 38, 38);
            Color accent   = Color.FromArgb(230, 180, 80);
            Color textMain = Color.FromArgb(240, 240, 240);
            Color textDim  = Color.FromArgb(160, 160, 160);
            Color gridBg   = Color.FromArgb(32, 32, 32);

            this.lblTitle           = new Label();
            this.lblEnterCode       = new Label();
            this.txtTrackingCode    = new TextBox();
            this.btnTrack           = new Button();
            this.btnClear           = new Button();
            this.grpDetails         = new GroupBox();
            this.lblTrackingCode    = new Label();
            this.lblTrackingCodeVal = new Label();
            this.lblSender          = new Label();
            this.lblSenderVal       = new Label();
            this.lblReceiver        = new Label();
            this.lblReceiverVal     = new Label();
            this.lblReceiverCity    = new Label();
            this.lblReceiverCityVal = new Label();
            this.lblWeight          = new Label();
            this.lblWeightVal       = new Label();
            this.lblParcelType      = new Label();
            this.lblParcelTypeVal   = new Label();
            this.lblStatus          = new Label();
            this.lblStatusVal       = new Label();
            this.lblZone            = new Label();
            this.lblZoneVal         = new Label();
            this.lblAmount          = new Label();
            this.lblAmountVal       = new Label();
            this.lblBookedOn        = new Label();
            this.lblBookedOnVal     = new Label();
            this.dgvResult          = new DataGridView();
            this.grpLog             = new GroupBox();
            this.dgvLog             = new DataGridView();

            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────
            this.BackColor     = bg;
            this.ForeColor     = textMain;
            this.ClientSize    = new Size(1100, 750);
            this.MinimumSize   = new Size(900, 650);
            this.Text          = "Track Parcel — CourierDB";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font          = new Font("Segoe UI", 9.5f);
            this.WindowState   = FormWindowState.Maximized;

            // ── Title ─────────────────────────────────────────────────
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new Font("Segoe UI", 16f, FontStyle.Bold);
            this.lblTitle.ForeColor = accent;
            this.lblTitle.Location  = new Point(20, 18);
            this.lblTitle.Text      = "🔍  Track Your Parcel";

            // ── Search bar ────────────────────────────────────────────
            this.lblEnterCode.AutoSize  = true;
            this.lblEnterCode.Font      = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.lblEnterCode.ForeColor = textDim;
            this.lblEnterCode.Location  = new Point(20, 68);
            this.lblEnterCode.Text      = "Tracking Code:";

            this.txtTrackingCode.Location    = new Point(148, 64);
            this.txtTrackingCode.Size        = new Size(320, 30);
            this.txtTrackingCode.BackColor   = card;
            this.txtTrackingCode.ForeColor   = textMain;
            this.txtTrackingCode.BorderStyle = BorderStyle.FixedSingle;
            this.txtTrackingCode.Font        = new Font("Segoe UI", 11f);

            this.btnTrack.Location                  = new Point(478, 62);
            this.btnTrack.Size                      = new Size(120, 36);
            this.btnTrack.Text                      = "▶  Track";
            this.btnTrack.FlatStyle                 = FlatStyle.Flat;
            this.btnTrack.FlatAppearance.BorderSize = 0;
            this.btnTrack.BackColor                 = accent;
            this.btnTrack.ForeColor                 = Color.Black;
            this.btnTrack.Font                      = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.btnTrack.Cursor                    = Cursors.Hand;
            this.btnTrack.Click                    += new System.EventHandler(this.btnTrack_Click);

            this.btnClear.Location                  = new Point(608, 62);
            this.btnClear.Size                      = new Size(100, 36);
            this.btnClear.Text                      = "↺  Clear";
            this.btnClear.FlatStyle                 = FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.BackColor                 = Color.FromArgb(55, 55, 55);
            this.btnClear.ForeColor                 = textMain;
            this.btnClear.Font                      = new Font("Segoe UI", 10f);
            this.btnClear.Cursor                    = Cursors.Hand;
            this.btnClear.Click                    += new System.EventHandler(this.btnClear_Click);

            // ── Parcel Details GroupBox ───────────────────────────────
            this.grpDetails.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.grpDetails.Location  = new Point(20, 112);
            this.grpDetails.Size      = new Size(1060, 250);
            this.grpDetails.Text      = "📦 Parcel Details";
            this.grpDetails.ForeColor = textDim;
            this.grpDetails.BackColor = card;
            this.grpDetails.Font      = new Font("Segoe UI", 10f);
            this.grpDetails.Padding   = new Padding(12, 8, 12, 8);

            int rowH = 40, startY = 30;

            // Left column (x=16)
            AddRow(this.grpDetails, this.lblTrackingCode,  "Tracking Code:", this.lblTrackingCodeVal, "-", 16, startY + rowH * 0, accent, textMain);
            AddRow(this.grpDetails, this.lblSender,        "Sender:",         this.lblSenderVal,       "-", 16, startY + rowH * 1, accent, textMain);
            AddRow(this.grpDetails, this.lblReceiver,      "Receiver:",       this.lblReceiverVal,     "-", 16, startY + rowH * 2, accent, textMain);
            AddRow(this.grpDetails, this.lblReceiverCity,  "Dest. City:",     this.lblReceiverCityVal, "-", 16, startY + rowH * 3, accent, textMain);
            AddRow(this.grpDetails, this.lblWeight,        "Weight (kg):",    this.lblWeightVal,       "-", 16, startY + rowH * 4, accent, textMain);

            // Right column (x=530)
            AddRow(this.grpDetails, this.lblParcelType, "Type:",    this.lblParcelTypeVal,  "-", 530, startY + rowH * 0, accent, textMain);
            AddRow(this.grpDetails, this.lblStatus,     "Status:",  this.lblStatusVal,      "-", 530, startY + rowH * 1, accent, textMain);
            AddRow(this.grpDetails, this.lblZone,       "Zone:",    this.lblZoneVal,        "-", 530, startY + rowH * 2, accent, textMain);
            AddRow(this.grpDetails, this.lblAmount,     "Amount:",  this.lblAmountVal,      "-", 530, startY + rowH * 3, accent, textMain);
            AddRow(this.grpDetails, this.lblBookedOn,   "Booked:",  this.lblBookedOnVal,    "-", 530, startY + rowH * 4, accent, textMain);

            // ── dgvResult — hidden data holder ────────────────────────
            this.dgvResult.Location          = new Point(0, 0);
            this.dgvResult.Size              = new Size(1, 1);
            this.dgvResult.Visible           = false;
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.ReadOnly          = true;
            this.dgvResult.CellClick        += new DataGridViewCellEventHandler(this.dgvResult_CellClick);

            // ── Tracking History GroupBox ─────────────────────────────
            this.grpLog.Anchor    = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.grpLog.Location  = new Point(20, 370);
            this.grpLog.Size      = new Size(1060, 348);
            this.grpLog.Text      = "📋  Tracking History";
            this.grpLog.ForeColor = textDim;
            this.grpLog.BackColor = card;
            this.grpLog.Font      = new Font("Segoe UI", 10f);
            this.grpLog.Padding   = new Padding(8, 6, 8, 8);

            this.dgvLog.Dock                                     = DockStyle.Fill;
            this.dgvLog.BackgroundColor                          = gridBg;
            this.dgvLog.ForeColor                                = textMain;
            this.dgvLog.GridColor                                = Color.FromArgb(50, 50, 50);
            this.dgvLog.BorderStyle                              = BorderStyle.None;
            this.dgvLog.RowHeadersVisible                        = false;
            this.dgvLog.AllowUserToAddRows                       = false;
            this.dgvLog.ReadOnly                                 = true;
            this.dgvLog.AutoSizeColumnsMode                      = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.SelectionMode                            = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.EnableHeadersVisualStyles                = false;
            this.dgvLog.ColumnHeadersHeightSizeMode              = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Font                                     = new Font("Segoe UI", 10f);
            this.dgvLog.RowTemplate.Height                       = 34;
            this.dgvLog.DefaultCellStyle.BackColor               = gridBg;
            this.dgvLog.DefaultCellStyle.ForeColor               = textMain;
            this.dgvLog.DefaultCellStyle.SelectionBackColor      = Color.FromArgb(60, 60, 80);
            this.dgvLog.DefaultCellStyle.SelectionForeColor      = Color.White;
            this.dgvLog.DefaultCellStyle.Font                    = new Font("Segoe UI", 9.5f);
            this.dgvLog.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(45, 45, 45);
            this.dgvLog.ColumnHeadersDefaultCellStyle.ForeColor  = accent;
            this.dgvLog.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.dgvLog.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
            this.grpLog.Controls.Add(this.dgvLog);

            this.Controls.AddRange(new Control[] {
                this.lblTitle,
                this.lblEnterCode, this.txtTrackingCode,
                this.btnTrack, this.btnClear,
                this.grpDetails,
                this.dgvResult,
                this.grpLog
            });

            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.grpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void AddRow(Control parent, Label lbl, string cap, Label val,
            string def, int x, int y, Color lc, Color vc)
        {
            lbl.AutoSize  = false;
            lbl.Location  = new Point(x, y);
            lbl.Size      = new Size(130, 26);
            lbl.Text      = cap;
            lbl.ForeColor = lc;
            lbl.Font      = new Font("Segoe UI", 10f, FontStyle.Bold);
            lbl.BackColor = Color.Transparent;
            lbl.TextAlign = ContentAlignment.MiddleLeft;

            val.AutoSize  = false;
            val.Location  = new Point(x + 130, y);
            val.Size      = new Size(360, 26);
            val.Text      = def;
            val.ForeColor = vc;
            val.Font      = new Font("Segoe UI", 10f);
            val.BackColor = Color.Transparent;
            val.TextAlign = ContentAlignment.MiddleLeft;

            parent.Controls.Add(lbl);
            parent.Controls.Add(val);
        }

        #endregion

        private Label        lblTitle, lblEnterCode;
        private TextBox      txtTrackingCode;
        private Button       btnTrack, btnClear;
        private GroupBox     grpDetails, grpLog;
        private Label        lblTrackingCode,  lblTrackingCodeVal;
        private Label        lblSender,        lblSenderVal;
        private Label        lblReceiver,      lblReceiverVal;
        private Label        lblReceiverCity,  lblReceiverCityVal;
        private Label        lblWeight,        lblWeightVal;
        private Label        lblParcelType,    lblParcelTypeVal;
        private Label        lblStatus,        lblStatusVal;
        private Label        lblZone,          lblZoneVal;
        private Label        lblAmount,        lblAmountVal;
        private Label        lblBookedOn,      lblBookedOnVal;
        private DataGridView dgvResult,        dgvLog;
    }
}
