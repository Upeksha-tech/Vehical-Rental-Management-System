namespace Vehical_Rental_Management_System
{
    partial class frmPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            paymentsToolStripMenuItem = new ToolStripMenuItem();
            invoicesToolStripMenuItem = new ToolStripMenuItem();
            historyToolStripMenuItem = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            btnNewPayment = new Button();
            btnLoad = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnGo = new Button();
            grpPayment = new GroupBox();
            btnClear = new Button();
            btnProcessPayment = new Button();
            btnRecalculate = new Button();
            textBox1 = new TextBox();
            dtpDate = new DateTimePicker();
            comboBox1 = new ComboBox();
            txtFinal = new TextBox();
            txtDiscount = new TextBox();
            txtTotalDue = new TextBox();
            txtLatePenalty = new TextBox();
            txtPenalty = new TextBox();
            txtOverdue = new TextBox();
            txtBase = new TextBox();
            txtPeriod = new TextBox();
            txtVehicle = new TextBox();
            txtCustomer = new TextBox();
            txtRentalID = new TextBox();
            lblReferences = new Label();
            lblDate = new Label();
            lblMethod = new Label();
            lblFinal = new Label();
            lblDiscount = new Label();
            lblTotalDue = new Label();
            lblLatePenalty = new Label();
            lblPenalty = new Label();
            lblOverdue = new Label();
            lblBase = new Label();
            lblPeriod = new Label();
            lblVehicle = new Label();
            lblCustomer = new Label();
            lblRentalID = new Label();
            grpRecent = new GroupBox();
            dgvPayments = new DataGridView();
            grpReceipt = new GroupBox();
            btnPrint = new Button();
            btnRefresh = new Button();
            richTextBox1 = new RichTextBox();
            menuStrip1.SuspendLayout();
            grpPayment.SuspendLayout();
            grpRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            grpReceipt.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { paymentsToolStripMenuItem, invoicesToolStripMenuItem, historyToolStripMenuItem, printToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1413, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // paymentsToolStripMenuItem
            // 
            paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            paymentsToolStripMenuItem.Size = new Size(85, 24);
            paymentsToolStripMenuItem.Text = "Payments";
            // 
            // invoicesToolStripMenuItem
            // 
            invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            invoicesToolStripMenuItem.Size = new Size(76, 24);
            invoicesToolStripMenuItem.Text = "Invoices";
            // 
            // historyToolStripMenuItem
            // 
            historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            historyToolStripMenuItem.Size = new Size(70, 24);
            historyToolStripMenuItem.Text = "History";
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Size = new Size(53, 24);
            printToolStripMenuItem.Text = "Print";
            // 
            // btnNewPayment
            // 
            btnNewPayment.BackColor = Color.DodgerBlue;
            btnNewPayment.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewPayment.ForeColor = SystemColors.Info;
            btnNewPayment.Location = new Point(12, 31);
            btnNewPayment.Name = "btnNewPayment";
            btnNewPayment.Size = new Size(200, 40);
            btnNewPayment.TabIndex = 2;
            btnNewPayment.Text = "➕ New Payment";
            btnNewPayment.UseVisualStyleBackColor = false;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = SystemColors.ControlLight;
            btnLoad.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoad.Location = new Point(218, 31);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(150, 40);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "📂 Load Rental";
            btnLoad.UseVisualStyleBackColor = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(953, 40);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(118, 23);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Search Rental:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(1077, 37);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(175, 30);
            txtSearch.TabIndex = 6;
            // 
            // btnGo
            // 
            btnGo.BackColor = SystemColors.ControlLight;
            btnGo.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGo.Location = new Point(1277, 31);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(100, 40);
            btnGo.TabIndex = 7;
            btnGo.Text = "🔍 Go";
            btnGo.UseVisualStyleBackColor = false;
            // 
            // grpPayment
            // 
            grpPayment.Controls.Add(btnClear);
            grpPayment.Controls.Add(btnProcessPayment);
            grpPayment.Controls.Add(btnRecalculate);
            grpPayment.Controls.Add(textBox1);
            grpPayment.Controls.Add(dtpDate);
            grpPayment.Controls.Add(comboBox1);
            grpPayment.Controls.Add(txtFinal);
            grpPayment.Controls.Add(txtDiscount);
            grpPayment.Controls.Add(txtTotalDue);
            grpPayment.Controls.Add(txtLatePenalty);
            grpPayment.Controls.Add(txtPenalty);
            grpPayment.Controls.Add(txtOverdue);
            grpPayment.Controls.Add(txtBase);
            grpPayment.Controls.Add(txtPeriod);
            grpPayment.Controls.Add(txtVehicle);
            grpPayment.Controls.Add(txtCustomer);
            grpPayment.Controls.Add(txtRentalID);
            grpPayment.Controls.Add(lblReferences);
            grpPayment.Controls.Add(lblDate);
            grpPayment.Controls.Add(lblMethod);
            grpPayment.Controls.Add(lblFinal);
            grpPayment.Controls.Add(lblDiscount);
            grpPayment.Controls.Add(lblTotalDue);
            grpPayment.Controls.Add(lblLatePenalty);
            grpPayment.Controls.Add(lblPenalty);
            grpPayment.Controls.Add(lblOverdue);
            grpPayment.Controls.Add(lblBase);
            grpPayment.Controls.Add(lblPeriod);
            grpPayment.Controls.Add(lblVehicle);
            grpPayment.Controls.Add(lblCustomer);
            grpPayment.Controls.Add(lblRentalID);
            grpPayment.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpPayment.Location = new Point(17, 84);
            grpPayment.Name = "grpPayment";
            grpPayment.Size = new Size(670, 900);
            grpPayment.TabIndex = 8;
            grpPayment.TabStop = false;
            grpPayment.Text = "💰Payment Details";
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ControlLight;
            btnClear.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(463, 800);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 40);
            btnClear.TabIndex = 35;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnProcessPayment
            // 
            btnProcessPayment.BackColor = Color.DodgerBlue;
            btnProcessPayment.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProcessPayment.ForeColor = SystemColors.Info;
            btnProcessPayment.Location = new Point(245, 800);
            btnProcessPayment.Name = "btnProcessPayment";
            btnProcessPayment.Size = new Size(200, 40);
            btnProcessPayment.TabIndex = 34;
            btnProcessPayment.Text = "✔ Process Payment";
            btnProcessPayment.UseVisualStyleBackColor = false;
            // 
            // btnRecalculate
            // 
            btnRecalculate.BackColor = Color.DodgerBlue;
            btnRecalculate.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecalculate.ForeColor = SystemColors.Info;
            btnRecalculate.Location = new Point(23, 800);
            btnRecalculate.Name = "btnRecalculate";
            btnRecalculate.Size = new Size(200, 40);
            btnRecalculate.TabIndex = 33;
            btnRecalculate.Text = "🔄 Recalculate";
            btnRecalculate.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(201, 697);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(369, 30);
            textBox1.TabIndex = 32;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(201, 644);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(175, 30);
            dtpDate.TabIndex = 31;
            dtpDate.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(201, 597);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(175, 31);
            comboBox1.TabIndex = 30;
            // 
            // txtFinal
            // 
            txtFinal.BackColor = Color.PowderBlue;
            txtFinal.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFinal.Location = new Point(201, 547);
            txtFinal.Name = "txtFinal";
            txtFinal.Size = new Size(175, 30);
            txtFinal.TabIndex = 29;
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiscount.Location = new Point(201, 497);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(175, 30);
            txtDiscount.TabIndex = 28;
            // 
            // txtTotalDue
            // 
            txtTotalDue.BackColor = Color.LightGreen;
            txtTotalDue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalDue.Location = new Point(201, 447);
            txtTotalDue.Name = "txtTotalDue";
            txtTotalDue.Size = new Size(175, 30);
            txtTotalDue.TabIndex = 27;
            // 
            // txtLatePenalty
            // 
            txtLatePenalty.BackColor = Color.LightSalmon;
            txtLatePenalty.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLatePenalty.Location = new Point(201, 397);
            txtLatePenalty.Name = "txtLatePenalty";
            txtLatePenalty.Size = new Size(175, 30);
            txtLatePenalty.TabIndex = 26;
            // 
            // txtPenalty
            // 
            txtPenalty.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPenalty.Location = new Point(201, 347);
            txtPenalty.Name = "txtPenalty";
            txtPenalty.Size = new Size(175, 30);
            txtPenalty.TabIndex = 25;
            // 
            // txtOverdue
            // 
            txtOverdue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOverdue.Location = new Point(201, 297);
            txtOverdue.Name = "txtOverdue";
            txtOverdue.Size = new Size(175, 30);
            txtOverdue.TabIndex = 24;
            // 
            // txtBase
            // 
            txtBase.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBase.Location = new Point(201, 243);
            txtBase.Name = "txtBase";
            txtBase.Size = new Size(175, 30);
            txtBase.TabIndex = 9;
            // 
            // txtPeriod
            // 
            txtPeriod.BackColor = SystemColors.Control;
            txtPeriod.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPeriod.Location = new Point(201, 197);
            txtPeriod.Name = "txtPeriod";
            txtPeriod.Size = new Size(369, 30);
            txtPeriod.TabIndex = 23;
            // 
            // txtVehicle
            // 
            txtVehicle.BackColor = SystemColors.Control;
            txtVehicle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVehicle.Location = new Point(201, 147);
            txtVehicle.Name = "txtVehicle";
            txtVehicle.Size = new Size(369, 30);
            txtVehicle.TabIndex = 22;
            // 
            // txtCustomer
            // 
            txtCustomer.BackColor = SystemColors.Control;
            txtCustomer.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCustomer.Location = new Point(201, 97);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(369, 30);
            txtCustomer.TabIndex = 21;
            // 
            // txtRentalID
            // 
            txtRentalID.BackColor = SystemColors.Control;
            txtRentalID.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRentalID.Location = new Point(201, 47);
            txtRentalID.Name = "txtRentalID";
            txtRentalID.Size = new Size(369, 30);
            txtRentalID.TabIndex = 20;
            // 
            // lblReferences
            // 
            lblReferences.AutoSize = true;
            lblReferences.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReferences.Location = new Point(88, 700);
            lblReferences.Name = "lblReferences";
            lblReferences.Size = new Size(89, 23);
            lblReferences.TabIndex = 19;
            lblReferences.Text = "Reference:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(56, 650);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(121, 23);
            lblDate.TabIndex = 18;
            lblDate.Text = "Payment Date:";
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMethod.Location = new Point(32, 600);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(145, 23);
            lblMethod.TabIndex = 17;
            lblMethod.Text = "Payment Method:";
            // 
            // lblFinal
            // 
            lblFinal.AutoSize = true;
            lblFinal.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFinal.Location = new Point(23, 550);
            lblFinal.Name = "lblFinal";
            lblFinal.Size = new Size(154, 23);
            lblFinal.TabIndex = 16;
            lblFinal.Text = "Final Amount(LKR):";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiscount.Location = new Point(58, 500);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(119, 23);
            lblDiscount.TabIndex = 15;
            lblDiscount.Text = "Discount(LKR):";
            // 
            // lblTotalDue
            // 
            lblTotalDue.AutoSize = true;
            lblTotalDue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalDue.Location = new Point(53, 450);
            lblTotalDue.Name = "lblTotalDue";
            lblTotalDue.Size = new Size(124, 23);
            lblTotalDue.TabIndex = 14;
            lblTotalDue.Text = "Total Due(LKR):";
            // 
            // lblLatePenalty
            // 
            lblLatePenalty.AutoSize = true;
            lblLatePenalty.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLatePenalty.Location = new Point(33, 400);
            lblLatePenalty.Name = "lblLatePenalty";
            lblLatePenalty.Size = new Size(144, 23);
            lblLatePenalty.TabIndex = 13;
            lblLatePenalty.Text = "Late Penalty(LKR):";
            // 
            // lblPenalty
            // 
            lblPenalty.AutoSize = true;
            lblPenalty.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPenalty.Location = new Point(36, 350);
            lblPenalty.Name = "lblPenalty";
            lblPenalty.Size = new Size(141, 23);
            lblPenalty.TabIndex = 12;
            lblPenalty.Text = "Penalty(LKR/day):";
            // 
            // lblOverdue
            // 
            lblOverdue.AutoSize = true;
            lblOverdue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOverdue.Location = new Point(57, 300);
            lblOverdue.Name = "lblOverdue";
            lblOverdue.Size = new Size(120, 23);
            lblOverdue.TabIndex = 11;
            lblOverdue.Text = "Overdue Days:";
            // 
            // lblBase
            // 
            lblBase.AutoSize = true;
            lblBase.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBase.Location = new Point(23, 250);
            lblBase.Name = "lblBase";
            lblBase.Size = new Size(154, 23);
            lblBase.TabIndex = 10;
            lblBase.Text = "Base Amount(LKR):";
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriod.Location = new Point(62, 200);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(115, 23);
            lblPeriod.TabIndex = 9;
            lblPeriod.Text = "Rental Period:";
            // 
            // lblVehicle
            // 
            lblVehicle.AutoSize = true;
            lblVehicle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVehicle.Location = new Point(109, 150);
            lblVehicle.Name = "lblVehicle";
            lblVehicle.Size = new Size(68, 23);
            lblVehicle.TabIndex = 8;
            lblVehicle.Text = "Vehicle:";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomer.Location = new Point(89, 100);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(88, 23);
            lblCustomer.TabIndex = 7;
            lblCustomer.Text = "Customer:";
            // 
            // lblRentalID
            // 
            lblRentalID.AutoSize = true;
            lblRentalID.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRentalID.Location = new Point(93, 50);
            lblRentalID.Name = "lblRentalID";
            lblRentalID.Size = new Size(84, 23);
            lblRentalID.TabIndex = 6;
            lblRentalID.Text = "Rental ID:";
            // 
            // grpRecent
            // 
            grpRecent.Controls.Add(dgvPayments);
            grpRecent.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpRecent.Location = new Point(711, 84);
            grpRecent.Name = "grpRecent";
            grpRecent.Size = new Size(690, 343);
            grpRecent.TabIndex = 9;
            grpRecent.TabStop = false;
            grpRecent.Text = "📋 Recent Payments";
            // 
            // dgvPayments
            // 
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Location = new Point(15, 47);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.RowHeadersWidth = 51;
            dgvPayments.Size = new Size(660, 276);
            dgvPayments.TabIndex = 0;
            // 
            // grpReceipt
            // 
            grpReceipt.Controls.Add(btnPrint);
            grpReceipt.Controls.Add(btnRefresh);
            grpReceipt.Controls.Add(richTextBox1);
            grpReceipt.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpReceipt.Location = new Point(711, 451);
            grpReceipt.Name = "grpReceipt";
            grpReceipt.Size = new Size(690, 360);
            grpReceipt.TabIndex = 10;
            grpReceipt.TabStop = false;
            grpReceipt.Text = "\U0001f9fe Receipt Preview";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.DodgerBlue;
            btnPrint.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = SystemColors.Info;
            btnPrint.Location = new Point(171, 316);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(150, 40);
            btnPrint.TabIndex = 36;
            btnPrint.Text = "🖨 Print";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ControlLight;
            btnRefresh.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(15, 314);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 40);
            btnRefresh.TabIndex = 36;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(15, 54);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(660, 253);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // frmPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1413, 1003);
            Controls.Add(grpReceipt);
            Controls.Add(grpRecent);
            Controls.Add(grpPayment);
            Controls.Add(btnGo);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnLoad);
            Controls.Add(btnNewPayment);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment & Billing Center";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            grpPayment.ResumeLayout(false);
            grpPayment.PerformLayout();
            grpRecent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            grpReceipt.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem paymentsToolStripMenuItem;
        private ToolStripMenuItem invoicesToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private Button btnNewPayment;
        private Button btnLoad;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnGo;
        private GroupBox grpPayment;
        private Label lblReferences;
        private Label lblDate;
        private Label lblMethod;
        private Label lblFinal;
        private Label lblDiscount;
        private Label lblTotalDue;
        private Label lblLatePenalty;
        private Label lblPenalty;
        private Label lblOverdue;
        private Label lblBase;
        private Label lblPeriod;
        private Label lblVehicle;
        private Label lblCustomer;
        private Label lblRentalID;
        private TextBox txtRentalID;
        private TextBox txtPenalty;
        private TextBox txtOverdue;
        private TextBox txtBase;
        private TextBox txtPeriod;
        private TextBox txtVehicle;
        private TextBox txtCustomer;
        private TextBox txtTotalDue;
        private TextBox txtLatePenalty;
        private DateTimePicker dtpDate;
        private ComboBox comboBox1;
        private TextBox txtFinal;
        private TextBox txtDiscount;
        private Button btnClear;
        private Button btnProcessPayment;
        private Button btnRecalculate;
        private TextBox textBox1;
        private GroupBox grpRecent;
        private DataGridView dgvPayments;
        private GroupBox grpReceipt;
        private RichTextBox richTextBox1;
        private Button btnPrint;
        private Button btnRefresh;
    }
}