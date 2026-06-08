using System.Drawing;

namespace CourierDB.UI
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);

            this.panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();

            // ── frmLogin ──────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login — CourierDB";
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Name = "frmLogin";
            this.MinimumSize = new System.Drawing.Size(800, 600);

            // ── panelCard  500 wide × 420 tall — compact, nothing cut ─
            // card is re-centred in code-behind on Resize
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Location = new System.Drawing.Point(350, 165);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(500, 380);
            this.panelCard.TabIndex = 0;

            // ── lblTitle  — full name fits at 20pt inside 500px card ──
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.None;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 55, 90);
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Size = new System.Drawing.Size(498, 40);          // full card width
            this.lblTitle.Text = "Welcome to Parcel Tracker";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblSubtitle ───────────────────────────────────────────
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(130, 140, 150);
            this.lblSubtitle.Location = new System.Drawing.Point(0, 76);
            this.lblSubtitle.Size = new System.Drawing.Size(498, 22);
            this.lblSubtitle.Text = "Sign in to manage and track your parcels";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // thin separator line drawn via padding trick — just a coloured panel
            // (no extra panel needed; the card border + vertical spacing is enough)

            // ── lblEmail ──────────────────────────────────────────────
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblEmail.Location = new System.Drawing.Point(50, 118);
            this.lblEmail.Text = "Email Address or Username";

            // ── txtEmail  ─────────────────────────────────────────────
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.txtEmail.Location = new System.Drawing.Point(50, 140);
            this.txtEmail.Size = new System.Drawing.Size(400, 28);
            this.txtEmail.TabIndex = 1;

            // ── lblPassword ───────────────────────────────────────────
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblPassword.Location = new System.Drawing.Point(50, 186);
            this.lblPassword.Text = "Password";

            // ── txtPassword ───────────────────────────────────────────
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.txtPassword.Location = new System.Drawing.Point(50, 208);
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(340, 28);   // leaves 46px for toggle btn
            this.txtPassword.TabIndex = 2;

            // ── btnTogglePassword  — 46px wide, exact same height as txtPassword ─
            this.btnTogglePassword.BackColor = System.Drawing.Color.FromArgb(235, 237, 240);
            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnTogglePassword.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnTogglePassword.Location = new System.Drawing.Point(390, 208);  // txtPassword.X + txtPassword.W
            this.btnTogglePassword.Size = new System.Drawing.Size(60, 28);     // same H as txtPassword
            this.btnTogglePassword.TabIndex = 3;
            this.btnTogglePassword.Text = "Show";
            this.btnTogglePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTogglePassword.UseVisualStyleBackColor = false;
            this.btnTogglePassword.Cursor = System.Windows.Forms.Cursors.Hand;

            // ── chkRemember ───────────────────────────────────────────
            this.chkRemember.AutoSize = true;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.chkRemember.Location = new System.Drawing.Point(50, 254);
            this.chkRemember.Text = "Remember me";
            this.chkRemember.TabIndex = 4;

            // ── lnkForgotPassword ─────────────────────────────────────
            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lnkForgotPassword.Location = new System.Drawing.Point(320, 256);
            this.lnkForgotPassword.Text = "Forgot Password?";
            this.lnkForgotPassword.TabIndex = 5;
            this.lnkForgotPassword.TabStop = true;

            // ── btnSignIn ─────────────────────────────────────────────
            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnSignIn.FlatAppearance.BorderSize = 0;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(50, 300);
            this.btnSignIn.Size = new System.Drawing.Size(400, 44);
            this.btnSignIn.TabIndex = 6;
            this.btnSignIn.Text = "SIGN IN";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;

            // ── errorProvider ─────────────────────────────────────────
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;

            // ── panelCard children ────────────────────────────────────
            this.panelCard.Controls.Add(this.lblTitle);
            this.panelCard.Controls.Add(this.lblSubtitle);
            this.panelCard.Controls.Add(this.lblEmail);
            this.panelCard.Controls.Add(this.txtEmail);
            this.panelCard.Controls.Add(this.lblPassword);
            this.panelCard.Controls.Add(this.txtPassword);
            this.panelCard.Controls.Add(this.btnTogglePassword);
            this.panelCard.Controls.Add(this.chkRemember);
            this.panelCard.Controls.Add(this.lnkForgotPassword);
            this.panelCard.Controls.Add(this.btnSignIn);

            this.Controls.Add(this.panelCard);

            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblTitle, lblSubtitle, lblEmail, lblPassword;
        private System.Windows.Forms.TextBox txtEmail, txtPassword;
        private System.Windows.Forms.Button btnTogglePassword, btnSignIn;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}


