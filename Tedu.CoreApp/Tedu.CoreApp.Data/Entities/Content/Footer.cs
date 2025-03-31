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

[Table("Footers")]
public class Footer : DomainEntity<string>, ISwitchable
{

    [Required]
    public string Content { set; get; }
    public Status Status { set; get; }
}
