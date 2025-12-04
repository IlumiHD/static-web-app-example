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

    optionsBuilder.UseSqlServer("Server=tcp:sql-server-adlesgrubers22054.database.windows.net,1433;Initial Catalog=sql-database-adlesgrubers22054;Persist Security Info=False;User ID=adlesgrubers22054;Password=htlgkr1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
  }
}
