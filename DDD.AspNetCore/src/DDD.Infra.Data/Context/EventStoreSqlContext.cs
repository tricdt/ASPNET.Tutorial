using System;
using DDD.Domain.Core.Events;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Context;

public class EventStoreSqlContext : DbContext
{
    public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options)
        : base(options)
    {
    }
    public DbSet<StoredEvent> StoredEvent { get; set; }
}
