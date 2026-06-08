using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManageRates
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
            // ── Palette (matches dashboard) ────────────────────────────
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
            Color red = Color.FromArgb(200, 70, 70);

            this.dgvDiscounts = new System.Windows.Forms.DataGridView();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.lblUsage = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtUsageLimit = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblSectionForm = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════
            // FORM  — sensible fixed size, centered
            // ════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = bg;
            this.ForeColor = txtMain;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.MinimumSize = new System.Drawing.Size(900, 580);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "frmManageRates";
            this.Text = "Manage Discount Rates — CourierDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManageRates_Load);

            // ════════════════════════════════════════════════════
            // TOP HEADER BAR
            // ════════════════════════════════════════════════════
            this.pnlTop.BackColor = header;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "💰  Manage Discount Rates";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = txtMain;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

            // ════════════════════════════════════════════════════
            // DATA GRID  — anchored all sides so it resizes
            // ════════════════════════════════════════════════════
            this.dgvDiscounts.AllowUserToAddRows = false;
            this.dgvDiscounts.AllowUserToDeleteRows = false;
            this.dgvDiscounts.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiscounts.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscounts.MultiSelect = false;
            this.dgvDiscounts.ReadOnly = true;
            this.dgvDiscounts.RowTemplate.Height = 30;
            this.dgvDiscounts.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiscounts.BackgroundColor = gridBg;
            this.dgvDiscounts.GridColor = border;
            this.dgvDiscounts.EnableHeadersVisualStyles = false;
            this.dgvDiscounts.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.dgvDiscounts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvDiscounts.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvDiscounts.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.dgvDiscounts.DefaultCellStyle.BackColor = gridBg;
            this.dgvDiscounts.DefaultCellStyle.ForeColor = txtMain;
            this.dgvDiscounts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvDiscounts.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvDiscounts.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

            // Anchored: stretches horizontally AND vertically with the form
            this.dgvDiscounts.Location = new System.Drawing.Point(20, 71);
            this.dgvDiscounts.Size = new System.Drawing.Size(860, 270);
            this.dgvDiscounts.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right |
                System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvDiscounts.TabIndex = 0;
            this.dgvDiscounts.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscounts_CellClick);

            // ════════════════════════════════════════════════════
            // INPUT CARD  — anchored bottom + left + right
            // ════════════════════════════════════════════════════
            this.pnlForm.BackColor = card;
            this.pnlForm.Location = new System.Drawing.Point(20, 355);
            this.pnlForm.Size = new System.Drawing.Size(860, 200);
            this.pnlForm.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            // Section label
            this.lblSectionForm.Text = "ADD / EDIT DISCOUNT";
            this.lblSectionForm.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionForm.ForeColor = accent;
            this.lblSectionForm.Location = new System.Drawing.Point(14, 12);
            this.lblSectionForm.AutoSize = true;

            // ── Row positions inside the card ─────────────────────────
            int lw = 110;   // label width
            int tw = 180;   // textbox width
            int row1y = 40;
            int row2y = 85;
            int row3y = 130;

            // Row 1 — Discount Code  |  Type
            DLabel(this.lblCode, "Discount Code:", 14, row1y, lw, txtDim);
            DInput(this.txtCode, 130, row1y, tw, inputBg, txtMain, 1);

            DLabel(this.lblType, "Type:", 340, row1y, 60, txtDim);
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbType.BackColor = inputBg;
            this.cmbType.ForeColor = txtMain;
            this.cmbType.Location = new System.Drawing.Point(408, row1y - 2);
            this.cmbType.Size = new System.Drawing.Size(170, 28);
            this.cmbType.TabIndex = 2;

            // Row 2 — Value  |  Expiry Date
            DLabel(this.lblValue, "Value:", 14, row2y, lw, txtDim);
            DInput(this.txtValue, 130, row2y, tw, inputBg, txtMain, 3);

            DLabel(this.lblExpiry, "Expiry Date:", 340, row2y, lw, txtDim);
            this.dtpExpiry.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiry.Location = new System.Drawing.Point(458, row2y - 2);
            this.dtpExpiry.Size = new System.Drawing.Size(160, 28);
            this.dtpExpiry.TabIndex = 4;
            this.dtpExpiry.CalendarForeColor = txtMain;
            this.dtpExpiry.CalendarMonthBackground = Color.FromArgb(38, 38, 38);

            // Row 3 — Usage Limit
            DLabel(this.lblUsage, "Usage Limit:", 14, row3y, lw, txtDim);
            DInput(this.txtUsageLimit, 130, row3y, tw, inputBg, txtMain, 5);

            // ── Action Buttons — right side of card, vertically stacked ──
            DBtn(this.btnAdd, "➕  Add", 630, row1y - 4, 100, 34, blue);
            DBtn(this.btnRefresh, "⟳  Refresh", 740, row1y - 4, 100, 34, green);
            DBtn(this.btnDelete, "🗑  Delete", 630, row2y - 4, 210, 34, red);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.pnlForm.Controls.Add(this.lblSectionForm);
            this.pnlForm.Controls.Add(this.lblCode);
            this.pnlForm.Controls.Add(this.txtCode);
            this.pnlForm.Controls.Add(this.lblType);
            this.pnlForm.Controls.Add(this.cmbType);
            this.pnlForm.Controls.Add(this.lblValue);
            this.pnlForm.Controls.Add(this.txtValue);
            this.pnlForm.Controls.Add(this.lblExpiry);
            this.pnlForm.Controls.Add(this.dtpExpiry);
            this.pnlForm.Controls.Add(this.lblUsage);
            this.pnlForm.Controls.Add(this.txtUsageLimit);
            this.pnlForm.Controls.Add(this.btnAdd);
            this.pnlForm.Controls.Add(this.btnDelete);
            this.pnlForm.Controls.Add(this.btnRefresh);

            // ── Add to form ───────────────────────────────────────────
            this.Controls.Add(this.dgvDiscounts);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);   // added last so it paints on top

            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Helpers ───────────────────────────────────────────────────
        private void DLabel(System.Windows.Forms.Label lbl,
            string text, int x, int y, int w, Color fg)
        {
            lbl.AutoSize = false;
            lbl.Text = text;
            lbl.Location = new System.Drawing.Point(x, y + 4);
            lbl.Size = new System.Drawing.Size(w, 22);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = fg;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void DInput(System.Windows.Forms.TextBox txt,
            int x, int y, int w, Color bg, Color fg, int tab)
        {
            txt.Location = new System.Drawing.Point(x, y);
            txt.Size = new System.Drawing.Size(w, 28);
            txt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txt.BackColor = bg;
            txt.ForeColor = fg;
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.TabIndex = tab;
        }

        private void DBtn(System.Windows.Forms.Button btn,
            string text, int x, int y, int w, int h, Color bg)
        {
            btn.Text = text;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(w, h);
            btn.BackColor = bg;
            btn.ForeColor = Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btn.UseVisualStyleBackColor = false;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiscounts;
        private System.Windows.Forms.Label lblCode, lblType, lblValue, lblExpiry, lblUsage;
        private System.Windows.Forms.TextBox txtCode, txtValue, txtUsageLimit;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.Button btnAdd, btnDelete, btnRefresh;
        private System.Windows.Forms.Panel pnlTop, pnlForm;
        private System.Windows.Forms.Label lblTitle, lblSectionForm;
    }
}


