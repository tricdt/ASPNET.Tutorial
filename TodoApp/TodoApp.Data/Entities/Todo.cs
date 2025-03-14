using System;
using TodoApp.Data.Enums;
using TodoApp.Infrastructure.SharedKernel;

namespace TodoApp.Data.Entities;

public class Todo : DomainEntity<Guid>
{
    public string? Name { get; set; }

    public Guid? Assignee { get; set; }

    public DateTime CreatedDate { get; set; }

    public Priority Priority { get; set; }

    public Status Status { get; set; }
}
