using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class ManageUsersForm : Form
    {


        private void StyleInputs()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.WindowState = FormWindowState.Maximized;

            foreach (Control c in this.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lbl.ForeColor = Color.FromArgb(44, 62, 80);
                    lbl.AutoSize = true;
                }

                if (c is TextBox txt)
                {
                    txt.Font = new Font("Segoe UI", 11);
                    txt.Width = 260;
                    txt.Height = 32;
                    txt.BackColor = Color.White;
                    txt.ForeColor = Color.FromArgb(44, 62, 80);
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }

                if (c is ComboBox cmb)
                {
                    cmb.Font = new Font("Segoe UI", 11);
                    cmb.Width = 260;
                    cmb.Height = 32;
                    cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                }

                if (c is DateTimePicker dtp)
                {
                    dtp.Font = new Font("Segoe UI", 11);
                    dtp.Width = 260;
                    dtp.Height = 32;
                }
            }
        }


        int selectedUserId = 0;

        public ManageUsersForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            StyleInputs();
            StyleGrid();
            StyleButtons();
        }

        private void StyleGrid()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowTemplate.Height = 30;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void StyleButtons()
        {
            StyleButton(btnAdd);
            StyleButton(btnUpdate);
            StyleButton(btnDelete);
            StyleButton(btnClear);
        }

        private void StyleButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(41, 128, 185);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Height = 45;
            btn.Width = 160;
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Student");
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("SuperAdmin");

            LoadUsers();
        }

        private void LoadUsers()
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT UserId, FullName, Email, Password, Role FROM Users", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || cmbRole.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = @"INSERT INTO Users (FullName, Email, Password, Role)
                                 VALUES (@FullName, @Email, @Password, @Role)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Role", cmbRole.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User Added Successfully");
                LoadUsers();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = @"UPDATE Users
                                 SET FullName=@FullName, Email=@Email, Password=@Password, Role=@Role
                                 WHERE UserId=@UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", selectedUserId);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Role", cmbRole.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User Updated Successfully");
                LoadUsers();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = DbConnection.GetConnection())
                {
                    con.Open();

                    string query = "DELETE FROM Users WHERE UserId=@UserId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserId", selectedUserId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User Deleted Successfully");
                    LoadUsers();
                    ClearFields();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedUserId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserId"].Value);
                txtFullName.Text = dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                cmbRole.Text = dataGridView1.Rows[e.RowIndex].Cells["Role"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            selectedUserId = 0;
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            cmbRole.Text = "";
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}