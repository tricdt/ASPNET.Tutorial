using System;

namespace Tedu.CoreApp.Data.Interfaces;

public interface IMayHaveTenant
{
    Guid? TenantId { get; set; }
}
