using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class Payment
{
    public int PaymentID { get; private set; }
    public int BookingID { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentMethod Method { get; private set; }
    public PaymentStatus Status { get; private set; }
    public DateTime? PaidAt { get; private set; }
    public Payment(int paymentId, int bookingId, decimal amount, PaymentMethod method)
    {
        PaymentID = paymentId; BookingID = bookingId; Amount = amount;
        Method = method; Status = PaymentStatus.Pending;
    }
    // Dummy processing: a positive amount succeeds; no money is transferred.
    public bool Process(DateTime now)
    {
        if (Status != PaymentStatus.Pending) return false;
        if (Amount <= 0) { Status = PaymentStatus.Failed; return false; }
        Status = PaymentStatus.Paid; PaidAt = now; return true;
    }
    public void Refund()
    {
        if (Status != PaymentStatus.Paid) throw new InvalidOperationException("Only paid payments can be refunded.");
        Status = PaymentStatus.Refunded;
    }
}
}
