using IPB2.EmployeeLeaveMS.BusinessLogic.Features.Employees;
using IPB2.EmployeeLeaveMS.BusinessLogic.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.BusinessLogic.Features.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPB2.EmployeeLeaveMS.MVC.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly LeaveRequestService _leaveRequestService;
        private readonly EmployeeService _employeeService;
        private readonly LeaveTypeService _leaveTypeService;

        public LeaveRequestsController(
            LeaveRequestService leaveRequestService,
            EmployeeService employeeService,
            LeaveTypeService leaveTypeService)
        {
            _leaveRequestService = leaveRequestService;
            _employeeService = employeeService;
            _leaveTypeService = leaveTypeService;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            var response = await _leaveRequestService.GetAllAsync(new LeaveRequestListRequestModel { PageNo = pageNo, PageSize = pageSize });
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropDowns();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeaveRequestCreateRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropDowns();
                return View(request);
            }

            var response = await _leaveRequestService.CreateAsync(request);
            if (response.IsSuccess)
            {
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", response.Message);
            await PopulateDropDowns();
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _leaveRequestService.DeleteAsync(new LeaveRequestDeleteRequestModel { LeaveRequestId = id });
            return Json(response);
        }

        private async Task PopulateDropDowns()
        {
            var employees = await _employeeService.GetAllAsync(new EmployeeListRequestModel { PageNumber = 1, PageSize = 100 });
            var leaveTypes = await _leaveTypeService.GetAllAsync(new LeaveTypeListRequestModel { PageNo = 1, PageSize = 100 });

            ViewBag.Employees = new SelectList(employees.Employees, "EmployeeId", "EmployeeName");
            ViewBag.LeaveTypes = new SelectList(leaveTypes.LeaveTypes, "LeaveTypeId", "LeaveTypeName");
        }
    }
}
