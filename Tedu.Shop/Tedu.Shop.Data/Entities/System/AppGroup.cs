using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;
[Table("ApplicationGroups")]
public class AppGroup : DomainEntity<Guid>
{
    [StringLength(250)]
    public string Name { set; get; }

    [StringLength(250)]
    public string Description { set; get; }
}
