using System;
using System.Linq.Expressions;
using Sala.TodoApp.Infrastructure.SharedKernel;

namespace Sala.TodoApp.Infrastructure.Interfaces;

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