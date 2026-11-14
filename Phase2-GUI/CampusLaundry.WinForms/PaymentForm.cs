using CampusLaundry.Core;
using System.ComponentModel;

namespace CampusLaundry.WinForms;

public partial class PaymentForm : Form
{
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public PaymentMethod SelectedMethod => (PaymentMethod)methodBox.SelectedItem!;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool SimulateFailure => failureBox.Checked;

    public PaymentForm()
    {
        InitializeComponent();
    }

    public PaymentForm(Booking booking, decimal price) : this()
    {
        bookingLabel.Text = "Booking " + booking.BookingID + " - " + booking.Student.StudName;
        amountLabel.Text = "Amount: RM " + price.ToString("F2") + " | 30-minute wash";
        methodBox.DataSource = Enum.GetValues<PaymentMethod>();
    }
}
