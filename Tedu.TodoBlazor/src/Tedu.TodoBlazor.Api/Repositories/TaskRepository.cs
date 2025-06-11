using System;
using Microsoft.EntityFrameworkCore;
using Tedu.TodoBlazor.Api.Data;

using Task = Tedu.TodoBlazor.Api.Entities.Task;

namespace Tedu.TodoBlazor.Api.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TodoListDbContext _context;

    public TaskRepository(TodoListDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Task>> GetTaskList()
    {
        return await _context.Tasks
            .Include(x => x.Assignee).ToListAsync();
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
        return await _context.Tasks.FindAsync(id);
    }
}