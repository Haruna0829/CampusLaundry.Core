namespace CampusLaundry.WinForms;

partial class StudentEntryForm
{
    private System.ComponentModel.IContainer components = null!;
    private Label titleLabel = null!;
    private Label subtitleLabel = null!;
    private Button backButton = null!;
    private TabControl entryTabs = null!;
    private TabPage registerPage = null!;
    private TabPage existingPage = null!;
    private Label registerHelp = null!;
    private Label idLabel = null!;
    private TextBox idBox = null!;
    private Label nameLabel = null!;
    private TextBox nameBox = null!;
    private Label phoneLabel = null!;
    private TextBox phoneBox = null!;
    private Button registerButton = null!;
    private Label existingHelp = null!;
    private ComboBox studentPicker = null!;
    private Button continueButton = null!;
    private Label demoNote = null!;
    private Label footerLabel = null!;
    protected override void Dispose(bool disposing)
    { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        titleLabel = new Label();
        subtitleLabel = new Label();
        backButton = new Button();
        entryTabs = new TabControl();
        registerPage = new TabPage();
        registerHelp = new Label();
        idLabel = new Label();
        idBox = new TextBox();
        nameLabel = new Label();
        nameBox = new TextBox();
        phoneLabel = new Label();
        phoneBox = new TextBox();
        registerButton = new Button();
        existingPage = new TabPage();
        existingHelp = new Label();
        studentPicker = new ComboBox();
        continueButton = new Button();
        demoNote = new Label();
        footerLabel = new Label();
        entryTabs.SuspendLayout();
        registerPage.SuspendLayout();
        existingPage.SuspendLayout();
        SuspendLayout();
        // 
        // titleLabel
        // 
        titleLabel.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
        titleLabel.ForeColor = Color.FromArgb(20, 49, 82);
        titleLabel.Location = new Point(32, 26);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(530, 48);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Student";
        // 
        // subtitleLabel
        // 
        subtitleLabel.Font = new Font("Segoe UI", 12F);
        subtitleLabel.ForeColor = Color.FromArgb(75, 94, 115);
        subtitleLabel.Location = new Point(34, 80);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(520, 30);
        subtitleLabel.TabIndex = 1;
        subtitleLabel.Text = "Village 5 Campus Laundry";
        // 
        // backButton
        // 
        backButton.BackColor = Color.FromArgb(34, 102, 174);
        backButton.Cursor = Cursors.Hand;
        backButton.FlatAppearance.BorderSize = 0;
        backButton.FlatStyle = FlatStyle.Flat;
        backButton.ForeColor = Color.White;
        backButton.Location = new Point(584, 35);
        backButton.Name = "backButton";
        backButton.Size = new Size(160, 38);
        backButton.TabIndex = 2;
        backButton.Text = "Back to home";
        backButton.UseVisualStyleBackColor = false;
        backButton.Click += BackClick;
        // 
        // entryTabs
        // 
        entryTabs.Controls.Add(registerPage);
        entryTabs.Controls.Add(existingPage);
        entryTabs.DrawMode = TabDrawMode.OwnerDrawFixed;
        entryTabs.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        entryTabs.ItemSize = new Size(80, 28);
        entryTabs.Location = new Point(34, 132);
        entryTabs.Name = "entryTabs";
        entryTabs.SelectedIndex = 0;
        entryTabs.Size = new Size(710, 388);
        entryTabs.TabIndex = 3;
        entryTabs.DrawItem += entryTabs_DrawItem;
        // 
        // registerPage
        // 
        registerPage.BackColor = Color.White;
        registerPage.Controls.Add(registerHelp);
        registerPage.Controls.Add(idLabel);
        registerPage.Controls.Add(idBox);
        registerPage.Controls.Add(nameLabel);
        registerPage.Controls.Add(nameBox);
        registerPage.Controls.Add(phoneLabel);
        registerPage.Controls.Add(phoneBox);
        registerPage.Controls.Add(registerButton);
        registerPage.Location = new Point(4, 32);
        registerPage.Name = "registerPage";
        registerPage.Size = new Size(702, 352);
        registerPage.TabIndex = 4;
        registerPage.Text = "Register";
        // 
        // registerHelp
        // 
        registerHelp.Font = new Font("Segoe UI", 11F);
        registerHelp.ForeColor = Color.FromArgb(75, 94, 115);
        registerHelp.Location = new Point(24, 22);
        registerHelp.Name = "registerHelp";
        registerHelp.Size = new Size(640, 28);
        registerHelp.TabIndex = 6;
        registerHelp.Text = "Enter your details to get started.";
        // 
        // idLabel
        // 
        idLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        idLabel.ForeColor = Color.FromArgb(75, 94, 115);
        idLabel.Location = new Point(24, 66);
        idLabel.Name = "idLabel";
        idLabel.Size = new Size(620, 25);
        idLabel.TabIndex = 7;
        idLabel.Text = "Student ID";
        // 
        // idBox
        // 
        idBox.Location = new Point(24, 94);
        idBox.MaxLength = 20;
        idBox.Name = "idBox";
        idBox.Size = new Size(636, 31);
        idBox.TabIndex = 8;
        // 
        // nameLabel
        // 
        nameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        nameLabel.ForeColor = Color.FromArgb(75, 94, 115);
        nameLabel.Location = new Point(24, 138);
        nameLabel.Name = "nameLabel";
        nameLabel.Size = new Size(620, 25);
        nameLabel.TabIndex = 9;
        nameLabel.Text = "Full name";
        // 
        // nameBox
        // 
        nameBox.Location = new Point(24, 166);
        nameBox.MaxLength = 80;
        nameBox.Name = "nameBox";
        nameBox.Size = new Size(636, 31);
        nameBox.TabIndex = 10;
        // 
        // phoneLabel
        // 
        phoneLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        phoneLabel.ForeColor = Color.FromArgb(75, 94, 115);
        phoneLabel.Location = new Point(24, 210);
        phoneLabel.Name = "phoneLabel";
        phoneLabel.Size = new Size(620, 25);
        phoneLabel.TabIndex = 11;
        phoneLabel.Text = "Phone number";
        // 
        // phoneBox
        // 
        phoneBox.Location = new Point(24, 238);
        phoneBox.MaxLength = 15;
        phoneBox.Name = "phoneBox";
        phoneBox.Size = new Size(636, 31);
        phoneBox.TabIndex = 12;
        // 
        // registerButton
        // 
        registerButton.BackColor = Color.FromArgb(34, 102, 174);
        registerButton.Cursor = Cursors.Hand;
        registerButton.FlatAppearance.BorderSize = 0;
        registerButton.FlatStyle = FlatStyle.Flat;
        registerButton.ForeColor = Color.White;
        registerButton.Location = new Point(24, 294);
        registerButton.Name = "registerButton";
        registerButton.Size = new Size(636, 40);
        registerButton.TabIndex = 13;
        registerButton.Text = "Register and continue";
        registerButton.UseVisualStyleBackColor = false;
        registerButton.Click += RegisterClick;
        // 
        // existingPage
        // 
        existingPage.BackColor = Color.White;
        existingPage.Controls.Add(existingHelp);
        existingPage.Controls.Add(studentPicker);
        existingPage.Controls.Add(continueButton);
        existingPage.Controls.Add(demoNote);
        existingPage.Location = new Point(4, 32);
        existingPage.Name = "existingPage";
        existingPage.Size = new Size(702, 352);
        existingPage.TabIndex = 5;
        existingPage.Text = "Existing student";
        // 
        // existingHelp
        // 
        existingHelp.Font = new Font("Segoe UI", 12F);
        existingHelp.ForeColor = Color.FromArgb(75, 94, 115);
        existingHelp.Location = new Point(24, 28);
        existingHelp.Name = "existingHelp";
        existingHelp.Size = new Size(630, 32);
        existingHelp.TabIndex = 14;
        existingHelp.Text = "Choose your registered profile.";
        // 
        // studentPicker
        // 
        studentPicker.DropDownStyle = ComboBoxStyle.DropDownList;
        studentPicker.Location = new Point(24, 85);
        studentPicker.Name = "studentPicker";
        studentPicker.Size = new Size(636, 33);
        studentPicker.TabIndex = 15;
        // 
        // continueButton
        // 
        continueButton.BackColor = Color.FromArgb(34, 102, 174);
        continueButton.Cursor = Cursors.Hand;
        continueButton.FlatAppearance.BorderSize = 0;
        continueButton.FlatStyle = FlatStyle.Flat;
        continueButton.ForeColor = Color.White;
        continueButton.Location = new Point(24, 145);
        continueButton.Name = "continueButton";
        continueButton.Size = new Size(636, 44);
        continueButton.TabIndex = 16;
        continueButton.Text = "Continue to my laundry";
        continueButton.UseVisualStyleBackColor = false;
        continueButton.Click += ContinueClick;
        // 
        // demoNote
        // 
        demoNote.Font = new Font("Segoe UI", 10F);
        demoNote.ForeColor = Color.FromArgb(75, 94, 115);
        demoNote.Location = new Point(24, 214);
        demoNote.Name = "demoNote";
        demoNote.Size = new Size(630, 62);
        demoNote.TabIndex = 17;
        demoNote.Text = "Profiles are for this class demo. No password is required.";
        // 
        // footerLabel
        // 
        footerLabel.Font = new Font("Segoe UI", 10F);
        footerLabel.ForeColor = Color.FromArgb(75, 94, 115);
        footerLabel.Location = new Point(34, 543);
        footerLabel.Name = "footerLabel";
        footerLabel.Size = new Size(700, 28);
        footerLabel.TabIndex = 18;
        footerLabel.Text = "One active booking per student. RM 5 per wash · 30 minutes.";
        // 
        // StudentEntryForm
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(242, 247, 252);
        ClientSize = new Size(780, 590);
        Controls.Add(titleLabel);
        Controls.Add(subtitleLabel);
        Controls.Add(backButton);
        Controls.Add(entryTabs);
        Controls.Add(footerLabel);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "StudentEntryForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Village 5 Campus Laundry";
        FormClosed += EntryClosed;
        Load += EntryLoad;
        entryTabs.ResumeLayout(false);
        registerPage.ResumeLayout(false);
        registerPage.PerformLayout();
        existingPage.ResumeLayout(false);
        ResumeLayout(false);
    }
}
