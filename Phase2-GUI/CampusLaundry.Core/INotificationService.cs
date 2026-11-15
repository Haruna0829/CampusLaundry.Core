namespace CampusLaundry.Core;

public interface INotificationService
{
    void Notify(Student student, string message);
}