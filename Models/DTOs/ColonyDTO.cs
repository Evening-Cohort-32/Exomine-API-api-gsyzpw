namespace ExomineAPI.Models.DTOs;

public class ColonyDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<GovernorDTO> Governors { get; set; }
}