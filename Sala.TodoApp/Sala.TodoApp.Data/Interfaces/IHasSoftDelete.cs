using System;

namespace Sala.TodoApp.Data.Interfaces;

public interface IHasSoftDelete
{
    bool IsDeleted { set; get; }
}
