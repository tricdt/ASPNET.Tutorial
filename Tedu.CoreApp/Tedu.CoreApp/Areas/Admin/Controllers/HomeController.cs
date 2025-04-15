using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tedu.CoreApp.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
