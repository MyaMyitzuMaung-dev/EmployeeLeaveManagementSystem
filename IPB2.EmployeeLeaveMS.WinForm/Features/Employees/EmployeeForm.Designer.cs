namespace IPB2.EmployeeLeaveMS.WinForm.Features.Employees
{
    partial class EmployeeForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvEmployees;
        private TextBox txtCode;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtDept;
        private TextBox txtPos;
        private DateTimePicker dtpJoinDate;
        private Button btnSave;
        private Label lblCode;
        private Label lblName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvEmployees = new DataGridView();
            txtCode = new TextBox();
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtDept = new TextBox();
            txtPos = new TextBox();
            dtpJoinDate = new DateTimePicker();
            btnSave = new Button();
            lblCode = new Label();
            lblName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(12, 190);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.Size = new Size(776, 248);
            dgvEmployees.TabIndex = 0;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(100, 20);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(200, 23);
            txtCode.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(100, 50);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(100, 150);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(txtName);
            Controls.Add(txtCode);
            Controls.Add(dgvEmployees);
            Name = "EmployeeForm";
            Text = "Employee Management";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
