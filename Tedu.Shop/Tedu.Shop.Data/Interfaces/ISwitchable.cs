using System;
using Tedu.Shop.Infrastructure.Enums;

namespace Tedu.Shop.Data.Interfaces;

public interface ISwitchable
{
    Status Status { set; get; }
}
