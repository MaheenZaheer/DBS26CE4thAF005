using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmReports
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
            this.lblReportTitle = new Label();
            this.lblStartDate = new Label();
            this.lblEndDate = new Label();
            this.dtpStartDate = new DateTimePicker();
            this.dtpEndDate = new DateTimePicker();
            this.btnSalesReport = new Button();
            this.btnInventoryReport = new Button();
            this.btnTopProducts = new Button();
            this.btnLowStock = new Button();
            this.btnRevenueByCategory = new Button();
            this.btnCustomerHistory = new Button();
            this.btnExport = new Button();
            this.dgvReport = new DataGridView();
            this.pnlDateRow = new Panel();
            this.pnlBtnRow1 = new Panel();
            this.pnlBtnRow2 = new Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            // Form
            this.BackColor = bg;
            this.ForeColor = textMain;
            this.ClientSize = new Size(1920, 1080);
            this.Text = "Reports — CourierDB";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f);
            this.MinimumSize = new Size(1280, 800);
            this.Load += new System.EventHandler(this.frmReports_Load);

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 15f, FontStyle.Bold);
            this.lblTitle.ForeColor = accent;
            this.lblTitle.Location = new Point(20, 18);
            this.lblTitle.Text = "Reports";

            // ── Date row panel ────────────────────────────────────────
            this.pnlDateRow.Location = new Point(20, 58);
            this.pnlDateRow.Size = new Size(820, 40);
            this.pnlDateRow.BackColor = Color.Transparent;

            DL(this.lblStartDate, "Start Date:", 0, 10, accent);
            this.dtpStartDate.Location = new Point(90, 6);
            this.dtpStartDate.Size = new Size(160, 26);
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            this.dtpStartDate.CalendarForeColor = textMain;
            this.dtpStartDate.CalendarMonthBackground = Color.FromArgb(40, 40, 40);
            this.dtpStartDate.Font = new Font("Segoe UI", 9.5f);

            DL(this.lblEndDate, "End Date:", 270, 10, accent);
            this.dtpEndDate.Location = new Point(345, 6);
            this.dtpEndDate.Size = new Size(160, 26);
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            this.dtpEndDate.Font = new Font("Segoe UI", 9.5f);

            this.pnlDateRow.Controls.AddRange(new Control[] {
                this.lblStartDate, this.dtpStartDate,
                this.lblEndDate,   this.dtpEndDate
            });

            // ── Button Row 1 ──────────────────────────────────────────
            this.pnlBtnRow1.Location = new Point(20, 108);
            this.pnlBtnRow1.Size = new Size(820, 44);
            this.pnlBtnRow1.BackColor = Color.Transparent;

            RB(this.btnSalesReport, "📊  Revenue Report", 0, 0, 170, 38, Color.FromArgb(25, 80, 140));
            RB(this.btnInventoryReport, "🗺️  Zone Performance", 180, 0, 170, 38, Color.FromArgb(46, 100, 60));
            RB(this.btnTopProducts, "👥  Staff Workload", 360, 0, 170, 38, Color.FromArgb(100, 60, 130));
            RB(this.btnLowStock, "🏢  Revenue by Branch", 540, 0, 170, 38, Color.FromArgb(140, 60, 30));

            this.btnSalesReport.Click += new System.EventHandler(this.btnSalesReport_Click);
            this.btnInventoryReport.Click += new System.EventHandler(this.btnInventoryReport_Click);
            this.btnTopProducts.Click += new System.EventHandler(this.btnTopProducts_Click);
            this.btnLowStock.Click += new System.EventHandler(this.btnLowStock_Click);

            this.pnlBtnRow1.Controls.AddRange(new Control[] {
                this.btnSalesReport, this.btnInventoryReport,
                this.btnTopProducts, this.btnLowStock
            });

            // ── Button Row 2 ──────────────────────────────────────────
            this.pnlBtnRow2.Location = new Point(20, 158);
            this.pnlBtnRow2.Size = new Size(820, 44);
            this.pnlBtnRow2.BackColor = Color.Transparent;

            RB(this.btnRevenueByCategory, "📣  Complaint Summary", 0, 0, 170, 38, Color.FromArgb(120, 80, 20));
            RB(this.btnCustomerHistory, "📦  Parcel Volume", 180, 0, 170, 38, Color.FromArgb(30, 100, 110));
            RB(this.btnExport, "⬇  Export CSV", 540, 0, 130, 38, Color.FromArgb(55, 55, 55));

            this.btnRevenueByCategory.Click += new System.EventHandler(this.btnRevenueByCategory_Click);
            this.btnCustomerHistory.Click += new System.EventHandler(this.btnCustomerHistory_Click);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            this.pnlBtnRow2.Controls.AddRange(new Control[] {
                this.btnRevenueByCategory, this.btnCustomerHistory, this.btnExport
            });

            // lblReportTitle
            this.lblReportTitle.AutoSize = false;
            this.lblReportTitle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            this.lblReportTitle.ForeColor = accent;
            this.lblReportTitle.Location = new Point(20, 212);
            this.lblReportTitle.Size = new Size(820, 24);
            this.lblReportTitle.Text = "Select a report from the buttons above";

            // dgvReport
            this.dgvReport.Location = new Point(20, 242);
            this.dgvReport.Size = new Size(820, 330);
            this.dgvReport.BackgroundColor = gridBg;
            this.dgvReport.ForeColor = textMain;
            this.dgvReport.GridColor = Color.FromArgb(50, 50, 50);
            this.dgvReport.BorderStyle = BorderStyle.None;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.ReadOnly = true;
            this.dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Font = new Font("Segoe UI", 9f);
            this.dgvReport.RowTemplate.Height = 30;
            this.dgvReport.DefaultCellStyle.BackColor = gridBg;
            this.dgvReport.DefaultCellStyle.ForeColor = textMain;
            this.dgvReport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvReport.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvReport.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvReport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.dgvReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);

            this.Controls.AddRange(new Control[] {
                this.lblTitle, this.pnlDateRow,
                this.pnlBtnRow1, this.pnlBtnRow2,
                this.lblReportTitle, this.dgvReport
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void DL(Label l, string t, int x, int y, Color fg)
        { l.AutoSize = true; l.Location = new Point(x, y); l.Text = t; l.ForeColor = fg; l.Font = new Font("Segoe UI", 9f, FontStyle.Bold); }

        private void RB(Button b, string t, int x, int y, int w, int h, Color bg)
        {
            b.Location = new Point(x, y); b.Size = new Size(w, h); b.Text = t;
            b.BackColor = bg; b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat; b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 9f, FontStyle.Bold); b.Cursor = Cursors.Hand;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(
                Math.Min(bg.R + 30, 255), Math.Min(bg.G + 30, 255), Math.Min(bg.B + 30, 255));
        }

        #endregion

        private Label lblTitle, lblReportTitle, lblStartDate, lblEndDate;
        private DateTimePicker dtpStartDate, dtpEndDate;
        private Button btnSalesReport, btnInventoryReport, btnTopProducts;
        private Button btnLowStock, btnRevenueByCategory, btnCustomerHistory, btnExport;
        private DataGridView dgvReport;
        private Panel pnlDateRow, pnlBtnRow1, pnlBtnRow2;
    }
}