//using System.Drawing;

//namespace CourierDB.UI
//{
//    partial class frmLogin
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.panelCard = new System.Windows.Forms.Panel();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.lblSubtitle = new System.Windows.Forms.Label();
//            this.lblEmail = new System.Windows.Forms.Label();
//            this.txtEmail = new System.Windows.Forms.TextBox();
//            this.lblPassword = new System.Windows.Forms.Label();
//            this.txtPassword = new System.Windows.Forms.TextBox();
//            this.btnTogglePassword = new System.Windows.Forms.Button();
//            this.chkRemember = new System.Windows.Forms.CheckBox();
//            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
//            this.btnSignIn = new System.Windows.Forms.Button();
//            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);

//            this.panelCard.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
//            this.SuspendLayout();

//            // ── frmLogin ──────────────────────────────────────────────
//            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(1920, 1080);
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Login — CourierDB";
//            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
//            this.Name = "frmLogin";
//            this.MinimumSize = new System.Drawing.Size(900, 700);

//            // ── panelCard ─────────────────────────────────────────────
//            this.panelCard.BackColor = System.Drawing.Color.White;
//            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.panelCard.Location = new System.Drawing.Point(560, 90);
//            this.panelCard.Name = "panelCard";
//            this.panelCard.Size = new System.Drawing.Size(800, 680);
//            this.panelCard.TabIndex = 0;
//            this.panelCard.Anchor =
//                System.Windows.Forms.AnchorStyles.None;   // centred via Resize event in .cs

//            // ── lblTitle ──────────────────────────────────────────────
//            this.lblTitle.AutoSize = false;
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
//            this.lblTitle.Location = new System.Drawing.Point(50, 50);
//            this.lblTitle.Size = new System.Drawing.Size(700, 60);
//            this.lblTitle.Text = "Welcome to Parcel Tracker";
//            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

//            // ── lblSubtitle ───────────────────────────────────────────
//            this.lblSubtitle.AutoSize = false;
//            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 13F);
//            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
//            this.lblSubtitle.Location = new System.Drawing.Point(50, 118);
//            this.lblSubtitle.Size = new System.Drawing.Size(700, 30);
//            this.lblSubtitle.Text = "Sign in to manage and track your parcels";
//            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

//            // ── lblEmail ──────────────────────────────────────────────
//            this.lblEmail.AutoSize = true;
//            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
//            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
//            this.lblEmail.Location = new System.Drawing.Point(130, 185);
//            this.lblEmail.Text = "Email Address or Username";

//            // ── txtEmail ──────────────────────────────────────────────
//            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
//            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
//            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
//            this.txtEmail.Location = new System.Drawing.Point(130, 215);
//            this.txtEmail.Size = new System.Drawing.Size(540, 36);
//            this.txtEmail.TabIndex = 1;

//            // ── lblPassword ───────────────────────────────────────────
//            this.lblPassword.AutoSize = true;
//            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
//            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
//            this.lblPassword.Location = new System.Drawing.Point(130, 275);
//            this.lblPassword.Text = "Password";

//            // ── txtPassword ───────────────────────────────────────────
//            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
//            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
//            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
//            this.txtPassword.Location = new System.Drawing.Point(130, 305);
//            this.txtPassword.PasswordChar = '●';
//            this.txtPassword.Size = new System.Drawing.Size(500, 36);
//            this.txtPassword.TabIndex = 2;

//            // ── btnTogglePassword — FIX: plain ASCII text, proper size ─
//            // Using text "Show"/"Hide" avoids emoji rendering/clipping issues
//            this.btnTogglePassword.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
//            this.btnTogglePassword.FlatAppearance.BorderSize = 1;
//            this.btnTogglePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
//            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
//            this.btnTogglePassword.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
//            this.btnTogglePassword.Location = new System.Drawing.Point(634, 305);
//            this.btnTogglePassword.Size = new System.Drawing.Size(50, 36);   // matches txtPassword height
//            this.btnTogglePassword.TabIndex = 3;
//            this.btnTogglePassword.Text = "Show";
//            this.btnTogglePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            this.btnTogglePassword.UseVisualStyleBackColor = false;
//            this.btnTogglePassword.Cursor = System.Windows.Forms.Cursors.Hand;

