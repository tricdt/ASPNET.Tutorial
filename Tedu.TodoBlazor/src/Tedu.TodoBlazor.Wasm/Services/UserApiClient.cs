using System;
using System.Net.Http.Json;
using Tedu.TodoBlazor.Models;

namespace Tedu.TodoBlazor.Wasm.Services;

public class UserApiClient : IUserApiClient
{
    public HttpClient _httpClient;

    public UserApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AssigneeDto>> GetAssignees()
    {
        var result = await _httpClient.GetFromJsonAsync<List<AssigneeDto>>($"/api/users");
        return result;
    }
}