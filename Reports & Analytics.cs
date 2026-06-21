using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Vehical_Rental_Management_System
{
    public partial class Form8 : Form
    {
        // Connection string for local XAMPP MySQL
        string connectionString = "Server=localhost;Database=vehicle_project;Uid=root;Pwd=;";

        public Form8()
        {
            InitializeComponent();
            
            // Wire up events manually to avoid touching the .Designer.cs file
            this.Load += Form8_Load;
            this.button1.Click += button1_Click; // Refresh Data
            this.button2.Click += button2_Click; // Export CSV
            this.button3.Click += button3_Click; // Apply Filter
            
            // Wire up menu items
            this.exportCSVToolStripMenuItem.Click += button2_Click;
            this.generateReportsToolStripMenuItem.Click += button1_Click;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "All Time", "This Year", "This Month" });
            comboBox1.SelectedIndex = 0;

            LoadAllReports();
        }

        private void LoadAllReports()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    // Automatically create the required tables if they don't exist
                    CreateTablesIfNotExist(con);

                    string dateFilter = GetDateFilter();

                    LoadKPIs(con, dateFilter);
                    LoadRevenueByCategory(con, dateFilter);
                    LoadTopCustomers(con, dateFilter);
                    LoadMonthlyTrend(con, dateFilter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reports: \n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateTablesIfNotExist(MySqlConnection con)
        {
            string createCustomerTable = @"
                CREATE TABLE IF NOT EXISTS customer (
                    ID INT AUTO_INCREMENT PRIMARY KEY,
                    Name VARCHAR(100) NOT NULL,
                    Contact VARCHAR(50) NOT NULL
                );";

            string createRentalTable = @"
                CREATE TABLE IF NOT EXISTS rental (
                    ID INT AUTO_INCREMENT PRIMARY KEY,
                    VehicleID INT NOT NULL,
                    CustomerID INT NOT NULL,
                    StartDate DATE NOT NULL,
                    EndDate DATE NOT NULL,
                    TotalAmount DECIMAL(10, 2) NOT NULL,
                    Status VARCHAR(50) NOT NULL,
                    FOREIGN KEY (VehicleID) REFERENCES vehicle(ID),
                    FOREIGN KEY (CustomerID) REFERENCES customer(ID)
                );";

            using (MySqlCommand cmd = new MySqlCommand(createCustomerTable, con))
            {
                cmd.ExecuteNonQuery();
            }

            using (MySqlCommand cmd = new MySqlCommand(createRentalTable, con))
            {
                cmd.ExecuteNonQuery();
            }

            // Insert sample data so the reports aren't empty
            InsertSampleDataIfEmpty(con);
        }

        private void InsertSampleDataIfEmpty(MySqlConnection con)
        {
            try
            {
                // Check if customers already exist
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM customer", con))
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) return; // Data already exists
                }

                // Insert Sample Customers
                string insertCustomers = @"
                    INSERT INTO customer (Name, Contact) VALUES 
                    ('Nimali Perera', '0771234567'),
                    ('Kasun Silva', '0719876543'),
                    ('Amila Fernando', '0755555555');";
                using (MySqlCommand cmd = new MySqlCommand(insertCustomers, con)) { cmd.ExecuteNonQuery(); }

                // Check if we have vehicles to link rentals to. If not, insert a dummy one.
                int vehicleId = 1;
                using (MySqlCommand cmd = new MySqlCommand("SELECT ID FROM vehicle LIMIT 1", con))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        vehicleId = Convert.ToInt32(result);
                    }
                    else
                    {
                        string insertVehicle = "INSERT INTO vehicle (`Brand`, `Model`, `Type`, `Reg. No`, `Daily Rate(LKR)`, `Manufacture Year`, `Status`) VALUES ('Toyota', 'Corolla', 'Car', 'CBA-1234', 5000, 2018, 'Available')";
                        using (MySqlCommand cmdV = new MySqlCommand(insertVehicle, con)) { cmdV.ExecuteNonQuery(); }
                        using (MySqlCommand cmdId = new MySqlCommand("SELECT LAST_INSERT_ID()", con)) { vehicleId = Convert.ToInt32(cmdId.ExecuteScalar()); }
                    }
                }

                // Get the generated Customer IDs
                int cust1 = 1, cust2 = 2;
                using (MySqlCommand cmd = new MySqlCommand("SELECT ID FROM customer LIMIT 2", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) cust1 = reader.GetInt32(0);
                        if (reader.Read()) cust2 = reader.GetInt32(0);
                    }
                }

                // Insert Sample Rentals (Mix of past and active)
                string insertRentals = $@"
                    INSERT INTO rental (VehicleID, CustomerID, StartDate, EndDate, TotalAmount, Status) VALUES 
                    ({vehicleId}, {cust1}, DATE_SUB(CURDATE(), INTERVAL 45 DAY), DATE_SUB(CURDATE(), INTERVAL 40 DAY), 25000, 'Completed'),
                    ({vehicleId}, {cust2}, DATE_SUB(CURDATE(), INTERVAL 20 DAY), DATE_SUB(CURDATE(), INTERVAL 15 DAY), 30000, 'Completed'),
                    ({vehicleId}, {cust1}, DATE_SUB(CURDATE(), INTERVAL 2 DAY), DATE_ADD(CURDATE(), INTERVAL 3 DAY), 25000, 'Active');";
                
                using (MySqlCommand cmd = new MySqlCommand(insertRentals, con)) { cmd.ExecuteNonQuery(); }
            }
            catch 
            { 
                // Silently ignore errors during dummy data insertion to not crash the main app
            }
        }

        private string GetDateFilter()
        {
            if (comboBox1.SelectedItem == null) return "";

            string selection = comboBox1.SelectedItem.ToString();
            if (selection == "This Year")
            {
                return " AND YEAR(StartDate) = YEAR(CURDATE()) ";
            }
            else if (selection == "This Month")
            {
                return " AND MONTH(StartDate) = MONTH(CURDATE()) AND YEAR(StartDate) = YEAR(CURDATE()) ";
            }
            return ""; // All Time
        }

        private void LoadKPIs(MySqlConnection con, string dateFilter)
        {
            // Total Revenue (label3)
            string q1 = $"SELECT IFNULL(SUM(TotalAmount), 0) FROM rental WHERE 1=1 {dateFilter}";
            using (MySqlCommand cmd = new MySqlCommand(q1, con))
            {
                decimal totalRev = Convert.ToDecimal(cmd.ExecuteScalar());
                label3.Text = $"LKR {totalRev:N2}";
            }

            // Active Rentals (label5)
            string q2 = "SELECT COUNT(*) FROM rental WHERE Status = 'Active'";
            using (MySqlCommand cmd = new MySqlCommand(q2, con))
            {
                int activeRentals = Convert.ToInt32(cmd.ExecuteScalar());
                label5.Text = activeRentals.ToString();
            }

            // Total Customers (label7)
            string q3 = "SELECT COUNT(*) FROM customer";
            using (MySqlCommand cmd = new MySqlCommand(q3, con))
            {
                int totalCustomers = Convert.ToInt32(cmd.ExecuteScalar());
                label7.Text = totalCustomers.ToString();
            }

            // Avg Rental Days (label9)
            string q4 = $"SELECT IFNULL(AVG(DATEDIFF(EndDate, StartDate)), 0) FROM rental WHERE 1=1 {dateFilter}";
            using (MySqlCommand cmd = new MySqlCommand(q4, con))
            {
                decimal avgDays = Convert.ToDecimal(cmd.ExecuteScalar());
                label9.Text = $"{avgDays:N1} Days";
            }
        }

        private void LoadRevenueByCategory(MySqlConnection con, string dateFilter)
        {
            string query = $@"
                SELECT v.Type as 'Vehicle Category', SUM(r.TotalAmount) as 'Total Revenue (LKR)'
                FROM rental r
                JOIN vehicle v ON r.VehicleID = v.ID
                WHERE 1=1 {dateFilter}
                GROUP BY v.Type
                ORDER BY SUM(r.TotalAmount) DESC";

            MySqlDataAdapter da = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void LoadTopCustomers(MySqlConnection con, string dateFilter)
        {
            string query = $@"
                SELECT c.Name as 'Customer Name', COUNT(r.ID) as 'Rentals Count', SUM(r.TotalAmount) as 'Total Spent (LKR)'
                FROM rental r
                JOIN customer c ON r.CustomerID = c.ID
                WHERE 1=1 {dateFilter}
                GROUP BY c.ID, c.Name
                ORDER BY SUM(r.TotalAmount) DESC
                LIMIT 10";

            MySqlDataAdapter da = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void LoadMonthlyTrend(MySqlConnection con, string dateFilter)
        {
            string query = $@"
                SELECT DATE_FORMAT(StartDate, '%Y-%m') as 'Month', COUNT(ID) as 'Total Rentals', SUM(TotalAmount) as 'Revenue (LKR)'
                FROM rental
                WHERE 1=1 {dateFilter}
                GROUP BY DATE_FORMAT(StartDate, '%Y-%m')
                ORDER BY DATE_FORMAT(StartDate, '%Y-%m') ASC";

            MySqlDataAdapter da = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAllReports(); // Refresh Data
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadAllReports(); // Apply Filter
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportToCSV(dataGridView1, "RevenueByCategory.csv");
            ExportToCSV(dataGridView2, "TopCustomers.csv");
            ExportToCSV(dataGridView3, "MonthlyTrend.csv");
            MessageBox.Show("Data successfully exported to CSV files in the application folder.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportToCSV(DataGridView dgv, string filename)
        {
            if (dgv.Rows.Count == 0) return;

            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    // Headers
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        sw.Write(dgv.Columns[i].HeaderText);
                        if (i < dgv.Columns.Count - 1) sw.Write(",");
                    }
                    sw.WriteLine();

                    // Data
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sw.Write(row.Cells[i].Value?.ToString().Replace(",", " "));
                            if (i < dgv.Columns.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export {filename}: {ex.Message}");
            }
        }
    }
}
