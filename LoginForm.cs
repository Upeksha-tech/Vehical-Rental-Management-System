using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;           // MySql.Data v9.7.0 (already in .csproj)

namespace Vehical_Rental_Management_System
{
    /// <summary>
    /// Login form for the Vehicle Rental Management System.
    /// Primary authentication: XAMPP MySQL (localhost:3306 → VehicleRentalDB).
    /// Fallback:               Hardcoded mock credentials (offline / demo mode).
    /// </summary>
    public partial class LoginForm : Form
    {
        // ── Configuration ─────────────────────────────────────────────────────
        /// <summary>
        /// XAMPP MySQL connection string.
        /// Default XAMPP settings: host=localhost, port=3306, user=root, password="" (empty).
        /// Change "database" to match your schema name.
        /// </summary>
        private const string MySqlConnectionString = DatabaseConnection.ConnectionString;

        // ── Mock credential store (offline fallback) ──────────────────────────
        // { username, password, role }  — case-sensitive passwords
        private static readonly string[,] MockUsers =
        {
            { "manager", "Mgr@2024",   "Manager" },
            { "staff",   "Staff@001",  "Staff"   }
        };

        // ── State ────────────────────────────────────────────────────────────
        // true  = use hardcoded mock users (no DB needed, good for testing)
        // false = connect to XAMPP MySQL (make sure VehicleRentalDB exists)
        private bool _useMockAuth = false;

        public string LoggedInUser { get; private set; } = string.Empty;
        public string LoggedInRole { get; private set; } = string.Empty;

        // ── Constructor ───────────────────────────────────────────────────────
        public LoginForm()
        {
            InitializeComponent();
        }

        // ────────────────────────────────────────────────────────────────────
        //  Form Load
        // ────────────────────────────────────────────────────────────────────
        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;

            txtUsername.Focus();

            // Enter key from any input fires the login
            txtUsername.KeyDown += InputField_KeyDown;
            txtPassword.KeyDown += InputField_KeyDown;
            cmbRole.KeyDown += InputField_KeyDown;

            AttachButtonHoverEffects();
        }

        // ────────────────────────────────────────────────────────────────────
        //  Card shadow / rounded corners  (pnlCard Paint)
        // ────────────────────────────────────────────────────────────────────
        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var panel = (Panel)sender;
            var rect = new Rectangle(4, 4, panel.Width - 8, panel.Height - 8);
            int r = 16;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Layered drop-shadow
            for (int i = 6; i >= 1; i--)
            {
                using var sb = new SolidBrush(Color.FromArgb(12 * i, 0, 0, 0));
                using var sp = RoundedRectPath(
                    new Rectangle(rect.X - i, rect.Y + i, rect.Width + i * 2, rect.Height + i * 2), r);
                g.FillPath(sb, sp);
            }

            // White card
            using var cardBrush = new SolidBrush(Color.White);
            using var cardPath = RoundedRectPath(rect, r);
            g.FillPath(cardBrush, cardPath);

