using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using XTLab.MvcApp.Data.EF.Configurations;
using XTLab.MvcApp.Data.EF.Extensions;
using XTLab.MvcApp.Data.Entities;

namespace XTLab.MvcApp.Data.EF;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

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
        builder.AddConfiguration(new ContactConfiguration());
    }

    public DbSet<Contact> Contacts { get; set; }
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
