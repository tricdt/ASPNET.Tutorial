using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Ecommerce;

[Table("ProductTags")]
public class ProductTag : DomainEntity<Guid>
{
    public Guid ProductId { set; get; }

    public string TagId { set; get; }
    [ForeignKey("ProductId")]
    public virtual Product Product { set; get; }
    [ForeignKey("TagId")]
    public virtual Tag Tag { set; get; }
}