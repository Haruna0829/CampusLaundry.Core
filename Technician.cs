using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class Technician
{
    public string TechID { get; private set; }
    public string TechName { get; private set; }
    public string PhoneNumber { get; private set; }
    public bool IsAvailable { get { return currentTicket == null; } }
    private MaintenanceTicket currentTicket;
    public Technician(string id, string name, string phone)
    { TechID = id; TechName = name; PhoneNumber = phone; }
    internal void Attach(MaintenanceTicket ticket)
    {
        if (!IsAvailable) throw new InvalidOperationException("Technician is busy.");
        currentTicket = ticket;
    }
    internal void Release(MaintenanceTicket ticket) { if (currentTicket == ticket) currentTicket = null; }
    public void AcceptTicket(MaintenanceTicket t) { t.Assign(this); }
    public void StartRepair(DateTime now)
    {
        if (currentTicket == null) throw new InvalidOperationException("No assigned ticket.");
        currentTicket.Start(now);
    }
    public void CompleteRepair(DateTime now, string notes)
    {
        if (currentTicket == null) throw new InvalidOperationException("No assigned ticket.");
        currentTicket.Resolve(now, notes);
    }
}
}
