using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
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

        

        private void StyleButtons()
        {
            StyleButton(btnLogin);
            StyleButton(btnRegister);
            
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
        public LoginForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            StyleInputs();
            StyleButtons();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                try
                {
                    con.Open();

                    string query = "SELECT * FROM Users WHERE Email=@Email AND Password=@Password";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Session.UserId = Convert.ToInt32(reader["UserId"]);
                        Session.FullName = reader["FullName"].ToString();
                        Session.Email = reader["Email"].ToString();
                        Session.Role = reader["Role"].ToString();

                        string role = reader["Role"].ToString();

                        MessageBox.Show("Login Successful");

                        this.Hide();

                        if (role == "Student")
                        {
                            StudentDashboard studentDashboard = new StudentDashboard();
                            studentDashboard.Show();
                        }
                        else if (role == "Admin")
                        {
                            AdminDashboard adminDashboard = new AdminDashboard();
                            adminDashboard.Show();
                        }
                        else if (role == "SuperAdmin")
                        {
                            SuperAdminDashboard superAdminDashboard = new SuperAdminDashboard();
                            superAdminDashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid user role.");
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Email or Password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}