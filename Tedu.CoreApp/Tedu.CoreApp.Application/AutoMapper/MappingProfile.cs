using System;
using AutoMapper;
using Tedu.CoreApp.Application.Ecommerce.ProductCategories.Dtos;
using Tedu.CoreApp.Data.Entities;

namespace Tedu.CoreApp.Application.AutoMapper;

public class MappingProfile :Profile
{
    public MappingProfile()
    {
        CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();
            
        //   CreateMap<Contact, ContactViewModel>().ReverseMap();
        // CreateMap<Product, ProductViewModel>()
        //     .ForMember(d => d.Category, opt => opt.MapFrom(s => s.ProductCategory.Name))
        //     .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.ProductCategory.Id));
    }
}

