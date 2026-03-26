using IPB2.EmployeeLeaveMS.BusinessLogic.Features.Employees;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            var request = new EmployeeListRequestModel
            {
                PageNumber = pageNo,
                PageSize = pageSize
            };
            var response = await _employeeService.GetAllAsync(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateRequestModel request)
        {
            if (!ModelState.IsValid) return View(request);

            var response = await _employeeService.CreateAsync(request);
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
            var request = new EmployeeDetailRequestModel { EmployeeId = id };
            var response = await _employeeService.GetByIdAsync(request);
            
            if (!response.IsSuccess) return NotFound();

            var editRequest = new EmployeeEditRequestModel
            {
                EmployeeId = response.EmployeeId,
                EmployeeName = response.EmployeeName,
                Email = response.Email,
                Phone = response.Phone,
                Department = response.Department,
                Position = response.Position
            };

            return View(editRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditRequestModel request)
        {
            if (!ModelState.IsValid) return View(request);

            var response = await _employeeService.UpdateAsync(request);
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
            var request = new EmployeeDeleteRequestModel { EmployeeId = id };
            var response = await _employeeService.DeleteAsync(request);
            
            return Json(response);
        }
    }
}
