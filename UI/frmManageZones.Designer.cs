using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManageZones
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
            Color border = Color.FromArgb(60, 60, 60);
            Color gridBg = Color.FromArgb(32, 32, 32);

            this.lblTitle = new Label();
            this.grpInput = new GroupBox();
            this.lblZoneName = new Label();
            this.txtZoneName = new TextBox();
            this.lblCities = new Label();
            this.txtCities = new TextBox();
            this.lblBaseRate = new Label();
            this.txtBaseRate = new TextBox();
            this.lblPerKgRate = new Label();
            this.txtPerKgRate = new TextBox();
            this.chkIsActive = new CheckBox();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();
            this.dgvZones = new DataGridView();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).BeginInit();
            this.SuspendLayout();

            // Form
            this.BackColor = bg;
            this.ForeColor = textMain;
            this.ClientSize = new Size(820, 580);
            this.Text = "Manage Delivery Zones — CourierDB";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f);
            this.Load += new System.EventHandler(this.frmManageZones_Load);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 15f, FontStyle.Bold);
            this.lblTitle.ForeColor = accent;
            this.lblTitle.Location = new Point(20, 18);
            this.lblTitle.Text = "Manage Delivery Zones";

            // grpInput
            this.grpInput.Location = new Point(20, 55);
            this.grpInput.Size = new Size(775, 155);
            this.grpInput.Text = "Zone Details";
            this.grpInput.ForeColor = textDim;
            this.grpInput.BackColor = card;
            this.grpInput.Font = new Font("Segoe UI", 9f);

            // Row 1: Zone Name + Cities
            DL(this.lblZoneName, "Zone Name:", 15, 28, accent);
            DT(this.txtZoneName, 115, 25, 180, bg, textMain, border);

            DL(this.lblCities, "Cities:", 315, 28, accent);
            DT(this.txtCities, 380, 25, 370, bg, textMain, border);

            // Row 2: Base Rate + Per KG Rate + Active
            DL(this.lblBaseRate, "Base Rate (Rs):", 15, 72, accent);
            DT(this.txtBaseRate, 130, 69, 110, bg, textMain, border);

            DL(this.lblPerKgRate, "Per KG Rate (Rs):", 260, 72, accent);
            DT(this.txtPerKgRate, 390, 69, 110, bg, textMain, border);

            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new Point(525, 72);
            this.chkIsActive.Text = "Active";
            this.chkIsActive.Checked = true;
            this.chkIsActive.ForeColor = textMain;
            this.chkIsActive.BackColor = card;

            this.grpInput.Controls.AddRange(new Control[] {
                this.lblZoneName,  this.txtZoneName,
                this.lblCities,    this.txtCities,
                this.lblBaseRate,  this.txtBaseRate,
                this.lblPerKgRate, this.txtPerKgRate,
                this.chkIsActive
            });

            // Buttons
            int by = 222;
            DB(this.btnAdd, "＋  Add", 20, by, 120, 34, Color.FromArgb(46, 125, 50));
            DB(this.btnUpdate, "✎  Update", 150, by, 120, 34, Color.FromArgb(230, 180, 80), Color.Black);
            DB(this.btnDelete, "✕  Delete", 280, by, 120, 34, Color.FromArgb(183, 28, 28));
            DB(this.btnClear, "↺  Clear", 410, by, 120, 34, Color.FromArgb(55, 55, 55));
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // dgvZones
            this.dgvZones.Location = new Point(20, 270);
            this.dgvZones.Size = new Size(775, 285);
            this.dgvZones.BackgroundColor = gridBg;
            this.dgvZones.ForeColor = textMain;
            this.dgvZones.GridColor = Color.FromArgb(50, 50, 50);
            this.dgvZones.BorderStyle = BorderStyle.None;
            this.dgvZones.RowHeadersVisible = false;
            this.dgvZones.AllowUserToAddRows = false;
            this.dgvZones.ReadOnly = true;
            this.dgvZones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvZones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvZones.EnableHeadersVisualStyles = false;
            this.dgvZones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZones.Font = new Font("Segoe UI", 9f);
            this.dgvZones.RowTemplate.Height = 30;
            this.dgvZones.DefaultCellStyle.BackColor = gridBg;
            this.dgvZones.DefaultCellStyle.ForeColor = textMain;
            this.dgvZones.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvZones.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvZones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvZones.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvZones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.dgvZones.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36);
            this.dgvZones.CellClick += new DataGridViewCellEventHandler(this.dgvZones_CellClick);

            this.Controls.AddRange(new Control[] {
                this.lblTitle, this.grpInput,
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear,
                this.dgvZones
            });

            this.grpInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // helpers
        private void DL(Label l, string t, int x, int y, Color fg)
        { l.AutoSize = true; l.Location = new Point(x, y); l.Text = t; l.ForeColor = fg; l.Font = new Font("Segoe UI", 9f, FontStyle.Bold); }
        private void DT(TextBox tb, int x, int y, int w, Color bg, Color fg, Color border)
        { tb.Location = new Point(x, y); tb.Size = new Size(w, 26); tb.BackColor = bg; tb.ForeColor = fg; tb.BorderStyle = BorderStyle.FixedSingle; }
        private void DB(Button b, string t, int x, int y, int w, int h, Color bg, Color fg = default)
        {
            b.Location = new Point(x, y); b.Size = new Size(w, h); b.Text = t;
            b.BackColor = bg; b.ForeColor = fg == default ? Color.White : fg;
            b.FlatStyle = FlatStyle.Flat; b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 9f, FontStyle.Bold); b.Cursor = Cursors.Hand;
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpInput;
        private Label lblZoneName, lblCities, lblBaseRate, lblPerKgRate;
        private TextBox txtZoneName, txtCities, txtBaseRate, txtPerKgRate;
        private CheckBox chkIsActive;
        private Button btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dgvZones;
    }
}



