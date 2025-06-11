using System;
using Task = Tedu.TodoBlazor.Api.Entities.Task;
namespace Tedu.TodoBlazor.Api.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<Task>> GetTaskList();

    Task<Task> Create(Task task);

    Task<Task> Update(Task task);

    Task<Task> Delete(Task task);

    Task<Task> GetById(Guid id);
}
