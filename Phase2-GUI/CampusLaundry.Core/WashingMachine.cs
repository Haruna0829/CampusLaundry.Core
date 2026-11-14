using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusLaundry.Core;

public class WashingMachine
{
    public int MachineID { get; }
    public MachineStatus WashingMachineStatus { get; internal set; } = MachineStatus.Available;
    public Booking? CurrentBooking { get; internal set; }
    public DateTime? EndsAt { get; internal set; }
    public WashingMachine(int id)
    {
        if (id <= 0) throw new ArgumentException("Machine ID must be positive.");
        MachineID = id;
    }
}
