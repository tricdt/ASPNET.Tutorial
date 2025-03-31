using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tedu.CoreApp.Data.Enums;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

[Table("ContactDetails")]
public class ContactDetail : DomainEntity<string>
{
    public ContactDetail()
    {
    }

    public ContactDetail(string id, string name, string phone, string email,
        string website, string address, string other, double? longtitude, double? latitude, Status status)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        Website = website;
        Address = address;
        Other = other;
        Lng = longtitude;
        Lat = latitude;
        Status = status;
    }

    [StringLength(250)]
    [Required]
    public string Name { set; get; }

    [StringLength(50)]
    public string Phone { set; get; }

    [StringLength(250)]
    public string Email { set; get; }

    [StringLength(250)]
    public string Website { set; get; }

    [StringLength(250)]
    public string Address { set; get; }

    public string? Other { set; get; }

    public double? Lat { set; get; }

    public double? Lng { set; get; }

    public Status Status { set; get; }
}