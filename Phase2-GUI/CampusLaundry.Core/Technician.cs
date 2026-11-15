namespace CampusLaundry.Core;

public class Technician
{
    public string TechID { get; }
    public string TechName { get; }
    public string PhoneNumber { get; }
    public bool IsAvailable { get; internal set; } = true;

    public Technician(string id, string name, string phone)
    { TechID = id; TechName = name; PhoneNumber = phone; }

    public override string ToString() => TechName + (IsAvailable ? " (available)" : " (busy)");
}