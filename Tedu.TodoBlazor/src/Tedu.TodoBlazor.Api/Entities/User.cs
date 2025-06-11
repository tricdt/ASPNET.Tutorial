using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Tedu.TodoBlazor.Api.Entities;

public class User : IdentityUser<Guid>
{
    [MaxLength(250)]
    [Required]
    public string FirstName { get; set; }

    [MaxLength(250)]
    [Required]
    public string LastName { get; set; }
}