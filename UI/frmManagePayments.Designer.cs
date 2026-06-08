using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManagepayment
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
            Color inputBg = Color.FromArgb(30, 30, 30);
            Color blue = Color.FromArgb(100, 130, 220);
            Color green = Color.FromArgb(90, 180, 130);
            Color red = Color.FromArgb(220, 80, 80);

            this.dgvpayment = new DataGridView();
            this.btnAddPayment = new Button();
            this.btnRefund = new Button();
            this.btnRefresh = new Button();
            this.OrderID = new Label();
            this.Amount = new Label();
            this.Method = new Label();
            this.RefundOrderID = new Label();
            this.txtAmount = new TextBox();
            this.txtRefundOrderID = new TextBox();
            this.txtOrderID = new TextBox();
            this.txtRefundReason = new TextBox();
            this.RefundReason = new Label();
            this.cmbMethod = new ComboBox();
            this.pnlTop = new Panel();
            this.lblTitle = new Label();
            this.pnlAddPayment = new Panel();
            this.lblSectionAdd = new Label();
            this.pnlRefund = new Panel();
            this.lblSectionRefund = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlAddPayment.SuspendLayout();
            this.pnlRefund.SuspendLayout();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────
            this.BackColor = bg;
            this.ForeColor = txtMain;
            this.ClientSize = new Size(1100, 700);
            this.MinimumSize = new Size(900, 600);
            this.Font = new Font("Segoe UI", 9.5F);
            this.Text = "Manage Payments — CourierDB";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManagepayment_Load);

            // ── pnlTop (Dock.Top) ─────────────────────────────────────
            this.pnlTop.BackColor = header;
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Text = "💳  Manage Payments";
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = txtMain;
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new Padding(20, 0, 0, 0);

            // ── dgvpayment ────────────────────────────────────────────
            // Anchored Top+Left+Right — fills width, fixed height
            this.dgvpayment.Anchor =
                AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvpayment.Location = new Point(16, 71);
            this.dgvpayment.Size = new Size(1068, 300);

            this.dgvpayment.AllowUserToAddRows = false;
            this.dgvpayment.AllowUserToDeleteRows = false;
            this.dgvpayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvpayment.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpayment.MultiSelect = false;
            this.dgvpayment.ReadOnly = true;
            this.dgvpayment.RowTemplate.Height = 34;
            this.dgvpayment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvpayment.BorderStyle = BorderStyle.None;
            this.dgvpayment.BackgroundColor = gridBg;
            this.dgvpayment.GridColor = border;
            this.dgvpayment.EnableHeadersVisualStyles = false;
            this.dgvpayment.Font = new Font("Segoe UI", 10F);

            this.dgvpayment.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvpayment.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvpayment.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            this.dgvpayment.DefaultCellStyle.BackColor = gridBg;
            this.dgvpayment.DefaultCellStyle.ForeColor = txtMain;
            this.dgvpayment.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvpayment.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvpayment.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvpayment.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

            this.dgvpayment.CellContentClick +=
                new DataGridViewCellEventHandler(this.dgvpayment_CellContentClick);

            // ── pnlAddPayment ─────────────────────────────────────────
            // Anchored Left+Right so it stretches full width
            this.pnlAddPayment.BackColor = card;
            this.pnlAddPayment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.pnlAddPayment.Location = new Point(16, 385);
            this.pnlAddPayment.Size = new Size(1068, 90);

            this.lblSectionAdd.Text = "ADD PAYMENT";
            this.lblSectionAdd.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblSectionAdd.ForeColor = accent;
            this.lblSectionAdd.Location = new Point(16, 8);
            this.lblSectionAdd.AutoSize = true;

            // Row y=38 inside pnlAddPayment — larger fonts, more spacing
            int ay = 38;
            SL(this.OrderID, "Order ID:", 16, ay, 90, txtDim);
            ST(this.txtOrderID, 110, ay - 2, 140, inputBg, txtMain, 1);

            SL(this.Amount, "Amount:", 270, ay, 80, txtDim);
            ST(this.txtAmount, 356, ay - 2, 140, inputBg, txtMain, 2);

            SL(this.Method, "Method:", 516, ay, 80, txtDim);
            this.cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMethod.FlatStyle = FlatStyle.Flat;
            this.cmbMethod.Font = new Font("Segoe UI", 10F);
            this.cmbMethod.BackColor = inputBg;
            this.cmbMethod.ForeColor = txtMain;
            this.cmbMethod.Location = new Point(602, ay - 2);
            this.cmbMethod.Size = new Size(180, 32);
            this.cmbMethod.TabIndex = 3;

            SB(this.btnAddPayment, "💳  Add Payment", 802, ay - 4, 190, 40, blue);
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);

            this.pnlAddPayment.Controls.AddRange(new Control[] {
                this.lblSectionAdd,
                this.OrderID, this.txtOrderID,
                this.Amount,  this.txtAmount,
                this.Method,  this.cmbMethod,
                this.btnAddPayment
            });

            // ── pnlRefund ─────────────────────────────────────────────
            this.pnlRefund.BackColor = Color.FromArgb(42, 28, 28);
            this.pnlRefund.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.pnlRefund.Location = new Point(16, 489);
            this.pnlRefund.Size = new Size(1068, 90);

            this.lblSectionRefund.Text = "PROCESS REFUND";
            this.lblSectionRefund.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblSectionRefund.ForeColor = Color.Tomato;
            this.lblSectionRefund.Location = new Point(16, 8);
            this.lblSectionRefund.AutoSize = true;

            int ry = 38;
            SL(this.RefundReason, "Reason:", 16, ry, 80, txtDim);
            ST(this.txtRefundReason, 100, ry - 2, 360, inputBg, txtMain, 4);

            SL(this.RefundOrderID, "Order ID:", 478, ry, 90, txtDim);
            ST(this.txtRefundOrderID, 574, ry - 2, 140, inputBg, txtMain, 5);

            SB(this.btnRefund, "↩  Process Refund", 734, ry - 4, 180, 40, red);
            SB(this.btnRefresh, "⟳  Refresh", 928, ry - 4, 130, 40, green);
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.pnlRefund.Controls.AddRange(new Control[] {
                this.lblSectionRefund,
                this.RefundReason,  this.txtRefundReason,
                this.RefundOrderID, this.txtRefundOrderID,
                this.btnRefund, this.btnRefresh
            });

            // ── thin divider above pnlAddPayment ─────────────────────
            var pnlDiv = new Panel
            {
                BackColor = Color.FromArgb(55, 55, 55),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(16, 380),
                Size = new Size(1068, 1)
            };

            // ── Wire controls ─────────────────────────────────────────
            this.Controls.Add(this.dgvpayment);
            this.Controls.Add(pnlDiv);
            this.Controls.Add(this.pnlAddPayment);
            this.Controls.Add(this.pnlRefund);
            this.Controls.Add(this.pnlTop);   // Dock.Top last

            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlAddPayment.ResumeLayout(false);
            this.pnlRefund.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Helpers ───────────────────────────────────────────────────
        private void SL(Label lbl, string text, int x, int y, int w, Color fg)
        {
            lbl.AutoSize = false;
            lbl.Text = text;
            lbl.Location = new Point(x, y + 4);
            lbl.Size = new Size(w, 24);
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl.ForeColor = fg;
            lbl.TextAlign = ContentAlignment.MiddleRight;
        }

        private void ST(TextBox txt, int x, int y, int w, Color bg, Color fg, int tab)
        {
            txt.Location = new Point(x, y);
            txt.Size = new Size(w, 32);
            txt.Font = new Font("Segoe UI", 10F);
            txt.BackColor = bg;
            txt.ForeColor = fg;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.TabIndex = tab;
        }

        private void SB(Button btn, string text, int x, int y, int w, int h, Color bg)
        {
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.BackColor = bg;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.UseVisualStyleBackColor = false;
            btn.Cursor = Cursors.Hand;
        }

        #endregion

        private DataGridView dgvpayment;
        private Button btnAddPayment, btnRefund, btnRefresh;
        private Label OrderID, Amount, Method, RefundOrderID, RefundReason;
        private TextBox txtAmount, txtRefundOrderID, txtOrderID, txtRefundReason;
        private ComboBox cmbMethod;
        private Panel pnlTop, pnlAddPayment, pnlRefund;
        private Label lblTitle, lblSectionAdd, lblSectionRefund;
    }
}








