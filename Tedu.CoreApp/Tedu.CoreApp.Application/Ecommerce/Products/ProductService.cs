using System;
using AutoMapper;
using Tedu.CoreApp.Application.Dtos;
using Tedu.CoreApp.Application.Ecommerce.Products.Dtos;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Data.Entities.Ecommerce;
using Tedu.CoreApp.Data.Enums;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.Interfaces;
using Tedu.CoreApp.Utilities.Dtos;
using Tedu.CoreApp.Utilities.Helpers;
using OfficeOpenXml;
namespace Tedu.CoreApp.Application.Ecommerce.Products;

public class ProductService : WebServiceBase<Product, Guid, ProductViewModel>, IProductService
{
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly IRepository<Tag, string> _tagRepository;
    private readonly IRepository<ProductTag, Guid> _productTagRepository;
    private readonly IRepository<ProductImage, Guid> _productImageRepository;
    private readonly IRepository<ProductCategory, Guid> _productCategoryRepository;
    private readonly IRepository<ProductWishlist, Guid> _productWishlistRepository;
    private readonly IMapper _mapper;

    public ProductService(IRepository<Product, Guid> productRepository,
        IRepository<ProductTag, Guid> productTagRepository,
        IRepository<ProductWishlist, Guid> productWishlistRepository,
        IRepository<Tag, string> tagRepository,
        IRepository<ProductCategory, Guid> productCategoryRepository,
        IRepository<ProductImage, Guid> productImageRepository,
        IUnitOfWork unitOfWork, IMapper mapper)
        : base(productRepository, unitOfWork, mapper)
    {
        _productRepository = productRepository;
        _productTagRepository = productTagRepository;
        _productImageRepository = productImageRepository;
        _productCategoryRepository = productCategoryRepository;
        _tagRepository = tagRepository;
        _productWishlistRepository = productWishlistRepository;
        _mapper = mapper;
    }

    public override void Add(ProductViewModel productVm)
    {
        var product = _mapper.Map<ProductViewModel, Product>(productVm);
        if (string.IsNullOrEmpty(productVm.SeoAlias))
            product.SeoAlias = TextHelper.ToUnsignString(productVm.Name);

        if (string.IsNullOrEmpty(productVm.Code))
        {
            var category = _productCategoryRepository.GetById(productVm.CategoryId);
            var code = category.Code + (category.CurrentIdentity + 1).ToString("0000");
            category.CurrentIdentity += 1;
            product.Code = code;
        }

        if (!string.IsNullOrEmpty(productVm.Tags))
        {
            string[] tags = productVm.Tags.Split(',');
            foreach (string t in tags)
            {
                var tagId = TextHelper.ToUnsignString(t);
                if (!_tagRepository.GetAll().Where(x => x.Id.ToString() == tagId).Any())
                {
                    Tag tag = new Tag
                    {
                        Id = tagId,
                        Name = t,
                        Type = TagType.Product
                    };
                    _tagRepository.Insert(tag);
                }

                ProductTag productTag = new ProductTag
                {
                    TagId = tagId
                };
                //product.ProductTags.Insert(productTag);
            }
        }
        _productRepository.Insert(product);
    }

    public PagedResult<ProductViewModel> GetAllPaging(Guid? categoryId, string keyword, int page, int pageSize, string sortBy)
    {
        var query = _productRepository.GetAll().Where(c => c.Status == Status.Actived);
        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(x => x.Name.Contains(keyword) || x.Code.Contains(keyword));

        if (categoryId.HasValue)
            query = query.Where(x => x.CategoryId == categoryId.Value);

        int totalRow = query.Count();
        switch (sortBy)
        {
            case "price":
                query = query.OrderByDescending(x => x.Price);
                break;

            case "name":
                query = query.OrderBy(x => x.Name);
                break;

            case "lastest":
                query = query.OrderByDescending(x => x.DateCreated);
                break;

            default:
                query = query.OrderByDescending(x => x.DateCreated);
                break;
        }
        query = query.Skip((page - 1) * pageSize)
            .Take(pageSize);

        var data = _mapper.ProjectTo<ProductViewModel>(query).ToList();
        var paginationSet = new PagedResult<ProductViewModel>()
        {
            Results = data,
            CurrentPage = page,
            RowCount = totalRow,
            PageSize = pageSize
        };

        return paginationSet;
    }

