using Microsoft.AspNetCore.Mvc;
using XTLab.MvcApp.Application.Services;

namespace XTLab.MvcApp.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        // GET: FirstController
        public string Index()
        {
            _logger.LogWarning("Thong bao");
            _logger.LogError("Thong bao");
            _logger.LogDebug("Thong bao");
            _logger.LogCritical("Thong bao");
            _logger.LogInformation("Index Action");
            return "Toi la Index cua First";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }

        public object Anything() => new int[] { 1, 2, 3 };

        public IActionResult Readme()
        {
            var content = @"
            Xin chao cac ban,
            cac ban dang hoc ve ASP.NET MVC




            XUANTHULAB.NET
            ";
            return Content(content, "text/plain");
        }

        public IActionResult Bird()
        {
            // Startup.ContentRootPath
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "Birds.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");
        }
        public IActionResult IphonePrice()
        {
            return Json(
              new
              {
                  productName = "Iphone X",
                  Price = 1000
              }
            );
        }
        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url); // local ~ host 
        }

        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation("Chuyen huong den " + url);
            return Redirect(url); // local ~ host 
        }

        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
                username = "Khách";
            return View((object)username);
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                // TempData["StatusMessage"] = "San pham ban yeu cau khong co";
                StatusMessage = "Sản phẩm bạn yêu cầu không có";
                return Redirect(Url.Action("Index", "Home"));
            }

            //Model
            //return View(product);

            //ViewData
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");

            ViewBag.product = product;
            return View("ViewProduct3");
        }
    }
}
