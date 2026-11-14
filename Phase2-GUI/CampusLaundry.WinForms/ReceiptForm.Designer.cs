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
            components = new System.ComponentModel.Container();
            receiptText = new System.Windows.Forms.TextBox();
            saveButton = new System.Windows.Forms.Button();
            SuspendLayout();
            receiptText.Name = "receiptText";
            receiptText.Location = new System.Drawing.Point(16, 16);
            receiptText.Size = new System.Drawing.Size(568, 340);
            receiptText.TabIndex = 0;
            receiptText.Text = "Your receipt will appear here.";
            receiptText.Multiline = true;
            receiptText.ReadOnly = true;
            receiptText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            receiptText.Font = new System.Drawing.Font("Consolas", 11F);
            receiptText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            saveButton.Name = "saveButton";
            saveButton.Location = new System.Drawing.Point(16, 375);
            saveButton.Size = new System.Drawing.Size(220, 36);
            saveButton.TabIndex = 1;
            saveButton.Text = "Save receipt as text";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.Controls.Add(receiptText);
            this.Controls.Add(saveButton);
            saveButton.Click += SaveClick;
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(600, 430);
            Font = new System.Drawing.Font("Segoe UI", 10F);
            Name = "ReceiptForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Receipt";
            MinimumSize = new System.Drawing.Size(500, 400);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.TextBox receiptText = null!;
        private System.Windows.Forms.Button saveButton = null!;
    }
}
