using System;
using System.ComponentModel.DataAnnotations;
using Tedu.TodoBlazor.Models.Enums;

namespace Tedu.TodoBlazor.Models;

public class TaskCreateRequest
{
    public Guid Id { get; set; }

    [MaxLength(250)]
    [Required]
    public string Name { get; set; }

    public Priority Priority { get; set; }
}
