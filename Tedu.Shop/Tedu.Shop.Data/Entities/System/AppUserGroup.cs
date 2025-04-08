using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;
[Table("ApplicationUserGroups")]
public class AppUserGroup : DomainEntity<Guid>
{
    [Required]
    public Guid UserId { set; get; }
    [Required]
    public Guid GroupId { set; get; }

    [ForeignKey("UserId")]
    public virtual AppUser AppUser { set; get; }

    [ForeignKey("GroupId")]
    public virtual AppGroup AppGroup { set; get; }
}
