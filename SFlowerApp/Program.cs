using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SapphireApp.Data;
using SapphireApp.Users;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
//Add razor pages to services - IdentityUi needs it
builder.Services.AddRazorPages();
//Here we add services to the service collection
builder.Services.AddDbContext<SFlowerDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SFlowerDb"))
    .EnableSensitiveDataLogging();
    });

builder.Services.AddDefaultIdentity<MyUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AuthenticationDbContext>();

builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationDb"));
});


////adding Identity to the AuthenticationDbContext
//builder.Services.AddIdentity<MyUser, IdentityRole>()
//    .AddEntityFrameworkStores<AuthenticationDbContext>()
//    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//Identity UI uses razor pages
app.MapRazorPages();

app.Run();
