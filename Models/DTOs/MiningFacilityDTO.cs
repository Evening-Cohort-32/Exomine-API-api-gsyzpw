using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Models.DTOs;

public class MiningFacilityDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }

    public List<FacilityInventoryDTO> Inventory { get; set; }
    public List<TransactionDTO> Transactions { get; set; }
}