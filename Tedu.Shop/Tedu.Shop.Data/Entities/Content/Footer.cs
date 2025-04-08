using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.Enums;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Content;

[Table("Footers")]
public class Footer : DomainEntity<string>, ISwitchable
{
    [Required]
    public string Content { set; get; }

    public Status Status { set; get; }
}