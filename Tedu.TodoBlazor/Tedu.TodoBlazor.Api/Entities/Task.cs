using System;
using System.ComponentModel.DataAnnotations;
using Tedu.TodoBlazor.Api.Enums;

namespace Tedu.TodoBlazor.Api.Entities;

public class Task
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid? Assignee { get; set; }

    public DateTime CreatedDate { get; set; }

    public Priority Priority { get; set; }

    public Status Status { get; set; }
}
