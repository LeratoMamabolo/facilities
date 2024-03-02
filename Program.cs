
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineBookingFacility.Data;
using OnlineBookingFacility.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Configure services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IPasswordValidator<IdentityUser>, CustomPasswordValidator>();
builder.Services.AddScoped<IUserValidator<IdentityUser>, CustomUserValidator>();
//Database Option 1: SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts => {
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
    opts.User.RequireUniqueEmail = true;
    //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
}).AddEntityFrameworkStores<AppIdentityDbContext>();

var app = builder.Build();

//Configure middleware
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "sortingpage",
    pattern: "Manager/OrderBy{sortBy}/Page{page}",
    defaults: new { Controller = "Manager", action = "Index", page = 1 });

app.MapControllerRoute(
    name: "sorting",
    pattern: "Manager/OrderBy{sortBy}",
    defaults: new { Controller = "Manager", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Booking}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.EnsurePopulated(app);
SeedDataIdentity.EnsurePopulated(app);

app.Run();