//using System.Drawing;
//using System.Windows.Forms;

//namespace CourierDB.UI
//{
//    partial class frmManagepayment
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
//            // ── Dashboard palette ──────────────────────────────────────
//            Color bg = Color.FromArgb(18, 18, 18);
//            Color card = Color.FromArgb(38, 38, 38);
//            Color header = Color.FromArgb(24, 24, 24);
//            Color gridBg = Color.FromArgb(32, 32, 32);
//            Color gridAlt = Color.FromArgb(36, 36, 36);
//            Color accent = Color.FromArgb(230, 180, 80);
//            Color txtMain = Color.FromArgb(240, 240, 240);
//            Color txtDim = Color.FromArgb(160, 160, 160);
//            Color border = Color.FromArgb(60, 60, 60);
//            Color inputBg = Color.FromArgb(30, 30, 30);
//            Color blue = Color.FromArgb(100, 130, 220);
//            Color green = Color.FromArgb(90, 180, 130);
//            Color red = Color.FromArgb(220, 80, 80);

//            this.dgvpayment = new System.Windows.Forms.DataGridView();
//            this.btnAddPayment = new System.Windows.Forms.Button();
//            this.btnRefund = new System.Windows.Forms.Button();
//            this.btnRefresh = new System.Windows.Forms.Button();
//            this.OrderID = new System.Windows.Forms.Label();
//            this.Amount = new System.Windows.Forms.Label();
//            this.Method = new System.Windows.Forms.Label();
//            this.RefundOrderID = new System.Windows.Forms.Label();
//            this.txtAmount = new System.Windows.Forms.TextBox();
//            this.txtRefundOrderID = new System.Windows.Forms.TextBox();
//            this.txtOrderID = new System.Windows.Forms.TextBox();
//            this.txtRefundReason = new System.Windows.Forms.TextBox();
//            this.RefundReason = new System.Windows.Forms.Label();
//            this.cmbMethod = new System.Windows.Forms.ComboBox();
//            this.pnlTop = new System.Windows.Forms.Panel();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.pnlAddPayment = new System.Windows.Forms.Panel();
//            this.lblSectionAdd = new System.Windows.Forms.Label();
//            this.pnlRefund = new System.Windows.Forms.Panel();
//            this.lblSectionRefund = new System.Windows.Forms.Label();

