using System;
using System.Collections.Generic;

namespace CampusLaundry.Core
{
public class Student
{
    public string StudID { get; private set; }
    public string StudName { get; private set; }
    public string PhoneNumber { get; private set; }
    public Student(string id, string name, string phone)
    {
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Student ID and name are required.");
        StudID = id; StudName = name; PhoneNumber = phone;
    }
}
}
