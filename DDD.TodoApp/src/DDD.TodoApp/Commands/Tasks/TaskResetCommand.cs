using System;
using MediatR;

namespace DDD.TodoApp.Commands.Tasks;

public class TaskResetCommand : SingleEntityCommandBase, IRequest<CommandResult>
{
}