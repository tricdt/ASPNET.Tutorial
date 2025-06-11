using System;
using Tedu.TodoBlazor.Models.Enums;

namespace Tedu.TodoBlazor.Models;

public class TaskUpdateRequest
{
    public string Name { get; set; }

    public Priority Priority { get; set; }
}
