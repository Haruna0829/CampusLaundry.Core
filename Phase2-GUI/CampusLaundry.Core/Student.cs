using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusLaundry.Core;

public class Student
{
    public string StudID { get; }
    public string StudName { get; }
    public string PhoneNumber { get; }
    public Student(string id, string name, string phone)
    {
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Enter a student ID and name.");
        phone = phone.Trim();
        if (phone.Length < 8 || phone.Length > 15 || !phone.All(char.IsDigit))
            throw new ArgumentException("Phone number must contain 8 to 15 digits.");
        StudID = id.Trim().ToUpperInvariant(); StudName = name.Trim(); PhoneNumber = phone;
    }
    public override string ToString() => StudID + " - " + StudName;
}
