namespace ExomineAPI.Models.DTOs;

public class FacilityInventoryDTO
{
    public int Id { get; set; }
    public int MiningFacilityId { get; set; }
    public int MineralId { get; set; }
    public int SaleQuantity { get; set; }

    public MiningFacilityDTO MiningFacility { get; set; }
    public MineralDTO Mineral { get; set; }

}