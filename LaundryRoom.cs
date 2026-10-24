using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class LaundryRoom
{
    public int RoomID { get; private set; }
    public int CycleMinutes { get; private set; }
    public LaundryQueue Queue { get; private set; }
    private readonly List<WashingMachine> machines = new List<WashingMachine>();
    public IList<WashingMachine> Machines { get { return machines.AsReadOnly(); } }
    private readonly List<Booking> Bookings = new List<Booking>();
    private readonly INotificationService notifier;
    public LaundryRoom(int id, int minutes, INotificationService service)
    {
        if (minutes <= 0 || service == null) throw new ArgumentException("Positive duration and notifier required.");
        RoomID = id; CycleMinutes = minutes; notifier = service; Queue = new LaundryQueue();
    }
    public void AddMachine(WashingMachine m)
    {
        if (m == null) throw new ArgumentNullException("m");
        foreach (WashingMachine existing in machines)
            if (existing.MachineID == m.MachineID) throw new InvalidOperationException("Duplicate machine ID.");
        machines.Add(m);
    }
    public Booking JoinQueue(Student s, DateTime now)
    {
        if (s == null) throw new ArgumentNullException("s");
        foreach (Booking b in Bookings)
            if (b.Student.StudID == s.StudID && b.IsActive) throw new InvalidOperationException("Student already has an active booking.");
        Booking booking = new Booking(Bookings.Count + 1, s, now);
        Bookings.Add(booking); Queue.EnQueue(booking);
        notifier.Notify(s, "Joined the queue."); AssignMachines(now); return booking;
    }
    public void Cancel(Booking b)
    {
        if (!Bookings.Contains(b)) throw new InvalidOperationException("Booking belongs to another room.");
        b.Cancel(); Queue.Remove(b); notifier.Notify(b.Student, "Booking cancelled.");
        // The application calls Ticker(now) to allocate any newly freed machine.
    }
    public void Ticker(DateTime now)
    {
        foreach (WashingMachine m in machines)
            if (m.WashingMachineStatus == MachineStatus.InUse && m.EndsAt.Value <= now)
            {
                Student s = m.CurrentBooking.Student; m.Finish(); notifier.Notify(s, "Your wash is completed.");
            }
        AssignMachines(now);
    }
    public int EstWaitTime(Booking b, DateTime now)
    {
        int position = Queue.PositionOf(b);
        if (position == 0) return 0;
        List<double> ready = new List<double>();
        foreach (WashingMachine m in machines)
        {
            // Payment time is unknown, so reserved machines are excluded.
            if (m.WashingMachineStatus == MachineStatus.Available) ready.Add(0);
            if (m.WashingMachineStatus == MachineStatus.InUse) ready.Add(Math.Max(0, (m.EndsAt.Value - now).TotalMinutes));
        }
        if (ready.Count == 0) return -1;
        double wait = 0;
        for (int i = 0; i < position; i++) { ready.Sort(); wait = ready[0]; ready[0] += CycleMinutes; }
        return (int)Math.Ceiling(wait);
    }
    public double AvgWaitTime()
    {
        double total = 0; int count = 0;
        foreach (Booking b in Bookings) if (b.StartedAt.HasValue) { total += b.WaitMinutes; count++; }
        return count == 0 ? 0 : total / count;
    }
    private void AssignMachines(DateTime now)
    {
        foreach (WashingMachine m in machines)
            while (m.WashingMachineStatus == MachineStatus.Available && Queue.Count > 0)
            {
                Booking b = Queue.DeQueue();
                if (b.BookingStatus != BookingStatus.Waiting) continue;
                m.Reserve(b); notifier.Notify(b.Student, "Machine " + m.MachineID + " reserved. Please pay before starting.");
            }
    }
}
}
