using System;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Interfaces;
using MediatR;

namespace DDD.Domain.CommandHandler;

public class CustomerCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMediatorHandler _bus;
    public CustomerCommandHandler(
        IUnitOfWork uow,
        IMediatorHandler bus,
        INotificationHandler<DomainNotification> notifications,
        ICustomerRepository customerRepository)
    : base(uow, bus, notifications)
    {
        _customerRepository = customerRepository;
    }
    public Task<bool> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}
