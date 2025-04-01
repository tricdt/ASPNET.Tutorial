using System;
using System.ComponentModel.DataAnnotations;
using Tedu.CoreApp.Application.Ecommerce.Products.Dtos;
using Tedu.CoreApp.Infrastructure.Enums;

namespace Tedu.CoreApp.Application.Ecommerce.ProductCategories.Dtos;

public class ProductCategoryViewModel
{
    public Guid Id { get; set; }
    public string Name { set; get; }

    public string Code { set; get; }

    [MaxLength(500)]
    public string Description { set; get; }

    public Guid? ParentId { set; get; }

    public int? HomeOrder { set; get; }

    public int CurrentIdentity { get; set; }

    [MaxLength(256)]
    public string Image { set; get; }

    public bool? HomeFlag { set; get; }

    public List<ProductViewModel> Products { set; get; }
    public DateTime DateCreated { set; get; }
    public DateTime DateModified { set; get; }
    public int SortOrder { set; get; }
    public Status Status { set; get; }

    [MaxLength(256)]
    public string SeoPageTitle { set; get; }

    [MaxLength(256)]
    public string SeoAlias { set; get; }

    [MaxLength(256)]
    public string SeoKeywords { set; get; }

    [MaxLength(256)]
    public string SeoDescription { set; get; }
}
