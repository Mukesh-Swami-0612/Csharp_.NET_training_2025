using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;
using StudentPortal.Repositories;
using StudentPortal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentPortalDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("StudentPortalDbConnection")));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();