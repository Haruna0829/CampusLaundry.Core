using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class Receipt
{
    public string ReceiptNo { get; private set; }
    public Payment Payment { get; private set; }
    public Student IssuedTo { get; private set; }
    public WashingMachine Machine { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime IssuedAt { get; private set; }
    private readonly Booking booking;
    public Receipt(Booking b)
    {
        if (b == null) throw new ArgumentNullException("b");
        booking = b; IssuedTo = b.Student;
    }
    public void Generate(Payment p, DateTime now)
    {
        if (Payment != null || p == null || p.Status != PaymentStatus.Paid || p.BookingID != booking.BookingID || booking.AssignedMachine == null || now < p.PaidAt.Value)
            throw new InvalidOperationException("A matching paid payment and assigned machine are required.");
        Payment = p; Machine = booking.AssignedMachine; Amount = p.Amount; IssuedAt = now;
        ReceiptNo = "RCP-" + p.PaymentID.ToString("D4");
    }
    public void Send()
    {
        if (Payment == null) throw new InvalidOperationException("Generate receipt first.");
        Console.WriteLine("Receipt " + ReceiptNo + " sent to " + IssuedTo.StudName + " (simulation).");
    }
    public string Print()
    {
        if (Payment == null) throw new InvalidOperationException("Generate receipt first.");
        return "Receipt: " + ReceiptNo + " | Student: " + IssuedTo.StudName + " | Machine: " + Machine.MachineID +
            " | RM" + Amount.ToString("F2") + " | " + Payment.Method + " | " + IssuedAt.ToString("yyyy-MM-dd HH:mm");
    }
}
}
