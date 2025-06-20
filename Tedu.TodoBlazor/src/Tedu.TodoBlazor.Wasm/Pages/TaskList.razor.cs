using System;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Tedu.TodoBlazor.Models;
using Tedu.TodoBlazor.Models.SeedWork;
using Tedu.TodoBlazor.Wasm.Components;
using Tedu.TodoBlazor.Wasm.Services;

namespace Tedu.TodoBlazor.Wasm.Pages;

public partial class TaskList
{
    [Inject] private ITaskApiClient TaskApiClient { set; get; }

    protected Confirmation DeleteConfirmation { set; get; }
    protected AssignTask AssignTaskDialog { set; get; }
    private Guid DeleteId { set; get; }
    private List<TaskDto> Tasks;
    public MetaData MetaData { get; set; } = new MetaData();
    private TaskListSearch TaskListSearch = new TaskListSearch();
    protected override async Task OnInitializedAsync()
    {
        await GetTasks();
    }
    public async Task SearchTask(TaskListSearch taskListSearch)
    {
        TaskListSearch = taskListSearch;
        await GetTasks();
    }
    public void OnDeleteTask(Guid deleteId)
    {
        DeleteId = deleteId;
        DeleteConfirmation.Show();
    }
    public async Task OnConfirmDeleteTask(bool deleteConfirmed)
    {
        if (deleteConfirmed)
        {
            await TaskApiClient.DeleteTask(DeleteId);
            await GetTasks();
        }
    }

    public void OpenAssignPopup(Guid id)
    {
        AssignTaskDialog.Show(id);
    }

    public async Task AssignTaskSuccess(bool result)
    {
        if (result)
        {
            await GetTasks();
        }
    }

    private async Task GetTasks()
    {
        var pagingResponse = await TaskApiClient.GetTaskList(TaskListSearch);
        Tasks = pagingResponse.Items;
        MetaData = pagingResponse.MetaData;
    }
    private async Task SelectedPage(int page)
    {
        TaskListSearch.PageNumber = page;
        await GetTasks();
    }
}
