using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManageUsers
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

            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFormSection = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop ────────────────────────────────────────────────
            this.pnlTop.BackColor = header;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "👥  Manage Users";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = txtMain;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

            // ── dgvUsers ──────────────────────────────────────────────
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.RowTemplate.Height = 30;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.BackgroundColor = gridBg;
            this.dgvUsers.GridColor = border;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.dgvUsers.DefaultCellStyle.BackColor = gridBg;
            this.dgvUsers.DefaultCellStyle.ForeColor = txtMain;
            this.dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

            this.dgvUsers.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvUsers.Location = new System.Drawing.Point(16, 71);
            this.dgvUsers.Size = new System.Drawing.Size(764, 220);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);

            // ── pnlForm (input card) ──────────────────────────────────
            this.pnlForm.BackColor = card;
            this.pnlForm.Location = new System.Drawing.Point(16, 307);
            this.pnlForm.Size = new System.Drawing.Size(764, 200);

            this.lblFormSection.Text = "ADD / EDIT USER";
            this.lblFormSection.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblFormSection.ForeColor = accent;
            this.lblFormSection.Location = new System.Drawing.Point(12, 10);
            this.lblFormSection.AutoSize = true;

            // Two-column layout inside card
            // Left column: Name, Email, Password
            // Right column: Phone, Role
            int lw = 88, iw = 190, lx1 = 12, ix1 = 108, lx2 = 330, ix2 = 428;

            UL(this.label1, "Name:", lx1, 36, lw, txtDim);
            UT(this.txtName, ix1, 34, iw, inputBg, txtMain, 1);

            UL(this.label2, "Email:", lx1, 76, lw, txtDim);
            UT(this.txtEmail, ix1, 74, iw, inputBg, txtMain, 2);

            UL(this.label5, "Password:", lx1, 116, lw, txtDim);
            UT(this.txtPassword, ix1, 114, iw, inputBg, txtMain, 3);
            this.txtPassword.PasswordChar = '●';

            UL(this.label4, "Phone:", lx2, 36, lw, txtDim);
            UT(this.txtPhone, ix2, 34, iw, inputBg, txtMain, 4);

            UL(this.label3, "Role:", lx2, 76, lw, txtDim);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbRole.BackColor = inputBg;
            this.cmbRole.ForeColor = txtMain;
            this.cmbRole.Location = new System.Drawing.Point(ix2, 74);
            this.cmbRole.Size = new System.Drawing.Size(iw, 28);
            this.cmbRole.TabIndex = 5;

            this.pnlForm.Controls.Add(this.lblFormSection);
            this.pnlForm.Controls.Add(this.label1);
            this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.label2);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.label5);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.label4);
            this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Controls.Add(this.cmbRole);

            // ── pnlButtons ────────────────────────────────────────────
            this.pnlButtons.BackColor = Color.FromArgb(28, 28, 28);
            this.pnlButtons.Location = new System.Drawing.Point(16, 519);
            this.pnlButtons.Size = new System.Drawing.Size(764, 56);

            int bx = 14, bw = 130, bh = 36, bgap = 14;
            UB(this.btnAdd, "➕  Add User", bx, 10, bw, bh, blue);
            UB(this.btnUpdate, "✏  Update", bx + bw + bgap, 10, bw, bh, orange);
            UB(this.btnDelete, "🗑  Delete", bx + (bw + bgap) * 2, 10, bw, bh, red);
            UB(this.btnClear, "✕  Clear", bx + (bw + bgap) * 3, 10, bw, bh, gray);

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear
            });

            // ── Form ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = bg;
            this.ForeColor = txtMain;
            this.ClientSize = new System.Drawing.Size(796, 592);
            this.MinimumSize = new System.Drawing.Size(796, 592);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "frmManageUsers";
            this.Text = "Manage Users — CourierDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManageUsers_Load);

            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTop);   // Dock=Top last

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Helpers ───────────────────────────────────────────────────
        private void UL(System.Windows.Forms.Label lbl,
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

        private void UT(System.Windows.Forms.TextBox txt,
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

        private void UB(System.Windows.Forms.Button btn,
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

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormSection;
        private System.Windows.Forms.Panel pnlButtons;
    }
}





//namespace CourierDB.UI
//{
//    partial class frmManageUsers
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
//            this.dgvUsers = new System.Windows.Forms.DataGridView();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.txtName = new System.Windows.Forms.TextBox();
//            this.txtEmail = new System.Windows.Forms.TextBox();
//            this.txtPassword = new System.Windows.Forms.TextBox();
//            this.txtPhone = new System.Windows.Forms.TextBox();
//            this.cmbRole = new System.Windows.Forms.ComboBox();
//            this.btnAdd = new System.Windows.Forms.Button();
//            this.btnUpdate = new System.Windows.Forms.Button();
//            this.btnDelete = new System.Windows.Forms.Button();
//            this.btnClear = new System.Windows.Forms.Button();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
//            this.SuspendLayout();

//            // dgvUsers — top left, shows all users
//            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvUsers.Location = new System.Drawing.Point(20, 20);
//            this.dgvUsers.Name = "dgvUsers";
//            this.dgvUsers.RowHeadersWidth = 62;
//            this.dgvUsers.RowTemplate.Height = 28;
//            this.dgvUsers.Size = new System.Drawing.Size(500, 180);
//            this.dgvUsers.TabIndex = 0;
//            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);

//            // label1 — Name
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(20, 220);
//            this.label1.Name = "label1";
//            this.label1.Text = "Name:";

//            // txtName
//            this.txtName.Location = new System.Drawing.Point(130, 217);
//            this.txtName.Name = "txtName";
//            this.txtName.Size = new System.Drawing.Size(200, 26);
//            this.txtName.TabIndex = 1;

//            // label2 — Email
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(20, 260);
//            this.label2.Name = "label2";
//            this.label2.Text = "Email:";

//            // txtEmail
//            this.txtEmail.Location = new System.Drawing.Point(130, 257);
//            this.txtEmail.Name = "txtEmail";
//            this.txtEmail.Size = new System.Drawing.Size(200, 26);
//            this.txtEmail.TabIndex = 2;

//            // label5 — Password
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(20, 300);
//            this.label5.Name = "label5";
//            this.label5.Text = "Password:";

//            // txtPassword
//            this.txtPassword.Location = new System.Drawing.Point(130, 297);
//            this.txtPassword.Name = "txtPassword";
//            this.txtPassword.PasswordChar = '*';
//            this.txtPassword.Size = new System.Drawing.Size(200, 26);
//            this.txtPassword.TabIndex = 3;

//            // label4 — Phone
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(20, 340);
//            this.label4.Name = "label4";
//            this.label4.Text = "Phone:";

//            // txtPhone
//            this.txtPhone.Location = new System.Drawing.Point(130, 337);
//            this.txtPhone.Name = "txtPhone";
//            this.txtPhone.Size = new System.Drawing.Size(200, 26);
//            this.txtPhone.TabIndex = 4;

//            // label3 — Role
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(20, 380);
//            this.label3.Name = "label3";
//            this.label3.Text = "Role:";

//            // cmbRole
//            this.cmbRole.FormattingEnabled = true;
//            this.cmbRole.Location = new System.Drawing.Point(130, 377);
//            this.cmbRole.Name = "cmbRole";
//            this.cmbRole.Size = new System.Drawing.Size(200, 28);
//            this.cmbRole.TabIndex = 5;

//            // btnAdd
//            this.btnAdd.Location = new System.Drawing.Point(560, 220);
//            this.btnAdd.Name = "btnAdd";
//            this.btnAdd.Size = new System.Drawing.Size(120, 38);
//            this.btnAdd.Text = "Add User";
//            this.btnAdd.UseVisualStyleBackColor = true;
//            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

//            // btnUpdate
//            this.btnUpdate.Location = new System.Drawing.Point(560, 270);
//            this.btnUpdate.Name = "btnUpdate";
//            this.btnUpdate.Size = new System.Drawing.Size(120, 38);
//            this.btnUpdate.Text = "Update";
//            this.btnUpdate.UseVisualStyleBackColor = true;
//            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

//            // btnDelete
//            this.btnDelete.Location = new System.Drawing.Point(560, 320);
//            this.btnDelete.Name = "btnDelete";
//            this.btnDelete.Size = new System.Drawing.Size(120, 38);
//            this.btnDelete.Text = "Delete";
//            this.btnDelete.UseVisualStyleBackColor = true;
//            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

//            // btnClear
//            this.btnClear.Location = new System.Drawing.Point(560, 370);
//            this.btnClear.Name = "btnClear";
//            this.btnClear.Size = new System.Drawing.Size(120, 38);
//            this.btnClear.Text = "Clear";
//            this.btnClear.UseVisualStyleBackColor = true;
//            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

//            // frmManageUsers
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(730, 450);
//            this.Controls.Add(this.dgvUsers);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.txtName);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.txtEmail);
//            this.Controls.Add(this.label5);
//            this.Controls.Add(this.txtPassword);
//            this.Controls.Add(this.label4);
//            this.Controls.Add(this.txtPhone);
//            this.Controls.Add(this.label3);
//            this.Controls.Add(this.cmbRole);
//            this.Controls.Add(this.btnAdd);
//            this.Controls.Add(this.btnUpdate);
//            this.Controls.Add(this.btnDelete);
//            this.Controls.Add(this.btnClear);
//            this.Name = "frmManageUsers";
//            this.Text = "Manage Users";
//            this.Load += new System.EventHandler(this.frmManageUsers_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        #endregion

//        private System.Windows.Forms.DataGridView dgvUsers;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.TextBox txtName;
//        private System.Windows.Forms.TextBox txtEmail;
//        private System.Windows.Forms.TextBox txtPassword;
//        private System.Windows.Forms.TextBox txtPhone;
//        private System.Windows.Forms.ComboBox cmbRole;
//        private System.Windows.Forms.Button btnAdd;
//        private System.Windows.Forms.Button btnUpdate;
//        private System.Windows.Forms.Button btnDelete;
//        private System.Windows.Forms.Button btnClear;
//    }
//}