using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Enums;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Ecommerce;

[Table("Tags")]
public class Tag : DomainEntity<string>
{
    [MaxLength(50)]
    [Required]
    public string Name { set; get; }

    [Required]
    public TagType Type { set; get; }
}
