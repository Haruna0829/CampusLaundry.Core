using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class LaundryQueue
{
    private readonly List<Booking> waiting = new List<Booking>();
    public int Count { get { return waiting.Count; } }
    public void EnQueue(Booking b)
    {
        if (b == null || b.BookingStatus != BookingStatus.Waiting || waiting.Contains(b))
            throw new InvalidOperationException("Only a new waiting booking can be queued.");
        waiting.Add(b);
    }
    public Booking DeQueue()
    {
        if (Count == 0) throw new InvalidOperationException("Queue is empty.");
        Booking b = waiting[0]; waiting.RemoveAt(0); return b;
    }
    public bool Remove(Booking b) { return waiting.Remove(b); }
    public int PositionOf(Booking b) { return waiting.IndexOf(b) + 1; }
}
}
