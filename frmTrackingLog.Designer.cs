using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmTrackingLog
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

            this.lblTitle = new Label();
            this.lblParcelIDLbl = new Label();
            this.txtParcelID = new TextBox();
            this.btnLoadLog = new Button();
            this.btnClear = new Button();
            this.grpHeader = new GroupBox();
            this.lblTracking = new Label();
            this.lblTrackingVal = new Label();
            this.lblSender = new Label();
            this.lblSenderVal = new Label();
            this.lblReceiver = new Label();
            this.lblReceiverVal = new Label();
            this.lblCurrStatus = new Label();
            this.lblCurrStatusVal = new Label();
            this.lblLogCount = new Label();
            this.dgvLog = new DataGridView();

            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();

            // Form
            this.BackColor = bg;
            this.ForeColor = textMain;
            this.ClientSize = new Size(1920, 1080);
            this.Text = "Tracking Log — CourierDB";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f);
            this.MinimumSize = new Size(1280, 800);

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
            this.lblTitle.ForeColor = accent;
            this.lblTitle.Location = new Point(30, 25);
            this.lblTitle.Text = "📋  Parcel Tracking Log";

            // Search bar
            this.lblParcelIDLbl.AutoSize = true;
            this.lblParcelIDLbl.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.lblParcelIDLbl.ForeColor = textDim;
            this.lblParcelIDLbl.Location = new Point(30, 75);
            this.lblParcelIDLbl.Text = "Parcel ID:";

            this.txtParcelID.Location = new Point(130, 72);
            this.txtParcelID.Size = new Size(180, 30);
            this.txtParcelID.BackColor = card;
            this.txtParcelID.ForeColor = textMain;
            this.txtParcelID.BorderStyle = BorderStyle.FixedSingle;
            this.txtParcelID.Font = new Font("Segoe UI", 11f);

            this.btnLoadLog.Location = new Point(320, 70);
            this.btnLoadLog.Size = new Size(130, 36);
            this.btnLoadLog.Text = "▶  Load Log";
            this.btnLoadLog.FlatStyle = FlatStyle.Flat;
            this.btnLoadLog.FlatAppearance.BorderSize = 0;
            this.btnLoadLog.BackColor = accent;
            this.btnLoadLog.ForeColor = Color.Black;
            this.btnLoadLog.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.btnLoadLog.Cursor = Cursors.Hand;
            this.btnLoadLog.Click += new System.EventHandler(this.btnLoadLog_Click);

            this.btnClear.Location = new Point(460, 70);
            this.btnClear.Size = new Size(100, 36);
            this.btnClear.Text = "↺  Clear";
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.BackColor = Color.FromArgb(55, 55, 55);
            this.btnClear.ForeColor = textMain;
            this.btnClear.Font = new Font("Segoe UI", 10f);
            this.btnClear.Cursor = Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // grpHeader — Parcel Summary
            this.grpHeader.Location = new Point(30, 120);
            this.grpHeader.Size = new Size(1860, 110);
            this.grpHeader.Text = "📋 Parcel Summary";
            this.grpHeader.ForeColor = textDim;
            this.grpHeader.BackColor = card;
            this.grpHeader.Font = new Font("Segoe UI", 10f);
            this.grpHeader.Padding = new Padding(15, 8, 15, 8);

            LS(this.grpHeader, this.lblTracking, "Tracking Code:", this.lblTrackingVal, "-", 20, 32, accent, textMain, 140);
            LS(this.grpHeader, this.lblSender, "Sender:", this.lblSenderVal, "-", 520, 32, accent, textMain, 100);
            LS(this.grpHeader, this.lblReceiver, "Receiver:", this.lblReceiverVal, "-", 1020, 32, accent, textMain, 110);
            LS(this.grpHeader, this.lblCurrStatus, "Status:", this.lblCurrStatusVal, "-", 20, 68, accent, Color.LimeGreen, 90);
            this.lblCurrStatusVal.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

            // lblLogCount
            this.lblLogCount.AutoSize = true;
            this.lblLogCount.Location = new Point(30, 250);
            this.lblLogCount.Text = "📊 Entries: 0";
            this.lblLogCount.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            this.lblLogCount.ForeColor = accent;

            // dgvLog
            this.dgvLog.Location = new Point(30, 280);
            this.dgvLog.Size = new Size(1860, 880);
            this.dgvLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvLog.BackgroundColor = gridBg;
            this.dgvLog.ForeColor = textMain;
            this.dgvLog.GridColor = Color.FromArgb(50, 50, 50);
            this.dgvLog.BorderStyle = BorderStyle.None;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.ReadOnly = true;
            this.dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.EnableHeadersVisualStyles = false;
            this.dgvLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Font = new Font("Segoe UI", 10f);
            this.dgvLog.RowTemplate.Height = 35;
            this.dgvLog.DefaultCellStyle.BackColor = gridBg;
            this.dgvLog.DefaultCellStyle.ForeColor = textMain;
            this.dgvLog.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvLog.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvLog.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            this.dgvLog.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvLog.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvLog.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.dgvLog.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);

            this.Controls.AddRange(new Control[] {
                this.lblTitle,
                this.lblParcelIDLbl, this.txtParcelID,
                this.btnLoadLog, this.btnClear,
                this.grpHeader, this.lblLogCount, this.dgvLog
            });

            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LS(Control parent, Label lbl, string cap, Label val,
            string def, int x, int y, Color labelColor, Color valColor, int labelWidth = 0)
        {
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            lbl.Text = cap;
            lbl.ForeColor = labelColor;
            lbl.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lbl.BackColor = Color.Transparent;
            if (labelWidth > 0)
            {
                lbl.AutoSize = false;
                lbl.Size = new Size(labelWidth, 25);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
            }

            val.AutoSize = true;
            val.Location = new Point(x + (labelWidth > 0 ? labelWidth : 105), y);
            val.Text = def;
            val.ForeColor = valColor;
            val.Font = new Font("Segoe UI", 10f);
            val.BackColor = Color.Transparent;
            val.MinimumSize = new Size(350, 25);
            val.AutoSize = false;
            val.TextAlign = ContentAlignment.MiddleLeft;

            parent.Controls.Add(lbl);
            parent.Controls.Add(val);
        }

        #endregion

        private Label lblTitle, lblParcelIDLbl, lblLogCount;
        private TextBox txtParcelID;
        private Button btnLoadLog, btnClear;
        private GroupBox grpHeader;
        private Label lblTracking, lblTrackingVal;
        private Label lblSender, lblSenderVal;
        private Label lblReceiver, lblReceiverVal;
        private Label lblCurrStatus, lblCurrStatusVal;
        private DataGridView dgvLog;
    }
}





