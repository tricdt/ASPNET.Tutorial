using System;
using DDD.Domain.Models;
using DDD.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMap());
        base.OnModelCreating(modelBuilder);
    }
}
