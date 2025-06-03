using System;
using DDD.TodoApp.Models;
using MediatR;

namespace DDD.TodoApp.Commands.Tasks;

public class TaskResetCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<TaskResetCommand, CommandResult>
{
    public TaskResetCommandHandler(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<CommandResult> Handle(TaskResetCommand command, CancellationToken cancellationToken)
    {
        var task = await GetTask(command.Id);
        task.MarkIncomplete();
        await Context.SaveChangesAsync();
        return CommandResult.SuccessResult();
    }
}