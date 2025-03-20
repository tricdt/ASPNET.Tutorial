using System;

namespace XTLab.MvcApp.Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Call save change from db context
    /// </summary>
    void Commit();
}