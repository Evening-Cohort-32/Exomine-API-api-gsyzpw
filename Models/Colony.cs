using ExomineAPI.Models.DTOs;

namespace ExomineAPI.Models;

public class Colony
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<GovernorDTO> Governors { get; set; }
}