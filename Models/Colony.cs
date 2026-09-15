namespace ExomineAPI.Models;

public class Colony
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Governor> Governors { get; set; }
}