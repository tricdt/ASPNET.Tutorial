using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Advs;

[Table("AdvertistmentPages")]
public class AdvertistmentPage : DomainEntity<Guid>, IHasUniqueCode
{
    public string UniqueCode { get; set; }
    public string Name { get; set; }

}