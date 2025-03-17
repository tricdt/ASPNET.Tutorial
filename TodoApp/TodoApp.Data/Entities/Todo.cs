using System;
using System.ComponentModel.DataAnnotations.Schema;
using TodoApp.Data.Enums;
using TodoApp.Infrastructure.SharedKernel;

namespace TodoApp.Data.Entities;

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
