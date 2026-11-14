using CampusLaundry.Core;
using System.ComponentModel;

namespace CampusLaundry.WinForms;

public partial class StudentEntryForm : Form
{
    private AppSession session = null!;
    private Action<Student>? openStudent;
    public event EventHandler? HomeRequested;

    public StudentEntryForm() { InitializeComponent(); }
    public StudentEntryForm(AppSession sharedSession, Action<Student> open) : this()
    { session = sharedSession; openStudent = open; }

    private void EntryLoad(object? sender, EventArgs e)
    {
        if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime || session == null) return;
        session.Changed += SessionChanged;
        RefreshStudents();
    }
    private void SessionChanged(object? sender, EventArgs e) => RefreshStudents();
    private void RefreshStudents()
    {
        if (studentPicker.Items.Count == session.Room.Students.Count) return;
        Student? selected = studentPicker.SelectedItem as Student;
        studentPicker.DataSource = session.Room.Students.ToList();
        if (selected != null) studentPicker.SelectedItem = selected;
        continueButton.Enabled = studentPicker.Items.Count > 0;
    }
    private void RegisterClick(object? sender, EventArgs e)
    {
        try
        {
            Student student = session.Room.AddStudent(idBox.Text, nameBox.Text, phoneBox.Text);
            session.Refresh();
            openStudent?.Invoke(student);
            Close();
        }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        { MessageBox.Show(this, ex.Message, "Check your details", MessageBoxButtons.OK, MessageBoxIcon.Information); }
    }
    private void ContinueClick(object? sender, EventArgs e)
    {
        if (studentPicker.SelectedItem is not Student student) return;
        openStudent?.Invoke(student);
        Close();
    }
    private void BackClick(object? sender, EventArgs e)
    { HomeRequested?.Invoke(this, EventArgs.Empty); Close(); }
    private void EntryClosed(object? sender, FormClosedEventArgs e)
    { if (session != null) session.Changed -= SessionChanged; }
}
