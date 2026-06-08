using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    partial class frmManageParcel
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
            // ── Colors (matches frmDashboard exactly) ─────────────────
            Color bg = Color.FromArgb(18, 18, 18);
            Color sidebar = Color.FromArgb(28, 28, 28);
            Color card = Color.FromArgb(38, 38, 38);
            Color header = Color.FromArgb(24, 24, 24);
            Color gridBg = Color.FromArgb(32, 32, 32);
            Color gridAlt = Color.FromArgb(36, 36, 36);
            Color accent = Color.FromArgb(230, 180, 80);
            Color txtMain = Color.FromArgb(240, 240, 240);
            Color txtDim = Color.FromArgb(160, 160, 160);
            Color border = Color.FromArgb(60, 60, 60);
            Color inputBg = Color.FromArgb(30, 30, 30);
            Color grpFg = Color.FromArgb(230, 180, 80);   // gold for group headers

            this.dgvparcel = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpAddParcel = new System.Windows.Forms.GroupBox();
            this.lblParcelID = new System.Windows.Forms.Label();
            this.txtParcelID = new System.Windows.Forms.TextBox();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.lblReceiverName = new System.Windows.Forms.Label();
            this.txtReceiverName = new System.Windows.Forms.TextBox();
            this.lblReceiverPhone = new System.Windows.Forms.Label();
            this.txtReceiverPhone = new System.Windows.Forms.TextBox();
            this.lblReceiverCity = new System.Windows.Forms.Label();
            this.txtReceiverCity = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblParcelType = new System.Windows.Forms.Label();
            this.cmbParcelType = new System.Windows.Forms.ComboBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.lblTrackingCode = new System.Windows.Forms.Label();
            this.txtTrackingCode = new System.Windows.Forms.TextBox();
            this.btnAddParcel = new System.Windows.Forms.Button();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.lblStatusAction = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnMarkDelivered = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblSelectedInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvparcel)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpAddParcel.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop ────────────────────────────────────────────────
            this.pnlTop.BackColor = header;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "📦  Manage Parcels";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = txtMain;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

            // ── dgvparcel ─────────────────────────────────────────────
            this.dgvparcel.AllowUserToAddRows = false;
            this.dgvparcel.AllowUserToDeleteRows = false;
            this.dgvparcel.ReadOnly = true;
            this.dgvparcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvparcel.MultiSelect = false;
            this.dgvparcel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvparcel.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvparcel.RowTemplate.Height = 30;
            this.dgvparcel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvparcel.BackgroundColor = gridBg;
            this.dgvparcel.GridColor = border;
            this.dgvparcel.EnableHeadersVisualStyles = false;
            this.dgvparcel.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // Header
            this.dgvparcel.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.dgvparcel.ColumnHeadersDefaultCellStyle.ForeColor = accent;
            this.dgvparcel.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            // Rows
            this.dgvparcel.DefaultCellStyle.BackColor = gridBg;
            this.dgvparcel.DefaultCellStyle.ForeColor = txtMain;
            this.dgvparcel.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 80);
            this.dgvparcel.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvparcel.AlternatingRowsDefaultCellStyle.BackColor = gridAlt;

            this.dgvparcel.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvparcel.Location = new System.Drawing.Point(16, 71);
            this.dgvparcel.Size = new System.Drawing.Size(650, 500);
            this.dgvparcel.TabIndex = 0;
            this.dgvparcel.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvparcel_CellClick);

            // ── pnlRight ──────────────────────────────────────────────
            this.pnlRight.BackColor = sidebar;
            this.pnlRight.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Right;
            this.pnlRight.Location = new System.Drawing.Point(682, 55);
            this.pnlRight.Size = new System.Drawing.Size(358, 589);

            // ── grpAddParcel ──────────────────────────────────────────
            this.grpAddParcel.Text = "Add New Parcel";
            this.grpAddParcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpAddParcel.ForeColor = grpFg;
            this.grpAddParcel.BackColor = card;
            this.grpAddParcel.Location = new System.Drawing.Point(10, 10);
            this.grpAddParcel.Size = new System.Drawing.Size(336, 400);

            int lx = 10, tx = 136, tw = 184, lh = 22, th = 26, gap = 36;
            int y = 26;

            SetLabel(this.lblParcelID, "Parcel ID:", lx, y, lh, txtDim);
            SetTextBox(this.txtParcelID, tx, y, tw, th, 0, inputBg, txtMain);
            y += gap;

            SetLabel(this.lblSenderName, "Sender Name:", lx, y, lh, txtMain);
            SetTextBox(this.txtSenderName, tx, y, tw, th, 1, inputBg, txtMain);
            this.txtSenderName.TextChanged += new System.EventHandler(this.txtSenderName_TextChanged);
            y += gap;

            SetLabel(this.lblReceiverName, "Receiver Name:", lx, y, lh, txtMain);
            SetTextBox(this.txtReceiverName, tx, y, tw, th, 2, inputBg, txtMain);
            this.txtReceiverName.TextChanged += new System.EventHandler(this.txtReceiverName_TextChanged);
            y += gap;

            SetLabel(this.lblReceiverPhone, "Receiver Phone:", lx, y, lh, txtMain);
            SetTextBox(this.txtReceiverPhone, tx, y, tw, th, 3, inputBg, txtMain);
            this.txtReceiverPhone.TextChanged += new System.EventHandler(this.txtReceiverPhone_TextChanged);
            y += gap;

            SetLabel(this.lblReceiverCity, "Receiver City:", lx, y, lh, txtMain);
            SetTextBox(this.txtReceiverCity, tx, y, tw, th, 4, inputBg, txtMain);
            this.txtReceiverCity.TextChanged += new System.EventHandler(this.txtReceiverCity_TextChanged);
            y += gap;

            SetLabel(this.lblWeight, "Weight (kg):", lx, y, lh, txtMain);
            SetTextBox(this.txtWeight, tx, y, tw, th, 5, inputBg, txtMain);
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            y += gap;

            SetLabel(this.lblParcelType, "Parcel Type:", lx, y, lh, txtMain);
            SetCombo(this.cmbParcelType, tx, y, tw, th, 6, inputBg, txtMain);
            this.cmbParcelType.SelectedIndexChanged += new System.EventHandler(this.cmbParcelType_SelectedIndexChanged);
            y += gap;

            SetLabel(this.lblZone, "Delivery Zone:", lx, y, lh, txtMain);
            SetCombo(this.cmbZone, tx, y, tw, th, 7, inputBg, txtMain);
            this.cmbZone.SelectedIndexChanged += new System.EventHandler(this.cmbZone_SelectedIndexChanged);
            y += gap;

            SetLabel(this.lblTrackingCode, "Tracking Code:", lx, y, lh, accent);
            SetTextBox(this.txtTrackingCode, tx, y, tw, th, 8, Color.FromArgb(28, 26, 20), accent);
            this.txtTrackingCode.ReadOnly = true;
            this.txtTrackingCode.TextChanged += new System.EventHandler(this.txtTrackingCode_TextChanged);
            y += gap;

            // btnAddParcel
            this.btnAddParcel.BackColor = accent;
            this.btnAddParcel.ForeColor = Color.FromArgb(18, 18, 18);
            this.btnAddParcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddParcel.FlatAppearance.BorderSize = 0;
            this.btnAddParcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddParcel.Location = new System.Drawing.Point(10, y + 4);
            this.btnAddParcel.Size = new System.Drawing.Size(314, 36);
            this.btnAddParcel.Text = "📦  Book Parcel";
            this.btnAddParcel.UseVisualStyleBackColor = false;
            this.btnAddParcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddParcel.Click += new System.EventHandler(this.btnAddParcel_Click);

            // Wire all controls into grpAddParcel
            this.grpAddParcel.Controls.Add(this.lblParcelID);
            this.grpAddParcel.Controls.Add(this.txtParcelID);
            this.grpAddParcel.Controls.Add(this.lblSenderName);
            this.grpAddParcel.Controls.Add(this.txtSenderName);
            this.grpAddParcel.Controls.Add(this.lblReceiverName);
            this.grpAddParcel.Controls.Add(this.txtReceiverName);
            this.grpAddParcel.Controls.Add(this.lblReceiverPhone);
            this.grpAddParcel.Controls.Add(this.txtReceiverPhone);
            this.grpAddParcel.Controls.Add(this.lblReceiverCity);
            this.grpAddParcel.Controls.Add(this.txtReceiverCity);
            this.grpAddParcel.Controls.Add(this.lblWeight);
            this.grpAddParcel.Controls.Add(this.txtWeight);
            this.grpAddParcel.Controls.Add(this.lblParcelType);
            this.grpAddParcel.Controls.Add(this.cmbParcelType);
            this.grpAddParcel.Controls.Add(this.lblZone);
            this.grpAddParcel.Controls.Add(this.cmbZone);
            this.grpAddParcel.Controls.Add(this.lblTrackingCode);
            this.grpAddParcel.Controls.Add(this.txtTrackingCode);
            this.grpAddParcel.Controls.Add(this.btnAddParcel);

            // ── grpActions ────────────────────────────────────────────
            this.grpActions.Text = "Update Selected Parcel";
            this.grpActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpActions.ForeColor = grpFg;
            this.grpActions.BackColor = card;
            this.grpActions.Location = new System.Drawing.Point(10, 420);
            this.grpActions.Size = new System.Drawing.Size(336, 130);

            this.lblStatusAction.AutoSize = false;
            this.lblStatusAction.Location = new System.Drawing.Point(10, 32);
            this.lblStatusAction.Size = new System.Drawing.Size(118, 26);
            this.lblStatusAction.Text = "New Status:";
            this.lblStatusAction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusAction.ForeColor = txtMain;
            this.lblStatusAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            SetCombo(this.cmbStatus, 136, 30, 188, 26, 10, inputBg, txtMain);
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);

            this.btnUpdateStatus.BackColor = Color.FromArgb(100, 130, 220);
            this.btnUpdateStatus.ForeColor = Color.White;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStatus.Location = new System.Drawing.Point(10, 72);
            this.btnUpdateStatus.Size = new System.Drawing.Size(152, 36);
            this.btnUpdateStatus.Text = "✔  Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            this.btnMarkDelivered.BackColor = Color.FromArgb(90, 180, 130);
            this.btnMarkDelivered.ForeColor = Color.White;
            this.btnMarkDelivered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkDelivered.FlatAppearance.BorderSize = 0;
            this.btnMarkDelivered.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMarkDelivered.Location = new System.Drawing.Point(172, 72);
            this.btnMarkDelivered.Size = new System.Drawing.Size(152, 36);
            this.btnMarkDelivered.Text = "🚚  Mark Delivered";
            this.btnMarkDelivered.UseVisualStyleBackColor = false;
            this.btnMarkDelivered.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkDelivered.Click += new System.EventHandler(this.btnMarkDelivered_Click);

            this.grpActions.Controls.Add(this.lblStatusAction);
            this.grpActions.Controls.Add(this.cmbStatus);
            this.grpActions.Controls.Add(this.btnUpdateStatus);
            this.grpActions.Controls.Add(this.btnMarkDelivered);

            this.pnlRight.Controls.Add(this.grpAddParcel);
            this.pnlRight.Controls.Add(this.grpActions);

            // ── pnlBottom ─────────────────────────────────────────────
            this.pnlBottom.BackColor = card;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 56;
            this.pnlBottom.Controls.Add(this.lblSelectedInfo);
            this.pnlBottom.Controls.Add(this.btnRefresh);

            this.lblSelectedInfo.AutoSize = false;
            this.lblSelectedInfo.Location = new System.Drawing.Point(16, 16);
            this.lblSelectedInfo.Size = new System.Drawing.Size(560, 24);
            this.lblSelectedInfo.Text = "No parcel selected";
            this.lblSelectedInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSelectedInfo.ForeColor = txtDim;

            this.btnRefresh.BackColor = Color.FromArgb(90, 180, 130);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Anchor =
                System.Windows.Forms.AnchorStyles.Right |
                System.Windows.Forms.AnchorStyles.Top;
            this.btnRefresh.Location = new System.Drawing.Point(910, 10);
            this.btnRefresh.Size = new System.Drawing.Size(120, 36);
            this.btnRefresh.Text = "⟳  Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── frmManageParcel ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = bg;
            this.ForeColor = txtMain;
            this.ClientSize = new System.Drawing.Size(1050, 644);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "frmManageParcel";
            this.Text = "Manage Parcels — CourierDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.dgvparcel);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);

            this.Load += new System.EventHandler(this.frmManageParcel_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvparcel)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.grpAddParcel.ResumeLayout(false);
            this.grpActions.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Helpers ───────────────────────────────────────────────────
        private void SetLabel(System.Windows.Forms.Label lbl,
            string text, int x, int y, int h, Color fg)
        {
            lbl.AutoSize = false;
            lbl.Location = new System.Drawing.Point(x, y + 2);
            lbl.Size = new System.Drawing.Size(120, h);
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = fg;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void SetTextBox(System.Windows.Forms.TextBox txt,
            int x, int y, int w, int h, int tab, Color bg, Color fg)
        {
            txt.Location = new System.Drawing.Point(x, y);
            txt.Size = new System.Drawing.Size(w, h);
            txt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txt.BackColor = bg;
            txt.ForeColor = fg;
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.TabIndex = tab;
        }

        private void SetCombo(System.Windows.Forms.ComboBox cmb,
            int x, int y, int w, int h, int tab, Color bg, Color fg)
        {
            cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmb.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cmb.BackColor = bg;
            cmb.ForeColor = fg;
            cmb.Location = new System.Drawing.Point(x, y);
            cmb.Size = new System.Drawing.Size(w, h);
            cmb.TabIndex = tab;
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvparcel;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpAddParcel;
        private System.Windows.Forms.Label lblParcelID;
        private System.Windows.Forms.TextBox txtParcelID;
        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.Label lblReceiverName;
        private System.Windows.Forms.TextBox txtReceiverName;
        private System.Windows.Forms.Label lblReceiverPhone;
        private System.Windows.Forms.TextBox txtReceiverPhone;
        private System.Windows.Forms.Label lblReceiverCity;
        private System.Windows.Forms.TextBox txtReceiverCity;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblParcelType;
        private System.Windows.Forms.ComboBox cmbParcelType;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Label lblTrackingCode;
        private System.Windows.Forms.TextBox txtTrackingCode;
        private System.Windows.Forms.Button btnAddParcel;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Label lblStatusAction;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnMarkDelivered;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblSelectedInfo;
        private System.Windows.Forms.Button btnRefresh;
    }
}

