using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using IPB2.EmployeeLeaveMS.Domain.Features.Employees;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveTypes;
using IPB2.EmployeeLeaveMS.Domain.Features.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
    .AddScoped<EmployeeService>()
    .AddScoped<LeaveTypeService>()
    .AddScoped<LeaveRequestService>()
    .AddScoped<LeaveApprovalService>()
    .AddScoped<ReportService>()
    .BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var services = scope.ServiceProvider;

bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine("=== Employee Leave Management System (CLI) ===");
    Console.WriteLine("1. Employee Management");
    Console.WriteLine("2. Leave Type Management");
    Console.WriteLine("3. Leave Request Management");
    Console.WriteLine("4. Leave Approvals");
    Console.WriteLine("5. Reports");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");

    switch (Console.ReadLine())
    {
        case "1": await EmployeeMenu(services.GetRequiredService<EmployeeService>()); break;
        case "2": await LeaveTypeMenu(services.GetRequiredService<LeaveTypeService>()); break;
        case "3": await LeaveRequestMenu(services.GetRequiredService<LeaveRequestService>()); break;
        case "4": await LeaveApprovalMenu(services.GetRequiredService<LeaveApprovalService>()); break;
        case "5": await ReportMenu(services.GetRequiredService<ReportService>()); break;
        case "0": exit = true; break;
        default: Console.WriteLine("Invalid option. Press any key to continue..."); Console.ReadKey(); break;
    }
}

async Task EmployeeMenu(EmployeeService service)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Employee Management ---");
        Console.WriteLine("1. List Employees");
        Console.WriteLine("2. Create Employee");
        Console.WriteLine("3. Update Employee");
        Console.WriteLine("4. Delete Employee");
        Console.WriteLine("0. Back");
        Console.Write("Select: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "0": back = true; break;
            case "1":
                var listRes = await service.GetAllAsync(new EmployeeListRequestModel { PageNumber = 1, PageSize = 100 });
                Console.WriteLine("\nEmployees:");
                foreach (var e in listRes.Employees) Console.WriteLine($"{e.EmployeeId}: {e.EmployeeCode} - {e.EmployeeName} ({e.Position})");
                Console.WriteLine("\nPress any key..."); Console.ReadKey();
                break;
            case "2":
                Console.Write("Code: "); var code = Console.ReadLine();
                Console.Write("Name: "); var name = Console.ReadLine();
                Console.Write("Email: "); var email = Console.ReadLine();
                Console.Write("Phone: "); var phone = Console.ReadLine();
                Console.Write("Dept: "); var dept = Console.ReadLine();
                Console.Write("Pos: "); var pos = Console.ReadLine();
                var createRes = await service.CreateAsync(new EmployeeCreateRequestModel 
                { 
                    EmployeeCode = code!, EmployeeName = name!, Email = email!, Phone = phone!, 
                    Department = dept!, Position = pos!, JoinDate = DateOnly.FromDateTime(DateTime.Now) 
                });
                Console.WriteLine(createRes.Message + ". Press any key..."); Console.ReadKey();
                break;
            case "3":
                Console.Write("Employee ID to Update: "); if (!int.TryParse(Console.ReadLine(), out int editId)) break;
                Console.Write("New Name: "); var uName = Console.ReadLine();
                Console.Write("New Email: "); var uEmail = Console.ReadLine();
                var updateRes = await service.UpdateAsync(new EmployeeEditRequestModel { EmployeeId = editId, EmployeeName = uName!, Email = uEmail! });
                Console.WriteLine(updateRes.Message + ". Press any key..."); Console.ReadKey();
                break;
            case "4":
                Console.Write("Employee ID to Delete: "); if (!int.TryParse(Console.ReadLine(), out int delId)) break;
                var delRes = await service.DeleteAsync(new EmployeeDeleteRequestModel { EmployeeId = delId });
                Console.WriteLine(delRes.Message + ". Press any key..."); Console.ReadKey();
                break;
        }
    }
}

async Task LeaveTypeMenu(LeaveTypeService service)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Leave Type Management ---");
        Console.WriteLine("1. List Leave Types");
        Console.WriteLine("2. Create Leave Type");
        Console.WriteLine("3. Update Leave Type");
        Console.WriteLine("4. Delete Leave Type");
        Console.WriteLine("0. Back");
        Console.Write("Select: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "0": back = true; break;
            case "1":
                var listRes = await service.GetAllAsync(new LeaveTypeListRequestModel { PageNo = 1, PageSize = 100 });
                foreach (var l in listRes.LeaveTypes) Console.WriteLine($"{l.LeaveTypeId}: {l.LeaveTypeName} (Max: {l.MaxDaysPerYear} days)");
                Console.WriteLine("\nPress any key..."); Console.ReadKey();
                break;
            case "2":
                Console.Write("Name: "); var name = Console.ReadLine();
                Console.Write("Desc: "); var desc = Console.ReadLine();
                Console.Write("Max Days: "); int.TryParse(Console.ReadLine(), out int days);
                var createRes = await service.CreateAsync(new LeaveTypeCreateRequestModel { LeaveTypeName = name!, Description = desc!, MaxDaysPerYear = days });
                Console.WriteLine(createRes.Message + ". Press any key..."); Console.ReadKey();
                break;
            case "3":
                Console.Write("ID: "); int.TryParse(Console.ReadLine(), out int id);
                Console.Write("New Name: "); var uName = Console.ReadLine();
                var updateRes = await service.UpdateAsync(new LeaveTypeUpdateRequestModel { LeaveTypeId = id, LeaveTypeName = uName! });
                Console.WriteLine(updateRes.Message + ". Press any key..."); Console.ReadKey();
                break;
            case "4":
                Console.Write("ID: "); int.TryParse(Console.ReadLine(), out int dId);
                var delRes = await service.DeleteAsync(new LeaveTypeDeleteRequestModel { LeaveTypeId = dId });
                Console.WriteLine(delRes.Message + ". Press any key..."); Console.ReadKey();
                break;
        }
    }
}

