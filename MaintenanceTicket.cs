using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class MaintenanceTicket
{
    public int TicketID { get; private set; }
    public WashingMachine Machine { get; private set; }
    public Technician AssignedTo { get; private set; }
    public TicketStatus Status { get; private set; }
    public string IssueDescription { get; private set; }
    public DateTime ReportedAt { get; private set; }
    public DateTime? ResolvedAt { get; private set; }
    private DateTime? startedAt;
    public MaintenanceTicket(int id, WashingMachine machine, string issue, DateTime now)
    {
        if (machine == null || string.IsNullOrWhiteSpace(issue)) throw new ArgumentException("Machine and issue required.");
        machine.MarkOutOfOrder(); TicketID = id; Machine = machine;
        IssueDescription = issue; ReportedAt = now; Status = TicketStatus.Open;
    }
    public void Assign(Technician t)
    {
        if (Status != TicketStatus.Open || t == null || !t.IsAvailable) throw new InvalidOperationException("Ticket or technician unavailable.");
        t.Attach(this); AssignedTo = t; Status = TicketStatus.Assigned;
    }
    public void Start(DateTime now)
    {
        if (Status != TicketStatus.Assigned || now < ReportedAt) throw new InvalidOperationException("Assign technician before repair.");
        startedAt = now; Status = TicketStatus.InProgress;
    }
    public void Resolve(DateTime now, string notes)
    {
        if (Status != TicketStatus.InProgress || now < startedAt.Value || string.IsNullOrWhiteSpace(notes))
            throw new InvalidOperationException("Repair must be in progress and notes supplied.");
        Machine.Repair(); IssueDescription += " | Resolution: " + notes;
        ResolvedAt = now; Status = TicketStatus.Resolved; AssignedTo.Release(this);
    }
}
}
