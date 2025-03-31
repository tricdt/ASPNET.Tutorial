using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Tedu.CoreApp.Data.Enums;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.Enums;

namespace Tedu.CoreApp.Data.Entities;

[Table("AppUsers")]
public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
{
    public AppUser()
    {
    }

    public AppUser(string fullName, string userName, string email, string phoneNumber, string avatar, Status status)
    {
        FullName = fullName;
        UserName = userName;
        Email = email;
        PhoneNumber = phoneNumber;
        Avatar = avatar;
        Status = status;
    }

    public AppUser(Guid id, string fullName, string userName,
        string email, string phoneNumber, string avatar, Status status)
    {
        Id = id;
        FullName = fullName;
        UserName = userName;
        Email = email;
        PhoneNumber = phoneNumber;
        Avatar = avatar;
        Status = status;
    }

    public string FullName { get; set; }

    public DateTime? BirthDay { set; get; }

    public decimal Balance { get; set; }

    public string Avatar { get; set; }

    public DateTime DateCreated { set; get; }
    public DateTime? DateModified { set; get; }
    public DateTime? DateDeleted { set; get; }
    public Status Status { set; get; }

}