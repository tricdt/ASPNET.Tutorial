using System;

namespace DDD.Services.Api.StartupExtensions;

public static class QuartzExtensions
{
    public static IServiceCollection AddCustomizedQuartz(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IApplicationBuilder UseCustomizedQuartz(this IApplicationBuilder app)
    {
        return app;
    }
}
