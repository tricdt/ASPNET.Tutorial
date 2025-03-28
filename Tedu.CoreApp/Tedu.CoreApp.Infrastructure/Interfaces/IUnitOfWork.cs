using System;

namespace Tedu.CoreApp.Infrastructure.Interfaces;

/// <summary>
/// Represents a unit of work
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Commits the changes to the underlying data store. 
    /// </summary>
    void Commit();
}
