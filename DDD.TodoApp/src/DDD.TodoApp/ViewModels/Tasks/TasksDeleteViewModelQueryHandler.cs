using System;
using AutoMapper;
using DDD.TodoApp.Models;
using MediatR;

namespace DDD.TodoApp.ViewModels.Tasks;

public class TasksDeleteViewModelQueryHandler : SingleTaskQueryHandlerBase, IRequestHandler<TasksDeleteViewModelQuery, TasksDeleteViewModel>
{
    public TasksDeleteViewModelQueryHandler(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    public async Task<TasksDeleteViewModel> Handle(TasksDeleteViewModelQuery query, CancellationToken cancellationToken)
    {
        var model = new TasksDeleteViewModel();
        var task = await GetTask(query.Id);
        Mapper.Map(task, model);
        return model;
    }
}