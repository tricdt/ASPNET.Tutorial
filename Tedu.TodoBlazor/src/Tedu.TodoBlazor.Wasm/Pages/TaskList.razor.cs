using System;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Tedu.TodoBlazor.Models;
using Tedu.TodoBlazor.Wasm.Services;

namespace Tedu.TodoBlazor.Wasm.Pages;

public partial class TaskList
{
    [Inject] private ITaskApiClient TaskApiClient { set; get; }
    [Inject] private IUserApiClient UserApiClient { set; get; }
    [Inject] private IToastService ToastService { set; get; }

    private List<TaskDto> Tasks;
    private List<AssigneeDto> Assignees;
    private TaskListSearch TaskListSearch = new TaskListSearch();

    protected override async Task OnInitializedAsync()
    {
        Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
        Assignees = await UserApiClient.GetAssignees();
    }

    private async Task SearchForm(EditContext context)
    {
        Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
        ToastService.ShowInfo("Search completed");
    }
}
