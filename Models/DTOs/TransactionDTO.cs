namespace ExomineAPI.Models.DTOs;

public class TransactionDTO
{
    public int Id { get; set; }
    public int MineralId { get; set; }
    public int Quanity { get; set; }
    public int GovernorId { get; set; }
    public int FacilityId { get; set; }
    public string TimeStamp { get; set; }

}