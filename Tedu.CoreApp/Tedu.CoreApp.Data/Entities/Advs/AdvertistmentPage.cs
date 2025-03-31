using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

[Table("AdvertistmentPages")]
public class AdvertistmentPage : DomainEntity<Guid>, IHasUniqueCode
{
    public string Name { get; set; }
    public string UniqueCode { get; set; }
    public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
}