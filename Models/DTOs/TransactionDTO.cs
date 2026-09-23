namespace ExomineAPI.Models.DTOs;

public class TransactionDTO
{
    public int Id { get; set; }
    public int GovernorId { get; set; }
    public int ColonyId { get; set; }
    public int MiningFacilityId { get; set; }
    public int MineralId { get; set; }
    public int Quantity { get; set; }
    public DateTime TimeStamp { get; set; }

    public GovernorDTO? Governor { get; set; }
    public ColonyDTO? Colony { get; set; }
    public MiningFacilityDTO? MiningFacility { get; set; }
    public MineralDTO? Mineral { get; set; }

}