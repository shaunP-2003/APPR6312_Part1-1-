using APPR6312_Part1_1_.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages(options =>
//{
//    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");

//});

builder.Services.AddDbContext<DAFAppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DAF_ConnectionString")));
//The following method was taken from youtube
// Author: Digtal TechJoint
//Link: https://youtu.be/ghzvSROMo_M?si=Y1YzZVwhciU1dcUm

builder.Services.AddDbContext<DAFAppDataDbcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DAF_ConnectionString")));
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DAFAppDbContext>();
//The following method was taken from youtube
// Author: Digtal TechJoint
//Link: https://youtu.be/ghzvSROMo_M?si=Y1YzZVwhciU1dcUm

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.MapRazorPages();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=PublicPage}/{action=Public}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();

//all the page with the authorize tag refrence
//The following method was taken from youtube
// Author: ASP.NET MVC
//Link: https://youtu.be/2BAqqYajk-c?feature=shared