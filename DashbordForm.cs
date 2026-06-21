using System;
using System.Windows.Forms;

namespace Vehical_Rental_Management_System
{
    /// <summary>
    /// Main Dashboard form. Opened after a successful login.
    /// Receives the logged-in user's name and role from LoginForm.
    /// </summary>
    public partial class Form2 : Form
    {
        // ── Logged-in user info ───────────────────────────────────────────────
        private readonly string _loggedInUser;
        private readonly string _loggedInRole;

        // ── Constructor (called by LoginForm) ─────────────────────────────────
        public Form2(string username, string role)
        {
            InitializeComponent();

            _loggedInUser = username;
            _loggedInRole = role;
        }

        // ── Default constructor (keeps Designer happy) ────────────────────────
        public Form2() : this("Guest", "Viewer") { }

        // ── Form Load ─────────────────────────────────────────────────────────
        private void Form2_Load(object sender, EventArgs e)
        {
            // Show the logged-in user and role in the title bar
            Text = $"Vehicle Rental Management System  –  {_loggedInUser} ({_loggedInRole})";

            // Show user info in the navigation panel header (label1 = "NAVIGATION")
            label1.Text = $"👤 {_loggedInUser}\n{_loggedInRole}";

            // Wire the Logout button (button9) to close the dashboard
            button9.Click += BtnLogout_Click;

            // Apply role-based visibility (hide buttons the role can't access)
            ApplyRolePermissions();
        }

        // ── Logout ────────────────────────────────────────────────────────────
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                $"Are you sure you want to logout, {_loggedInUser}?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DialogResult = DialogResult.Retry; // Signals Program.cs to show LoginForm again
                Close();
            }
        }

        // ── Role-based UI permissions ─────────────────────────────────────────
        /// <summary>
        /// Hides/disables menu items and buttons the current role cannot access.
        /// Extend this method as you add more role-restricted features.
        /// </summary>
        private void ApplyRolePermissions()
        {
            switch (_loggedInRole)
            {
                case "Admin":
                    // Admin sees everything — no restrictions
                    break;

                case "Manager":
                    // Manager cannot access the Users admin button
                    button8.Visible = false;    // ⚙️ Users
                    adminToolStripMenuItem.Visible = false;
                    break;

                case "Staff":
                    // Staff can only do bookings and returns
                    button7.Visible  = false;   // 📊 Reports
                    button8.Visible  = false;   // ⚙️ Users
                    button12.Visible = false;   // View Reports
                    adminToolStripMenuItem.Visible   = false;
                    reportsToolStripMenuItem.Visible = false;
                    break;

                case "Viewer":
                    // Viewer is read-only — disable all action buttons
                    button7.Visible  = false;
                    button8.Visible  = false;
                    button10.Visible = false;   // New Booking
                    button11.Visible = false;   // Process Return
                    button12.Visible = false;
                    adminToolStripMenuItem.Visible   = false;
                    break;
            }
        }
    }
}
