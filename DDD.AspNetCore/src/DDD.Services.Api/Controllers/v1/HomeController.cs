using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HomeController : ApiController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new
            {
                Message = "Welcome to DDD ASP.NET Core API",
                Version = "v1",
                Documentation = "https://tricdt.github.io/ASPNET.Tutorial/DDD.AspNetCore/README.md"
            });
        }
    }
}
