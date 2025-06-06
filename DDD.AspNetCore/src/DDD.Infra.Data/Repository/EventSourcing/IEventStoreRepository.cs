using System;
using DDD.Domain.Core.Events;

namespace DDD.Infra.Data.Repository.EventSourcing;

public interface IEventStoreRepository : IDisposable
{
    void Store(StoredEvent theEvent);

    IList<StoredEvent> All(Guid aggregateId);
}