using System;
using Tedu.TodoBlazor.Models;

namespace Tedu.TodoBlazor.Wasm.Services;

public interface ITaskApiClient
{
    Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch);
    Task<TaskDto> GetTaskDetail(string id);
    Task<bool> CreateTask(TaskCreateRequest request);
    Task<bool> UpdateTask(Guid id, TaskUpdateRequest request);
}
