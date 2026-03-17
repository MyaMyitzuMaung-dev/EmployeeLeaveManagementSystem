using IPB2.EmployeeLeaveMS.WinForm.Features.Employees;
using IPB2.EmployeeLeaveMS.WinForm.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.WinForm.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.WinForm.Features.LeaveTypes;
using IPB2.EmployeeLeaveMS.WinForm.Features.Reports;
using Microsoft.Extensions.DependencyInjection;

namespace IPB2.EmployeeLeaveMS.WinForm
{
    public partial class DashboardForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public DashboardForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            btnEmployees.Click += (s, e) => OpenForm<EmployeeForm>();
            btnLeaveTypes.Click += (s, e) => OpenForm<LeaveTypeForm>();
            btnRequests.Click += (s, e) => OpenForm<LeaveRequestForm>();
            btnApprovals.Click += (s, e) => OpenForm<ApprovalForm>();
            btnReports.Click += (s, e) => OpenForm<ReportForm>();
        }

        private void OpenForm<T>() where T : Form
        {
            // Create a new scope for the form
            var scope = _serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<T>();

            // Ensure the scope is disposed when the form is closed
            form.FormClosed += (s, e) => scope.Dispose();

            form.Show();
        }
    }
}
