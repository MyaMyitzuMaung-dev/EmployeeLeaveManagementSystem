using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace IPB2.EmployeeLeaveMS.BusinessLogic.Features.Reports
{
    public class ReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        // 1. Monthly Leave Report
        public async Task<MonthlyLeaveReportResponseModel> GetMonthlyLeaveReportAsync(MonthlyLeaveReportRequestModel request)
        {
            var leaves = await _context.LeaveRequests
                .Include(x => x.Employee)
                .Include(x => x.LeaveType)
                .Where(x => !x.IsDeleted
                            && x.Status == "Approved"
                            && x.StartDate.Month == request.Month
                            && x.StartDate.Year == request.Year)
                .Select(x => new MonthlyLeaveReportDto
                {
                    EmployeeName = x.Employee.EmployeeName,
                    EmployeeCode = x.Employee.EmployeeCode,
                    Department = x.Employee.Department,
                    Position = x.Employee.Position,
                    LeaveTypeName = x.LeaveType.LeaveTypeName,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    TotalDays = x.TotalDays,
                    Status = x.Status
                })
                .ToListAsync();

            return new MonthlyLeaveReportResponseModel
            {
                IsSuccess = true,
                Message = "Monthly leave report generated",
                Leaves = leaves
            };
        }

        // 2. Employee Leave Summary
        public async Task<EmployeeLeaveSummaryResponseModel> GetEmployeeLeaveSummaryAsync(EmployeeLeaveSummaryRequestModel request)
        {
            var query = _context.Employees
                .Include(x => x.LeaveRequests.Where(lr => !lr.IsDeleted && lr.Status == "Approved"))
                .ThenInclude(lr => lr.LeaveType)
                .AsQueryable();

            if (request.EmployeeId.HasValue)
                query = query.Where(e => e.EmployeeId == request.EmployeeId.Value);

            var summary = await query.SelectMany(e => e.LeaveRequests)
                .GroupBy(lr => new { lr.Employee.EmployeeName, lr.Employee.EmployeeCode, lr.Employee.Department, lr.LeaveType.LeaveTypeName, lr.LeaveType.MaxDaysPerYear })
                .Select(g => new EmployeeLeaveSummaryDto
                {
                    EmployeeName = g.Key.EmployeeName,
                    EmployeeCode = g.Key.EmployeeCode,
                    Department = g.Key.Department,
                    LeaveTypeName = g.Key.LeaveTypeName,
                    TotalLeavesTaken = g.Sum(x => x.TotalDays),
                    MaxLeaves = g.Key.MaxDaysPerYear
                })
                .ToListAsync();

            return new EmployeeLeaveSummaryResponseModel
            {
                IsSuccess = true,
                Message = "Employee leave summary generated",
                Summary = summary
            };
        }
    }
}
