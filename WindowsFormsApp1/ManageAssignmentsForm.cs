using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class ManageAssignmentsForm : Form

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

        int selectedAssignmentId = 0;

        public ManageAssignmentsForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadAssignments();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            StyleGrid();
            StyleButtons();
            StyleInputs();
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

        private void ManageAssignmentsForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadAssignments();
        }

        private void LoadCourses()
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = "SELECT CourseID, Title FROM Courses ORDER BY CourseID";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCourse.DataSource = null;
                cmbCourse.DisplayMember = "Title";
                cmbCourse.ValueMember = "CourseID";
                cmbCourse.DataSource = dt;
            }
        }

        private int GetSelectedCourseId()
        {
            if (cmbCourse.SelectedValue == null)
            {
                return 0;
            }

            if (cmbCourse.SelectedValue is DataRowView row)
            {
                return Convert.ToInt32(row["CourseID"]);
            }

            return Convert.ToInt32(cmbCourse.SelectedValue);
        }

        private void LoadAssignments()
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = @"
                    SELECT 
                        A.AssignmentID,
                        A.CourseID,
                        C.Title AS CourseTitle,
                        A.Title,
                        A.Description,
                        A.Deadline
                    FROM Assignments A
                    INNER JOIN Courses C ON A.CourseID = C.CourseID
                    ORDER BY A.AssignmentID DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int courseId = GetSelectedCourseId();

            if (courseId == 0 || txtTitle.Text.Trim() == "" || txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please select course and fill all fields.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = @"INSERT INTO Assignments
                                 (CourseID, Title, Description, Deadline)
                                 VALUES
                                 (@CourseID, @Title, @Description, @Deadline)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Deadline", dtpDeadline.Value.Date);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Assignment Added Successfully. CourseID: " + courseId);

                LoadAssignments();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int courseId = GetSelectedCourseId();

            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Please select assignment first.");
                return;
            }

            if (courseId == 0 || txtTitle.Text.Trim() == "" || txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please select course and fill all fields.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = @"UPDATE Assignments
                                 SET CourseID=@CourseID,
                                     Title=@Title,
                                     Description=@Description,
                                     Deadline=@Deadline
                                 WHERE AssignmentID=@AssignmentID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AssignmentID", selectedAssignmentId);
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Deadline", dtpDeadline.Value.Date);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Assignment Updated Successfully. CourseID: " + courseId);

                LoadAssignments();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Please select assignment first.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = "DELETE FROM Assignments WHERE AssignmentID=@AssignmentID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AssignmentID", selectedAssignmentId);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Assignment Deleted Successfully");

                LoadAssignments();
                ClearFields();
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
                selectedAssignmentId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["AssignmentID"].Value);

                cmbCourse.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CourseID"].Value);
                txtTitle.Text = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                dtpDeadline.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Deadline"].Value);
            }
        }

        private void ClearFields()
        {
            selectedAssignmentId = 0;
            txtTitle.Text = "";
            txtDescription.Text = "";
            dtpDeadline.Value = DateTime.Now;

            if (cmbCourse.Items.Count > 0)
            {
                cmbCourse.SelectedIndex = 0;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}