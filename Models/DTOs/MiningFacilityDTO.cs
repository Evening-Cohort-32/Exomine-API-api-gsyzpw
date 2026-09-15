public class MiningFacilityDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }

    public List<MineralDTO> SaleMinerals { get; set; }
}