//            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).BeginInit();
//            this.pnlTop.SuspendLayout();
//            this.pnlAddPayment.SuspendLayout();
//            this.pnlRefund.SuspendLayout();
//            this.SuspendLayout();

//            // ── pnlTop ────────────────────────────────────────────────
//            this.pnlTop.BackColor = header;
//            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
//            this.pnlTop.Height = 55;
//            this.pnlTop.Controls.Add(this.lblTitle);

//            this.lblTitle.AutoSize = false;
//            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.lblTitle.Text = "💳  Manage Payments";
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = txtMain;
//            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

//            // ── dgvpayment ────────────────────────────────────────────
//            this.dgvpayment.AllowUserToAddRows = false;
//            this.dgvpayment.AllowUserToDeleteRows = false;
//            this.dgvpayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvpayment.ColumnHeadersHeightSizeMode =
//                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvpayment.MultiSelect = false;
//            this.dgvpayment.ReadOnly = true;
//            this.dgvpayment.RowTemplate.Height = 30;
//            this.dgvpayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvpayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
//            this.dgvpayment.BackgroundColor = gridBg;
//            this.dgvpayment.GridColor = border;
//            this.dgvpayment.EnableHeadersVisualStyles = false;
//            this.dgvpayment.Font = new System.Drawing.Font("Segoe UI", 9.5F);

//            this.dgvpayment.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
//            this.dgvpayment.ColumnHeadersDefaultCellStyle.ForeColor = accent;
//            this.dgvpayment.ColumnHeadersDefaultCellStyle.Font =
//                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

//            this.dgvpayment.DefaultCellStyle.BackColor = gridBg;
//            this.dgvpayment.DefaultCellStyle.ForeColor = txtMain;
//            this.dgvpayment.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
//            this.dgvpayment.DefaultCellStyle.SelectionForeColor = Color.White;
//            this.dgvpayment.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

//            this.dgvpayment.Anchor =
//                System.Windows.Forms.AnchorStyles.Top |
//                System.Windows.Forms.AnchorStyles.Left |
//                System.Windows.Forms.AnchorStyles.Right;
//            this.dgvpayment.Location = new System.Drawing.Point(16, 71);
//            this.dgvpayment.Size = new System.Drawing.Size(968, 240);
//            this.dgvpayment.TabIndex = 0;
//            this.dgvpayment.CellContentClick +=
//                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpayment_CellContentClick);

