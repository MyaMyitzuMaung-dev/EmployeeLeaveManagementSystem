using IPB2.EmployeeLeaveMS.Domain.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2.EmployeeLeaveMS.MVC.Controllers
{
    public class LeaveApprovalsController : Controller
    {
        private readonly LeaveApprovalService _leaveApprovalService;
        private readonly LeaveRequestService _leaveRequestService;
        private readonly AppDbContext _context;

        public LeaveApprovalsController(
            LeaveApprovalService leaveApprovalService,
            LeaveRequestService leaveRequestService,
            AppDbContext context)
        {
            _leaveApprovalService = leaveApprovalService;
            _leaveRequestService = leaveRequestService;
            _context = context;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            var response = await _leaveApprovalService.GetAllAsync(new LeaveApprovalListRequestModel { PageNo = pageNo, PageSize = pageSize });
            return View(response);
        }

        public async Task<IActionResult> Pending()
        {
            var employees = await _context.Employees.Where(e => !e.IsDeleted).Take(1).ToListAsync();
            ViewBag.DefaultApproverId = employees.FirstOrDefault()?.EmployeeId ?? 1;

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
