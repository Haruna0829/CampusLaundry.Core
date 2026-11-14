# Windows checks before submission

These manual GUI checks remain to be performed on your Windows computer. Business-rule checks passing does not replace clicking through the interface.

- [ ] Extract the full folder and launch with RUN_GUI.cmd.
- [ ] Verify every tab and button is visible at your normal screen resolution.
- [ ] Resize the window and check 100%, 125% and 150% Windows display scaling if available.
- [ ] Navigate fields with Tab, select students and technicians, and select different table rows.
- [ ] Register a valid student; reject a blank name, duplicate ID and invalid phone.
- [ ] Join a queue, verify Pay/Start/Cancel button availability for each state.
- [ ] Cancel the payment dialog: no payment should be recorded.
- [ ] Simulate payment failure, retry successfully and start the wash.
- [ ] Verify View receipt is disabled for failed payments; successful receipts open and save.
- [ ] Cancel Save File dialog without error. Test saving somewhere writable.
- [ ] Fill all three machines and verify a fourth student waits.
- [ ] Complete a cycle using the demo clock and verify automatic queue advancement.
- [ ] Let an unpaid reservation expire; verify cancellation and release.
- [ ] Let a paid reservation expire; verify refund.
- [ ] Cancel a paid reservation before starting and verify refund.
- [ ] Open a payment dialog, let the reservation expire, then confirm: it should reject the stale booking.
- [ ] Report a fault on an available machine, assign a technician, start and resolve the repair.
- [ ] Verify a busy technician cannot be assigned to a second ticket.
- [ ] Check notification messages after the above actions.
- [ ] Close, choose No, and confirm the app stays open. Close with Yes and verify a new session starts fresh.
- [ ] Run RUN_CHECKS.cmd and confirm all 40 checks pass.

If a check fails, keep the exact steps and error text so the group can fix and retest it before recording.

## Shared-session checks

- [ ] Open Admin, Ali and Mei from the same start screen. Keep all three open.
- [ ] Join as Ali: Admin sees Ali's reservation; Mei sees no Ali booking, payment or personal update.
- [ ] Pay and start as Ali: both Ali and Admin see the change.
- [ ] Register through Student > Register: the personal view opens and Admin > Students updates.
- [ ] A personal student view cannot change identity, manage repairs or advance time. New registration is on the separate student entry screen.
- [ ] Report/repair a machine in Admin: student machine status updates too.
- [ ] Advance time in Admin: reservations expire and washes finish in every view.
- [ ] Close a student window and reopen it: its records remain.
- [ ] Close Admin and reopen it: all records remain.
- [ ] Try closing the start screen, choose No, then make another booking. All views must still refresh.
- [ ] Close the start screen with Yes: all child windows close. A new run starts fresh.
- [ ] Open StartForm and MainForm with View Designer, edit a button label, save and run.

## Welcome and registration

- [ ] Check the large Village 5 Campus Laundry title and both panels at your screen scaling.
- [ ] Open Student: Register and Existing student tabs are visible without clipped controls.
- [ ] Reject blank names, duplicate IDs and invalid phone numbers without leaving the registration screen.
- [ ] Register a new student: their personal view opens and their profile appears in Admin and Existing student.
- [ ] Back to home from each view returns to the welcome screen without clearing records.
- [ ] Keep Admin open while registering and booking as a student. Confirm both update.
- [ ] Open StudentEntryForm using View Designer; edit and save a label.
