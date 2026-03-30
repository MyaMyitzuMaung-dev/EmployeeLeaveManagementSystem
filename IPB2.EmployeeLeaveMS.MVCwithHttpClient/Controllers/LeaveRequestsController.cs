using IPB2.EmployeeLeaveMS.Domain.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly LeaveRequestHttpClientService _service;
        private readonly EmployeeHttpClientService _employeeService;
        private readonly LeaveTypeHttpClientService _leaveTypeService;

        public LeaveRequestsController(LeaveRequestHttpClientService service, EmployeeHttpClientService employeeService, LeaveTypeHttpClientService leaveTypeService)
        {
            _service = service;
            _employeeService = employeeService;
            _leaveTypeService = leaveTypeService;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            var result = await _service.GetAllAsync(pageNo, pageSize);
            return View(result);
        }

        public IActionResult Create()
        {
            // Usually we'd load dropdowns here
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.CreateAsync(request);
                if (result != null && result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result?.Message ?? "Failed to create leave request");
            }
            return View(request);
        }

        public async Task<IActionResult> EditStatus(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null || !result.IsSuccess)
            {
                return NotFound();
            }

            var statusModel = new LeaveRequestUpdateStatusRequestModel
            {
                LeaveRequestId = result.LeaveRequestId,
                Status = result.Status
            };

            return View(statusModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStatus(LeaveRequestUpdateStatusRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateStatusAsync(request);
                if (result != null && result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result?.Message ?? "Failed to update status");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Json(result);
        }
    }
}
