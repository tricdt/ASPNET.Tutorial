using System;
using Tedu.TodoBlazor.Models.Enums;
using Tedu.TodoBlazor.Models.SeedWork;

namespace Tedu.TodoBlazor.Models;

public class TaskListSearch : PagingParameters
{
    public string Name { get; set; }

    public Guid? AssigneeId { get; set; }

    public Priority? Priority { get; set; }
}
