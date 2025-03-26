using System;
using AutoMapper;
using XTLab.MvcApp.Application.ViewModels;
using XTLab.MvcApp.Data.Entities;

namespace XTLab.MvcApp.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Contact, ContactViewModel>().ReverseMap();
    }
}
