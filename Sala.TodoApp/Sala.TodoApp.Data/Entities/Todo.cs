using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sala.TodoApp.Data.Enums;
using Sala.TodoApp.Infrastructure.SharedKernel;

namespace Sala.TodoApp.Data.Entities;

public class Todo : DomainEntity<Guid>
{
    public string Name { get; set; }
    public Guid? AssigneeId { get; set; }
    [ForeignKey("AssigneeId")]
    public virtual User? Assignee { get; set; }
    public DateTime CreatedDate { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }

}