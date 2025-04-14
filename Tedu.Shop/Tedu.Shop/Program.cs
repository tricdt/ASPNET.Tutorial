
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Tedu.Shop.Data.EF;
using Tedu.Shop.Data.Entities.System;
using Tedu.Shop.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Tedu.Shop.Application.Ecommerce.ProductCategories.Dtos;
using Tedu.Shop.Application.Ecommerce.ProductCategories;
using Tedu.Shop.Application.Ecommerce.Products.Dtos;
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
var configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication().AddGoogle(options =>
{
    options.ClientId = "712161982861-59h45ehggoud21t2bho7qq9umvmhrga3.apps.googleusercontent.com";
    options.ClientSecret = "fIal4UNk7zF280VkvPWZv8zc";
}).AddFacebook(options =>
{
    options.AppId = "614363022067583";
    options.AppSecret = "ad39a62199eb4306ae24006476dff0ff";
});

builder.Services.AddAutoMapper(typeof(ProductCategoryViewModel));
builder.Services.AddAutoMapper(typeof(ProductViewModel));


builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;

    // User settings
    options.User.RequireUniqueEmail = true;
});

//Register for DI
builder.Services.AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

// Add application services.
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
builder.Services.AddScoped(typeof(IRepository<,>), typeof(EFRepository<,>));

//Add services for DI
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();

builder.Services.AddTransient<DBInitializer>();

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

var app = builder.Build();
var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
loggerFactory.AddFile("Logs/TeduShop-{Date}.txt");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using(var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<DBInitializer>();
    dbInitializer.Seed().Wait();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
