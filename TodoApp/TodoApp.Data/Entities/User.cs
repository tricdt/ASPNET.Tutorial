using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TodoApp.Data.Entities;

public class User : IdentityUser<Guid>
{
        public string FirstName { get; set; }
        public string LastName { get; set; }
}
