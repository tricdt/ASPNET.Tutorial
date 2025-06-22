using System;
using Tedu.TodoBlazor.Models;
using Tedu.TodoBlazor.Models.SeedWork;
using Task = Tedu.TodoBlazor.Api.Entities.Task;
namespace Tedu.TodoBlazor.Api.Repositories;

public interface ITaskRepository
{
    Task<PagedList<Task>> GetTaskList(TaskListSearch taskListSearch);
    Task<PagedList<Task>> GetTaskListByUserId(Guid userId, TaskListSearch taskListSearch);
    Task<Task> Create(Task task);

    Task<Task> Update(Task task);

    Task<Task> Delete(Task task);

    Task<Task> GetById(Guid id);
}
