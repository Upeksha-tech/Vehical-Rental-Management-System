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
        string connectionString = DatabaseConnection.ConnectionString;

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
            string q1 = $"SELECT IFNULL(SUM(TotalAmount), 0) FROM rentals WHERE 1=1 {dateFilter}";
            using (MySqlCommand cmd = new MySqlCommand(q1, con))
            {
                decimal totalRev = Convert.ToDecimal(cmd.ExecuteScalar());
                label3.Text = $"LKR {totalRev:N2}";
            }

            // Active Rentals (label5)
            string q2 = "SELECT COUNT(*) FROM rentals WHERE Status = 'Active'";
            using (MySqlCommand cmd = new MySqlCommand(q2, con))
            {
                int activeRentals = Convert.ToInt32(cmd.ExecuteScalar());
                label5.Text = activeRentals.ToString();
            }

            // Total Customers (label7)
            string q3 = "SELECT COUNT(*) FROM customers";
            using (MySqlCommand cmd = new MySqlCommand(q3, con))
            {
                int totalCustomers = Convert.ToInt32(cmd.ExecuteScalar());
                label7.Text = totalCustomers.ToString();
            }

            // Avg Rental Days (label9)
            string q4 = $"SELECT IFNULL(AVG(DATEDIFF(EndDate, StartDate)), 0) FROM rentals WHERE 1=1 {dateFilter}";
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
                FROM rentals r
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
                SELECT c.FullName as 'Customer Name', COUNT(r.RentalID) as 'Rentals Count', SUM(r.TotalAmount) as 'Total Spent (LKR)'
                FROM rentals r
                JOIN customers c ON r.CustomerID = c.CustomerID
                WHERE 1=1 {dateFilter}
                GROUP BY c.CustomerID, c.FullName
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
                SELECT DATE_FORMAT(StartDate, '%Y-%m') as 'Month', COUNT(RentalID) as 'Total Rentals', SUM(TotalAmount) as 'Revenue (LKR)'
                FROM rentals
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