//            // ── pnlAddPayment (card panel) ────────────────────────────
//            this.pnlAddPayment.BackColor = card;
//            this.pnlAddPayment.Location = new System.Drawing.Point(16, 325);
//            this.pnlAddPayment.Size = new System.Drawing.Size(968, 76);

//            // Section label
//            this.lblSectionAdd.Text = "ADD PAYMENT";
//            this.lblSectionAdd.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
//            this.lblSectionAdd.ForeColor = accent;
//            this.lblSectionAdd.Location = new System.Drawing.Point(12, 8);
//            this.lblSectionAdd.AutoSize = true;

//            // OrderID label + box
//            SetLabel(this.OrderID, "Order ID:", 12, 30, txtDim);
//            SetTextBox(this.txtOrderID, 90, 31, 110, inputBg, txtMain, 1);

//            // check 

//            // Amount label + box
//            SetLabel(this.Amount, "Amount:", 218, 30, txtDim);
//            SetTextBox(this.txtAmount, 290, 28, 110, inputBg, txtMain, 2);

//            // Method label + combo
//            SetLabel(this.Method, "Method:", 418, 30, txtDim);
//            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.cmbMethod.BackColor = inputBg;
//            this.cmbMethod.ForeColor = txtMain;
//            this.cmbMethod.Location = new System.Drawing.Point(486, 26);
//            this.cmbMethod.Size = new System.Drawing.Size(150, 28);
//            this.cmbMethod.TabIndex = 3;

//            // btnAddPayment
//            StyleButton(this.btnAddPayment, "💳  Add Payment", 656, 22, 120, 36, blue);
//            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);

//            this.pnlAddPayment.Controls.Add(this.lblSectionAdd);
//            this.pnlAddPayment.Controls.Add(this.OrderID);
//            this.pnlAddPayment.Controls.Add(this.txtOrderID);
//            this.pnlAddPayment.Controls.Add(this.Amount);
//            this.pnlAddPayment.Controls.Add(this.txtAmount);
//            this.pnlAddPayment.Controls.Add(this.Method);
//            this.pnlAddPayment.Controls.Add(this.cmbMethod);
//            this.pnlAddPayment.Controls.Add(this.btnAddPayment);

//            // ── pnlRefund (card panel) ────────────────────────────────
//            this.pnlRefund.BackColor = Color.FromArgb(42, 34, 34);   // subtle red tint
//            this.pnlRefund.Location = new System.Drawing.Point(16, 415);
//            this.pnlRefund.Size = new System.Drawing.Size(968, 76);

//            this.lblSectionRefund.Text = "PROCESS REFUND";
//            this.lblSectionRefund.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
//            this.lblSectionRefund.ForeColor = Color.Tomato;
//            this.lblSectionRefund.Location = new System.Drawing.Point(12, 8);
//            this.lblSectionRefund.AutoSize = true;

//            SetLabel(this.RefundReason, "Reason:", 12, 30, txtDim);
//            SetTextBox(this.txtRefundReason, 80, 28, 280, inputBg, txtMain, 4);

//            SetLabel(this.RefundOrderID, "Order ID:", 378, 30, txtDim);
//            SetTextBox(this.txtRefundOrderID, 450, 28, 110, inputBg, txtMain, 5);

//            StyleButton(this.btnRefund, "↩  Process Refund", 580, 22, 150, 36, red);
//            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);

//            StyleButton(this.btnRefresh, "⟳  Refresh", 748, 22, 110, 36, green);
//            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

//            this.pnlRefund.Controls.Add(this.lblSectionRefund);
//            this.pnlRefund.Controls.Add(this.RefundReason);
//            this.pnlRefund.Controls.Add(this.txtRefundReason);
//            this.pnlRefund.Controls.Add(this.RefundOrderID);
//            this.pnlRefund.Controls.Add(this.txtRefundOrderID);
//            this.pnlRefund.Controls.Add(this.btnRefund);
//            this.pnlRefund.Controls.Add(this.btnRefresh);

//            // ── divider label between grid and panels ─────────────────
//            var pnlDivider = new System.Windows.Forms.Panel
//            {
//                BackColor = Color.FromArgb(45, 45, 45),
//                Location = new System.Drawing.Point(16, 318),
//                Size = new System.Drawing.Size(968, 1)
//            };

