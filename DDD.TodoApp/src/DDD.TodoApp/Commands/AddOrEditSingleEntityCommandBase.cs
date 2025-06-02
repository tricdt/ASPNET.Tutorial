using System;

namespace DDD.TodoApp.Commands;

public class AddOrEditSingleEntityCommandBase : SingleEntityCommandBase
{
    public bool IsAdding => Id == 0;
}
