using IPB2.EmployeeLeaveMS.BusinessLogic.Features.Employees;

namespace IPB2.EmployeeLeaveMS.WinForm.Features.Employees
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeService _service;

        public EmployeeForm(EmployeeService service)
        {
            _service = service;
            InitializeComponent();
            LoadEmployees();
        }

        private async void LoadEmployees()
        {
            var res = await _service.GetAllAsync(new EmployeeListRequestModel { PageNumber = 1, PageSize = 100 });
            dgvEmployees.DataSource = res.Employees;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = new EmployeeCreateRequestModel
            {
                EmployeeCode = txtCode.Text,
                EmployeeName = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Department = txtDept.Text,
                Position = txtPos.Text,
                JoinDate = DateOnly.FromDateTime(dtpJoinDate.Value)
            };

            var res = await _service.CreateAsync(request);
            MessageBox.Show(res.Message);
            LoadEmployees();
        }
    }
}
