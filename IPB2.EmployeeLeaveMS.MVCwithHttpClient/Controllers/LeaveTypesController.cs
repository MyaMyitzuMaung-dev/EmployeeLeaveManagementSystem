using IPB2.EmployeeLeaveMS.Domain.Features.LeaveTypes;
using IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly LeaveTypeHttpClientService _service;

        public LeaveTypesController(LeaveTypeHttpClientService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            var result = await _service.GetAllAsync(pageNo, pageSize);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.CreateAsync(request);
                if (result != null && result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result?.Message ?? "Failed to create leave type");
            }
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null || !result.IsSuccess)
            {
                return NotFound();
            }

            var editModel = new LeaveTypeUpdateRequestModel
            {
                LeaveTypeId = result.LeaveTypeId,
                LeaveTypeName = result.LeaveTypeName,
                Description = result.Description,
                MaxDaysPerYear = result.MaxDaysPerYear
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LeaveTypeUpdateRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(request);
                if (result != null && result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result?.Message ?? "Failed to update leave type");
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
