using BlogErsen.Data.Abstract;
using BlogErsen.Data.Concrete;
using BlogErsen.Ui.Identity;
using BlogUi.Business.Abstract;
using BlogUi.Business.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var services = builder.Services;


/// Dependecy Injection////////////////
services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
services.AddScoped<IPostDal, EfCorePostDal>();
services.AddScoped<ICategoryService, CategoryManager>();
services.AddScoped<IPostService, PostManager>();
///////////////////////////////////////

//Identity K�t�phanesi Config ////////////////////////
var path2 = "C:\\Users\\ersen\\Desktop\\BlogErsen\\BlogErsen.Ui\\BlogErsen.Data\\BlogContext.db";
services.AddDbContext<ApplicationContext>(options => options.UseSqlite($"Data Source = {path2}"));
services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;
    //Lockout
    options.Lockout.MaxFailedAccessAttempts = 5;
    //Oturum a��k kalma s�resi 
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

});
//////////////////////////////////////////////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=PostUpdate}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
