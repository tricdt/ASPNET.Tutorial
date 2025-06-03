using System;
using AutoMapper;
using DDD.TodoApp.Infrastructure.Mediator;
using DDD.TodoApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace DDD.TodoApp.ViewModels.Tasks;

public class TasksEditViewModelQueryHandler : SingleTaskQueryHandlerBase, IRequestHandler<TasksEditViewModelQuery, TasksEditViewModel>
{
    public TasksEditViewModelQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<TasksEditViewModel> Handle(TasksEditViewModelQuery query, CancellationToken cancellationToken)
    {
        var model = new TasksEditViewModel();
        if (query.Id > 0)
        {
            var task = await GetTask(query.Id);
            Mapper.Map(task, model);
        }

        model.CategoryOptions = new SelectList(await Context.Categories
            .OrderBy(x => x.Name)
            .ToListAsync(), "Id", "Name", model.CategoryId);

        return model;
    }
}