//namespace CourierDB.UI
//{
//    partial class frmManageParcel
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
//            // ── Controls declaration ──────────────────────────────────
//            this.dgvparcel = new System.Windows.Forms.DataGridView();
//            this.pnlTop = new System.Windows.Forms.Panel();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.pnlRight = new System.Windows.Forms.Panel();
//            this.grpAddParcel = new System.Windows.Forms.GroupBox();
//            this.lblParcelID = new System.Windows.Forms.Label();
//            this.txtParcelID = new System.Windows.Forms.TextBox();
//            this.lblSenderName = new System.Windows.Forms.Label();
//            this.txtSenderName = new System.Windows.Forms.TextBox();
//            this.lblReceiverName = new System.Windows.Forms.Label();
//            this.txtReceiverName = new System.Windows.Forms.TextBox();
//            this.lblReceiverPhone = new System.Windows.Forms.Label();
//            this.txtReceiverPhone = new System.Windows.Forms.TextBox();
//            this.lblReceiverCity = new System.Windows.Forms.Label();
//            this.txtReceiverCity = new System.Windows.Forms.TextBox();
//            this.lblWeight = new System.Windows.Forms.Label();
//            this.txtWeight = new System.Windows.Forms.TextBox();
//            this.lblParcelType = new System.Windows.Forms.Label();
//            this.cmbParcelType = new System.Windows.Forms.ComboBox();
//            this.lblZone = new System.Windows.Forms.Label();
//            this.cmbZone = new System.Windows.Forms.ComboBox();
//            this.lblTrackingCode = new System.Windows.Forms.Label();
//            this.txtTrackingCode = new System.Windows.Forms.TextBox();
//            this.btnAddParcel = new System.Windows.Forms.Button();
//            this.grpActions = new System.Windows.Forms.GroupBox();
//            this.lblStatusAction = new System.Windows.Forms.Label();
//            this.cmbStatus = new System.Windows.Forms.ComboBox();
//            this.btnUpdateStatus = new System.Windows.Forms.Button();
//            this.btnMarkDelivered = new System.Windows.Forms.Button();
//            this.pnlBottom = new System.Windows.Forms.Panel();
//            this.lblSelectedInfo = new System.Windows.Forms.Label();
//            this.btnRefresh = new System.Windows.Forms.Button();

