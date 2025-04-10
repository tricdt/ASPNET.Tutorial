using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Tedu.Core.Data.EF;
using Tedu.CoreApp.Application.AutoMapper;
using Tedu.CoreApp.Data.EF;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Infrastructure.Interfaces;
using TeduCore.Data.EF;
using Microsoft.Extensions.Logging;
using Tedu.CoreApp.Helpers;
namespace Tedu.CoreApp;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
              b => b.MigrationsAssembly("Tedu.CoreApp.Data.EF")));
        services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


        // Configure Identity
        services.Configure<IdentityOptions>(options =>
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
        services.AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
        services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
        services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();


        services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()));
        // Add application services.
        services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
        services.AddScoped(typeof(IRepository<,>), typeof(EFRepository<,>));

        services.AddTransient<DbInitializer>();
        services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();
        services.AddControllersWithViews().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer dbInitializer, ILoggerFactory loggerFactory)
    {
        // Configure the HTTP request pipeline.
        loggerFactory.AddFile("Logs/tedu-{Date}.txt");
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        app.UseAuthentication();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllerRoute(
               name: "areaRoute",
               pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            // endpoints.MapAreaControllerRoute(
            //     name: "Admin",
            //     areaName: "Admin",
            //     pattern: "{controller=Home}/{action=Index}/{id?}"); 
        });

        //dbInitializer.Seed().Wait();
    }
}
