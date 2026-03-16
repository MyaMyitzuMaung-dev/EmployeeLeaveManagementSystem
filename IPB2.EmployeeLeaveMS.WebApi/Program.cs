using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services
builder.Services.AddScoped<IPB2.EmployeeLeaveMS.WebApi.Features.Employees.EmployeeService>();
builder.Services.AddScoped<IPB2.EmployeeLeaveMS.WebApi.Features.LeaveTypes.LeaveTypeService>();
builder.Services.AddScoped<IPB2.EmployeeLeaveMS.WebApi.Features.LeaveRequests.LeaveRequestService>();
builder.Services.AddScoped<IPB2.EmployeeLeaveMS.WebApi.Features.LeaveApprovals.LeaveApprovalService>();
builder.Services.AddScoped< IPB2.EmployeeLeaveMS.WebApi.Features.Reports.ReportService> ();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
