using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities.System;

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