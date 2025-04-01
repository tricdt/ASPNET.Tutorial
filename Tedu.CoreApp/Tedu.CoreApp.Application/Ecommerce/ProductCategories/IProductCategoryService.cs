using System;
using Tedu.CoreApp.Application.Ecommerce.ProductCategories.Dtos;
using Tedu.CoreApp.Data.Entities;

namespace Tedu.CoreApp.Application.Ecommerce.ProductCategories;

    public interface IProductCategoryService : IWebServiceBase<ProductCategory, Guid, ProductCategoryViewModel>
    {
        List<ProductCategoryViewModel> GetAll(string keyword);

        List<ProductCategoryViewModel> GetAllByParentId(Guid? parentId);

        void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items);

        void ReOrder(Guid sourceId, Guid targetId);

        List<ProductCategoryViewModel> GetHomeCategories(int top);
    }