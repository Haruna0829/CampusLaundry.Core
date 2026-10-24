using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class ConsoleNotificationService : INotificationService
{
    public void Notify(Student s, string message)
    {
        Console.WriteLine("[Notification] " + s.StudName + ": " + message);
    }
}
}
