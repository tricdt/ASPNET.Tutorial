using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tedu.CoreApp.Data.Enums;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.SharedKernel;
namespace Tedu.CoreApp.Data.Entities;

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