//            ((System.ComponentModel.ISupportInitialize)(this.dgvparcel)).BeginInit();
//            this.pnlTop.SuspendLayout();
//            this.pnlRight.SuspendLayout();
//            this.grpAddParcel.SuspendLayout();
//            this.grpActions.SuspendLayout();
//            this.pnlBottom.SuspendLayout();
//            this.SuspendLayout();

//            // ── pnlTop ────────────────────────────────────────────────
//            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 40, 90);
//            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
//            this.pnlTop.Height = 64;
//            this.pnlTop.Controls.Add(this.lblTitle);

//            this.lblTitle.AutoSize = false;
//            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.lblTitle.Text = "📦  Manage parcel";
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F,
//                System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = System.Drawing.Color.White;
//            this.lblTitle.TextAlign =
//                System.Drawing.ContentAlignment.MiddleLeft;
//            this.lblTitle.Padding =
//                new System.Windows.Forms.Padding(18, 0, 0, 0);

//            // ── dgvparcel ────────────────────────────────────────────
//            this.dgvparcel.AllowUserToAddRows = false;
//            this.dgvparcel.AllowUserToDeleteRows = false;
//            this.dgvparcel.ReadOnly = true;
//            this.dgvparcel.SelectionMode =
//                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvparcel.MultiSelect = false;
//            this.dgvparcel.AutoSizeColumnsMode =
//                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvparcel.ColumnHeadersHeightSizeMode =
//                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvparcel.RowTemplate.Height = 30;
//            this.dgvparcel.BorderStyle =
//                System.Windows.Forms.BorderStyle.None;
//            this.dgvparcel.BackgroundColor = System.Drawing.Color.White;
//            this.dgvparcel.GridColor =
//                System.Drawing.Color.FromArgb(220, 225, 235);

