using System;

namespace Tedu.CoreApp.Data.Interfaces;

public interface IDateTracking
{
    DateTime DateCreated { set; get; }
    DateTime DateModified { set; get; }
}
