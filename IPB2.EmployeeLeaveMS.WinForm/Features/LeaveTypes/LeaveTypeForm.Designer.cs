namespace IPB2.EmployeeLeaveMS.WinForm.Features.LeaveTypes
{
    partial class LeaveTypeForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvLeaveTypes;
        private TextBox txtName;
        private TextBox txtDescription;
        private NumericUpDown numMaxDays;
        private Button btnSave;
        private Label lblName;
        private Label lblDescription;
        private Label lblMaxDays;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvLeaveTypes = new DataGridView();
            txtName = new TextBox();
            txtDescription = new TextBox();
            numMaxDays = new NumericUpDown();
            btnSave = new Button();
            lblName = new Label();
            lblDescription = new Label();
            lblMaxDays = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLeaveTypes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxDays).BeginInit();
            SuspendLayout();
            // 
            // dgvLeaveTypes
            // 
            dgvLeaveTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeaveTypes.Location = new Point(12, 190);
            dgvLeaveTypes.Name = "dgvLeaveTypes";
            dgvLeaveTypes.Size = new Size(776, 248);
            dgvLeaveTypes.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(120, 50);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 23);
            txtDescription.TabIndex = 2;
            // 
            // numMaxDays
            // 
            numMaxDays.Location = new Point(120, 80);
            numMaxDays.Name = "numMaxDays";
            numMaxDays.Size = new Size(120, 23);
            numMaxDays.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 110);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 23);
            lblName.Name = "lblName";
            lblName.Size = new Size(102, 15);
            lblName.Text = "Leave Type Name";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 53);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.Text = "Description";
            // 
            // lblMaxDays
            // 
            lblMaxDays.AutoSize = true;
            lblMaxDays.Location = new Point(12, 83);
            lblMaxDays.Name = "lblMaxDays";
            lblMaxDays.Size = new Size(105, 15);
            lblMaxDays.Text = "Max Days Per Year";
            // 
            // LeaveTypeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMaxDays);
            Controls.Add(lblDescription);
            Controls.Add(lblName);
            Controls.Add(btnSave);
            Controls.Add(numMaxDays);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            Controls.Add(dgvLeaveTypes);
            Name = "LeaveTypeForm";
            Text = "Leave Type Management";
            ((System.ComponentModel.ISupportInitialize)dgvLeaveTypes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxDays).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
