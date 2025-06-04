using System;

namespace DDD.Services.Api.StartupExtensions;

public static class HttpExtension
{
    public static IServiceCollection AddCustomizedHttp(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
