namespace ExomineAPI.Models;

public class MiningFacility
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }

    public List<Mineral> SaleMinerals { get; set; }
}