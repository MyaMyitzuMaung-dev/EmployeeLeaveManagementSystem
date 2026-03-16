using System;
using System.Collections.Generic;

namespace IPB2.EmployeeLeaveMS.Database.AppDbContextModels;

public partial class LeaveRequest
{
    public int LeaveRequestId { get; set; }

    public int EmployeeId { get; set; }

    public int LeaveTypeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int TotalDays { get; set; }

    public string Reason { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime AppliedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<LeaveApproval> LeaveApprovals { get; set; } = new List<LeaveApproval>();

    public virtual LeaveType LeaveType { get; set; } = null!;
}
