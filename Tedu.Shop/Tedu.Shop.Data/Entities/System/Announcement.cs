using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.Enums;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;
[Table("Announcements")]
public class Announcement : DomainEntity<Guid>, ISwitchable, IDateTracking, IHasOwner<Guid>
{
    [Required]
    [StringLength(250)]
    public string Title { set; get; }

    [StringLength(250)]
    public string Content { set; get; }

    public DateTime DateCreated { set; get; }
    public DateTime? DateModified { set; get; }

    public DateTime? DateDeleted { set; get; }
    public Status Status { set; get; }
    public Guid OwnerId { set; get; }
    public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
}