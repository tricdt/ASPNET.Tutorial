using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tedu.TodoBlazor.Api.Entities;
namespace Tedu.TodoBlazor.Api.Data;

public class TodoListDbContext : IdentityDbContext<User, Role, Guid>
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
    {

    }

    public DbSet<Entities.Task> Tasks { set; get; }
}