using IPB2.EmployeeLeaveMS.BusinessLogic.Features.Employees;
using IPB2.EmployeeLeaveMS.BusinessLogic.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.BusinessLogic.Features.LeaveTypes;

namespace IPB2.EmployeeLeaveMS.WinForm.Features.LeaveRequests
{
    public partial class LeaveRequestForm : Form
    {
        private readonly LeaveRequestService _leaveRequestService;
        private readonly EmployeeService _employeeService;
        private readonly LeaveTypeService _leaveTypeService;

        public LeaveRequestForm(LeaveRequestService leaveRequestService, EmployeeService employeeService, LeaveTypeService leaveTypeService)
        {
            _leaveRequestService = leaveRequestService;
            _employeeService = employeeService;
            _leaveTypeService = leaveTypeService;
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            var employees = await _employeeService.GetAllAsync(new EmployeeListRequestModel { PageNumber = 1, PageSize = 100 });
            cboEmployee.DataSource = employees.Employees;
            cboEmployee.DisplayMember = "EmployeeName";
            cboEmployee.ValueMember = "EmployeeId";

            var leaveTypes = await _leaveTypeService.GetAllAsync(new LeaveTypeListRequestModel { PageNo = 1, PageSize = 100 });
            cboLeaveType.DataSource = leaveTypes.LeaveTypes;
            cboLeaveType.DisplayMember = "LeaveTypeName";
            cboLeaveType.ValueMember = "LeaveTypeId";

            LoadRequests();
        }

        private async void LoadRequests()
        {
            var res = await _leaveRequestService.GetAllAsync(new LeaveRequestListRequestModel { PageNo = 1, PageSize = 100 });
            dgvRequests.DataSource = res.LeaveRequests;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = new LeaveRequestCreateRequestModel
            {
                EmployeeId = (int)cboEmployee.SelectedValue!,
                LeaveTypeId = (int)cboLeaveType.SelectedValue!,
                StartDate = DateOnly.FromDateTime(dtpStart.Value),
                EndDate = DateOnly.FromDateTime(dtpEnd.Value),
                Reason = txtReason.Text
            };

            var res = await _leaveRequestService.CreateAsync(request);
            MessageBox.Show(res.Message);
            LoadRequests();
        }
    }
}
