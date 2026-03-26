namespace IPB2.EmployeeLeaveMS.WinForm
{
    partial class DashboardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnLeaveTypes = new System.Windows.Forms.Button();
            this.btnRequests = new System.Windows.Forms.Button();
            this.btnApprovals = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(50, 50);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(200, 50);
            this.btnEmployees.TabIndex = 0;
            this.btnEmployees.Text = "Manage Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            // 
            // btnLeaveTypes
            // 
            this.btnLeaveTypes.Location = new System.Drawing.Point(50, 120);
            this.btnLeaveTypes.Name = "btnLeaveTypes";
            this.btnLeaveTypes.Size = new System.Drawing.Size(200, 50);
            this.btnLeaveTypes.TabIndex = 1;
            this.btnLeaveTypes.Text = "Manage Leave Types";
            this.btnLeaveTypes.UseVisualStyleBackColor = true;
            // 
            // btnRequests
            // 
            this.btnRequests.Location = new System.Drawing.Point(50, 190);
            this.btnRequests.Name = "btnRequests";
            this.btnRequests.Size = new System.Drawing.Size(200, 50);
            this.btnRequests.TabIndex = 2;
            this.btnRequests.Text = "Leave Requests";
            this.btnRequests.UseVisualStyleBackColor = true;
            // 
            // btnApprovals
            // 
            this.btnApprovals.Location = new System.Drawing.Point(50, 260);
            this.btnApprovals.Name = "btnApprovals";
            this.btnApprovals.Size = new System.Drawing.Size(200, 50);
            this.btnApprovals.TabIndex = 3;
            this.btnApprovals.Text = "Pending Approvals";
            this.btnApprovals.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(50, 330);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(200, 50);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "View Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnApprovals);
            this.Controls.Add(this.btnRequests);
            this.Controls.Add(this.btnLeaveTypes);
            this.Controls.Add(this.btnEmployees);
            this.Name = "DashboardForm";
            this.Text = "Employee Leave Management System - Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnEmployees;
        private Button btnLeaveTypes;
        private Button btnRequests;
        private Button btnApprovals;
        private Button btnReports;
    }
}
