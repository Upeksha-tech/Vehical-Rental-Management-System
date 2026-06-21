using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Vehical_Rental_Management_System
{

    public partial class LoginForm : Form
    {

        private const string MySqlConnectionString = DatabaseConnection.ConnectionString;


        private static readonly string[,] MockUsers =
        {
            { "manager", "Mgr@2024",   "Manager" },
            { "staff",   "Staff@001",  "Staff"   }
        };


        private bool _useMockAuth = false;

        public string LoggedInUser { get; private set; } = string.Empty;
        public string LoggedInRole { get; private set; } = string.Empty;


        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;

            txtUsername.Focus();


            txtUsername.KeyDown += InputField_KeyDown;
            txtPassword.KeyDown += InputField_KeyDown;
            cmbRole.KeyDown += InputField_KeyDown;

            AttachButtonHoverEffects();
        }


        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var panel = (Panel)sender;
            var rect = new Rectangle(4, 4, panel.Width - 8, panel.Height - 8);
            int r = 16;

            g.SmoothingMode = SmoothingMode.AntiAlias;


            for (int i = 6; i >= 1; i--)
            {
                using var sb = new SolidBrush(Color.FromArgb(12 * i, 0, 0, 0));
                using var sp = RoundedRectPath(
                    new Rectangle(rect.X - i, rect.Y + i, rect.Width + i * 2, rect.Height + i * 2), r);
                g.FillPath(sb, sp);
            }


            using var cardBrush = new SolidBrush(Color.White);
            using var cardPath = RoundedRectPath(rect, r);
            g.FillPath(cardBrush, cardPath);

            using var borderPen = new Pen(Color.FromArgb(210, 210, 215), 1f);
            g.DrawPath(borderPen, cardPath);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString() ?? string.Empty;

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


            bool ok = _useMockAuth
                ? AuthenticateMock(username, password, role)
                : AuthenticateMySQL(username, password, role);

            if (ok) OnLoginSuccess(username, role);
            else OnLoginFailure();
        }



        private bool AuthenticateMySQL(string username, string password, string role)
        {
            try
            {
                using var conn = new MySqlConnection(MySqlConnectionString);
                conn.Open();


                const string sql =
                    "SELECT COUNT(1) FROM users " +
                    "WHERE username = @user " +
                    "  AND password = @pass " +
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
                    _useMockAuth = true;
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


        private bool AuthenticateMock(string username, string password, string role)
        {
            int rows = MockUsers.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                bool userMatch = string.Equals(MockUsers[i, 0], username, StringComparison.OrdinalIgnoreCase);
                bool passMatch = MockUsers[i, 1] == password;
                bool roleMatch = string.Equals(MockUsers[i, 2], role, StringComparison.OrdinalIgnoreCase);
                if (userMatch && passMatch && roleMatch) return true;
            }
            return false;
        }


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


            txtPassword.BackColor = Color.FromArgb(255, 220, 220);
            var t = new System.Windows.Forms.Timer { Interval = 1200 };
            t.Tick += (s, _) => { txtPassword.BackColor = SystemColors.Window; t.Stop(); t.Dispose(); };
            t.Start();
        }


        private void OpenDashboard(string username, string role)
        {
            UserSession.Set(username, role);
            LoggedInUser = username;
            LoggedInRole = role;
            DialogResult = DialogResult.OK;
            Close();
        }


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


        private void InputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin_Click(sender, EventArgs.Empty);
            }
        }


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
