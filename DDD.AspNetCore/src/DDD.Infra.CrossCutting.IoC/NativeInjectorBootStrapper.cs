using System;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Events;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Interfaces;
using DDD.Infra.CrossCutting.Bus;
using DDD.Infra.CrossCutting.Identity.Models;
using DDD.Infra.CrossCutting.Identity.Services;
using DDD.Infra.Data.EventSourcing;
using DDD.Infra.Data.Repository.EventSourcing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infra.CrossCutting.IoC;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // Domain - Events
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

        // Infra - Data EventSourcing
        services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
        services.AddScoped<IEventStore, SqlEventStore>();

        // Infra - Identity
        services.AddScoped<IUser, AspNetUser>();
        services.AddSingleton<IJwtFactory, JwtFactory>();
    }
}
