using Microsoft.AspNetCore.Mvc;
using OurApi.Models;

namespace OurApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForeCastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForeCastController> _logger;
    private static List<WeatherForeCast> arr;
    public WeatherForeCastController(ILogger<WeatherForeCastController> logger)
    {
        _logger = logger;
    }
    static WeatherForeCastController()
    {
        arr = Enumerable.Range(1, 5).Select(index => new WeatherForeCast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
    }

    [HttpGet(Name = "GetWeatherForeCast")]
    public IEnumerable<WeatherForeCast> Get()
    {
        return arr;
    }
    
    [HttpGet("{id}")]
    public WeatherForeCast Get(int id)
    {
        return arr[id];
    }

    [HttpPost]
    public void Post(WeatherForeCast newItem)
    {
        arr.Add(newItem);
    }

    [HttpPut("{id}")]
    public void Put(int id, WeatherForeCast newItem)
    {
        arr[id]=newItem;
    }   

    [HttpDelete("{id}")]
    public void RuthDelete(int id)
    {
        arr.RemoveAt(id);
    } 
}
