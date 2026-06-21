using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Vehical_Rental_Management_System
{
    public partial class returnForm : Form
    {
        private readonly string _connStr = DatabaseConnection.ConnectionString;

        private int     _rentalId    = -1;
        private int     _customerId  = -1;
        private int     _vehicleId   = -1;
        private decimal _dailyRate;
        private bool    _paymentCompleted;

        public returnForm()
        {
            InitializeComponent();
            returnToolStripMenuItem.Click += (s, e) => Close();
            refreshToolStripMenuItem.Click += (s, e) => LoadActiveRentals();
            btnSearch.Click += BtnSearch_Click;
            bthShowAll.Click += (s, e) => { txtSearch.Clear(); LoadActiveRentals(); };
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dateTimeReturn.ValueChanged += (s, e) => RecalculateCharges();
            btnPay.Click += BtnPay_Click;
            btnClear.Click += (s, e) => ClearDetails();
            btnReturn.Click += BtnReturn_Click;
            Load += ReturnForm_Load;
        }

        private void ReturnForm_Load(object? sender, EventArgs e)
        {
            dateTimeReturn.Value = DateTime.Today;
            btnReturn.Enabled = false;
            LoadActiveRentals();
        }

        private void LoadActiveRentals(string filter = "")
        {
            try
            {
                using var conn = new MySqlConnection(_connStr);
                conn.Open();
                var sql = @"SELECT r.RentalID, c.FullName AS Customer,
                                   CONCAT(v.Brand,' ',v.Model) AS Vehicle,
                                   v.RegNo, r.StartDate, r.EndDate,
                                   v.DailyRate,
                                   r.CustomerID, r.VehicleID
                            FROM rentals r
                            JOIN customers c ON r.CustomerID = c.CustomerID
                            JOIN vehicle v ON r.VehicleID = v.ID
                            WHERE r.Status = 'Active'";

                if (!string.IsNullOrWhiteSpace(filter))
                    sql += " AND (CAST(r.RentalID AS CHAR) LIKE @f OR c.FullName LIKE @f OR v.RegNo LIKE @f)";

                sql += " ORDER BY r.StartDate DESC";

                using var cmd = new MySqlCommand(sql, conn);
                if (!string.IsNullOrWhiteSpace(filter))
                    cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                using var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                HideGridColumn("CustomerID");
                HideGridColumn("VehicleID");
                HideGridColumn("DailyRate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load active rentals:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideGridColumn(string name)
        {
            if (dataGridView1.Columns.Contains(name))
                dataGridView1.Columns[name].Visible = false;
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadActiveRentals(txtSearch.Text.Trim());
        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not DataRowView row)
                return;

            _paymentCompleted = false;
            btnReturn.Enabled = false;
            btnPay.Enabled = true;

            _rentalId   = Convert.ToInt32(row["RentalID"]);
            _customerId = Convert.ToInt32(row["CustomerID"]);
            _vehicleId  = Convert.ToInt32(row["VehicleID"]);
            _dailyRate  = Convert.ToDecimal(row["DailyRate"]);

            txtRentalID.Text = _rentalId.ToString();
            textBox2.Text    = row["Customer"].ToString() ?? "";
            txtNo_Days.Text  = $"{row["Vehicle"]} ({row["RegNo"]})";

            dateTimeRental.Value   = Convert.ToDateTime(row["StartDate"]);
            dateTimeExpected.Value = Convert.ToDateTime(row["EndDate"]);
            dateTimeReturn.Value   = DateTime.Today;
            if (dateTimeReturn.Value < dateTimeRental.Value)
                dateTimeReturn.Value = dateTimeRental.Value;

            txtRate.Text        = _dailyRate.ToString("F2");
            RecalculateCharges();
        }

        private void RecalculateCharges()
        {
            if (_rentalId <= 0)
                return;

            int daysRented = (dateTimeReturn.Value.Date - dateTimeRental.Value.Date).Days + 1;
            if (daysRented < 1) daysRented = 1;

            int overdueDays = (dateTimeReturn.Value.Date - dateTimeExpected.Value.Date).Days;
            if (overdueDays < 0) overdueDays = 0;

            decimal baseCharge  = daysRented * _dailyRate;
            decimal latePenalty = overdueDays * _dailyRate;
            decimal totalDue    = baseCharge + latePenalty;

            textBox1.Text         = daysRented.ToString();
            txtBaseCharge.Text    = baseCharge.ToString("F2");
            txtOverdueDates.Text  = overdueDays.ToString();
            txtPenaltyFee.Text    = latePenalty.ToString("F2");
            txtTotalFee.Text      = totalDue.ToString("F2");
        }

        private void BtnPay_Click(object? sender, EventArgs e)
        {
            if (_rentalId <= 0)
            {
                MessageBox.Show("Select an active rental first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RecalculateCharges();

            var request = new PaymentRequest
            {
                RentalID    = _rentalId,
                Customer    = textBox2.Text.Trim(),
                Vehicle     = txtNo_Days.Text.Trim(),
                Period      = $"{dateTimeRental.Value:yyyy-MM-dd} → {dateTimeReturn.Value:yyyy-MM-dd}",
                BaseAmount  = ParseDecimal(txtBaseCharge.Text),
                OverdueDays = ParseInt(txtOverdueDates.Text),
                PenaltyRate = _dailyRate,
                LatePenalty = ParseDecimal(txtPenaltyFee.Text),
                TotalDue    = ParseDecimal(txtTotalFee.Text),
                Discount    = 0,
                FinalAmount = ParseDecimal(txtTotalFee.Text)
            };

            using var payForm = new frmPayment();
            payForm.LoadFromReturn(request);
            if (payForm.ShowDialog(this) == DialogResult.OK && payForm.PaymentCompleted)
            {
                _paymentCompleted = true;
                btnReturn.Enabled = true;
                btnPay.Enabled    = false;
                MessageBox.Show(
                    "Payment completed. You can now confirm the return.",
                    "Payment Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void BtnReturn_Click(object? sender, EventArgs e)
        {
            if (_rentalId <= 0)
            {
                MessageBox.Show("Select an active rental first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_paymentCompleted)
            {
                MessageBox.Show(
                    "Payment must be completed before confirming the return.\n" +
                    "Click \"Proceed to Payment\" first.",
                    "Payment Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal finalTotal = ParseDecimal(txtTotalFee.Text);

            try
            {
                using var conn = new MySqlConnection(_connStr);
                conn.Open();
                using var tx = conn.BeginTransaction();

                using (var cmd = new MySqlCommand(@"
                    UPDATE rentals
                    SET Status = 'Completed',
                        EndDate = @actual,
                        TotalAmount = @total
                    WHERE RentalID = @id;", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@actual", dateTimeReturn.Value.Date);
                    cmd.Parameters.AddWithValue("@total", finalTotal);
                    cmd.Parameters.AddWithValue("@id", _rentalId);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand(
                    "UPDATE vehicle SET Status = 'Available' WHERE ID = @vid;", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@vid", _vehicleId);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand(@"
                    UPDATE customers
                    SET ActiveRentals = GREATEST(ActiveRentals - 1, 0)
                    WHERE CustomerID = @cid;", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@cid", _customerId);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
                MessageBox.Show("Vehicle return confirmed successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDetails();
                LoadActiveRentals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not confirm return:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDetails()
        {
            _rentalId = _customerId = _vehicleId = -1;
            _dailyRate = 0;
            _paymentCompleted = false;
            btnReturn.Enabled = false;
            btnPay.Enabled = true;

            txtRentalID.Clear();
            textBox2.Clear();
            txtNo_Days.Clear();
            textBox1.Clear();
            txtRate.Clear();
            txtBaseCharge.Clear();
            txtOverdueDates.Clear();
            txtPenaltyFee.Clear();
            txtTotalFee.Clear();
        }

        private static decimal ParseDecimal(string s) =>
            decimal.TryParse(s, out var v) ? v : 0;

        private static int ParseInt(string s) =>
            int.TryParse(s, out var v) ? v : 0;
    }
}
