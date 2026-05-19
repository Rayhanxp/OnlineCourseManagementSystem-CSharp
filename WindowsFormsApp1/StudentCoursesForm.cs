using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class StudentCoursesForm : Form
    {
        int selectedCourseId = 0;
        string selectedCourseTitle = "";
        decimal selectedCourseFee = 5000; // Dummy fixed fee

        public StudentCoursesForm()
        {
            InitializeComponent();
            LoadCourses();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
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
            StyleButton(btnEnroll);
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

        private void StudentCoursesForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = "SELECT CourseID, Title, Description FROM Courses";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedCourseId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CourseID"].Value);
                selectedCourseTitle = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();

                MessageBox.Show("Selected Course: " + selectedCourseTitle);
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (Session.UserId == 0)
            {
                MessageBox.Show("Session problem. Please login again.");
                return;
            }

            if (selectedCourseId == 0)
            {
                MessageBox.Show("Please select a course first.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM Enrollments WHERE UserId=@UserId AND CourseID=@CourseID";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@UserId", Session.UserId);
                checkCmd.Parameters.AddWithValue("@CourseID", selectedCourseId);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("You already enrolled in this course.");
                    return;
                }
            }

            PaymentForm payment = new PaymentForm(selectedCourseId, selectedCourseTitle, selectedCourseFee);
            payment.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void StudentCoursesForm_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}