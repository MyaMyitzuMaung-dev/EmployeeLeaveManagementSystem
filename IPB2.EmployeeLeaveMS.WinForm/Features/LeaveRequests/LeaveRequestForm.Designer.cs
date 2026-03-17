namespace IPB2.EmployeeLeaveMS.WinForm.Features.LeaveRequests
{
    partial class LeaveRequestForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvRequests;
        private ComboBox cboEmployee;
        private ComboBox cboLeaveType;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private TextBox txtReason;
        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvRequests = new DataGridView();
            cboEmployee = new ComboBox();
            cboLeaveType = new ComboBox();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            txtReason = new TextBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();

            dgvRequests.Location = new Point(12, 200);
            dgvRequests.Size = new Size(776, 238);
            dgvRequests.Name = "dgvRequests";

            cboEmployee.Location = new Point(120, 20);
            cboEmployee.Size = new Size(200, 23);
            cboEmployee.Name = "cboEmployee";

            cboLeaveType.Location = new Point(120, 50);
            cboLeaveType.Size = new Size(200, 23);
            cboLeaveType.Name = "cboLeaveType";

            dtpStart.Location = new Point(120, 80);
            dtpStart.Name = "dtpStart";

            dtpEnd.Location = new Point(120, 110);
            dtpEnd.Name = "dtpEnd";

            txtReason.Location = new Point(120, 140);
            txtReason.Name = "txtReason";

            btnSave.Location = new Point(120, 170);
            btnSave.Text = "Apply Leave";
            btnSave.Click += btnSave_Click;

            ClientSize = new Size(800, 450);
            Controls.Add(dgvRequests);
            Controls.Add(cboEmployee);
            Controls.Add(cboLeaveType);
            Controls.Add(dtpStart);
            Controls.Add(dtpEnd);
            Controls.Add(txtReason);
            Controls.Add(btnSave);
            Text = "Leave Requests";
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
        }
    }
}
