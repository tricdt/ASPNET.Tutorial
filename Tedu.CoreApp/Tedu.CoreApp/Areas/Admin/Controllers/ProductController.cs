using Microsoft.AspNetCore.Mvc;
using Tedu.CoreApp.Application.Ecommerce.Products;

namespace Tedu.CoreApp.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }
        #region AJAX API
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(Guid? categoryId, string keyword, int page, int pageSize, string sortBy)
        {
            var model = _productService.GetAllPaging(categoryId, keyword, page, pageSize, sortBy);
            return new OkObjectResult(model);
        }
        #endregion
    }
}
