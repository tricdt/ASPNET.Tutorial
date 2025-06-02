using System;

namespace DDD.TodoApp.ViewModels;

public class AddOrEditSingleEntityViewModelBase : SingleEntityViewModelBase
{
    public bool IsAdding => Id == 0;
}
