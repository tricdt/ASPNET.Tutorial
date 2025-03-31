using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Data.Enums;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

[Table("Announcements")]
public class Announcement : DomainEntity<Guid>, ISwitchable, IDateTracking
{
    public Announcement()
    {
        AnnouncementUsers = new List<AnnouncementUser>();
    }

    [Required]
    [StringLength(250)]
    public string Title { set; get; }

    [StringLength(250)]
    public string Content { set; get; }

    public Guid OwnerId { set; get; }


    public DateTime DateCreated { set; get; }
    public DateTime? DateModified { set; get; }

    public DateTime? DateDeleted { set; get; }
    public Status Status { set; get; }

    public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
}