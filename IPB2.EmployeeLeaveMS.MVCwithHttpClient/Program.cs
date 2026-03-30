using IPB2.EmployeeLeaveMS.MVCwithHttpClient.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<EmployeeHttpClientService>();
builder.Services.AddHttpClient<LeaveTypeHttpClientService>();
builder.Services.AddHttpClient<LeaveRequestHttpClientService>();
builder.Services.AddHttpClient<LeaveApprovalHttpClientService>();
builder.Services.AddHttpClient<ReportHttpClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
