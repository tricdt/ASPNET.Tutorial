using AutoMapper;
using DDD.TodoApp.Commands.Tasks;
using DDD.TodoApp.ViewModels.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.TodoApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private const string NotificationMessageKey = "NotificationMessage";

        public TasksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(TasksIndexViewModelQuery query)
        {
            var model = await _mediator.Send(query);
            model.NotificationMessage = TempData[NotificationMessageKey] as string;
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = await _mediator.Send(new TasksEditViewModelQuery());
            return View("Edit", model);
        }

        public async Task<IActionResult> Edit(TasksEditViewModelQuery query)
        {
            var model = await _mediator.Send(query);
            if (model.Id == 0)
            {
                return NotFound();
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TasksEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new TaskAddOrEditCommand();
                _mapper.Map(model, command);
                var result = await _mediator.Send(command);
                if (result.Success)
                {
                    TempData[NotificationMessageKey] = $"Task {(model.IsAdding ? "created" : "updated")}";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, result.ErrorMessage);
            }

            return View(model);
        }

    }
}
