using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using IPB2.EmployeeLeaveMS.WebApi.Features.Employees;
using IPB2.EmployeeLeaveMS.WebApi.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.WebApi.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.WebApi.Features.LeaveTypes;
using IPB2.EmployeeLeaveMS.WebApi.Features.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services from WebApi 프로젝트
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<LeaveTypeService>();
builder.Services.AddScoped<LeaveRequestService>();
builder.Services.AddScoped<LeaveApprovalService>();
builder.Services.AddScoped<ReportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- EMPLOYEES ---
var employeeGroup = app.MapGroup("/api/Employee");

employeeGroup.MapPost("/create", async ([FromBody] EmployeeCreateRequestModel request, EmployeeService service) =>
    Results.Ok(await service.CreateAsync(request)));

employeeGroup.MapGet("/list", async (int pageNo, int pageSize, EmployeeService service) =>
{
    var request = new EmployeeListRequestModel { PageNumber = pageNo, PageSize = pageSize };
    return Results.Ok(await service.GetAllAsync(request));
});

employeeGroup.MapPut("/update", async ([FromBody] EmployeeEditRequestModel request, EmployeeService service) =>
    Results.Ok(await service.UpdateAsync(request)));

employeeGroup.MapDelete("/delete", async ([AsParameters] EmployeeDeleteRequestModel request, EmployeeService service) =>
    Results.Ok(await service.DeleteAsync(request)));

// --- LEAVE TYPES ---
var leaveTypeGroup = app.MapGroup("/api/LeaveType");

leaveTypeGroup.MapPost("/create", async ([FromBody] LeaveTypeCreateRequestModel request, LeaveTypeService service) =>
    Results.Ok(await service.CreateAsync(request)));

leaveTypeGroup.MapGet("/list", async (int pageNo, int pageSize, LeaveTypeService service) =>
{
    var request = new LeaveTypeListRequestModel { PageNo = pageNo, PageSize = pageSize };
    return Results.Ok(await service.GetAllAsync(request));
});

leaveTypeGroup.MapGet("/detail", async (int leaveTypeId, LeaveTypeService service) =>
{
    var request = new LeaveTypeDetailRequestModel { LeaveTypeId = leaveTypeId };
    return Results.Ok(await service.GetByIdAsync(request));
});

leaveTypeGroup.MapPut("/update", async ([FromBody] LeaveTypeUpdateRequestModel request, LeaveTypeService service) =>
    Results.Ok(await service.UpdateAsync(request)));

leaveTypeGroup.MapDelete("/delete", async (int leaveTypeId, LeaveTypeService service) =>
{
    var request = new LeaveTypeDeleteRequestModel { LeaveTypeId = leaveTypeId };
    return Results.Ok(await service.DeleteAsync(request));
});

// --- LEAVE REQUESTS ---
var leaveRequestGroup = app.MapGroup("/api/LeaveRequest");

leaveRequestGroup.MapPost("/create", async ([FromBody] LeaveRequestCreateRequestModel request, LeaveRequestService service) =>
    Results.Ok(await service.CreateAsync(request)));

leaveRequestGroup.MapGet("/list", async (int pageNo, int pageSize, LeaveRequestService service) =>
{
    var request = new LeaveRequestListRequestModel { PageNo = pageNo, PageSize = pageSize };
    return Results.Ok(await service.GetAllAsync(request));
});

leaveRequestGroup.MapGet("/detail", async (int leaveRequestId, LeaveRequestService service) =>
{
    var request = new LeaveRequestDetailRequestModel { LeaveRequestId = leaveRequestId };
    return Results.Ok(await service.GetByIdAsync(request));
});

leaveRequestGroup.MapPut("/update-status", async ([FromBody] LeaveRequestUpdateStatusRequestModel request, LeaveRequestService service) =>
    Results.Ok(await service.UpdateStatusAsync(request)));

leaveRequestGroup.MapDelete("/delete", async (int leaveRequestId, LeaveRequestService service) =>
{
    var request = new LeaveRequestDeleteRequestModel { LeaveRequestId = leaveRequestId };
    return Results.Ok(await service.DeleteAsync(request));
});

// --- LEAVE APPROVALS ---
var leaveApprovalGroup = app.MapGroup("/api/LeaveApproval");

leaveApprovalGroup.MapPost("/approve", async ([FromBody] LeaveApprovalCreateRequestModel request, LeaveApprovalService service) =>
    Results.Ok(await service.ApproveAsync(request)));

leaveApprovalGroup.MapGet("/list", async (int pageNo, int pageSize, LeaveApprovalService service) =>
{
    var request = new LeaveApprovalListRequestModel { PageNo = pageNo, PageSize = pageSize };
    return Results.Ok(await service.GetAllAsync(request));
});

leaveApprovalGroup.MapDelete("/delete", async (int approvalId, LeaveApprovalService service) =>
{
    var request = new LeaveApprovalDeleteRequestModel { ApprovalId = approvalId };
    return Results.Ok(await service.DeleteAsync(request));
});

// --- REPORTS ---
var reportGroup = app.MapGroup("/api/Report");

reportGroup.MapGet("/monthly-leave", async (int year, int month, ReportService service) =>
{
    var request = new MonthlyLeaveReportRequestModel { Year = year, Month = month };
    return Results.Ok(await service.GetMonthlyLeaveReportAsync(request));
});

reportGroup.MapGet("/employee-summary", async (int? employeeId, ReportService service) =>
{
    var request = new EmployeeLeaveSummaryRequestModel { EmployeeId = employeeId };
    return Results.Ok(await service.GetEmployeeLeaveSummaryAsync(request));
});

app.Run();