//            // ── chkRemember ───────────────────────────────────────────
//            this.chkRemember.AutoSize = true;
//            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 11F);
//            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
//            this.chkRemember.Location = new System.Drawing.Point(130, 365);
//            this.chkRemember.Text = "Remember me";
//            this.chkRemember.TabIndex = 4;

//            // ── lnkForgotPassword ─────────────────────────────────────
//            this.lnkForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(41, 128, 185);
//            this.lnkForgotPassword.AutoSize = true;
//            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
//            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(52, 152, 219);
//            this.lnkForgotPassword.Location = new System.Drawing.Point(470, 367);
//            this.lnkForgotPassword.Text = "Forgot Password?";
//            this.lnkForgotPassword.TabIndex = 5;
//            this.lnkForgotPassword.TabStop = true;

//            // ── btnSignIn ─────────────────────────────────────────────
//            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
//            this.btnSignIn.FlatAppearance.BorderSize = 0;
//            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
//            this.btnSignIn.ForeColor = System.Drawing.Color.White;
//            this.btnSignIn.Location = new System.Drawing.Point(130, 430);
//            this.btnSignIn.Size = new System.Drawing.Size(555, 55);
//            this.btnSignIn.TabIndex = 6;
//            this.btnSignIn.Text = "SIGN IN";
//            this.btnSignIn.UseVisualStyleBackColor = false;
//            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;

//            // ── errorProvider ─────────────────────────────────────────
//            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
//            this.errorProvider.ContainerControl = this;

//            // ── panelCard children ────────────────────────────────────
//            this.panelCard.Controls.Add(this.lblTitle);
//            this.panelCard.Controls.Add(this.lblSubtitle);
//            this.panelCard.Controls.Add(this.lblEmail);
//            this.panelCard.Controls.Add(this.txtEmail);
//            this.panelCard.Controls.Add(this.lblPassword);
//            this.panelCard.Controls.Add(this.txtPassword);
//            this.panelCard.Controls.Add(this.btnTogglePassword);
//            this.panelCard.Controls.Add(this.chkRemember);
//            this.panelCard.Controls.Add(this.lnkForgotPassword);
//            this.panelCard.Controls.Add(this.btnSignIn);

//            this.Controls.Add(this.panelCard);

//            this.panelCard.ResumeLayout(false);
//            this.panelCard.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
//            this.ResumeLayout(false);
//        }

//        private System.Windows.Forms.Panel panelCard;
//        private System.Windows.Forms.Label lblTitle, lblSubtitle, lblEmail, lblPassword;
//        private System.Windows.Forms.TextBox txtEmail, txtPassword;
//        private System.Windows.Forms.Button btnTogglePassword, btnSignIn;
//        private System.Windows.Forms.CheckBox chkRemember;
//        private System.Windows.Forms.LinkLabel lnkForgotPassword;
//        private System.Windows.Forms.ErrorProvider errorProvider;
//    }
//}










////using System.Drawing;

////namespace CourierDB.UI
////{
////    partial class frmLogin
////    {
////        private System.ComponentModel.IContainer components = null;

////        protected override void Dispose(bool disposing)
////        {
////            if (disposing && (components != null))
////            {
////                components.Dispose();
////            }
////            base.Dispose(disposing);
////        }

////        private void InitializeComponent()
////        {
////            this.components = new System.ComponentModel.Container();
////            this.panelCard = new System.Windows.Forms.Panel();
////            this.lblTitle = new System.Windows.Forms.Label();
////            this.lblSubtitle = new System.Windows.Forms.Label();
////            this.lblEmail = new System.Windows.Forms.Label();
////            this.txtEmail = new System.Windows.Forms.TextBox();
////            this.lblPassword = new System.Windows.Forms.Label();
////            this.txtPassword = new System.Windows.Forms.TextBox();
////            this.btnTogglePassword = new System.Windows.Forms.Button();
////            this.chkRemember = new System.Windows.Forms.CheckBox();
////            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
////            this.btnSignIn = new System.Windows.Forms.Button();
////            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);

