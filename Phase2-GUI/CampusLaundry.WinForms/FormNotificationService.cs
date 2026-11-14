using CampusLaundry.Core;
namespace CampusLaundry.WinForms;
public class FormNotificationService : INotificationService
{
    private readonly List<(Student Student, string Message)> messages = new();
    public IEnumerable<string> MessagesFor(Student? student) => messages
        .Where(m => student == null || m.Student == student)
        .Select(m => m.Student.StudID + " / " + m.Student.StudName + ": " + m.Message);
    public void Notify(Student student, string message)
    { messages.Insert(0, (student, message)); }
}
