using System;
using AutoMapper;
using DDD.TodoApp.Models;

namespace DDD.TodoApp.Infrastructure.Mediator;

public abstract class CommandHandlerBase : HandlerBase
{
    protected IMapper Mapper { get; private set; }
    protected CommandHandlerBase(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
}
