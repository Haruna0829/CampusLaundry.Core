using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusLaundry.Core;

public class Receipt
{
    public string ReceiptNo => "R" + Payment.PaymentID.ToString("D4");
    public Payment Payment { get; }
    public Student IssuedTo { get; }
    public int MachineID { get; }
    public DateTime IssuedAt { get; }
    internal Receipt(Payment payment, Booking booking, DateTime now)
    {
        Payment = payment; IssuedTo = booking.Student;
        MachineID = booking.AssignedMachine!.MachineID; IssuedAt = now;
    }
    public string Print() =>
        "CAMPUS LAUNDRY - DEMO RECEIPT" + Environment.NewLine +
        "Receipt: " + ReceiptNo + Environment.NewLine +
        "Issued: " + IssuedAt.ToString("dd MMM yyyy HH:mm") + Environment.NewLine +
        "Student: " + IssuedTo + Environment.NewLine +
        "Booking: " + Payment.BookingID + Environment.NewLine +
        "Machine: " + MachineID + Environment.NewLine +
        "Method: " + Payment.Method + Environment.NewLine +
        "Amount: RM " + Payment.Amount.ToString("F2") + Environment.NewLine +
        "Current payment status: " + Payment.Status + Environment.NewLine +
        "Demo payment. No money was charged.";
}