//namespace CourierDB.UI
//{
//    partial class frmReports
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
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.lblReportTitle = new System.Windows.Forms.Label();

//            // ── Report buttons ──
//            this.btnSalesReport = new System.Windows.Forms.Button();
//            this.btnInventoryReport = new System.Windows.Forms.Button();
//            this.btnTopProducts = new System.Windows.Forms.Button();
//            this.btnLowStock = new System.Windows.Forms.Button();
//            this.btnRevenueByCategory = new System.Windows.Forms.Button();
//            this.btnCustomerHistory = new System.Windows.Forms.Button();
//            this.btnExport = new System.Windows.Forms.Button();

//            // ── Date pickers for Sales Report ──
//            this.lblStartDate = new System.Windows.Forms.Label();
//            this.lblEndDate = new System.Windows.Forms.Label();
//            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
//            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();

//            // ── Grid ──
//            this.dgvReport = new System.Windows.Forms.DataGridView();

//            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
//            this.SuspendLayout();

//            // ── lblTitle ──────────────────────────────────────────────────
//            this.lblTitle.AutoSize = false;
//            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(46, 117, 182);
//            this.lblTitle.Location = new System.Drawing.Point(20, 15);
//            this.lblTitle.Name = "lblTitle";
//            this.lblTitle.Size = new System.Drawing.Size(200, 35);
//            this.lblTitle.Text = "Reports";

//            // ── Date pickers row ──────────────────────────────────────────
//            this.lblStartDate.AutoSize = true;
//            this.lblStartDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.lblStartDate.Location = new System.Drawing.Point(20, 60);
//            this.lblStartDate.Name = "lblStartDate";
//            this.lblStartDate.Text = "Start Date:";

//            this.dtpStartDate.Font = new System.Drawing.Font("Arial", 10F);
//            this.dtpStartDate.Location = new System.Drawing.Point(120, 57);
//            this.dtpStartDate.Name = "dtpStartDate";
//            this.dtpStartDate.Size = new System.Drawing.Size(180, 26);
//            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
//            this.dtpStartDate.TabIndex = 0;

