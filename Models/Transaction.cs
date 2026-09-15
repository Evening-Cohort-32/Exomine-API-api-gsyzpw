namespace ExomineAPI.Models;

public class Transaction
{
    public int Id { get; set; }
    public int MineralId { get; set; }
    public int Quanity { get; set; }
    public int GovernorId { get; set; }
    public int FacilityId { get; set; }
    public string TimeStamp { get; set; }

}