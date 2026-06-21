using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Vehical_Rental_Management_System
{

    public partial class frmCustomer : Form
    {

        private readonly string _connStr = DatabaseConnection.ConnectionString;


        private bool _isDbAvailable = false;
        private int  _selectedCustomerID = -1;
        private Label _lblDbStatus = null!;


        private readonly List<Customer> _offlineList = new();


        public frmCustomer()
        {
            InitializeComponent();
            WireEvents();
            SeedOfflineData();
        }


        private void WireEvents()
        {
            btnEdit.Click   += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSearch.Click += btnSearch_Click;

            backToolStripMenuItem.Click    += (s, e) => this.Close();
            refreshToolStripMenuItem.Click += (s, e) => { TryConnectDb(); LoadGrid(); };
            exportToolStripMenuItem.Click  += ExportToCsv;

            dgvCustomer.SelectionChanged  += DgvCustomer_SelectionChanged;
            txtSearch.KeyDown             += (s, e) =>
                { if (e.KeyCode == Keys.Enter) LoadGrid(txtSearch.Text.Trim()); };


            _lblDbStatus = new Label
            {
                AutoSize = true,
                Anchor   = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(ClientSize.Width - 210, ClientSize.Height - 28),
                Font     = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text     = "Connecting…"
            };
            Controls.Add(_lblDbStatus);
            _lblDbStatus.BringToFront();
        }


        private void frmCustomer_Load(object sender, EventArgs e)
        {
            StyleGrid();
            TryConnectDb();
            LoadGrid();
            SetFormReadOnly(true);
        }


        private void TryConnectDb()
        {
            try
            {

                using var rootConn = new MySqlConnection("server=localhost;uid=root;pwd=;");
                rootConn.Open();
                new MySqlCommand("CREATE DATABASE IF NOT EXISTS VehicleRentalDB;", rootConn)
                    .ExecuteNonQuery();


                using var conn = new MySqlConnection(_connStr);
                conn.Open();
                new MySqlCommand(@"
                    CREATE TABLE IF NOT EXISTS customers (
                        CustomerID     INT AUTO_INCREMENT PRIMARY KEY,
                        FullName       VARCHAR(255) NOT NULL,
                        NIC            VARCHAR(20)  NOT NULL UNIQUE,
                        Phone          VARCHAR(20)  NOT NULL,
                        LicenseNo      VARCHAR(50)  NOT NULL,
                        Address        TEXT         NOT NULL,
                        DateRegistered DATE         NOT NULL,
                        ActiveRentals  INT          NOT NULL DEFAULT 0
                    );", conn).ExecuteNonQuery();

                _isDbAvailable = true;
                _lblDbStatus.Text      = "🟢 Database Active";
                _lblDbStatus.ForeColor = Color.Green;
            }
            catch
            {
                _isDbAvailable = false;
                _lblDbStatus.Text      = "🟠 Offline / Demo Mode";
                _lblDbStatus.ForeColor = Color.OrangeRed;
            }
        }


        private void LoadGrid(string filter = "")
        {
            dgvCustomer.SelectionChanged -= DgvCustomer_SelectionChanged;

            var dt = BuildEmptyTable();

            if (_isDbAvailable)
            {
                try
                {
                    using var conn = new MySqlConnection(_connStr);
                    conn.Open();
                    var sql = @"SELECT CustomerID, FullName, NIC, Phone, LicenseNo,
                                       Address, DateRegistered, ActiveRentals
                                FROM customers";
                    if (!string.IsNullOrEmpty(filter))
                        sql += " WHERE FullName LIKE @f OR NIC LIKE @f";

                    using var cmd = new MySqlCommand(sql, conn);
                    if (!string.IsNullOrEmpty(filter))
                        cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                    using var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        dt.Rows.Add(
                            rdr.GetInt32("CustomerID"),
                            rdr.GetString("FullName"),
                            rdr.GetString("NIC"),
                            rdr.GetString("Phone"),
                            rdr.GetString("LicenseNo"),
                            rdr.GetString("Address"),
                            rdr.GetDateTime("DateRegistered").ToString("yyyy-MM-dd"),
                            rdr.GetInt32("ActiveRentals"));
                }
                catch (Exception ex)
                {
                    ShowError("Load failed: " + ex.Message);
                    _isDbAvailable = false;
                    _lblDbStatus.Text      = "🟠 Offline / Demo Mode";
                    _lblDbStatus.ForeColor = Color.OrangeRed;
                }
            }

            if (!_isDbAvailable)
            {
                foreach (var c in _offlineList)
                {
                    if (string.IsNullOrEmpty(filter) ||
                        c.FullName.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                        c.NIC.Contains(filter, StringComparison.OrdinalIgnoreCase))
                    {
                        dt.Rows.Add(c.CustomerID, c.FullName, c.NIC, c.Phone,
                            c.LicenseNo, c.Address,
                            c.DateRegistered.ToString("yyyy-MM-dd"), c.ActiveRentals);
                    }
                }
            }

            dgvCustomer.DataSource = dt;
            ApplyColumnHeaders();
            dgvCustomer.SelectionChanged += DgvCustomer_SelectionChanged;

            if (dgvCustomer.Rows.Count > 0)
            {
                dgvCustomer.ClearSelection();
                dgvCustomer.Rows[0].Selected = true;
                PopulateForm(dgvCustomer.Rows[0]);
            }
            else
            {
                ClearForm();
            }
        }


        private void btnAdd_Click(object? sender, EventArgs e)
        {
            _selectedCustomerID = -1;
            ClearForm();
            txtRegistered.Text = DateTime.Today.ToString("yyyy-MM-dd");


            int nextId = GetNextCustomerID();
            lblfillActive.Text = $"New — ID will be: {nextId}";
            lblfillActive.ForeColor = Color.Gray;

            SetFormReadOnly(false);
            txtFullName.Focus();
        }


        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedCustomerID < 0)
            {
                ShowInfo("Please select a customer row to edit.");
                return;
            }
            SetFormReadOnly(false);
            txtFullName.Focus();
        }


        private void btnSave_Click(object? sender, EventArgs e)
        {

            if (!ValidateInputs()) return;

            DateTime regDate;
            if (!DateTime.TryParse(txtRegistered.Text.Trim(), out regDate))
                regDate = DateTime.Today;

            if (_selectedCustomerID == -1)
                InsertCustomer(regDate);
            else
                UpdateCustomer(regDate);
        }

        private void InsertCustomer(DateTime regDate)
        {

            if (NicExists(txtNIC.Text.Trim()))
            {
                ShowWarning("A customer with this NIC already exists. Please verify the NIC number.");
                txtNIC.Focus();
                return;
            }

            if (_isDbAvailable)
            {
                try
                {
                    using var conn = new MySqlConnection(_connStr);
                    conn.Open();
                    using var cmd = new MySqlCommand(@"
                        INSERT INTO customers
                            (FullName, NIC, Phone, LicenseNo, Address, DateRegistered, ActiveRentals)
                        VALUES
                            (@fn, @nic, @ph, @lic, @addr, @dr, 0);", conn);
                    cmd.Parameters.AddWithValue("@fn",   txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@nic",  txtNIC.Text.Trim());
                    cmd.Parameters.AddWithValue("@ph",   txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@lic",  txtLicense.Text.Trim());
                    cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@dr",   regDate.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();
                    ShowSuccess("Customer added successfully.");
                }
                catch (Exception ex) { ShowError("Insert failed: " + ex.Message); return; }
            }
            else
            {
                int newId = _offlineList.Count > 0
                    ? _offlineList[^1].CustomerID + 1 : 1;
                _offlineList.Add(new Customer
                {
                    CustomerID     = newId,
                    FullName       = txtFullName.Text.Trim(),
                    NIC            = txtNIC.Text.Trim(),
                    Phone          = txtPhone.Text.Trim(),
                    LicenseNo      = txtLicense.Text.Trim(),
                    Address        = txtAddress.Text.Trim(),
                    DateRegistered = regDate,
                    ActiveRentals  = 0
                });
                ShowSuccess("Customer added (offline demo).");
            }

            SetFormReadOnly(true);
            LoadGrid();
        }

        private void UpdateCustomer(DateTime regDate)
        {
            if (_isDbAvailable)
            {
                try
                {
                    using var conn = new MySqlConnection(_connStr);
                    conn.Open();
                    using var cmd = new MySqlCommand(@"
                        UPDATE customers SET
                            FullName       = @fn,
                            NIC            = @nic,
                            Phone          = @ph,
                            LicenseNo      = @lic,
                            Address        = @addr,
                            DateRegistered = @dr
                        WHERE CustomerID = @id;", conn);
                    cmd.Parameters.AddWithValue("@fn",   txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@nic",  txtNIC.Text.Trim());
                    cmd.Parameters.AddWithValue("@ph",   txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@lic",  txtLicense.Text.Trim());
                    cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@dr",   regDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@id",   _selectedCustomerID);
                    cmd.ExecuteNonQuery();
                    ShowSuccess("Customer updated successfully.");
                }
                catch (Exception ex) { ShowError("Update failed: " + ex.Message); return; }
            }
            else
            {
                var c = _offlineList.Find(x => x.CustomerID == _selectedCustomerID);
                if (c != null)
                {
                    c.FullName       = txtFullName.Text.Trim();
                    c.NIC            = txtNIC.Text.Trim();
                    c.Phone          = txtPhone.Text.Trim();
                    c.LicenseNo      = txtLicense.Text.Trim();
                    c.Address        = txtAddress.Text.Trim();
                    c.DateRegistered = regDate;
                }
                ShowSuccess("Customer updated (offline demo).");
            }

            SetFormReadOnly(true);
            LoadGrid();
        }


        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedCustomerID < 0)
            {
                ShowInfo("Please select a customer to delete.");
                return;
            }


            int activeCount = GetActiveRentalCount(_selectedCustomerID);
            if (activeCount > 0)
            {
                ShowWarning($"Cannot delete: this customer has {activeCount} active rental(s).\n" +
                            "Please close all rentals before deleting.");
                return;
            }

            if (MessageBox.Show(
                    "Permanently delete this customer record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (_isDbAvailable)
            {
                try
                {
                    using var conn = new MySqlConnection(_connStr);
                    conn.Open();
                    using var cmd = new MySqlCommand(
                        "DELETE FROM customers WHERE CustomerID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", _selectedCustomerID);
                    cmd.ExecuteNonQuery();
                    ShowSuccess("Customer deleted.");
                }
                catch (Exception ex) { ShowError("Delete failed: " + ex.Message); return; }
            }
            else
            {
                _offlineList.RemoveAll(c => c.CustomerID == _selectedCustomerID);
                ShowSuccess("Customer deleted (offline demo).");
            }

            _selectedCustomerID = -1;
            LoadGrid();
        }


        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadGrid(txtSearch.Text.Trim());
        }


        private void dgvCustomer_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PopulateForm(dgvCustomer.Rows[e.RowIndex]);
        }

        private void DgvCustomer_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
                PopulateForm(dgvCustomer.SelectedRows[0]);
        }

        private void PopulateForm(DataGridViewRow row)
        {
            _selectedCustomerID = Convert.ToInt32(row.Cells["CustomerID"].Value);
            txtFullName.Text   = row.Cells["FullName"].Value?.ToString() ?? "";
            txtNIC.Text        = row.Cells["NIC"].Value?.ToString() ?? "";
            txtPhone.Text      = row.Cells["Phone"].Value?.ToString() ?? "";
            txtLicense.Text    = row.Cells["LicenseNo"].Value?.ToString() ?? "";
            txtAddress.Text    = row.Cells["Address"].Value?.ToString() ?? "";
            txtRegistered.Text = row.Cells["DateRegistered"].Value?.ToString() ?? "";

            int active = Convert.ToInt32(row.Cells["ActiveRentals"].Value);
            lblfillActive.Text      = active == 0 ? "0 active rental"
                                                  : $"{active} active rental" + (active == 1 ? "" : "s");
            lblfillActive.ForeColor = active > 0 ? Color.Red : Color.FromArgb(33, 37, 41);
        }


        private void ExportToCsv(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter   = "CSV Files (*.csv)|*.csv",
                FileName = $"Customers_{DateTime.Today:yyyyMMdd}.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("CustomerID,FullName,NIC,Phone,LicenseNo,Address,DateRegistered,ActiveRentals");

                if (dgvCustomer.DataSource is DataTable dt)
                    foreach (DataRow r in dt.Rows)
                        sb.AppendLine(
                            $"\"{r["CustomerID"]}\",\"{r["FullName"]}\",\"{r["NIC"]}\"," +
                            $"\"{r["Phone"]}\",\"{r["LicenseNo"]}\",\"{r["Address"]}\"," +
                            $"\"{r["DateRegistered"]}\",\"{r["ActiveRentals"]}\"");

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                ShowSuccess("Exported to:\n" + sfd.FileName);
            }
            catch (Exception ex) { ShowError("Export failed: " + ex.Message); }
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            { ShowWarning("Full Name is required."); txtFullName.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtNIC.Text))
            { ShowWarning("NIC Number is required."); txtNIC.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            { ShowWarning("Phone Number is required."); txtPhone.Focus(); return false; }

            if (!IsNumeric(txtPhone.Text.Trim()))
            { ShowWarning("Phone must contain digits only (e.g. 0771234567)."); txtPhone.Focus(); return false; }

            if (txtPhone.Text.Trim().Length < 9)
            { ShowWarning("Phone number must be at least 9 digits."); txtPhone.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtLicense.Text))
            { ShowWarning("License Number is required."); txtLicense.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            { ShowWarning("Address is required."); txtAddress.Focus(); return false; }

            return true;
        }

        private static bool IsNumeric(string s)
        {
            foreach (char c in s)
                if (!char.IsDigit(c)) return false;
            return s.Length > 0;
        }


        private bool NicExists(string nic)
        {
            if (_isDbAvailable)
            {
                try
                {
                    using var conn = new MySqlConnection(_connStr);
                    conn.Open();
                    using var cmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM customers WHERE NIC = @nic AND CustomerID <> @id;", conn);
                    cmd.Parameters.AddWithValue("@nic", nic);
                    cmd.Parameters.AddWithValue("@id",  _selectedCustomerID < 0 ? 0 : _selectedCustomerID);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
                catch { return false; }
            }

            return _offlineList.Exists(c =>
                c.NIC == nic && c.CustomerID != _selectedCustomerID);
        }

        private int GetActiveRentalCount(int customerId)
        {
            if (_isDbAvailable)
            {
                try
                {
                    using var conn = new MySqlConnection(_connStr);
                    conn.Open();

                    using var cmd = new MySqlCommand(
                        "SELECT ActiveRentals FROM customers WHERE CustomerID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", customerId);
                    var result = cmd.ExecuteScalar();
                    return result == null ? 0 : Convert.ToInt32(result);
                }
                catch { return 0; }
            }
            return _offlineList.Find(c => c.CustomerID == customerId)?.ActiveRentals ?? 0;
        }

        private int GetNextCustomerID()
        {
            if (_isDbAvailable)
            {
                try
                {
                    using var conn = new MySqlConnection(_connStr);
                    conn.Open();
                    using var cmd = new MySqlCommand(
                        "SELECT IFNULL(MAX(CustomerID),0)+1 FROM customers;", conn);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch { return _offlineList.Count + 1; }
            }
            return _offlineList.Count + 1;
        }


        private void StyleGrid()
        {
            dgvCustomer.BorderStyle = BorderStyle.None;
            dgvCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomer.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 252);
            dgvCustomer.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvCustomer.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 40, 130);
            dgvCustomer.DefaultCellStyle.BackColor  = Color.White;
            dgvCustomer.DefaultCellStyle.ForeColor  = Color.FromArgb(33, 37, 41);
            dgvCustomer.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvCustomer.RowHeadersVisible     = false;
            dgvCustomer.EnableHeadersVisualStyles = false;
            dgvCustomer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCustomer.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 54, 80);
            dgvCustomer.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvCustomer.ColumnHeadersHeight   = 42;
            dgvCustomer.RowTemplate.Height    = 36;
            dgvCustomer.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.AllowUserToResizeRows  = false;
        }

        private void ApplyColumnHeaders()
        {
            void Rename(string col, string header)
            {
                if (dgvCustomer.Columns[col] is DataGridViewColumn c)
                    c.HeaderText = header;
            }
            if (dgvCustomer.Columns["CustomerID"] is DataGridViewColumn idCol)
                idCol.Visible = false;
            Rename("FullName",       "Full Name");
            Rename("NIC",            "NIC Number");
            Rename("Phone",          "Phone");
            Rename("LicenseNo",      "License No");
            Rename("Address",        "Address");
            Rename("DateRegistered", "Date Registered");
            Rename("ActiveRentals",  "Active Rentals");
        }


        private void SetFormReadOnly(bool readOnly)
        {
            txtFullName.ReadOnly   = readOnly;
            txtNIC.ReadOnly        = readOnly;
            txtPhone.ReadOnly      = readOnly;
            txtLicense.ReadOnly    = readOnly;
            txtAddress.ReadOnly    = readOnly;
            txtRegistered.ReadOnly = readOnly;

            Color bg = readOnly ? Color.FromArgb(240, 242, 245) : Color.White;
            txtFullName.BackColor   = bg;
            txtNIC.BackColor        = bg;
            txtPhone.BackColor      = bg;
            txtLicense.BackColor    = bg;
            txtAddress.BackColor    = bg;
            txtRegistered.BackColor = bg;

            btnSave.Enabled = !readOnly;
        }


        private void ClearForm()
        {
            txtFullName.Clear();
            txtNIC.Clear();
            txtPhone.Clear();
            txtLicense.Clear();
            txtAddress.Clear();
            txtRegistered.Clear();
            lblfillActive.Text      = "0 active rental";
            lblfillActive.ForeColor = Color.FromArgb(33, 37, 41);
        }


        private static DataTable BuildEmptyTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("CustomerID",     typeof(int));
            dt.Columns.Add("FullName",       typeof(string));
            dt.Columns.Add("NIC",            typeof(string));
            dt.Columns.Add("Phone",          typeof(string));
            dt.Columns.Add("LicenseNo",      typeof(string));
            dt.Columns.Add("Address",        typeof(string));
            dt.Columns.Add("DateRegistered", typeof(string));
            dt.Columns.Add("ActiveRentals",  typeof(int));
            return dt;
        }


        private static void ShowSuccess(string msg) =>
            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private static void ShowWarning(string msg) =>
            MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private static void ShowError(string msg) =>
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private static void ShowInfo(string msg) =>
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


        private void SeedOfflineData()
        {
            _offlineList.AddRange(new[]
            {
                new Customer { CustomerID=1, FullName="Anura Perera",      NIC="921543876V",   Phone="0771234567", LicenseNo="B9215438", Address="124 Galle Rd, Colombo 03",  DateRegistered=DateTime.Today.AddMonths(-10), ActiveRentals=0 },
                new Customer { CustomerID=2, FullName="Nimal Fernando",    NIC="199528741369", Phone="0719876543", LicenseNo="B1995287", Address="45 Lake Dr, Kandy",          DateRegistered=DateTime.Today.AddMonths(-4),  ActiveRentals=1 },
                new Customer { CustomerID=3, FullName="Priyanthi De Silva",NIC="886741258V",   Phone="0751112223", LicenseNo="B8867412", Address="88/A Temple Rd, Negombo",    DateRegistered=DateTime.Today.AddDays(-25),   ActiveRentals=0 },
            });
        }
    }
}
