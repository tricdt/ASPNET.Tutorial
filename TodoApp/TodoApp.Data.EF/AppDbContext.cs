using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TodoApp.Data.EF.Configurations;
using TodoApp.Data.EF.Extensions;
using TodoApp.Data.Entities;

namespace TodoApp.Data.EF;

public class AppDbContext : IdentityDbContext<User, Role, Guid>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> AppUsers { get; set; }
    public DbSet<Role> AppRoles { get; set; }
    public DbSet<Todo> Todos { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        builder.AddConfiguration(new RoleConfiguartion());
        builder.AddConfiguration(new UserConfiguration());
        builder.AddConfiguration(new TodoConfiguration());
    }
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json").Build();
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);
        return new AppDbContext(builder.Options);
    }
}
