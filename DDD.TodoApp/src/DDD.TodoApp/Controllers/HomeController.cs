using Microsoft.AspNetCore.Mvc;

namespace DDD.TodoApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Tasks");
        }

    }
}
