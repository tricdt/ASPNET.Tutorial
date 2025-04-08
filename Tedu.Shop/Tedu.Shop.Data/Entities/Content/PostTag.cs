using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Entities.Ecommerce;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Content;

[Table("BlogTags")]
public class PostTag : DomainEntity<Guid>
{
    public Guid PostId { set; get; }

    public string TagId { set; get; }
    [ForeignKey("TagId")]
    public virtual Tag Tag { set; get; }
    [ForeignKey("PostId")]
    public virtual Post Post { set; get; }

}