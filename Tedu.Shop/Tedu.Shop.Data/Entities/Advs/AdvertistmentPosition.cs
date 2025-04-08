using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Advs;

[Table("AdvertistmentPositions")]
public class AdvertistmentPosition : DomainEntity<Guid>
{
    public Guid PageId { get; set; }

    [StringLength(250)]
    public string Name { get; set; }

}