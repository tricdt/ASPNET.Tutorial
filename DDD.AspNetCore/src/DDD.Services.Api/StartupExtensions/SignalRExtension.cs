using System;

namespace DDD.Services.Api.StartupExtensions;

public static class SignalRExtension
{
    public static IServiceCollection AddCustomizedSignalR(this IServiceCollection services)
    {
        return services;
    }
    public static IApplicationBuilder UseCustomizedSignalR(this IApplicationBuilder app)
    {
        return app;
    }
}
