using AutoMapper;
using DDD.TodoApp.Commands.Tasks;
using DDD.TodoApp.ViewModels.Tasks;
namespace DDD.TodoApp.Infrastructure.Mapping;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Models.Task, TasksIndexViewModel.TaskListEntry>();
        CreateMap<TasksEditViewModel, TaskAddOrEditCommand>();
        CreateMap<Models.Task, TasksEditViewModel>();
        CreateMap<Models.Task, TasksDeleteViewModel>();
        CreateMap<TasksDeleteViewModel, TaskDeleteCommand>();
    }
}