    public override void Update(ProductViewModel productVm)
    {
        var product = _mapper.Map<ProductViewModel, Product>(productVm);
        _productTagRepository.Delete(x => x.Id == product.Id);

        if (!string.IsNullOrEmpty(productVm.Tags))
        {
            string[] tags = productVm.Tags.Split(',');
            foreach (string t in tags)
            {
                var tagId = TextHelper.ToUnsignString(t);
                if (!_tagRepository.GetAll().Where(x => x.Id == tagId).Any())
                {
                    Tag tag = new Tag();
                    tag.Id = tagId;
                    tag.Name = t;
                    tag.Type = TagType.Product;
                    _tagRepository.Insert(tag);
                }
                ProductTag productTag = new ProductTag
                {
                    TagId = tagId
                };
                //product.ProductTags.Insert(productTag);
            }
        }
        _productRepository.Update(product);
    }

    public List<ProductViewModel> GetLastest(int top)
    {
        var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived).OrderByDescending(x => x.DateCreated)
            .Take(top);
        return _mapper.ProjectTo<ProductViewModel>(query).ToList();
    }

    public List<ProductViewModel> GetHotProduct(int top)
    {
        var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived && x.HotFlag == true)
            .OrderByDescending(x => x.DateCreated)
            .Take(top);
        return _mapper.ProjectTo<ProductViewModel>(query).ToList();
    }

    public List<ProductViewModel> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, out int totalRow)
    {
        var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived && x.CategoryId == categoryId);

        switch (sort)
        {
            case "popular":
                query = query.OrderByDescending(x => x.ViewCount);
                break;

            case "discount":
                query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                break;

            case "price":
                query = query.OrderBy(x => x.Price);
                break;

            default:
                query = query.OrderByDescending(x => x.DateCreated);
                break;
        }

        totalRow = query.Count();

        return _mapper.ProjectTo<ProductViewModel>(query.Skip((page - 1) * pageSize)
            .Take(pageSize)).ToList();
    }

    public List<string> GetListProductByName(string name)
    {
        return _productRepository.GetAll().Where(x => x.Status == Status.Actived
        && x.Name.Contains(name)).Select(y => y.Name).ToList();
    }

    public List<ProductViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
    {
        var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived
        && x.Name.Contains(keyword));

        switch (sort)
        {
            case "popular":
                query = query.OrderByDescending(x => x.ViewCount);
                break;

            case "discount":
                query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                break;

            case "price":
                query = query.OrderBy(x => x.Price);
                break;

            default:
                query = query.OrderByDescending(x => x.DateCreated);
                break;
        }

        totalRow = query.Count();

        return _mapper.ProjectTo<ProductViewModel>(query.Skip((page - 1) * pageSize)
            .Take(pageSize))
            .ToList();
    }

    public List<ProductViewModel> GetReatedProducts(Guid id, int top)
    {
        var product = _productRepository.GetById(id);
        var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived
            && x.Id != id && x.CategoryId == product.CategoryId)
        .OrderByDescending(x => x.DateCreated)
        .Take(top);
        return _mapper.ProjectTo<ProductViewModel>(query).ToList();
    }

    public List<TagViewModel> GetListTagByProductId(Guid id)
    {
        var query = _productTagRepository.GetAll().Where(x => x.ProductId == id);
        return _mapper.ProjectTo<TagViewModel>(query).ToList();
    }

    public void IncreaseView(Guid id)
    {
        var product = _productRepository.GetById(id);
        if (product.ViewCount.HasValue)
            product.ViewCount += 1;
        else
            product.ViewCount = 1;
    }

    public List<ProductViewModel> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
    {
        var query = from p in _productRepository.GetAll()
                    join pt in _productTagRepository.GetAll()
                    on p.Id equals pt.ProductId
                    where pt.TagId == tagId
                    select p;
        totalRow = query.Count();

        var model = _mapper.ProjectTo<ProductViewModel>(query.OrderByDescending(x => x.DateCreated)
            .Skip((page - 1) * pageSize)
            .Take(pageSize));
        return model.ToList();
    }

    public TagViewModel GetTag(string tagId)
    {
        return _mapper.Map<Tag, TagViewModel>(_tagRepository.Single(x => x.Id == tagId));
    }


    public List<ProductViewModel> GetListProduct(string keyword)
    {
        IQueryable<ProductViewModel> query;
        if (!string.IsNullOrEmpty(keyword))
            query = _mapper.ProjectTo<ProductViewModel>(_productRepository.GetAll().Where(x => x.Name.Contains(keyword)));
        else
            query = _mapper.ProjectTo<ProductViewModel>(_productRepository.GetAll());
        return query.ToList();
    }

    public List<TagViewModel> GetListProductTag(string searchText)
    {
        return _mapper.ProjectTo<TagViewModel>(_tagRepository.GetAll().Where(x => x.Type == TagType.Product
        && searchText.Contains(x.Name))).ToList();
    }

    public void ImportExcel(string filePath, Guid categoryId)
    {
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
            Product product;
            for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
            {
                product = new Product();
                product.CategoryId = categoryId;
                product.Name = workSheet.Cells[i, 1].Value.ToString();
                product.Description = workSheet.Cells[i, 2].Value.ToString();
                decimal.TryParse(workSheet.Cells[i, 3].Value.ToString(), out var originalPrice);
                product.OriginalPrice = originalPrice;
                decimal.TryParse(workSheet.Cells[i, 4].Value.ToString(), out var price);
                product.Price = price;
                decimal.TryParse(workSheet.Cells[i, 5].Value.ToString(), out var promotionPrice);

                product.PromotionPrice = promotionPrice;
                product.Content = workSheet.Cells[i, 6].Value.ToString();
                product.SeoKeywords = workSheet.Cells[i, 7].Value.ToString();

                product.SeoDescription = workSheet.Cells[i, 8].Value.ToString();
                bool.TryParse(workSheet.Cells[i, 9].Value.ToString(), out var hotFlag);
                product.HotFlag = hotFlag;
                bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out var homeFlag);
                product.HomeFlag = homeFlag;

                product.Status = Status.Actived;

                _productRepository.Insert(product);
            }
        }
    }

    public void AddImages(Guid productId, string[] images)
    {
        _productImageRepository.Delete(x => x.ProductId == productId);
        foreach (var image in images)
        {
            _productImageRepository.Insert(new ProductImage()
            {
                Path = image,
                ProductId = productId,
                Caption = string.Empty
            });
        }
    }

    public List<ProductImageViewModel> GetImages(Guid productId)
    {
        var query = _productImageRepository.GetAll().Where(x => x.ProductId == productId);
        return _mapper.ProjectTo<ProductImageViewModel>(query).ToList();
    }

    public List<ProductViewModel> GetUpsellProducts(int top)
    {
        var query = _productRepository.GetAll().Where(x => x.PromotionPrice != null)
            .OrderByDescending(x => x.DateModified)
            .Take(top);
        return _mapper.ProjectTo<ProductViewModel>(query).ToList();
    }

    public PagedResult<ProductViewModel> GetMyWishlist(Guid userId, int page, int pageSize)
    {
        var query = _productWishlistRepository.GetAll().Where(c => c.UserId == userId);

        int totalRow = query.Count();

        query = query.Skip((page - 1) * pageSize)
            .Take(pageSize);

        var data = _mapper.ProjectTo<ProductViewModel>(query).ToList();
        var paginationSet = new PagedResult<ProductViewModel>()
        {
            Results = data,
            CurrentPage = page,
            RowCount = totalRow,
            PageSize = pageSize
        };

        return paginationSet;
    }
}