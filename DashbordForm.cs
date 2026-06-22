using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

            // ── Wire Logout button ────────────────────────────────────────────
            button9.Click += BtnLogout_Click;

            // ── Wire Navigation sidebar buttons ──────────────────────────────
            button1.Click  += (s, ev) => { /* Dashboard – already here, do nothing */ };
            button2.Click  += BtnVehicles_Click;       // 🚗 Vehicles
            button3.Click  += BtnCustomers_Click;      // 👤 Customers
            button4.Click  += BtnRentalBooking_Click;  // 📋 Rental Booking
            button5.Click  += BtnReturnVehicle_Click;  // 🔄 Return Vehicle
            button6.Click  += BtnPayments_Click;       // 💳 Payments
            button7.Click  += BtnReports_Click;        // 📊 Reports
            button8.Click  += BtnUsers_Click;          // ⚙️ Users (Admin)

            // ── Wire quick-action buttons (main area) ─────────────────────────
            button10.Click += BtnRentalBooking_Click;  // New Booking
            button11.Click += BtnReturnVehicle_Click;  // Process Return
            button12.Click += BtnReports_Click;        // View Reports

            // ── Wire menu strip (logic only – no designer changes) ────────────
            reportsToolStripMenuItem.Click += BtnReports_Click;
            adminToolStripMenuItem.Click   += BtnUsers_Click;
            modulesToolStripMenuItem.Click += BtnShowModulesMenu;

            // Apply role-based visibility (hide buttons the role can't access)
            ApplyRolePermissions();

            LoadDashboardData();
        }

        // ── Helper: open a child form modally, then return to dashboard ───────
        private void OpenChildForm(Form childForm)
        {
            childForm.StartPosition = FormStartPosition.CenterScreen;
            Hide();
            try
            {
                childForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not open this module:\n{ex.Message}",
                    "Navigation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Show();
                LoadDashboardData();
            }
        }

        // ── Navigation handlers ───────────────────────────────────────────────
        private void BtnVehicles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form3());
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCustomer());
        }

        private void BtnRentalBooking_Click(object sender, EventArgs e)
        {
            OpenChildForm(new bookingForm());
        }

        private void BtnReturnVehicle_Click(object sender, EventArgs e)
        {
            OpenChildForm(new returnForm());
        }

        private void BtnPayments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPayment());
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form8());
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "User accounts are stored in the VehicleRentalDB → users table.\n" +
                "Manage them via phpMyAdmin (XAMPP) or extend this module later.",
                "User Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnShowModulesMenu(object sender, EventArgs e)
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("🚗 Vehicles",       null, (s, ev) => BtnVehicles_Click(s, ev));
            menu.Items.Add("👤 Customers",      null, (s, ev) => BtnCustomers_Click(s, ev));
            menu.Items.Add("📋 Rental Booking", null, (s, ev) => BtnRentalBooking_Click(s, ev));
            menu.Items.Add("🔄 Return Vehicle", null, (s, ev) => BtnReturnVehicle_Click(s, ev));
            menu.Items.Add("💳 Payments",       null, (s, ev) => BtnPayments_Click(s, ev));
            menu.Show(menuStrip1, new System.Drawing.Point(0, menuStrip1.Height));
        }

        // ── Load live stats from MySQL (updates existing labels/grid only) ───
        private void LoadDashboardData()
        {
            try
            {
                using var conn = new MySqlConnection(DatabaseConnection.ConnectionString);
                conn.Open();

                label3.Text  = ScalarInt(conn, "SELECT COUNT(*) FROM vehicle").ToString();
                label6.Text  = ScalarInt(conn, "SELECT COUNT(*) FROM vehicle WHERE Status = 'Available'").ToString();
                label8.Text  = ScalarInt(conn, "SELECT COUNT(*) FROM vehicle WHERE Status = 'Rented'").ToString();
                label10.Text = ScalarInt(conn, "SELECT COUNT(*) FROM vehicle WHERE Status = 'Maintenance'").ToString();

                const string recentSql = @"
                    SELECT c.FullName AS Customer,
                           CONCAT(v.Brand, ' ', v.Model) AS Vehicle,
                           DATE_FORMAT(r.EndDate, '%Y-%m-%d') AS `Return`
                    FROM rentals r
                    JOIN customers c ON r.CustomerID = c.CustomerID
                    JOIN vehicle   v ON r.VehicleID  = v.ID
                    WHERE r.Status = 'Active'
                    ORDER BY r.StartDate DESC
                    LIMIT 10";

                using var cmd = new MySqlCommand(recentSql, conn);
                using var adapter = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                // Keep designer default values when DB is unavailable
            }
        }

        private static int ScalarInt(MySqlConnection conn, string sql)
        {
            using var cmd = new MySqlCommand(sql, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
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
