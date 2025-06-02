using System;
using AutoMapper;
using DDD.TodoApp.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DDD.TodoApp.Commands.Tasks;

public class TaskAddOrEditCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<TaskAddOrEditCommand, CommandResult<int>>
{
    public TaskAddOrEditCommandHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<CommandResult<int>> Handle(TaskAddOrEditCommand command, CancellationToken cancellationToken)
    {
        var category = await GetCategory(command.CategoryId);
        Models.Task task;
        if (command.IsAdding)
        {
            task = new Models.Task(command.Description, category);
            Context.Tasks.Add(task);
        }
        else
        {
            task = await GetTask(command.Id);
            task.SetDetails(command.Description, category);
        }

        await Context.SaveChangesAsync();

        return CommandResult<int>.SuccessResult(task.Id);
    }

    private async Task<Category> GetCategory(int id)
    {
        var task = await Context.Categories
            .SingleOrDefaultAsync(x => x.Id == id);
        if (task == null)
        {
            throw new NullReferenceException($"Category with id: {id} not found.");
        }

        return task;
    }
}
