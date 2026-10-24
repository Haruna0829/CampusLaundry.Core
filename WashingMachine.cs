using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class WashingMachine
{
    public int MachineID { get; private set; }
    public MachineStatus WashingMachineStatus { get; private set; }
    public Booking CurrentBooking { get; private set; }
    public DateTime? EndsAt { get; private set; }
    public WashingMachine(int id) { MachineID = id; WashingMachineStatus = MachineStatus.Available; }
    public void Reserve(Booking b)
    {
        if (b == null || WashingMachineStatus != MachineStatus.Available || b.BookingStatus != BookingStatus.Waiting || b.AssignedMachine != null)
            throw new InvalidOperationException("Machine or booking is unavailable.");
        b.AwaitPayment(); b.AssignedMachine = this; CurrentBooking = b;
        WashingMachineStatus = MachineStatus.Reserved;
    }
    public void Start(Booking b, DateTime now, int minutes)
    {
        if (WashingMachineStatus != MachineStatus.Reserved || CurrentBooking != b || minutes <= 0)
            throw new InvalidOperationException("Reserve this machine first and use a positive duration.");
        DateTime end = now.AddMinutes(minutes);
        b.Start(now); EndsAt = end; WashingMachineStatus = MachineStatus.InUse;
    }
    public void Finish()
    {
        if (WashingMachineStatus != MachineStatus.InUse) throw new InvalidOperationException("Machine is not running.");
        CurrentBooking.Complete(); CurrentBooking = null; EndsAt = null;
        WashingMachineStatus = MachineStatus.Available;
    }
    internal void ReleaseReservation(Booking b)
    {
        if (WashingMachineStatus == MachineStatus.Reserved && CurrentBooking == b)
        { CurrentBooking = null; EndsAt = null; WashingMachineStatus = MachineStatus.Available; }
    }
    public void MarkOutOfOrder()
    {
        if (WashingMachineStatus != MachineStatus.Available) throw new InvalidOperationException("Machine must be available first.");
        WashingMachineStatus = MachineStatus.OutOfOrder;
    }
    public void Repair()
    {
        if (WashingMachineStatus != MachineStatus.OutOfOrder) throw new InvalidOperationException("Machine is not out of order.");
        WashingMachineStatus = MachineStatus.Available;
    }
}
}
