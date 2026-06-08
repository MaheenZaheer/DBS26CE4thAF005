using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManageVehicles
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
            this.lblRegNo = new System.Windows.Forms.Label();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.txtVehicleType = new System.Windows.Forms.TextBox();
            this.lblCapacityKg = new System.Windows.Forms.Label();
            this.txtCapacityKg = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();

            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
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
            this.lblTitle.Text = "🚚  Manage Fleet — Vehicles";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = txtMain;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

            // ── grpInput (card) ───────────────────────────────────────
            this.grpInput.Text = "Vehicle Details";
            this.grpInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInput.ForeColor = accent;
            this.grpInput.BackColor = card;
            this.grpInput.Location = new System.Drawing.Point(16, 71);
            this.grpInput.Size = new System.Drawing.Size(768, 148);

            // Row 1 — Reg No, Vehicle Type
            VL(this.lblRegNo, "Reg No:", 10, 30, 80, txtDim);
            VT(this.txtRegNo, 98, 27, 200, inputBg, txtMain, 1);

            VL(this.lblVehicleType, "Type:", 324, 30, 55, txtDim);
            VT(this.txtVehicleType, 387, 27, 200, inputBg, txtMain, 2);

            // Row 2 — Capacity, Branch, Available
            VL(this.lblCapacityKg, "Capacity (kg):", 10, 74, 110, txtDim);
            VT(this.txtCapacityKg, 128, 71, 120, inputBg, txtMain, 3);

            VL(this.lblBranch, "Branch:", 270, 74, 70, txtDim);
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBranch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbBranch.BackColor = inputBg;
            this.cmbBranch.ForeColor = txtMain;
            this.cmbBranch.Location = new System.Drawing.Point(348, 71);
            this.cmbBranch.Size = new System.Drawing.Size(200, 28);
            this.cmbBranch.TabIndex = 4;

            this.chkAvailable.AutoSize = false;
            this.chkAvailable.Location = new System.Drawing.Point(570, 73);
            this.chkAvailable.Size = new System.Drawing.Size(110, 26);
            this.chkAvailable.Text = "Available";
            this.chkAvailable.Checked = true;
            this.chkAvailable.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkAvailable.ForeColor = green;
            this.chkAvailable.BackColor = card;
            this.chkAvailable.TabIndex = 5;

            this.grpInput.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblRegNo,       this.txtRegNo,
                this.lblVehicleType, this.txtVehicleType,
                this.lblCapacityKg,  this.txtCapacityKg,
                this.lblBranch,      this.cmbBranch,
                this.chkAvailable
            });

            // ── pnlButtons ────────────────────────────────────────────
            this.pnlButtons.BackColor = Color.FromArgb(28, 28, 28);
            this.pnlButtons.Location = new System.Drawing.Point(16, 231);
            this.pnlButtons.Size = new System.Drawing.Size(768, 56);

            int bx = 14, bw = 130, bh = 36, bgap = 14;
            VB(this.btnAdd, "➕  Add Vehicle", bx, 10, bw, bh, blue);
            VB(this.btnUpdate, "✏  Update", bx + bw + bgap, 10, bw, bh, orange);
            VB(this.btnDelete, "🗑  Delete", bx + (bw + bgap) * 2, 10, bw, bh, red);
            VB(this.btnClear, "✕  Clear", bx + (bw + bgap) * 3, 10, bw, bh, gray);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear
            });

            // ── dgvVehicles ───────────────────────────────────────────
            this.dgvVehicles.AllowUserToAddRows = false;
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.ReadOnly = true;
            this.dgvVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicles.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicles.MultiSelect = false;
            this.dgvVehicles.RowTemplate.Height = 30;
            this.dgvVehicles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVehicles.BackgroundColor = gridBg;
            this.dgvVehicles.GridColor = border;
            this.dgvVehicles.EnableHeadersVisualStyles = false;
            this.dgvVehicles.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.dgvVehicles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvVehicles.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvVehicles.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.dgvVehicles.DefaultCellStyle.BackColor = gridBg;
            this.dgvVehicles.DefaultCellStyle.ForeColor = txtMain;
            this.dgvVehicles.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvVehicles.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvVehicles.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

            this.dgvVehicles.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvVehicles.Location = new System.Drawing.Point(16, 299);
            this.dgvVehicles.Size = new System.Drawing.Size(768, 280);
            this.dgvVehicles.TabIndex = 6;
            this.dgvVehicles.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicles_CellClick);

            // ── Form ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = bg;
            this.ForeColor = txtMain;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Text = "Manage Vehicles — CourierDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManageVehicles_Load);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpInput,
                this.pnlButtons,
                this.dgvVehicles,
                this.pnlTop       // Dock=Top added last
            });

            this.grpInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Helpers ───────────────────────────────────────────────────
        private void VL(System.Windows.Forms.Label lbl,
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

        private void VT(System.Windows.Forms.TextBox txt,
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

        private void VB(System.Windows.Forms.Button btn,
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
        private System.Windows.Forms.Label lblRegNo;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.TextBox txtVehicleType;
        private System.Windows.Forms.Label lblCapacityKg;
        private System.Windows.Forms.TextBox txtCapacityKg;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlButtons;
    }
}


//namespace CourierDB.UI
//{
//    partial class frmManageVehicles
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
//            this.lblRegNo       = new System.Windows.Forms.Label();
//            this.txtRegNo       = new System.Windows.Forms.TextBox();
//            this.lblVehicleType = new System.Windows.Forms.Label();
//            this.txtVehicleType = new System.Windows.Forms.TextBox();
//            this.lblCapacityKg  = new System.Windows.Forms.Label();
//            this.txtCapacityKg  = new System.Windows.Forms.TextBox();
//            this.lblBranch      = new System.Windows.Forms.Label();
//            this.cmbBranch      = new System.Windows.Forms.ComboBox();
//            this.chkAvailable   = new System.Windows.Forms.CheckBox();
//            this.btnAdd         = new System.Windows.Forms.Button();
//            this.btnUpdate      = new System.Windows.Forms.Button();
//            this.btnDelete      = new System.Windows.Forms.Button();
//            this.btnClear       = new System.Windows.Forms.Button();
//            this.dgvVehicles    = new System.Windows.Forms.DataGridView();
//            this.grpInput.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
//            this.SuspendLayout();

//            // lblTitle
//            this.lblTitle.AutoSize = true;
//            this.lblTitle.Font     = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.Location = new System.Drawing.Point(230, 12);
//            this.lblTitle.Text     = "Manage Fleet — Vehicles";

//            // grpInput
//            this.grpInput.Location = new System.Drawing.Point(20, 45);
//            this.grpInput.Size     = new System.Drawing.Size(750, 140);
//            this.grpInput.Text     = "Vehicle Details";

//            // Row 1
//            AddLblTxt(this.grpInput, this.lblRegNo, "Reg No:", this.txtRegNo, 120, 15, 25, 200);
//            AddLblTxt(this.grpInput, this.lblVehicleType, "Type:", this.txtVehicleType, 370, 15, 25, 180);
//            // Row 2
//            AddLblTxt(this.grpInput, this.lblCapacityKg, "Capacity (kg):", this.txtCapacityKg, 15, 65, 75, 120);
//            // Branch combo
//            this.lblBranch.AutoSize = true;
//            this.lblBranch.Location = new System.Drawing.Point(220, 65);
//            this.lblBranch.Text     = "Branch:";
//            this.cmbBranch.Location = new System.Drawing.Point(285, 62);
//            this.cmbBranch.Size     = new System.Drawing.Size(200, 26);
//            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            // Available checkbox
//            this.chkAvailable.AutoSize = true;
//            this.chkAvailable.Location = new System.Drawing.Point(510, 65);
//            this.chkAvailable.Text     = "Available";
//            this.chkAvailable.Checked  = true;

//            this.grpInput.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblRegNo, this.txtRegNo,
//                this.lblVehicleType, this.txtVehicleType,
//                this.lblCapacityKg, this.txtCapacityKg,
//                this.lblBranch, this.cmbBranch, this.chkAvailable
//            });

//            // Buttons
//            int by = 198, bw = 110, bh = 32, gap = 120;
//            SetBtn(this.btnAdd,    "Add",    20,          by, bw, bh, System.Drawing.Color.SteelBlue);
//            SetBtn(this.btnUpdate, "Update", 20 + gap,    by, bw, bh, System.Drawing.Color.DarkOrange);
//            SetBtn(this.btnDelete, "Delete", 20 + gap*2,  by, bw, bh, System.Drawing.Color.Crimson);
//            SetBtn(this.btnClear,  "Clear",  20 + gap*3,  by, bw, bh, System.Drawing.Color.Gray);
//            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);
//            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
//            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
//            this.btnClear.Click  += new System.EventHandler(this.btnClear_Click);

//            // dgvVehicles
//            this.dgvVehicles.Location            = new System.Drawing.Point(20, 243);
//            this.dgvVehicles.Size                = new System.Drawing.Size(750, 270);
//            this.dgvVehicles.AllowUserToAddRows  = false;
//            this.dgvVehicles.ReadOnly            = true;
//            this.dgvVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvVehicles.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvVehicles.CellClick          += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicles_CellClick);

//            // Form
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize          = new System.Drawing.Size(800, 535);
//            this.Text                = "Manage Vehicles — CourierDB";
//            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Load               += new System.EventHandler(this.frmManageVehicles_Load);
//            this.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblTitle, this.grpInput,
//                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear,
//                this.dgvVehicles
//            });

//            this.grpInput.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        private void AddLblTxt(System.Windows.Forms.Control parent,
//            System.Windows.Forms.Label lbl, string caption,
//            System.Windows.Forms.TextBox txt, int lx, int ty, int tx_offset, int tw)
//        {
//            lbl.AutoSize = true; lbl.Location = new System.Drawing.Point(lx, ty + 3); lbl.Text = caption;
//            txt.Location = new System.Drawing.Point(lx + tx_offset, ty); txt.Size = new System.Drawing.Size(tw, 26);
//            parent.Controls.Add(lbl); parent.Controls.Add(txt);
//        }

//        private void SetBtn(System.Windows.Forms.Button btn, string text, int x, int y, int w, int h,
//            System.Drawing.Color color)
//        {
//            btn.Location = new System.Drawing.Point(x, y); btn.Size = new System.Drawing.Size(w, h);
//            btn.Text = text; btn.BackColor = color; btn.ForeColor = System.Drawing.Color.White;
//            btn.UseVisualStyleBackColor = false;
//        }

//        #endregion

//        private System.Windows.Forms.Label         lblTitle;
//        private System.Windows.Forms.GroupBox      grpInput;
//        private System.Windows.Forms.Label         lblRegNo;
//        private System.Windows.Forms.TextBox       txtRegNo;
//        private System.Windows.Forms.Label         lblVehicleType;
//        private System.Windows.Forms.TextBox       txtVehicleType;
//        private System.Windows.Forms.Label         lblCapacityKg;
//        private System.Windows.Forms.TextBox       txtCapacityKg;
//        private System.Windows.Forms.Label         lblBranch;
//        private System.Windows.Forms.ComboBox      cmbBranch;
//        private System.Windows.Forms.CheckBox      chkAvailable;
//        private System.Windows.Forms.Button        btnAdd;
//        private System.Windows.Forms.Button        btnUpdate;
//        private System.Windows.Forms.Button        btnDelete;
//        private System.Windows.Forms.Button        btnClear;
//        private System.Windows.Forms.DataGridView  dgvVehicles;
//    }
//}
