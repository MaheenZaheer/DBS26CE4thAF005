using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManageStaff
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
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.lblCNIC = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();

            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
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
            this.lblTitle.Text = "🧑‍💼  Manage Staff";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = txtMain;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

            // ── grpInput (card) ───────────────────────────────────────
            this.grpInput.Text = "Staff Details";
            this.grpInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInput.ForeColor = accent;
            this.grpInput.BackColor = card;
            this.grpInput.Location = new System.Drawing.Point(16, 71);
            this.grpInput.Size = new System.Drawing.Size(768, 170);

            // Row 1 — User, Branch
            SL(this.lblUser, "User:", 10, 30, 70, txtDim);
            SC(this.cmbUser, 88, 27, 200, inputBg, txtMain, 1);

            SL(this.lblBranch, "Branch:", 306, 30, 70, txtDim);
            SC(this.cmbBranch, 384, 27, 200, inputBg, txtMain, 2);

            // Row 2 — Designation, CNIC
            SL(this.lblDesignation, "Designation:", 10, 72, 100, txtDim);
            ST(this.txtDesignation, 118, 69, 200, inputBg, txtMain, 3);

            SL(this.lblCNIC, "CNIC:", 330, 72, 60, txtDim);
            ST(this.txtCNIC, 398, 69, 180, inputBg, txtMain, 4);
            this.txtCNIC.MaxLength = 13;

            // Row 3 — Join Date, Active
            SL(this.lblJoinDate, "Join Date:", 10, 114, 90, txtDim);
            this.dtpJoinDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJoinDate.Location = new System.Drawing.Point(108, 111);
            this.dtpJoinDate.Size = new System.Drawing.Size(160, 28);
            this.dtpJoinDate.TabIndex = 5;
            this.dtpJoinDate.CalendarForeColor = txtMain;
            this.dtpJoinDate.CalendarMonthBackground = card;

            this.chkIsActive.AutoSize = false;
            this.chkIsActive.Location = new System.Drawing.Point(300, 113);
            this.chkIsActive.Size = new System.Drawing.Size(90, 26);
            this.chkIsActive.Text = "Active";
            this.chkIsActive.Checked = true;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.ForeColor = green;
            this.chkIsActive.BackColor = card;
            this.chkIsActive.TabIndex = 6;

            this.grpInput.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblUser,        this.cmbUser,
                this.lblBranch,      this.cmbBranch,
                this.lblDesignation, this.txtDesignation,
                this.lblCNIC,        this.txtCNIC,
                this.lblJoinDate,    this.dtpJoinDate,
                this.chkIsActive
            });

            // ── pnlButtons ────────────────────────────────────────────
            this.pnlButtons.BackColor = Color.FromArgb(28, 28, 28);
            this.pnlButtons.Location = new System.Drawing.Point(16, 253);
            this.pnlButtons.Size = new System.Drawing.Size(768, 56);

            int bx = 14, bw = 130, bh = 36, bgap = 14;
            SB(this.btnAdd, "➕  Add Staff", bx, 10, bw, bh, blue);
            SB(this.btnUpdate, "✏  Update", bx + bw + bgap, 10, bw, bh, orange);
            SB(this.btnDelete, "🗑  Delete", bx + (bw + bgap) * 2, 10, bw, bh, red);
            SB(this.btnClear, "✕  Clear", bx + (bw + bgap) * 3, 10, bw, bh, gray);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear
            });

            // ── dgvStaff ──────────────────────────────────────────────
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.MultiSelect = false;
            this.dgvStaff.RowTemplate.Height = 30;
            this.dgvStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStaff.BackgroundColor = gridBg;
            this.dgvStaff.GridColor = border;
            this.dgvStaff.EnableHeadersVisualStyles = false;
            this.dgvStaff.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvStaff.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvStaff.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.dgvStaff.DefaultCellStyle.BackColor = gridBg;
            this.dgvStaff.DefaultCellStyle.ForeColor = txtMain;
            this.dgvStaff.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvStaff.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvStaff.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

            this.dgvStaff.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvStaff.Location = new System.Drawing.Point(16, 321);
            this.dgvStaff.Size = new System.Drawing.Size(768, 280);
            this.dgvStaff.TabIndex = 7;
            this.dgvStaff.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);

            // ── Form ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = bg;
            this.ForeColor = txtMain;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.MinimumSize = new System.Drawing.Size(800, 620);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Text = "Manage Staff — CourierDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManageStaff_Load);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpInput,
                this.pnlButtons,
                this.dgvStaff,
                this.pnlTop       // Dock=Top added last
            });

            this.grpInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Helpers ───────────────────────────────────────────────────
        private void SL(System.Windows.Forms.Label lbl,
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

        private void ST(System.Windows.Forms.TextBox txt,
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

        private void SC(System.Windows.Forms.ComboBox cmb,
            int x, int y, int w, Color bg, Color fg, int tab)
        {
            cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmb.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cmb.BackColor = bg;
            cmb.ForeColor = fg;
            cmb.Location = new System.Drawing.Point(x, y);
            cmb.Size = new System.Drawing.Size(w, 28);
            cmb.TabIndex = tab;
        }

        private void SB(System.Windows.Forms.Button btn,
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
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label lblCNIC;
        private System.Windows.Forms.TextBox txtCNIC;
        private System.Windows.Forms.Label lblJoinDate;
        private System.Windows.Forms.DateTimePicker dtpJoinDate;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlButtons;
    }
}



//namespace CourierDB.UI
//{
//    partial class frmManageStaff
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
//            this.lblUser        = new System.Windows.Forms.Label();
//            this.cmbUser        = new System.Windows.Forms.ComboBox();
//            this.lblBranch      = new System.Windows.Forms.Label();
//            this.cmbBranch      = new System.Windows.Forms.ComboBox();
//            this.lblDesignation = new System.Windows.Forms.Label();
//            this.txtDesignation = new System.Windows.Forms.TextBox();
//            this.lblCNIC        = new System.Windows.Forms.Label();
//            this.txtCNIC        = new System.Windows.Forms.TextBox();
//            this.lblJoinDate    = new System.Windows.Forms.Label();
//            this.dtpJoinDate    = new System.Windows.Forms.DateTimePicker();
//            this.chkIsActive    = new System.Windows.Forms.CheckBox();
//            this.btnAdd         = new System.Windows.Forms.Button();
//            this.btnUpdate      = new System.Windows.Forms.Button();
//            this.btnDelete      = new System.Windows.Forms.Button();
//            this.btnClear       = new System.Windows.Forms.Button();
//            this.dgvStaff       = new System.Windows.Forms.DataGridView();
//            this.grpInput.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
//            this.SuspendLayout();

//            // lblTitle
//            this.lblTitle.AutoSize = true;
//            this.lblTitle.Font     = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.Location = new System.Drawing.Point(250, 12);
//            this.lblTitle.Text     = "Manage Courier Staff";

//            // grpInput
//            this.grpInput.Location = new System.Drawing.Point(20, 45);
//            this.grpInput.Size     = new System.Drawing.Size(750, 165);
//            this.grpInput.Text     = "Staff Details";

//            // Row 1: User combo + Branch combo
//            this.lblUser.AutoSize    = true;
//            this.lblUser.Location    = new System.Drawing.Point(10, 28);
//            this.lblUser.Text        = "User:";
//            this.cmbUser.Location    = new System.Drawing.Point(75, 25);
//            this.cmbUser.Size        = new System.Drawing.Size(220, 26);
//            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

//            this.lblBranch.AutoSize  = true;
//            this.lblBranch.Location  = new System.Drawing.Point(320, 28);
//            this.lblBranch.Text      = "Branch:";
//            this.cmbBranch.Location  = new System.Drawing.Point(390, 25);
//            this.cmbBranch.Size      = new System.Drawing.Size(200, 26);
//            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

//            // Row 2: Designation + CNIC
//            this.lblDesignation.AutoSize = true;
//            this.lblDesignation.Location = new System.Drawing.Point(10, 65);
//            this.lblDesignation.Text     = "Designation:";
//            this.txtDesignation.Location = new System.Drawing.Point(100, 62);
//            this.txtDesignation.Size     = new System.Drawing.Size(200, 26);

//            this.lblCNIC.AutoSize  = true;
//            this.lblCNIC.Location  = new System.Drawing.Point(320, 65);
//            this.lblCNIC.Text      = "CNIC (no dashes):";
//            this.txtCNIC.Location  = new System.Drawing.Point(445, 62);
//            this.txtCNIC.Size      = new System.Drawing.Size(150, 26);
//            this.txtCNIC.MaxLength = 13;

//            // Row 3: Join Date + Active
//            this.lblJoinDate.AutoSize = true;
//            this.lblJoinDate.Location = new System.Drawing.Point(10, 103);
//            this.lblJoinDate.Text     = "Join Date:";
//            this.dtpJoinDate.Location = new System.Drawing.Point(90, 100);
//            this.dtpJoinDate.Size     = new System.Drawing.Size(160, 26);
//            this.dtpJoinDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

//            this.chkIsActive.AutoSize = true;
//            this.chkIsActive.Location = new System.Drawing.Point(280, 103);
//            this.chkIsActive.Text     = "Active";
//            this.chkIsActive.Checked  = true;

//            this.grpInput.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblUser,  this.cmbUser,
//                this.lblBranch, this.cmbBranch,
//                this.lblDesignation, this.txtDesignation,
//                this.lblCNIC, this.txtCNIC,
//                this.lblJoinDate, this.dtpJoinDate,
//                this.chkIsActive
//            });

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

//            // dgvStaff
//            this.dgvStaff.Location            = new System.Drawing.Point(20, 268);
//            this.dgvStaff.Size                = new System.Drawing.Size(750, 280);
//            this.dgvStaff.AllowUserToAddRows  = false;
//            this.dgvStaff.ReadOnly            = true;
//            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvStaff.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvStaff.CellClick          += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);

//            // Form
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize          = new System.Drawing.Size(800, 572);
//            this.Text                = "Manage Staff — CourierDB";
//            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Load               += new System.EventHandler(this.frmManageStaff_Load);
//            this.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblTitle, this.grpInput,
//                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear,
//                this.dgvStaff
//            });

//            this.grpInput.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        private void SB(System.Windows.Forms.Button btn, string text, int x, int y, int w, int h,
//            System.Drawing.Color c)
//        {
//            btn.Location = new System.Drawing.Point(x, y); btn.Size = new System.Drawing.Size(w, h);
//            btn.Text = text; btn.BackColor = c; btn.ForeColor = System.Drawing.Color.White;
//            btn.UseVisualStyleBackColor = false;
//        }

//        #endregion

//        private System.Windows.Forms.Label           lblTitle;
//        private System.Windows.Forms.GroupBox        grpInput;
//        private System.Windows.Forms.Label           lblUser;
//        private System.Windows.Forms.ComboBox        cmbUser;
//        private System.Windows.Forms.Label           lblBranch;
//        private System.Windows.Forms.ComboBox        cmbBranch;
//        private System.Windows.Forms.Label           lblDesignation;
//        private System.Windows.Forms.TextBox         txtDesignation;
//        private System.Windows.Forms.Label           lblCNIC;
//        private System.Windows.Forms.TextBox         txtCNIC;
//        private System.Windows.Forms.Label           lblJoinDate;
//        private System.Windows.Forms.DateTimePicker  dtpJoinDate;
//        private System.Windows.Forms.CheckBox        chkIsActive;
//        private System.Windows.Forms.Button          btnAdd;
//        private System.Windows.Forms.Button          btnUpdate;
//        private System.Windows.Forms.Button          btnDelete;
//        private System.Windows.Forms.Button          btnClear;
//        private System.Windows.Forms.DataGridView    dgvStaff;
//    }
//}
