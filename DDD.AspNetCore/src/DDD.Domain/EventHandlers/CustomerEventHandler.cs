using System;
using DDD.Domain.Events;
using MediatR;

namespace DDD.Domain.EventHandlers;

public class CustomerEventHandler : 
    INotificationHandler<CustomerRegisteredEvent>
{
    public Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