//using System.Drawing;
//using System.Windows.Forms;

//namespace CourierDB.UI
//{
//    partial class frmTrackingLog
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
//            Color bg = Color.FromArgb(18, 18, 18);
//            Color card = Color.FromArgb(38, 38, 38);
//            Color accent = Color.FromArgb(230, 180, 80);
//            Color textMain = Color.FromArgb(240, 240, 240);
//            Color textDim = Color.FromArgb(160, 160, 160);
//            Color gridBg = Color.FromArgb(32, 32, 32);

//            this.lblTitle = new Label();
//            this.lblParcelIDLbl = new Label();
//            this.txtParcelID = new TextBox();
//            this.btnLoadLog = new Button();
//            this.btnClear = new Button();
//            this.grpHeader = new GroupBox();
//            this.lblTracking = new Label();
//            this.lblTrackingVal = new Label();
//            this.lblSender = new Label();
//            this.lblSenderVal = new Label();
//            this.lblReceiver = new Label();
//            this.lblReceiverVal = new Label();
//            this.lblCurrStatus = new Label();
//            this.lblCurrStatusVal = new Label();
//            this.lblLogCount = new Label();
//            this.dgvLog = new DataGridView();

//            this.grpHeader.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
//            this.SuspendLayout();

//            // Form
//            this.BackColor = bg;
//            this.ForeColor = textMain;
//            this.ClientSize = new Size(820, 580);
//            this.Text = "Tracking Log — CourierDB";
//            this.StartPosition = FormStartPosition.CenterScreen;
//            this.Font = new Font("Segoe UI", 9.5f);

