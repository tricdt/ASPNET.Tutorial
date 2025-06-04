using System;

namespace DDD.Services.Api.StartupExtensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddCustomizedSwagger(this IServiceCollection services, IWebHostEnvironment env)
    {
        return services;
    }

    public static IApplicationBuilder UseCustomizedSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        return app;
    }
}