//using System.Drawing;
//using System.Windows.Forms;

//namespace CourierDB.UI
//{
//    partial class frmManageRates
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
//            Color red = Color.FromArgb(200, 70, 70);

//            this.dgvDiscounts = new System.Windows.Forms.DataGridView();
//            this.lblCode = new System.Windows.Forms.Label();
//            this.lblType = new System.Windows.Forms.Label();
//            this.lblValue = new System.Windows.Forms.Label();
//            this.lblExpiry = new System.Windows.Forms.Label();
//            this.lblUsage = new System.Windows.Forms.Label();
//            this.txtCode = new System.Windows.Forms.TextBox();
//            this.txtValue = new System.Windows.Forms.TextBox();
//            this.txtUsageLimit = new System.Windows.Forms.TextBox();
//            this.cmbType = new System.Windows.Forms.ComboBox();
//            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
//            this.btnAdd = new System.Windows.Forms.Button();
//            this.btnDelete = new System.Windows.Forms.Button();
//            this.btnRefresh = new System.Windows.Forms.Button();
//            this.pnlTop = new System.Windows.Forms.Panel();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.pnlForm = new System.Windows.Forms.Panel();
//            this.lblSectionForm = new System.Windows.Forms.Label();

//            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).BeginInit();
//            this.pnlTop.SuspendLayout();
//            this.pnlForm.SuspendLayout();
//            this.SuspendLayout();

