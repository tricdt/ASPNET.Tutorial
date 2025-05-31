using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Serilog;
using Tedu.Core.Data.EF;
using Tedu.CoreApp.Application.AutoMapper;
using Tedu.CoreApp.Application.Ecommerce.ProductCategories.Dtos;
using Tedu.CoreApp.Application.Ecommerce.Products;
using Tedu.CoreApp.Application.Ecommerce.Products.Dtos;
using Tedu.CoreApp.Application.Systems.Functions;
using Tedu.CoreApp.Application.Systems.Functions.Dtos;
using Tedu.CoreApp.Data.EF;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Infrastructure.Interfaces;
using TeduCore.Data.EF;

namespace Tedu.CoreApp;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
              b => b.MigrationsAssembly("Tedu.CoreApp.Data.EF")));

        builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            options.Lockout.MaxFailedAccessAttempts = 10;

            options.User.RequireUniqueEmail = true;
        });

        builder.Services.AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
        builder.Services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
        builder.Services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

        builder.Services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
        builder.Services.AddScoped(typeof(IRepository<,>), typeof(EFRepository<,>));

        builder.Services.AddTransient<DbInitializer>();

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        });

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication();

        builder.Services.AddTransient<IFunctionService, FunctionService>();
        builder.Services.AddTransient<IProductService, ProductService>();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "areaRoute",
            pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        return app;
    }
}
