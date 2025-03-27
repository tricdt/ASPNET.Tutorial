using System;
using Sala.TodoApp.Infrastructure.Interfaces;

namespace Sala.TodoApp.Data.EF;

/// <summary>
/// Defines a Unit of Work using an EF DbContext under the hood.
/// </summary>
public class EFUnitOfWork : IUnitOfWork
{
    private AppDbContext _context;
    public EFUnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}