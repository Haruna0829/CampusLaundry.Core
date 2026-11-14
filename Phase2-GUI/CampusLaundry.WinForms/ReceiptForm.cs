using CampusLaundry.Core;

namespace CampusLaundry.WinForms;

public partial class ReceiptForm : Form
{
    private string receiptNumber = "Receipt";
    public ReceiptForm()
    {
        InitializeComponent();
    }
    public ReceiptForm(Receipt receipt) : this()
    {
        receiptNumber = receipt.ReceiptNo;
        Text = "Receipt " + receiptNumber;
        receiptText.Text = receipt.Print();
    }
    private void SaveClick(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog { Filter = "Text files (*.txt)|*.txt", FileName = receiptNumber + ".txt" };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try { File.WriteAllText(dialog.FileName, receiptText.Text); }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        { MessageBox.Show(this, ex.Message, "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
}
