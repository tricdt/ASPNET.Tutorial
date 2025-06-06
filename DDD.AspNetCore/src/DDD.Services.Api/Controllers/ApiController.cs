using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;
        public ApiController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }
    }
}
