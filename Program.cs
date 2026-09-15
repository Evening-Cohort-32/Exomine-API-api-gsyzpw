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
        Status = false
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
List<ColonyInventory> colonyInventory = new List<ColonyInventory>
{
    new ColonyInventory
    {
        Id = 1,
        ColonyId = 1,
        MineralId = 3,
        Quantity = 5
    }
};
List<FacilityInventory> facilityInventory = new List<FacilityInventory>
{
    new FacilityInventory
    {
        Id = 1,
        MiningFacilityId = 2,
        MineralId = 3,
        SaleQuantity = 8
    },
    new FacilityInventory
    {
        Id = 1,
        MiningFacilityId = 2,
        MineralId = 2,
        SaleQuantity = 0
    }
};
List<GovernorHistory> governorHistory = new List<GovernorHistory>
{
     new GovernorHistory
    {
        Id = 1,
        GovernorId = 2,
        ColonyId = 2,
        PreviousStatus = true,
        NewStatus = true,
        Timestamp = new DateTime(2026, 4, 2, 8, 15, 0)
    },
     new GovernorHistory
    {
        Id = 2,
        GovernorId = 1,
        ColonyId = 1,
        PreviousStatus = false,
        NewStatus = true,
        Timestamp = new DateTime(2026, 4, 2, 8, 15, 0)
    }
};
List<Transaction> transactions = new List<Transaction>
{
    new Transaction
    {
        Id = 1,
        GovernorId = 1,
        ColonyId = 1,
        MiningFacilityId = 1,
        MineralId = 2,
        Quantity = 1,
        TimeStamp = new DateTime(2026, 8, 10, 14, 20, 0)
    },
        new Transaction
    {
        Id = 2,
        GovernorId = 2,
        ColonyId = 2,
        MiningFacilityId = 1,
        MineralId = 1,
        Quantity = 2,
        TimeStamp = new DateTime(2026, 8, 12, 9, 45, 0)
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
