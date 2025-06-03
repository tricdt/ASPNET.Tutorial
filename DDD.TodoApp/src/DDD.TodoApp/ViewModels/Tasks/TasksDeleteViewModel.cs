using System;

namespace DDD.TodoApp.ViewModels.Tasks;

public class TasksDeleteViewModel : SingleEntityViewModelBase
{
    public string Description { get; set; }
}
