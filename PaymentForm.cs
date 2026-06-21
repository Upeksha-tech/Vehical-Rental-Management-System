using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Vehical_Rental_Management_System
{

    public partial class frmPayment : Form
    {

        private readonly string _connStr = DatabaseConnection.ConnectionString;


        private bool _isDbAvailable  = false;
        private int  _loadedRentalID = -1;
        private bool _fromReturnFlow = false;
        private Label _lblDbStatus   = null!;

        public bool PaymentCompleted { get; private set; }

        private string _receiptText = string.Empty;


        public void LoadFromReturn(PaymentRequest request)
        {
            _fromReturnFlow    = true;
            PaymentCompleted   = false;
            _loadedRentalID    = request.RentalID;

            txtRentalID.Text   = request.RentalID.ToString();
            txtCustomer.Text   = request.Customer;
            txtVehicle.Text    = request.Vehicle;
            txtPeriod.Text     = request.Period;
            txtBase.Text       = request.BaseAmount.ToString("F2");
            txtOverdue.Text    = request.OverdueDays.ToString();
            txtPenalty.Text    = request.PenaltyRate.ToString("F2");
            txtLatePenalty.Text = request.LatePenalty.ToString("F2");
            txtTotalDue.Text   = request.TotalDue.ToString("F2");
            txtDiscount.Text   = request.Discount.ToString("F2");
            txtFinal.Text      = request.FinalAmount.ToString("F2");
            dtpDate.Value      = DateTime.Today;

            SetPanelReadOnly(false);
            ApplyReturnFlowFieldLocks();
            btnProcessPayment.Enabled = true;
            btnRecalculate.Enabled    = true;
        }

        private void ApplyReturnFlowFieldLocks()
        {
            if (!_fromReturnFlow) return;

            txtRentalID.ReadOnly     = true;
            txtCustomer.ReadOnly     = true;
            txtVehicle.ReadOnly      = true;
            txtPeriod.ReadOnly       = true;
            txtBase.ReadOnly         = true;
            txtOverdue.ReadOnly      = true;
            txtPenalty.ReadOnly      = true;
            txtLatePenalty.ReadOnly  = true;
            txtTotalDue.ReadOnly     = true;
        }


        public frmPayment()
        {
            InitializeComponent();
            WireEvents();
        }


        private void WireEvents()
        {
            btnNewPayment.Click    += BtnNewPayment_Click;
            btnLoad.Click          += BtnLoad_Click;
            btnGo.Click            += BtnGo_Click;
            btnRecalculate.Click   += BtnRecalculate_Click;
            btnProcessPayment.Click += BtnProcessPayment_Click;
            btnClear.Click         += BtnClear_Click;
            btnRefresh.Click       += BtnRefresh_Click;
            btnPrint.Click         += BtnPrint_Click;

            paymentsToolStripMenuItem.Click += (s, e) => { TryConnectDb(); LoadRecentPayments(); };
            invoicesToolStripMenuItem.Click  += (s, e) => ShowInfo("Invoice view coming soon.");
            historyToolStripMenuItem.Click   += (s, e) => { TryConnectDb(); LoadRecentPayments(); };
            printToolStripMenuItem.Click     += (s, e) => DoPrint();

            txtSearch.KeyDown += (s, e) =>
                { if (e.KeyCode == Keys.Enter) BtnGo_Click(s, e); };
            dtpDate.ValueChanged += dateTimePicker1_ValueChanged;


            comboBox1.Items.AddRange(new object[]
                { "Cash", "Credit Card", "Debit Card", "Bank Transfer", "Online" });
            comboBox1.SelectedIndex = 0;


            _lblDbStatus = new Label
            {
                AutoSize = true, Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(ClientSize.Width - 210, ClientSize.Height - 28),
                Font     = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text     = "Connecting…"
            };
            Controls.Add(_lblDbStatus);
            _lblDbStatus.BringToFront();
        }


        private void frmPayment_Load(object sender, EventArgs e)
        {
            TryConnectDb();
            if (_fromReturnFlow)
                return;

            LoadRecentPayments();
            SetPanelReadOnly(true);
        }


        private void TryConnectDb()
        {
            try
            {
                using var conn = new MySqlConnection(_connStr);
                conn.Open();


                new MySqlCommand(@"
                    CREATE TABLE IF NOT EXISTS payments (
                        PaymentID    INT AUTO_INCREMENT PRIMARY KEY,
                        RentalID     INT          NOT NULL,
                        Customer     VARCHAR(255) NOT NULL,
                        Vehicle      VARCHAR(255) NOT NULL,
                        Period       VARCHAR(100) NOT NULL,
                        BaseAmount   DECIMAL(10,2) NOT NULL,
                        OverdueDays  INT           NOT NULL DEFAULT 0,
                        PenaltyRate  DECIMAL(10,2) NOT NULL DEFAULT 0,
                        LatePenalty  DECIMAL(10,2) NOT NULL DEFAULT 0,
                        TotalDue     DECIMAL(10,2) NOT NULL,
                        Discount     DECIMAL(10,2) NOT NULL DEFAULT 0,
                        FinalAmount  DECIMAL(10,2) NOT NULL,
                        Method       VARCHAR(50)   NOT NULL,
                        PayDate      DATE          NOT NULL,
                        ReferenceNo  VARCHAR(100)  NOT NULL DEFAULT ''
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


        private void BtnNewPayment_Click(object? sender, EventArgs e)
        {
            _fromReturnFlow = false;
            _loadedRentalID = -1;
            ClearPaymentPanel();
            ResetFieldReadOnlyStates();
            SetPanelReadOnly(false);
            txtRentalID.Focus();
        }


        private void BtnLoad_Click(object? sender, EventArgs e)
        {
            string q = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(q))
            { ShowInfo("Enter a Rental ID or Customer name in the search box."); return; }

            if (_isDbAvailable)
            {
                LoadRentalFromDb(q);
            }
            else
            {

                txtRentalID.Text  = "R-2024-001";
                txtCustomer.Text  = "Anura Perera";
                txtVehicle.Text   = "Toyota Aqua – CAB-1234";
                txtPeriod.Text    = "2024-06-01 → 2024-06-07 (7 days)";
                txtBase.Text      = "35000.00";
                txtOverdue.Text   = "2";
                txtPenalty.Text   = "2500.00";
                Recalculate();
                _loadedRentalID = 1;
                SetPanelReadOnly(false);
            }
        }


        private void BtnGo_Click(object? sender, EventArgs e) => BtnLoad_Click(sender, e);


        private void BtnRecalculate_Click(object? sender, EventArgs e) => Recalculate();

        private void Recalculate()
        {
            if (!decimal.TryParse(txtBase.Text, out decimal baseAmt)) baseAmt = 0;
            if (!int.TryParse(txtOverdue.Text, out int overdue))       overdue = 0;
            if (!decimal.TryParse(txtPenalty.Text, out decimal rate))  rate    = 0;
            if (!decimal.TryParse(txtDiscount.Text, out decimal disc)) disc    = 0;

            decimal latePenalty = overdue * rate;
            decimal totalDue    = baseAmt + latePenalty;
            decimal finalAmt    = totalDue - disc;
            if (finalAmt < 0) finalAmt = 0;

            txtLatePenalty.Text = latePenalty.ToString("F2");
            txtTotalDue.Text    = totalDue.ToString("F2");
            txtFinal.Text       = finalAmt.ToString("F2");
        }

        private void dateTimePicker1_ValueChanged(object? sender, EventArgs e)
        {
        }


        private void BtnProcessPayment_Click(object? sender, EventArgs e)
        {
            if (!ValidatePayment()) return;

            Recalculate();

            var p = CollectPayment();

            if (_isDbAvailable)
            {
                try
                {
                    using var conn = new MySqlConnection(_connStr);
                    conn.Open();
                    using var cmd = new MySqlCommand(@"
                        INSERT INTO payments
                            (RentalID, Customer, Vehicle, Period, BaseAmount, OverdueDays,
                             PenaltyRate, LatePenalty, TotalDue, Discount, FinalAmount,
                             Method, PayDate, ReferenceNo)
                        VALUES
                            (@rid,@cust,@veh,@per,@base,@od,@prate,@lp,@td,@disc,@fin,
                             @meth,@pdate,@ref);", conn);
                    AddPaymentParams(cmd, p);
                    cmd.ExecuteNonQuery();
                    ShowSuccess("Payment processed and saved successfully.");
                }
                catch (Exception ex)
                {
                    ShowError("Save failed: " + ex.Message);
                    return;
                }
            }
            else
            {
                ShowSuccess("Payment processed (offline demo — not saved to DB).");
            }

            GenerateReceipt(p);
            LoadRecentPayments();

            PaymentCompleted = true;

            if (_fromReturnFlow)
            {
                ShowSuccess("Payment processed successfully.");
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            SetPanelReadOnly(true);
        }


        private void BtnClear_Click(object? sender, EventArgs e)   { ClearPaymentPanel(); SetPanelReadOnly(true); }
        private void BtnRefresh_Click(object? sender, EventArgs e) { TryConnectDb(); LoadRecentPayments(); }
        private void BtnPrint_Click(object? sender, EventArgs e)   => DoPrint();


        private void LoadRecentPayments(string filter = "")
        {
            var dt = new DataTable();
            dt.Columns.Add("PaymentID");
            dt.Columns.Add("RentalID");
            dt.Columns.Add("Customer");
            dt.Columns.Add("Vehicle");
            dt.Columns.Add("FinalAmount");
            dt.Columns.Add("Method");
            dt.Columns.Add("PayDate");

            if (_isDbAvailable)
            {
                try
                {
                    using var conn = new MySqlConnection(_connStr);
                    conn.Open();
                    var sql = @"SELECT PaymentID, RentalID, Customer, Vehicle, FinalAmount, Method, PayDate
                                FROM payments ORDER BY PaymentID DESC LIMIT 100;";
                    using var cmd = new MySqlCommand(sql, conn);
                    using var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        dt.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3],
                            $"LKR {Convert.ToDecimal(rdr[4]):F2}", rdr[5],
                            Convert.ToDateTime(rdr[6]).ToString("yyyy-MM-dd"));
                }
                catch { }
            }
            else
            {

                dt.Rows.Add(1, "R-2024-001", "Anura Perera", "Toyota Aqua",
                    "LKR 37500.00", "Cash", DateTime.Today.ToString("yyyy-MM-dd"));
            }

            dgvPayments.DataSource = dt;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void LoadRentalFromDb(string q)
        {
            try
            {
                using var conn = new MySqlConnection(_connStr);
                conn.Open();


                var sql = @"SELECT r.RentalID, c.FullName AS Customer,
                                   v.RegNo AS PlateNo,
                                   CONCAT(r.StartDate,' → ',r.EndDate) AS Period,
                                   r.TotalAmount AS Base
                            FROM rentals r
                            JOIN customers c ON r.CustomerID = c.CustomerID
                            JOIN vehicle   v ON r.VehicleID  = v.ID
                            WHERE r.Status = 'Active'
                              AND (CAST(r.RentalID AS CHAR) LIKE @q OR c.FullName LIKE @q)
                            LIMIT 1;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@q", "%" + q + "%");
                using var rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtRentalID.Text  = rdr["RentalID"].ToString()!;
                    txtCustomer.Text  = rdr["Customer"].ToString()!;
                    txtVehicle.Text   = rdr["PlateNo"].ToString()!;
                    txtPeriod.Text    = rdr["Period"].ToString()!;
                    txtBase.Text      = Convert.ToDecimal(rdr["Base"]).ToString("F2");
                    txtOverdue.Text   = "0";
                    txtPenalty.Text   = "0";
                    Recalculate();
                    _loadedRentalID = Convert.ToInt32(rdr["RentalID"]);
                    SetPanelReadOnly(false);
                }
                else
                {
                    ShowInfo("No active rental found matching: " + q);
                }
            }
            catch
            {
                ShowInfo("Rentals table not found. Please enter details manually.");
                SetPanelReadOnly(false);
            }
        }


        private Payment CollectPayment() => new Payment
        {
            RentalID    = _loadedRentalID > 0 ? _loadedRentalID : 0,
            Customer    = txtCustomer.Text.Trim(),
            Vehicle     = txtVehicle.Text.Trim(),
            Period      = txtPeriod.Text.Trim(),
            BaseAmount  = ParseDecimal(txtBase.Text),
            OverdueDays = ParseInt(txtOverdue.Text),
            PenaltyRate = ParseDecimal(txtPenalty.Text),
            LatePenalty = ParseDecimal(txtLatePenalty.Text),
            TotalDue    = ParseDecimal(txtTotalDue.Text),
            Discount    = ParseDecimal(txtDiscount.Text),
            FinalAmount = ParseDecimal(txtFinal.Text),
            Method      = comboBox1.SelectedItem?.ToString() ?? "Cash",
            PayDate     = dtpDate.Value.Date,
            Reference   = textBox1.Text.Trim()
        };

        private static void AddPaymentParams(MySqlCommand cmd, Payment p)
        {
            cmd.Parameters.AddWithValue("@rid",   p.RentalID);
            cmd.Parameters.AddWithValue("@cust",  p.Customer);
            cmd.Parameters.AddWithValue("@veh",   p.Vehicle);
            cmd.Parameters.AddWithValue("@per",   p.Period);
            cmd.Parameters.AddWithValue("@base",  p.BaseAmount);
            cmd.Parameters.AddWithValue("@od",    p.OverdueDays);
            cmd.Parameters.AddWithValue("@prate", p.PenaltyRate);
            cmd.Parameters.AddWithValue("@lp",    p.LatePenalty);
            cmd.Parameters.AddWithValue("@td",    p.TotalDue);
            cmd.Parameters.AddWithValue("@disc",  p.Discount);
            cmd.Parameters.AddWithValue("@fin",   p.FinalAmount);
            cmd.Parameters.AddWithValue("@meth",  p.Method);
            cmd.Parameters.AddWithValue("@pdate", p.PayDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@ref",   p.Reference);
        }


        private void GenerateReceipt(Payment p)
        {
            var sb = new StringBuilder();
            sb.AppendLine("══════════════════════════════════════");
            sb.AppendLine("    VEHICLE RENTAL MANAGEMENT SYSTEM  ");
            sb.AppendLine("          PAYMENT RECEIPT             ");
            sb.AppendLine("══════════════════════════════════════");
            sb.AppendLine($"Date       : {p.PayDate:yyyy-MM-dd}");
            sb.AppendLine($"Rental ID  : {p.RentalID}");
            sb.AppendLine($"Customer   : {p.Customer}");
            sb.AppendLine($"Vehicle    : {p.Vehicle}");
            sb.AppendLine($"Period     : {p.Period}");
            sb.AppendLine("──────────────────────────────────────");
            sb.AppendLine($"Base Amount: LKR {p.BaseAmount,10:F2}");
            sb.AppendLine($"Overdue    : {p.OverdueDays} day(s) x LKR {p.PenaltyRate:F2}");
            sb.AppendLine($"Late Pen.  : LKR {p.LatePenalty,10:F2}");
            sb.AppendLine($"Total Due  : LKR {p.TotalDue,10:F2}");
            sb.AppendLine($"Discount   : LKR {p.Discount,10:F2}");
            sb.AppendLine("──────────────────────────────────────");
            sb.AppendLine($"FINAL AMT  : LKR {p.FinalAmount,10:F2}");
            sb.AppendLine("══════════════════════════════════════");
            sb.AppendLine($"Method     : {p.Method}");
            sb.AppendLine($"Reference  : {p.Reference}");
            sb.AppendLine();
            sb.AppendLine("    Thank you for choosing our service!");

            _receiptText = sb.ToString();
            richTextBox1.Text = _receiptText;
        }

        private void DoPrint()
        {
            if (string.IsNullOrEmpty(_receiptText))
            { ShowInfo("No receipt to print. Process a payment first."); return; }

            var pd = new PrintDocument();
            pd.PrintPage += (s, e) =>
            {
                e.Graphics?.DrawString(_receiptText,
                    new Font("Courier New", 10),
                    Brushes.Black, e.MarginBounds);
            };
            using var dlg = new PrintPreviewDialog { Document = pd };
            dlg.ShowDialog();
        }


        private bool ValidatePayment()
        {
            if (string.IsNullOrWhiteSpace(txtCustomer.Text))
            { ShowWarning("Please load a rental first (Customer field is empty)."); return false; }
            if (string.IsNullOrWhiteSpace(txtBase.Text))
            { ShowWarning("Base Amount is required."); return false; }
            if (!decimal.TryParse(txtBase.Text, out decimal ba) || ba < 0)
            { ShowWarning("Base Amount must be a valid positive number."); return false; }

            string discountText = string.IsNullOrWhiteSpace(txtDiscount.Text) ? "0" : txtDiscount.Text.Trim();
            if (!decimal.TryParse(discountText, out decimal disc) || disc < 0)
            { ShowWarning("Discount must be a valid non-negative number."); return false; }

            return true;
        }


        private void SetPanelReadOnly(bool readOnly)
        {
            foreach (Control ctrl in grpPayment.Controls)
            {
                if (ctrl is TextBox tb && tb.Name != "txtRentalID"
                                      && tb.Name != "txtCustomer"
                                      && tb.Name != "txtVehicle"
                                      && tb.Name != "txtPeriod")
                {
                    tb.ReadOnly  = readOnly;
                    tb.BackColor = readOnly ? Color.FromArgb(240, 242, 245) : Color.White;
                }
                if (ctrl is ComboBox cb) cb.Enabled = !readOnly;
                if (ctrl is DateTimePicker dtp) dtp.Enabled = !readOnly;
            }
            btnProcessPayment.Enabled = !readOnly;
            btnRecalculate.Enabled    = !readOnly;
        }


        private void ClearPaymentPanel()
        {
            _fromReturnFlow = false;
            _loadedRentalID = -1;
            txtRentalID.Clear(); txtCustomer.Clear(); txtVehicle.Clear();
            txtPeriod.Clear();   txtBase.Clear();     txtOverdue.Clear();
            txtPenalty.Clear();  txtLatePenalty.Clear(); txtTotalDue.Clear();
            txtDiscount.Clear(); txtFinal.Clear();    textBox1.Clear();
            dtpDate.Value = DateTime.Today;
            comboBox1.SelectedIndex = 0;
            richTextBox1.Clear();
            _receiptText = string.Empty;
            ResetFieldReadOnlyStates();
        }

        private void ResetFieldReadOnlyStates()
        {
            foreach (Control ctrl in grpPayment.Controls)
            {
                if (ctrl is TextBox tb)
                    tb.ReadOnly = false;
            }
        }


        private static decimal ParseDecimal(string s)
            => decimal.TryParse(s, out var v) ? v : 0;
        private static int ParseInt(string s)
            => int.TryParse(s, out var v) ? v : 0;


        private static void ShowSuccess(string msg) =>
            MessageBox.Show(msg, "Success",    MessageBoxButtons.OK, MessageBoxIcon.Information);
        private static void ShowWarning(string msg) =>
            MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private static void ShowError(string msg) =>
            MessageBox.Show(msg, "Error",      MessageBoxButtons.OK, MessageBoxIcon.Error);
        private static void ShowInfo(string msg) =>
            MessageBox.Show(msg, "Info",       MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
