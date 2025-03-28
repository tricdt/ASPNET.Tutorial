using System;

namespace Tedu.CoreApp.Data.Interfaces;

public interface IHasOwner<T>
{
    T OwnerId { set; get; }
}
