using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusLaundry.Core;

public class Booking
{
    public int BookingID { get; }
    public Student Student { get; }
    public BookingStatus BookingStatus { get; internal set; } = BookingStatus.Waiting;
    public DateTime JoinedAt { get; }
    public DateTime? StartedAt { get; internal set; }
    public DateTime? ReservationExpiresAt { get; internal set; }
    public WashingMachine? AssignedMachine { get; internal set; }
    public Payment? ConfirmedPayment { get; internal set; }
    public bool IsActive => BookingStatus == BookingStatus.Waiting || BookingStatus == BookingStatus.AwaitingPayment || BookingStatus == BookingStatus.InProgress;
    public double WaitMinutes => StartedAt.HasValue ? (StartedAt.Value - JoinedAt).TotalMinutes : 0;
    internal Booking(int id, Student student, DateTime now)
    { BookingID = id; Student = student; JoinedAt = now; }
}
