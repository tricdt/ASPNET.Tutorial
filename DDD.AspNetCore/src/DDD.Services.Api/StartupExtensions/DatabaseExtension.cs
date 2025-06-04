using System;

namespace DDD.Services.Api.StartupExtensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
        return services;
    }
}
