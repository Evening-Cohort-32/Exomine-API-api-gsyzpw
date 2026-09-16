using System.ComponentModel.Design;
using ExomineAPI.Models;
using ExomineAPI.Models.DTO;
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
        MineralId = 1,
        Quantity = 5
    },
        new ColonyInventory
    {
        Id = 2,
        ColonyId = 2,
        MineralId = 1,
        Quantity = 3
    },
        new ColonyInventory
    {
        Id = 3,
        ColonyId = 3,
        MineralId = 1,
        Quantity = 4
    },
    new ColonyInventory
    {
        Id = 4,
        ColonyId = 1,
        MineralId = 2,
        Quantity = 6
    },
        new ColonyInventory
    {
        Id = 5,
        ColonyId = 2,
        MineralId = 2,
        Quantity = 3
    },
        new ColonyInventory
    {
        Id = 6,
        ColonyId = 3,
        MineralId = 3,
        Quantity = 8
    },
    new ColonyInventory
    {
        Id = 7,
        ColonyId = 1,
        MineralId = 4,
        Quantity = 5
    },
        new ColonyInventory
    {
        Id = 8,
        ColonyId = 2,
        MineralId = 5,
        Quantity = 6
    },
        new ColonyInventory
    {
        Id = 9,
        ColonyId = 3,
        MineralId = 4,
        Quantity = 9
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
        Id = 2,
        MiningFacilityId = 2,
        MineralId = 2,
        SaleQuantity = 0
    },
    new FacilityInventory
    {
        Id = 3,
        MiningFacilityId = 1,
        MineralId = 1,
        SaleQuantity = 10
    },
    new FacilityInventory
    {
        Id = 4,
        MiningFacilityId = 1,
        MineralId = 2,
        SaleQuantity = 5
    },
    new FacilityInventory
    {
        Id = 5,
        MiningFacilityId = 3,
        MineralId = 4,
        SaleQuantity = 7
    },
    new FacilityInventory
    {
        Id = 6,
        MiningFacilityId = 3,
        MineralId = 5,
        SaleQuantity = 3
    }
};
List<GovernorHistory> governorHistory = new List<GovernorHistory>
{
     new GovernorHistory
    {
        Id = 1,
        GovernorId = 4,
        ColonyId = 3,
        PreviousStatus = true,
        NewStatus = false,
        TimeStamp = new DateTime(2026, 4, 2, 8, 15, 0)
    },
     new GovernorHistory
    {
        Id = 2,
        GovernorId = 1,
        ColonyId = 1,
        PreviousStatus = false,
        NewStatus = true,
        TimeStamp = new DateTime(2026, 4, 2, 8, 15, 0)
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



//Get all active Governors
app.MapGet("/api/governors", (bool? status) =>
{
    List<Governor> governorsToReturn = governors;

    if (status != null)
    {
        governorsToReturn = governorsToReturn.Where(g => g.Status == status).ToList();
    }
    return governorsToReturn.Select(g => new GovernorDTO
    {
        Id = g.Id,
        Name = g.Name,
        ColonyId = g.ColonyId,
        Status = g.Status
    });
});

//Get Governor by Id
app.MapGet("/api/governors/{id}", (int id) =>
{
    Governor? governor =
        governors.FirstOrDefault(g => g.Id == id);

    if (governor == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(new GovernorDTO
    {
        Id = governor.Id,
        Name = governor.Name,
        ColonyId = governor.ColonyId,
        Status = governor.Status
    });
});

//Create Governor
app.MapPost("/governors", (GovernorDTO governorDTO) =>
{
    Colony? colony = colonies.FirstOrDefault(c => c.Id == governorDTO.ColonyId);

    if (colony == null)
    {
        return Results.BadRequest();
    }

    Governor newgGovernor = new Governor
    {
        Id = governors.Max(g => g.Id) + 1,
        Name = governorDTO.Name,
        ColonyId = governorDTO.ColonyId,
        Status = governorDTO.Status
    };

    governors.Add(newgGovernor);

    return Results.Created($"/governors/{newgGovernor.Id}", new GovernorDTO
    {
        Id = newgGovernor.Id,
        Name = newgGovernor.Name,
        ColonyId = newgGovernor.ColonyId,
        Status = newgGovernor.Status
    });

});

//Update Governor (also creates GovernorHistory)
//app.MapPut("/governors/{id}", )

//Delete Governor
app.MapDelete("/api/governors/{id}", (int id) =>
{
    Governor? governor = governors.FirstOrDefault(g => g.Id == id);

    if (governor == null)
    {
        return Results.NotFound();
    }
    governors.Remove(governor);
    return Results.NoContent();
});

//MiningFacility get all
app.MapGet("/api/miningfacilities", () =>
{
    return miningFacilities.Select(f => new MiningFacilityDTO
    {
        Id = f.Id,
        Name = f.Name,
        Active = f.Active
    });
});

//MiningFacility get Id
app.MapGet("/api/miningfacilities/{id}", (int id) =>
{
    MiningFacility facility = miningFacilities.FirstOrDefault(f => f.Id == id);

    if (facility == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new MiningFacilityDTO
    {
        Id = facility.Id,
        Name = facility.Name,
        Active = facility.Active
    });
});

//MiningFacility create
app.MapPost("/api/miningfacilities", (MiningFacilityDTO facilityDTO) =>
{
    MiningFacility newFacility = new MiningFacility
    {
        Id = miningFacilities.Max(f => f.Id) +1,
        Name = facilityDTO.Name,
        Active = facilityDTO.Active
    };

    miningFacilities.Add(newFacility);

    return Results.Created(
        $"/api/miningfacilities/{newFacility.Id}",
        new MiningFacilityDTO
        {
            Id = newFacility.Id,
            Name = newFacility.Name,
            Active = newFacility.Active
        }
    );
});

//MiningFacility update
app.MapPut("/api/miningfacilities/{id}", (int id, MiningFacilityDTO facilityDTO) =>
{
    MiningFacility facilityToUpdate = miningFacilities.FirstOrDefault(f => f.Id == id);

    if (facilityToUpdate == null)
    {
        return Results.NotFound();
    }

    facilityToUpdate.Name = facilityDTO.Name;
    facilityToUpdate.Active = facilityDTO.Active;

    return Results.Ok(new MiningFacilityDTO
    {
        Id = facilityToUpdate.Id,
        Name = facilityToUpdate.Name,
        Active = facilityToUpdate.Active
    });
});

//MiningFacility delete
app.MapDelete("/api/miningfacilities/{id}", (int id) =>
{
    MiningFacility facilityToDelete = miningFacilities.FirstOrDefault(f => f.Id == id);

    if (facilityToDelete == null)
    {
        return Results.NotFound();
    }

    miningFacilities.Remove(facilityToDelete);

    return Results.NoContent();
});

app.Run();

