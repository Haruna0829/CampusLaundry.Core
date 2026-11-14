using CampusLaundry.Core;

namespace CampusLaundry.WinForms;

// Every open window uses this same session. No form creates its own laundry room.
public class AppSession
{
    public FormNotificationService Notifier { get; } = new();
    public LaundryRoom Room { get; }
    private TimeSpan offset;
    public DateTime Now => DateTime.Now.Add(offset);
    public event EventHandler? Changed;

    public AppSession()
    {
        Room = new LaundryRoom(Notifier);
        Room.AddStudent("S001", "Ali", "0123456789");
        Room.AddStudent("S002", "Mei", "0123456790");
        Room.AddStudent("S003", "Ravi", "0123456791");
    }

    public void Refresh()
    {
        Room.Ticker(Now);
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void AdvanceTime()
    {
        offset = offset.Add(TimeSpan.FromMinutes(5));
        Refresh();
    }

    public IEnumerable<Booking> BookingsFor(Student? student) =>
        Room.Bookings.Where(b => student == null || b.Student == student);

    public IEnumerable<Payment> PaymentsFor(Student? student) =>
        Room.Payments.Where(p => BookingsFor(student).Any(b => b.BookingID == p.BookingID));
}