//            // ── frmManagepayment ──────────────────────────────────────
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = bg;
//            this.ForeColor = txtMain;
//            this.ClientSize = new System.Drawing.Size(1000, 510);
//            this.MinimumSize = new System.Drawing.Size(900, 510);
//            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.Name = "frmManagepayment";
//            this.Text = "Manage Payments — CourierDB";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

//            this.Controls.Add(this.dgvpayment);
//            this.Controls.Add(pnlDivider);
//            this.Controls.Add(this.pnlAddPayment);
//            this.Controls.Add(this.pnlRefund);
//            this.Controls.Add(this.pnlTop);   // dock=Top must be added last

//            this.Load += new System.EventHandler(this.frmManagepayment_Load);

//            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).EndInit();
//            this.pnlTop.ResumeLayout(false);
//            this.pnlAddPayment.ResumeLayout(false);
//            this.pnlRefund.ResumeLayout(false);
//            this.ResumeLayout(false);
//        }

//        // ── Helpers ───────────────────────────────────────────────────
//        private void SetLabel(System.Windows.Forms.Label lbl,
//            string text, int x, int y, Color fg)
//        {
//            lbl.AutoSize = false;
//            lbl.Text = text;
//            lbl.Location = new System.Drawing.Point(x, y + 4);
//            lbl.Size = new System.Drawing.Size(80, 22);
//            lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            lbl.ForeColor = fg;
//            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//        }

//        private void SetTextBox(System.Windows.Forms.TextBox txt,
//            int x, int y, int w, Color bg, Color fg, int tab)
//        {
//            txt.Location = new System.Drawing.Point(x, y);
//            txt.Size = new System.Drawing.Size(w, 28);
//            txt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            txt.BackColor = bg;
//            txt.ForeColor = fg;
//            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            txt.TabIndex = tab;
//        }

//        private void StyleButton(System.Windows.Forms.Button btn,
//            string text, int x, int y, int w, int h, Color bg)
//        {
//            btn.Text = text;
//            btn.Location = new System.Drawing.Point(x, y);
//            btn.Size = new System.Drawing.Size(w, h);
//            btn.BackColor = bg;
//            btn.ForeColor = Color.White;
//            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            btn.FlatAppearance.BorderSize = 0;
//            btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
//            btn.UseVisualStyleBackColor = false;
//            btn.Cursor = System.Windows.Forms.Cursors.Hand;
//        }

//        #endregion

//        private System.Windows.Forms.DataGridView dgvpayment;
//        private System.Windows.Forms.Button btnAddPayment;
//        private System.Windows.Forms.Button btnRefund;
//        private System.Windows.Forms.Button btnRefresh;
//        private System.Windows.Forms.Label OrderID;
//        private System.Windows.Forms.Label Amount;
//        private System.Windows.Forms.Label Method;
//        private System.Windows.Forms.Label RefundOrderID;
//        private System.Windows.Forms.TextBox txtAmount;
//        private System.Windows.Forms.TextBox txtRefundOrderID;
//        private System.Windows.Forms.TextBox txtOrderID;
//        private System.Windows.Forms.TextBox txtRefundReason;
//        private System.Windows.Forms.Label RefundReason;
//        private System.Windows.Forms.ComboBox cmbMethod;
//        private System.Windows.Forms.Panel pnlTop;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Panel pnlAddPayment;
//        private System.Windows.Forms.Label lblSectionAdd;
//        private System.Windows.Forms.Panel pnlRefund;
//        private System.Windows.Forms.Label lblSectionRefund;
//    }
//}


////namespace CourierDB.UI
////{
////    partial class frmManagepayment
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
////            this.dgvpayment = new System.Windows.Forms.DataGridView();
////            this.btnAddPayment = new System.Windows.Forms.Button();
////            this.btnRefund = new System.Windows.Forms.Button();
////            this.btnRefresh = new System.Windows.Forms.Button();
////            this.OrderID = new System.Windows.Forms.Label();
////            this.Amount = new System.Windows.Forms.Label();
////            this.Method = new System.Windows.Forms.Label();
////            this.RefundOrderID = new System.Windows.Forms.Label();
////            this.txtAmount = new System.Windows.Forms.TextBox();
////            this.txtRefundOrderID = new System.Windows.Forms.TextBox();
////            this.txtOrderID = new System.Windows.Forms.TextBox();
////            this.txtRefundReason = new System.Windows.Forms.TextBox();
////            this.RefundReason = new System.Windows.Forms.Label();
////            this.cmbMethod = new System.Windows.Forms.ComboBox();

