using System;
using AutoMapper;
using Tedu.CoreApp.Application.Ecommerce.ProductCategories.Dtos;
using Tedu.CoreApp.Application.Ecommerce.Products.Dtos;
using Tedu.CoreApp.Application.Systems.Functions.Dtos;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Data.Entities.System;

namespace Tedu.CoreApp.Application.AutoMapper;

public class MappingProfile :Profile
{
    public MappingProfile()
    {
        CreateMap<Function, FunctionViewModel>().ReverseMap();
        CreateMap<Product, ProductViewModel>().ReverseMap();
        CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();
    }
}

