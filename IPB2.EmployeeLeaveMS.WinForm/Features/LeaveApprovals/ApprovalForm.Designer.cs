namespace IPB2.EmployeeLeaveMS.WinForm.Features.LeaveApprovals
{
    partial class ApprovalForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvApprovals;
        private ComboBox cboRequest;
        private ComboBox cboApprover;
        private TextBox txtComments;
        private Button btnApprove;
        private Button btnReject;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvApprovals = new DataGridView();
            cboRequest = new ComboBox();
            cboApprover = new ComboBox();
            txtComments = new TextBox();
            btnApprove = new Button();
            btnReject = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvApprovals).BeginInit();
            SuspendLayout();

            dgvApprovals.Location = new Point(12, 200);
            dgvApprovals.Size = new Size(776, 238);
            dgvApprovals.Name = "dgvApprovals";

            cboRequest.Location = new Point(120, 20);
            cboRequest.Name = "cboRequest";

            cboApprover.Location = new Point(120, 50);
            cboApprover.Name = "cboApprover";

            txtComments.Location = new Point(120, 80);
            txtComments.Name = "txtComments";

            btnApprove.Location = new Point(120, 110);
            btnApprove.Text = "Approve";
            btnApprove.Click += btnApprove_Click;

            btnReject.Location = new Point(200, 110);
            btnReject.Text = "Reject";
            btnReject.Click += btnReject_Click;

            ClientSize = new Size(800, 450);
            Controls.Add(dgvApprovals);
            Controls.Add(cboRequest);
            Controls.Add(cboApprover);
            Controls.Add(txtComments);
            Controls.Add(btnApprove);
            Controls.Add(btnReject);
            Text = "Approvals";
            ((System.ComponentModel.ISupportInitialize)dgvApprovals).EndInit();
            ResumeLayout(false);
        }
    }
}
