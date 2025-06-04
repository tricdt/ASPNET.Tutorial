using System;

namespace DDD.Services.Api.StartupExtensions;

public static class AuthExtension
{
    public static IServiceCollection AddCustomizedAuth(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IApplicationBuilder UseCustomizedAuth(this IApplicationBuilder app)
    {
        return app;
    }
}