//            // Header style
//            this.dgvparcel.ColumnHeadersDefaultCellStyle.BackColor =
//                System.Drawing.Color.FromArgb(15, 40, 90);
//            this.dgvparcel.ColumnHeadersDefaultCellStyle.ForeColor =
//                System.Drawing.Color.White;
//            this.dgvparcel.ColumnHeadersDefaultCellStyle.Font =
//                new System.Drawing.Font("Segoe UI", 9.5F,
//                System.Drawing.FontStyle.Bold);
//            this.dgvparcel.EnableHeadersVisualStyles = false;

//            // Row styles
//            this.dgvparcel.DefaultCellStyle.Font =
//                new System.Drawing.Font("Segoe UI", 9.5F);
//            this.dgvparcel.DefaultCellStyle.SelectionBackColor =
//                System.Drawing.Color.FromArgb(50, 100, 200);
//            this.dgvparcel.DefaultCellStyle.SelectionForeColor =
//                System.Drawing.Color.White;
//            this.dgvparcel.AlternatingRowsDefaultCellStyle.BackColor =
//                System.Drawing.Color.FromArgb(240, 245, 255);

//            // Position — fills left area
//            this.dgvparcel.Anchor =
//                System.Windows.Forms.AnchorStyles.Top |
//                System.Windows.Forms.AnchorStyles.Bottom |
//                System.Windows.Forms.AnchorStyles.Left |
//                System.Windows.Forms.AnchorStyles.Right;
//            this.dgvparcel.Location = new System.Drawing.Point(16, 80);
//            this.dgvparcel.Size = new System.Drawing.Size(660, 500);
//            this.dgvparcel.TabIndex = 0;
//            this.dgvparcel.CellClick +=
//                new System.Windows.Forms.DataGridViewCellEventHandler(
//                this.dgvparcel_CellClick);

