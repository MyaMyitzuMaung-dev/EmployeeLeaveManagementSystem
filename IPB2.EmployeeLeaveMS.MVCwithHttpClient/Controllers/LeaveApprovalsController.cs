using IPB2.EmployeeLeaveMS.Domain.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Controllers
{
    public class LeaveApprovalsController : Controller
    {
        private readonly LeaveApprovalHttpClientService _service;
        private readonly LeaveRequestHttpClientService _leaveRequestService;
        private readonly EmployeeHttpClientService _employeeService;

        public LeaveApprovalsController(
            LeaveApprovalHttpClientService service,
            LeaveRequestHttpClientService leaveRequestService,
            EmployeeHttpClientService employeeService)
        {
            _service = service;
            _leaveRequestService = leaveRequestService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            var result = await _service.GetAllAsync(pageNo, pageSize);
            return View(result);
        }

        public async Task<IActionResult> Pending()
        {
            // Fetch first employee as default approver for demo
            var employees = await _employeeService.GetAllAsync(1, 1);
            ViewBag.DefaultApproverId = employees?.Employees?.FirstOrDefault()?.EmployeeId ?? 1;

            var requests = await _leaveRequestService.GetAllAsync(1, 100);
            var pendingRequests = requests?.LeaveRequests?.Where(r => r.Status == "Pending").ToList() ?? new List<LeaveRequestDto>();
            return View(pendingRequests);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(LeaveApprovalCreateRequestModel request)
        {
            request.ApprovalStatus = "Approved";
            var result = await _service.ApproveAsync(request);
            
            if (result != null && result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction(nameof(Pending));
            }

            TempData["ErrorMessage"] = result?.Message ?? "Failed to approve request";
            return RedirectToAction(nameof(Pending));
        }

        [HttpPost]
        public async Task<IActionResult> Reject(LeaveApprovalCreateRequestModel request)
        {
            request.ApprovalStatus = "Rejected";
            var result = await _service.ApproveAsync(request);

            if (result != null && result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction(nameof(Pending));
            }

            TempData["ErrorMessage"] = result?.Message ?? "Failed to reject request";
            return RedirectToAction(nameof(Pending));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Json(result);
        }
    }
}
