using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.SharedKernel;
namespace Tedu.CoreApp.Data.Entities;

[Table("ProductImages")]
public class ProductImage : DomainEntity<Guid>, ISortable
{
    public Guid ProductId { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    [StringLength(250)]
    public string Path { get; set; }

    [StringLength(250)]
    public string Caption { get; set; }
    public int SortOrder { get; set; }
}