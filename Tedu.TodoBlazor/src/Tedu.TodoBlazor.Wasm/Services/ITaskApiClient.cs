using System;
using Tedu.TodoBlazor.Models;
using Tedu.TodoBlazor.Models.SeedWork;

namespace Tedu.TodoBlazor.Wasm.Services;

public interface ITaskApiClient
{
    Task<PagedList<TaskDto>> GetTaskList(TaskListSearch taskListSearch);
    Task<TaskDto> GetTaskDetail(string id);
    Task<bool> CreateTask(TaskCreateRequest request);
    Task<bool> UpdateTask(Guid id, TaskUpdateRequest request);
    Task<bool> AssignTask(Guid id, AssignTaskRequest request);
    Task<bool> DeleteTask(Guid id);
}
