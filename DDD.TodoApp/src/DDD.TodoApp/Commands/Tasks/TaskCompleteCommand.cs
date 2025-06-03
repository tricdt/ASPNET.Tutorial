using System;
using MediatR;

namespace DDD.TodoApp.Commands.Tasks;

public class TaskCompleteCommand : SingleEntityCommandBase, IRequest<CommandResult>
{
}
