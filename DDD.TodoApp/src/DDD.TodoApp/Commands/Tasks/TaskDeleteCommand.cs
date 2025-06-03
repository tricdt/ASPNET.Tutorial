using System;
using MediatR;

namespace DDD.TodoApp.Commands.Tasks;

public class TaskDeleteCommand : SingleEntityCommandBase, IRequest<CommandResult>
{
}