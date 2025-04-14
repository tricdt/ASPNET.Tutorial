using System;
using Tedu.Shop.Application.Ecommerce.ProductCategories.Dtos;
using Tedu.Shop.Data.Entities.Ecommerce;

namespace Tedu.Shop.Application.Ecommerce.ProductCategories;

 public interface IProductCategoryService : IWebServiceBase<ProductCategory, Guid, ProductCategoryViewModel>
    {
        List<ProductCategoryViewModel> GetAll(string keyword);

        List<ProductCategoryViewModel> GetAllByParentId(Guid? parentId);

        void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items);

        void ReOrder(Guid sourceId, Guid targetId);

        List<ProductCategoryViewModel> GetHomeCategories(int top);
    }
