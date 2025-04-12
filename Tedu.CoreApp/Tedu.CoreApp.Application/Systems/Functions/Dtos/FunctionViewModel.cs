using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Tedu.CoreApp.Data.Entities.System;
using Tedu.CoreApp.Infrastructure.Enums;

namespace Tedu.CoreApp.Application.Systems.Functions.Dtos;

public class FunctionViewModel
{
    public Guid Id { set; get; }

    [Required]
    [MaxLength(50)]
    public string Name { set; get; }

    [Required]
    [MaxLength(256)]
    public string URL { set; get; }

    public int DisplayOrder { set; get; }

    public Guid? ParentId { set; get; }

    public Status Status { set; get; }

    public string IconCss { get; set; }
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Function, FunctionViewModel>();
        }
    }
}
