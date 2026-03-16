using System;
using System.Collections.Generic;

namespace IPB2.EmployeeLeaveMS.Database.AppDbContextModels;

public partial class LeaveApproval
{
    public int ApprovalId { get; set; }

    public int LeaveRequestId { get; set; }

    public int ApprovedBy { get; set; }

    public string ApprovalStatus { get; set; } = null!;

    public DateTime ApprovalDate { get; set; }

    public string Comments { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual Employee ApprovedByNavigation { get; set; } = null!;

    public virtual LeaveRequest LeaveRequest { get; set; } = null!;
}
