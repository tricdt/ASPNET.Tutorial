using System;

namespace Tedu.Shop.Data.Interfaces;

public interface IMayHaveTenant
{
    Guid? TenantId { get; set; }
}
