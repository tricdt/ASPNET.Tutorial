using System;
using MediatR;

namespace DDD.TodoApp.ViewModels.Tasks;

public class TasksEditViewModelQuery : IRequest<TasksEditViewModel>
{
    public int Id { get; set; }
}
