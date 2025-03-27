using System;
using Microsoft.AspNetCore.Identity;

namespace Sala.TodoApp.Data.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
