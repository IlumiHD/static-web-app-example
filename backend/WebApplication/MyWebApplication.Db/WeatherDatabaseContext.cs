using Microsoft.EntityFrameworkCore;

namespace MyWebApplication.Db;

public class WeatherDatabaseContext : DbContext
{
  public WeatherDatabaseContext(DbContextOptions options) : base(options) { }

  public WeatherDatabaseContext() { }

  public DbSet<WeatherForecast> WeatherForecasts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
  }
}
