using CampusLaundry.Core;
using System.ComponentModel;

namespace CampusLaundry.WinForms;

public partial class MainForm : Form
{
    private AppSession session = null!;
    private Student? activeStudent;
    private bool IsAdmin => activeStudent == null;
    private LaundryRoom room = null!;
    private DateTime Now => session.Now;
    private bool refreshing;
    private bool started;

    public event EventHandler? HomeRequested;

    private void BackHomeClick(object? sender, EventArgs e)
    { HomeRequested?.Invoke(this, EventArgs.Empty); Close(); }

    public MainForm()
    {
        InitializeComponent();
    }

    public MainForm(AppSession sharedSession, Student? student = null) : this()
    {
        session = sharedSession;
        activeStudent = student;
    }

    private void MainFormLoad(object? sender, EventArgs e)
    {
        if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime || started) return;
        if (session == null) return;
        room = session.Room;
        refreshing = true;
        technicianBox.DataSource = room.Technicians.ToList();
        ReloadStudents();
        Text = IsAdmin ? "Village 5 Laundry - Admin" : "Village 5 Laundry - " + activeStudent!.StudName;
        headingLabel.Text = IsAdmin ? "Laundry Admin" : "My Laundry - " + activeStudent!.StudName;
        studentsPage.Text = "Students";
        foreach (Control control in studentsPage.Controls)
            control.Visible = control == studentsGrid || control == studentsHelp;
        studentsHelp.Text = "Registered students. New students register through the student view.";
        bookingsPage.Text = IsAdmin ? "All bookings" : "My bookings";
        paymentsPage.Text = IsAdmin ? "All payments" : "My payments";
        maintenancePage.Text = IsAdmin ? "Machine Status" : "Machine status";
        notificationsPage.Text = "Updates";
        joinButton.Visible = !IsAdmin;
        payButton.Visible = !IsAdmin;
        startButton.Visible = !IsAdmin;
        studentBox.Visible = !IsAdmin;
        studentBox.Enabled = false;
        advanceButton.Visible = IsAdmin;
        sessionLabel.Text = "Shared session. Close this window to return to the start screen.";
        if (!IsAdmin)
        {
            mainTabs.TabPages.Remove(studentsPage);
            mainTabs.TabPages.Remove(maintenancePage);
            mainTabs.TabPages.Insert(0, maintenancePage);
            mainTabs.SelectedTab = maintenancePage;
            foreach (Control control in maintenancePage.Controls)
                control.Visible = control == machinesGrid || control == machineHelp;
            machineHelp.Text = "Check which machines are available.";
            machinesGrid.Columns[2].Visible = false;
            machinesGrid.Location = new Point(16, 60);
            machinesGrid.Size = new Size(1090, 450);
            machinesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        started = true;
        session.Changed += SessionChanged;
        RefreshScreen();
    }

    private void SessionChanged(object? sender, EventArgs e)
    {
        if (started && !IsDisposed) RefreshScreen();
    }

    private void SelectionChanged(object? sender, EventArgs e)
    {
        if (started && !refreshing) UpdateButtons();
    }

    private void MainFormClosed(object? sender, FormClosedEventArgs e)
    {
        if (!started) return;
        session.Changed -= SessionChanged;
        started = false;
    }

    private void RequireAdmin()
    {
        if (!IsAdmin) throw new InvalidOperationException("Open the admin view for this action.");
    }

    private Booking SelectedBooking()
    {
        Booking booking = Selected<Booking>(bookingsGrid);
        if (!IsAdmin && booking.Student != activeStudent)
            throw new InvalidOperationException("Choose one of your own bookings.");
        return booking;
    }

    private void JoinClick(object? sender, EventArgs e) => RunAction(() =>
    {
        if (activeStudent is not Student s) throw new InvalidOperationException("Select a student first.");
        Booking b = room.JoinQueue(s, Now);
        RefreshScreen(); SelectRow(bookingsGrid, b);
    });

    private void PayClick(object? sender, EventArgs e) => RunAction(() =>
    {
        Booking b = SelectedBooking();
        using var form = new PaymentForm(b, room.Price);
        if (form.ShowDialog(this) != DialogResult.OK) return;
        bool paid = room.Pay(b, form.SelectedMethod, form.SimulateFailure, Now);
        session.Refresh();
        MessageBox.Show(this, paid ? "Payment successful. Click Start wash when ready." : "Payment failed. Try again before your reservation expires.", "Payment result");
    });

    private void StartClick(object? sender, EventArgs e) => RunAction(() => room.StartWash(SelectedBooking(), Now));

