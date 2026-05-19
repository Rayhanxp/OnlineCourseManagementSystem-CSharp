using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class ManageNoticesForm : Form
    {
        int selectedNoticeId = 0;

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


        public ManageNoticesForm()
        {
            InitializeComponent();
            LoadNotices();
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

        private void LoadNotices()
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Notices", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = "INSERT INTO Notices (Title, Description) VALUES (@Title, @Description)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Notice Added Successfully");
                LoadNotices();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedNoticeId == 0)
            {
                MessageBox.Show("Please select a notice first.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = "UPDATE Notices SET Title=@Title, Description=@Description WHERE NoticeID=@NoticeID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NoticeID", selectedNoticeId);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Notice Updated Successfully");
                LoadNotices();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedNoticeId == 0)
            {
                MessageBox.Show("Please select a notice first.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string query = "DELETE FROM Notices WHERE NoticeID=@NoticeID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NoticeID", selectedNoticeId);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Notice Deleted Successfully");
                LoadNotices();
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
                selectedNoticeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["NoticeID"].Value);
                txtTitle.Text = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            selectedNoticeId = 0;
            txtTitle.Text = "";
            txtDescription.Text = "";
        }

        private void ManageNoticesForm_Load(object sender, EventArgs e)
        {

        }
    }
}