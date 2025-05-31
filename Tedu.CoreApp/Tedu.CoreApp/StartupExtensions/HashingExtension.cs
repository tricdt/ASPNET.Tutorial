using System;

namespace Tedu.CoreApp.StartupExtensions;

public static class HashingExtension
{
    public static IServiceCollection AddCustomizedHash(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
