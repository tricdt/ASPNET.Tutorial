using System;

namespace Tedu.CoreApp.StartupExtensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            
        }
        return services;
    }

    public static IApplicationBuilder UseCustomizedDatabase(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        return app;
    }
}
