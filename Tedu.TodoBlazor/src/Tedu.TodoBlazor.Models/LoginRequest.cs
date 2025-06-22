using System;
using System.ComponentModel.DataAnnotations;

namespace Tedu.TodoBlazor.Models;

public class LoginRequest
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
