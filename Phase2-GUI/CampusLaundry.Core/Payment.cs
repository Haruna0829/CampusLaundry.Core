using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusLaundry.Core;

public class Payment
{
    public int PaymentID { get; }
    public int BookingID { get; }
    public decimal Amount { get; }
    public PaymentMethod Method { get; }
    public PaymentStatus Status { get; private set; } = PaymentStatus.Pending;
    public DateTime? PaidAt { get; private set; }
    internal Payment(int id, int bookingId, decimal amount, PaymentMethod method)
    { PaymentID = id; BookingID = bookingId; Amount = amount; Method = method; }
    internal bool Process(DateTime now, bool simulateFailure)
    {
        if (Status != PaymentStatus.Pending) throw new InvalidOperationException("Payment was already processed.");
        Status = simulateFailure ? PaymentStatus.Failed : PaymentStatus.Paid;
        if (Status == PaymentStatus.Paid) PaidAt = now;
        return Status == PaymentStatus.Paid;
    }
    internal void Refund()
    {
        if (Status != PaymentStatus.Paid) throw new InvalidOperationException("Only a paid payment can be refunded.");
        Status = PaymentStatus.Refunded;
    }
}
