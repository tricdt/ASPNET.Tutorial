using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tedu.TodoBlazor.Api.Extensions;
using Tedu.TodoBlazor.Api.Repositories;
using Tedu.TodoBlazor.Models;
using Tedu.TodoBlazor.Models.Enums;
using Tedu.TodoBlazor.Models.SeedWork;

namespace Tedu.TodoBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        //api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TaskListSearch taskListSearch)
        {
            var pagedList = await _taskRepository.GetTaskList(taskListSearch);
            var taskDtos = pagedList.Items.Select(x => new TaskDto()
            {
                Status = x.Status,
                Name = x.Name,
                AssigneeId = x.AssigneeId,
                CreatedDate = x.CreatedDate,
                Priority = x.Priority,
                Id = x.Id,
                AssigneeName = x.Assignee != null ? x.Assignee.FirstName + ' ' + x.Assignee.LastName : "N/A"
            });

            return Ok(new PagedList<TaskDto>(taskDtos.ToList(),
                pagedList.MetaData.TotalCount,
                pagedList.MetaData.CurrentPage,
                pagedList.MetaData.PageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _taskRepository.Create(new Entities.Task()
            {
                Name = request.Name,
                Priority = request.Priority.HasValue ? request.Priority.Value : Priority.Low,
                Status = Status.Open,
                CreatedDate = DateTime.Now,
                Id = request.Id

            });
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskFromDb = await _taskRepository.GetById(id);

            if (taskFromDb == null)
            {
                return NotFound($"{id} is not found");
            }

            taskFromDb.Name = request.Name;
            taskFromDb.Priority = request.Priority;

            var taskResult = await _taskRepository.Update(taskFromDb);

            return Ok(new TaskDto()
            {
                Name = taskResult.Name,
                Status = taskResult.Status,
                Id = taskResult.Id,
                AssigneeId = taskResult.AssigneeId,
                Priority = taskResult.Priority,
                CreatedDate = taskResult.CreatedDate
            });
        }


        //api/tasks/xxxx
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null) return NotFound($"{id} is not found");
            return Ok(new TaskDto()
            {
                Name = task.Name,
                Status = task.Status,
                Id = task.Id,
                AssigneeId = task.AssigneeId,
                Priority = task.Priority,
                CreatedDate = task.CreatedDate,
                AssigneeName = task.Assignee != null ? task.Assignee.FirstName + ' ' + task.Assignee.LastName : "N/A"
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null) return NotFound($"{id} is not found");

            await _taskRepository.Delete(task);
            return Ok(new TaskDto()
            {
                Name = task.Name,
                Status = task.Status,
                Id = task.Id,
                AssigneeId = task.AssigneeId,
                Priority = task.Priority,
                CreatedDate = task.CreatedDate
            });
        }

        [HttpPut]
        [Route("{id}/assign")]
        public async Task<IActionResult> AssignTask(Guid id, [FromBody] AssignTaskRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskFromDb = await _taskRepository.GetById(id);

            if (taskFromDb == null)
            {
                return NotFound($"{id} is not found");
            }

            taskFromDb.AssigneeId = request.UserId.Value == Guid.Empty ? null : request.UserId.Value;

            var taskResult = await _taskRepository.Update(taskFromDb);

            return Ok(new TaskDto()
            {
                Name = taskResult.Name,
                Status = taskResult.Status,
                Id = taskResult.Id,
                AssigneeId = taskResult.AssigneeId,
                Priority = taskResult.Priority,
                CreatedDate = taskResult.CreatedDate
            });
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetByAssigneeId([FromQuery] TaskListSearch taskListSearch)
        {
            var userId = User.GetUserId();
            var pagedList = await _taskRepository.GetTaskListByUserId(Guid.Parse(userId), taskListSearch);
            var taskDtos = pagedList.Items.Select(x => new TaskDto()
            {
                Status = x.Status,
                Name = x.Name,
                AssigneeId = x.AssigneeId,
                CreatedDate = x.CreatedDate,
                Priority = x.Priority,
                Id = x.Id,
                AssigneeName = x.Assignee != null ? x.Assignee.FirstName + ' ' + x.Assignee.LastName : "N/A"
            });

            return Ok(
                    new PagedList<TaskDto>(taskDtos.ToList(),
                        pagedList.MetaData.TotalCount,
                        pagedList.MetaData.CurrentPage,
                        pagedList.MetaData.PageSize)
                );
        }
    }
}
