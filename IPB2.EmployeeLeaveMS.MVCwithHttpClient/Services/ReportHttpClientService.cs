using IPB2.EmployeeLeaveMS.Domain.Features.Reports;

namespace IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services
{
    public class ReportHttpClientService : BaseHttpClientService
    {
        public ReportHttpClientService(HttpClient httpClient, IConfiguration configuration) 
            : base(httpClient, configuration)
        {
        }

        public async Task<MonthlyLeaveReportResponseModel?> GetMonthlyLeaveReportAsync(int year, int month)
        {
            return await GetAsync<MonthlyLeaveReportResponseModel>($"Report/monthly-leave?year={year}&month={month}");
        }

        public async Task<EmployeeLeaveSummaryResponseModel?> GetEmployeeLeaveSummaryAsync(int? employeeId)
        {
            return await GetAsync<EmployeeLeaveSummaryResponseModel>($"Report/employee-summary?employeeId={employeeId}");
        }
    }
}
