using BudgetPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using OfficeOpenXml;
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;



var builder = WebApplication.CreateBuilder(args);

// 🔌 Configure the database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔐 Configure Identity system with ApplicationUser
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// 📦 Add MVC and Razor Pages support
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // ✅ This must be BEFORE builder.Build()

var app = builder.Build();

// 🌐 Middleware setup
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔐 Enable Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

// 🗺️ Define routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Budget}/{action=Index}/{id?}");

// 🧱 Enable Identity Razor pages (for login/register)
app.MapRazorPages(); // ✅ This maps /Identity/Account/Login etc.

app.Run();
