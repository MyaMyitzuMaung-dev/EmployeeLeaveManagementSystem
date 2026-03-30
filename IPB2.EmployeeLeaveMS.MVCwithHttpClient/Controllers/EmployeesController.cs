using IPB2.EmployeeLeaveMS.Domain.Features.Employees;
using IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeHttpClientService _service;

        public EmployeesController(EmployeeHttpClientService service)
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
        public async Task<IActionResult> Create(EmployeeCreateRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.CreateAsync(request);
                if (result != null && result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result?.Message ?? "Failed to create employee");
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

            var editModel = new EmployeeEditRequestModel
            {
                EmployeeId = result.EmployeeId,
                EmployeeName = result.EmployeeName,
                Email = result.Email,
                Phone = result.Phone,
                Department = result.Department,
                Position = result.Position
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(request);
                if (result != null && result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result?.Message ?? "Failed to update employee");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(new EmployeeDeleteRequestModel { EmployeeId = id });
            return Json(result);
        }
    }
}
