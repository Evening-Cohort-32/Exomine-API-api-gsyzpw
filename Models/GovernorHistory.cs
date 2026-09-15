namespace ExomineAPI.Models;

public class GovernorHistory
{
    public int Id { get; set; }

    public int GovernorId { get; set; }
    public int ColonyId { get; set; }

    public string PreviousStatus { get; set; }
    public string NewStatus { get; set; }
    public DateTime Timestamp { get; set; }

    public Governor Governor { get; set; }
    public Colony Colony { get; set; }
}