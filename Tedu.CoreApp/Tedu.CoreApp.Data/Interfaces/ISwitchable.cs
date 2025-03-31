using System;
using Tedu.CoreApp.Infrastructure.Enums;

namespace Tedu.CoreApp.Data.Interfaces;

public interface ISwitchable
{
    Status Status { set; get; }
}
