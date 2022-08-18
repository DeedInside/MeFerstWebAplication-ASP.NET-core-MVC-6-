using Microsoft.EntityFrameworkCore;
using MeFerstWebAplication.Models;

var builder = WebApplication.CreateBuilder(args);

//Подключение БД 
string Connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Blog}/{id?}");

app.Run();