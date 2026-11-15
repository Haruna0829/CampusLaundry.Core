namespace CampusLaundry.Core;

// This class coordinates changes so a form cannot accidentally double-book a machine.
public class LaundryRoom
{
    public int RoomID { get; } = 1;
    public int CycleMinutes { get; } = 30;
    public decimal Price { get; } = 5m;
    public LaundryQueue Queue { get; } = new();
    private readonly List<Student> students = new();
    private readonly List<WashingMachine> machines = new();
    private readonly List<Booking> bookings = new();
    private readonly List<Payment> payments = new();
    private readonly List<Receipt> receipts = new();
    private readonly List<MaintenanceTicket> tickets = new();
    private readonly List<Technician> technicians = new();
    private readonly INotificationService notifier;
    public IReadOnlyList<Student> Students => students.AsReadOnly();
    public IReadOnlyList<WashingMachine> Machines => machines.AsReadOnly();
    public IReadOnlyList<Booking> Bookings => bookings.AsReadOnly();
    public IReadOnlyList<Payment> Payments => payments.AsReadOnly();
    public IReadOnlyList<Receipt> Receipts => receipts.AsReadOnly();
    public IReadOnlyList<MaintenanceTicket> Tickets => tickets.AsReadOnly();
    public IReadOnlyList<Technician> Technicians => technicians.AsReadOnly();

    public LaundryRoom(INotificationService service)
    {
        notifier = service ?? throw new ArgumentNullException(nameof(service));
        for (int i = 1; i <= 3; i++) machines.Add(new WashingMachine(i));
        technicians.Add(new Technician("T001", "Ahmad", "0123456792"));
        technicians.Add(new Technician("T002", "Siti", "0123456793"));
    }

    public Student AddStudent(string id, string name, string phone)
    {
        Student student = new(id, name, phone);
        if (students.Any(s => s.StudID == student.StudID)) throw new InvalidOperationException("This student ID already exists.");
        students.Add(student); return student;
    }

    public Booking JoinQueue(Student student, DateTime now)
    {
        Ticker(now);
        if (!students.Contains(student)) throw new InvalidOperationException("Register the student first.");
        if (bookings.Any(b => b.Student == student && b.IsActive)) throw new InvalidOperationException("This student already has an active booking.");
        Booking b = new(bookings.Count + 1, student, now);
        bookings.Add(b); Queue.EnQueue(b);
        notifier.Notify(student, "Joined the laundry queue. Booking " + b.BookingID + ".");
        AssignMachines(now); return b;
    }

    public bool Pay(Booking b, PaymentMethod method, bool simulateFailure, DateTime now)
    {
        Ticker(now); CheckBooking(b);
        if (b.BookingStatus != BookingStatus.AwaitingPayment || b.ConfirmedPayment != null)
            throw new InvalidOperationException("Select an unpaid reserved booking.");
        if (!Enum.IsDefined(method)) throw new ArgumentException("Select a valid payment method.");
        Payment p = new(payments.Count + 1, b.BookingID, Price, method); payments.Add(p);
        if (!p.Process(now, simulateFailure))
        { notifier.Notify(b.Student, "Payment failed. Try again before your reservation expires."); return false; }
        b.ConfirmedPayment = p;
        receipts.Add(new Receipt(p, b, now));
        notifier.Notify(b.Student, "Payment successful. Start your wash before the reservation expires.");
        return true;
    }

    public void StartWash(Booking b, DateTime now)
    {
        Ticker(now); CheckBooking(b);
        if (b.BookingStatus != BookingStatus.AwaitingPayment || b.ConfirmedPayment?.Status != PaymentStatus.Paid)
            throw new InvalidOperationException("Reserve a machine and pay before starting.");
        WashingMachine m = b.AssignedMachine!;
        b.StartedAt = now; b.ReservationExpiresAt = null; b.BookingStatus = BookingStatus.InProgress;
        m.WashingMachineStatus = MachineStatus.InUse; m.EndsAt = now.AddMinutes(CycleMinutes);
        notifier.Notify(b.Student, "Wash started on machine " + m.MachineID + ".");
    }

    public void Cancel(Booking b, DateTime now)
    {
        Ticker(now); CheckBooking(b);
        if (b.BookingStatus != BookingStatus.Waiting && b.BookingStatus != BookingStatus.AwaitingPayment)
            throw new InvalidOperationException("Only waiting or reserved bookings can be cancelled.");
        CancelBooking(b, "Booking cancelled."); AssignMachines(now);
    }

