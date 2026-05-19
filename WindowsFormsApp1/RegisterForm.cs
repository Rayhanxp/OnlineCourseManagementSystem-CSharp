using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class RegisterForm : Form
    {
        private void StyleButtons()
        {
            StyleButton(btnRegister);
            StyleButton(btnBack);
            
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

        public RegisterForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            StyleButtons();
            StyleInputs();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = @"INSERT INTO Users (FullName, Email, Password, Role)
                                 VALUES (@FullName, @Email, @Password, 'Student')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful. Please login.");

                    LoginForm login = new LoginForm();
                    login.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("This email already exists or invalid data.");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}