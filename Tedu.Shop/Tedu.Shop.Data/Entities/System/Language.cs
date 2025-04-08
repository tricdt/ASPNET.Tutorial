using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.Enums;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;

[Table("Languages")]
public class Language : DomainEntity<string>, ISwitchable
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    public bool IsDefault { get; set; }

    public string Resources { get; set; }

    public Status Status { get; set; }
}