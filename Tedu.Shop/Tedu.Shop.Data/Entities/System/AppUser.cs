using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Tedu.Shop.Data.Entities.System;
[Table("AppUsers")]
public class AppUser : IdentityUser<Guid>
{
    public AppUser()
    {
        
    }
    public AppUser(string fullName, string userName, string email, string phoneNumber, string avatar, bool status)
    {
        FullName = fullName;
        UserName = userName;
        Email = email;
        PhoneNumber = phoneNumber;
        Avatar = avatar;
        Status = status;
    }
    [MaxLength(256)]
    public string FullName { set; get; }

    [MaxLength(256)]
    public string Address { set; get; }

    public string Avatar { get; set; }

    public DateTime? BirthDay { set; get; }

    public bool? Status { get; set; }

    public bool? Gender { get; set; }

}


// [Table("AppUsers")]
// public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
// {
//     public AppUser()
//     {
//     }

//     public AppUser(string fullName, string userName, string email, string phoneNumber, string avatar, Status status)
//     {
//         FullName = fullName;
//         UserName = userName;
//         Email = email;
//         PhoneNumber = phoneNumber;
//         Avatar = avatar;
//         Status = status;
//     }

//     public AppUser(Guid id, string fullName, string userName, 
//         string email, string phoneNumber, string avatar, Status status)
//     {
//         Id = id;
//         FullName = fullName;
//         UserName = userName;
//         Email = email;
//         PhoneNumber = phoneNumber;
//         Avatar = avatar;
//         Status = status;
//     }

//     public string FullName { get; set; }

//     public DateTime? BirthDay { set; get; }

//     public decimal Balance { get; set; }

//     public string Avatar { get; set; }

//     public DateTime DateCreated { set; get; }
//     public DateTime? DateModified { set; get; }
//     public DateTime? DateDeleted { set; get; }
//     public Status Status { set; get; }
// }
