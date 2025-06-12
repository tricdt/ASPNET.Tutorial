using System;
using System.Net.Http.Json;
using Tedu.TodoBlazor.Models;

namespace Tedu.TodoBlazor.Wasm.Services;

public class TaskApiClient : ITaskApiClient
{
    public HttpClient _httpClient;

    public TaskApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TaskDto> GetTaskDetail(string id)
    {
        var result = await _httpClient.GetFromJsonAsync<TaskDto>($"/api/tasks/{id}");
        return result;
    }

    public async Task<List<TaskDto>> GetTaskList()
    {
        var result = await _httpClient.GetFromJsonAsync<List<TaskDto>>("/api/tasks");
        return result;
    }
}