    private void CancelBooking(Booking b, string reason)
    {
        Queue.Remove(b);
        if (b.ConfirmedPayment?.Status == PaymentStatus.Paid)
        { b.ConfirmedPayment.Refund(); reason += " Payment refunded (simulation)."; }
        if (b.AssignedMachine?.CurrentBooking == b) Release(b.AssignedMachine);
        b.ReservationExpiresAt = null; b.BookingStatus = BookingStatus.Cancelled;
        notifier.Notify(b.Student, reason);
    }

    public void Ticker(DateTime now)
    {
        foreach (Booking b in bookings.Where(b => b.BookingStatus == BookingStatus.AwaitingPayment && b.ReservationExpiresAt <= now).ToList())
            CancelBooking(b, "Reservation expired after five minutes.");
        foreach (WashingMachine m in machines.Where(m => m.WashingMachineStatus == MachineStatus.InUse && m.EndsAt <= now))
        {
            Booking b = m.CurrentBooking!; b.BookingStatus = BookingStatus.Completed;
            Release(m); notifier.Notify(b.Student, "Your wash is done. Please collect your laundry.");
        }
        AssignMachines(now);
    }

    private void AssignMachines(DateTime now)
    {
        foreach (WashingMachine m in machines.Where(m => m.WashingMachineStatus == MachineStatus.Available))
        {
            if (Queue.Count == 0) break;
            Booking b = Queue.DeQueue(); b.AssignedMachine = m;
            b.BookingStatus = BookingStatus.AwaitingPayment; b.ReservationExpiresAt = now.AddMinutes(5);
            m.CurrentBooking = b; m.WashingMachineStatus = MachineStatus.Reserved;
            notifier.Notify(b.Student, "Machine " + m.MachineID + " reserved. Pay and start within five minutes.");
        }
    }

    private void Release(WashingMachine m)
    { m.CurrentBooking = null; m.EndsAt = null; m.WashingMachineStatus = MachineStatus.Available; }

    private void CheckBooking(Booking b)
    { if (!bookings.Contains(b)) throw new InvalidOperationException("Booking does not belong to this room."); }

    public MaintenanceTicket ReportFault(WashingMachine m, string issue, DateTime now)
    {
        Ticker(now);
        if (!machines.Contains(m) || m.WashingMachineStatus != MachineStatus.Available)
            throw new InvalidOperationException("Only an available machine can be taken out of service. Finish or cancel its booking first.");
        if (string.IsNullOrWhiteSpace(issue)) throw new ArgumentException("Enter the fault description.");
        m.WashingMachineStatus = MachineStatus.OutOfOrder;
        MaintenanceTicket ticket = new(tickets.Count + 1, m, issue.Trim(), now); tickets.Add(ticket); return ticket;
    }

    public void AssignTicket(MaintenanceTicket ticket, Technician technician)
    {
        if (!tickets.Contains(ticket) || !technicians.Contains(technician) || ticket.Status != TicketStatus.Open || !technician.IsAvailable)
            throw new InvalidOperationException("Select an open ticket and an available technician.");
        ticket.AssignedTo = technician; technician.IsAvailable = false; ticket.Status = TicketStatus.Assigned;
    }

    public void StartRepair(MaintenanceTicket ticket)
    {
        if (!tickets.Contains(ticket) || ticket.Status != TicketStatus.Assigned)
            throw new InvalidOperationException("Assign a technician first.");
        ticket.Status = TicketStatus.InProgress;
    }

    public void ResolveTicket(MaintenanceTicket ticket, string notes, DateTime now)
    {
        if (!tickets.Contains(ticket) || ticket.Status != TicketStatus.InProgress)
            throw new InvalidOperationException("Start the repair first.");
        if (string.IsNullOrWhiteSpace(notes)) throw new ArgumentException("Enter the repair notes.");
        ticket.ResolutionNotes = notes.Trim(); ticket.ResolvedAt = now; ticket.Status = TicketStatus.Resolved;
        ticket.AssignedTo!.IsAvailable = true; ticket.Machine.WashingMachineStatus = MachineStatus.Available;
        AssignMachines(now);
    }
}