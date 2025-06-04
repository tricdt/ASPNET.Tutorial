using System;
using DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}
