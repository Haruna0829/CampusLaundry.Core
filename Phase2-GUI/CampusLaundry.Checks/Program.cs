using CampusLaundry.Core;

int passed = 0;
void Check(bool result, string name)
{
    if (!result) throw new Exception("FAIL: " + name);
    Console.WriteLine("PASS: " + name); passed++;
}
void Reject(Action action, string name)
{
    bool rejected = false;
    try { action(); }
    catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException) { rejected = true; }
    Check(rejected, name);
}
DateTime now = new(2026, 11, 3, 9, 0, 0);
var room = new LaundryRoom(new ConsoleNotificationService());
var ali = room.AddStudent("s001", "Ali", "0123456789");
Reject(() => room.AddStudent(" S001 ", "Duplicate", "0123456789"), "Duplicate IDs rejected");
Reject(() => room.AddStudent("S009", "", "0123456789"), "Blank name rejected");
Reject(() => room.AddStudent("S009", "Name", "abc"), "Invalid phone rejected");
var mei = room.AddStudent("S002", "Mei", "0123456789");
var ravi = room.AddStudent("S003", "Ravi", "0123456789");
var sara = room.AddStudent("S004", "Sara", "0123456789");
var a = room.JoinQueue(ali, now);
Check(a.BookingStatus == BookingStatus.AwaitingPayment && a.AssignedMachine?.MachineID == 1, "First available machine reserved");
Reject(() => room.JoinQueue(ali, now), "Duplicate active booking rejected");
Reject(() => room.StartWash(a, now), "Unpaid wash rejected");
Check(!room.Pay(a, PaymentMethod.EWallet, true, now), "Failed payment stays retryable");
Check(room.Receipts.Count == 0, "Failed payment has no receipt");
Check(room.Pay(a, PaymentMethod.EWallet, false, now), "Successful retry");
Reject(() => room.Pay(a, PaymentMethod.Coin, false, now), "Duplicate charge rejected");
Check(room.Receipts.Count == 1 && room.Receipts[0].Print().Contains("RM 5.00"), "Receipt generated");
room.StartWash(a, now);
Reject(() => room.Cancel(a, now), "Running wash cancellation rejected");
Reject(() => room.ReportFault(a.AssignedMachine!, "Fault", now), "Busy machine fault blocked");
var b = room.JoinQueue(mei, now); room.Pay(b, PaymentMethod.Coin, false, now); room.StartWash(b, now);
var c = room.JoinQueue(ravi, now); room.Pay(c, PaymentMethod.Cashless, false, now); room.StartWash(c, now);
var d = room.JoinQueue(sara, now);
Check(d.BookingStatus == BookingStatus.Waiting && room.Queue.PositionOf(d) == 1, "Fourth student waits in FIFO queue");
room.Ticker(now.AddMinutes(30));
Check(a.BookingStatus == BookingStatus.Completed && b.BookingStatus == BookingStatus.Completed && c.BookingStatus == BookingStatus.Completed, "Timed washes complete");
Check(d.BookingStatus == BookingStatus.AwaitingPayment && room.Queue.Count == 0, "Queue advances after completion");
room.Pay(d, PaymentMethod.PrepaidCard, false, now.AddMinutes(30)); room.Cancel(d, now.AddMinutes(31));
Check(d.ConfirmedPayment!.Status == PaymentStatus.Refunded && d.AssignedMachine!.WashingMachineStatus == MachineStatus.Available, "Cancellation refunds and releases machine");
var expired = room.JoinQueue(sara, now.AddMinutes(32)); room.Pay(expired, PaymentMethod.Coin, false, now.AddMinutes(32));
room.Ticker(now.AddMinutes(37));
Check(expired.BookingStatus == BookingStatus.Cancelled && expired.ConfirmedPayment!.Status == PaymentStatus.Refunded, "Expired paid reservation refunded");
Reject(() => room.StartWash(expired, now.AddMinutes(37)), "Expired reservation cannot start");
var fault = room.ReportFault(room.Machines[0], "Drain blocked", now.AddMinutes(38));
Reject(() => room.ReportFault(room.Machines[0], "Second fault", now.AddMinutes(38)), "Duplicate fault rejected");
Reject(() => room.ResolveTicket(fault, "Fixed", now.AddMinutes(38)), "Unstarted repair cannot resolve");
room.AssignTicket(fault, room.Technicians[0]);
Check(!room.Technicians[0].IsAvailable && fault.Status == TicketStatus.Assigned, "Technician assigned");
room.StartRepair(fault);
Reject(() => room.ResolveTicket(fault, " ", now.AddMinutes(39)), "Repair notes required");
room.ResolveTicket(fault, "Drain cleaned", now.AddMinutes(40));
Check(fault.Status == TicketStatus.Resolved && room.Machines[0].WashingMachineStatus == MachineStatus.Available && room.Technicians[0].IsAvailable, "Repair restores machine and technician");
// All machines out of order: booking must wait until a repair finishes.
var faults = room.Machines.Select(m => room.ReportFault(m, "Inspection", now.AddMinutes(41))).ToList();
var waiting = room.JoinQueue(ali, now.AddMinutes(41));
Check(waiting.BookingStatus == BookingStatus.Waiting, "No working machines leaves booking queued");
room.AssignTicket(faults[0], room.Technicians[0]); room.StartRepair(faults[0]);
room.ResolveTicket(faults[0], "Inspection complete", now.AddMinutes(42));
Check(waiting.BookingStatus == BookingStatus.AwaitingPayment, "Repair immediately serves queued student");
// The same session backs the admin window and every student window.
var session = new CampusLaundry.WinForms.AppSession();
var studentAli = session.Room.Students[0];
var studentMei = session.Room.Students[1];
int adminUpdates = 0, studentUpdates = 0;
EventHandler adminListener = (_, _) => adminUpdates++;
EventHandler studentListener = (_, _) => studentUpdates++;
session.Changed += adminListener;
session.Changed += studentListener;
var aliBooking = session.Room.JoinQueue(studentAli, session.Now);
var meiBooking = session.Room.JoinQueue(studentMei, session.Now);
session.Refresh();
Check(adminUpdates == 1 && studentUpdates == 1, "Both views receive the same refresh");
Check(session.BookingsFor(null).Count() == 2, "Admin sees all bookings");
Check(session.BookingsFor(studentAli).Single() == aliBooking, "Student sees only their own booking");
session.Room.Pay(aliBooking, PaymentMethod.Coin, false, session.Now);
session.Room.Pay(meiBooking, PaymentMethod.EWallet, false, session.Now);
session.Refresh();
Check(session.PaymentsFor(studentAli).Single().BookingID == aliBooking.BookingID, "Student payments are filtered");
Check(session.PaymentsFor(null).Count() == 2, "Admin sees both payments");
Check(session.Notifier.MessagesFor(studentAli).All(m => m.StartsWith("S001 / ")), "Student notifications stay separate");
session.Room.StartWash(aliBooking, session.Now);
session.AdvanceTime();
Check(meiBooking.BookingStatus == BookingStatus.Cancelled && meiBooking.ConfirmedPayment!.Status == PaymentStatus.Refunded, "Shared clock expires and refunds another student's reservation");
for (int i = 0; i < 5; i++) session.AdvanceTime();
Check(aliBooking.BookingStatus == BookingStatus.Completed, "Shared clock completes a running wash");
session.Changed -= studentListener;
int previousStudentUpdates = studentUpdates;
session.Refresh();
Check(studentUpdates == previousStudentUpdates && adminUpdates > studentUpdates, "Closing one view leaves the other subscribed");
Check(session.BookingsFor(studentAli).Single() == aliBooking, "Reopened view can read existing session records");
var newStudent = session.Room.AddStudent("S004", "Sara", "0123456788");
session.Refresh();
Check(session.Room.Students.Contains(newStudent), "Student registration is available to the shared admin list");
Reject(() => session.Room.AddStudent("S004", "Sara", "0123456788"), "Self-registration rejects an existing ID");
Check(!session.BookingsFor(newStudent).Any(), "New student starts with an empty personal booking list");
var newBooking = session.Room.JoinQueue(newStudent, session.Now);
session.Refresh();
Check(session.BookingsFor(null).Contains(newBooking) && session.BookingsFor(newStudent).Single() == newBooking, "New student's booking appears in both views");
Console.WriteLine($"All {passed} checks passed.");