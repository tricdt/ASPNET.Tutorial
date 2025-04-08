using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;
[Table("AnnouncementUsers")]
public class AnnouncementUser : DomainEntity<Guid>
{
    [Required]
    public Guid AnnouncementId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    public bool HasRead { get; set; }

    [ForeignKey("UserId")]
    public virtual AppUser AppUser { get; set; }

    [ForeignKey("AnnouncementId")]
    public virtual Announcement Announcement { get; set; }
}
