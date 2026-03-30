using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using IPB2.EmployeeLeaveMS.Domain;
using IPB2.EmployeeLeaveMS.Domain.Features.Employees;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveTypes;
using IPB2.EmployeeLeaveMS.Domain.Features.Reports;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register Services
builder.AddDomain();

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
