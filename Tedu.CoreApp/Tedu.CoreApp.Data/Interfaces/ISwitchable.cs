using System;
using Tedu.CoreApp.Data.Enums;

namespace Tedu.CoreApp.Data.Interfaces;

public interface ISwitchable
{
    Status Status { set; get; }
}
