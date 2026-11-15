namespace CampusLaundry.Core;

public class MaintenanceTicket
{
    public int TicketID { get; }
    public WashingMachine Machine { get; }
    public Technician? AssignedTo { get; internal set; }
    public TicketStatus Status { get; internal set; } = TicketStatus.Open;
    public string IssueDescription { get; }
    public DateTime ReportedAt { get; }
    public DateTime? ResolvedAt { get; internal set; }
    public string ResolutionNotes { get; internal set; } = "";

    internal MaintenanceTicket(int id, WashingMachine machine, string issue, DateTime now)
    { TicketID = id; Machine = machine; IssueDescription = issue; ReportedAt = now; }
}