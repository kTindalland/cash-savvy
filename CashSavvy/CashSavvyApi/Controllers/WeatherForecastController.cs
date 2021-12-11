using Microsoft.AspNetCore.Mvc;
using CashSavvyApi.Models;

namespace CashSavvyApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly test_dbContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, test_dbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet(Name = "GetUsers")]
    public IEnumerable<User> GetUsers(int id) {
        Console.WriteLine(id);
        var users = new List<User>();

        if (_context.Users.Any(u => u.Id == id)) {
            users.Add(_context.Users.First(u => u.Id == id));
        }

        users = _context.Users.ToList();

        return users;
    }

    [HttpPost]
    public void AddUser(string name, int age)
    {
        var newUser = new User() {
            Name = name,
            Age = age
        };

        _context.Users.Add(newUser);

        _context.SaveChanges();
    }
}
