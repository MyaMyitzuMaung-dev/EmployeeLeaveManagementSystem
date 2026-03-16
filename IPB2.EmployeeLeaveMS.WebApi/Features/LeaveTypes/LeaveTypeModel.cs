namespace IPB2.EmployeeLeaveMS.WebApi.Features.LeaveTypes;

// CREATE
public class LeaveTypeCreateRequestModel
{
    public string LeaveTypeName { get; set; }
    public string Description { get; set; }
    public int MaxDaysPerYear { get; set; }
}

public class LeaveTypeCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int LeaveTypeId { get; set; }
}

// UPDATE
public class LeaveTypeUpdateRequestModel
{
    public int LeaveTypeId { get; set; }
    public string LeaveTypeName { get; set; }
    public string Description { get; set; }
    public int MaxDaysPerYear { get; set; }
}

public class LeaveTypeUpdateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

// DELETE
public class LeaveTypeDeleteRequestModel
{
    public int LeaveTypeId { get; set; }
}

public class LeaveTypeDeleteResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

// LIST
public class LeaveTypeListRequestModel
{
    public int PageNo { get; set; }
    public int PageSize { get; set; }
}

public class LeaveTypeListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public int TotalCount { get; set; }

    public List<LeaveTypeDto> LeaveTypes { get; set; }
}

public class LeaveTypeDto
{
    public int LeaveTypeId { get; set; }
    public string LeaveTypeName { get; set; }
    public string Description { get; set; }
    public int MaxDaysPerYear { get; set; }
}

// DETAIL
public class LeaveTypeDetailRequestModel
{
    public int LeaveTypeId { get; set; }
}

public class LeaveTypeDetailResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public int LeaveTypeId { get; set; }
    public string LeaveTypeName { get; set; }
    public string Description { get; set; }
    public int MaxDaysPerYear { get; set; }
}
