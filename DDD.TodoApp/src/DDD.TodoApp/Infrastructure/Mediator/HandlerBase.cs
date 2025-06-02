using System;
using DDD.TodoApp.Models;

namespace DDD.TodoApp.Infrastructure.Mediator;

public abstract class HandlerBase
{
    protected HandlerBase(ApplicationDbContext context)
    {
        Context = context;
    }

    protected ApplicationDbContext Context { get; private set; }
}
