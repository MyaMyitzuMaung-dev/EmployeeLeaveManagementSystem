namespace IPB2.EmployeeLeaveMS.WinForm.Features.Reports
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvReports;
        private NumericUpDown numMonth;
        private NumericUpDown numYear;
        private Button btnMonthlyReport;
        private Button btnSummaryReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvReports = new DataGridView();
            numMonth = new NumericUpDown();
            numYear = new NumericUpDown();
            btnMonthlyReport = new Button();
            btnSummaryReport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            SuspendLayout();

            dgvReports.Location = new Point(12, 100);
            dgvReports.Size = new Size(776, 338);

            numMonth.Location = new Point(12, 20);
            numMonth.Value = DateTime.Now.Month;
            numMonth.Minimum = 1;
            numMonth.Maximum = 12;

            numYear.Location = new Point(100, 20);
            numYear.Value = DateTime.Now.Year;
            numYear.Minimum = 2000;
            numYear.Maximum = 2100;

            btnMonthlyReport.Location = new Point(200, 20);
            btnMonthlyReport.Text = "Monthly Report";
            btnMonthlyReport.Click += btnMonthlyReport_Click;

            btnSummaryReport.Location = new Point(350, 20);
            btnSummaryReport.Text = "Summary Report";
            btnSummaryReport.Click += btnSummaryReport_Click;

            ClientSize = new Size(800, 450);
            Controls.Add(dgvReports);
            Controls.Add(numMonth);
            Controls.Add(numYear);
            Controls.Add(btnMonthlyReport);
            Controls.Add(btnSummaryReport);
            Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ResumeLayout(false);
        }
    }
}
