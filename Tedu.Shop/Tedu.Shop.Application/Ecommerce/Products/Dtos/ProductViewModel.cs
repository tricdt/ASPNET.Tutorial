using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Tedu.Shop.Data.Entities.Ecommerce;
using Tedu.Shop.Infrastructure.Enums;

namespace Tedu.Shop.Application.Ecommerce.Products.Dtos;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string Name { set; get; }

    public string Code { set; get; }

    [Required]
    public Guid CategoryId { set; get; }

    [MaxLength(256)]
    public string ThumbnailImage { set; get; }

    public decimal Price { set; get; }

    public decimal OriginalPrice { set; get; }

    public decimal? PromotionPrice { set; get; }

    [MaxLength(500)]
    public string Description { set; get; }

    public string Content { set; get; }

    public bool? HomeFlag { set; get; }

    public bool? HotFlag { set; get; }

    public int? ViewCount { set; get; }

    public string Tags { set; get; }

    public int Quantity { set; get; }

    [StringLength(50)]
    public string Unit { get; set; }

    public DateTime DateCreated { set; get; }
    public DateTime DateModified { set; get; }
    public Status Status { set; get; }
    public string SeoPageTitle { set; get; }
    public string SeoAlias { set; get; }
    public string SeoKeywords { set; get; }
    public string SeoDescription { set; get; }
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
