namespace CampusLaundry.WinForms
{
    partial class ReceiptForm
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            receiptText = new TextBox();
            saveButton = new Button();
            SuspendLayout();
            // 
            // receiptText
            // 
            receiptText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            receiptText.Font = new Font("Consolas", 11F);
            receiptText.Location = new Point(16, 16);
            receiptText.Multiline = true;
            receiptText.Name = "receiptText";
            receiptText.ReadOnly = true;
            receiptText.ScrollBars = ScrollBars.Both;
            receiptText.Size = new Size(568, 340);
            receiptText.TabIndex = 0;
            receiptText.Text = "Your receipt will appear here.";
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Location = new Point(16, 375);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(220, 36);
            saveButton.TabIndex = 1;
            saveButton.Text = "Save receipt as text";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveClick;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(242, 247, 252);
            ClientSize = new Size(600, 430);
            Controls.Add(receiptText);
            Controls.Add(saveButton);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(500, 400);
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Receipt";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.TextBox receiptText = null!;
        private System.Windows.Forms.Button saveButton = null!;
    }
}
