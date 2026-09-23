namespace ExomineAPI.Models;

public class Transaction
{
    public int Id { get; set; }
    public int GovernorId { get; set; }
    public int ColonyId { get; set; }
    public int MiningFacilityId { get; set; }
    public int MineralId { get; set; }
    public int Quantity { get; set; }
    public DateTime TimeStamp { get; set; }

    public Governor? Governor { get; set; }
    public Colony? Colony { get; set; }
    public MiningFacility? MiningFacility { get; set; }
    public Mineral? Mineral { get; set; }

}