//            // Title
//            this.lblTitle.AutoSize = true;
//            this.lblTitle.Font = new Font("Segoe UI", 15f, FontStyle.Bold);
//            this.lblTitle.ForeColor = accent;
//            this.lblTitle.Location = new Point(20, 18);
//            this.lblTitle.Text = "📋  Parcel Tracking Log";

//            // Search bar
//            this.lblParcelIDLbl.AutoSize = true;
//            this.lblParcelIDLbl.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
//            this.lblParcelIDLbl.ForeColor = textDim;
//            this.lblParcelIDLbl.Location = new Point(20, 60);
//            this.lblParcelIDLbl.Text = "Parcel ID:";

//            this.txtParcelID.Location = new Point(110, 57);
//            this.txtParcelID.Size = new Size(130, 28);
//            this.txtParcelID.BackColor = card;
//            this.txtParcelID.ForeColor = textMain;
//            this.txtParcelID.BorderStyle = BorderStyle.FixedSingle;
//            this.txtParcelID.Font = new Font("Segoe UI", 10.5f);

//            this.btnLoadLog.Location = new Point(252, 55);
//            this.btnLoadLog.Size = new Size(120, 34);
//            this.btnLoadLog.Text = "▶  Load Log";
//            this.btnLoadLog.FlatStyle = FlatStyle.Flat;
//            this.btnLoadLog.FlatAppearance.BorderSize = 0;
//            this.btnLoadLog.BackColor = accent;
//            this.btnLoadLog.ForeColor = Color.Black;
//            this.btnLoadLog.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
//            this.btnLoadLog.Cursor = Cursors.Hand;
//            this.btnLoadLog.Click += new System.EventHandler(this.btnLoadLog_Click);

//            this.btnClear.Location = new Point(382, 55);
//            this.btnClear.Size = new Size(90, 34);
//            this.btnClear.Text = "↺  Clear";
//            this.btnClear.FlatStyle = FlatStyle.Flat;
//            this.btnClear.FlatAppearance.BorderSize = 0;
//            this.btnClear.BackColor = Color.FromArgb(55, 55, 55);
//            this.btnClear.ForeColor = textMain;
//            this.btnClear.Font = new Font("Segoe UI", 9.5f);
//            this.btnClear.Cursor = Cursors.Hand;
//            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

//            // grpHeader — Parcel Summary
//            this.grpHeader.Location = new Point(20, 103);
//            this.grpHeader.Size = new Size(775, 90);
//            this.grpHeader.Text = "Parcel Summary";
//            this.grpHeader.ForeColor = textDim;
//            this.grpHeader.BackColor = card;

//            LS(this.grpHeader, this.lblTracking, "Tracking Code:", this.lblTrackingVal, "-", 12, 28, accent, textMain);
//            LS(this.grpHeader, this.lblSender, "Sender:", this.lblSenderVal, "-", 280, 28, accent, textMain);
//            LS(this.grpHeader, this.lblReceiver, "Receiver:", this.lblReceiverVal, "-", 520, 28, accent, textMain);
//            LS(this.grpHeader, this.lblCurrStatus, "Status:", this.lblCurrStatusVal, "-", 12, 58, accent, Color.LimeGreen);
//            this.lblCurrStatusVal.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

//            // lblLogCount
//            this.lblLogCount.AutoSize = true;
//            this.lblLogCount.Location = new Point(20, 205);
//            this.lblLogCount.Text = "Entries: 0";
//            this.lblLogCount.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
//            this.lblLogCount.ForeColor = textDim;

//            // dgvLog
//            this.dgvLog.Location = new Point(20, 228);
//            this.dgvLog.Size = new Size(775, 320);
//            this.dgvLog.BackgroundColor = gridBg;
//            this.dgvLog.ForeColor = textMain;
//            this.dgvLog.GridColor = Color.FromArgb(50, 50, 50);
//            this.dgvLog.BorderStyle = BorderStyle.None;
//            this.dgvLog.RowHeadersVisible = false;
//            this.dgvLog.AllowUserToAddRows = false;
//            this.dgvLog.ReadOnly = true;
//            this.dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
//            this.dgvLog.EnableHeadersVisualStyles = false;
//            this.dgvLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvLog.Font = new Font("Segoe UI", 9f);
//            this.dgvLog.RowTemplate.Height = 30;
//            this.dgvLog.DefaultCellStyle.BackColor = gridBg;
//            this.dgvLog.DefaultCellStyle.ForeColor = textMain;
//            this.dgvLog.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
//            this.dgvLog.DefaultCellStyle.SelectionForeColor = Color.White;
//            this.dgvLog.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
//            this.dgvLog.ColumnHeadersDefaultCellStyle.ForeColor = accent;
//            this.dgvLog.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
//            this.dgvLog.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);

