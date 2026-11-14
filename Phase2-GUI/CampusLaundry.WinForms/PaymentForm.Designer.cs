namespace CampusLaundry.WinForms
{
    partial class PaymentForm
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
            bookingLabel = new Label();
            amountLabel = new Label();
            simulationLabel = new Label();
            methodBox = new ComboBox();
            failureBox = new CheckBox();
            confirmButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // bookingLabel
            // 
            bookingLabel.BackColor = Color.FromArgb(242, 247, 252);
            bookingLabel.Location = new Point(20, 20);
            bookingLabel.Name = "bookingLabel";
            bookingLabel.Size = new Size(460, 26);
            bookingLabel.TabIndex = 0;
            bookingLabel.Text = "Booking details";
            // 
            // amountLabel
            // 
            amountLabel.Location = new Point(20, 58);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(460, 26);
            amountLabel.TabIndex = 1;
            amountLabel.Text = "Amount: RM 5.00 | 30-minute wash";
            // 
            // simulationLabel
            // 
            simulationLabel.Location = new Point(20, 96);
            simulationLabel.Name = "simulationLabel";
            simulationLabel.Size = new Size(460, 26);
            simulationLabel.TabIndex = 2;
            simulationLabel.Text = "Demo payment. No money will be charged.";
            // 
            // methodBox
            // 
            methodBox.DropDownStyle = ComboBoxStyle.DropDownList;
            methodBox.Location = new Point(20, 137);
            methodBox.Name = "methodBox";
            methodBox.Size = new Size(270, 31);
            methodBox.TabIndex = 3;
            // 
            // failureBox
            // 
            failureBox.Location = new Point(20, 180);
            failureBox.Name = "failureBox";
            failureBox.Size = new Size(350, 30);
            failureBox.TabIndex = 4;
            failureBox.Text = "Test a failed payment";
            // 
            // confirmButton
            // 
            confirmButton.BackColor = Color.FromArgb(40, 122, 208);
            confirmButton.DialogResult = DialogResult.OK;
            confirmButton.FlatStyle = FlatStyle.Flat;
            confirmButton.ForeColor = Color.White;
            confirmButton.Location = new Point(20, 235);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(120, 36);
            confirmButton.TabIndex = 5;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = false;
            // 
            // backButton
            // 
            backButton.BackColor = Color.FromArgb(40, 122, 208);
            backButton.DialogResult = DialogResult.Cancel;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.ForeColor = Color.White;
            backButton.Location = new Point(155, 235);
            backButton.Name = "backButton";
            backButton.Size = new Size(120, 36);
            backButton.TabIndex = 6;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = false;
            // 
            // PaymentForm
            // 
            AcceptButton = confirmButton;
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = backButton;
            ClientSize = new Size(500, 300);
            Controls.Add(bookingLabel);
            Controls.Add(amountLabel);
            Controls.Add(simulationLabel);
            Controls.Add(methodBox);
            Controls.Add(failureBox);
            Controls.Add(confirmButton);
            Controls.Add(backButton);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Demo payment";
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Label bookingLabel = null!;
        private System.Windows.Forms.Label amountLabel = null!;
        private System.Windows.Forms.Label simulationLabel = null!;
        private System.Windows.Forms.ComboBox methodBox = null!;
        private System.Windows.Forms.CheckBox failureBox = null!;
        private System.Windows.Forms.Button confirmButton = null!;
        private System.Windows.Forms.Button backButton = null!;
    }
}
