
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Tedu.CoreApp.Application.Ecommerce.ProductCategories.Dtos;
using Tedu.CoreApp.Application.Ecommerce.Products.Dtos;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.Interfaces;
using Tedu.CoreApp.Utilities.Helpers;

namespace Tedu.CoreApp.Application.Ecommerce.ProductCategories;

 public class ProductCategoryService : WebServiceBase<ProductCategory, Guid, ProductCategoryViewModel>,
        IProductCategoryService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<ProductCategory, Guid> _productCategoryRepository;

        private readonly IMapper _mapper;

        public ProductCategoryService(IRepository<ProductCategory, Guid> productCategoryRepository,
            IRepository<Product, Guid> productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(productCategoryRepository, unitOfWork, mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public override void Add(ProductCategoryViewModel productCategoryVm)
        {
            if (string.IsNullOrEmpty(productCategoryVm.SeoAlias))
                productCategoryVm.SeoAlias = TextHelper.ToUnsignString(productCategoryVm.Name);

            var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Insert(productCategory);
        }


        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetAll().Where(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId).ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider).ToList();
            return _productCategoryRepository.GetAll().OrderBy(x => x.ParentId)
                .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<ProductCategoryViewModel> GetAllByParentId(Guid? parentId)
        {
            return _productCategoryRepository.GetAll().Where(x => x.Status == Status.Actived && x.ParentId == parentId)
                .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _productCategoryRepository.GetAll().Where(x => x.HomeFlag == true)
                .OrderBy(x => x.HomeOrder).Take(top).ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider);
            var categories = query.ToList();
            foreach (var category in categories)
            {
                category.Products = _productRepository
                    .GetAll().Where(x => x.CategoryId == category.Id)
                    .OrderByDescending(x => x.DateCreated)
                    .Take(5)
                    .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider).ToList();
            }
            return categories;
        }

        public void ReOrder(Guid sourceId, Guid targetId)
        {
            var source = _productCategoryRepository.GetById(sourceId);
            var target = _productCategoryRepository.GetById(targetId);
            int tempOrder = source.SortOrder;

            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _productCategoryRepository.Update(source);
            _productCategoryRepository.Update(target);
        }

        public override void Update(ProductCategoryViewModel productCategoryVm)
        {
            if (string.IsNullOrEmpty(productCategoryVm.SeoAlias))
                productCategoryVm.SeoAlias = TextHelper.ToUnsignString(productCategoryVm.Name);

            var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);

            _productCategoryRepository.Update(productCategory);
        }

        public void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items)
        {
            //Update parent id for source
            var category = _productCategoryRepository.GetById(sourceId);
            category.ParentId = targetId;
            _productCategoryRepository.Update(category);

            //Get all sibling
            var sibling = _productCategoryRepository.GetAll().Where(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _productCategoryRepository.Update(child);
            }
        }
    }