async Task LeaveRequestMenu(LeaveRequestService service)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Leave Request Management ---");
        Console.WriteLine("1. List Requests");
        Console.WriteLine("2. Create Request");
        Console.WriteLine("3. Update Status");
        Console.WriteLine("0. Back");
        Console.Write("Select: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "0": back = true; break;
            case "1":
                var listRes = await service.GetAllAsync(new LeaveRequestListRequestModel { PageNo = 1, PageSize = 100 });
                foreach (var r in listRes.LeaveRequests) Console.WriteLine($"ID: {r.LeaveRequestId} | Emp: {r.EmployeeName} | Type: {r.LeaveTypeName} | Status: {r.Status}");
                Console.WriteLine("\nPress any key..."); Console.ReadKey();
                break;
            case "2":
                Console.Write("Emp ID: "); int.TryParse(Console.ReadLine(), out int eId);
                Console.Write("Type ID: "); int.TryParse(Console.ReadLine(), out int tId);
                Console.Write("Reason: "); var reason = Console.ReadLine();
                var createRes = await service.CreateAsync(new LeaveRequestCreateRequestModel 
                { 
                    EmployeeId = eId, LeaveTypeId = tId, Reason = reason!, 
                    StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)) 
                });
                Console.WriteLine(createRes.Message + ". Press any key..."); Console.ReadKey();
                break;
            case "3":
                Console.Write("Req ID: "); int.TryParse(Console.ReadLine(), out int rId);
                Console.Write("Status (Approved/Rejected): "); var status = Console.ReadLine();
                var statusRes = await service.UpdateStatusAsync(new LeaveRequestUpdateStatusRequestModel { LeaveRequestId = rId, Status = status! });
                Console.WriteLine(statusRes.Message + ". Press any key..."); Console.ReadKey();
                break;
        }
    }
}

async Task LeaveApprovalMenu(LeaveApprovalService service)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Leave Approvals ---");
        Console.WriteLine("1. List Approvals");
        Console.WriteLine("2. Action (Approve/Reject)");
        Console.WriteLine("0. Back");
        Console.Write("Select: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "0": back = true; break;
            case "1":
                var listRes = await service.GetAllAsync(new LeaveApprovalListRequestModel { PageNo = 1, PageSize = 100 });
                foreach (var a in listRes.Approvals) Console.WriteLine($"Approval ID: {a.ApprovalId} | Req ID: {a.LeaveRequestId} | Status: {a.ApprovalStatus}");
                Console.WriteLine("\nPress any key..."); Console.ReadKey();
                break;
            case "2":
                Console.Write("Req ID: "); int.TryParse(Console.ReadLine(), out int rId);
                Console.Write("Manager ID: "); int.TryParse(Console.ReadLine(), out int mId);
                Console.Write("Status: "); var status = Console.ReadLine();
                var appRes = await service.ApproveAsync(new LeaveApprovalCreateRequestModel { LeaveRequestId = rId, ApprovedBy = mId, ApprovalStatus = status! });
                Console.WriteLine(appRes.Message + ". Press any key..."); Console.ReadKey();
                break;
        }
    }
}

async Task ReportMenu(ReportService service)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Reports ---");
        Console.WriteLine("1. Employee Leave Summary");
        Console.WriteLine("2. Monthly Report");
        Console.WriteLine("0. Back");
        Console.Write("Select: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "0": back = true; break;
            case "1":
                var res = await service.GetEmployeeLeaveSummaryAsync(new EmployeeLeaveSummaryRequestModel());
                foreach (var s in res.Summary) Console.WriteLine($"{s.EmployeeName} ({s.EmployeeCode}): {s.TotalLeavesTaken}/{s.MaxLeaves} taken.");
                Console.WriteLine("\nPress any key..."); Console.ReadKey();
                break;
            case "2":
                Console.Write("Year (e.g. 2024, Enter for current): ");
                string yearStr = Console.ReadLine();
                int year = string.IsNullOrWhiteSpace(yearStr) ? DateTime.Now.Year : int.Parse(yearStr);

                Console.Write("Month (1-12, Enter for current): ");
                string monthStr = Console.ReadLine();
                int month = string.IsNullOrWhiteSpace(monthStr) ? DateTime.Now.Month : int.Parse(monthStr);

                var monthlyRes = await service.GetMonthlyLeaveReportAsync(new MonthlyLeaveReportRequestModel { Year = year, Month = month });
                if (monthlyRes.Leaves.Count == 0)
                {
                    Console.WriteLine($"\nNo approved leaves found for {year}/{month}.");
                }
                else
                {
                    Console.WriteLine($"\nMonthly Report for {year}/{month}:");
                    foreach (var l in monthlyRes.Leaves) Console.WriteLine($"{l.EmployeeName}: {l.LeaveTypeName} {l.StartDate} to {l.EndDate} ({l.TotalDays} days)");
                }
                Console.WriteLine("\nPress any key..."); Console.ReadKey();
                break;
        }
    }
}