//namespace CourierDB.UI
//{
//    partial class frmManageZones
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
//            this.lblTitle      = new System.Windows.Forms.Label();
//            this.grpInput      = new System.Windows.Forms.GroupBox();
//            this.lblZoneName   = new System.Windows.Forms.Label();
//            this.txtZoneName   = new System.Windows.Forms.TextBox();
//            this.lblCities     = new System.Windows.Forms.Label();
//            this.txtCities     = new System.Windows.Forms.TextBox();
//            this.lblBaseRate   = new System.Windows.Forms.Label();
//            this.txtBaseRate   = new System.Windows.Forms.TextBox();
//            this.lblPerKgRate  = new System.Windows.Forms.Label();
//            this.txtPerKgRate  = new System.Windows.Forms.TextBox();
//            this.chkIsActive   = new System.Windows.Forms.CheckBox();
//            this.btnAdd        = new System.Windows.Forms.Button();
//            this.btnUpdate     = new System.Windows.Forms.Button();
//            this.btnDelete     = new System.Windows.Forms.Button();
//            this.btnClear      = new System.Windows.Forms.Button();
//            this.dgvZones      = new System.Windows.Forms.DataGridView();
//            this.grpInput.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).BeginInit();
//            this.SuspendLayout();

//            // lblTitle
//            this.lblTitle.AutoSize = true;
//            this.lblTitle.Font     = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.Location = new System.Drawing.Point(230, 12);
//            this.lblTitle.Text     = "Manage Delivery Zones";

//            // grpInput
//            this.grpInput.Location = new System.Drawing.Point(20, 45);
//            this.grpInput.Size     = new System.Drawing.Size(750, 160);
//            this.grpInput.Text     = "Zone Details";

//            int lx = 15, tx = 130, row1 = 25, row2 = 60, row3 = 95;

//            // Zone Name
//            SetLabel(this.lblZoneName, "Zone Name:", lx, row1);
//            SetTextBox(this.txtZoneName, tx, row1 - 3, 200);
//            // Cities
//            SetLabel(this.lblCities, "Cities:", lx, row2);
//            SetTextBox(this.txtCities, tx, row2 - 3, 350);
//            // Base Rate
//            SetLabel(this.lblBaseRate, "Base Rate:", lx, row3);
//            SetTextBox(this.txtBaseRate, tx, row3 - 3, 100);
//            // Per KG Rate
//            SetLabel(this.lblPerKgRate, "Per KG Rate:", 360, row3);
//            SetTextBox(this.txtPerKgRate, 470, row3 - 3, 100);
//            // Active checkbox
//            this.chkIsActive.AutoSize = true;
//            this.chkIsActive.Location = new System.Drawing.Point(600, row3);
//            this.chkIsActive.Text     = "Active";
//            this.chkIsActive.Checked  = true;