//            // ── pnlTop ────────────────────────────────────────────────
//            this.pnlTop.BackColor = header;
//            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
//            this.pnlTop.Height = 55;
//            this.pnlTop.Controls.Add(this.lblTitle);

//            this.lblTitle.AutoSize = false;
//            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.lblTitle.Text = "📊  Manage Discount Rates";
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = txtMain;
//            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

//            // ── dgvDiscounts ──────────────────────────────────────────
//            this.dgvDiscounts.AllowUserToAddRows = false;
//            this.dgvDiscounts.AllowUserToDeleteRows = false;
//            this.dgvDiscounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvDiscounts.ColumnHeadersHeightSizeMode =
//                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvDiscounts.MultiSelect = false;
//            this.dgvDiscounts.ReadOnly = true;
//            this.dgvDiscounts.RowTemplate.Height = 30;
//            this.dgvDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
//            this.dgvDiscounts.BackgroundColor = gridBg;
//            this.dgvDiscounts.GridColor = border;
//            this.dgvDiscounts.EnableHeadersVisualStyles = false;
//            this.dgvDiscounts.Font = new System.Drawing.Font("Segoe UI", 9.5F);

//            this.dgvDiscounts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
//            this.dgvDiscounts.ColumnHeadersDefaultCellStyle.ForeColor = accent;
//            this.dgvDiscounts.ColumnHeadersDefaultCellStyle.Font =
//                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

//            this.dgvDiscounts.DefaultCellStyle.BackColor = gridBg;
//            this.dgvDiscounts.DefaultCellStyle.ForeColor = txtMain;
//            this.dgvDiscounts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
//            this.dgvDiscounts.DefaultCellStyle.SelectionForeColor = Color.White;
//            this.dgvDiscounts.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

//            this.dgvDiscounts.Anchor =
//                System.Windows.Forms.AnchorStyles.Top |
//                System.Windows.Forms.AnchorStyles.Left |
//                System.Windows.Forms.AnchorStyles.Right;
//            this.dgvDiscounts.Location = new System.Drawing.Point(16, 71);
//            this.dgvDiscounts.Size = new System.Drawing.Size(768, 220);
//            this.dgvDiscounts.TabIndex = 0;
//            this.dgvDiscounts.CellClick +=
//                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscounts_CellClick);

//            // ── pnlForm (input card) ──────────────────────────────────
//            this.pnlForm.BackColor = card;
//            this.pnlForm.Location = new System.Drawing.Point(16, 307);
//            this.pnlForm.Size = new System.Drawing.Size(768, 180);

//            this.lblSectionForm.Text = "ADD / EDIT DISCOUNT";
//            this.lblSectionForm.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
//            this.lblSectionForm.ForeColor = accent;
//            this.lblSectionForm.Location = new System.Drawing.Point(12, 10);
//            this.lblSectionForm.AutoSize = true;

//            // Row 1: Code | Type
//            int lw = 100, tw = 160;
//            int row1y = 36, row2y = 80, row3y = 124;

//            DLabel(this.lblCode, "Discount Code:", 10, row1y, lw, txtDim);
//            DInput(this.txtCode, 118, row1y, tw, inputBg, txtMain, 1);

//            DLabel(this.lblType, "Type:", 310, row1y, 60, txtDim);
//            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.cmbType.BackColor = inputBg;
//            this.cmbType.ForeColor = txtMain;
//            this.cmbType.Location = new System.Drawing.Point(378, row1y - 2);
//            this.cmbType.Size = new System.Drawing.Size(160, 28);
//            this.cmbType.TabIndex = 2;

//            // Row 2: Value | Expiry
//            DLabel(this.lblValue, "Value:", 10, row2y, lw, txtDim);
//            DInput(this.txtValue, 118, row2y, tw, inputBg, txtMain, 3);

