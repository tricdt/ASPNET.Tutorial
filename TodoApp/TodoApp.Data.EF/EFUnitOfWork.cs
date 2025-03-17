using System;
using TodoApp.Infrastructure.Interfaces;

namespace TodoApp.Data.EF;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
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
