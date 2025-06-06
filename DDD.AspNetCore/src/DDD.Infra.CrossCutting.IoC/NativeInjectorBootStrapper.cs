using System;
using DDD.Domain.Core.Bus;
using DDD.Infra.CrossCutting.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infra.CrossCutting.IoC;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    { 
        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();
        
    }
}
