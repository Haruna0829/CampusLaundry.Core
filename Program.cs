using System;
using CampusLaundry.Core;

namespace CampusLaundry.Core
{
    public class Program
    {
        public static void Main()
        {
            DateTime now = new DateTime(2026, 10, 24, 9, 0, 0);
            INotificationService notifier = new ConsoleNotificationService();
            LaundryRoom room = new LaundryRoom(1, 30, notifier);
            WashingMachine machine = new WashingMachine(1);
            room.AddMachine(machine);
            Student ali = new Student("S001", "Ali", "0123456789");
            Student mei = new Student("S002", "Mei", "0123456790");
            Student ravi = new Student("S003", "Ravi", "0123456791");

            Console.WriteLine("=== BOOKING, PAYMENT AND RECEIPT ===");
            Booking first = room.JoinQueue(ali, now);
            Payment payment = new Payment(1, first.BookingID, 5m, PaymentMethod.EWallet);
            if (payment.Process(now))
            {
                first.ConfirmPayment(payment);
                machine.Start(first, now, room.CycleMinutes);
                Receipt receipt = new Receipt(first);
                receipt.Generate(payment, now);
                Console.WriteLine(receipt.Print()); receipt.Send();
            }
            Booking second = room.JoinQueue(mei, now.AddMinutes(5));
            Booking third = room.JoinQueue(ravi, now.AddMinutes(6));
            Console.WriteLine("Mei queue position: " + room.Queue.PositionOf(second));
            Console.WriteLine("Mei estimated wait: " + room.EstWaitTime(second, now.AddMinutes(6)) + " minutes");
            room.Cancel(third);
            room.Ticker(now.AddMinutes(30));
            Console.WriteLine("Ali status: " + first.BookingStatus);
            Console.WriteLine("Mei status: " + second.BookingStatus);

            Console.WriteLine("=== FAILED PAYMENT AND RETRY ===");
            Payment failed = new Payment(2, second.BookingID, 0m, PaymentMethod.Coin);
            Console.WriteLine("Invalid payment success: " + failed.Process(now.AddMinutes(30)));
            Payment retry = new Payment(3, second.BookingID, 5m, PaymentMethod.Cashless);
            retry.Process(now.AddMinutes(30)); second.ConfirmPayment(retry);
            machine.Start(second, now.AddMinutes(30), room.CycleMinutes);
            room.Ticker(now.AddMinutes(60));
            Console.WriteLine("Mei actual wait: " + second.WaitMinutes + " minutes");
            Console.WriteLine("Average wait: " + room.AvgWaitTime() + " minutes");

            Console.WriteLine("=== MAINTENANCE ===");
            MaintenanceTicket ticket = new MaintenanceTicket(1, machine, "Drain needs cleaning", now.AddMinutes(61));
            Technician technician = new Technician("T001", "Ahmad", "0123456792");
            technician.AcceptTicket(ticket); technician.StartRepair(now.AddMinutes(62));
            technician.CompleteRepair(now.AddMinutes(70), "Drain cleaned and tested");
            Console.WriteLine("Ticket: " + ticket.Status + "; machine: " + machine.WashingMachineStatus);

            Console.WriteLine("=== RESERVATION CANCELLATION AND REFUND ===");
            Booking cancelled = room.JoinQueue(ravi, now.AddMinutes(71));
            Payment refund = new Payment(4, cancelled.BookingID, 5m, PaymentMethod.PrepaidCard);
            refund.Process(now.AddMinutes(71)); cancelled.ConfirmPayment(refund);
            room.Cancel(cancelled); room.Ticker(now.AddMinutes(71));
            Console.WriteLine("Payment: " + refund.Status + "; machine: " + machine.WashingMachineStatus);
        }
    }
}
