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
            components = new System.ComponentModel.Container();
            bookingLabel = new System.Windows.Forms.Label();
            amountLabel = new System.Windows.Forms.Label();
            simulationLabel = new System.Windows.Forms.Label();
            methodBox = new System.Windows.Forms.ComboBox();
            failureBox = new System.Windows.Forms.CheckBox();
            confirmButton = new System.Windows.Forms.Button();
            backButton = new System.Windows.Forms.Button();
            SuspendLayout();
            bookingLabel.Name = "bookingLabel";
            bookingLabel.Location = new System.Drawing.Point(20, 20);
            bookingLabel.Size = new System.Drawing.Size(460, 26);
            bookingLabel.TabIndex = 0;
            bookingLabel.Text = "Booking details";
            amountLabel.Name = "amountLabel";
            amountLabel.Location = new System.Drawing.Point(20, 58);
            amountLabel.Size = new System.Drawing.Size(460, 26);
            amountLabel.TabIndex = 1;
            amountLabel.Text = "Amount: RM 5.00 | 30-minute wash";
            simulationLabel.Name = "simulationLabel";
            simulationLabel.Location = new System.Drawing.Point(20, 96);
            simulationLabel.Size = new System.Drawing.Size(460, 26);
            simulationLabel.TabIndex = 2;
            simulationLabel.Text = "Demo payment. No money will be charged.";
            methodBox.Name = "methodBox";
            methodBox.Location = new System.Drawing.Point(20, 137);
            methodBox.Size = new System.Drawing.Size(270, 30);
            methodBox.TabIndex = 3;
            methodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            failureBox.Name = "failureBox";
            failureBox.Location = new System.Drawing.Point(20, 180);
            failureBox.Size = new System.Drawing.Size(350, 30);
            failureBox.TabIndex = 4;
            failureBox.Text = "Test a failed payment";
            confirmButton.Name = "confirmButton";
            confirmButton.Location = new System.Drawing.Point(20, 235);
            confirmButton.Size = new System.Drawing.Size(120, 36);
            confirmButton.TabIndex = 5;
            confirmButton.Text = "Confirm";
            confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            backButton.Name = "backButton";
            backButton.Location = new System.Drawing.Point(155, 235);
            backButton.Size = new System.Drawing.Size(120, 36);
            backButton.TabIndex = 6;
            backButton.Text = "Back";
            backButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Controls.Add(bookingLabel);
            this.Controls.Add(amountLabel);
            this.Controls.Add(simulationLabel);
            this.Controls.Add(methodBox);
            this.Controls.Add(failureBox);
            this.Controls.Add(confirmButton);
            this.Controls.Add(backButton);
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(500, 300);
            Font = new System.Drawing.Font("Segoe UI", 10F);
            Name = "PaymentForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Demo payment";
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            AcceptButton = confirmButton;
            CancelButton = backButton;
            ResumeLayout(false);
            PerformLayout();
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
