using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

[Table("AdvertistmentPositions")]
public class AdvertistmentPosition : DomainEntity<Guid>
{
    [StringLength(20)]
    public Guid PageId { get; set; }

    [StringLength(250)]
    public string Name { get; set; }

    [ForeignKey("PageId")]
    public virtual AdvertistmentPage AdvertistmentPage { get; set; }

    public virtual ICollection<Advertistment> Advertistments { get; set; }
}