////            this.panelCard.SuspendLayout();
////            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
////            this.SuspendLayout();

////            // frmLogin - MAKE IT FULL SCREEN
////            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
////            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
////            this.ClientSize = new System.Drawing.Size(1920, 1080);
////            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
////            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
////            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;  // Remove border for full screen
////            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;    // Normal state but sized to full
////            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
////            this.Text = "Login";
////            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
////            this.Name = "frmLogin";
////            this.MinimumSize = new Size(1200, 800);
////            this.Size = new System.Drawing.Size(1920, 1200);
////            //this.Size = new System.Drawing.Size(1920, 1200);  // Explicitly set size

////            // panelCard - Centered card on the full screen
////            this.panelCard.BackColor = System.Drawing.Color.White;
////            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
////            this.panelCard.Location = new System.Drawing.Point(560, 150);
////            this.panelCard.Name = "panelCard";
////            this.panelCard.Size = new System.Drawing.Size(800, 900);
////            this.panelCard.TabIndex = 0;

////            // lblTitle
////            this.lblTitle.AutoSize = true;
////            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 32F, System.Drawing.FontStyle.Bold);
////            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
////            this.lblTitle.Location = new System.Drawing.Point(140, 60);
////            this.lblTitle.Name = "lblTitle";
////            this.lblTitle.Size = new System.Drawing.Size(520, 72);
////            this.lblTitle.TabIndex = 1;
////            this.lblTitle.Text = "Welcome to parcel Tracker";
////            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

////            // lblSubtitle
////            this.lblSubtitle.AutoSize = true;
////            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 18F);
////            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
////            this.lblSubtitle.Location = new System.Drawing.Point(145, 150);
////            this.lblSubtitle.Name = "lblSubtitle";
////            this.lblSubtitle.Size = new System.Drawing.Size(248, 41);
////            this.lblSubtitle.TabIndex = 2;
////            this.lblSubtitle.Text = "Track your order now";
////            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

////            // lblEmail
////            this.lblEmail.AutoSize = true;
////            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
////            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
////            this.lblEmail.Location = new System.Drawing.Point(140, 250);
////            this.lblEmail.Name = "lblEmail";
////            this.lblEmail.Size = new System.Drawing.Size(248, 32);
////            this.lblEmail.TabIndex = 3;
////            this.lblEmail.Text = "Email Address or Username";

////            // txtEmail
////            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
////            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
////            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 14F);
////            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
////            this.txtEmail.Location = new System.Drawing.Point(145, 295);
////            this.txtEmail.Name = "txtEmail";
////            this.txtEmail.Size = new System.Drawing.Size(500, 39);
////            this.txtEmail.TabIndex = 4;

////            // lblPassword
////            this.lblPassword.AutoSize = true;
////            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
////            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
////            this.lblPassword.Location = new System.Drawing.Point(140, 380);
////            this.lblPassword.Name = "lblPassword";
////            this.lblPassword.Size = new System.Drawing.Size(116, 32);
////            this.lblPassword.TabIndex = 5;
////            this.lblPassword.Text = "Password";

////            // txtPassword
////            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
////            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
////            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 14F);
////            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
////            this.txtPassword.Location = new System.Drawing.Point(145, 425);
////            this.txtPassword.Name = "txtPassword";
////            this.txtPassword.PasswordChar = '●';
////            this.txtPassword.Size = new System.Drawing.Size(500, 100);
////            this.txtPassword.TabIndex = 5;

////            // btnTogglePassword
////            this.btnTogglePassword.BackColor = System.Drawing.Color.Transparent;
////            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
////            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
////            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe UI", 14F);
////            this.btnTogglePassword.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
////            this.btnTogglePassword.Location = new System.Drawing.Point(650, 425);
////            this.btnTogglePassword.Name = "btnTogglePassword";
////            this.btnTogglePassword.Size = new System.Drawing.Size(45, 39);
////            this.btnTogglePassword.TabIndex = 6;
////            this.btnTogglePassword.Text = "👁️";
////            this.btnTogglePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
////            this.btnTogglePassword.UseVisualStyleBackColor = false;

