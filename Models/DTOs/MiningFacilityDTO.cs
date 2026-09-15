using ExomineAPI.Models.DTO;

namespace ExomineAPI.Models.DTOs;

public class MiningFacilityDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }

    public List<FacilityInventoryDTO> Inventory { get; set; }
    public List<TransactionDTO> Transactions { get; set; }
}