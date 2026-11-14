# Village 5 Campus Laundry — WinForms

A classroom desktop application for a campus laundry room. It uses C# Windows Forms and a separate C# class library. Each class, interface and enum has its own file.

## Student and admin views

The start screen opens separate windows using the same session. Keep the start screen open, click **Open admin view**, then click **Open student view**, choose **Existing student**, select Ali and continue. Both windows can stay open. You can also open Mei's or Ravi's view.

| View | What you can do |
| --- | --- |
| Student | Join the queue, pay, start or cancel an eligible booking, view personal payments and receipts, check machine availability and read personal updates. |
| Admin | View registered students and all bookings and payments, cancel eligible bookings, manage machines and repairs, and advance demo time. |

A student view is fixed to the student chosen on the start screen. It shows only that student's bookings, payments and updates. To use another student, click Student on the home screen and choose Existing student. New students use the Register tab, entering ID, name and phone number. Opening an already-open view brings it to the front.

Changes refresh all open views immediately after an action and every second while time passes. Closing one view keeps the records. Closing the **start screen** ends the session and clears the records after confirmation.

This is a same-computer classroom demonstration with role selection, not password-protected accounts. Two separately launched copies or two different computers do **not** share data. That would require a database/server and authentication.

The session starts with three machines, Ali, Mei, Ravi and two technicians. A wash costs RM 5 and takes 30 minutes. The admin's **Demo: +5 minutes** button advances time for every view. Ordinary time also continues to pass.

## Start here on Windows

1. Extract the entire ZIP. Do not run files while they are still inside the ZIP.
2. Keep the three project folders together. Do not move Program.cs into the class library.
3. Install the [.NET 8 SDK for Windows](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) if needed. `dotnet --list-sdks` should include an 8.x version.
4. Open the extracted `CampusLaundryGUI` folder and double-click **RUN_GUI.cmd**.
5. The first launch may need an internet connection to restore/build the project.

### VS Code

Open the folder containing `CampusLaundryGUI.sln` and `RUN_GUI.cmd` using File > Open Folder.

Open Terminal > New Terminal, then run:

```powershell
dotnet run --project ".\CampusLaundry.WinForms\CampusLaundry.WinForms.csproj"
```

Alternatively, use Terminal > Run Task > **Run Campus Laundry GUI**.
Do not use Code Runner's single-file play button: the application is a project, not a scriptcs script.

### Visual Studio on Windows

Open `CampusLaundryGUI.sln`. Set **CampusLaundry.WinForms** as the startup project, then run it. To edit the interface, stop debugging, expand CampusLaundry.WinForms, right-click MainForm.cs and choose View Designer (Shift+F7). StartForm.cs, StudentEntryForm.cs, PaymentForm.cs and ReceiptForm.cs also have editable Designer layouts. See OPEN_DESIGNER.md.

## Demonstrate both views

1. Run the app once. From the start screen open Admin and Ali's student view.
2. In Ali's **My bookings**, click **Join queue**. Switch to Admin > **All bookings** to see the same reservation.
3. In Ali's window click **Pay**, choose a method and confirm. Click **Start wash**. Check the payment and machine status in Admin.
4. Open Mei and Ravi from the start screen. Pay and start their washes too.
5. On the home screen, open the student view. Register Sara (S004 with a valid phone number). Her personal laundry view opens automatically.
6. Sara joins the queue and waits in position 1 because all machines are busy.
7. In Admin, press **Demo: +5 minutes** six times. The washes finish and Sara gets a reservation. Check Sara's updates and Admin's bookings.
8. Close and reopen Ali's window: his records remain. Close the start screen only when the demonstration is finished.

## Behaviour and scope

- This is a **shared, in-memory classroom demo on one computer**. Closing the start screen clears the session after confirmation. There is no database, login, network service or hardware control.
- Payments and refunds are simulations; no card details or real payment gateway are used. SMS delivery is represented by the Notifications tab.
- One active booking per student. Available machines are allocated in machine-number order; waiting students are served first in, first out.
- A reservation lasts five minutes. Pay and start before its deadline. An expired paid reservation is automatically refunded in the simulation.
- Payment and starting the wash are separate actions, allowing a demonstration of paid-reservation cancellation/refund.
- Waiting and reserved bookings can be cancelled. A running wash must finish; this prototype does not support emergency stop or interrupting a running machine for maintenance.
- A failed payment leaves the reservation eligible for a retry before expiry. A successful payment cannot be charged twice.
- Fault reporting is allowed only for an available machine. A technician can handle one unresolved assigned ticket at a time.
- The queue is shown by position. No exact wait estimate is promised because a reserved student may pay, cancel or let the reservation expire.
- Receipts are text exports; printing to a physical printer is outside this version.

## Files to understand

| Folder/file | Purpose |
| --- | --- |
| CampusLaundry.Core | Class library: students, bookings, queue, machines, payments, receipts, maintenance and enums. |
| CampusLaundry.Core/LaundryRoom.cs | Coordinates operations and enforces booking, payment and repair rules. |
| CampusLaundry.WinForms/Program.cs | Application entry point that opens StartForm. |
| CampusLaundry.WinForms/StartForm.cs | Welcome screen with Student and Admin panels; owns the shared timer. |
| CampusLaundry.WinForms/StudentEntryForm.cs | Student self-registration and existing-profile selection. |
| CampusLaundry.WinForms/AppSession.cs | Shared laundry room, clock, update event and student record filters. |
| CampusLaundry.WinForms/MainForm.cs | Shared screen layout, role-specific controls, button handlers and refresh. |
| CampusLaundry.WinForms/PaymentForm.cs | Modal payment-method and simulated-failure dialog. |
| CampusLaundry.WinForms/ReceiptForm.cs | Receipt display and text-file export. |
| CampusLaundry.WinForms/FormNotificationService.cs | Implements INotificationService for the on-screen message list. |
| CampusLaundry.Checks | Console checks for business rules; not the GUI startup project. |
| VIDEO_GUIDE.md | Suggested video demonstration and submission checklist. |
| WINDOWS_CHECKLIST.md | Hands-on checks to complete on Windows before recording. |
| DESIGN_NOTES.md | How this version extends the first assignment's dummy classes. |

## Verify

```powershell
dotnet build CampusLaundryGUI.sln
dotnet run --project ".\CampusLaundry.Checks\CampusLaundry.Checks.csproj"
```

This update builds with .NET SDK 8.0.408 with zero warnings and errors. All 40 business-rule and shared-session checks passed. Actual Windows GUI and Designer testing still needs to be completed using WINDOWS_CHECKLIST.md.

## Submit

Upload the source folders, solution, launchers and documentation to your group's intended GitHub repository. Do not upload bin or obj; .gitignore excludes them. Keep individual changes attributable to the members who actually make them.

Record the running application on Windows, explain the flow in your own words, upload the video to your chosen host, and submit the video link plus the repository link. This package does not create those online links for you. Check that your lecturer can access both links.

Project configuration reference: https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props-desktop

## Updated design

The welcome page displays Village 5 Campus Laundry with two matching panels. Student registration is inside the student entry screen; the admin's Students tab is a read-only list. Both main views and the student entry screen include Back to home. A main view closes when returning home, but its session records remain. Reopen it to continue.

Machine status uses text plus colour: green Available, amber Reserved, blue Washing and red Out of order. The home and entry forms use fixed layouts and DPI scaling. Check the Windows display and Designer checklist before recording.
