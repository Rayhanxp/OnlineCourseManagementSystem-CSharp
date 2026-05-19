namespace WindowsFormsApp1
{
    partial class AdminDashboard
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
            this.btnManageCourses = new System.Windows.Forms.Button();
            this.btnManageAssignments = new System.Windows.Forms.Button();
            this.btnManageNotices = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageCourses
            // 
            this.btnManageCourses.Location = new System.Drawing.Point(602, 297);
            this.btnManageCourses.Name = "btnManageCourses";
            this.btnManageCourses.Size = new System.Drawing.Size(180, 34);
            this.btnManageCourses.TabIndex = 0;
            this.btnManageCourses.Text = "Manage Courses";
            this.btnManageCourses.UseVisualStyleBackColor = true;
            this.btnManageCourses.Click += new System.EventHandler(this.btnManageCourses_Click);
            // 
            // btnManageAssignments
            // 
            this.btnManageAssignments.Location = new System.Drawing.Point(834, 297);
            this.btnManageAssignments.Name = "btnManageAssignments";
            this.btnManageAssignments.Size = new System.Drawing.Size(180, 41);
            this.btnManageAssignments.TabIndex = 1;
            this.btnManageAssignments.Text = "Manage Assignments";
            this.btnManageAssignments.UseVisualStyleBackColor = true;
            this.btnManageAssignments.Click += new System.EventHandler(this.btnManageAssignments_Click);
            // 
            // btnManageNotices
            // 
            this.btnManageNotices.Location = new System.Drawing.Point(602, 420);
            this.btnManageNotices.Name = "btnManageNotices";
            this.btnManageNotices.Size = new System.Drawing.Size(180, 41);
            this.btnManageNotices.TabIndex = 2;
            this.btnManageNotices.Text = "Manage Notices";
            this.btnManageNotices.UseVisualStyleBackColor = true;
            this.btnManageNotices.Click += new System.EventHandler(this.btnManageNotices_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(834, 420);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 41);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 829);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageNotices);
            this.Controls.Add(this.btnManageAssignments);
            this.Controls.Add(this.btnManageCourses);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageCourses;
        private System.Windows.Forms.Button btnManageAssignments;
        private System.Windows.Forms.Button btnManageNotices;
        private System.Windows.Forms.Button btnLogout;
    }
}