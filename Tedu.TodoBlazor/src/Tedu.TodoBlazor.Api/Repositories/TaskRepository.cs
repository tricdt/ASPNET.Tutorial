using System;
using Microsoft.EntityFrameworkCore;
using Tedu.TodoBlazor.Api.Data;
using Tedu.TodoBlazor.Models;
using Tedu.TodoBlazor.Models.SeedWork;
using Task = Tedu.TodoBlazor.Api.Entities.Task;

namespace Tedu.TodoBlazor.Api.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TodoListDbContext _context;

    public TaskRepository(TodoListDbContext context)
    {
        _context = context;
    }
    public async Task<PagedList<Task>> GetTaskList(TaskListSearch taskListSearch)
    {
        var query = _context.Tasks
            .Include(x => x.Assignee).AsQueryable();

        if (!string.IsNullOrEmpty(taskListSearch.Name))
            query = query.Where(x => x.Name.Contains(taskListSearch.Name));

        if (taskListSearch.AssigneeId.HasValue)
            query = query.Where(x => x.AssigneeId == taskListSearch.AssigneeId.Value);

        if (taskListSearch.Priority.HasValue)
            query = query.Where(x => x.Priority == taskListSearch.Priority.Value);

        var count = await query.CountAsync();

        var data = await query.OrderByDescending(x => x.CreatedDate)
               .Skip((taskListSearch.PageNumber - 1) * taskListSearch.PageSize)
               .Take(taskListSearch.PageSize)
               .ToListAsync();
        return new PagedList<Task>(data, count, taskListSearch.PageNumber, taskListSearch.PageSize);

    }

    public async Task<Task> Create(Task task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Task> Update(Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Task> Delete(Task task)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Task> GetById(Guid id)
    {
        return await _context.Tasks.Include(t => t.Assignee).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<PagedList<Task>> GetTaskListByUserId(Guid userId, TaskListSearch taskListSearch)
    {
        var query = _context.Tasks
            .Where(x => x.AssigneeId == userId)
            .Include(x => x.Assignee).AsQueryable();

        if (!string.IsNullOrEmpty(taskListSearch.Name))
            query = query.Where(x => x.Name.Contains(taskListSearch.Name));

        if (taskListSearch.AssigneeId.HasValue)
            query = query.Where(x => x.AssigneeId == taskListSearch.AssigneeId.Value);

        if (taskListSearch.Priority.HasValue)
            query = query.Where(x => x.Priority == taskListSearch.Priority.Value);

        var count = await query.CountAsync();

        var data = await query.OrderByDescending(x => x.CreatedDate)
            .Skip((taskListSearch.PageNumber - 1) * taskListSearch.PageSize)
            .Take(taskListSearch.PageSize)
            .ToListAsync();
        return new PagedList<Task>(data, count, taskListSearch.PageNumber, taskListSearch.PageSize);
    }
}