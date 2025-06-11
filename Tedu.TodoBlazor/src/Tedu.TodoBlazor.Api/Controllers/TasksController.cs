using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tedu.TodoBlazor.Api.Repositories;

namespace Tedu.TodoBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetTaskList();
            return Ok(tasks);

        }
    }
}
