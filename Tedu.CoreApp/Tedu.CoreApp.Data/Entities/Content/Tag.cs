using System;
using System.ComponentModel.DataAnnotations;
using Tedu.CoreApp.Data.Enums;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

public class Tag : DomainEntity<string>
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [MaxLength(50)]
    [Required]
    public TagType Type { get; set; }
}