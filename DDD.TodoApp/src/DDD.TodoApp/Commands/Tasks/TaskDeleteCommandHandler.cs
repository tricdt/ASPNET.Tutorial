using System;
using DDD.TodoApp.Models;
using MediatR;

namespace DDD.TodoApp.Commands.Tasks;

public class TaskDeleteCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<TaskDeleteCommand, CommandResult>
{
    public TaskDeleteCommandHandler(ApplicationDbContext context)
        : base(context)
    {
    }



    public async Task<CommandResult> Handle(TaskDeleteCommand command, CancellationToken cancellationToken)
    {
        var task = await GetTask(command.Id);
        Context.Tasks.Remove(task);
        await Context.SaveChangesAsync();
        return CommandResult.SuccessResult();
    }
}