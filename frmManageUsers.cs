using CourierDB.BLL;
using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CourierDB.UI
{
    public partial class frmManageUsers : Form
    {
        private UserBLL bll = new UserBLL();
        private int selectedUserID = 0;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            cmbRole.Items.AddRange(new string[] { "Customer", "Staff", "Admin" });
            cmbRole.SelectedIndex = 0;
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                dgvUsers.DataSource = bll.GetAllUsers();
                if (dgvUsers.Columns["password_hash"] != null)
                    dgvUsers.Columns["password_hash"].Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageUsers", ex.Message);
                MessageBox.Show("Failed to load users.");
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            selectedUserID = Convert.ToInt32(row.Cells["user_id"].Value);
            txtName.Text = row.Cells["name"].Value.ToString();
            txtEmail.Text = row.Cells["email"].Value.ToString();
            txtPhone.Text = row.Cells["phone"].Value.ToString();
            cmbRole.Text = row.Cells["role"].Value.ToString();
            txtPassword.Text = ""; // Never show hash
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                User u = new User
                {
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    PasswordHash = txtPassword.Text,  // BLL will hash it
                    Phone = txtPhone.Text.Trim(),
                    Role = cmbRole.SelectedItem.ToString()
                };
                string result = bll.AddUser(u);
                MessageBox.Show(result);
                LoadUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageUsers", ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedUserID == 0)
                { MessageBox.Show("Please select a user first."); return; }

                User u = new User
                {
                    UserID = selectedUserID,
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };
                string result = bll.UpdateUser(u);
                MessageBox.Show(result);
                LoadUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                Logger.LogError("frmManageUsers", ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserID == 0)
            { MessageBox.Show("Please select a user first."); return; }

            DialogResult confirm = MessageBox.Show(
                "Delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bll.DeleteUser(selectedUserID);
                MessageBox.Show("User deleted.");
                LoadUsers();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        private void ClearFields()
        {
            selectedUserID = 0;
            txtName.Text = txtEmail.Text = txtPhone.Text = txtPassword.Text = "";
            cmbRole.SelectedIndex = 0;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {

        }
    }
}
