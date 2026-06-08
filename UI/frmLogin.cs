using CourierDB.BLL;
using CourierDB.SoftwareClasses;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CourierDB.UI
{
    public partial class frmLogin : Form
    {
        private bool _passwordVisible = false;

        // ── Registry key used to persist credentials ───────────────────
        private const string REG_KEY = @"SOFTWARE\CourierDB";
        private const string REG_USER = "SavedUsername";
        private const string REG_PASS = "SavedPassword";   // stored as Base64 — not encryption, just obfuscation
        private const string REG_REM = "RememberMe";

        public frmLogin()
        {
            InitializeComponent();

            this.Resize += frmLogin_Resize;

            this.btnSignIn.Click += btnSignIn_Click;
            this.btnTogglePassword.Click += btnTogglePassword_Click;
            this.lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;

            SetupPlaceholders();
            LoadRememberedCredentials();
        }

        // ── Keep card centred when the maximised form resizes ──────────
        private void frmLogin_Resize(object sender, EventArgs e)
        {
            panelCard.Location = new Point(
                (this.ClientSize.Width - panelCard.Width) / 2,
                (this.ClientSize.Height - panelCard.Height) / 2);
        }

        // ── Placeholder helpers ────────────────────────────────────────
        private void SetupPlaceholders()
        {
            const string emailPH = "Enter your email or username";
            const string passPH = "Enter your password";

            txtEmail.Text = emailPH;
            txtEmail.ForeColor = Color.Gray;

            txtEmail.Enter += (s, e) =>
            {
                if (txtEmail.Text == emailPH)
                { txtEmail.Text = ""; txtEmail.ForeColor = Color.FromArgb(44, 62, 80); }
            };
            txtEmail.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                { txtEmail.Text = emailPH; txtEmail.ForeColor = Color.Gray; }
            };

            txtPassword.Text = passPH;
            txtPassword.ForeColor = Color.Gray;
            txtPassword.PasswordChar = '\0';

            txtPassword.Enter += (s, e) =>
            {
                if (txtPassword.Text == passPH)
                {
                    txtPassword.Text = "";
                    txtPassword.ForeColor = Color.FromArgb(44, 62, 80);
                    txtPassword.PasswordChar = _passwordVisible ? '\0' : '●';
                }
            };
            txtPassword.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.Text = passPH;
                    txtPassword.ForeColor = Color.Gray;
                    txtPassword.PasswordChar = '\0';
                }
            };
        }

        // ── FIX 1: Toggle button uses "Show" / "Hide" — no emoji clipping ──
        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter your password") return;

            _passwordVisible = !_passwordVisible;
            txtPassword.PasswordChar = _passwordVisible ? '\0' : '●';
            btnTogglePassword.Text = _passwordVisible ? "Hide" : "Show";
        }

        // ── FIX 2: Remember Me — load / save via registry ──────────────
        private void LoadRememberedCredentials()
        {
            try
            {
                using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(REG_KEY))
                {
                    if (key == null) return;

                    bool remember = key.GetValue(REG_REM)?.ToString() == "1";
                    if (!remember) return;

                    string savedUser = key.GetValue(REG_USER)?.ToString() ?? "";
                    string savedPass = key.GetValue(REG_PASS)?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(savedUser))
                    {
                        // Decode the stored Base64 password
                        string decoded = System.Text.Encoding.UTF8.GetString(
                                             Convert.FromBase64String(savedPass));

                        txtEmail.Text = savedUser;
                        txtEmail.ForeColor = Color.FromArgb(44, 62, 80);
                        txtPassword.Text = decoded;
                        txtPassword.ForeColor = Color.FromArgb(44, 62, 80);
                        txtPassword.PasswordChar = '●';
                        chkRemember.Checked = true;
                    }
                }
            }
            catch { /* silently ignore — registry may not exist yet */ }
        }

        private void SaveCredentials(string username, string password)
        {
            using (var key = Microsoft.Win32.Registry.CurrentUser
                                 .CreateSubKey(REG_KEY, true))
            {
                if (chkRemember.Checked)
                {
                    string encoded = Convert.ToBase64String(
                                         System.Text.Encoding.UTF8.GetBytes(password));
                    key.SetValue(REG_USER, username);
                    key.SetValue(REG_PASS, encoded);
                    key.SetValue(REG_REM, "1");
                }
                else
                {
                    // Clear any previously saved credentials
                    key.DeleteValue(REG_USER, false);
                    key.DeleteValue(REG_PASS, false);
                    key.SetValue(REG_REM, "0");
                }
            }
        }

        // ── FIX 3: Forgot Password — role-aware message ────────────────
        private void lnkForgotPassword_LinkClicked(object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            // We don't know the role until after login, so we check
            // whether a session is already open (i.e. called from dashboard).
            // At login time nobody is authenticated yet — show a generic
            // message that doesn't insult an admin by telling them to call
            // themselves.
            string role = frmDashboard.LoggedInRole ?? "";

            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                // Admin is already logged in and somehow landed here — shouldn't happen,
                // but handle gracefully.
                MessageBox.Show(
                    "As an administrator you can reset any user's password\n" +
                    "directly from the Manage Users screen.",
                    "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Normal user at the login screen
                MessageBox.Show(
                    "Please contact your system administrator to reset your password.\n\n" +
                    "If you are an administrator, log in with your admin credentials\n" +
                    "and use the Manage Users section to reset passwords.",
                    "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ── Sign-in logic ──────────────────────────────────────────────
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            const string emailPH = "Enter your email or username";
            const string passPH = "Enter your password";

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (email == emailPH || string.IsNullOrWhiteSpace(email))
            { MessageBox.Show("Please enter your email or username."); return; }

            if (password == passPH || string.IsNullOrWhiteSpace(password))
            { MessageBox.Show("Please enter your password."); return; }

            try
            {
                UserBLL bll = new UserBLL();
                DataTable dt = bll.Login(email, password);

                if (dt.Rows.Count > 0)
                {
                    frmDashboard.LoggedInUserID = Convert.ToInt32(dt.Rows[0]["user_id"]);
                    frmDashboard.LoggedInUserName = dt.Rows[0]["name"].ToString();
                    frmDashboard.LoggedInRole = dt.Rows[0]["role"].ToString();

                    // Save or clear remembered credentials
                    SaveCredentials(email, password);

                    frmDashboard dashboard = new frmDashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid email or password. Please try again.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("frmLogin", ex.Message, ex.StackTrace);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ── Unused stubs kept to avoid breaking any Designer references ─
        private void label1_Click(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void password_name_Click(object sender, EventArgs e) { }
        private void email_name_Click(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
    }
}












//using CourierDB.BLL;
//using CourierDB.SoftwareClasses;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace CourierDB.UI
//{
//    public partial class frmLogin : Form
//    {
//        private bool isPasswordVisible = false;

//        public frmLogin()
//        {
//            InitializeComponent();

//            //// Make form full screen
//            //this.WindowState = FormWindowState.Maximized;

//            // Wire up events manually (commented out in Designer)
//            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
//            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
//            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);

//            // Optional: Add placeholder text functionality
//            SetupPlaceholders();
//        }

//        private void SetupPlaceholders()
//        {
//            // Email placeholder
//            if (string.IsNullOrWhiteSpace(txtEmail.Text))
//            {
//                txtEmail.Text = "Enter your email or username";
//                txtEmail.ForeColor = System.Drawing.Color.Gray;
//            }

//            txtEmail.Enter += (s, e) =>
//            {
//                if (txtEmail.Text == "Enter your email or username")
//                {
//                    txtEmail.Text = "";
//                    txtEmail.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
//                }
//            };

//            txtEmail.Leave += (s, e) =>
//            {
//                if (string.IsNullOrWhiteSpace(txtEmail.Text))
//                {
//                    txtEmail.Text = "Enter your email or username";
//                    txtEmail.ForeColor = System.Drawing.Color.Gray;
//                }
//            };

//            // Password placeholder
//            if (string.IsNullOrWhiteSpace(txtPassword.Text))
//            {
//                txtPassword.Text = "Enter your password";
//                txtPassword.ForeColor = System.Drawing.Color.Gray;
//                txtPassword.PasswordChar = '\0';
//            }

//            txtPassword.Enter += (s, e) =>
//            {
//                if (txtPassword.Text == "Enter your password")
//                {
//                    txtPassword.Text = "";
//                    txtPassword.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
//                    if (!isPasswordVisible)
//                    {
//                        txtPassword.PasswordChar = '●';
//                    }
//                }
//            };

//            txtPassword.Leave += (s, e) =>
//            {
//                if (string.IsNullOrWhiteSpace(txtPassword.Text))
//                {
//                    txtPassword.Text = "Enter your password";
//                    txtPassword.ForeColor = System.Drawing.Color.Gray;
//                    txtPassword.PasswordChar = '\0';
//                }
//            };
//        }

//        private void btnLogin_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                string email = txtEmail.Text.Trim();
//                string password = txtPassword.Text;

//                // Check for placeholder text
//                if (email == "Enter your email or username" || string.IsNullOrWhiteSpace(email))
//                {
//                    MessageBox.Show("Please enter email and password.");
//                    return;
//                }

//                if (password == "Enter your password" || string.IsNullOrWhiteSpace(password))
//                {
//                    MessageBox.Show("Please enter email and password.");
//                    return;
//                }

//                UserBLL bll = new UserBLL();
//                DataTable dt = bll.Login(email, password);

//                if (dt.Rows.Count > 0)
//                {
//                    // Set logged in user info for dashboard
//                    frmDashboard.LoggedInUserID = Convert.ToInt32(dt.Rows[0]["user_id"]);
//                    frmDashboard.LoggedInUserName = dt.Rows[0]["name"].ToString();
//                    frmDashboard.LoggedInRole = dt.Rows[0]["role"].ToString();

//                    frmDashboard dashboard = new frmDashboard();
//                    dashboard.Show();
//                    this.Hide();
//                }
//                else
//                {
//                    MessageBox.Show("Invalid email or password. Please try again.");
//                }
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError("frmLogin", ex.Message, ex.StackTrace);
//                MessageBox.Show("Error: " + ex.Message);
//            }
//        }

//        private void btnTogglePassword_Click(object sender, EventArgs e)
//        {
//            // FIXED: Use PasswordChar instead of UseSystemPasswordChar
//            isPasswordVisible = !isPasswordVisible;

//            if (txtPassword.Text != "Enter your password")
//            {
//                if (isPasswordVisible)
//                {
//                    txtPassword.PasswordChar = '\0';  // Show password
//                    btnTogglePassword.Text = "🙈";     // Closed eye icon
//                }
//                else
//                {
//                    txtPassword.PasswordChar = '●';   // Hide password
//                    btnTogglePassword.Text = "👁️";     // Open eye icon
//                }
//            }
//        }

//        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            MessageBox.Show("Please contact the administrator to reset your password.",
//                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void btnSignIn_Click(object sender, EventArgs e)
//        {
//            btnLogin_Click(sender, e);
//        }

//        // Keep these empty methods as they might be referenced
//        private void label1_Click(object sender, EventArgs e)
//        {

//        }

//        private void txtPassword_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void password_name_Click(object sender, EventArgs e)
//        {

//        }

//        private void email_name_Click(object sender, EventArgs e)
//        {

//        }

//        private void txtEmail_TextChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}











////using CourierDB.BLL;
////using CourierDB.SoftwareClasses;
////using System;
////using System.Collections.Generic;
////using System.ComponentModel;
////using System.Data;
////using System.Drawing;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
////using System.Windows.Forms;

////namespace CourierDB.UI
////{
////    public partial class frmLogin : Form
////    {
////        public frmLogin()
////        {
////            InitializeComponent();

////            // Wire up events manually (commented out in Designer)
////            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
////            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
////            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);
////        }

////            private void btnLogin_Click(object sender, EventArgs e)
////            {
////                try
////                {
////                    string email = txtEmail.Text.Trim();
////                    string password = txtPassword.Text;

////                    if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
////                    {
////                        MessageBox.Show("Please enter email and password.");
////                        return;
////                    }

////                    UserBLL bll = new UserBLL();
////                    DataTable dt = bll.Login(email, password);

////                    if (dt.Rows.Count > 0)
////                    {
////                        // Set logged in user info for dashboard
////                        frmDashboard.LoggedInUserID = Convert.ToInt32(dt.Rows[0]["user_id"]);
////                        frmDashboard.LoggedInUserName = dt.Rows[0]["name"].ToString();
////                        frmDashboard.LoggedInRole = dt.Rows[0]["role"].ToString();

////                        frmDashboard dashboard = new frmDashboard();
////                        dashboard.Show();
////                        this.Hide();
////                    }
////                    else
////                    {
////                        MessageBox.Show("Invalid email or password. Please try again.");
////                    }
////                }
////                catch (Exception ex)
////                {
////                    Logger.LogError("frmLogin", ex.Message, ex.StackTrace);
////                    MessageBox.Show("Error: " + ex.Message);
////                }
////            }

////        private void btnTogglePassword_Click(object sender, EventArgs e)
////        {
////            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
////        }

////        private void lnkForgotPassword_LinkClicked(object sender,
////            System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
////        {
////            MessageBox.Show("Please contact the administrator to reset your password.",
////                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
////        }

////        private void btnSignIn_Click(object sender, EventArgs e)
////        {
////            btnLogin_Click(sender, e);
////        }

////        private void label1_Click(object sender, EventArgs e)
////        {

////        }


////        private void txtPassword_TextChanged(object sender, EventArgs e)
////        {

////        }

////        private void password_name_Click(object sender, EventArgs e)
////        {

////        }

////        private void email_name_Click(object sender, EventArgs e)
////        {

////        }

////        private void txtEmail_TextChanged(object sender, EventArgs e)
////        {

////        }
////    }
////}

