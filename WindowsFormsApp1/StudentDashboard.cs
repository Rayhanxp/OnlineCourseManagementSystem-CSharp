using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class StudentDashboard : Form
    {

        private void StyleButtons()
        {
            StyleButton(btnViewCourses);
            StyleButton(btnMyCourses);
            StyleButton(btnProfile);
            StyleButton(btnAssignments);
            StyleButton(btnNotices);
            StyleButton(btnLogout);

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
        public StudentDashboard()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            StyleButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnViewCourses_Click(object sender, EventArgs e)
        {
            StudentCoursesForm form = new StudentCoursesForm();
            form.Show();
        }

        private void btnNotices_Click(object sender, EventArgs e)
        {
            StudentNoticeForm form = new StudentNoticeForm();
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            MyProfileForm form = new MyProfileForm();
            form.Show();
        }

        

        private void btnMyCourses_Click(object sender, EventArgs e)
        {
            MyCoursesForm form = new MyCoursesForm();
            form.Show();
        }

        private void btnAssignments_Click(object sender, EventArgs e)
        {
            StudentAssignmentsForm form = new StudentAssignmentsForm();
            form.Show();
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