//            this.lblEndDate.AutoSize = true;
//            this.lblEndDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.lblEndDate.Location = new System.Drawing.Point(320, 60);
//            this.lblEndDate.Name = "lblEndDate";
//            this.lblEndDate.Text = "End Date:";

//            this.dtpEndDate.Font = new System.Drawing.Font("Arial", 10F);
//            this.dtpEndDate.Location = new System.Drawing.Point(410, 57);
//            this.dtpEndDate.Name = "dtpEndDate";
//            this.dtpEndDate.Size = new System.Drawing.Size(180, 26);
//            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
//            this.dtpEndDate.TabIndex = 1;

//            // ── Report buttons row ────────────────────────────────────────
//            // btnSalesReport
//            this.btnSalesReport.Location = new System.Drawing.Point(20, 100);
//            this.btnSalesReport.Name = "btnSalesReport";
//            this.btnSalesReport.Size = new System.Drawing.Size(140, 38);
//            this.btnSalesReport.Text = "Sales Report";
//            this.btnSalesReport.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
//            this.btnSalesReport.BackColor = System.Drawing.Color.FromArgb(46, 117, 182);
//            this.btnSalesReport.ForeColor = System.Drawing.Color.White;
//            this.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnSalesReport.UseVisualStyleBackColor = false;
//            this.btnSalesReport.TabIndex = 2;
//            // FIX: wired to btnSalesReport_Click (not _Click_1)
//            this.btnSalesReport.Click += new System.EventHandler(this.btnSalesReport_Click);

//            // btnInventoryReport
//            this.btnInventoryReport.Location = new System.Drawing.Point(170, 100);
//            this.btnInventoryReport.Name = "btnInventoryReport";
//            this.btnInventoryReport.Size = new System.Drawing.Size(140, 38);
//            this.btnInventoryReport.Text = "Inventory Report";
//            this.btnInventoryReport.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
//            this.btnInventoryReport.BackColor = System.Drawing.Color.FromArgb(46, 117, 182);
//            this.btnInventoryReport.ForeColor = System.Drawing.Color.White;
//            this.btnInventoryReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnInventoryReport.UseVisualStyleBackColor = false;
//            this.btnInventoryReport.TabIndex = 3;
//            // FIX: wired to btnInventoryReport_Click (not _Click_1)
//            this.btnInventoryReport.Click += new System.EventHandler(this.btnInventoryReport_Click);

//            // btnTopProducts
//            this.btnTopProducts.Location = new System.Drawing.Point(320, 100);
//            this.btnTopProducts.Name = "btnTopProducts";
//            this.btnTopProducts.Size = new System.Drawing.Size(140, 38);
//            this.btnTopProducts.Text = "Top 10 Products";
//            this.btnTopProducts.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
//            this.btnTopProducts.BackColor = System.Drawing.Color.FromArgb(84, 130, 53);
//            this.btnTopProducts.ForeColor = System.Drawing.Color.White;
//            this.btnTopProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnTopProducts.UseVisualStyleBackColor = false;
//            this.btnTopProducts.TabIndex = 4;
//            // FIX: wired to btnTopProducts_Click (not _Click_1)
//            this.btnTopProducts.Click += new System.EventHandler(this.btnTopProducts_Click);

//            // btnLowStock
//            this.btnLowStock.Location = new System.Drawing.Point(470, 100);
//            this.btnLowStock.Name = "btnLowStock";
//            this.btnLowStock.Size = new System.Drawing.Size(140, 38);
//            this.btnLowStock.Text = "Low Stock Alert";
//            this.btnLowStock.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
//            this.btnLowStock.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
//            this.btnLowStock.ForeColor = System.Drawing.Color.White;
//            this.btnLowStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnLowStock.UseVisualStyleBackColor = false;
//            this.btnLowStock.TabIndex = 5;
//            // FIX: wired to btnLowStock_Click (not _Click_1)
//            this.btnLowStock.Click += new System.EventHandler(this.btnLowStock_Click);

//            // btnRevenueByCategory
//            this.btnRevenueByCategory.Location = new System.Drawing.Point(20, 148);
//            this.btnRevenueByCategory.Name = "btnRevenueByCategory";
//            this.btnRevenueByCategory.Size = new System.Drawing.Size(175, 38);
//            this.btnRevenueByCategory.Text = "Revenue by Category";
//            this.btnRevenueByCategory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
//            this.btnRevenueByCategory.BackColor = System.Drawing.Color.FromArgb(84, 130, 53);
//            this.btnRevenueByCategory.ForeColor = System.Drawing.Color.White;
//            this.btnRevenueByCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnRevenueByCategory.UseVisualStyleBackColor = false;
//            this.btnRevenueByCategory.TabIndex = 6;
//            this.btnRevenueByCategory.Click += new System.EventHandler(this.btnRevenueByCategory_Click);

