using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;
[Table("ApplicationRoleGroups")]
public class AppRoleGroup : DomainEntity<Guid>
{
    [Required]
    public Guid GroupId { set; get; }

    [Required]
    public Guid RoleId { set; get; }
    
    [ForeignKey("RoleId")]
    public virtual AppRole AppRole { set; get; }

    [ForeignKey("GroupId")]
    public virtual AppGroup AppGroup { set; get; }
}
