using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tedu.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet()]
        public string Get(){
            return "Home Controller";
        }
    }
}