//            this.Controls.AddRange(new Control[] {
//                this.lblTitle,
//                this.lblParcelIDLbl, this.txtParcelID,
//                this.btnLoadLog, this.btnClear,
//                this.grpHeader, this.lblLogCount, this.dgvLog
//            });

//            this.grpHeader.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        private void LS(Control parent, Label lbl, string cap, Label val,
//            string def, int x, int y, Color labelColor, Color valColor)
//        {
//            lbl.AutoSize = true;
//            lbl.Location = new Point(x, y);
//            lbl.Text = cap;
//            lbl.ForeColor = labelColor;
//            lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
//            lbl.BackColor = Color.Transparent;

//            val.AutoSize = true;
//            val.Location = new Point(x + 105, y);
//            val.Text = def;
//            val.ForeColor = valColor;
//            val.Font = new Font("Segoe UI", 9f);
//            val.BackColor = Color.Transparent;

//            parent.Controls.Add(lbl);
//            parent.Controls.Add(val);
//        }

//        #endregion

//        private Label lblTitle, lblParcelIDLbl, lblLogCount;
//        private TextBox txtParcelID;
//        private Button btnLoadLog, btnClear;
//        private GroupBox grpHeader;
//        private Label lblTracking, lblTrackingVal;
//        private Label lblSender, lblSenderVal;
//        private Label lblReceiver, lblReceiverVal;
//        private Label lblCurrStatus, lblCurrStatusVal;
//        private DataGridView dgvLog;
//    }
//}






////namespace CourierDB.UI
////{
////    partial class frmTrackingLog
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
////            this.lblTitle        = new System.Windows.Forms.Label();
////            this.lblParcelIDLbl  = new System.Windows.Forms.Label();
////            this.txtParcelID     = new System.Windows.Forms.TextBox();
////            this.btnLoadLog      = new System.Windows.Forms.Button();
////            this.btnClear        = new System.Windows.Forms.Button();
////            this.grpHeader       = new System.Windows.Forms.GroupBox();
////            this.lblTracking     = new System.Windows.Forms.Label();
////            this.lblTrackingVal  = new System.Windows.Forms.Label();
////            this.lblSender       = new System.Windows.Forms.Label();
////            this.lblSenderVal    = new System.Windows.Forms.Label();
////            this.lblReceiver     = new System.Windows.Forms.Label();
////            this.lblReceiverVal  = new System.Windows.Forms.Label();
////            this.lblCurrStatus   = new System.Windows.Forms.Label();
////            this.lblCurrStatusVal= new System.Windows.Forms.Label();
////            this.lblLogCount     = new System.Windows.Forms.Label();
////            this.dgvLog          = new System.Windows.Forms.DataGridView();
////            this.grpHeader.SuspendLayout();
////            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
////            this.SuspendLayout();

////            // lblTitle
////            this.lblTitle.AutoSize = true;
////            this.lblTitle.Font     = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
////            this.lblTitle.Location = new System.Drawing.Point(240, 12);
////            this.lblTitle.Text     = "Parcel Tracking Log";