    private void CancelClick(object? sender, EventArgs e) => RunAction(() =>
    {
        Booking b = SelectedBooking();
        if (MessageBox.Show(this, "Cancel booking " + b.BookingID + "? Any paid reservation will be refunded.", "Confirm cancellation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            room.Cancel(b, Now);
    });

    private void ReceiptClick(object? sender, EventArgs e) => RunAction(() =>
    {
        Payment p = Selected<Payment>(paymentsGrid);
        if (!session.PaymentsFor(activeStudent).Contains(p)) throw new InvalidOperationException("Choose one of your own payments.");
        Receipt? receipt = room.Receipts.FirstOrDefault(r => r.Payment == p);
        if (receipt == null) throw new InvalidOperationException("This payment has no receipt.");
        using var form = new ReceiptForm(receipt); form.ShowDialog(this);
    });

    private void ReportClick(object? sender, EventArgs e) => RunAction(() =>
    { RequireAdmin(); room.ReportFault(Selected<WashingMachine>(machinesGrid), issueBox.Text, Now); issueBox.Clear(); });

    private void AssignClick(object? sender, EventArgs e) => RunAction(() =>
    {
        RequireAdmin();
        if (technicianBox.SelectedItem is not Technician t) throw new InvalidOperationException("Select a technician.");
        room.AssignTicket(Selected<MaintenanceTicket>(ticketsGrid), t);
    });

    private void RepairClick(object? sender, EventArgs e) => RunAction(() => { RequireAdmin(); room.StartRepair(Selected<MaintenanceTicket>(ticketsGrid)); });

    private void ResolveClick(object? sender, EventArgs e) => RunAction(() =>
    { RequireAdmin(); room.ResolveTicket(Selected<MaintenanceTicket>(ticketsGrid), notesBox.Text, Now); notesBox.Clear(); });

    private void AdvanceClick(object? sender, EventArgs e) => RunAction(() =>
    { RequireAdmin(); session.AdvanceTime(); });

    private void RunAction(Action action)
    {
        try { action(); }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        { MessageBox.Show(this, ex.Message, "Please check", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        finally { session.Refresh(); }
    }

    private void ReloadStudents()
    { studentBox.DataSource = IsAdmin ? room.Students.ToList() : new List<Student> { activeStudent! }; }

    private void RefreshScreen()
    {
        refreshing = true;
        RefreshGrid(studentsGrid, room.Students, s => new object?[] { s.StudID, s.StudName, s.PhoneNumber });
        RefreshGrid(bookingsGrid, session.BookingsFor(activeStudent), b => new object?[] {
            b.BookingID, b.Student.StudName, StatusText(b.BookingStatus),
            room.Queue.PositionOf(b) == 0 ? "—" : room.Queue.PositionOf(b).ToString(),
            b.AssignedMachine?.MachineID, b.ConfirmedPayment?.Status.ToString() ?? "Unpaid",
            FormatTime(b.ReservationExpiresAt), b.BookingStatus == BookingStatus.InProgress ? FormatTime(b.AssignedMachine?.EndsAt) : "—" });
        RefreshGrid(paymentsGrid, session.PaymentsFor(activeStudent), p => new object?[] { p.PaymentID, p.BookingID, p.Amount.ToString("F2"), p.Method, p.Status, FormatTime(p.PaidAt) });
        RefreshGrid(machinesGrid, room.Machines, m => new object?[] { m.MachineID, m.WashingMachineStatus, m.CurrentBooking?.BookingID, FormatTime(m.EndsAt) });
        RefreshGrid(ticketsGrid, room.Tickets, t => new object?[] { t.TicketID, t.Machine.MachineID, t.IssueDescription, t.AssignedTo?.TechName ?? "Unassigned", t.Status, t.ResolutionNotes });
        string[] updates = session.Notifier.MessagesFor(activeStudent).ToArray();
        if (!messages.Items.Cast<string>().SequenceEqual(updates))
        { messages.BeginUpdate(); messages.Items.Clear(); messages.Items.AddRange(updates); messages.EndUpdate(); }
        summary.Text = "Room 1   |   Available: " + room.Machines.Count(m => m.WashingMachineStatus == MachineStatus.Available)
            + "   Reserved: " + room.Machines.Count(m => m.WashingMachineStatus == MachineStatus.Reserved)
            + "   Washing: " + room.Machines.Count(m => m.WashingMachineStatus == MachineStatus.InUse)
            + "   Out of order: " + room.Machines.Count(m => m.WashingMachineStatus == MachineStatus.OutOfOrder)
            + "   |   Waiting: " + room.Queue.Count;
        clock.Text = "Demo time: " + Now.ToString("dd MMM yyyy HH:mm:ss");
        // Refresh the technician availability text without replacing the selected technician.
        if (!technicianBox.DroppedDown)
        {
            int techIndex = technicianBox.SelectedIndex;
            technicianBox.DataSource = room.Technicians.ToList(); technicianBox.SelectedIndex = techIndex;
        }
        foreach (DataGridViewRow row in machinesGrid.Rows)
        {
            if (row.Tag is not WashingMachine machine) continue;
            row.Cells[1].Value = machine.WashingMachineStatus switch
            {
                MachineStatus.InUse => "Washing",
                MachineStatus.OutOfOrder => "Out of order",
                _ => machine.WashingMachineStatus.ToString()
            };
            row.Cells[1].Style.BackColor = machine.WashingMachineStatus switch
            {
                MachineStatus.Available => Color.FromArgb(220, 242, 228),
                MachineStatus.Reserved => Color.FromArgb(255, 240, 204),
                MachineStatus.InUse => Color.FromArgb(219, 235, 253),
                _ => Color.FromArgb(249, 221, 221)
            };
            row.Cells[1].Style.ForeColor = Color.FromArgb(20, 49, 82);
        }
        refreshing = false; UpdateButtons();
    }

    private void UpdateButtons()
    {
        joinButton.Enabled = activeStudent != null && !room.Bookings.Any(b => b.Student == activeStudent && b.IsActive);
        Booking? b = Current<Booking>(bookingsGrid);
        bool reserved = b?.BookingStatus == BookingStatus.AwaitingPayment;
        payButton.Enabled = reserved && b!.ConfirmedPayment == null;
        startButton.Enabled = reserved && b!.ConfirmedPayment?.Status == PaymentStatus.Paid;
        cancelButton.Enabled = reserved || b?.BookingStatus == BookingStatus.Waiting;
        Payment? p = Current<Payment>(paymentsGrid);
        receiptButton.Enabled = p != null && room.Receipts.Any(r => r.Payment == p);
        reportButton.Enabled = Current<WashingMachine>(machinesGrid)?.WashingMachineStatus == MachineStatus.Available;
        MaintenanceTicket? ticket = Current<MaintenanceTicket>(ticketsGrid);
        assignButton.Enabled = ticket?.Status == TicketStatus.Open && technicianBox.SelectedItem is Technician t && t.IsAvailable;
        repairButton.Enabled = ticket?.Status == TicketStatus.Assigned;
        resolveButton.Enabled = ticket?.Status == TicketStatus.InProgress;
    }

    private static string StatusText(BookingStatus status) => status switch
    {
        BookingStatus.AwaitingPayment => "Reserved",
        BookingStatus.InProgress => "Washing",
        _ => status.ToString()
    };

    private static string FormatTime(DateTime? time) => time?.ToString("HH:mm:ss") ?? "—";

    private static T? Current<T>(DataGridView grid) where T : class => grid.CurrentRow?.Tag as T;

    private static T Selected<T>(DataGridView grid) where T : class => Current<T>(grid) ?? throw new InvalidOperationException("Select a row first.");

    private static void SelectRow(DataGridView grid, object item)
    {
        foreach (DataGridViewRow row in grid.Rows)
            if (ReferenceEquals(row.Tag, item)) { grid.CurrentCell = row.Cells[0]; return; }
    }

    private void studentsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void mainTabs_DrawItem(object sender, DrawItemEventArgs e)
    {
        var tabs = (TabControl)sender!;
        var page = tabs.TabPages[e.Index];
        bool selected = e.Index == tabs.SelectedIndex;

        Color back = selected ? ColorTranslator.FromHtml("#0200A8") : ColorTranslator.FromHtml("#287AD0");
        Color fore = selected ? Color.White : ColorTranslator.FromHtml("#FFFFFF");

        using (var brush = new SolidBrush(back))
            e.Graphics.FillRectangle(brush, e.Bounds);

        TextRenderer.DrawText(e.Graphics, page.Text, tabs.Font, e.Bounds, fore,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private static void RefreshGrid<T>(DataGridView grid, IEnumerable<T> items, Func<T, object?[]> cells) where T : class
    {
        object? selected = grid.CurrentRow?.Tag;
        int scroll = grid.FirstDisplayedScrollingRowIndex;
        grid.Rows.Clear();
        foreach (T item in items) { int index = grid.Rows.Add(cells(item)); grid.Rows[index].Tag = item; }
        if (selected != null) SelectRow(grid, selected);
        if (scroll >= 0 && scroll < grid.RowCount) grid.FirstDisplayedScrollingRowIndex = scroll;
    }
}