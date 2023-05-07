using Microsoft.EntityFrameworkCore;
using PustokBackTask.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer("Server=ELFRUSTAICHI\\SQLEXPRESS;Database=PustokTaskDB;Trusted_Connection=true");
});



var app = builder.Build();

app.MapControllerRoute("default",
    "{controller=home}/{action=index}/{id?}");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.Run();