//            this.grpInput.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblZoneName, this.txtZoneName,
//                this.lblCities,   this.txtCities,
//                this.lblBaseRate, this.txtBaseRate,
//                this.lblPerKgRate,this.txtPerKgRate,
//                this.chkIsActive
//            });

//            // Buttons
//            int bx = 20, by = 215, bw = 110, bh = 32, gap = 120;
//            SetButton(this.btnAdd,    "Add",    bx,          by, bw, bh, System.Drawing.Color.SteelBlue);
//            SetButton(this.btnUpdate, "Update", bx + gap,    by, bw, bh, System.Drawing.Color.DarkOrange);
//            SetButton(this.btnDelete, "Delete", bx + gap*2,  by, bw, bh, System.Drawing.Color.Crimson);
//            SetButton(this.btnClear,  "Clear",  bx + gap*3,  by, bw, bh, System.Drawing.Color.Gray);
//            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);
//            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
//            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
//            this.btnClear.Click  += new System.EventHandler(this.btnClear_Click);

//            // dgvZones
//            this.dgvZones.Location            = new System.Drawing.Point(20, 260);
//            this.dgvZones.Size                = new System.Drawing.Size(750, 260);
//            this.dgvZones.AllowUserToAddRows  = false;
//            this.dgvZones.ReadOnly            = true;
//            this.dgvZones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvZones.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvZones.CellClick          += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZones_CellClick);

//            // Form
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize          = new System.Drawing.Size(800, 545);
//            this.Text                = "Manage Delivery Zones — CourierDB";
//            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Load               += new System.EventHandler(this.frmManageZones_Load);
//            this.Controls.AddRange(new System.Windows.Forms.Control[] {
//                this.lblTitle, this.grpInput,
//                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear,
//                this.dgvZones
//            });

//            this.grpInput.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        private void SetLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
//        {
//            lbl.AutoSize = true; lbl.Location = new System.Drawing.Point(x, y); lbl.Text = text;
//        }
//        private void SetTextBox(System.Windows.Forms.TextBox txt, int x, int y, int w)
//        {
//            txt.Location = new System.Drawing.Point(x, y); txt.Size = new System.Drawing.Size(w, 26);
//        }
//        private void SetButton(System.Windows.Forms.Button btn, string text, int x, int y, int w, int h, System.Drawing.Color color)
//        {
//            btn.Location = new System.Drawing.Point(x, y); btn.Size = new System.Drawing.Size(w, h);
//            btn.Text = text; btn.BackColor = color; btn.ForeColor = System.Drawing.Color.White;
//            btn.UseVisualStyleBackColor = false;
//        }

//        #endregion

//        private System.Windows.Forms.Label         lblTitle;
//        private System.Windows.Forms.GroupBox      grpInput;
//        private System.Windows.Forms.Label         lblZoneName;
//        private System.Windows.Forms.TextBox       txtZoneName;
//        private System.Windows.Forms.Label         lblCities;
//        private System.Windows.Forms.TextBox       txtCities;
//        private System.Windows.Forms.Label         lblBaseRate;
//        private System.Windows.Forms.TextBox       txtBaseRate;
//        private System.Windows.Forms.Label         lblPerKgRate;
//        private System.Windows.Forms.TextBox       txtPerKgRate;
//        private System.Windows.Forms.CheckBox      chkIsActive;
//        private System.Windows.Forms.Button        btnAdd;
//        private System.Windows.Forms.Button        btnUpdate;
//        private System.Windows.Forms.Button        btnDelete;
//        private System.Windows.Forms.Button        btnClear;
//        private System.Windows.Forms.DataGridView  dgvZones;
//    }
//}
