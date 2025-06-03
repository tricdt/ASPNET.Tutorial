using System;
using DDD.TodoApp.Models;
using MediatR;

namespace DDD.TodoApp.Commands.Tasks;

public class TaskCompleteCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<TaskCompleteCommand, CommandResult>
{
    public TaskCompleteCommandHandler(ApplicationDbContext context)
        : base(context)
    {
    }


    public async Task<CommandResult> Handle(TaskCompleteCommand command, CancellationToken cancellationToken)
    {
        var task = await GetTask(command.Id);
        task.MarkComplete();
        await Context.SaveChangesAsync();
        return CommandResult.SuccessResult();
    }
}
