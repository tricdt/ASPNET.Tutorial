using System;
using DDD.Domain.Events;
using MediatR;

namespace DDD.Domain.EventHandlers;

public class CustomerEventHandler :
    INotificationHandler<CustomerRegisteredEvent>,
    INotificationHandler<CustomerRemovedEvent>
{
    public Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(CustomerRemovedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
