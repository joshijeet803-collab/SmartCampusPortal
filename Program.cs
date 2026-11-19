using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CampusDb>(o => o.UseSqlite("Data Source=campus.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CampusDb>();
    db.Database.EnsureCreated();

    if (!db.Students.Any())
    {
        db.Students.AddRange(
            new Student { Name = "Jeet Joshi", Email = "jeet@gmail.com", Course = "Computer Engineering", Semester = 5 },
            new Student { Name = "Preet Vora", Email = "preet@gmail.com", Course = "Computer Engineering", Semester = 5 },
            new Student { Name = "Krish Tajpara", Email = "Krish@gmail.com", Course = "Computer Engineering", Semester = 5 },
            new Student { Name = "Tapan Raval", Email = "Tapan@gmail.com", Course = "Computer Engineering", Semester = 5 },
            new Student { Name = "Afraz Malik", Email = "Afraz@gmail.com", Course = "Computer Engineering", Semester = 5 }
        );

        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();