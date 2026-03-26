namespace IPB2.EmployeeLeaveMS.BusinessLogic.Features.LeaveApprovals;

// CREATE APPROVAL
public class LeaveApprovalCreateRequestModel
{
    public int LeaveRequestId { get; set; }
    public int ApprovedBy { get; set; } // manager/admin EmployeeId
    public string ApprovalStatus { get; set; } // Approved / Rejected
    public string Comments { get; set; }
}

public class LeaveApprovalCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int ApprovalId { get; set; }
}

// DELETE (soft delete)
public class LeaveApprovalDeleteRequestModel
{
    public int ApprovalId { get; set; }
}

public class LeaveApprovalDeleteResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

// LIST (with pagination)
public class LeaveApprovalListRequestModel
{
    public int PageNo { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class LeaveApprovalListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int TotalCount { get; set; }
    public List<LeaveApprovalDto> Approvals { get; set; }
}

public class LeaveApprovalDto
{
    public int ApprovalId { get; set; }
    public int LeaveRequestId { get; set; }
    public int ApprovedBy { get; set; }
    public string ApproverName { get; set; }
    public string ApprovalStatus { get; set; }
    public string Comments { get; set; }
    public DateTime ApprovalDate { get; set; }
    public string EmployeeName { get; set; }
    public string LeaveTypeName { get; set; }
}
