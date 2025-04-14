using System;
using Microsoft.AspNetCore.Mvc;
using Tedu.Shop.Application.Ecommerce.ProductCategories;

namespace Tedu.Shop.Controllers.Components;

public class MobileMenuViewComponent : ViewComponent
{
    private IProductCategoryService _productCategoryService;
    public MobileMenuViewComponent(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var data = _productCategoryService.GetAll();
        return await Task.FromResult<IViewComponentResult>(View(_productCategoryService.GetAll()));
    }
}
