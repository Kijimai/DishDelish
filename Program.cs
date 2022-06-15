using Microsoft.EntityFrameworkCore;
using Crudelicious.Models;
// Additional libraries
// Creates builder (also part of boilerplate code for web apps)
var builder = WebApplication.CreateBuilder(args);
//  Creates the db connection string
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Adds database connection - must be before app.Build();
// Add services to the container.
builder.Services.AddDbContext<DishContext>(options =>
{
  options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
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
