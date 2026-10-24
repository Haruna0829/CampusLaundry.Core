using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class Booking
{
    public int BookingID { get; private set; }
    public BookingStatus BookingStatus { get; private set; }
    public DateTime JoinedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public Student Student { get; private set; }
    public WashingMachine AssignedMachine { get; internal set; }
    private Payment confirmedPayment;
    public bool IsActive { get { return BookingStatus == BookingStatus.Waiting || BookingStatus == BookingStatus.AwaitingPayment || BookingStatus == BookingStatus.InProgress; } }
    public double WaitMinutes { get { return StartedAt.HasValue ? (StartedAt.Value - JoinedAt).TotalMinutes : 0; } }
    public Booking(int id, Student student, DateTime now)
    {
        if (student == null) throw new ArgumentNullException("student");
        BookingID = id; Student = student; JoinedAt = now;
        BookingStatus = BookingStatus.Waiting;
    }
    internal void AwaitPayment()
    {
        if (BookingStatus != BookingStatus.Waiting) throw new InvalidOperationException("Booking must be waiting.");
        BookingStatus = BookingStatus.AwaitingPayment;
    }
    public void ConfirmPayment(Payment p)
    {
        if (BookingStatus != BookingStatus.AwaitingPayment || p == null || p.BookingID != BookingID || p.Status != PaymentStatus.Paid || confirmedPayment != null)
            throw new InvalidOperationException("A matching paid payment is required, once only.");
        confirmedPayment = p;
    }
    public void Start(DateTime now)
    {
        if (BookingStatus != BookingStatus.AwaitingPayment || confirmedPayment == null || confirmedPayment.Status != PaymentStatus.Paid || now < JoinedAt || now < confirmedPayment.PaidAt.Value)
            throw new InvalidOperationException("Reserve and pay before starting.");
        StartedAt = now; BookingStatus = BookingStatus.InProgress;
    }
    public void Complete()
    {
        if (BookingStatus != BookingStatus.InProgress) throw new InvalidOperationException("Wash is not running.");
        BookingStatus = BookingStatus.Completed;
    }
    public void Cancel()
    {
        if (BookingStatus != BookingStatus.Waiting && BookingStatus != BookingStatus.AwaitingPayment)
            throw new InvalidOperationException("Only waiting or reserved bookings can be cancelled.");
        if (confirmedPayment != null && confirmedPayment.Status == PaymentStatus.Paid) confirmedPayment.Refund();
        BookingStatus = BookingStatus.Cancelled;
        if (AssignedMachine != null) AssignedMachine.ReleaseReservation(this);
        AssignedMachine = null;
    }
}
}