//            DLabel(this.lblExpiry, "Expiry Date:", 310, row2y, lw, txtDim);
//            this.dtpExpiry.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
//            this.dtpExpiry.Location = new System.Drawing.Point(418, row2y - 2);
//            this.dtpExpiry.Size = new System.Drawing.Size(150, 28);
//            this.dtpExpiry.TabIndex = 4;
//            this.dtpExpiry.CalendarForeColor = txtMain;
//            this.dtpExpiry.CalendarMonthBackground = Color.FromArgb(38, 38, 38);

//            // Row 3: Usage Limit | buttons
//            DLabel(this.lblUsage, "Usage Limit:", 10, row3y, lw, txtDim);
//            DInput(this.txtUsageLimit, 118, row3y, tw, inputBg, txtMain, 5);

//            // Buttons — right-aligned inside card
//            DBtn(this.btnAdd, "➕  Add", 570, row1y - 2, 90, 34, blue);
//            DBtn(this.btnDelete, "🗑  Delete", 570, row2y - 2, 90, 34, red);
//            DBtn(this.btnRefresh, "⟳  Refresh", 670, row1y - 2, 90, 34, green);

//            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
//            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
//            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

//            this.pnlForm.Controls.Add(this.lblSectionForm);
//            this.pnlForm.Controls.Add(this.lblCode);
//            this.pnlForm.Controls.Add(this.txtCode);
//            this.pnlForm.Controls.Add(this.lblType);
//            this.pnlForm.Controls.Add(this.cmbType);
//            this.pnlForm.Controls.Add(this.lblValue);
//            this.pnlForm.Controls.Add(this.txtValue);
//            this.pnlForm.Controls.Add(this.lblExpiry);
//            this.pnlForm.Controls.Add(this.dtpExpiry);
//            this.pnlForm.Controls.Add(this.lblUsage);
//            this.pnlForm.Controls.Add(this.txtUsageLimit);
//            this.pnlForm.Controls.Add(this.btnAdd);
//            this.pnlForm.Controls.Add(this.btnDelete);
//            this.pnlForm.Controls.Add(this.btnRefresh);

//            // ── frmManageRates ────────────────────────────────────────
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = bg;
//            this.ForeColor = txtMain;
//            this.ClientSize = new System.Drawing.Size(1920, 1080);
//            this.MinimumSize = new System.Drawing.Size(1200, 800);
//            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.Name = "frmManageRates";
//            this.Text = "Manage Discount Rates — CourierDB";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

//            this.Controls.Add(this.dgvDiscounts);
//            this.Controls.Add(this.pnlForm);
//            this.Controls.Add(this.pnlTop);

//            this.Load += new System.EventHandler(this.frmManageRates_Load);

//            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).EndInit();
//            this.pnlTop.ResumeLayout(false);
//            this.pnlForm.ResumeLayout(false);
//            this.ResumeLayout(false);
//        }

//        // ── Helpers ───────────────────────────────────────────────────
//        private void DLabel(System.Windows.Forms.Label lbl,
//            string text, int x, int y, int w, Color fg)
//        {
//            lbl.AutoSize = false;
//            lbl.Text = text;
//            lbl.Location = new System.Drawing.Point(x, y + 4);
//            lbl.Size = new System.Drawing.Size(w, 22);
//            lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            lbl.ForeColor = fg;
//            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//        }

//        private void DInput(System.Windows.Forms.TextBox txt,
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

//        private void DBtn(System.Windows.Forms.Button btn,
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

//        private System.Windows.Forms.DataGridView dgvDiscounts;
//        private System.Windows.Forms.Label lblCode;
//        private System.Windows.Forms.Label lblType;
//        private System.Windows.Forms.Label lblValue;
//        private System.Windows.Forms.Label lblExpiry;
//        private System.Windows.Forms.Label lblUsage;
//        private System.Windows.Forms.TextBox txtCode;
//        private System.Windows.Forms.TextBox txtValue;
//        private System.Windows.Forms.TextBox txtUsageLimit;
//        private System.Windows.Forms.ComboBox cmbType;
//        private System.Windows.Forms.DateTimePicker dtpExpiry;
//        private System.Windows.Forms.Button btnAdd;
//        private System.Windows.Forms.Button btnDelete;
//        private System.Windows.Forms.Button btnRefresh;
//        private System.Windows.Forms.Panel pnlTop;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Panel pnlForm;
//        private System.Windows.Forms.Label lblSectionForm;
//    }
//}

