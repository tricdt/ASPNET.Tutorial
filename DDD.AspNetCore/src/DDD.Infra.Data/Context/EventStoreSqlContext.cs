using System;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Context;

public class EventStoreSqlContext : DbContext
{
    public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options)
        : base(options)
    {
    }

}