            using var borderPen = new Pen(Color.FromArgb(210, 210, 215), 1f);
            g.DrawPath(borderPen, cardPath);
        }

        // ────────────────────────────────────────────────────────────────────
        //  btnLogin_Click
        // ────────────────────────────────────────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString() ?? string.Empty;

            // ── Validation ────────────────────────────────────────────────────
            if (string.IsNullOrWhiteSpace(username))
            {
                ShowFieldError("Username cannot be empty.", txtUsername);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                ShowFieldError("Password cannot be empty.", txtPassword);
                return;
            }
            if (string.IsNullOrWhiteSpace(role))
            {
                ShowFieldError("Please select a role.", null);
                return;
            }

            // ── Authenticate ──────────────────────────────────────────────────
            bool ok = _useMockAuth
                ? AuthenticateMock(username, password, role)
                : AuthenticateMySQL(username, password, role);

            if (ok) OnLoginSuccess(username, role);
            else OnLoginFailure();
        }

        // ────────────────────────────────────────────────────────────────────
        //  MySQL Authentication  (XAMPP / localhost:3306)
        // ────────────────────────────────────────────────────────────────────
        /// <summary>
        /// Expects a MySQL table:
        /// <code>
        ///   CREATE TABLE users (
        ///       id          INT AUTO_INCREMENT PRIMARY KEY,
        ///       username    VARCHAR(100) NOT NULL UNIQUE,
        ///       password    VARCHAR(255) NOT NULL,   -- store hashed in production
        ///       role        VARCHAR(50)  NOT NULL,
        ///       is_active   TINYINT(1)   DEFAULT 1
        ///   );
        /// </code>
        /// Quick insert to test:
        /// <code>
        ///   INSERT INTO users (username, password, role)
        ///   VALUES ('admin', 'Admin@123', 'Admin');
        /// </code>
        /// </summary>
        private bool AuthenticateMySQL(string username, string password, string role)
        {
            try
            {
                using var conn = new MySqlConnection(MySqlConnectionString);
                conn.Open();

                // Parameterised query – immune to SQL injection
                const string sql =
                    "SELECT COUNT(1) FROM users " +
                    "WHERE username = @user " +
                    "  AND password = @pass " +    // replace with hash check in production
                    "  AND role = @role " +
                    "  AND is_active = 1";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", role);

                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (MySqlException ex)
            {
                // Common error codes:
                //   1045 – Access denied (wrong credentials)
                //   2003 – Can't connect (XAMPP not running)
                //   1049 – Unknown database
                string hint = ex.Number switch
                {
                    1045 => "Access denied. Check MySQL username/password in the connection string.",
                    2003 => "Cannot connect to MySQL. Make sure XAMPP is running and MySQL service is started.",
                    1049 => "Database 'VehicleRentalDB' not found. Create it in phpMyAdmin first.",
                    1146 => "Table 'users' does not exist. Run the CREATE TABLE script.",
                    _ => ex.Message
                };

                DialogResult choice = MessageBox.Show(
                    $"MySQL Error ({ex.Number}):\n{hint}\n\n" +
                    "Would you like to continue in offline demo mode?",
                    "Database Connection Error",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (choice == DialogResult.Yes)
                {
                    _useMockAuth = true;                      // auto-fallback
                    return AuthenticateMock(username, password, role);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ────────────────────────────────────────────────────────────────────
        //  Mock Authentication  (offline demo)
        // ────────────────────────────────────────────────────────────────────
        private bool AuthenticateMock(string username, string password, string role)
        {
            int rows = MockUsers.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                bool userMatch = string.Equals(MockUsers[i, 0], username, StringComparison.OrdinalIgnoreCase);
                bool passMatch = MockUsers[i, 1] == password;                       // case-sensitive
                bool roleMatch = string.Equals(MockUsers[i, 2], role, StringComparison.OrdinalIgnoreCase);
                if (userMatch && passMatch && roleMatch) return true;
            }
            return false;
        }

        // ────────────────────────────────────────────────────────────────────
        //  Post-login handlers
        // ────────────────────────────────────────────────────────────────────
        private void OnLoginSuccess(string username, string role)
        {
            lblAttemptsWarn.Text = string.Empty;
            OpenDashboard(username, role);
        }

        private void OnLoginFailure()
        {
            lblAttemptsWarn.Text = "⚠ Invalid username, password, or role. Please try again.";
            txtPassword.Clear();
            txtPassword.Focus();

            // Flash red background on password box
            txtPassword.BackColor = Color.FromArgb(255, 220, 220);
            var t = new System.Windows.Forms.Timer { Interval = 1200 };
            t.Tick += (s, _) => { txtPassword.BackColor = SystemColors.Window; t.Stop(); t.Dispose(); };
            t.Start();
        }

        // ────────────────────────────────────────────────────────────────────
        //  Role-based dashboard routing
        // ────────────────────────────────────────────────────────────────────
        private void OpenDashboard(string username, string role)
        {
            UserSession.Set(username, role);
            LoggedInUser = username;
            LoggedInRole = role;
            DialogResult = DialogResult.OK;
            Close();
        }

        // ────────────────────────────────────────────────────────────────────
        //  btnClear_Click
        // ────────────────────────────────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;

            lblAttemptsWarn.Text = string.Empty;
            txtPassword.BackColor = SystemColors.Window;
            txtUsername.BackColor = SystemColors.Window;

            txtUsername.Focus();
        }

        // ────────────────────────────────────────────────────────────────────
        //  Enter key → Login
        // ────────────────────────────────────────────────────────────────────
        private void InputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin_Click(sender, EventArgs.Empty);
            }
        }

        // ────────────────────────────────────────────────────────────────────
        //  UI helpers
        // ────────────────────────────────────────────────────────────────────
        private void ShowFieldError(string message, Control? focusControl)
        {
            lblAttemptsWarn.Text = $"⚠ {message}";
            focusControl?.Focus();
        }

        private void AttachButtonHoverEffects()
        {
            Color loginNormal = btnLogin.BackColor;
            Color loginHover = Color.FromArgb(20, 90, 170);
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = loginHover;
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = loginNormal;

            Color clearNormal = btnClear.BackColor;
            Color clearHover = Color.FromArgb(220, 223, 230);
            btnClear.MouseEnter += (s, e) => btnClear.BackColor = clearHover;
            btnClear.MouseLeave += (s, e) => btnClear.BackColor = clearNormal;
        }

        private static GraphicsPath RoundedRectPath(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
