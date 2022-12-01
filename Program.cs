using Microsoft.EntityFrameworkCore;
using ProjetoLp3.Models;

var builder = WebApplication.CreateBuilder(args); //configura como a aplicação comporta

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProjetoLp3Context>(options => options.UseMySQL("server=localhost;database=estudante;user=root;password=123456;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