////            // chkRemember
////            this.chkRemember.AutoSize = true;
////            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 12F);
////            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
////            this.chkRemember.Location = new System.Drawing.Point(145, 510);
////            this.chkRemember.Name = "chkRemember";
////            this.chkRemember.Size = new System.Drawing.Size(149, 32);
////            this.chkRemember.TabIndex = 7;
////            this.chkRemember.Text = "Remember me";
////            this.chkRemember.UseVisualStyleBackColor = true;

////            // lnkForgotPassword
////            this.lnkForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(41, 128, 185);
////            this.lnkForgotPassword.AutoSize = true;
////            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
////            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(52, 152, 219);
////            this.lnkForgotPassword.Location = new System.Drawing.Point(430, 512);
////            this.lnkForgotPassword.Name = "lnkForgotPassword";
////            this.lnkForgotPassword.Size = new System.Drawing.Size(157, 28);
////            this.lnkForgotPassword.TabIndex = 8;
////            this.lnkForgotPassword.TabStop = true;
////            this.lnkForgotPassword.Text = "Forgot Password?";

////            // btnSignIn
////            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
////            this.btnSignIn.FlatAppearance.BorderSize = 0;
////            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
////            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
////            this.btnSignIn.ForeColor = System.Drawing.Color.White;
////            this.btnSignIn.Location = new System.Drawing.Point(145, 600);
////            this.btnSignIn.Name = "btnSignIn";
////            this.btnSignIn.Size = new System.Drawing.Size(500, 70);
////            this.btnSignIn.TabIndex = 9;
////            this.btnSignIn.Text = "SIGN IN";
////            this.btnSignIn.UseVisualStyleBackColor = false;

////            // errorProvider
////            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
////            this.errorProvider.ContainerControl = this;

////            // panelCard Controls
////            this.panelCard.Controls.Add(this.lblTitle);
////            this.panelCard.Controls.Add(this.lblSubtitle);
////            this.panelCard.Controls.Add(this.lblEmail);
////            this.panelCard.Controls.Add(this.txtEmail);
////            this.panelCard.Controls.Add(this.lblPassword);
////            this.panelCard.Controls.Add(this.txtPassword);
////            this.panelCard.Controls.Add(this.btnTogglePassword);
////            this.panelCard.Controls.Add(this.chkRemember);
////            this.panelCard.Controls.Add(this.lnkForgotPassword);
////            this.panelCard.Controls.Add(this.btnSignIn);

////            // frmLogin Controls
////            this.Controls.Add(this.panelCard);

////            // Resume Layout
////            this.panelCard.ResumeLayout(false);
////            this.panelCard.PerformLayout();
////            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
////            this.ResumeLayout(false);
////        }

////        private System.Windows.Forms.Panel panelCard;
////        private System.Windows.Forms.Label lblTitle;
////        private System.Windows.Forms.Label lblSubtitle;
////        private System.Windows.Forms.Label lblEmail;
////        private System.Windows.Forms.TextBox txtEmail;
////        private System.Windows.Forms.Label lblPassword;
////        private System.Windows.Forms.TextBox txtPassword;
////        private System.Windows.Forms.Button btnTogglePassword;
////        private System.Windows.Forms.CheckBox chkRemember;
////        private System.Windows.Forms.LinkLabel lnkForgotPassword;
////        private System.Windows.Forms.Button btnSignIn;
////        private System.Windows.Forms.ErrorProvider errorProvider;
////    }
////}


////// my correct code 

//////namespace CourierDB.UI
//////{
//////    partial class frmLogin
//////    {
//////        private System.ComponentModel.IContainer components = null;

//////        protected override void Dispose(bool disposing)
//////        {
//////            if (disposing && (components != null))
//////            {
//////                components.Dispose();
//////            }
//////            base.Dispose(disposing);
//////        }

