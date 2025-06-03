using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDD.TodoApp.Infrastructure.Mediator;
using DDD.TodoApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DDD.TodoApp.ViewModels.Tasks;

public class TasksIndexViewModelQueryHandler : QueryHandlerBase, IRequestHandler<TasksIndexViewModelQuery, TasksIndexViewModel>
{
    public TasksIndexViewModelQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<TasksIndexViewModel> Handle(TasksIndexViewModelQuery query, CancellationToken cancellationToken)
    {
          var model = new TasksIndexViewModel
            {
                CategoryId = query.CategoryId,
                Items = await Context.Tasks
                    .Include(x => x.Category)
                    .Where(x => !query.CategoryId.HasValue || x.Category.Id == query.CategoryId) 
                    .OrderBy(x => x.Description)
                    .ProjectTo<TasksIndexViewModel.TaskListEntry>(Mapper.ConfigurationProvider)
                    .ToListAsync()
            };

            model.CategoryOptions = new SelectList(await Context.Categories
                .OrderBy(x => x.Name)
                .ToListAsync(), "Id", "Name", model.CategoryId);

            return model;
    }
}
