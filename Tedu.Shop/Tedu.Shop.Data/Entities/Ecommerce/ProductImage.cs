using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Ecommerce;

[Table("ProductImages")]
public class ProductImage : DomainEntity<Guid>, ISortable
{
    public Guid ProductId { get; set; }

    [StringLength(250)]
    public string Path { get; set; }

    [StringLength(250)]
    public string Caption { get; set; }

    public int SortOrder { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}