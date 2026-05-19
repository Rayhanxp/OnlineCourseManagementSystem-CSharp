using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PaymentForm : Form
    {
        int courseId;
        string courseTitle;
        decimal amount;

        public PaymentForm(int selectedCourseId, string selectedCourseTitle, decimal courseAmount)
        {
            InitializeComponent();

            courseId = selectedCourseId;
            courseTitle = selectedCourseTitle;
            amount = courseAmount;

            lblCourse.Text = "Course: " + courseTitle;
            lblAmount.Text = "Amount: " + amount.ToString();

            cmbPaymentMethod.Items.Add("Bkash");
            cmbPaymentMethod.Items.Add("Nagad");
            cmbPaymentMethod.Items.Add("Card");
            cmbPaymentMethod.Items.Add("Cash");
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            if (cmbPaymentMethod.Text == "")
            {
                MessageBox.Show("Please select payment method.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string payQuery = @"INSERT INTO Payments 
                                    (UserId, CourseID, Amount, PaymentMethod)
                                    VALUES 
                                    (@UserId, @CourseID, @Amount, @PaymentMethod)";

                SqlCommand payCmd = new SqlCommand(payQuery, con);
                payCmd.Parameters.AddWithValue("@UserId", Session.UserId);
                payCmd.Parameters.AddWithValue("@CourseID", courseId);
                payCmd.Parameters.AddWithValue("@Amount", amount);
                payCmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text);
                payCmd.ExecuteNonQuery();

                string enrollQuery = @"INSERT INTO Enrollments 
                                       (UserId, CourseID)
                                       VALUES 
                                       (@UserId, @CourseID)";

                SqlCommand enrollCmd = new SqlCommand(enrollQuery, con);
                enrollCmd.Parameters.AddWithValue("@UserId", Session.UserId);
                enrollCmd.Parameters.AddWithValue("@CourseID", courseId);
                enrollCmd.ExecuteNonQuery();

                MessageBox.Show("Payment successful and course enrolled.");
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}