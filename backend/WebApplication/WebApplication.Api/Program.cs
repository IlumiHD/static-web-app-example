using Azure.Identity;

using Microsoft.EntityFrameworkCore;

using MyWebApplication.Db;

using WebApplication.Api;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddAzureKeyVault(
  new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
  new DefaultAzureCredential());

builder.Services.AddDbContext<WeatherDatabaseContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:Database"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
