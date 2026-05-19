namespace WindowsFormsApp1
{
    partial class StudentDashboard
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
            this.btnViewCourses = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnNotices = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMyCourses = new System.Windows.Forms.Button();
            this.btnAssignments = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewCourses
            // 
            this.btnViewCourses.Location = new System.Drawing.Point(579, 246);
            this.btnViewCourses.Name = "btnViewCourses";
            this.btnViewCourses.Size = new System.Drawing.Size(138, 50);
            this.btnViewCourses.TabIndex = 0;
            this.btnViewCourses.Text = "View Courses";
            this.btnViewCourses.UseVisualStyleBackColor = true;
            this.btnViewCourses.Click += new System.EventHandler(this.btnViewCourses_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(579, 336);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(138, 49);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.Text = "My Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnNotices
            // 
            this.btnNotices.Location = new System.Drawing.Point(579, 427);
            this.btnNotices.Name = "btnNotices";
            this.btnNotices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNotices.Size = new System.Drawing.Size(138, 48);
            this.btnNotices.TabIndex = 2;
            this.btnNotices.Text = "Notices";
            this.btnNotices.UseVisualStyleBackColor = true;
            this.btnNotices.Click += new System.EventHandler(this.btnNotices_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(794, 430);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(160, 45);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMyCourses
            // 
            this.btnMyCourses.Location = new System.Drawing.Point(794, 246);
            this.btnMyCourses.Name = "btnMyCourses";
            this.btnMyCourses.Size = new System.Drawing.Size(160, 50);
            this.btnMyCourses.TabIndex = 4;
            this.btnMyCourses.Text = "My Courses";
            this.btnMyCourses.UseVisualStyleBackColor = true;
            this.btnMyCourses.Click += new System.EventHandler(this.btnMyCourses_Click);
            // 
            // btnAssignments
            // 
            this.btnAssignments.Location = new System.Drawing.Point(794, 336);
            this.btnAssignments.Name = "btnAssignments";
            this.btnAssignments.Size = new System.Drawing.Size(160, 50);
            this.btnAssignments.TabIndex = 5;
            this.btnAssignments.Text = "Assignments";
            this.btnAssignments.UseVisualStyleBackColor = true;
            this.btnAssignments.Click += new System.EventHandler(this.btnAssignments_Click);
            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 819);
            this.Controls.Add(this.btnAssignments);
            this.Controls.Add(this.btnMyCourses);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnNotices);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnViewCourses);
            this.Name = "StudentDashboard";
            this.Text = "StudentDashboard";
            this.Load += new System.EventHandler(this.StudentDashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewCourses;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnNotices;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMyCourses;
        private System.Windows.Forms.Button btnAssignments;
    }
}