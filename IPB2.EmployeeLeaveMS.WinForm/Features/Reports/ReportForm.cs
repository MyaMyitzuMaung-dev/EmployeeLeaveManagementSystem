using IPB2.EmployeeLeaveMS.Domain.Features.Reports;

namespace IPB2.EmployeeLeaveMS.WinForm.Features.Reports
{
    public partial class ReportForm : Form
    {
        private readonly ReportService _reportService;

        public ReportForm(ReportService reportService)
        {
            _reportService = reportService;
            InitializeComponent();
        }

        private async void btnMonthlyReport_Click(object sender, EventArgs e)
        {
            var res = await _reportService.GetMonthlyLeaveReportAsync(new MonthlyLeaveReportRequestModel 
            { 
                Month = (int)numMonth.Value, 
                Year = (int)numYear.Value 
            });
            dgvReports.DataSource = res.Leaves;
        }

        private async void btnSummaryReport_Click(object sender, EventArgs e)
        {
            var res = await _reportService.GetEmployeeLeaveSummaryAsync(new EmployeeLeaveSummaryRequestModel());
            dgvReports.DataSource = res.Summary;
        }
    }
}
