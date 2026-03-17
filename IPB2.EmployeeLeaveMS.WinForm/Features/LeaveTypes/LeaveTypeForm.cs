using IPB2.EmployeeLeaveMS.WebApi.Features.LeaveTypes;

namespace IPB2.EmployeeLeaveMS.WinForm.Features.LeaveTypes
{
    public partial class LeaveTypeForm : Form
    {
        private readonly LeaveTypeService _service;

        public LeaveTypeForm(LeaveTypeService service)
        {
            _service = service;
            InitializeComponent();
            LoadLeaveTypes();
        }

        private async void LoadLeaveTypes()
        {
            var res = await _service.GetAllAsync(new LeaveTypeListRequestModel { PageNo = 1, PageSize = 100 });
            dgvLeaveTypes.DataSource = res.LeaveTypes;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = new LeaveTypeCreateRequestModel
            {
                LeaveTypeName = txtName.Text,
                Description = txtDescription.Text,
                MaxDaysPerYear = (int)numMaxDays.Value
            };

            var res = await _service.CreateAsync(request);
            MessageBox.Show(res.Message);
            LoadLeaveTypes();
        }
    }
}
