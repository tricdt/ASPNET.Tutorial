using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

[Table("AnnouncementUsers")]
public class AnnouncementUser : DomainEntity<Guid>
{
    [Required]
    public Guid AnnouncementId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    public bool? HasRead { get; set; }

    [ForeignKey("UserId")]
    public virtual AppUser AppUser { get; set; }

    [ForeignKey("AnnouncementId")]
    public virtual Announcement Announcement { get; set; }
}