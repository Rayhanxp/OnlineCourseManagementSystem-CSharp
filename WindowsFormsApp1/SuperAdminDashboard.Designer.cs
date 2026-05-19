namespace WindowsFormsApp1
{
    partial class SuperAdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnManageCourses = new System.Windows.Forms.Button();
            this.btnManageAssignments = new System.Windows.Forms.Button();
            this.btnManageNotices = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Location = new System.Drawing.Point(583, 222);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(135, 45);
            this.btnManageUsers.TabIndex = 0;
            this.btnManageUsers.Text = "Manage Users ";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnManageCourses
            // 
            this.btnManageCourses.Location = new System.Drawing.Point(828, 222);
            this.btnManageCourses.Name = "btnManageCourses";
            this.btnManageCourses.Size = new System.Drawing.Size(135, 45);
            this.btnManageCourses.TabIndex = 1;
            this.btnManageCourses.Text = "Manage Courses";
            this.btnManageCourses.UseVisualStyleBackColor = true;
            this.btnManageCourses.Click += new System.EventHandler(this.btnManageCourses_Click);
            // 
            // btnManageAssignments
            // 
            this.btnManageAssignments.Location = new System.Drawing.Point(592, 356);
            this.btnManageAssignments.Name = "btnManageAssignments";
            this.btnManageAssignments.Size = new System.Drawing.Size(135, 45);
            this.btnManageAssignments.TabIndex = 2;
            this.btnManageAssignments.Text = "Manage Assignments";
            this.btnManageAssignments.UseVisualStyleBackColor = true;
            this.btnManageAssignments.Click += new System.EventHandler(this.btnManageAssignments_Click);
            // 
            // btnManageNotices
            // 
            this.btnManageNotices.Location = new System.Drawing.Point(828, 355);
            this.btnManageNotices.Name = "btnManageNotices";
            this.btnManageNotices.Size = new System.Drawing.Size(135, 46);
            this.btnManageNotices.TabIndex = 3;
            this.btnManageNotices.Text = "Manage Notices";
            this.btnManageNotices.UseVisualStyleBackColor = true;
            this.btnManageNotices.Click += new System.EventHandler(this.btnManageNotices_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(703, 478);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(135, 45);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // SuperAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 807);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageNotices);
            this.Controls.Add(this.btnManageAssignments);
            this.Controls.Add(this.btnManageCourses);
            this.Controls.Add(this.btnManageUsers);
            this.Name = "SuperAdminDashboard";
            this.Text = "SuperAdminDashboard";
            this.Load += new System.EventHandler(this.SuperAdminDashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnManageCourses;
        private System.Windows.Forms.Button btnManageAssignments;
        private System.Windows.Forms.Button btnManageNotices;
        private System.Windows.Forms.Button btnLogout;
    }
}