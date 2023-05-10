using Microsoft.EntityFrameworkCore;
using PustokBackTask.DAL;
using PustokBackTask.Services;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer("Server=ELFRUSTAICHI\\SQLEXPRESS;Database=PustokTaskDB;Trusted_Connection=true");
});

builder.Services.AddScoped<LayoutService>();



var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();