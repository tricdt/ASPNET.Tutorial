using System;
using AutoMapper;
using DDD.TodoApp.Commands.Tasks;
using DDD.TodoApp.ViewModels.Tasks;
namespace DDD.TodoApp.Infrastructure.Mapping;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
          CreateMap<TasksEditViewModel, TaskAddOrEditCommand>();
    }
}
