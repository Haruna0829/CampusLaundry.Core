using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusLaundry.Core;

public interface INotificationService
{
    void Notify(Student student, string message);
}
