using IPB2.EmployeeLeaveMS.Database.AppDbContextModels;
using IPB2.EmployeeLeaveMS.Domain.Features.Employees;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.Domain.Features.LeaveTypes;
using IPB2.EmployeeLeaveMS.Domain.Features.Reports;
using IPB2.EmployeeLeaveMS.WinForm.Features.Employees;
using IPB2.EmployeeLeaveMS.WinForm.Features.LeaveApprovals;
using IPB2.EmployeeLeaveMS.WinForm.Features.LeaveRequests;
using IPB2.EmployeeLeaveMS.WinForm.Features.LeaveTypes;
using IPB2.EmployeeLeaveMS.WinForm.Features.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IPB2.EmployeeLeaveMS.WinForm
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            ConfigureServices(services, configuration);

            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            var mainForm = ServiceProvider.GetRequiredService<DashboardForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<EmployeeService>();
            services.AddScoped<LeaveTypeService>();
            services.AddScoped<LeaveRequestService>();
            services.AddScoped<LeaveApprovalService>();
            services.AddScoped<ReportService>();

            services.AddTransient<DashboardForm>();
            services.AddTransient<EmployeeForm>();
            services.AddTransient<LeaveTypeForm>();
            services.AddTransient<LeaveRequestForm>();
            services.AddTransient<ApprovalForm>();
            services.AddTransient<ReportForm>();
        }
    }
}
