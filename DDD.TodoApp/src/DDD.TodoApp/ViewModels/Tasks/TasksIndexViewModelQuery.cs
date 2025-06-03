using System;
using MediatR;

namespace DDD.TodoApp.ViewModels.Tasks;

public class TasksIndexViewModelQuery : IRequest<TasksIndexViewModel>
{
    public int? CategoryId { get; set; }
}
