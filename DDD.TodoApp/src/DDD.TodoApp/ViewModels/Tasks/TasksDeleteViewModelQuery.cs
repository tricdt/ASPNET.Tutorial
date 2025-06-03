using System;
using MediatR;

namespace DDD.TodoApp.ViewModels.Tasks;

public class TasksDeleteViewModelQuery : IRequest<TasksDeleteViewModel>
{
    public int Id { get; set; }
}
