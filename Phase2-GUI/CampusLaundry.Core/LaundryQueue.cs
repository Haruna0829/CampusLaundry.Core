namespace CampusLaundry.Core;

public class LaundryQueue
{
    private readonly List<Booking> waiting = new();
    public int Count => waiting.Count;

    internal void EnQueue(Booking b)
    {
        if (b.BookingStatus != BookingStatus.Waiting || waiting.Contains(b))
            throw new InvalidOperationException("Booking cannot enter this queue.");
        waiting.Add(b);
    }

    internal Booking DeQueue()
    {
        if (waiting.Count == 0) throw new InvalidOperationException("Queue is empty.");
        Booking b = waiting[0]; waiting.RemoveAt(0); return b;
    }

    internal bool Remove(Booking b) => waiting.Remove(b);

    public int PositionOf(Booking b) => waiting.IndexOf(b) + 1;
}