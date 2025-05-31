using System;
using Microsoft.Extensions.DependencyInjection;

namespace Tedu.CoreApp.StartupExtensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddCustomizedSwagger(this IServiceCollection services, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            
        }
        return services;
    }

    public static IApplicationBuilder UseCustomizedSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        return app;
    }
}