//////        private void InitializeComponent()
//////        {
//////            this.components = new System.ComponentModel.Container();
//////            this.panelCard = new System.Windows.Forms.Panel();
//////            this.lblTitle = new System.Windows.Forms.Label();
//////            this.lblSubtitle = new System.Windows.Forms.Label();
//////            this.lblEmail = new System.Windows.Forms.Label();
//////            this.txtEmail = new System.Windows.Forms.TextBox();
//////            this.lblPassword = new System.Windows.Forms.Label();
//////            this.txtPassword = new System.Windows.Forms.TextBox();
//////            this.btnTogglePassword = new System.Windows.Forms.Button();
//////            this.chkRemember = new System.Windows.Forms.CheckBox();
//////            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
//////            this.btnSignIn = new System.Windows.Forms.Button();
//////            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);

//////            this.panelCard.SuspendLayout();
//////            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
//////            this.SuspendLayout();

//////            // frmLogin
//////            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//////            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//////            this.ClientSize = new System.Drawing.Size(520, 620);
//////            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//////            this.MaximizeBox = false;
//////            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//////            this.Text = "Login";
//////            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
//////            this.Name = "frmLogin";

//////            // panelCard
//////            this.panelCard.BackColor = System.Drawing.Color.White;
//////            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//////            this.panelCard.Location = new System.Drawing.Point(40, 30);
//////            this.panelCard.Name = "panelCard";
//////            this.panelCard.Size = new System.Drawing.Size(440, 540);
//////            this.panelCard.TabIndex = 0;

//////            // lblTitle
//////            this.lblTitle.AutoSize = true;
//////            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
//////            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
//////            this.lblTitle.Location = new System.Drawing.Point(60, 40);
//////            this.lblTitle.Name = "lblTitle";
//////            this.lblTitle.Size = new System.Drawing.Size(320, 41);
//////            this.lblTitle.TabIndex = 1;
//////            this.lblTitle.Text = "Welcome to parcel Tracker";

//////            // lblSubtitle
//////            this.lblSubtitle.AutoSize = true;
//////            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F);
//////            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
//////            this.lblSubtitle.Location = new System.Drawing.Point(62, 90);
//////            this.lblSubtitle.Name = "lblSubtitle";
//////            this.lblSubtitle.Size = new System.Drawing.Size(148, 21);
//////            this.lblSubtitle.TabIndex = 2;
//////            this.lblSubtitle.Text = "Track your order now";

//////            // lblEmail
//////            this.lblEmail.AutoSize = true;
//////            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
//////            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
//////            this.lblEmail.Location = new System.Drawing.Point(62, 150);
//////            this.lblEmail.Name = "lblEmail";
//////            this.lblEmail.Size = new System.Drawing.Size(136, 19);
//////            this.lblEmail.TabIndex = 3;
//////            this.lblEmail.Text = "Email Address or Username";

//////            // txtEmail
//////            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
//////            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//////            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
//////            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
//////            this.txtEmail.Location = new System.Drawing.Point(66, 175);
//////            this.txtEmail.Name = "txtEmail";
//////            this.txtEmail.Size = new System.Drawing.Size(308, 27);
//////            this.txtEmail.TabIndex = 4;

//////            // lblPassword
//////            this.lblPassword.AutoSize = true;
//////            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
//////            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
//////            this.lblPassword.Location = new System.Drawing.Point(62, 230);
//////            this.lblPassword.Name = "lblPassword";
//////            this.lblPassword.Size = new System.Drawing.Size(67, 19);
//////            this.lblPassword.TabIndex = 5;
//////            this.lblPassword.Text = "Password";

//////            // txtPassword
//////            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
//////            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//////            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
//////            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
//////            this.txtPassword.Location = new System.Drawing.Point(66, 255);
//////            this.txtPassword.Name = "txtPassword";
//////            this.txtPassword.PasswordChar = '●';
//////            this.txtPassword.Size = new System.Drawing.Size(308, 27);
//////            this.txtPassword.TabIndex = 6;

//////            // btnTogglePassword
//////            this.btnTogglePassword.BackColor = System.Drawing.Color.Transparent;
//////            this.btnTogglePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
//////            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
//////            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//////            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe UI", 8F);
//////            this.btnTogglePassword.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
//////            this.btnTogglePassword.Location = new System.Drawing.Point(380, 255);
//////            this.btnTogglePassword.Name = "btnTogglePassword";
//////            this.btnTogglePassword.Size = new System.Drawing.Size(28, 27);
//////            this.btnTogglePassword.TabIndex = 7;
//////            this.btnTogglePassword.Text = "👁️";
//////            this.btnTogglePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//////            this.btnTogglePassword.UseVisualStyleBackColor = false;
//////            // Commented out - add this in the form constructor or create the event handler
//////            // this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);

