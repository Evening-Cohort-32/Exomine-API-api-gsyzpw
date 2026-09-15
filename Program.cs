using ExomineAPI.Models;
using ExomineAPI.Models.DTOs;

List<Colony> colonies = new List<Colony>
{
    new Colony
    {
        Id = 1,
        Name = "Earth"
    },
    new Colony
    {
        Id = 2,
        Name = "Mars"
    }
};
List<Governor> governors = new List<Governor>
{
    new Governor
    {
        Id = 1,
        Name = "",
        ColonyId = 1,
        Status = true
    },
    new Governor
    {
        Id = 2,
        Name = "",
        ColonyId = 2,
        Status = false
    }
};
List<MiningFacility> miningFacilities = new List<MiningFacility>
{
    new MiningFacility
    {
        Id = 1,
        Name = "",
        Status = true
    },
    new MiningFacility
    {
        Id = 2,
        Name = "",
        Status = false
    },
        new MiningFacility
    {
        Id = 3,
        Name = "",
        Status = true
    }
};
List<Mineral> minerals = new List<Mineral>
{
    new Mineral
    {
        Id = 1,
        Name = "Iron"
    },
    new Mineral
    {
        Id = 2,
        Name = "Magnesium",
    }
};





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
