using CampusLaundry.Core;
using System.ComponentModel;

namespace CampusLaundry.WinForms;

public partial class StartForm : Form
{
    private AppSession session = null!;
    private MainForm? adminWindow;
    private StudentEntryForm? studentEntry;
    private readonly Dictionary<Student, MainForm> studentWindows = new();

    public StartForm()
    { InitializeComponent(); }

    private void StartFormLoad(object? sender, EventArgs e)
    {
        if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
        session = new AppSession();
        sessionTimer.Start();
    }

    private void ShowHome(object? sender, EventArgs e)
    { WindowState = FormWindowState.Normal; Show(); Activate(); }

    private void AdminClick(object? sender, EventArgs e)
    {
        if (adminWindow == null || adminWindow.IsDisposed)
        {
            adminWindow = new MainForm(session);
            adminWindow.HomeRequested += ShowHome;
            adminWindow.Show();
        }
        adminWindow.WindowState = FormWindowState.Normal;
        adminWindow.Activate();
    }

    private void StudentClick(object? sender, EventArgs e)
    {
        if (studentEntry == null || studentEntry.IsDisposed)
        {
            studentEntry = new StudentEntryForm(session, OpenStudent);
            studentEntry.HomeRequested += ShowHome;
            studentEntry.Show();
        }
        studentEntry.WindowState = FormWindowState.Normal;
        studentEntry.Activate();
    }

    private void OpenStudent(Student student)
    {
        if (!studentWindows.TryGetValue(student, out MainForm? window) || window.IsDisposed)
        {
            window = new MainForm(session, student);
            studentWindows[student] = window;
            window.HomeRequested += ShowHome;
            window.Show();
        }
        window.WindowState = FormWindowState.Normal;
        window.Activate();
    }

    private void SessionTimerTick(object? sender, EventArgs e) => session.Refresh();

    private void StartFormClosing(object? sender, FormClosingEventArgs e)
    {
        if (session == null) return;
        if (MessageBox.Show(this, "Close all windows? Student records and bookings will be cleared.",
            "Close Village 5 Campus Laundry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        { e.Cancel = true; return; }
        sessionTimer.Stop();
        if (adminWindow != null && !adminWindow.IsDisposed) adminWindow.Close();
        if (studentEntry != null && !studentEntry.IsDisposed) studentEntry.Close();
        foreach (MainForm window in studentWindows.Values)
            if (!window.IsDisposed) window.Close();
    }

    private void footerLabel_Click(object sender, EventArgs e)
    {
    }

    private void adminTitle_Click(object sender, EventArgs e)
    {
    }
}