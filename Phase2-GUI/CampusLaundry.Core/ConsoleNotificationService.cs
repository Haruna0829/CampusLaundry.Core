using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusLaundry.Core;

public class ConsoleNotificationService : INotificationService
{
    public void Notify(Student student, string message) => Console.WriteLine(student.StudName + ": " + message);
}
