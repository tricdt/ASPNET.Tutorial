using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

[Table("BlogTags")]
public class PostTag : DomainEntity<Guid>
{
    public Guid PostId { set; get; }

    public Guid TagId { set; get; }

    [ForeignKey("PostId")]
    public virtual Post Post { set; get; }

    [ForeignKey("TagId")]
    public virtual Tag Tag { set; get; }

}