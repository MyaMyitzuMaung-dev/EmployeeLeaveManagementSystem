using IPB2.EmployeeLeaveMS.WebApi.Features.Employees;
using IPB2.EmployeeLeaveMS.WebApi.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.WebApi.Features.LeaveRequests;

namespace IPB2.EmployeeLeaveMS.WinForm.Features.LeaveApprovals
{
    public partial class ApprovalForm : Form
    {
        private readonly LeaveApprovalService _approvalService;
        private readonly LeaveRequestService _requestService;
        private readonly EmployeeService _employeeService;

        public ApprovalForm(LeaveApprovalService approvalService, LeaveRequestService requestService, EmployeeService employeeService)
        {
            _approvalService = approvalService;
            _requestService = requestService;
            _employeeService = employeeService;
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            var requests = await _requestService.GetAllAsync(new LeaveRequestListRequestModel { PageNo = 1, PageSize = 100 });
            cboRequest.DataSource = requests.LeaveRequests.Where(x => x.Status == "Pending").ToList();
            cboRequest.DisplayMember = "LeaveRequestId";
            cboRequest.ValueMember = "LeaveRequestId";

            var employees = await _employeeService.GetAllAsync(new EmployeeListRequestModel { PageNumber = 1, PageSize = 100 });
            cboApprover.DataSource = employees.Employees;
            cboApprover.DisplayMember = "EmployeeName";
            cboApprover.ValueMember = "EmployeeId";

            LoadApprovals();
        }

        private async void LoadApprovals()
        {
            var res = await _approvalService.GetAllAsync(new LeaveApprovalListRequestModel { PageNo = 1, PageSize = 100 });
            dgvApprovals.DataSource = res.Approvals;
        }

        private async void btnApprove_Click(object sender, EventArgs e) => await SubmitApproval("Approved");
        private async void btnReject_Click(object sender, EventArgs e) => await SubmitApproval("Rejected");

        private async Task SubmitApproval(string status)
        {
            if (cboRequest.SelectedValue == null || cboApprover.SelectedValue == null) return;

            var request = new LeaveApprovalCreateRequestModel
            {
                LeaveRequestId = (int)cboRequest.SelectedValue,
                ApprovedBy = (int)cboApprover.SelectedValue,
                ApprovalStatus = status,
                Comments = txtComments.Text
            };

            var res = await _approvalService.ApproveAsync(request);
            MessageBox.Show(res.Message);
            LoadData();
        }
    }
}
