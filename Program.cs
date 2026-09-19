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
app.MapPost("/api/governors", (GovernorDTO governorDTO) =>
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
        Status = f.Status
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
        Status = facility.Status
    });
});

//MiningFacility create
app.MapPost("/api/miningfacilities", (MiningFacilityDTO facilityDTO) =>
{
    MiningFacility newFacility = new MiningFacility
    {
        Id = miningFacilities.Max(f => f.Id) + 1,
        Name = facilityDTO.Name,
        Status = facilityDTO.Status
    };

    miningFacilities.Add(newFacility);

    return Results.Created(
        $"/api/miningfacilities/{newFacility.Id}",
        new MiningFacilityDTO
        {
            Id = newFacility.Id,
            Name = newFacility.Name,
            Status = newFacility.Status
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
    facilityToUpdate.Status = facilityDTO.Status;

    return Results.Ok(new MiningFacilityDTO
    {
        Id = facilityToUpdate.Id,
        Name = facilityToUpdate.Name,
        Status = facilityToUpdate.Status
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

//Colony CRUD Below

//Get All Colonies
app.MapGet("/api/colony", () =>
{
    return colonies.Select(c => new ColonyDTO
    {
        Id = c.Id,
        Name = c.Name,
        Governors = governors
            .Where(g => g.ColonyId == c.Id)
            .Select(g => new GovernorDTO
            {
                Id = g.Id,
                Name = g.Name,
                ColonyId = g.ColonyId,
                Status = g.Status
            })
            .ToList()
    });
});

//Get One Colony by Id
app.MapGet("/api/colony/{id}", (int id) =>
{
    Colony colony = colonies.FirstOrDefault(c => c.Id == id);
    if (colony == null)
    {
        return Results.NotFound();
    }

    List<ColonyInventory> inventory = colonyInventory
        .Where(i => i.ColonyId == id)
        .ToList();

    List<Mineral> inventoryMinerals = colonyInventory
        .Where(i => i.ColonyId == id)
        .Select(i => minerals.First(m => m.Id == i.MineralId))
        .ToList();

    return Results.Ok(new ColonyDTO
    {
        Id = colony.Id,
        Name = colony.Name,
        Governors = governors
            .Where(g => g.ColonyId == colony.Id)
            .Select(g => new GovernorDTO
            {
                Id = g.Id,
                Name = g.Name,
                ColonyId = g.ColonyId,
                Status = g.Status
            })
            .ToList(),
        Inventory = inventory
            .Where(i => i.ColonyId == colony.Id)
            .Select(i => new ColonyInventoryDTO
            {
                Id = i.Id,
                Mineral = minerals
                    .Where(m => m.Id == i.MineralId)
                    .Select(m => new MineralDTO
                    {
                        Id = m.Id,
                        Name = m.Name
                    })
                    .FirstOrDefault(),
                Quantity = i.Quantity
            })
            .ToList()
    });
});

//Create Colony
app.MapPost("/api/colony", (Colony colony) =>
{
    colony.Id = colonies.Max(c => c.Id) + 1;
    colonies.Add(colony);

    return Results.Created($"/api/colony/{colony.Id}", new ColonyDTO
    {
        Id = colony.Id,
        Name = colony.Name
    });
});

//Delete Colony by Id
app.MapDelete("/api/colony/{id}", (int id) =>
{
    Colony colonyDelete = colonies.FirstOrDefault(c => c.Id == id);
    if (colonyDelete == null)
    {
        return Results.NoContent();
    }
    else
    {
        return Results.Ok(colonies.Remove(colonyDelete));
    }
});

//Edit Colony by Id
app.MapPut("/api/colony/{id}", (int id, Colony colony) =>
{
    Colony colonyToUpdate = colonies.FirstOrDefault(c => c.Id == id);
    if (colonyToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != colony.Id)
    {
        return Results.BadRequest();
    }

    colonyToUpdate.Id = colony.Id;
    colonyToUpdate.Name = colony.Name;
    colonyToUpdate.Governors = colony.Governors;
    colonyToUpdate.Inventory = colonyInventory;

    return Results.NoContent();
});

//Mineral CRUD below

//Get All Minerals
app.MapGet("/api/mineral", () =>
{
    return minerals.Select(m => new MineralDTO
    {
        Id = m.Id,
        Name = m.Name
    });
});

//Get one Mineral By Id
app.MapGet("/api/mineral/{id}", (int id) =>
{
    Mineral mineral = minerals.FirstOrDefault(m => m.Id == id);
    if (mineral == null)
    {
        return Results.NotFound();
    }

    List<ColonyInventory> colonyDistro = colonyInventory
        .Where(c => c.MineralId == id)
        .ToList();

    List<FacilityInventory> facilityDistro = facilityInventory
        .Where(f => f.MineralId == id)
        .ToList();

    return Results.Ok(new MineralDTO
    {
        Id = mineral.Id,
        Name = mineral.Name,
        ColonyDistro = colonyInventory
            .Where(cd => cd.MineralId == mineral.Id)
            .Select(cd => new ColonyInventoryDTO
            {
                Id = cd.Id,
                Colony = colonies
                    .Where(c => c.Id == cd.ColonyId)
                    .Select(c => new ColonyDTO
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .FirstOrDefault(),
                Quantity = cd.Quantity
            }).ToList(),
        FacilityDistro = facilityInventory
            .Where(fd => fd.MineralId == mineral.Id)
            .Select(fd => new FacilityInventoryDTO
            {
                Id = fd.Id,
                MiningFacility = miningFacilities
                    .Where(f => f.Id == fd.MiningFacilityId)
                    .Select(f => new MiningFacilityDTO
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Status = f.Status
                    })
                    .FirstOrDefault(),
                SaleQuantity = fd.SaleQuantity
            })
            .ToList()
    });
});

//Create Mineral
app.MapPost("/api/minerals", (Mineral mineral) =>
{
    mineral.Id = minerals.Max(m => m.Id) + 1;
    minerals.Add(mineral);

    return Results.Created($"/api/mineral/{mineral.Id}", new MineralDTO
    {
        Id = mineral.Id,
        Name = mineral.Name
    });
});

//Delete Mineral by Id
app.MapDelete("/api/mineral/{id}", (int id) =>
{
    Mineral mineralDelete = minerals.FirstOrDefault(m => m.Id == id);
    if (mineralDelete == null)
    {
        return Results.NoContent();
    }
    else
    {
        return Results.Ok(minerals.Remove(mineralDelete));
    }
});

//Edit Mineral by Id
app.MapPut("/api/mineral/{id}", (int id, Mineral mineral) =>
{
    Mineral mineralToUpdate = minerals.FirstOrDefault(m => m.Id == id);
    if (mineralToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != mineral.Id)
    {
        return Results.BadRequest();
    }

    mineralToUpdate.Id = mineral.Id;
    mineralToUpdate.Name = mineral.Name;
    mineralToUpdate.ColonyDistro = mineral.ColonyDistro;
    mineralToUpdate.FacilityDistro = mineral.FacilityDistro;

    return Results.NoContent();
});

//ColonyInventory (CI) CRUD

//Get All CI
app.MapGet("/api/colonyInventory", () =>
{
    return colonyInventory.Select(ci => new ColonyInventoryDTO
    {
        Id = ci.Id,
        MineralId = ci.MineralId,
        ColonyId = ci.ColonyId,
        Quantity = ci.Quantity,
        Colony = colonies
            .Where(c => c.Id == ci.ColonyId)
            .Select(c => new ColonyDTO
            {
                Id = c.Id,
                Name = c.Name
            })
            .FirstOrDefault(),
        Mineral = minerals
            .Where(m => m.Id == ci.MineralId)
            .Select(m => new MineralDTO
            {
                Id = m.Id,
                Name = m.Name
            })
            .FirstOrDefault()
    });
});

//Get one CI by Id
app.MapGet("/api/colonyInventory/{id}", (int id) =>
{
    ColonyInventory colonyInvt = colonyInventory.FirstOrDefault(ci => ci.Id == id);
    if (colonyInvt == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new ColonyInventoryDTO
    {
        Id = colonyInvt.Id,
        MineralId = colonyInvt.MineralId,
        ColonyId = colonyInvt.ColonyId,
        Quantity = colonyInvt.Quantity,
        Colony = colonies
            .Where(c => c.Id == colonyInvt.ColonyId)
            .Select(c => new ColonyDTO
            {
                Id = c.Id,
                Name = c.Name

            })
            .FirstOrDefault(),
        Mineral = minerals
            .Where(m => m.Id == colonyInvt.MineralId)
            .Select(m => new MineralDTO
            {
                Id = m.Id,
                Name = m.Name
            })
            .FirstOrDefault()
    });
});

//Create CI
app.MapPost("/api/colonyInventory", (ColonyInventory colonyInvt) =>
{
    colonyInvt.Id = colonyInventory.Max(ci => ci.Id) + 1;
    colonyInventory.Add(colonyInvt);

    return Results.Created($"/api/colonyInventory/{colonyInvt.Id}", new ColonyInventoryDTO
    {
        Id = colonyInvt.Id,
        MineralId = colonyInvt.MineralId,
        ColonyId = colonyInvt.ColonyId,
        Quantity = colonyInvt.Quantity,
        Colony = colonies
            .Where(c => c.Id == colonyInvt.ColonyId)
            .Select(c => new ColonyDTO
            {
                Id = c.Id,
                Name = c.Name

            })
            .FirstOrDefault(),
        Mineral = minerals
            .Where(m => m.Id == colonyInvt.MineralId)
            .Select(m => new MineralDTO
            {
                Id = m.Id,
                Name = m.Name
            })
            .FirstOrDefault()

    });
});

//Delete CI by Id
app.MapDelete("/api/colonyInventory/{id}", (int id) =>
{
    ColonyInventory CIToDelete = colonyInventory.FirstOrDefault(ci => ci.Id == id);
    if (CIToDelete == null)
    {
        return Results.NoContent();
    }
    else
    {
        return Results.Ok(colonyInventory.Remove(CIToDelete));
    }
});

//Edit CI by Id
app.MapPut("/api/colonyInventory/{id}", (int id, ColonyInventory colonyInvt) =>
{
    ColonyInventory CIToUpdate = colonyInventory.FirstOrDefault(ci => ci.Id == id);
    if (CIToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != colonyInvt.Id)
    {
        return Results.BadRequest();
    }

    CIToUpdate.Id = colonyInvt.Id;
    CIToUpdate.MineralId = colonyInvt.MineralId;
    CIToUpdate.ColonyId = colonyInvt.ColonyId;
    CIToUpdate.Quantity = colonyInvt.Quantity;
    CIToUpdate.Colony = colonyInvt.Colony;
    CIToUpdate.Mineral = colonyInvt.Mineral;

    return Results.NoContent();
});

//FacilityInventory (FI) CRUD

//Get all FI
app.MapGet("/api/facilityInventory", () =>
{
    return facilityInventory.Select(fi => new FacilityInventoryDTO
    {
        Id = fi.Id,
        MiningFacilityId = fi.MiningFacilityId,
        MineralId = fi.MineralId,
        SaleQuantity = fi.SaleQuantity,
        MiningFacility = miningFacilities
            .Where(mf => mf.Id == fi.MiningFacilityId)
            .Select(mf => new MiningFacilityDTO
            {
                Id = mf.Id,
                Name = mf.Name,
                Status = mf.Status
            })
            .FirstOrDefault(),
        Mineral = minerals
            .Where(m => m.Id == fi.MineralId)
            .Select(m => new MineralDTO
            {
                Id = m.Id,
                Name = m.Name
            })
            .FirstOrDefault()
    });
});

//Get one FI by Id
app.MapGet("/api/facilityInventory/{id}", (int id) =>
{
    FacilityInventory facilityInvt = facilityInventory.FirstOrDefault(fi => fi.Id == id);
    if (facilityInvt == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new FacilityInventoryDTO
    {
        Id = facilityInvt.Id,
        MiningFacilityId = facilityInvt.MiningFacilityId,
        MineralId = facilityInvt.MineralId,
        SaleQuantity = facilityInvt.SaleQuantity,
        MiningFacility = miningFacilities
            .Where(mf => mf.Id == facilityInvt.MiningFacilityId)
            .Select(mf => new MiningFacilityDTO
            {
                Id = mf.Id,
                Name = mf.Name,
                Status = mf.Status
            })
            .FirstOrDefault(),
        Mineral = minerals
            .Where(m => m.Id == facilityInvt.MineralId)
            .Select(m => new MineralDTO
            {
                Id = m.Id,
                Name = m.Name
            })
            .FirstOrDefault()
    });
});

//Create FI
app.MapPost("/api/facilityInventory", (FacilityInventory facilityInvt) =>
{
    facilityInvt.Id = facilityInventory.Max(fi => fi.Id) + 1;
    facilityInventory.Add(facilityInvt);

    return Results.Created($"/api/facilityInventory/{facilityInvt.Id}", new FacilityInventoryDTO
    {
        Id = facilityInvt.Id,
        MiningFacilityId = facilityInvt.MiningFacilityId,
        MineralId = facilityInvt.MineralId,
        SaleQuantity = facilityInvt.SaleQuantity,
        MiningFacility = miningFacilities
            .Where(mf => mf.Id == facilityInvt.MiningFacilityId)
            .Select(mf => new MiningFacilityDTO
            {
                Id = mf.Id,
                Name = mf.Name,
                Status = mf.Status
            })
            .FirstOrDefault(),
        Mineral = minerals
            .Where(m => m.Id == facilityInvt.MineralId)
            .Select(m => new MineralDTO
            {
                Id = m.Id,
                Name = m.Name
            })
            .FirstOrDefault()
    });
});

//Delete FI by Id
app.MapDelete("/api/facilityInventory/{id}", (int id) =>
{
    FacilityInventory FIToDelete = facilityInventory.FirstOrDefault(fi => fi.Id == id);
    if (FIToDelete == null)
    {
        return Results.NoContent();
    }
    else
    {
        return Results.Ok(facilityInventory.Remove(FIToDelete));
    }
});

//Edit FI by Id
app.MapPut("/api/facilityInventory/{id}", (int id, FacilityInventory facilityInvt) =>
{
    FacilityInventory FIToUpdate = facilityInventory.FirstOrDefault(fi => fi.Id == id);
    if (FIToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != facilityInvt.Id)
    {
        return Results.BadRequest();
    }

    FIToUpdate.Id = facilityInvt.Id;
    FIToUpdate.MiningFacilityId = facilityInvt.MiningFacilityId;
    FIToUpdate.MineralId = facilityInvt.MineralId;
    FIToUpdate.SaleQuantity = facilityInvt.SaleQuantity;
    FIToUpdate.MiningFacility = facilityInvt.MiningFacility;
    FIToUpdate.Mineral = facilityInvt.Mineral;

    return Results.NoContent();
});

app.Run();