////            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).BeginInit();
////            this.SuspendLayout();

////            //
////            // dgvpayment
////            //
////            this.dgvpayment.AllowUserToAddRows = false;
////            this.dgvpayment.AllowUserToDeleteRows = false;
////            this.dgvpayment.AutoSizeColumnsMode =
////                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
////            this.dgvpayment.ColumnHeadersHeightSizeMode =
////                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
////            this.dgvpayment.Location =
////                new System.Drawing.Point(20, 20);
////            this.dgvpayment.MultiSelect = false;
////            this.dgvpayment.Name = "dgvpayment";
////            this.dgvpayment.ReadOnly = true;
////            this.dgvpayment.RowHeadersWidth = 51;
////            this.dgvpayment.RowTemplate.Height = 24;
////            this.dgvpayment.SelectionMode =
////                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
////            this.dgvpayment.Size =
////                new System.Drawing.Size(940, 250);
////            this.dgvpayment.TabIndex = 0;
////            this.dgvpayment.CellContentClick +=
////                new System.Windows.Forms.DataGridViewCellEventHandler(
////                this.dgvpayment_CellContentClick);

////            //
////            // OrderID
////            //
////            this.OrderID.AutoSize = true;
////            this.OrderID.Location =
////                new System.Drawing.Point(20, 300);
////            this.OrderID.Name = "OrderID";
////            this.OrderID.Size = new System.Drawing.Size(74, 20);
////            this.OrderID.Text = "Order ID";

////            //
////            // txtOrderID
////            //
////            this.txtOrderID.Location =
////                new System.Drawing.Point(110, 297);
////            this.txtOrderID.Name = "txtOrderID";
////            this.txtOrderID.Size =
////                new System.Drawing.Size(120, 26);

////            //
////            // Amount
////            //
////            this.Amount.AutoSize = true;
////            this.Amount.Location =
////                new System.Drawing.Point(260, 300);
////            this.Amount.Name = "Amount";
////            this.Amount.Size = new System.Drawing.Size(69, 20);
////            this.Amount.Text = "Amount";

////            //
////            // txtAmount
////            //
////            this.txtAmount.Location =
////                new System.Drawing.Point(340, 297);
////            this.txtAmount.Name = "txtAmount";
////            this.txtAmount.Size =
////                new System.Drawing.Size(120, 26);

////            //
////            // Method
////            //
////            this.Method.AutoSize = true;
////            this.Method.Location =
////                new System.Drawing.Point(490, 300);
////            this.Method.Name = "Method";
////            this.Method.Size = new System.Drawing.Size(67, 20);
////            this.Method.Text = "Method";

////            //
////            // cmbMethod
////            //
////            this.cmbMethod.DropDownStyle =
////                System.Windows.Forms.ComboBoxStyle.DropDownList;
////            this.cmbMethod.FormattingEnabled = true;
////            this.cmbMethod.Location =
////                new System.Drawing.Point(570, 296);
////            this.cmbMethod.Name = "cmbMethod";
////            this.cmbMethod.Size =
////                new System.Drawing.Size(150, 28);

////            //
////            // btnAddPayment
////            //
////            this.btnAddPayment.Location =
////                new System.Drawing.Point(760, 292);
////            this.btnAddPayment.Name = "btnAddPayment";
////            this.btnAddPayment.Size =
////                new System.Drawing.Size(180, 35);
////            this.btnAddPayment.TabIndex = 1;
////            this.btnAddPayment.Text = "Add Payment";
////            this.btnAddPayment.UseVisualStyleBackColor = true;
////            this.btnAddPayment.Click +=
////                new System.EventHandler(this.btnAddPayment_Click);

////            //
////            // RefundReason
////            //
////            this.RefundReason.AutoSize = true;
////            this.RefundReason.Location =
////                new System.Drawing.Point(20, 360);
////            this.RefundReason.Name = "RefundReason";
////            this.RefundReason.Size = new System.Drawing.Size(126, 20);
////            this.RefundReason.Text = "Refund Reason";

