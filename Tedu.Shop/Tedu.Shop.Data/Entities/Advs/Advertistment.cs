using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.Enums;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Advs;

[Table("Advertistments")]
public class Advertistment : DomainEntity<Guid>, ISwitchable, ISortable
{
    [StringLength(250)]
    public string Name { get; set; }

    [StringLength(250)]
    public string Description { get; set; }

    [StringLength(250)]
    public string Image { get; set; }

    [StringLength(250)]
    public string Url { get; set; }

    public Guid PositionId { get; set; }

    public Status Status { set; get; }
    public DateTime DateCreated { set; get; }
    public DateTime? DateModified { set; get; }
    public int SortOrder { set; get; }
}