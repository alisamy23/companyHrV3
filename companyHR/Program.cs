using company.BL.Interface;
using company.BL.Mapper;
using company.BL.Repository;
using company.DAL.Entity;
using company.DAL.Extend;
using company.DAL.Repository.Models;
using companyHR.MiddleWare;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryUsingEFinMVC.GenericRepository;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyConnectionString"));
});   
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));


//add scoped

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IReligionRep, ReligionRep>();
builder.Services.AddScoped<IGenderRep, GenderRep>();
builder.Services.AddScoped<IMenuRep, MenuRep>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });
builder.Services.AddIdentity<ApplicationUser, ApplictionRoles>(options =>
{
    // Default Password settings.
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<CompanyContext>()
           .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{  
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");
 app.UseRouteMiddleware();

app.Run();
