using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace Tedu.TodoBlazor.Wasm.Pages;

public partial class FetchData
{
    private WeatherForecast[] forecasts;

    [Inject] private HttpClient Http { set; get; }

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}