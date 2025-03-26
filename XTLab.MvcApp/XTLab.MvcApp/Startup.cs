using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XTLab.MvcApp.Application.AutoMapper;
using XTLab.MvcApp.Application.Implementation;
using XTLab.MvcApp.Application.Interface;
using XTLab.MvcApp.Application.Services;
using XTLab.MvcApp.Data.EF;
using XTLab.MvcApp.Extensions;
using XTLab.MvcApp.Infrastructure.Interfaces;

namespace XTLab.MvcApp;

public class Startup
{
    public static string ContentRootPath { get; set; }
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        ContentRootPath = env.ContentRootPath;
    }
    public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            string connectString = Configuration.GetConnectionString("AppMvcConnectionString");
            options.UseSqlServer(connectString);
        });
        services.AddAutoMapper(cfg =>{cfg.AddProfile(new MappingProfile());});
        services.AddControllersWithViews();
        services.AddRazorPages();
        services.AddSingleton(typeof(PlanetService), typeof(PlanetService));
        services.AddSingleton(typeof(ProductService), typeof(ProductService));

        services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
        services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

        services.AddTransient<IContactService, ContactService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.AddStatusCodePage();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapAreaControllerRoute(
                //     name: "product",
                //     pattern: "/{controller}/{action=Index}/{id?}",
                //     areaName: "ProductManage"
                // ); 

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "/{area}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
    }
}
