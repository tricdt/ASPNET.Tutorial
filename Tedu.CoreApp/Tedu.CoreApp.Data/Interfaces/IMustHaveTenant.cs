using System;

namespace Tedu.CoreApp.Data.Interfaces;

public interface IMustHaveTenant
{
    Guid TenantId { get; set; }
}