////            //
////            // txtRefundReason
////            //
////            this.txtRefundReason.Location =
////                new System.Drawing.Point(160, 357);
////            this.txtRefundReason.Name = "txtRefundReason";
////            this.txtRefundReason.Size =
////                new System.Drawing.Size(300, 26);

////            //
////            // RefundOrderID
////            //
////            this.RefundOrderID.AutoSize = true;
////            this.RefundOrderID.Location =
////                new System.Drawing.Point(490, 360);
////            this.RefundOrderID.Name = "RefundOrderID";
////            this.RefundOrderID.Size = new System.Drawing.Size(131, 20);
////            this.RefundOrderID.Text = "Refund Order ID";

////            //
////            // txtRefundOrderID
////            //
////            this.txtRefundOrderID.Location =
////                new System.Drawing.Point(630, 357);
////            this.txtRefundOrderID.Name = "txtRefundOrderID";
////            this.txtRefundOrderID.Size =
////                new System.Drawing.Size(100, 26);

////            //
////            // btnRefund
////            //
////            this.btnRefund.Location =
////                new System.Drawing.Point(760, 352);
////            this.btnRefund.Name = "btnRefund";
////            this.btnRefund.Size =
////                new System.Drawing.Size(180, 35);
////            this.btnRefund.TabIndex = 2;
////            this.btnRefund.Text = "Process Refund";
////            this.btnRefund.UseVisualStyleBackColor = true;
////            this.btnRefund.Click +=
////                new System.EventHandler(this.btnRefund_Click);

////            //
////            // btnRefresh
////            //
////            this.btnRefresh.Location =
////                new System.Drawing.Point(760, 410);
////            this.btnRefresh.Name = "btnRefresh";
////            this.btnRefresh.Size =
////                new System.Drawing.Size(180, 35);
////            this.btnRefresh.TabIndex = 3;
////            this.btnRefresh.Text = "Refresh";
////            this.btnRefresh.UseVisualStyleBackColor = true;
////            this.btnRefresh.Click +=
////                new System.EventHandler(this.btnRefresh_Click);

////            //
////            // frmManagepayment
////            //
////            this.AutoScaleDimensions =
////                new System.Drawing.SizeF(8F, 20F);

////            this.AutoScaleMode =
////                System.Windows.Forms.AutoScaleMode.Font;

////            this.BackColor =
////                System.Drawing.Color.WhiteSmoke;

////            this.ClientSize =
////                new System.Drawing.Size(1000, 480);

////            this.Controls.Add(this.dgvpayment);
////            this.Controls.Add(this.OrderID);
////            this.Controls.Add(this.txtOrderID);
////            this.Controls.Add(this.Amount);
////            this.Controls.Add(this.txtAmount);
////            this.Controls.Add(this.Method);
////            this.Controls.Add(this.cmbMethod);
////            this.Controls.Add(this.btnAddPayment);
////            this.Controls.Add(this.RefundReason);
////            this.Controls.Add(this.txtRefundReason);
////            this.Controls.Add(this.RefundOrderID);
////            this.Controls.Add(this.txtRefundOrderID);
////            this.Controls.Add(this.btnRefund);
////            this.Controls.Add(this.btnRefresh);

////            this.Name = "frmManagepayment";
////            this.StartPosition =
////                System.Windows.Forms.FormStartPosition.CenterScreen;

////            this.Text = "Manage payment";

////            this.Load +=
////                new System.EventHandler(this.frmManagepayment_Load);

////            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).EndInit();
////            this.ResumeLayout(false);
////            this.PerformLayout();
////        }

////        #endregion

////        private System.Windows.Forms.DataGridView dgvpayment;
////        private System.Windows.Forms.Button btnAddPayment;
////        private System.Windows.Forms.Button btnRefund;
////        private System.Windows.Forms.Button btnRefresh;
////        private System.Windows.Forms.Label OrderID;
////        private System.Windows.Forms.Label Amount;
////        private System.Windows.Forms.Label Method;
////        private System.Windows.Forms.Label RefundOrderID;
////        private System.Windows.Forms.TextBox txtAmount;
////        private System.Windows.Forms.TextBox txtRefundOrderID;
////        private System.Windows.Forms.TextBox txtOrderID;
////        private System.Windows.Forms.TextBox txtRefundReason;
////        private System.Windows.Forms.Label RefundReason;
////        private System.Windows.Forms.ComboBox cmbMethod;
////    }
////}