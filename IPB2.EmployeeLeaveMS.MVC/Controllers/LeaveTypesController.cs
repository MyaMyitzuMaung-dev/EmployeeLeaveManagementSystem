using IPB2.EmployeeLeaveMS.Domain.Features.LeaveTypes;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly LeaveTypeService _leaveTypeService;

        public LeaveTypesController(LeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            var request = new LeaveTypeListRequestModel { PageNo = pageNo, PageSize = pageSize };
            var response = await _leaveTypeService.GetAllAsync(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeaveTypeCreateRequestModel request)
        {
            if (!ModelState.IsValid) return View(request);

            var response = await _leaveTypeService.CreateAsync(request);
            if (response.IsSuccess)
            {
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", response.Message);
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var request = new LeaveTypeDetailRequestModel { LeaveTypeId = id };
            var response = await _leaveTypeService.GetByIdAsync(request);

            if (!response.IsSuccess) return NotFound();

            var updateRequest = new LeaveTypeUpdateRequestModel
            {
                LeaveTypeId = response.LeaveTypeId,
                LeaveTypeName = response.LeaveTypeName,
                MaxDaysPerYear = response.MaxDaysPerYear
            };

            return View(updateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LeaveTypeUpdateRequestModel request)
        {
            if (!ModelState.IsValid) return View(request);

            var response = await _leaveTypeService.UpdateAsync(request);
            if (response.IsSuccess)
            {
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", response.Message);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _leaveTypeService.DeleteAsync(new LeaveTypeDeleteRequestModel { LeaveTypeId = id });
            return Json(response);
        }
    }
}
