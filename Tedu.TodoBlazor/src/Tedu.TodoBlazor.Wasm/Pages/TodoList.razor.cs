using System;
using Microsoft.AspNetCore.Components;
using Tedu.TodoBlazor.Models;
using Tedu.TodoBlazor.Wasm.Services;

namespace Tedu.TodoBlazor.Wasm.Pages;

public partial class TodoList
{
    [Inject] private ITaskApiClient TaskApiClient { set; get; }

    private List<TaskDto> Tasks;

    protected override async Task OnInitializedAsync()
    {
        Tasks = await TaskApiClient.GetTaskList();
    }
}
