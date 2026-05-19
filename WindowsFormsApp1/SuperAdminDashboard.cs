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
    public partial class SuperAdminDashboard : Form
    {

        private void StyleButtons()
        {
            StyleButton(btnManageUsers);
            StyleButton(btnManageCourses);
            StyleButton(btnManageAssignments);
            StyleButton(btnManageNotices);
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
        public SuperAdminDashboard()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            StyleButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUsersForm form = new ManageUsersForm();
            form.Show();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void btnManageCourses_Click(object sender, EventArgs e)
        {
            ManageCoursesForm form = new ManageCoursesForm();
            form.Show();
        }

        private void btnManageNotices_Click(object sender, EventArgs e)
        {
            ManageNoticesForm form = new ManageNoticesForm();
            form.Show();
        }

        private void btnManageAssignments_Click(object sender, EventArgs e)
        {
            ManageAssignmentsForm form = new ManageAssignmentsForm();
            form.Show();
        }

        private void SuperAdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
