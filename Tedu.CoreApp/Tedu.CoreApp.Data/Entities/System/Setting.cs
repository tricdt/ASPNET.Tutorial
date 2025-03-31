using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities.System;

[Table("Settings")]
public class Setting : DomainEntity<Guid>, ISwitchable, IHasUniqueCode
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    public string TextValue { get; set; }

    public int? IntegerValue { get; set; }

    public bool? BooleanValue { get; set; }

    public DateTime? DateValue { get; set; }

    public decimal? DecimalValue { get; set; }

    public Status Status { get; set; }

    public string UniqueCode { get; set; }
}