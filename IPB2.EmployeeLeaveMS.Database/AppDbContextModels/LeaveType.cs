using System;
using System.Collections.Generic;

namespace IPB2.EmployeeLeaveMS.Database.AppDbContextModels;

public partial class LeaveType
{
    public int LeaveTypeId { get; set; }

    public string LeaveTypeName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int MaxDaysPerYear { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
}
