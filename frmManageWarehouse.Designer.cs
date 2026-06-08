using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManageWarehouse
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
            // ── Dashboard palette ──────────────────────────────────────
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
            Color orange = Color.FromArgb(210, 130, 50);
            Color red = Color.FromArgb(200, 70, 70);
            Color gray = Color.FromArgb(80, 80, 80);
            Color green = Color.FromArgb(90, 180, 130);

            this.lblTitle = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lblWHName = new System.Windows.Forms.Label();
            this.txtWHName = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.lblUsed = new System.Windows.Forms.Label();
            this.txtUsed = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvWarehouses = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();

            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop ────────────────────────────────────────────────
            this.pnlTop.BackColor = header;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "🏭  Manage Warehouses";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = txtMain;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

            // ── grpInput (card) ───────────────────────────────────────
            this.grpInput.Text = "Warehouse Details";
            this.grpInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInput.ForeColor = accent;
            this.grpInput.BackColor = card;
            this.grpInput.Location = new System.Drawing.Point(16, 71);
            this.grpInput.Size = new System.Drawing.Size(768, 170);

            // Row 1 — Name, City
            WL(this.lblWHName, "Name:", 10, 30, 70, txtDim);
            WT(this.txtWHName, 88, 27, 240, inputBg, txtMain, 1);

            WL(this.lblCity, "City:", 346, 30, 55, txtDim);
            WT(this.txtCity, 409, 27, 200, inputBg, txtMain, 2);

            // Row 2 — Address (spans full width)
            WL(this.lblAddress, "Address:", 10, 72, 78, txtDim);
            WT(this.txtAddress, 96, 69, 654, inputBg, txtMain, 3);

            // Row 3 — Capacity, Used, Active
            WL(this.lblCapacity, "Capacity:", 10, 114, 82, txtDim);
            WT(this.txtCapacity, 100, 111, 120, inputBg, txtMain, 4);

            WL(this.lblUsed, "Used:", 240, 114, 55, txtDim);
            WT(this.txtUsed, 303, 111, 100, inputBg, txtMain, 5);
            this.txtUsed.Text = "0";

            this.chkIsActive.AutoSize = false;
            this.chkIsActive.Location = new System.Drawing.Point(424, 113);
            this.chkIsActive.Size = new System.Drawing.Size(90, 26);
            this.chkIsActive.Text = "Active";
            this.chkIsActive.Checked = true;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.ForeColor = green;
            this.chkIsActive.BackColor = card;
            this.chkIsActive.TabIndex = 6;

            this.grpInput.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblWHName,   this.txtWHName,
                this.lblCity,     this.txtCity,
                this.lblAddress,  this.txtAddress,
                this.lblCapacity, this.txtCapacity,
                this.lblUsed,     this.txtUsed,
                this.chkIsActive
            });

            // ── pnlButtons ────────────────────────────────────────────
            this.pnlButtons.BackColor = Color.FromArgb(28, 28, 28);
            this.pnlButtons.Location = new System.Drawing.Point(16, 253);
            this.pnlButtons.Size = new System.Drawing.Size(768, 56);

            int bx = 14, bw = 140, bh = 36, bgap = 14;
            WB(this.btnAdd, "➕  Add Warehouse", bx, 10, bw, bh, blue);
            WB(this.btnUpdate, "✏  Update", bx + bw + bgap, 10, bw, bh, orange);
            WB(this.btnDelete, "🗑  Delete", bx + (bw + bgap) * 2, 10, bw, bh, red);
            WB(this.btnClear, "✕  Clear", bx + (bw + bgap) * 3, 10, bw, bh, gray);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear
            });

            // ── dgvWarehouses ─────────────────────────────────────────
            this.dgvWarehouses.AllowUserToAddRows = false;
            this.dgvWarehouses.AllowUserToDeleteRows = false;
            this.dgvWarehouses.ReadOnly = true;
            this.dgvWarehouses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarehouses.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouses.MultiSelect = false;
            this.dgvWarehouses.RowTemplate.Height = 30;
            this.dgvWarehouses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWarehouses.BackgroundColor = gridBg;
            this.dgvWarehouses.GridColor = border;
            this.dgvWarehouses.EnableHeadersVisualStyles = false;
            this.dgvWarehouses.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.dgvWarehouses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvWarehouses.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvWarehouses.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.dgvWarehouses.DefaultCellStyle.BackColor = gridBg;
            this.dgvWarehouses.DefaultCellStyle.ForeColor = txtMain;
            this.dgvWarehouses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvWarehouses.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvWarehouses.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

            this.dgvWarehouses.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvWarehouses.Location = new System.Drawing.Point(16, 321);
            this.dgvWarehouses.Size = new System.Drawing.Size(768, 280);
            this.dgvWarehouses.TabIndex = 7;
            this.dgvWarehouses.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouses_CellClick);

            // ── Form ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = bg;
            this.ForeColor = txtMain;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.MinimumSize = new System.Drawing.Size(800, 620);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Text = "Manage Warehouses — CourierDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManageWarehouse_Load);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpInput,
                this.pnlButtons,
                this.dgvWarehouses,
                this.pnlTop       // Dock=Top added last
            });

            this.grpInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Helpers ───────────────────────────────────────────────────
        private void WL(System.Windows.Forms.Label lbl,
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

        private void WT(System.Windows.Forms.TextBox txt,
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

        private void WB(System.Windows.Forms.Button btn,
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

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblWHName;
        private System.Windows.Forms.TextBox txtWHName;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label lblUsed;
        private System.Windows.Forms.TextBox txtUsed;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvWarehouses;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlButtons;
    }
}



//namespace CourierDB.UI
//{
//    partial class frmManageWarehouse
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
//            this.lblTitle       = new System.Windows.Forms.Label();
//            this.grpInput       = new System.Windows.Forms.GroupBox();
//            this.lblWHName      = new System.Windows.Forms.Label();
//            this.txtWHName      = new System.Windows.Forms.TextBox();
//            this.lblCity        = new System.Windows.Forms.Label();
//            this.txtCity        = new System.Windows.Forms.TextBox();
//            this.lblAddress     = new System.Windows.Forms.Label();
//            this.txtAddress     = new System.Windows.Forms.TextBox();
//            this.lblCapacity    = new System.Windows.Forms.Label();
//            this.txtCapacity    = new System.Windows.Forms.TextBox();
//            this.lblUsed        = new System.Windows.Forms.Label();
//            this.txtUsed        = new System.Windows.Forms.TextBox();
//            this.chkIsActive    = new System.Windows.Forms.CheckBox();
//            this.btnAdd         = new System.Windows.Forms.Button();
//            this.btnUpdate      = new System.Windows.Forms.Button();
//            this.btnDelete      = new System.Windows.Forms.Button();
//            this.btnClear       = new System.Windows.Forms.Button();
//            this.dgvWarehouses  = new System.Windows.Forms.DataGridView();
//            this.grpInput.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).BeginInit();
//            this.SuspendLayout();

//            // lblTitle
//            this.lblTitle.AutoSize = true;
//            this.lblTitle.Font     = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.Location = new System.Drawing.Point(240, 12);
//            this.lblTitle.Text     = "Manage Warehouses";

//            // grpInput
//            this.grpInput.Location = new System.Drawing.Point(20, 45);
//            this.grpInput.Size     = new System.Drawing.Size(750, 165);
//            this.grpInput.Text     = "Warehouse Details";

//            // Row 1: Name + City
//            SL(this.grpInput, this.lblWHName, "Name:",  this.txtWHName,  15, 28, 65, 220);
//            SL(this.grpInput, this.lblCity,   "City:",  this.txtCity,    360, 28, 45, 180);
//            // Row 2: Address (full width)
//            SL(this.grpInput, this.lblAddress,"Address:", this.txtAddress,15, 65, 75, 600);
//            // Row 3: Capacity + Used + Active
//            SL(this.grpInput, this.lblCapacity,"Capacity:", this.txtCapacity, 15, 102, 80, 100);
//            SL(this.grpInput, this.lblUsed,    "Used:",     this.txtUsed,    240, 102, 50, 80);
//            this.txtUsed.Text = "0";
//            this.chkIsActive.AutoSize = true;
//            this.chkIsActive.Location = new System.Drawing.Point(400, 102);
//            this.chkIsActive.Text     = "Active";
//            this.chkIsActive.Checked  = true;
//            this.grpInput.Controls.Add(this.chkIsActive);

//            // Buttons
//            int by = 222, bw = 110, bh = 32, gap = 120;
//            SB(this.btnAdd,    "Add",    20,         by, bw, bh, System.Drawing.Color.SteelBlue);
//            SB(this.btnUpdate, "Update", 20 + gap,   by, bw, bh, System.Drawing.Color.DarkOrange);
//            SB(this.btnDelete, "Delete", 20 + gap*2, by, bw, bh, System.Drawing.Color.Crimson);
//            SB(this.btnClear,  "Clear",  20 + gap*3, by, bw, bh, System.Drawing.Color.Gray);
//            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);
//            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
//            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
//            this.btnClear.Click  += new System.EventHandler(this.btnClear_Click);

//            // dgvWarehouses
//            this.dgvWarehouses.Location            = new System.Drawing.Point(20, 268);
//            this.dgvWarehouses.Size                = new System.Drawing.Size(750, 270);
//            this.dgvWarehouses.AllowUserToAddRows  = false;
//            this.dgvWarehouses.ReadOnly            = true;
//            this.dgvWarehouses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvWarehouses.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvWarehouses.CellClick          += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouses_CellClick);

//            // Form
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize          = new System.Drawing.Size(800, 560);
//            this.Text                = "Manage Warehouse — CourierDB";
//            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Load               += new System.EventHandler(this.frmManageWarehouse_Load);
//            this.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblTitle, this.grpInput,
//                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear,
//                this.dgvWarehouses
//            });

//            this.grpInput.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        private void SL(System.Windows.Forms.Control p,
//            System.Windows.Forms.Label lbl, string cap,
//            System.Windows.Forms.TextBox txt, int lx, int ty, int offset, int w)
//        {
//            lbl.AutoSize = true; lbl.Location = new System.Drawing.Point(lx, ty + 3); lbl.Text = cap;
//            txt.Location = new System.Drawing.Point(lx + offset, ty); txt.Size = new System.Drawing.Size(w, 26);
//            p.Controls.Add(lbl); p.Controls.Add(txt);
//        }
//        private void SB(System.Windows.Forms.Button btn, string text, int x, int y, int w, int h,
//            System.Drawing.Color c)
//        {
//            btn.Location = new System.Drawing.Point(x, y); btn.Size = new System.Drawing.Size(w, h);
//            btn.Text = text; btn.BackColor = c; btn.ForeColor = System.Drawing.Color.White;
//            btn.UseVisualStyleBackColor = false;
//        }

//        #endregion

//        private System.Windows.Forms.Label         lblTitle;
//        private System.Windows.Forms.GroupBox      grpInput;
//        private System.Windows.Forms.Label         lblWHName;
//        private System.Windows.Forms.TextBox       txtWHName;
//        private System.Windows.Forms.Label         lblCity;
//        private System.Windows.Forms.TextBox       txtCity;
//        private System.Windows.Forms.Label         lblAddress;
//        private System.Windows.Forms.TextBox       txtAddress;
//        private System.Windows.Forms.Label         lblCapacity;
//        private System.Windows.Forms.TextBox       txtCapacity;
//        private System.Windows.Forms.Label         lblUsed;
//        private System.Windows.Forms.TextBox       txtUsed;
//        private System.Windows.Forms.CheckBox      chkIsActive;
//        private System.Windows.Forms.Button        btnAdd;
//        private System.Windows.Forms.Button        btnUpdate;
//        private System.Windows.Forms.Button        btnDelete;
//        private System.Windows.Forms.Button        btnClear;
//        private System.Windows.Forms.DataGridView  dgvWarehouses;
//    }
//}
