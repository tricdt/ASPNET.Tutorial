using System;
using Microsoft.EntityFrameworkCore;

namespace DDD.TodoApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure entity properties and relationships here
    }
}
