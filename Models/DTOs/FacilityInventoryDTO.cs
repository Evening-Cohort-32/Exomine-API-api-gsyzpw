namespace ExomineAPI.Models.DTO;

public class FacilityInventoryDTO
{
    public int Id { get; set; }
    public int MiningFacilityId { get; set; }
    public int MineralId { get; set; }
    public int SaleQuantity { get; set; }

    public MiningFacility MiningFacility { get; set; }
    public Mineral Mineral { get; set; }

}