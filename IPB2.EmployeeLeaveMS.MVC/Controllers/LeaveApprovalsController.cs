using IPB2.EmployeeLeaveMS.BusinessLogic.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.BusinessLogic.Features.LeaveRequests;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.MVC.Controllers
{
    public class LeaveApprovalsController : Controller
    {
        private readonly LeaveApprovalService _leaveApprovalService;
        private readonly LeaveRequestService _leaveRequestService;

        public LeaveApprovalsController(
            LeaveApprovalService leaveApprovalService,
            LeaveRequestService leaveRequestService)
        {
            _leaveApprovalService = leaveApprovalService;
            _leaveRequestService = leaveRequestService;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            var response = await _leaveApprovalService.GetAllAsync(new LeaveApprovalListRequestModel { PageNo = pageNo, PageSize = pageSize });
            return View(response);
        }

        public async Task<IActionResult> Pending()
        {
            var requests = await _leaveRequestService.GetAllAsync(new LeaveRequestListRequestModel { PageNo = 1, PageSize = 100 });
            var pendingRequests = requests.LeaveRequests.Where(r => r.Status == "Pending").ToList();
            return View(pendingRequests);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(LeaveApprovalCreateRequestModel request)
        {
            request.ApprovalStatus = "Approved";
            var response = await _leaveApprovalService.ApproveAsync(request);
            
            if (response.IsSuccess)
            {
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction(nameof(Pending));
            }

            TempData["ErrorMessage"] = response.Message;
            return RedirectToAction(nameof(Pending));
        }

        [HttpPost]
        public async Task<IActionResult> Reject(LeaveApprovalCreateRequestModel request)
        {
            request.ApprovalStatus = "Rejected";
            var response = await _leaveApprovalService.ApproveAsync(request);

            if (response.IsSuccess)
            {
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction(nameof(Pending));
            }

            TempData["ErrorMessage"] = response.Message;
            return RedirectToAction(nameof(Pending));
        }
    }
}
