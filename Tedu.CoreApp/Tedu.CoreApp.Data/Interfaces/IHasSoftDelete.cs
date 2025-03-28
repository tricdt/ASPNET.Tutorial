using System;

namespace Tedu.CoreApp.Data.Interfaces;

public interface IHasSoftDelete
{
    bool IsDeleted { set; get; }
}
