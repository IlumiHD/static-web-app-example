using Microsoft.AspNetCore.Mvc;

using MyWebApplication.Db;

namespace WebApplication.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
  private static readonly string[] Summaries = new[]
  {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

  private readonly ILogger<WeatherForecastController> _logger;
  private readonly WeatherDatabaseContext _weatherDatabaseContext;

  public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherDatabaseContext weatherDatabaseContext)
  {
    _logger = logger;
    _weatherDatabaseContext = weatherDatabaseContext;
  }

  [HttpGet(Name = "GetWeatherForecast")]
  public IEnumerable<WeatherForecast> Get()
  {
    var query = _weatherDatabaseContext.WeatherForecasts
      .Select(x => new WeatherForecast()
      {
        Date = x.Date,
        TemperatureC = x.TemperatureC,
        Summary = x.Summary,
      });

    return query.ToList();
  }
}
