using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Models.DTOs;

public class MineralDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<ColonyInventoryDTO> ColonyDistro { get; set; }
    public List<FacilityInventoryDTO> FacilityDistro { get; set; }
}