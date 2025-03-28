using System;
using System.ComponentModel.DataAnnotations;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

public class Tag : DomainEntity<string>
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [MaxLength(50)]
    [Required]
    public string Type { get; set; }
}