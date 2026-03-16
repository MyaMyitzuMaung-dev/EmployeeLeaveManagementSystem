namespace IPB2.EmployeeLeaveMS.WebApi.Features.Reports;

public class MonthlyLeaveReportRequestModel
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int? DepartmentId { get; set; } // optional
}

public class MonthlyLeaveReportResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<MonthlyLeaveReportDto> Leaves { get; set; }
}

public class MonthlyLeaveReportDto
{
    public string EmployeeName { get; set; }
    public string EmployeeCode { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }
    public string LeaveTypeName { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int TotalDays { get; set; }
    public string Status { get; set; }
}
public class EmployeeLeaveSummaryRequestModel
{
    public int? EmployeeId { get; set; } // optional filter
}

public class EmployeeLeaveSummaryResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<EmployeeLeaveSummaryDto> Summary { get; set; }
}

public class EmployeeLeaveSummaryDto
{
    public string EmployeeName { get; set; }
    public string EmployeeCode { get; set; }
    public string Department { get; set; }
    public string LeaveTypeName { get; set; }
    public int TotalLeavesTaken { get; set; }
    public int MaxLeaves { get; set; } // from LeaveTypes.MaxDaysPerYear
    public int RemainingLeaves => MaxLeaves - TotalLeavesTaken;
}