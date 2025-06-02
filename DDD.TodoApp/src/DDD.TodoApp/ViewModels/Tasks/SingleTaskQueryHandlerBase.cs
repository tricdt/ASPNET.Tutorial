using System;
using AutoMapper;
using DDD.TodoApp.Infrastructure.Mediator;
using DDD.TodoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DDD.TodoApp.ViewModels.Tasks;

public abstract class SingleTaskQueryHandlerBase : QueryHandlerBase
{
    protected SingleTaskQueryHandlerBase(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected async Task<Models.Task> GetTask(int id)
    {
        var task = await Context.Tasks
            .SingleOrDefaultAsync(x => x.Id == id);
        if (task == null)
        {
            throw new NullReferenceException($"Task with id: {id} not found.");
        }

        return task;
    }
}
