using IPB2.EmployeeLeaveMS.Domain.Features.Employees;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveTypes;
using IPB2.EmployeeLeaveMS.Domain.Features.Reports;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;

namespace IPB2.EmployeeLeaveMS.Domain
{
    public static class FeatureManager
    {
        public static WebApplicationBuilder AddDomain(this WebApplicationBuilder builder)
        {
            // Register AppDbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<EmployeeService>();
            builder.Services.AddScoped<LeaveTypeService>();
            builder.Services.AddScoped<LeaveRequestService>();
            builder.Services.AddScoped<LeaveApprovalService>();
            builder.Services.AddScoped<ReportService>();

            return builder;
        }
    }
}
