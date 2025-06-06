using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers.v2
{
    [ApiVersion("2.0")]
    public class HomeController : ApiController
    {
        public HomeController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new
            {
                Message = "Welcome to DDD ASP.NET Core API",
                Version = "v2",
                Documentation = "https://tricdt.github.io/ASPNET.Tutorial/DDD.AspNetCore/README.md"
            });
        }
    }
}
