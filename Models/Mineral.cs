namespace ExomineAPI.Models;

public class Mineral
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<ColonyInventory> ColonyDistro { get; set; }
    public List<FacilityInventory> FacilityDistro { get; set; }
}