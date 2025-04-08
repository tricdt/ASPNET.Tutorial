using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.Enums;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Content;

[Table("Feedbacks")]
public class Feedback : DomainEntity<Guid>, ISwitchable, IDateTracking
{
    public Feedback()
    {
    }

    public Feedback(Guid id, string name, string email,
        string message, Status status)
    {
        Id = id;
        Name = name;
        Email = email;
        Message = message;
        Status = status;
    }

    [StringLength(250)]
    [Required]
    public string Name { set; get; }

    [StringLength(250)]
    public string Email { set; get; }

    [StringLength(500)]
    public string Message { set; get; }

    public Status Status { set; get; }
    public DateTime DateCreated { set; get; }
    public DateTime? DateModified { set; get; }
    public DateTime? DateDeleted { set; get; }
}