//            // ── pnlRight (side panel with all inputs) ─────────────────
//            this.pnlRight.BackColor =
//                System.Drawing.Color.FromArgb(245, 247, 252);
//            this.pnlRight.Anchor =
//                System.Windows.Forms.AnchorStyles.Top |
//                System.Windows.Forms.AnchorStyles.Bottom |
//                System.Windows.Forms.AnchorStyles.Right;
//            this.pnlRight.Location = new System.Drawing.Point(692, 64);
//            this.pnlRight.Size = new System.Drawing.Size(330, 580);

//            // ── grpAddParcel ──────────────────────────────────────────
//            this.grpAddParcel.Text = "Add New Parcel";
//            this.grpAddParcel.Font = new System.Drawing.Font(
//                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.grpAddParcel.ForeColor =
//                System.Drawing.Color.FromArgb(15, 40, 90);
//            this.grpAddParcel.Location =
//                new System.Drawing.Point(10, 8);
//            this.grpAddParcel.Size =
//                new System.Drawing.Size(310, 390);

//            int lx = 10, tx = 130, tw = 164, lh = 22, th = 28, gap = 38;
//            int y = 24;

//            // Parcel ID (read only)
//            SetLabel(this.lblParcelID, "Parcel ID:", lx, y, lh);
//            SetTextBox(this.txtParcelID, tx, y, tw, th, 0);
//            y += gap;

//            // Sender Name
//            SetLabel(this.lblSenderName, "Sender Name:", lx, y, lh);
//            SetTextBox(this.txtSenderName, tx, y, tw, th, 1);
//            this.txtSenderName.TextChanged +=
//                new System.EventHandler(this.txtSenderName_TextChanged);
//            y += gap;

//            // Receiver Name
//            SetLabel(this.lblReceiverName, "Receiver Name:", lx, y, lh);
//            SetTextBox(this.txtReceiverName, tx, y, tw, th, 2);
//            this.txtReceiverName.TextChanged +=
//                new System.EventHandler(this.txtReceiverName_TextChanged);
//            y += gap;

//            // Receiver Phone
//            SetLabel(this.lblReceiverPhone, "Receiver Phone:", lx, y, lh);
//            SetTextBox(this.txtReceiverPhone, tx, y, tw, th, 3);
//            this.txtReceiverPhone.TextChanged +=
//                new System.EventHandler(this.txtReceiverPhone_TextChanged);
//            y += gap;

//            // Receiver City
//            SetLabel(this.lblReceiverCity, "Receiver City:", lx, y, lh);
//            SetTextBox(this.txtReceiverCity, tx, y, tw, th, 4);
//            this.txtReceiverCity.TextChanged +=
//                new System.EventHandler(this.txtReceiverCity_TextChanged);
//            y += gap;

//            // Weight
//            SetLabel(this.lblWeight, "Weight (kg):", lx, y, lh);
//            SetTextBox(this.txtWeight, tx, y, tw, th, 5);
//            this.txtWeight.TextChanged +=
//                new System.EventHandler(this.txtWeight_TextChanged);
//            y += gap;

//            // Parcel Type
//            SetLabel(this.lblParcelType, "Parcel Type:", lx, y, lh);
//            this.cmbParcelType.DropDownStyle =
//                System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbParcelType.FlatStyle =
//                System.Windows.Forms.FlatStyle.Flat;
//            this.cmbParcelType.Font =
//                new System.Drawing.Font("Segoe UI", 9.5F);
//            this.cmbParcelType.Location =
//                new System.Drawing.Point(tx, y);
//            this.cmbParcelType.Size = new System.Drawing.Size(tw, th);
//            this.cmbParcelType.TabIndex = 6;
//            this.cmbParcelType.SelectedIndexChanged +=
//                new System.EventHandler(
//                this.cmbParcelType_SelectedIndexChanged);
//            y += gap;