//////            // chkRemember
//////            this.chkRemember.AutoSize = true;
//////            this.chkRemember.BackColor = System.Drawing.Color.Transparent;
//////            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 9F);
//////            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
//////            this.chkRemember.Location = new System.Drawing.Point(66, 310);
//////            this.chkRemember.Name = "chkRemember";
//////            this.chkRemember.Size = new System.Drawing.Size(100, 19);
//////            this.chkRemember.TabIndex = 8;
//////            this.chkRemember.Text = "Remember me";
//////            this.chkRemember.UseVisualStyleBackColor = false;

//////            // lnkForgotPassword
//////            this.lnkForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(41, 128, 185);
//////            this.lnkForgotPassword.AutoSize = true;
//////            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
//////            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(52, 152, 219);
//////            this.lnkForgotPassword.Location = new System.Drawing.Point(302, 311);
//////            this.lnkForgotPassword.Name = "lnkForgotPassword";
//////            this.lnkForgotPassword.Size = new System.Drawing.Size(99, 15);
//////            this.lnkForgotPassword.TabIndex = 9;
//////            this.lnkForgotPassword.TabStop = true;
//////            this.lnkForgotPassword.Text = "Forgot Password?";
//////            // Commented out - add this in the form constructor or create the event handler
//////            // this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);

//////            // btnSignIn
//////            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
//////            this.btnSignIn.FlatAppearance.BorderSize = 0;
//////            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//////            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
//////            this.btnSignIn.ForeColor = System.Drawing.Color.White;
//////            this.btnSignIn.Location = new System.Drawing.Point(66, 370);
//////            this.btnSignIn.Name = "btnSignIn";
//////            this.btnSignIn.Size = new System.Drawing.Size(308, 42);
//////            this.btnSignIn.TabIndex = 10;
//////            this.btnSignIn.Text = "SIGN IN";
//////            this.btnSignIn.UseVisualStyleBackColor = false;
//////            // Commented out - add this in the form constructor or create the event handler
//////            // this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);

//////            // errorProvider
//////            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
//////            this.errorProvider.ContainerControl = this;

//////            // panelCard Controls
//////            this.panelCard.Controls.Add(this.lblTitle);
//////            this.panelCard.Controls.Add(this.lblSubtitle);
//////            this.panelCard.Controls.Add(this.lblEmail);
//////            this.panelCard.Controls.Add(this.txtEmail);
//////            this.panelCard.Controls.Add(this.lblPassword);
//////            this.panelCard.Controls.Add(this.txtPassword);
//////            this.panelCard.Controls.Add(this.btnTogglePassword);
//////            this.panelCard.Controls.Add(this.chkRemember);
//////            this.panelCard.Controls.Add(this.lnkForgotPassword);
//////            this.panelCard.Controls.Add(this.btnSignIn);

//////            // frmLogin Controls
//////            this.Controls.Add(this.panelCard);

//////            // Resume Layout
//////            this.panelCard.ResumeLayout(false);
//////            this.panelCard.PerformLayout();
//////            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
//////            this.ResumeLayout(false);
//////        }

//////        private System.Windows.Forms.Panel panelCard;
//////        private System.Windows.Forms.Label lblTitle;
//////        private System.Windows.Forms.Label lblSubtitle;
//////        private System.Windows.Forms.Label lblEmail;
//////        private System.Windows.Forms.TextBox txtEmail;
//////        private System.Windows.Forms.Label lblPassword;
//////        private System.Windows.Forms.TextBox txtPassword;
//////        private System.Windows.Forms.Button btnTogglePassword;
//////        private System.Windows.Forms.CheckBox chkRemember;
//////        private System.Windows.Forms.LinkLabel lnkForgotPassword;
//////        private System.Windows.Forms.Button btnSignIn;
//////        private System.Windows.Forms.ErrorProvider errorProvider;
//////    }
//////}




////////namespace CourierDB.UI
////////{
////////    partial class frmLogin
////////    {
////////        /// <summary>
////////        /// Required designer variable.
////////        /// </summary>
////////        private System.ComponentModel.IContainer components = null;

