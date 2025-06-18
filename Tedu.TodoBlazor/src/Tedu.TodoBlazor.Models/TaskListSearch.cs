using System;
using Tedu.TodoBlazor.Models.Enums;

namespace Tedu.TodoBlazor.Models;

public class TaskListSearch
{
    public string Name { get; set; }

    public Guid? AssigneeId { get; set; }

    public Priority? Priority { get; set; }
}
