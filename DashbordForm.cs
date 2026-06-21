using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Vehical_Rental_Management_System
{

    public partial class Form2 : Form
    {
        private readonly string _loggedInUser;
        private readonly string _loggedInRole;

        public Form2(string username, string role)
        {
            InitializeComponent();

            _loggedInUser = username;
            _loggedInRole = role;
        }

        public Form2() : this("Guest", "Staff") { }

        private void Form2_Load(object sender, EventArgs e)
        {
            Text = $"Vehicle Rental Management System  –  {_loggedInUser} ({_loggedInRole})";

            button9.Click += BtnLogout_Click;

            button1.Click += (s, ev) => { };
            button2.Click += BtnVehicles_Click;
            button3.Click += BtnCustomers_Click;
            button4.Click += BtnRentalBooking_Click;
            button5.Click += BtnReturnVehicle_Click;
            button6.Click += BtnPayments_Click;
            button7.Click += BtnReports_Click;

            reportsToolStripMenuItem.Click += BtnReports_Click;
            adminToolStripMenuItem.Visible = false;
            modulesToolStripMenuItem.Click += BtnShowModulesMenu;


            ApplyRolePermissions();

            LoadDashboardData();
        }

        private void OpenChildForm(Form childForm, AppModule module)
        {
            if (!AccessControl.CanOpen(module))
            {
                AccessControl.ShowDenied(module);
                return;
            }

            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Load += (_, __) => AccessControl.ApplyModulePermissions(childForm, module);

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

        private void BtnVehicles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form3(), AppModule.Vehicles);
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCustomer(), AppModule.Customers);
        }

        private void BtnRentalBooking_Click(object sender, EventArgs e)
        {
            OpenChildForm(new bookingForm(), AppModule.Booking);
        }

        private void BtnReturnVehicle_Click(object sender, EventArgs e)
        {
            OpenChildForm(new returnForm(), AppModule.Return);
        }

        private void BtnPayments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPayment(), AppModule.Payments);
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form8(), AppModule.Reports);
        }


        private void BtnShowModulesMenu(object sender, EventArgs e)
        {
            var menu = new ContextMenuStrip();
            AddModuleMenuItem(menu, "🚗 Vehicles", AppModule.Vehicles, BtnVehicles_Click);
            AddModuleMenuItem(menu, "👤 Customers", AppModule.Customers, BtnCustomers_Click);
            AddModuleMenuItem(menu, "📋 Rental Booking", AppModule.Booking, BtnRentalBooking_Click);
            AddModuleMenuItem(menu, "🔄 Return Vehicle", AppModule.Return, BtnReturnVehicle_Click);
            AddModuleMenuItem(menu, "💳 Payments", AppModule.Payments, BtnPayments_Click);
            menu.Show(menuStrip1, new System.Drawing.Point(0, menuStrip1.Height));
        }

        private static void AddModuleMenuItem(
            ContextMenuStrip menu, string text, AppModule module, EventHandler handler)
        {
            if (!AccessControl.CanOpen(module))
                return;
            menu.Items.Add(text, null, handler);
        }

        private void LoadDashboardData()
        {
            try
            {
                using var conn = new MySqlConnection(DatabaseConnection.ConnectionString);
                conn.Open();

                label3.Text = ScalarInt(conn, "SELECT COUNT(*) FROM vehicle").ToString();
                label6.Text = ScalarInt(conn, "SELECT COUNT(*) FROM vehicle WHERE Status = 'Available'").ToString();
                label8.Text = ScalarInt(conn, "SELECT COUNT(*) FROM vehicle WHERE Status = 'Rented'").ToString();
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
            }
        }

        private static int ScalarInt(MySqlConnection conn, string sql)
        {
            using var cmd = new MySqlCommand(sql, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                $"Are you sure you want to logout, {_loggedInUser}?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserSession.Clear();
                DialogResult = DialogResult.Retry;
                Close();
            }
        }

        private void ApplyRolePermissions()
        {
            button2.Visible = AccessControl.CanOpen(AppModule.Vehicles);
            button3.Visible = AccessControl.CanOpen(AppModule.Customers);
            button4.Visible = AccessControl.CanOpen(AppModule.Booking);
            button5.Visible = AccessControl.CanOpen(AppModule.Return);
            button6.Visible = AccessControl.CanOpen(AppModule.Payments);
            button7.Visible = AccessControl.CanOpen(AppModule.Reports);
            button8.Visible = false;

            reportsToolStripMenuItem.Visible = AccessControl.CanOpen(AppModule.Reports);
            adminToolStripMenuItem.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}