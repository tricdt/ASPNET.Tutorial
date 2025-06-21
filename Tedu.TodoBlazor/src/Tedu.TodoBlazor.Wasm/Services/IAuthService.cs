using System;
using Tedu.TodoBlazor.Models;

namespace Tedu.TodoBlazor.Wasm.Services;

public interface IAuthService
{
    Task<LoginResponse> Login(LoginRequest loginRequest);
    Task Logout();
}