//            // btnCustomerHistory
//            this.btnCustomerHistory.Location = new System.Drawing.Point(205, 148);
//            this.btnCustomerHistory.Name = "btnCustomerHistory";
//            this.btnCustomerHistory.Size = new System.Drawing.Size(175, 38);
//            this.btnCustomerHistory.Text = "Customer History";
//            this.btnCustomerHistory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
//            this.btnCustomerHistory.BackColor = System.Drawing.Color.FromArgb(84, 130, 53);
//            this.btnCustomerHistory.ForeColor = System.Drawing.Color.White;
//            this.btnCustomerHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnCustomerHistory.UseVisualStyleBackColor = false;
//            this.btnCustomerHistory.TabIndex = 7;
//            this.btnCustomerHistory.Click += new System.EventHandler(this.btnCustomerHistory_Click);

//            // btnExport
//            this.btnExport.Location = new System.Drawing.Point(620, 148);
//            this.btnExport.Name = "btnExport";
//            this.btnExport.Size = new System.Drawing.Size(140, 38);
//            this.btnExport.Text = "Export to CSV";
//            this.btnExport.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
//            this.btnExport.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
//            this.btnExport.ForeColor = System.Drawing.Color.White;
//            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnExport.UseVisualStyleBackColor = false;
//            this.btnExport.TabIndex = 8;
//            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

//            // ── lblReportTitle ────────────────────────────────────────────
//            this.lblReportTitle.AutoSize = false;
//            this.lblReportTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
//            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(84, 130, 53);
//            this.lblReportTitle.Location = new System.Drawing.Point(20, 198);
//            this.lblReportTitle.Name = "lblReportTitle";
//            this.lblReportTitle.Size = new System.Drawing.Size(740, 25);
//            this.lblReportTitle.Text = "Select a report from the buttons above";

//            // ── dgvReport ─────────────────────────────────────────────────
//            this.dgvReport.ColumnHeadersHeightSizeMode =
//                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvReport.Location = new System.Drawing.Point(20, 228);
//            this.dgvReport.Name = "dgvReport";
//            this.dgvReport.RowHeadersWidth = 40;
//            this.dgvReport.RowTemplate.Height = 28;
//            // FIX: size expanded from tiny 240x150 to full usable area
//            this.dgvReport.Size = new System.Drawing.Size(740, 280);
//            this.dgvReport.TabIndex = 9;
//            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
//            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.dgvReport.SelectionMode =
//                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvReport.ReadOnly = true;
//            this.dgvReport.AllowUserToAddRows = false;
//            this.dgvReport.AllowUserToDeleteRows = false;
//            this.dgvReport.AutoSizeColumnsMode =
//                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

//            // ── frmReports ────────────────────────────────────────────────
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(800, 530);
//            this.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
//            this.Text = "Reports";
//            this.Name = "frmReports";
//            this.Load += new System.EventHandler(this.frmReports_Load);
//            this.Controls.Add(this.lblTitle);
//            this.Controls.Add(this.lblStartDate);
//            this.Controls.Add(this.dtpStartDate);
//            this.Controls.Add(this.lblEndDate);
//            this.Controls.Add(this.dtpEndDate);
//            this.Controls.Add(this.btnSalesReport);
//            this.Controls.Add(this.btnInventoryReport);
//            this.Controls.Add(this.btnTopProducts);
//            this.Controls.Add(this.btnLowStock);
//            this.Controls.Add(this.btnRevenueByCategory);
//            this.Controls.Add(this.btnCustomerHistory);
//            this.Controls.Add(this.btnExport);
//            this.Controls.Add(this.lblReportTitle);
//            this.Controls.Add(this.dgvReport);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        #endregion

//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Label lblReportTitle;
//        private System.Windows.Forms.Label lblStartDate;
//        private System.Windows.Forms.Label lblEndDate;
//        private System.Windows.Forms.DateTimePicker dtpStartDate;
//        private System.Windows.Forms.DateTimePicker dtpEndDate;
//        private System.Windows.Forms.Button btnSalesReport;
//        private System.Windows.Forms.Button btnInventoryReport;
//        private System.Windows.Forms.Button btnTopProducts;
//        private System.Windows.Forms.Button btnLowStock;
//        private System.Windows.Forms.Button btnRevenueByCategory;
//        private System.Windows.Forms.Button btnCustomerHistory;
//        private System.Windows.Forms.Button btnExport;
//        private System.Windows.Forms.DataGridView dgvReport;
//    }
//}