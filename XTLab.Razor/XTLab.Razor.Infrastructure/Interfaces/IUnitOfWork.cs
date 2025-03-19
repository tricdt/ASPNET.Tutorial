using System;

namespace XTLab.Razor.Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Call save change from db context
    /// </summary>
    void Commit();
}