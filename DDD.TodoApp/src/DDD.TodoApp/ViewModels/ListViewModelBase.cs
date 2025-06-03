using System;

namespace DDD.TodoApp.ViewModels;

public abstract class ListViewModelBase<T>
{
    public IEnumerable<T> Items { get; set; }

    public string NotificationMessage { get; set; }

    public bool ShowNotificationMessage => !string.IsNullOrEmpty(NotificationMessage);
}
