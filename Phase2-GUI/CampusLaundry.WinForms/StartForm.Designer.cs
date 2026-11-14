namespace CampusLaundry.WinForms;

partial class StartForm
{
    private System.ComponentModel.IContainer components = null!;
    private Label brandLabel = null!;
    private Label titleLabel = null!;
    private Label subtitleLabel = null!;
    private Label choiceLabel = null!;
    private Panel studentCard = null!;
    private Label studentNumber = null!;
    private Label studentTitle = null!;
    private Label studentDescription = null!;
    private Button studentButton = null!;
    private Panel adminCard = null!;
    private Label adminNumber = null!;
    private Label adminTitle = null!;
    private Label adminDescription = null!;
    private Button adminButton = null!;
    private Label footerLabel = null!;
    private System.Windows.Forms.Timer sessionTimer = null!;
    protected override void Dispose(bool disposing)
    { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        brandLabel = new Label();
        titleLabel = new Label();
        subtitleLabel = new Label();
        choiceLabel = new Label();
        studentCard = new Panel();
        studentNumber = new Label();
        studentTitle = new Label();
        studentDescription = new Label();
        studentButton = new Button();
        adminCard = new Panel();
        adminNumber = new Label();
        adminTitle = new Label();
        adminDescription = new Label();
        adminButton = new Button();
        footerLabel = new Label();
        sessionTimer = new System.Windows.Forms.Timer(components);
        studentCard.SuspendLayout();
        adminCard.SuspendLayout();
        SuspendLayout();
        // 
        // brandLabel
        // 
        brandLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        brandLabel.ForeColor = Color.FromArgb(75, 94, 115);
        brandLabel.Location = new Point(58, 40);
        brandLabel.Name = "brandLabel";
        brandLabel.Size = new Size(750, 24);
        brandLabel.TabIndex = 0;
        brandLabel.Text = "VILLAGE 5  /  STUDENT SERVICES";
        // 
        // titleLabel
        // 
        titleLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
        titleLabel.ForeColor = Color.FromArgb(20, 49, 82);
        titleLabel.Location = new Point(54, 80);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(860, 65);
        titleLabel.TabIndex = 1;
        titleLabel.Text = "Village 5 Campus Laundry";
        // 
        // subtitleLabel
        // 
        subtitleLabel.Font = new Font("Segoe UI", 13F);
        subtitleLabel.ForeColor = Color.FromArgb(75, 94, 115);
        subtitleLabel.Location = new Point(58, 153);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(820, 34);
        subtitleLabel.TabIndex = 2;
        subtitleLabel.Text = "Book a machine. Check your queue. Get your laundry done.";
        // 
        // choiceLabel
        // 
        choiceLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        choiceLabel.ForeColor = Color.FromArgb(75, 94, 115);
        choiceLabel.Location = new Point(58, 218);
        choiceLabel.Name = "choiceLabel";
        choiceLabel.Size = new Size(800, 27);
        choiceLabel.TabIndex = 3;
        choiceLabel.Text = "Choose how you want to continue";
        // 
        // studentCard
        // 
        studentCard.BackColor = Color.White;
        studentCard.Controls.Add(studentNumber);
        studentCard.Controls.Add(studentTitle);
        studentCard.Controls.Add(studentDescription);
        studentCard.Controls.Add(studentButton);
        studentCard.Location = new Point(58, 265);
        studentCard.Name = "studentCard";
        studentCard.Size = new Size(404, 240);
        studentCard.TabIndex = 4;
        // 
        // studentNumber
        // 
        studentNumber.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        studentNumber.ForeColor = Color.FromArgb(34, 102, 174);
        studentNumber.Location = new Point(28, 22);
        studentNumber.Name = "studentNumber";
        studentNumber.Size = new Size(60, 25);
        studentNumber.TabIndex = 5;
        studentNumber.Text = "01";
        // 
        // studentTitle
        // 
        studentTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        studentTitle.ForeColor = Color.FromArgb(20, 49, 82);
        studentTitle.Location = new Point(28, 57);
        studentTitle.Name = "studentTitle";
        studentTitle.Size = new Size(340, 40);
        studentTitle.TabIndex = 6;
        studentTitle.Text = "Student";
        // 
        // studentDescription
        // 
        studentDescription.Font = new Font("Segoe UI", 11F);
        studentDescription.ForeColor = Color.FromArgb(75, 94, 115);
        studentDescription.Location = new Point(28, 104);
        studentDescription.Name = "studentDescription";
        studentDescription.Size = new Size(350, 55);
        studentDescription.TabIndex = 7;
        studentDescription.Text = "Register, book a machine and\r\nkeep track of your laundry.";
        // 
        // studentButton
        // 
        studentButton.BackColor = Color.FromArgb(34, 102, 174);
        studentButton.Cursor = Cursors.Hand;
        studentButton.FlatAppearance.BorderSize = 0;
        studentButton.FlatStyle = FlatStyle.Flat;
        studentButton.ForeColor = Color.White;
        studentButton.Location = new Point(28, 174);
        studentButton.Name = "studentButton";
        studentButton.Size = new Size(348, 44);
        studentButton.TabIndex = 8;
        studentButton.Text = "Open student view";
        studentButton.UseVisualStyleBackColor = false;
        studentButton.Click += StudentClick;
        // 
        // adminCard
        // 
        adminCard.BackColor = Color.White;
        adminCard.Controls.Add(adminNumber);
        adminCard.Controls.Add(adminTitle);
        adminCard.Controls.Add(adminDescription);
        adminCard.Controls.Add(adminButton);
        adminCard.Location = new Point(498, 265);
        adminCard.Name = "adminCard";
        adminCard.Size = new Size(404, 240);
        adminCard.TabIndex = 9;
        // 
        // adminNumber
        // 
        adminNumber.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        adminNumber.ForeColor = Color.FromArgb(34, 102, 174);
        adminNumber.Location = new Point(28, 22);
        adminNumber.Name = "adminNumber";
        adminNumber.Size = new Size(60, 25);
        adminNumber.TabIndex = 10;
        adminNumber.Text = "02";
        // 
        // adminTitle
        // 
        adminTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        adminTitle.ForeColor = Color.FromArgb(20, 49, 82);
        adminTitle.Location = new Point(28, 57);
        adminTitle.Name = "adminTitle";
        adminTitle.Size = new Size(340, 40);
        adminTitle.TabIndex = 11;
        adminTitle.Text = "Admin";
        // 
        // adminDescription
        // 
        adminDescription.Font = new Font("Segoe UI", 11F);
        adminDescription.ForeColor = Color.FromArgb(75, 94, 115);
        adminDescription.Location = new Point(28, 104);
        adminDescription.Name = "adminDescription";
        adminDescription.Size = new Size(350, 55);
        adminDescription.TabIndex = 12;
        adminDescription.Text = "View bookings, manage machines\r\nand handle maintenance.";
        // 
        // adminButton
        // 
        adminButton.BackColor = Color.FromArgb(34, 102, 174);
        adminButton.Cursor = Cursors.Hand;
        adminButton.FlatAppearance.BorderSize = 0;
        adminButton.FlatStyle = FlatStyle.Flat;
        adminButton.ForeColor = Color.White;
        adminButton.Location = new Point(28, 174);
        adminButton.Name = "adminButton";
        adminButton.Size = new Size(348, 44);
        adminButton.TabIndex = 13;
        adminButton.Text = "Open admin view";
        adminButton.UseVisualStyleBackColor = false;
        adminButton.Click += AdminClick;
        // 
        // footerLabel
        // 
        footerLabel.Font = new Font("Segoe UI", 10F);
        footerLabel.ForeColor = Color.FromArgb(75, 94, 115);
        footerLabel.Location = new Point(58, 539);
        footerLabel.Name = "footerLabel";
        footerLabel.Size = new Size(850, 28);
        footerLabel.TabIndex = 14;
        footerLabel.Text = "Class demo  •  No real payments  •  Records reset when you close the app";
        // 
        // sessionTimer
        // 
        sessionTimer.Interval = 1000;
        sessionTimer.Tick += SessionTimerTick;
        // 
        // StartForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(242, 247, 252);
        ClientSize = new Size(960, 590);
        Controls.Add(brandLabel);
        Controls.Add(titleLabel);
        Controls.Add(subtitleLabel);
        Controls.Add(choiceLabel);
        Controls.Add(studentCard);
        Controls.Add(adminCard);
        Controls.Add(footerLabel);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "StartForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Village 5 Campus Laundry";
        FormClosing += StartFormClosing;
        Load += StartFormLoad;
        studentCard.ResumeLayout(false);
        adminCard.ResumeLayout(false);
        ResumeLayout(false);
    }
}
