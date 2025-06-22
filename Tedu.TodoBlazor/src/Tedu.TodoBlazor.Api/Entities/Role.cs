using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Tedu.TodoBlazor.Api.Entities;

public class Role : IdentityRole<Guid>
{
    [MaxLength(250)]
    [Required]
    public string Description { get; set; }
}