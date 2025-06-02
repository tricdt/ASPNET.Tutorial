using DDD.TodoApp.ViewModels.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DDD.TodoApp.Controllers
{
    public class TasksController : Controller
    {
        // GET: TasksController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            var model = new TasksEditViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TasksEditViewModel model)
        {
            // if (ModelState.IsValid)
            // {
            //     var command = new TaskAddOrEditCommand();
            //     _mapper.Map(model, command);
            //     var result = await _mediator.SendAsync(command);
            //     if (result.Success)
            //     {
            //         TempData[NotificationMessageKey] = $"Task {(model.IsAdding ? "created" : "updated")}";
            //         return RedirectToAction("Index");
            //     }

            //     ModelState.AddModelError(string.Empty, result.ErrorMessage);
            // }

            return View(model);
        }

    }
}
