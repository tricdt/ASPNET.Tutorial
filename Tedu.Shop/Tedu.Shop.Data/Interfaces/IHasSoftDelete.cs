using System;

namespace Tedu.Shop.Data.Interfaces;

public interface IHasSoftDelete
{
    bool IsDeleted { set; get; }
}
