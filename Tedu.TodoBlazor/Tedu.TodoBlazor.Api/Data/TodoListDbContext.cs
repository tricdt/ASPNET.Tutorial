using System;
using Microsoft.EntityFrameworkCore;
namespace Tedu.TodoBlazor.Api.Data;

public class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
    {

    }

    public DbSet<Entities.Task> Tasks { set; get; }
}