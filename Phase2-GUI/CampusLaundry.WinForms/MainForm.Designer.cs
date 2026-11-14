namespace CampusLaundry.WinForms
{
    partial class MainForm
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
            headingLabel = new Label();
            summary = new Label();
            mainTabs = new TabControl();
            bookingsPage = new TabPage();
            bookingsHelp = new Label();
            studentBox = new ComboBox();
            joinButton = new Button();
            payButton = new Button();
            startButton = new Button();
            cancelButton = new Button();
            bookingsGrid = new DataGridView();
            bookingsGridColumn0 = new DataGridViewTextBoxColumn();
            bookingsGridColumn1 = new DataGridViewTextBoxColumn();
            bookingsGridColumn2 = new DataGridViewTextBoxColumn();
            bookingsGridColumn3 = new DataGridViewTextBoxColumn();
            bookingsGridColumn4 = new DataGridViewTextBoxColumn();
            bookingsGridColumn5 = new DataGridViewTextBoxColumn();
            bookingsGridColumn6 = new DataGridViewTextBoxColumn();
            bookingsGridColumn7 = new DataGridViewTextBoxColumn();
            maintenancePage = new TabPage();
            faultLabel = new Label();
            issueBox = new TextBox();
            reportButton = new Button();
            machineHelp = new Label();
            machinesGrid = new DataGridView();
            machinesGridColumn0 = new DataGridViewTextBoxColumn();
            machinesGridColumn1 = new DataGridViewTextBoxColumn();
            machinesGridColumn2 = new DataGridViewTextBoxColumn();
            machinesGridColumn3 = new DataGridViewTextBoxColumn();
            technicianBox = new ComboBox();
            assignButton = new Button();
            repairButton = new Button();
            notesLabel = new Label();
            notesBox = new TextBox();
            resolveButton = new Button();
            ticketsGrid = new DataGridView();
            ticketsGridColumn0 = new DataGridViewTextBoxColumn();
            ticketsGridColumn1 = new DataGridViewTextBoxColumn();
            ticketsGridColumn2 = new DataGridViewTextBoxColumn();
            ticketsGridColumn3 = new DataGridViewTextBoxColumn();
            ticketsGridColumn4 = new DataGridViewTextBoxColumn();
            ticketsGridColumn5 = new DataGridViewTextBoxColumn();
            studentsPage = new TabPage();
            studentsHelp = new Label();
            studentsGrid = new DataGridView();
            studentsGridColumn0 = new DataGridViewTextBoxColumn();
            studentsGridColumn1 = new DataGridViewTextBoxColumn();
            studentsGridColumn2 = new DataGridViewTextBoxColumn();
            paymentsPage = new TabPage();
            paymentsHelp = new Label();
            receiptButton = new Button();
            paymentsGrid = new DataGridView();
            paymentsGridColumn0 = new DataGridViewTextBoxColumn();
            paymentsGridColumn1 = new DataGridViewTextBoxColumn();
            paymentsGridColumn2 = new DataGridViewTextBoxColumn();
            paymentsGridColumn3 = new DataGridViewTextBoxColumn();
            paymentsGridColumn4 = new DataGridViewTextBoxColumn();
            paymentsGridColumn5 = new DataGridViewTextBoxColumn();
            notificationsPage = new TabPage();
            notificationsHelp = new Label();
            messages = new ListBox();
            clock = new Label();
            advanceButton = new Button();
            sessionLabel = new Label();
            backHomeButton = new Button();
            mainTabs.SuspendLayout();
            bookingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bookingsGrid).BeginInit();
            maintenancePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)machinesGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ticketsGrid).BeginInit();
            studentsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)studentsGrid).BeginInit();
            paymentsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)paymentsGrid).BeginInit();
            notificationsPage.SuspendLayout();
            SuspendLayout();
            // 
            // headingLabel
            // 
            headingLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            headingLabel.ForeColor = Color.Black;
            headingLabel.Location = new Point(20, 15);
            headingLabel.Name = "headingLabel";
            headingLabel.Size = new Size(600, 44);
            headingLabel.TabIndex = 0;
            headingLabel.Text = "Campus Laundry";
            // 
            // summary
            // 
            summary.BackColor = Color.Transparent;
            summary.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            summary.ForeColor = SystemColors.ActiveCaptionText;
            summary.Location = new Point(20, 65);
            summary.Name = "summary";
            summary.Size = new Size(1088, 30);
            summary.TabIndex = 1;
            summary.Text = "Room 1 | Available: 3 | Reserved: 0 | Washing: 0 | Waiting: 0";
            // 
            // mainTabs
            // 
            mainTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainTabs.Controls.Add(bookingsPage);
            mainTabs.Controls.Add(maintenancePage);
            mainTabs.Controls.Add(studentsPage);
            mainTabs.Controls.Add(paymentsPage);
            mainTabs.Controls.Add(notificationsPage);
            mainTabs.DrawMode = TabDrawMode.OwnerDrawFixed;
            mainTabs.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainTabs.ItemSize = new Size(150, 34);
            mainTabs.Location = new Point(20, 98);
            mainTabs.Name = "mainTabs";
            mainTabs.SelectedIndex = 0;
            mainTabs.Size = new Size(1140, 565);
            mainTabs.TabIndex = 2;
            mainTabs.DrawItem += mainTabs_DrawItem;
            // 
            // bookingsPage
            // 
            bookingsPage.Controls.Add(bookingsHelp);
            bookingsPage.Controls.Add(studentBox);
            bookingsPage.Controls.Add(joinButton);
            bookingsPage.Controls.Add(payButton);
            bookingsPage.Controls.Add(startButton);
            bookingsPage.Controls.Add(cancelButton);
            bookingsPage.Controls.Add(bookingsGrid);
            bookingsPage.Location = new Point(4, 38);
            bookingsPage.Name = "bookingsPage";
            bookingsPage.Size = new Size(1132, 523);
            bookingsPage.TabIndex = 1;
            bookingsPage.Text = "Bookings & queue";
            bookingsPage.UseVisualStyleBackColor = true;
            // 
            // bookingsHelp
            // 
            bookingsHelp.Location = new Point(16, 16);
            bookingsHelp.Name = "bookingsHelp";
            bookingsHelp.Size = new Size(1090, 26);
            bookingsHelp.TabIndex = 0;
            bookingsHelp.Text = "RM 5 per wash (30 minutes). Once reserved, pay and start within 5 minutes.";
            // 
            // studentBox
            // 
            studentBox.DropDownStyle = ComboBoxStyle.DropDownList;
            studentBox.Location = new Point(16, 65);
            studentBox.Name = "studentBox";
            studentBox.Size = new Size(280, 31);
            studentBox.TabIndex = 1;
            // 
            // joinButton
            // 
            joinButton.BackColor = Color.FromArgb(40, 122, 208);
            joinButton.FlatStyle = FlatStyle.Flat;
            joinButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            joinButton.ForeColor = Color.White;
            joinButton.Location = new Point(315, 61);
            joinButton.Name = "joinButton";
            joinButton.Size = new Size(140, 36);
            joinButton.TabIndex = 2;
            joinButton.Text = "Join queue";
            joinButton.UseVisualStyleBackColor = false;
            joinButton.Click += JoinClick;
            // 
            // payButton
            // 
            payButton.BackColor = Color.FromArgb(40, 122, 208);
            payButton.FlatStyle = FlatStyle.Flat;
            payButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            payButton.ForeColor = Color.White;
            payButton.Location = new Point(470, 61);
            payButton.Name = "payButton";
            payButton.Size = new Size(110, 36);
            payButton.TabIndex = 3;
            payButton.Text = "Pay";
            payButton.UseVisualStyleBackColor = false;
            payButton.Click += PayClick;
            // 
            // startButton
            // 
            startButton.BackColor = Color.FromArgb(40, 122, 208);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startButton.ForeColor = Color.White;
            startButton.Location = new Point(595, 61);
            startButton.Name = "startButton";
            startButton.Size = new Size(140, 36);
            startButton.TabIndex = 4;
            startButton.Text = "Start wash";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += StartClick;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(40, 122, 208);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(750, 61);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(160, 36);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel booking";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += CancelClick;
            // 
            // bookingsGrid
            // 
            bookingsGrid.AllowUserToAddRows = false;
            bookingsGrid.AllowUserToDeleteRows = false;
            bookingsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bookingsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bookingsGrid.BackgroundColor = Color.White;
            bookingsGrid.ColumnHeadersHeight = 29;
            bookingsGrid.Columns.AddRange(new DataGridViewColumn[] { bookingsGridColumn0, bookingsGridColumn1, bookingsGridColumn2, bookingsGridColumn3, bookingsGridColumn4, bookingsGridColumn5, bookingsGridColumn6, bookingsGridColumn7 });
            bookingsGrid.Location = new Point(16, 120);
            bookingsGrid.MultiSelect = false;
            bookingsGrid.Name = "bookingsGrid";
            bookingsGrid.ReadOnly = true;
            bookingsGrid.RowHeadersVisible = false;
            bookingsGrid.RowHeadersWidth = 51;
            bookingsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bookingsGrid.Size = new Size(1090, 373);
            bookingsGrid.TabIndex = 6;
            bookingsGrid.SelectionChanged += SelectionChanged;
            // 
            // bookingsGridColumn0
            // 
            bookingsGridColumn0.HeaderText = "Booking";
            bookingsGridColumn0.MinimumWidth = 70;
            bookingsGridColumn0.Name = "bookingsGridColumn0";
            bookingsGridColumn0.ReadOnly = true;
            bookingsGridColumn0.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // bookingsGridColumn1
            // 
            bookingsGridColumn1.HeaderText = "Student";
            bookingsGridColumn1.MinimumWidth = 70;
            bookingsGridColumn1.Name = "bookingsGridColumn1";
            bookingsGridColumn1.ReadOnly = true;
            bookingsGridColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // bookingsGridColumn2
            // 
            bookingsGridColumn2.HeaderText = "Status";
            bookingsGridColumn2.MinimumWidth = 70;
            bookingsGridColumn2.Name = "bookingsGridColumn2";
            bookingsGridColumn2.ReadOnly = true;
            bookingsGridColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // bookingsGridColumn3
            // 
            bookingsGridColumn3.HeaderText = "Queue position";
            bookingsGridColumn3.MinimumWidth = 70;
            bookingsGridColumn3.Name = "bookingsGridColumn3";
            bookingsGridColumn3.ReadOnly = true;
            bookingsGridColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // bookingsGridColumn4
            // 
            bookingsGridColumn4.HeaderText = "Machine";
            bookingsGridColumn4.MinimumWidth = 70;
            bookingsGridColumn4.Name = "bookingsGridColumn4";
            bookingsGridColumn4.ReadOnly = true;
            bookingsGridColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // bookingsGridColumn5
            // 
            bookingsGridColumn5.HeaderText = "Payment";
            bookingsGridColumn5.MinimumWidth = 70;
            bookingsGridColumn5.Name = "bookingsGridColumn5";
            bookingsGridColumn5.ReadOnly = true;
            bookingsGridColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // bookingsGridColumn6
            // 
            bookingsGridColumn6.HeaderText = "Pay/start deadline";
            bookingsGridColumn6.MinimumWidth = 70;
            bookingsGridColumn6.Name = "bookingsGridColumn6";
            bookingsGridColumn6.ReadOnly = true;
            bookingsGridColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // bookingsGridColumn7
            // 
            bookingsGridColumn7.HeaderText = "Wash ends";
            bookingsGridColumn7.MinimumWidth = 70;
            bookingsGridColumn7.Name = "bookingsGridColumn7";
            bookingsGridColumn7.ReadOnly = true;
            bookingsGridColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // maintenancePage
            // 
            maintenancePage.Controls.Add(faultLabel);
            maintenancePage.Controls.Add(issueBox);
            maintenancePage.Controls.Add(reportButton);
            maintenancePage.Controls.Add(machineHelp);
            maintenancePage.Controls.Add(machinesGrid);
            maintenancePage.Controls.Add(technicianBox);
            maintenancePage.Controls.Add(assignButton);
            maintenancePage.Controls.Add(repairButton);
            maintenancePage.Controls.Add(notesLabel);
            maintenancePage.Controls.Add(notesBox);
            maintenancePage.Controls.Add(resolveButton);
            maintenancePage.Controls.Add(ticketsGrid);
            maintenancePage.Location = new Point(4, 38);
            maintenancePage.Name = "maintenancePage";
            maintenancePage.Size = new Size(1132, 523);
            maintenancePage.TabIndex = 3;
            maintenancePage.Text = "Machines";
            maintenancePage.UseVisualStyleBackColor = true;
            // 
            // faultLabel
            // 
            faultLabel.Location = new Point(16, 14);
            faultLabel.Name = "faultLabel";
            faultLabel.Size = new Size(140, 26);
            faultLabel.TabIndex = 0;
            faultLabel.Text = "Fault description";
            // 
            // issueBox
            // 
            issueBox.Location = new Point(155, 12);
            issueBox.MaxLength = 200;
            issueBox.Name = "issueBox";
            issueBox.Size = new Size(380, 30);
            issueBox.TabIndex = 1;
            // 
            // reportButton
            // 
            reportButton.BackColor = Color.FromArgb(40, 122, 208);
            reportButton.FlatStyle = FlatStyle.Flat;
            reportButton.ForeColor = Color.White;
            reportButton.Location = new Point(550, 8);
            reportButton.Name = "reportButton";
            reportButton.Size = new Size(150, 36);
            reportButton.TabIndex = 2;
            reportButton.Text = "Report fault";
            reportButton.UseVisualStyleBackColor = false;
            reportButton.Click += ReportClick;
            // 
            // machineHelp
            // 
            machineHelp.Location = new Point(720, 14);
            machineHelp.Name = "machineHelp";
            machineHelp.Size = new Size(380, 26);
            machineHelp.TabIndex = 3;
            machineHelp.Text = "Select an available machine below.";
            // 
            // machinesGrid
            // 
            machinesGrid.AllowUserToAddRows = false;
            machinesGrid.AllowUserToDeleteRows = false;
            machinesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            machinesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            machinesGrid.BackgroundColor = Color.White;
            machinesGrid.ColumnHeadersHeight = 29;
            machinesGrid.Columns.AddRange(new DataGridViewColumn[] { machinesGridColumn0, machinesGridColumn1, machinesGridColumn2, machinesGridColumn3 });
            machinesGrid.Location = new Point(16, 62);
            machinesGrid.MultiSelect = false;
            machinesGrid.Name = "machinesGrid";
            machinesGrid.ReadOnly = true;
            machinesGrid.RowHeadersVisible = false;
            machinesGrid.RowHeadersWidth = 51;
            machinesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            machinesGrid.Size = new Size(1090, 170);
            machinesGrid.TabIndex = 4;
            machinesGrid.SelectionChanged += SelectionChanged;
            // 
            // machinesGridColumn0
            // 
            machinesGridColumn0.HeaderText = "Machine";
            machinesGridColumn0.MinimumWidth = 70;
            machinesGridColumn0.Name = "machinesGridColumn0";
            machinesGridColumn0.ReadOnly = true;
            machinesGridColumn0.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // machinesGridColumn1
            // 
            machinesGridColumn1.HeaderText = "Status";
            machinesGridColumn1.MinimumWidth = 70;
            machinesGridColumn1.Name = "machinesGridColumn1";
            machinesGridColumn1.ReadOnly = true;
            machinesGridColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // machinesGridColumn2
            // 
            machinesGridColumn2.HeaderText = "Current booking";
            machinesGridColumn2.MinimumWidth = 70;
            machinesGridColumn2.Name = "machinesGridColumn2";
            machinesGridColumn2.ReadOnly = true;
            machinesGridColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // machinesGridColumn3
            // 
            machinesGridColumn3.HeaderText = "Wash ends";
            machinesGridColumn3.MinimumWidth = 70;
            machinesGridColumn3.Name = "machinesGridColumn3";
            machinesGridColumn3.ReadOnly = true;
            machinesGridColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // technicianBox
            // 
            technicianBox.DropDownStyle = ComboBoxStyle.DropDownList;
            technicianBox.Location = new Point(16, 255);
            technicianBox.Name = "technicianBox";
            technicianBox.Size = new Size(210, 31);
            technicianBox.TabIndex = 5;
            technicianBox.SelectedIndexChanged += SelectionChanged;
            // 
            // assignButton
            // 
            assignButton.BackColor = Color.FromArgb(40, 122, 208);
            assignButton.FlatStyle = FlatStyle.Flat;
            assignButton.ForeColor = Color.White;
            assignButton.Location = new Point(240, 251);
            assignButton.Name = "assignButton";
            assignButton.Size = new Size(165, 36);
            assignButton.TabIndex = 6;
            assignButton.Text = "Assign technician";
            assignButton.UseVisualStyleBackColor = false;
            assignButton.Click += AssignClick;
            // 
            // repairButton
            // 
            repairButton.BackColor = Color.FromArgb(40, 122, 208);
            repairButton.FlatStyle = FlatStyle.Flat;
            repairButton.ForeColor = Color.White;
            repairButton.Location = new Point(420, 251);
            repairButton.Name = "repairButton";
            repairButton.Size = new Size(140, 36);
            repairButton.TabIndex = 7;
            repairButton.Text = "Start repair";
            repairButton.UseVisualStyleBackColor = false;
            repairButton.Click += RepairClick;
            // 
            // notesLabel
            // 
            notesLabel.BackColor = Color.Transparent;
            notesLabel.FlatStyle = FlatStyle.Flat;
            notesLabel.ForeColor = Color.Black;
            notesLabel.Location = new Point(595, 260);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new Size(79, 26);
            notesLabel.TabIndex = 8;
            notesLabel.Text = "Repair notes";
            // 
            // notesBox
            // 
            notesBox.Location = new Point(680, 255);
            notesBox.MaxLength = 200;
            notesBox.Name = "notesBox";
            notesBox.Size = new Size(250, 30);
            notesBox.TabIndex = 9;
            // 
            // resolveButton
            // 
            resolveButton.BackColor = Color.FromArgb(40, 122, 208);
            resolveButton.FlatStyle = FlatStyle.Flat;
            resolveButton.ForeColor = Color.White;
            resolveButton.Location = new Point(945, 251);
            resolveButton.Name = "resolveButton";
            resolveButton.Size = new Size(160, 36);
            resolveButton.TabIndex = 10;
            resolveButton.Text = "Resolve ticket";
            resolveButton.UseVisualStyleBackColor = false;
            resolveButton.Click += ResolveClick;
            // 
            // ticketsGrid
            // 
            ticketsGrid.AllowUserToAddRows = false;
            ticketsGrid.AllowUserToDeleteRows = false;
            ticketsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ticketsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ticketsGrid.BackgroundColor = Color.White;
            ticketsGrid.ColumnHeadersHeight = 29;
            ticketsGrid.Columns.AddRange(new DataGridViewColumn[] { ticketsGridColumn0, ticketsGridColumn1, ticketsGridColumn2, ticketsGridColumn3, ticketsGridColumn4, ticketsGridColumn5 });
            ticketsGrid.Location = new Point(16, 310);
            ticketsGrid.MultiSelect = false;
            ticketsGrid.Name = "ticketsGrid";
            ticketsGrid.ReadOnly = true;
            ticketsGrid.RowHeadersVisible = false;
            ticketsGrid.RowHeadersWidth = 51;
            ticketsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ticketsGrid.Size = new Size(1090, 189);
            ticketsGrid.TabIndex = 11;
            ticketsGrid.SelectionChanged += SelectionChanged;
            // 
            // ticketsGridColumn0
            // 
            ticketsGridColumn0.HeaderText = "Ticket";
            ticketsGridColumn0.MinimumWidth = 70;
            ticketsGridColumn0.Name = "ticketsGridColumn0";
            ticketsGridColumn0.ReadOnly = true;
            ticketsGridColumn0.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ticketsGridColumn1
            // 
            ticketsGridColumn1.HeaderText = "Machine";
            ticketsGridColumn1.MinimumWidth = 70;
            ticketsGridColumn1.Name = "ticketsGridColumn1";
            ticketsGridColumn1.ReadOnly = true;
            ticketsGridColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ticketsGridColumn2
            // 
            ticketsGridColumn2.HeaderText = "Issue";
            ticketsGridColumn2.MinimumWidth = 70;
            ticketsGridColumn2.Name = "ticketsGridColumn2";
            ticketsGridColumn2.ReadOnly = true;
            ticketsGridColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ticketsGridColumn3
            // 
            ticketsGridColumn3.HeaderText = "Technician";
            ticketsGridColumn3.MinimumWidth = 70;
            ticketsGridColumn3.Name = "ticketsGridColumn3";
            ticketsGridColumn3.ReadOnly = true;
            ticketsGridColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ticketsGridColumn4
            // 
            ticketsGridColumn4.HeaderText = "Status";
            ticketsGridColumn4.MinimumWidth = 70;
            ticketsGridColumn4.Name = "ticketsGridColumn4";
            ticketsGridColumn4.ReadOnly = true;
            ticketsGridColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ticketsGridColumn5
            // 
            ticketsGridColumn5.HeaderText = "Repair notes";
            ticketsGridColumn5.MinimumWidth = 70;
            ticketsGridColumn5.Name = "ticketsGridColumn5";
            ticketsGridColumn5.ReadOnly = true;
            ticketsGridColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // studentsPage
            // 
            studentsPage.Controls.Add(studentsHelp);
            studentsPage.Controls.Add(studentsGrid);
            studentsPage.Location = new Point(4, 38);
            studentsPage.Name = "studentsPage";
            studentsPage.Size = new Size(1132, 523);
            studentsPage.TabIndex = 0;
            studentsPage.Text = "Students";
            studentsPage.UseVisualStyleBackColor = true;
            // 
            // studentsHelp
            // 
            studentsHelp.Location = new Point(16, 16);
            studentsHelp.Name = "studentsHelp";
            studentsHelp.Size = new Size(1080, 26);
            studentsHelp.TabIndex = 0;
            studentsHelp.Text = "Add students here. Each student can have one active booking.";
            // 
            // studentsGrid
            // 
            studentsGrid.AllowUserToAddRows = false;
            studentsGrid.AllowUserToDeleteRows = false;
            studentsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            studentsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            studentsGrid.BackgroundColor = Color.White;
            studentsGrid.ColumnHeadersHeight = 29;
            studentsGrid.Columns.AddRange(new DataGridViewColumn[] { studentsGridColumn0, studentsGridColumn1, studentsGridColumn2 });
            studentsGrid.Location = new Point(16, 59);
            studentsGrid.MultiSelect = false;
            studentsGrid.Name = "studentsGrid";
            studentsGrid.ReadOnly = true;
            studentsGrid.RowHeadersVisible = false;
            studentsGrid.RowHeadersWidth = 51;
            studentsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentsGrid.Size = new Size(1090, 447);
            studentsGrid.TabIndex = 8;
            studentsGrid.CellContentClick += studentsGrid_CellContentClick;
            // 
            // studentsGridColumn0
            // 
            studentsGridColumn0.HeaderText = "ID";
            studentsGridColumn0.MinimumWidth = 70;
            studentsGridColumn0.Name = "studentsGridColumn0";
            studentsGridColumn0.ReadOnly = true;
            studentsGridColumn0.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // studentsGridColumn1
            // 
            studentsGridColumn1.HeaderText = "Student name";
            studentsGridColumn1.MinimumWidth = 70;
            studentsGridColumn1.Name = "studentsGridColumn1";
            studentsGridColumn1.ReadOnly = true;
            studentsGridColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // studentsGridColumn2
            // 
            studentsGridColumn2.HeaderText = "Phone";
            studentsGridColumn2.MinimumWidth = 70;
            studentsGridColumn2.Name = "studentsGridColumn2";
            studentsGridColumn2.ReadOnly = true;
            studentsGridColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // paymentsPage
            // 
            paymentsPage.Controls.Add(paymentsHelp);
            paymentsPage.Controls.Add(receiptButton);
            paymentsPage.Controls.Add(paymentsGrid);
            paymentsPage.Location = new Point(4, 38);
            paymentsPage.Name = "paymentsPage";
            paymentsPage.Size = new Size(1132, 523);
            paymentsPage.TabIndex = 2;
            paymentsPage.Text = "Payments & receipts";
            paymentsPage.UseVisualStyleBackColor = true;
            // 
            // paymentsHelp
            // 
            paymentsHelp.Location = new Point(16, 16);
            paymentsHelp.Name = "paymentsHelp";
            paymentsHelp.Size = new Size(1090, 26);
            paymentsHelp.TabIndex = 0;
            paymentsHelp.Text = "Choose a paid transaction to view its receipt. No real money is charged.";
            // 
            // receiptButton
            // 
            receiptButton.Location = new Point(16, 58);
            receiptButton.Name = "receiptButton";
            receiptButton.Size = new Size(160, 36);
            receiptButton.TabIndex = 1;
            receiptButton.Text = "View receipt";
            receiptButton.UseVisualStyleBackColor = true;
            receiptButton.Click += ReceiptClick;
            // 
            // paymentsGrid
            // 
            paymentsGrid.AllowUserToAddRows = false;
            paymentsGrid.AllowUserToDeleteRows = false;
            paymentsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            paymentsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            paymentsGrid.BackgroundColor = Color.White;
            paymentsGrid.ColumnHeadersHeight = 29;
            paymentsGrid.Columns.AddRange(new DataGridViewColumn[] { paymentsGridColumn0, paymentsGridColumn1, paymentsGridColumn2, paymentsGridColumn3, paymentsGridColumn4, paymentsGridColumn5 });
            paymentsGrid.Location = new Point(16, 120);
            paymentsGrid.MultiSelect = false;
            paymentsGrid.Name = "paymentsGrid";
            paymentsGrid.ReadOnly = true;
            paymentsGrid.RowHeadersVisible = false;
            paymentsGrid.RowHeadersWidth = 51;
            paymentsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            paymentsGrid.Size = new Size(1090, 373);
            paymentsGrid.TabIndex = 2;
            paymentsGrid.SelectionChanged += SelectionChanged;
            // 
            // paymentsGridColumn0
            // 
            paymentsGridColumn0.HeaderText = "Payment";
            paymentsGridColumn0.MinimumWidth = 70;
            paymentsGridColumn0.Name = "paymentsGridColumn0";
            paymentsGridColumn0.ReadOnly = true;
            paymentsGridColumn0.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // paymentsGridColumn1
            // 
            paymentsGridColumn1.HeaderText = "Booking";
            paymentsGridColumn1.MinimumWidth = 70;
            paymentsGridColumn1.Name = "paymentsGridColumn1";
            paymentsGridColumn1.ReadOnly = true;
            paymentsGridColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // paymentsGridColumn2
            // 
            paymentsGridColumn2.HeaderText = "Amount (RM)";
            paymentsGridColumn2.MinimumWidth = 70;
            paymentsGridColumn2.Name = "paymentsGridColumn2";
            paymentsGridColumn2.ReadOnly = true;
            paymentsGridColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // paymentsGridColumn3
            // 
            paymentsGridColumn3.HeaderText = "Method";
            paymentsGridColumn3.MinimumWidth = 70;
            paymentsGridColumn3.Name = "paymentsGridColumn3";
            paymentsGridColumn3.ReadOnly = true;
            paymentsGridColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // paymentsGridColumn4
            // 
            paymentsGridColumn4.HeaderText = "Status";
            paymentsGridColumn4.MinimumWidth = 70;
            paymentsGridColumn4.Name = "paymentsGridColumn4";
            paymentsGridColumn4.ReadOnly = true;
            paymentsGridColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // paymentsGridColumn5
            // 
            paymentsGridColumn5.HeaderText = "Paid at";
            paymentsGridColumn5.MinimumWidth = 70;
            paymentsGridColumn5.Name = "paymentsGridColumn5";
            paymentsGridColumn5.ReadOnly = true;
            paymentsGridColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // notificationsPage
            // 
            notificationsPage.Controls.Add(notificationsHelp);
            notificationsPage.Controls.Add(messages);
            notificationsPage.Location = new Point(4, 38);
            notificationsPage.Name = "notificationsPage";
            notificationsPage.Size = new Size(1132, 523);
            notificationsPage.TabIndex = 4;
            notificationsPage.Text = "Notifications";
            notificationsPage.UseVisualStyleBackColor = true;
            // 
            // notificationsHelp
            // 
            notificationsHelp.Location = new Point(16, 16);
            notificationsHelp.Name = "notificationsHelp";
            notificationsHelp.Size = new Size(1090, 26);
            notificationsHelp.TabIndex = 0;
            notificationsHelp.Text = "Booking and wash updates. Newest first. No SMS is sent.";
            // 
            // messages
            // 
            messages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            messages.HorizontalScrollbar = true;
            messages.ItemHeight = 23;
            messages.Location = new Point(16, 60);
            messages.Name = "messages";
            messages.Size = new Size(1090, 326);
            messages.TabIndex = 1;
            // 
            // clock
            // 
            clock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            clock.Location = new Point(20, 690);
            clock.Name = "clock";
            clock.Size = new Size(350, 30);
            clock.TabIndex = 3;
            clock.Text = "Demo clock";
            // 
            // advanceButton
            // 
            advanceButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            advanceButton.Location = new Point(385, 683);
            advanceButton.Name = "advanceButton";
            advanceButton.Size = new Size(185, 36);
            advanceButton.TabIndex = 4;
            advanceButton.Text = "Demo: +5 minutes";
            advanceButton.UseVisualStyleBackColor = true;
            advanceButton.Click += AdvanceClick;
            // 
            // sessionLabel
            // 
            sessionLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            sessionLabel.Location = new Point(590, 690);
            sessionLabel.Name = "sessionLabel";
            sessionLabel.Size = new Size(565, 45);
            sessionLabel.TabIndex = 5;
            sessionLabel.Text = "Records are kept until you close the start screen.";
            // 
            // backHomeButton
            // 
            backHomeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            backHomeButton.BackColor = Color.FromArgb(34, 102, 174);
            backHomeButton.FlatStyle = FlatStyle.Flat;
            backHomeButton.ForeColor = Color.White;
            backHomeButton.Location = new Point(990, 25);
            backHomeButton.Name = "backHomeButton";
            backHomeButton.Size = new Size(165, 38);
            backHomeButton.TabIndex = 0;
            backHomeButton.Text = "Back to home";
            backHomeButton.UseVisualStyleBackColor = false;
            backHomeButton.Click += BackHomeClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(242, 247, 252);
            ClientSize = new Size(1184, 760);
            Controls.Add(backHomeButton);
            Controls.Add(headingLabel);
            Controls.Add(summary);
            Controls.Add(mainTabs);
            Controls.Add(clock);
            Controls.Add(advanceButton);
            Controls.Add(sessionLabel);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1200, 799);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Campus Laundry Queue System";
            FormClosed += MainFormClosed;
            Load += MainFormLoad;
            mainTabs.ResumeLayout(false);
            bookingsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bookingsGrid).EndInit();
            maintenancePage.ResumeLayout(false);
            maintenancePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)machinesGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ticketsGrid).EndInit();
            studentsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)studentsGrid).EndInit();
            paymentsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)paymentsGrid).EndInit();
            notificationsPage.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Label headingLabel = null!;
        private System.Windows.Forms.Label summary = null!;
        private System.Windows.Forms.TabControl mainTabs = null!;
        private System.Windows.Forms.Button backHomeButton = null!;
        private System.Windows.Forms.TabPage studentsPage = null!;
        private System.Windows.Forms.TabPage bookingsPage = null!;
        private System.Windows.Forms.TabPage paymentsPage = null!;
        private System.Windows.Forms.TabPage maintenancePage = null!;
        private System.Windows.Forms.TabPage notificationsPage = null!;
        private System.Windows.Forms.Label studentsHelp = null!;
        private System.Windows.Forms.DataGridView studentsGrid = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentsGridColumn0 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentsGridColumn1 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentsGridColumn2 = null!;
        private System.Windows.Forms.Label bookingsHelp = null!;
        private System.Windows.Forms.ComboBox studentBox = null!;
        private System.Windows.Forms.Button joinButton = null!;
        private System.Windows.Forms.Button payButton = null!;
        private System.Windows.Forms.Button startButton = null!;
        private System.Windows.Forms.Button cancelButton = null!;
        private System.Windows.Forms.DataGridView bookingsGrid = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingsGridColumn0 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingsGridColumn1 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingsGridColumn2 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingsGridColumn3 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingsGridColumn4 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingsGridColumn5 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingsGridColumn6 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingsGridColumn7 = null!;
        private System.Windows.Forms.Label paymentsHelp = null!;
        private System.Windows.Forms.Button receiptButton = null!;
        private System.Windows.Forms.DataGridView paymentsGrid = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentsGridColumn0 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentsGridColumn1 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentsGridColumn2 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentsGridColumn3 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentsGridColumn4 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentsGridColumn5 = null!;
        private System.Windows.Forms.Label faultLabel = null!;
        private System.Windows.Forms.TextBox issueBox = null!;
        private System.Windows.Forms.Button reportButton = null!;
        private System.Windows.Forms.Label machineHelp = null!;
        private System.Windows.Forms.DataGridView machinesGrid = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn machinesGridColumn0 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn machinesGridColumn1 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn machinesGridColumn2 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn machinesGridColumn3 = null!;
        private System.Windows.Forms.ComboBox technicianBox = null!;
        private System.Windows.Forms.Button assignButton = null!;
        private System.Windows.Forms.Button repairButton = null!;
        private System.Windows.Forms.Label notesLabel = null!;
        private System.Windows.Forms.TextBox notesBox = null!;
        private System.Windows.Forms.Button resolveButton = null!;
        private System.Windows.Forms.DataGridView ticketsGrid = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketsGridColumn0 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketsGridColumn1 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketsGridColumn2 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketsGridColumn3 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketsGridColumn4 = null!;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketsGridColumn5 = null!;
        private System.Windows.Forms.Label notificationsHelp = null!;
        private System.Windows.Forms.ListBox messages = null!;
        private System.Windows.Forms.Label clock = null!;
        private System.Windows.Forms.Button advanceButton = null!;
        private System.Windows.Forms.Label sessionLabel = null!;
    }
}
