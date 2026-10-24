using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public interface INotificationService
{
    void Notify(Student s, string message);
}
}
