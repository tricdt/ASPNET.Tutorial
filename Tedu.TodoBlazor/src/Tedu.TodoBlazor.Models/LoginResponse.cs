using System;

namespace Tedu.TodoBlazor.Models;

public class LoginResponse
{
    public bool Successful { get; set; }
    public string Error { get; set; }
    public string Token { get; set; }
}
