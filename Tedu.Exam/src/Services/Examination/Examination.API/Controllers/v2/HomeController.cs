using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examination.API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Returns a welcome message for the Examination API.
        /// </summary>
        /// <returns>A string message.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to Tedu.Exam.Examination API version 2!");
        }
    }
}
