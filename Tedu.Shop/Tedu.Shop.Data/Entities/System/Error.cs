using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;

[Table("Errors")]
public class Error : DomainEntity<Guid>
{
    public string Message { set; get; }

    public string StackTrace { set; get; }

    public DateTime CreatedDate { set; get; }
}