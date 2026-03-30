using IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ReportHttpClientService _service;

        public ReportsController(ReportHttpClientService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MonthlyReport(int year, int month)
        {
            if (year == 0) year = DateTime.Now.Year;
            if (month == 0) month = DateTime.Now.Month;

            var result = await _service.GetMonthlyLeaveReportAsync(year, month);
            return View(result);
        }

        public async Task<IActionResult> EmployeeSummary(int? employeeId)
        {
            var result = await _service.GetEmployeeLeaveSummaryAsync(employeeId);
            return View(result);
        }
    }
}
