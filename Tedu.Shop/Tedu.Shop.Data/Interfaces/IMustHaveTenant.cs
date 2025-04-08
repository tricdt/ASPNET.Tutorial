using System;

namespace Tedu.Shop.Data.Interfaces;

public interface IMustHaveTenant
{
    Guid TenantId { get; set; }
}
