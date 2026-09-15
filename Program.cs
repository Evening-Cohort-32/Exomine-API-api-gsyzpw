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
    },
        new Colony
    {
        Id = 3,
        Name = "Europa"
    },
};
List<Governor> governors = new List<Governor>
{
    new Governor
    {
        Id = 1,
        Name = "Patricia Purdy",
        ColonyId = 1,
        Status = true
    },
    new Governor
    {
        Id = 2,
        Name = "Katrina Bahringer",
        ColonyId = 2,
        Status = true
    },
        new Governor
    {
        Id = 3,
        Name = "Lola Wolf",
        ColonyId = 3,
        Status = true
    },
        new Governor
    {
        Id = 4,
        Name = "Damon Hartmann",
        ColonyId = 3,
        Status = true
    },
        new Governor
    {
        Id = 5,
        Name = "Eleanor Voss",
        ColonyId = 2,
        Status = true
    }
};
List<MiningFacility> miningFacilities = new List<MiningFacility>
{
    new MiningFacility
    {
        Id = 1,
        Name = "Ganymede",
        Status = true
    },
    new MiningFacility
    {
        Id = 2,
        Name = "Io",
        Status = false
    },
        new MiningFacility
    {
        Id = 3,
        Name = "Titan",
        Status = true
    },
        new MiningFacility
    {
        Id = 4,
        Name = "Luna",
        Status = false
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
    },
    new Mineral
    {
        Id = 3,
        Name = "Molybdenum",
    },
    new Mineral
    {
        Id = 4,
        Name = "Salt",
    },
    new Mineral
    {
        Id = 5,
        Name = "Nickel",
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