//namespace CourierDB.UI
//{
//    partial class frmManageRates
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
//            this.dgvDiscounts = new System.Windows.Forms.DataGridView();
//            this.lblCode = new System.Windows.Forms.Label();
//            this.lblType = new System.Windows.Forms.Label();
//            this.lblValue = new System.Windows.Forms.Label();
//            this.lblExpiry = new System.Windows.Forms.Label();
//            this.lblUsage = new System.Windows.Forms.Label();
//            this.txtCode = new System.Windows.Forms.TextBox();
//            this.txtValue = new System.Windows.Forms.TextBox();
//            this.txtUsageLimit = new System.Windows.Forms.TextBox();
//            this.cmbType = new System.Windows.Forms.ComboBox();
//            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
//            this.btnAdd = new System.Windows.Forms.Button();
//            this.btnDelete = new System.Windows.Forms.Button();
//            this.btnRefresh = new System.Windows.Forms.Button();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).BeginInit();
//            this.SuspendLayout();

//            // ── dgvDiscounts ──
//            this.dgvDiscounts.AllowUserToAddRows = false;
//            this.dgvDiscounts.AllowUserToDeleteRows = false;
//            this.dgvDiscounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvDiscounts.BackgroundColor = System.Drawing.Color.White;
//            this.dgvDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.dgvDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvDiscounts.Location = new System.Drawing.Point(20, 20);
//            this.dgvDiscounts.MultiSelect = false;
//            this.dgvDiscounts.Name = "dgvDiscounts";
//            this.dgvDiscounts.ReadOnly = true;
//            this.dgvDiscounts.RowHeadersWidth = 40;
//            this.dgvDiscounts.RowTemplate.Height = 28;
//            this.dgvDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvDiscounts.Size = new System.Drawing.Size(740, 200);
//            this.dgvDiscounts.TabIndex = 0;
//            this.dgvDiscounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscounts_CellClick);

//            // ── lblCode ──
//            this.lblCode.AutoSize = true;
//            this.lblCode.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.lblCode.Location = new System.Drawing.Point(20, 245);
//            this.lblCode.Name = "lblCode";
//            this.lblCode.Text = "Discount Code:";

//            // ── txtCode ──
//            this.txtCode.Font = new System.Drawing.Font("Arial", 10F);
//            this.txtCode.Location = new System.Drawing.Point(180, 242);
//            this.txtCode.Name = "txtCode";
//            this.txtCode.Size = new System.Drawing.Size(180, 26);
//            this.txtCode.TabIndex = 1;

//            // ── lblType ──
//            this.lblType.AutoSize = true;
//            this.lblType.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.lblType.Location = new System.Drawing.Point(20, 285);
//            this.lblType.Name = "lblType";
//            this.lblType.Text = "Type:";

//            // ── cmbType ──
//            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbType.Font = new System.Drawing.Font("Arial", 10F);
//            this.cmbType.FormattingEnabled = true;
//            this.cmbType.Location = new System.Drawing.Point(180, 282);
//            this.cmbType.Name = "cmbType";
//            this.cmbType.Size = new System.Drawing.Size(180, 28);
//            this.cmbType.TabIndex = 2;

//            // ── lblValue ──
//            this.lblValue.AutoSize = true;
//            this.lblValue.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.lblValue.Location = new System.Drawing.Point(20, 325);
//            this.lblValue.Name = "lblValue";
//            this.lblValue.Text = "Value:";

//            // ── txtValue ──
//            this.txtValue.Font = new System.Drawing.Font("Arial", 10F);
//            this.txtValue.Location = new System.Drawing.Point(180, 322);
//            this.txtValue.Name = "txtValue";
//            this.txtValue.Size = new System.Drawing.Size(180, 26);
//            this.txtValue.TabIndex = 3;

//            // ── lblExpiry ──
//            this.lblExpiry.AutoSize = true;
//            this.lblExpiry.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.lblExpiry.Location = new System.Drawing.Point(20, 365);
//            this.lblExpiry.Name = "lblExpiry";
//            this.lblExpiry.Text = "Expiry Date:";

//            // ── dtpExpiry ──
//            this.dtpExpiry.Font = new System.Drawing.Font("Arial", 10F);
//            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
//            this.dtpExpiry.Location = new System.Drawing.Point(180, 362);
//            this.dtpExpiry.Name = "dtpExpiry";
//            this.dtpExpiry.Size = new System.Drawing.Size(180, 26);
//            this.dtpExpiry.TabIndex = 4;

