using System.Reflection;
using DDD.TodoApp.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DDD.TodoApp;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        //builder.Services.AddRazorPages();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddControllersWithViews();
        builder.Services.AddAutoMapper(GetExecutingAssembly());
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(GetExecutingAssembly());
        });
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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
        //app.UseIdentityServer();

        //app.UseAuthorization();
        //app.MapRazorPages().RequireAuthorization();

        return app;
    }

    private static Assembly GetExecutingAssembly()
    {
        return typeof(Program).GetTypeInfo().Assembly;
    }
}
