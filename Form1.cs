using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Vehical_Rental_Management_System
{
    public partial class bookingForm : Form
    {
        private readonly string _connStr = DatabaseConnection.ConnectionString;
        private int _selectedCustomerId = -1;
        private int _selectedVehicleId  = -1;

        public bookingForm()
        {
            InitializeComponent();
            backToolStripMenuItem.Click += (s, e) => Close();
            refreshToolStripMenuItem.Click += (s, e) => LoadFormData();
            btnSave.Click += BtnSave_Click;
            btnClear.Click += (s, e) => ClearForm();
            cmbCustomer.SelectedIndexChanged += CmbCustomer_SelectedIndexChanged;
            cmbType.SelectedIndexChanged += (s, e) => LoadVehicles();
            cmbVehical.SelectedIndexChanged += CmbVehical_SelectedIndexChanged;
            dateTimeRental.ValueChanged += (s, e) => RecalculateTotal();
            dateTimeReturn.ValueChanged += (s, e) => RecalculateTotal();
            txtDailyRate.TextChanged += (s, e) => RecalculateTotal();
        }

        private void booking_Load(object sender, EventArgs e)
        {
            dateTimeRental.Value = DateTime.Today;
            dateTimeReturn.Value = DateTime.Today.AddDays(1);
            dateTimeReturn.MinDate = dateTimeRental.Value;
            LoadFormData();
        }

        private void btnSearch_Click(object sender, EventArgs e) => BtnSearch_Click(sender, e);

        private void LoadFormData()
        {
            LoadCustomers();
            LoadVehicleTypes();
            LoadVehicles();
            LoadActiveBookings();
        }

        private void LoadCustomers(string filter = "")
        {
            cmbCustomer.Items.Clear();
            _selectedCustomerId = -1;
            ClearCustomerPanel();

            try
            {
                using var conn = new MySqlConnection(_connStr);
                conn.Open();
                var sql = "SELECT CustomerID, FullName, NIC, Phone, LicenseNo FROM customers";
                if (!string.IsNullOrWhiteSpace(filter))
                    sql += " WHERE FullName LIKE @f OR NIC LIKE @f";
                sql += " ORDER BY FullName";

                using var cmd = new MySqlCommand(sql, conn);
                if (!string.IsNullOrWhiteSpace(filter))
                    cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCustomer.Items.Add(new IdTextItem(
                        rdr.GetInt32("CustomerID"),
                        rdr.GetString("FullName"),
                        rdr.GetString("NIC"),
                        rdr.GetString("Phone"),
                        rdr.GetString("LicenseNo")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load customers:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cmbCustomer.Items.Count > 0)
                cmbCustomer.SelectedIndex = 0;
        }

        private void LoadVehicleTypes()
        {
            cmbType.Items.Clear();
            try
            {
                using var conn = new MySqlConnection(_connStr);
                conn.Open();
                using var cmd = new MySqlCommand(
                    "SELECT DISTINCT Type FROM vehicle WHERE Status = 'Available' ORDER BY Type", conn);
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    cmbType.Items.Add(rdr.GetString("Type"));
            }
            catch { }

            cmbType.Items.Insert(0, "All Types");
            if (cmbType.Items.Count > 0)
                cmbType.SelectedIndex = 0;
        }

        private void LoadVehicles()
        {
            cmbVehical.Items.Clear();
            _selectedVehicleId = -1;
            ClearVehiclePanel();

            string? typeFilter = cmbType.SelectedItem?.ToString();
            if (typeFilter == "All Types")
                typeFilter = null;

            try
            {
                using var conn = new MySqlConnection(_connStr);
                conn.Open();
                var sql = @"SELECT ID, Brand, Model, Type, RegNo, DailyRate,
                                   ManufactureYear, Status
                            FROM vehicle WHERE Status = 'Available'";
                if (!string.IsNullOrEmpty(typeFilter))
                    sql += " AND Type = @type";
                sql += " ORDER BY Brand, Model";

                using var cmd = new MySqlCommand(sql, conn);
                if (!string.IsNullOrEmpty(typeFilter))
                    cmd.Parameters.AddWithValue("@type", typeFilter);

                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbVehical.Items.Add(new VehicleItem(
                        rdr.GetInt32("ID"),
                        rdr.GetString("Brand"),
                        rdr.GetString("Model"),
                        rdr.GetString("Type"),
                        rdr.GetString("RegNo"),
                        rdr.GetDecimal("DailyRate"),
                        rdr.GetInt32("ManufactureYear"),
                        rdr.GetString("Status")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load vehicles:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cmbVehical.Items.Count > 0)
                cmbVehical.SelectedIndex = 0;
        }

        private void LoadActiveBookings()
        {
            try
            {
                using var conn = new MySqlConnection(_connStr);
                conn.Open();
                var sql = @"SELECT r.RentalID, c.FullName AS Customer,
                                   CONCAT(v.Brand,' ',v.Model,' (',v.RegNo,')') AS Vehicle,
                                   r.StartDate, r.EndDate, r.TotalAmount, r.Status
                            FROM rentals r
                            JOIN customers c ON r.CustomerID = c.CustomerID
                            JOIN vehicle v ON r.VehicleID = v.ID
                            WHERE r.Status = 'Active'
                            ORDER BY r.StartDate DESC";

                using var da = new MySqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load active bookings:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string q = txtSearch.Text.Trim();
            if (q.Equals("Name or NIC...", StringComparison.OrdinalIgnoreCase))
                q = string.Empty;
            LoadCustomers(q);
        }

        private void CmbCustomer_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem is IdTextItem c)
            {
                _selectedCustomerId = c.Id;
                lblName.Text    = c.FullName;
                lblPhone.Text   = c.Phone;
                lblNIC.Text     = c.Nic;
                lblLicence.Text = c.License;
            }
        }

        private void CmbVehical_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbVehical.SelectedItem is VehicleItem v)
            {
                _selectedVehicleId = v.Id;
                lblStatus.Text = v.Status;
                lblType.Text   = v.Type;
                lblYear.Text   = v.Year.ToString();
                lblRate.Text   = "LKR " + v.DailyRate.ToString("F2");
                txtDailyRate.Text = v.DailyRate.ToString("F2");
                RecalculateTotal();
            }
        }

        private void RecalculateTotal()
        {
            if (dateTimeReturn.Value.Date < dateTimeRental.Value.Date)
                dateTimeReturn.Value = dateTimeRental.Value;

            int days = (dateTimeReturn.Value.Date - dateTimeRental.Value.Date).Days + 1;
            if (days < 1) days = 1;
            txtNo_Days.Text = days.ToString();

            if (decimal.TryParse(txtDailyRate.Text, out decimal rate))
                txtTotal.Text = (days * rate).ToString("F2");
            else
                txtTotal.Text = "0.00";
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (_selectedCustomerId <= 0)
            {
                MessageBox.Show("Please select a customer.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_selectedVehicleId <= 0)
            {
                MessageBox.Show("Please select an available vehicle.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtTotal.Text, out decimal total) || total <= 0)
            {
                MessageBox.Show("Total amount is invalid.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = new MySqlConnection(_connStr);
                conn.Open();
                using var tx = conn.BeginTransaction();

                using (var cmd = new MySqlCommand(@"
                    INSERT INTO rentals (CustomerID, VehicleID, StartDate, EndDate, TotalAmount, Status)
                    VALUES (@cid, @vid, @start, @end, @total, 'Active');", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@cid", _selectedCustomerId);
                    cmd.Parameters.AddWithValue("@vid", _selectedVehicleId);
                    cmd.Parameters.AddWithValue("@start", dateTimeRental.Value.Date);
                    cmd.Parameters.AddWithValue("@end", dateTimeReturn.Value.Date);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand(
                    "UPDATE vehicle SET Status = 'Rented' WHERE ID = @vid;", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@vid", _selectedVehicleId);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand(@"
                    UPDATE customers SET ActiveRentals = ActiveRentals + 1
                    WHERE CustomerID = @cid;", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@cid", _selectedCustomerId);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
                MessageBox.Show("Booking saved successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadFormData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save booking:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtSearch.Clear();
            txtNote.Clear();
            txtDailyRate.Clear();
            txtNo_Days.Clear();
            txtTotal.Clear();
            dateTimeRental.Value = DateTime.Today;
            dateTimeReturn.Value = DateTime.Today.AddDays(1);
            _selectedCustomerId = -1;
            _selectedVehicleId = -1;
            ClearCustomerPanel();
            ClearVehiclePanel();
        }

        private void ClearCustomerPanel()
        {
            lblName.Text = lblPhone.Text = lblNIC.Text = lblLicence.Text = "-";
        }

        private void ClearVehiclePanel()
        {
            lblStatus.Text = lblType.Text = lblYear.Text = lblRate.Text = "-";
        }

        private sealed class IdTextItem
        {
            public int Id { get; }
            public string FullName { get; }
            public string Nic { get; }
            public string Phone { get; }
            public string License { get; }

            public IdTextItem(int id, string name, string nic, string phone, string license)
            {
                Id = id; FullName = name; Nic = nic; Phone = phone; License = license;
            }

            public override string ToString() => FullName;
        }

        private sealed class VehicleItem
        {
            public int Id { get; }
            public string Brand { get; }
            public string Model { get; }
            public string Type { get; }
            public string RegNo { get; }
            public decimal DailyRate { get; }
            public int Year { get; }
            public string Status { get; }

            public VehicleItem(int id, string brand, string model, string type,
                string regNo, decimal rate, int year, string status)
            {
                Id = id; Brand = brand; Model = model; Type = type;
                RegNo = regNo; DailyRate = rate; Year = year; Status = status;
            }

            public override string ToString() => $"{Brand} {Model} ({RegNo})";
        }
    }
}