//            // Zone
//            SetLabel(this.lblZone, "Delivery Zone:", lx, y, lh);
//            this.cmbZone.DropDownStyle =
//                System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbZone.FlatStyle =
//                System.Windows.Forms.FlatStyle.Flat;
//            this.cmbZone.Font =
//                new System.Drawing.Font("Segoe UI", 9.5F);
//            this.cmbZone.Location = new System.Drawing.Point(tx, y);
//            this.cmbZone.Size = new System.Drawing.Size(tw, th);
//            this.cmbZone.TabIndex = 7;
//            this.cmbZone.SelectedIndexChanged +=
//                new System.EventHandler(
//                this.cmbZone_SelectedIndexChanged);
//            y += gap;

//            // Tracking Code (auto-generated, readonly)
//            SetLabel(this.lblTrackingCode, "Tracking Code:", lx, y, lh);
//            SetTextBox(this.txtTrackingCode, tx, y, tw, th, 8);
//            this.txtTrackingCode.ReadOnly = true;
//            this.txtTrackingCode.BackColor =
//                System.Drawing.Color.FromArgb(235, 240, 255);
//            this.txtTrackingCode.TextChanged +=
//                new System.EventHandler(this.txtTrackingCode_TextChanged);
//            y += gap;

//            // Add button
//            this.btnAddParcel.BackColor =
//                System.Drawing.Color.FromArgb(15, 40, 90);
//            this.btnAddParcel.ForeColor = System.Drawing.Color.White;
//            this.btnAddParcel.FlatStyle =
//                System.Windows.Forms.FlatStyle.Flat;
//            this.btnAddParcel.FlatAppearance.BorderSize = 0;
//            this.btnAddParcel.Font = new System.Drawing.Font(
//                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
//            this.btnAddParcel.Location = new System.Drawing.Point(10, y);
//            this.btnAddParcel.Size = new System.Drawing.Size(290, 38);
//            this.btnAddParcel.TabIndex = 9;
//            this.btnAddParcel.Text = "📦  Book Parcel";
//            this.btnAddParcel.UseVisualStyleBackColor = false;
//            this.btnAddParcel.Cursor =
//                System.Windows.Forms.Cursors.Hand;
//            this.btnAddParcel.Click +=
//                new System.EventHandler(this.btnAddParcel_Click);

//            // Add controls to grpAddParcel
//            this.grpAddParcel.Controls.Add(this.lblParcelID);
//            this.grpAddParcel.Controls.Add(this.txtParcelID);
//            this.grpAddParcel.Controls.Add(this.lblSenderName);
//            this.grpAddParcel.Controls.Add(this.txtSenderName);
//            this.grpAddParcel.Controls.Add(this.lblReceiverName);
//            this.grpAddParcel.Controls.Add(this.txtReceiverName);
//            this.grpAddParcel.Controls.Add(this.lblReceiverPhone);
//            this.grpAddParcel.Controls.Add(this.txtReceiverPhone);
//            this.grpAddParcel.Controls.Add(this.lblReceiverCity);
//            this.grpAddParcel.Controls.Add(this.txtReceiverCity);
//            this.grpAddParcel.Controls.Add(this.lblWeight);
//            this.grpAddParcel.Controls.Add(this.txtWeight);
//            this.grpAddParcel.Controls.Add(this.lblParcelType);
//            this.grpAddParcel.Controls.Add(this.cmbParcelType);
//            this.grpAddParcel.Controls.Add(this.lblZone);
//            this.grpAddParcel.Controls.Add(this.cmbZone);
//            this.grpAddParcel.Controls.Add(this.lblTrackingCode);
//            this.grpAddParcel.Controls.Add(this.txtTrackingCode);
//            this.grpAddParcel.Controls.Add(this.btnAddParcel);

//            // ── grpActions ────────────────────────────────────────────
//            this.grpActions.Text = "Update Selected Parcel";
//            this.grpActions.Font = new System.Drawing.Font(
//                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.grpActions.ForeColor =
//                System.Drawing.Color.FromArgb(15, 40, 90);
//            this.grpActions.Location = new System.Drawing.Point(10, 406);
//            this.grpActions.Size = new System.Drawing.Size(310, 140);

//            // Status label + combo
//            this.lblStatusAction.AutoSize = false;
//            this.lblStatusAction.Location = new System.Drawing.Point(10, 30);
//            this.lblStatusAction.Size = new System.Drawing.Size(110, 26);
//            this.lblStatusAction.Text = "New Status:";
//            this.lblStatusAction.Font = new System.Drawing.Font(
//                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblStatusAction.ForeColor =
//                System.Drawing.Color.FromArgb(60, 60, 80);
//            this.lblStatusAction.TextAlign =
//                System.Drawing.ContentAlignment.MiddleRight;

