namespace IPB2.EmployeeLeaveMS.WebApi.Features.LeaveRequests;

// CREATE
public class LeaveRequestCreateRequestModel
{
    public int EmployeeId { get; set; }
    public int LeaveTypeId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Reason { get; set; }
}

public class LeaveRequestCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int LeaveRequestId { get; set; }
}

// UPDATE STATUS
public class LeaveRequestUpdateStatusRequestModel
{
    public int LeaveRequestId { get; set; }
    public string Status { get; set; } // Approved / Rejected
}

public class LeaveRequestUpdateStatusResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

// DELETE (soft delete)
public class LeaveRequestDeleteRequestModel
{
    public int LeaveRequestId { get; set; }
}

public class LeaveRequestDeleteResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

// LIST (with pagination)
public class LeaveRequestListRequestModel
{
    public int PageNo { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class LeaveRequestListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int TotalCount { get; set; }
    public List<LeaveRequestDto> LeaveRequests { get; set; }
}

public class LeaveRequestDto
{
    public int LeaveRequestId { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public int LeaveTypeId { get; set; }
    public string LeaveTypeName { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int TotalDays { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
    public DateTime AppliedDate { get; set; }
}

// DETAIL
public class LeaveRequestDetailRequestModel
{
    public int LeaveRequestId { get; set; }
}

public class LeaveRequestDetailResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public int LeaveRequestId { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public int LeaveTypeId { get; set; }
    public string LeaveTypeName { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int TotalDays { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
    public DateTime AppliedDate { get; set; }
}
