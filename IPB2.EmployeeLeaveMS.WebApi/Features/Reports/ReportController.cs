using IPB2.EmployeeLeaveMS.BusinessLogic.Features.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.EmployeeLeaveMS.WebApi.Features.Reports
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _service;

        public ReportController(ReportService service)
        {
            _service = service;
        }

        [HttpGet("monthly-leave")]
        public async Task<IActionResult> MonthlyLeave(int year, int month)
        {
            var request = new MonthlyLeaveReportRequestModel { Year = year, Month = month };
            var result = await _service.GetMonthlyLeaveReportAsync(request);
            return Ok(result);
        }

        [HttpGet("employee-summary")]
        public async Task<IActionResult> EmployeeSummary(int? employeeId = null)
        {
            var request = new EmployeeLeaveSummaryRequestModel { EmployeeId = employeeId };
            var result = await _service.GetEmployeeLeaveSummaryAsync(request);
            return Ok(result);
        }
    }
}