//            this.cmbStatus.DropDownStyle =
//                System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbStatus.FlatStyle =
//                System.Windows.Forms.FlatStyle.Flat;
//            this.cmbStatus.Font =
//                new System.Drawing.Font("Segoe UI", 9.5F);
//            this.cmbStatus.Location = new System.Drawing.Point(128, 28);
//            this.cmbStatus.Size = new System.Drawing.Size(166, 28);
//            this.cmbStatus.TabIndex = 10;
//            this.cmbStatus.SelectedIndexChanged +=
//                new System.EventHandler(
//                this.cmbStatus_SelectedIndexChanged);

//            // Update Status button
//            this.btnUpdateStatus.BackColor =
//                System.Drawing.Color.FromArgb(30, 110, 200);
//            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
//            this.btnUpdateStatus.FlatStyle =
//                System.Windows.Forms.FlatStyle.Flat;
//            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
//            this.btnUpdateStatus.Font = new System.Drawing.Font(
//                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
//            this.btnUpdateStatus.Location =
//                new System.Drawing.Point(10, 68);
//            this.btnUpdateStatus.Size =
//                new System.Drawing.Size(140, 36);
//            this.btnUpdateStatus.TabIndex = 11;
//            this.btnUpdateStatus.Text = "✔  Update Status";
//            this.btnUpdateStatus.UseVisualStyleBackColor = false;
//            this.btnUpdateStatus.Cursor =
//                System.Windows.Forms.Cursors.Hand;
//            this.btnUpdateStatus.Click +=
//                new System.EventHandler(this.btnUpdateStatus_Click);

//            // Mark Delivered button
//            this.btnMarkDelivered.BackColor =
//                System.Drawing.Color.FromArgb(30, 140, 80);
//            this.btnMarkDelivered.ForeColor = System.Drawing.Color.White;
//            this.btnMarkDelivered.FlatStyle =
//                System.Windows.Forms.FlatStyle.Flat;
//            this.btnMarkDelivered.FlatAppearance.BorderSize = 0;
//            this.btnMarkDelivered.Font = new System.Drawing.Font(
//                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
//            this.btnMarkDelivered.Location =
//                new System.Drawing.Point(160, 68);
//            this.btnMarkDelivered.Size =
//                new System.Drawing.Size(140, 36);
//            this.btnMarkDelivered.TabIndex = 12;
//            this.btnMarkDelivered.Text = "🚚  Mark Delivered";
//            this.btnMarkDelivered.UseVisualStyleBackColor = false;
//            this.btnMarkDelivered.Cursor =
//                System.Windows.Forms.Cursors.Hand;
//            this.btnMarkDelivered.Click +=
//                new System.EventHandler(this.btnMarkDelivered_Click);

//            this.grpActions.Controls.Add(this.lblStatusAction);
//            this.grpActions.Controls.Add(this.cmbStatus);
//            this.grpActions.Controls.Add(this.btnUpdateStatus);
//            this.grpActions.Controls.Add(this.btnMarkDelivered);

//            // Add groups to pnlRight
//            this.pnlRight.Controls.Add(this.grpAddParcel);
//            this.pnlRight.Controls.Add(this.grpActions);

//            // ── pnlBottom ─────────────────────────────────────────────
//            this.pnlBottom.BackColor =
//                System.Drawing.Color.FromArgb(240, 242, 250);
//            this.pnlBottom.Dock =
//                System.Windows.Forms.DockStyle.Bottom;
//            this.pnlBottom.Height = 56;
//            this.pnlBottom.Controls.Add(this.lblSelectedInfo);
//            this.pnlBottom.Controls.Add(this.btnRefresh);

//            this.lblSelectedInfo.AutoSize = false;
//            this.lblSelectedInfo.Location =
//                new System.Drawing.Point(16, 16);
//            this.lblSelectedInfo.Size =
//                new System.Drawing.Size(580, 24);
//            this.lblSelectedInfo.Text = "No parcel selected";
//            this.lblSelectedInfo.Font = new System.Drawing.Font(
//                "Segoe UI", 9F,
//                System.Drawing.FontStyle.Italic);
//            this.lblSelectedInfo.ForeColor =
//                System.Drawing.Color.FromArgb(80, 80, 120);

