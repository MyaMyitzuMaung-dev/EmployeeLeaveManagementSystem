using IPB2.EmployeeLeaveMS.Domain.Features.Employees;
using IPB2.EmployeeLeaveMS.Domain.Features.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPB2.EmployeeLeaveMS.MVC.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ReportService _reportService;
        private readonly EmployeeService _employeeService;

        public ReportsController(ReportService reportService, EmployeeService employeeService)
        {
            _reportService = reportService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllAsync(new EmployeeListRequestModel { PageNumber = 1, PageSize = 100 });
            ViewBag.Employees = new SelectList(employees.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MonthlyReport(int year, int month)
        {
            var request = new MonthlyLeaveReportRequestModel { Year = year, Month = month };
            var response = await _reportService.GetMonthlyLeaveReportAsync(request);
            return PartialView("_MonthlyReportTable", response);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeSummary(int? employeeId)
        {
            var request = new EmployeeLeaveSummaryRequestModel { EmployeeId = employeeId };
            var response = await _reportService.GetEmployeeLeaveSummaryAsync(request);
            return PartialView("_EmployeeSummaryTable", response);
        }
    }
}
