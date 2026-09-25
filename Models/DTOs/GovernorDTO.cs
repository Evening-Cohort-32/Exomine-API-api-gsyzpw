namespace ExomineAPI.Models.DTOs;

public class GovernorDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ColonyId { get; set; }
    public bool Status { get; set; }

    public ColonyDTO Colony { get; set; }
    public List<GovernorHistoryDTO> GovernorHistories { get; set; }
    public List<TransactionDTO> Transactions { get; set; }
}