//            this.btnRefresh.BackColor =
//                System.Drawing.Color.FromArgb(60, 160, 110);
//            this.btnRefresh.ForeColor = System.Drawing.Color.White;
//            this.btnRefresh.FlatStyle =
//                System.Windows.Forms.FlatStyle.Flat;
//            this.btnRefresh.FlatAppearance.BorderSize = 0;
//            this.btnRefresh.Font = new System.Drawing.Font(
//                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
//            this.btnRefresh.Anchor =
//                System.Windows.Forms.AnchorStyles.Right |
//                System.Windows.Forms.AnchorStyles.Top;
//            this.btnRefresh.Location =
//                new System.Drawing.Point(900, 10);
//            this.btnRefresh.Size =
//                new System.Drawing.Size(120, 36);
//            this.btnRefresh.TabIndex = 13;
//            this.btnRefresh.Text = "⟳  Refresh";
//            this.btnRefresh.UseVisualStyleBackColor = false;
//            this.btnRefresh.Cursor =
//                System.Windows.Forms.Cursors.Hand;
//            this.btnRefresh.Click +=
//                new System.EventHandler(this.btnRefresh_Click);

//            // ── frmManageParcel ───────────────────────────────────────
//            this.AutoScaleDimensions =
//                new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode =
//                System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.White;
//            this.ClientSize = new System.Drawing.Size(1040, 644);
//            this.MinimumSize = new System.Drawing.Size(900, 600);
//            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            this.Name = "frmManageParcel";
//            this.Text =
//                "Manage parcel — Courier & Parcel Tracking System";
//            this.StartPosition =
//                System.Windows.Forms.FormStartPosition.CenterScreen;

//            this.Controls.Add(this.dgvparcel);
//            this.Controls.Add(this.pnlRight);
//            this.Controls.Add(this.pnlTop);
//            this.Controls.Add(this.pnlBottom);

//            // ── FIXED: Load event wired correctly ──
//            this.Load +=
//                new System.EventHandler(this.frmManageParcel_Load);

//            ((System.ComponentModel.ISupportInitialize)(this.dgvparcel)).EndInit();
//            this.pnlTop.ResumeLayout(false);
//            this.pnlRight.ResumeLayout(false);
//            this.grpAddParcel.ResumeLayout(false);
//            this.grpActions.ResumeLayout(false);
//            this.pnlBottom.ResumeLayout(false);
//            this.ResumeLayout(false);
//        }

//        // ── Helper to avoid repetition for label setup ──
//        private void SetLabel(System.Windows.Forms.Label lbl,
//            string text, int x, int y, int h)
//        {
//            lbl.AutoSize = false;
//            lbl.Location = new System.Drawing.Point(x, y + 3);
//            lbl.Size = new System.Drawing.Size(118, h);
//            lbl.Text = text;
//            lbl.Font = new System.Drawing.Font("Segoe UI", 9F,
//                System.Drawing.FontStyle.Bold);
//            lbl.ForeColor =
//                System.Drawing.Color.FromArgb(60, 60, 80);
//            lbl.TextAlign =
//                System.Drawing.ContentAlignment.MiddleRight;
//        }

//        // ── Helper to avoid repetition for textbox setup ──
//        private void SetTextBox(System.Windows.Forms.TextBox txt,
//            int x, int y, int w, int h, int tab)
//        {
//            txt.Location = new System.Drawing.Point(x, y);
//            txt.Size = new System.Drawing.Size(w, h);
//            txt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
//            txt.TabIndex = tab;
//        }

//        #endregion

//        private System.Windows.Forms.DataGridView dgvparcel;
//        private System.Windows.Forms.Panel pnlTop;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Panel pnlRight;
//        private System.Windows.Forms.GroupBox grpAddParcel;
//        private System.Windows.Forms.Label lblParcelID;
//        private System.Windows.Forms.TextBox txtParcelID;
//        private System.Windows.Forms.Label lblSenderName;
//        private System.Windows.Forms.TextBox txtSenderName;
//        private System.Windows.Forms.Label lblReceiverName;
//        private System.Windows.Forms.TextBox txtReceiverName;
//        private System.Windows.Forms.Label lblReceiverPhone;
//        private System.Windows.Forms.TextBox txtReceiverPhone;
//        private System.Windows.Forms.Label lblReceiverCity;
//        private System.Windows.Forms.TextBox txtReceiverCity;
//        private System.Windows.Forms.Label lblWeight;
//        private System.Windows.Forms.TextBox txtWeight;
//        private System.Windows.Forms.Label lblParcelType;
//        private System.Windows.Forms.ComboBox cmbParcelType;
//        private System.Windows.Forms.Label lblZone;
//        private System.Windows.Forms.ComboBox cmbZone;
//        private System.Windows.Forms.Label lblTrackingCode;
//        private System.Windows.Forms.TextBox txtTrackingCode;
//        private System.Windows.Forms.Button btnAddParcel;
//        private System.Windows.Forms.GroupBox grpActions;
//        private System.Windows.Forms.Label lblStatusAction;
//        private System.Windows.Forms.ComboBox cmbStatus;
//        private System.Windows.Forms.Button btnUpdateStatus;
//        private System.Windows.Forms.Button btnMarkDelivered;
//        private System.Windows.Forms.Panel pnlBottom;
//        private System.Windows.Forms.Label lblSelectedInfo;
//        private System.Windows.Forms.Button btnRefresh;
//    }
//}