////////        /// <summary>
////////        /// Clean up any resources being used.
////////        /// </summary>
////////        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
////////        protected override void Dispose(bool disposing)
////////        {
////////            if (disposing && (components != null))
////////            {
////////                components.Dispose();
////////            }
////////            base.Dispose(disposing);
////////        }

////////        #region Windows Form Designer generated code

////////        /// <summary>
////////        /// Required method for Designer support - do not modify
////////        /// the contents of this method with the code editor.
////////        /// </summary>
////////        private void InitializeComponent()
////////        {
////////            this.components = new System.ComponentModel.Container();
////////            this.email_name = new System.Windows.Forms.Label();
////////            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
////////            this.txtEmail = new System.Windows.Forms.TextBox();
////////            this.password_name = new System.Windows.Forms.Label();
////////            this.txtPassword = new System.Windows.Forms.TextBox();
////////            this.btnLogin = new System.Windows.Forms.Button();
////////            this.SuspendLayout();
////////            // 
////////            // email_name
////////            // 
////////            this.email_name.AutoSize = true;
////////            this.email_name.Location = new System.Drawing.Point(527, 110);
////////            this.email_name.Name = "email_name";
////////            this.email_name.Size = new System.Drawing.Size(56, 20);
////////            this.email_name.TabIndex = 0;
////////            this.email_name.Text = " Email:";
////////            this.email_name.Click += new System.EventHandler(this.email_name_Click);
////////            // 
////////            // contextMenuStrip1
////////            // 
////////            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
////////            this.contextMenuStrip1.Name = "contextMenuStrip1";
////////            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
////////            // 
////////            // txtEmail
////////            // 
////////            this.txtEmail.Location = new System.Drawing.Point(589, 104);
////////            this.txtEmail.Name = "txtEmail";
////////            this.txtEmail.Size = new System.Drawing.Size(100, 26);
////////            this.txtEmail.TabIndex = 2;
////////            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
////////            // 
////////            // password_name
////////            // 
////////            this.password_name.AutoSize = true;
////////            this.password_name.Location = new System.Drawing.Point(527, 186);
////////            this.password_name.Name = "password_name";
////////            this.password_name.Size = new System.Drawing.Size(82, 20);
////////            this.password_name.TabIndex = 3;
////////            this.password_name.Text = "Password:";
////////            this.password_name.Click += new System.EventHandler(this.password_name_Click);
////////            // 
////////            // txtPassword
////////            // 
////////            this.txtPassword.Location = new System.Drawing.Point(615, 186);
////////            this.txtPassword.Name = "txtPassword";
////////            this.txtPassword.PasswordChar = '*';
////////            this.txtPassword.Size = new System.Drawing.Size(100, 26);
////////            this.txtPassword.TabIndex = 4;
////////            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
////////            // 
////////            // btnLogin
////////            // 
////////            this.btnLogin.Location = new System.Drawing.Point(531, 280);
////////            this.btnLogin.Name = "btnLogin";
////////            this.btnLogin.Size = new System.Drawing.Size(80, 28);
////////            this.btnLogin.TabIndex = 5;
////////            this.btnLogin.Text = "Login";
////////            this.btnLogin.UseVisualStyleBackColor = true;
////////            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
////////            // 
////////            // frmLogin
////////            // 
////////            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
////////            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
////////            this.ClientSize = new System.Drawing.Size(800, 450);
////////            this.Controls.Add(this.btnLogin);
////////            this.Controls.Add(this.txtPassword);
////////            this.Controls.Add(this.password_name);
////////            this.Controls.Add(this.txtEmail);
////////            this.Controls.Add(this.email_name);
////////            this.Name = "frmLogin";
////////            this.Text = "frmLogin";
////////            this.ResumeLayout(false);
////////            this.PerformLayout();

////////        }

////////        #endregion

////////        private System.Windows.Forms.Label email_name;
////////        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
////////        private System.Windows.Forms.TextBox txtEmail;
////////        private System.Windows.Forms.Label password_name;
////////        private System.Windows.Forms.TextBox txtPassword;
////////        private System.Windows.Forms.Button btnLogin;
////////    }
////////}