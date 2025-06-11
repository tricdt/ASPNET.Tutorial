using System;
using Tedu.TodoBlazor.Models;

namespace Tedu.TodoBlazor.Wasm.Services;

public interface ITaskApiClient
{
    Task<List<TaskDto>> GetTaskList();
}
