using System;

namespace Tedu.CoreApp.StartupExtensions;

public static class AuthExtension
{
    public static IServiceCollection AddCustomizedAuth(this IServiceCollection services, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            
        }
        return services;
    }

    public static IApplicationBuilder UseCustomizedAuth(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        return app;
    }
}
