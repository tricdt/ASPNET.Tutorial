using System;
using Tedu.TodoBlazor.Models;

namespace Tedu.TodoBlazor.Wasm.Services;

public interface IUserApiClient
{
    Task<List<AssigneeDto>> GetAssignees();
}
