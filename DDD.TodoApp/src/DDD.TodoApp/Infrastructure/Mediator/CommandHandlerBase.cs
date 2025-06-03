using System;
using AutoMapper;
using DDD.TodoApp.Models;

namespace DDD.TodoApp.Infrastructure.Mediator;

public abstract class CommandHandlerBase : HandlerBase
{
    protected CommandHandlerBase(ApplicationDbContext context)
        : base(context)
    {
    }
}
