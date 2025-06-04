using System;

namespace DDD.Services.Api.StartupExtensions;

public static class HealthCheckExtension
{
    public static IServiceCollection AddCustomizedHealthCheck(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
        return services;
    }

    public static void UseCustomizedHealthCheck(IEndpointRouteBuilder endpoints, IWebHostEnvironment env)
    {
    }
}