//            // ── lblUsage ──
//            this.lblUsage.AutoSize = true;
//            this.lblUsage.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.lblUsage.Location = new System.Drawing.Point(20, 405);
//            this.lblUsage.Name = "lblUsage";
//            this.lblUsage.Text = "Usage Limit:";

//            // ── txtUsageLimit ──
//            this.txtUsageLimit.Font = new System.Drawing.Font("Arial", 10F);
//            this.txtUsageLimit.Location = new System.Drawing.Point(180, 402);
//            this.txtUsageLimit.Name = "txtUsageLimit";
//            this.txtUsageLimit.Size = new System.Drawing.Size(180, 26);
//            this.txtUsageLimit.TabIndex = 5;

//            // ── btnAdd ──
//            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 117, 182);
//            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnAdd.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.btnAdd.ForeColor = System.Drawing.Color.White;
//            this.btnAdd.Location = new System.Drawing.Point(420, 242);
//            this.btnAdd.Name = "btnAdd";
//            this.btnAdd.Size = new System.Drawing.Size(150, 42);
//            this.btnAdd.Text = "➕  Add Discount";
//            this.btnAdd.UseVisualStyleBackColor = false;
//            this.btnAdd.TabIndex = 6;
//            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

//            // ── btnDelete ──
//            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
//            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnDelete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.btnDelete.ForeColor = System.Drawing.Color.White;
//            this.btnDelete.Location = new System.Drawing.Point(420, 300);
//            this.btnDelete.Name = "btnDelete";
//            this.btnDelete.Size = new System.Drawing.Size(150, 42);
//            this.btnDelete.Text = "🗑️  Delete";
//            this.btnDelete.UseVisualStyleBackColor = false;
//            this.btnDelete.TabIndex = 7;
//            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

//            // ── btnRefresh ──
//            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(84, 130, 53);
//            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnRefresh.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.btnRefresh.ForeColor = System.Drawing.Color.White;
//            this.btnRefresh.Location = new System.Drawing.Point(420, 358);
//            this.btnRefresh.Name = "btnRefresh";
//            this.btnRefresh.Size = new System.Drawing.Size(150, 42);
//            this.btnRefresh.Text = "🔄  Refresh";
//            this.btnRefresh.UseVisualStyleBackColor = false;
//            this.btnRefresh.TabIndex = 8;
//            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

//            // ── frmManageRates ──
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
//            this.ClientSize = new System.Drawing.Size(800, 480);
//            this.Name = "frmManageRates";
//            this.Text = "Manage Discounts";
//            this.Load += new System.EventHandler(this.frmManageRates_Load);
//            this.Controls.Add(this.dgvDiscounts);
//            this.Controls.Add(this.lblCode);
//            this.Controls.Add(this.txtCode);
//            this.Controls.Add(this.lblType);
//            this.Controls.Add(this.cmbType);
//            this.Controls.Add(this.lblValue);
//            this.Controls.Add(this.txtValue);
//            this.Controls.Add(this.lblExpiry);
//            this.Controls.Add(this.dtpExpiry);
//            this.Controls.Add(this.lblUsage);
//            this.Controls.Add(this.txtUsageLimit);
//            this.Controls.Add(this.btnAdd);
//            this.Controls.Add(this.btnDelete);
//            this.Controls.Add(this.btnRefresh);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        #endregion

//        private System.Windows.Forms.DataGridView dgvDiscounts;
//        private System.Windows.Forms.Label lblCode;
//        private System.Windows.Forms.Label lblType;
//        private System.Windows.Forms.Label lblValue;
//        private System.Windows.Forms.Label lblExpiry;
//        private System.Windows.Forms.Label lblUsage;
//        private System.Windows.Forms.TextBox txtCode;
//        private System.Windows.Forms.TextBox txtValue;
//        private System.Windows.Forms.TextBox txtUsageLimit;
//        private System.Windows.Forms.ComboBox cmbType;
//        private System.Windows.Forms.DateTimePicker dtpExpiry;
//        private System.Windows.Forms.Button btnAdd;
//        private System.Windows.Forms.Button btnDelete;
//        private System.Windows.Forms.Button btnRefresh;
//    }
//}