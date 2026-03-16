using System;
using System.Collections.Generic;

namespace IPB2.EmployeeLeaveMS.Database.AppDbContextModels;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<LeaveApproval> LeaveApprovals { get; set; } = new List<LeaveApproval>();

    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
}