////            // Search bar
////            this.lblParcelIDLbl.AutoSize = true;
////            this.lblParcelIDLbl.Location = new System.Drawing.Point(20, 52);
////            this.lblParcelIDLbl.Text     = "Parcel ID:";
////            this.txtParcelID.Location    = new System.Drawing.Point(100, 49);
////            this.txtParcelID.Size        = new System.Drawing.Size(120, 26);
////            this.btnLoadLog.Location     = new System.Drawing.Point(235, 47);
////            this.btnLoadLog.Size         = new System.Drawing.Size(100, 30);
////            this.btnLoadLog.Text         = "Load Log";
////            this.btnLoadLog.BackColor    = System.Drawing.Color.SteelBlue;
////            this.btnLoadLog.ForeColor    = System.Drawing.Color.White;
////            this.btnLoadLog.UseVisualStyleBackColor = false;
////            this.btnLoadLog.Click       += new System.EventHandler(this.btnLoadLog_Click);
////            this.btnClear.Location       = new System.Drawing.Point(345, 47);
////            this.btnClear.Size           = new System.Drawing.Size(80, 30);
////            this.btnClear.Text           = "Clear";
////            this.btnClear.Click         += new System.EventHandler(this.btnClear_Click);

////            // grpHeader
////            this.grpHeader.Location = new System.Drawing.Point(20, 90);
////            this.grpHeader.Size     = new System.Drawing.Size(750, 80);
////            this.grpHeader.Text     = "Parcel Summary";

////            L(this.grpHeader, this.lblTracking,  "Tracking Code:", this.lblTrackingVal,  "-", 10, 25);
////            L(this.grpHeader, this.lblSender,    "Sender:",         this.lblSenderVal,    "-", 220, 25);
////            L(this.grpHeader, this.lblReceiver,  "Receiver:",       this.lblReceiverVal,  "-", 440, 25);
////            L(this.grpHeader, this.lblCurrStatus,"Current Status:", this.lblCurrStatusVal,"-", 10, 50);
////            this.lblCurrStatusVal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);

////            // lblLogCount
////            this.lblLogCount.AutoSize = true;
////            this.lblLogCount.Location = new System.Drawing.Point(20, 182);
////            this.lblLogCount.Text     = "Entries: 0";
////            this.lblLogCount.Font     = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);

////            // dgvLog
////            this.dgvLog.Location            = new System.Drawing.Point(20, 205);
////            this.dgvLog.Size                = new System.Drawing.Size(750, 330);
////            this.dgvLog.AllowUserToAddRows  = false;
////            this.dgvLog.ReadOnly            = true;
////            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
////            this.dgvLog.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

////            // Form
////            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
////            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
////            this.ClientSize          = new System.Drawing.Size(800, 558);
////            this.Text                = "Tracking Log — CourierDB";
////            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
////            this.Controls.AddRange(new System.Windows.Forms.Control[] {
////                this.lblTitle,
////                this.lblParcelIDLbl, this.txtParcelID, this.btnLoadLog, this.btnClear,
////                this.grpHeader, this.lblLogCount, this.dgvLog
////            });

////            this.grpHeader.ResumeLayout(false);
////            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
////            this.ResumeLayout(false);
////            this.PerformLayout();
////        }

////        private void L(System.Windows.Forms.Control parent,
////            System.Windows.Forms.Label lbl, string cap,
////            System.Windows.Forms.Label val, string def, int x, int y)
////        {
////            lbl.AutoSize = true; lbl.Location = new System.Drawing.Point(x, y); lbl.Text = cap;
////            val.AutoSize = true; val.Location = new System.Drawing.Point(x + 110, y); val.Text = def;
////            parent.Controls.Add(lbl); parent.Controls.Add(val);
////        }

////        #endregion

////        private System.Windows.Forms.Label         lblTitle;
////        private System.Windows.Forms.Label         lblParcelIDLbl;
////        private System.Windows.Forms.TextBox       txtParcelID;
////        private System.Windows.Forms.Button        btnLoadLog;
////        private System.Windows.Forms.Button        btnClear;
////        private System.Windows.Forms.GroupBox      grpHeader;
////        private System.Windows.Forms.Label         lblTracking;
////        private System.Windows.Forms.Label         lblTrackingVal;
////        private System.Windows.Forms.Label         lblSender;
////        private System.Windows.Forms.Label         lblSenderVal;
////        private System.Windows.Forms.Label         lblReceiver;
////        private System.Windows.Forms.Label         lblReceiverVal;
////        private System.Windows.Forms.Label         lblCurrStatus;
////        private System.Windows.Forms.Label         lblCurrStatusVal;
////        private System.Windows.Forms.Label         lblLogCount;
////        private System.Windows.Forms.DataGridView  dgvLog;
////    }
////}
