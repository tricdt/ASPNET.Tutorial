using System;
using Microsoft.AspNetCore.Identity;

namespace Sala.TodoApp.Data.Entities;

public class Role : IdentityRole<Guid>
{
    public string Description { get; set; }
}
