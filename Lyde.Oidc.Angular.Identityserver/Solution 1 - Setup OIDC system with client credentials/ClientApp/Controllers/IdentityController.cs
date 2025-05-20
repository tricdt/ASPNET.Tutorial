using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
namespace ClientApp.Controllers;

[Route("[controller]")]
public class IdentityController : ControllerBase
{

     private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public IdentityController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    // [HttpGet]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
    
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();

        var oidcDiscoveryResult = await client.GetDiscoveryDocumentAsync("https://localhost:5000");

        if (oidcDiscoveryResult.IsError)
        {
            Console.WriteLine(oidcDiscoveryResult.Error);
            return Ok(oidcDiscoveryResult.Error);
        }

        // request token
        var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = "https://localhost:5000",

            ClientId = "clientApp",
            ClientSecret = "secret",
            Scope = "resourceApi"
        });

        // if (tokenResponse.IsError)
        // {
        //     Console.WriteLine(tokenResponse.Error);
        //     throw new HttpRequestException(tokenResponse.Error);
        // }

        // Console.WriteLine(tokenResponse.Json);
        // Console.WriteLine("\n\n");


        return Ok(tokenResponse);
    }
}
