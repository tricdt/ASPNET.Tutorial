using System;
using MediatR;

namespace DDD.TodoApp.Commands.Tasks;

public class TaskAddOrEditCommand : AddOrEditSingleEntityCommandBase, IRequest<CommandResult<int>>
{
    public string Description { get; set; }

    public int CategoryId { get; set; }
}
