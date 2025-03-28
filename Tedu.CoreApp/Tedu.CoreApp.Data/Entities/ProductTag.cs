using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

public class ProductTag : DomainEntity<int>
{
    public int ProductId { get; set; }

    [StringLength(50)]
    [Column(TypeName = "varchar")]
    public string TagId { set; get; }

    [ForeignKey("ProductId")]
    public virtual Product Product { set; get; }

    [ForeignKey("TagId")]
    public virtual Tag Tag { set; get; }
}