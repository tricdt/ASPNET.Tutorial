using System;
using Tedu.CoreApp.Application.Dtos;
using Tedu.CoreApp.Application.Ecommerce.Products.Dtos;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Utilities.Dtos;

namespace Tedu.CoreApp.Application.Ecommerce.Products;

public interface IProductService : IWebServiceBase<Product, Guid, ProductViewModel>
{

    PagedResult<ProductViewModel> GetAllPaging(Guid? categoryId, string keyword, int page, int pageSize, string sortBy);

    List<ProductViewModel> GetLastest(int top);

    List<ProductViewModel> GetHotProduct(int top);

    List<ProductViewModel> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, out int totalRow);

    List<ProductViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

    List<ProductViewModel> GetListProduct(string keyword);

    List<ProductViewModel> GetReatedProducts(Guid id, int top);

    List<string> GetListProductByName(string name);

    List<TagViewModel> GetListTagByProductId(Guid id);

    TagViewModel GetTag(string tagId);

    void IncreaseView(Guid id);

    List<ProductViewModel> GetListProductByTag(string tagId, int page, int pagesize, out int totalRow);

    List<TagViewModel> GetListProductTag(string searchText);

    void ImportExcel(string filePath, Guid categoryId);

    void AddImages(Guid productId, string[] images);

    List<ProductImageViewModel> GetImages(Guid productId);

    List<ProductViewModel> GetUpsellProducts(int top);

    PagedResult<ProductViewModel> GetMyWishlist(Guid userId, int page, int pageSize);
}