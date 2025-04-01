using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tedu.Core.Data.EF;
using Tedu.CoreApp.Application.AutoMapper;
using Tedu.CoreApp.Data.EF;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Infrastructure.Interfaces;
using TeduCore.Data.EF;

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

        services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
        services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

        services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()));
        // Add application services.
        services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
        services.AddScoped(typeof(IRepository<,>), typeof(EFRepository<,>));

        services.AddTransient<DbInitializer>();
        services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer dbInitializer)
    {
        // Configure the HTTP request pipeline.
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
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllerRoute(
               name: "areaRoute",
               pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            // endpoints.MapAreaControllerRoute(
            //     name: "Admin",
            //     areaName: "Admin",
            //     pattern: "{controller=Home}/{action=Index}/{id?}"); 
        });

        dbInitializer.Seed().Wait();
    }
}
