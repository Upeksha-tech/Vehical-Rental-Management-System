namespace Vehical_Rental_Management_System
{
    partial class returnForm
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
            returnToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            bthShowAll = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
            lblTotal = new GroupBox();
            textBox1 = new TextBox();
            dateTimeReturn = new DateTimePicker();
            label2 = new Label();
            dateTimeExpected = new DateTimePicker();
            dateTimeRental = new DateTimePicker();
            textBox2 = new TextBox();
            txtRentalID = new TextBox();
            txtNo_Days = new TextBox();
            label18 = new Label();
            lb = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            groupBox2 = new GroupBox();
            txtTotalFee = new TextBox();
            txtPenaltyFee = new TextBox();
            label3 = new Label();
            txtBaseCharge = new TextBox();
            txtRate = new TextBox();
            txtOverdueDates = new TextBox();
            label4 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            btnPay = new Button();
            btnClear = new Button();
            btnReturn = new Button();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            lblTotal.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { returnToolStripMenuItem, refreshToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1282, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // returnToolStripMenuItem
            // 
            returnToolStripMenuItem.Name = "returnToolStripMenuItem";
            returnToolStripMenuItem.Size = new Size(54, 24);
            returnToolStripMenuItem.Text = "Back";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(72, 24);
            refreshToolStripMenuItem.Text = "Refresh";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(bthShowAll);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(26, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1240, 177);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Active Rental";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1208, 94);
            dataGridView1.TabIndex = 7;
            // 
            // bthShowAll
            // 
            bthShowAll.BackgroundImageLayout = ImageLayout.Zoom;
            bthShowAll.Cursor = Cursors.Hand;
            bthShowAll.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bthShowAll.ImageAlign = ContentAlignment.MiddleLeft;
            bthShowAll.Location = new Point(603, 42);
            bthShowAll.Name = "bthShowAll";
            bthShowAll.Size = new Size(115, 27);
            bthShowAll.TabIndex = 6;
            bthShowAll.Text = "Show All";
            bthShowAll.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = SystemColors.Control;
            txtSearch.Location = new Point(157, 41);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(292, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(479, 41);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 28);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 42);
            label1.Name = "label1";
            label1.Size = new Size(123, 23);
            label1.TabIndex = 0;
            label1.Text = "Search Rentel :";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.BackColor = SystemColors.Control;
            lblTotal.Controls.Add(textBox1);
            lblTotal.Controls.Add(dateTimeReturn);
            lblTotal.Controls.Add(label2);
            lblTotal.Controls.Add(dateTimeExpected);
            lblTotal.Controls.Add(dateTimeRental);
            lblTotal.Controls.Add(textBox2);
            lblTotal.Controls.Add(txtRentalID);
            lblTotal.Controls.Add(txtNo_Days);
            lblTotal.Controls.Add(label18);
            lblTotal.Controls.Add(lb);
            lblTotal.Controls.Add(label10);
            lblTotal.Controls.Add(label9);
            lblTotal.Controls.Add(label8);
            lblTotal.Controls.Add(label7);
            lblTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(26, 240);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(638, 384);
            lblTotal.TabIndex = 3;
            lblTotal.TabStop = false;
            lblTotal.Text = "Return Details";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlLightLight;
            textBox1.Location = new Point(197, 293);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(134, 27);
            textBox1.TabIndex = 18;
            // 
            // dateTimeReturn
            // 
            dateTimeReturn.CustomFormat = "";
            dateTimeReturn.Format = DateTimePickerFormat.Short;
            dateTimeReturn.Location = new Point(197, 252);
            dateTimeReturn.Name = "dateTimeReturn";
            dateTimeReturn.Size = new Size(174, 27);
            dateTimeReturn.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(63, 294);
            label2.Name = "label2";
            label2.Size = new Size(114, 23);
            label2.TabIndex = 16;
            label2.Text = "Days Rented :";
            // 
            // dateTimeExpected
            // 
            dateTimeExpected.CustomFormat = "";
            dateTimeExpected.Format = DateTimePickerFormat.Short;
            dateTimeExpected.Location = new Point(197, 209);
            dateTimeExpected.Name = "dateTimeExpected";
            dateTimeExpected.Size = new Size(174, 27);
            dateTimeExpected.TabIndex = 15;
            // 
            // dateTimeRental
            // 
            dateTimeRental.CustomFormat = "";
            dateTimeRental.Format = DateTimePickerFormat.Short;
            dateTimeRental.Location = new Point(197, 170);
            dateTimeRental.Name = "dateTimeRental";
            dateTimeRental.Size = new Size(174, 27);
            dateTimeRental.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlLightLight;
            textBox2.Location = new Point(197, 87);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(235, 27);
            textBox2.TabIndex = 13;
            // 
            // txtRentalID
            // 
            txtRentalID.BackColor = SystemColors.ControlLightLight;
            txtRentalID.Location = new Point(197, 51);
            txtRentalID.Name = "txtRentalID";
            txtRentalID.Size = new Size(134, 27);
            txtRentalID.TabIndex = 12;
            // 
            // txtNo_Days
            // 
            txtNo_Days.BackColor = SystemColors.ControlLightLight;
            txtNo_Days.Location = new Point(197, 130);
            txtNo_Days.Name = "txtNo_Days";
            txtNo_Days.Size = new Size(235, 27);
            txtNo_Days.TabIndex = 8;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(13, 255);
            label18.Name = "label18";
            label18.Size = new Size(164, 23);
            label18.TabIndex = 6;
            label18.Text = "Actual Return Date :";
            // 
            // lb
            // 
            lb.AutoSize = true;
            lb.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb.Location = new Point(33, 212);
            lb.Name = "lb";
            lb.Size = new Size(144, 23);
            lb.TabIndex = 5;
            lb.Text = "Expected Return :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(69, 173);
            label10.Name = "label10";
            label10.Size = new Size(108, 23);
            label10.TabIndex = 4;
            label10.Text = "Rental Date :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(104, 131);
            label9.Name = "label9";
            label9.Size = new Size(73, 23);
            label9.TabIndex = 3;
            label9.Text = "Vehical :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(84, 88);
            label8.Name = "label8";
            label8.Size = new Size(93, 23);
            label8.TabIndex = 2;
            label8.Text = "Customer :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(88, 55);
            label7.Name = "label7";
            label7.Size = new Size(89, 23);
            label7.TabIndex = 1;
            label7.Text = "Rental ID :";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(txtTotalFee);
            groupBox2.Controls.Add(txtPenaltyFee);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtBaseCharge);
            groupBox2.Controls.Add(txtRate);
            groupBox2.Controls.Add(txtOverdueDates);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label13);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(670, 240);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(577, 261);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Change Calculations";
            // 
            // txtTotalFee
            // 
            txtTotalFee.BackColor = Color.FromArgb(192, 255, 192);
            txtTotalFee.ForeColor = Color.DarkGreen;
            txtTotalFee.Location = new Point(237, 211);
            txtTotalFee.Name = "txtTotalFee";
            txtTotalFee.ReadOnly = true;
            txtTotalFee.Size = new Size(134, 27);
            txtTotalFee.TabIndex = 19;
            // 
            // txtPenaltyFee
            // 
            txtPenaltyFee.BackColor = SystemColors.ControlLightLight;
            txtPenaltyFee.Location = new Point(237, 172);
            txtPenaltyFee.Name = "txtPenaltyFee";
            txtPenaltyFee.ReadOnly = true;
            txtPenaltyFee.Size = new Size(134, 27);
            txtPenaltyFee.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(97, 215);
            label3.Name = "label3";
            label3.Size = new Size(134, 23);
            label3.TabIndex = 16;
            label3.Text = "Total Due (LKR) :";
            // 
            // txtBaseCharge
            // 
            txtBaseCharge.BackColor = SystemColors.ControlLightLight;
            txtBaseCharge.Location = new Point(237, 88);
            txtBaseCharge.Name = "txtBaseCharge";
            txtBaseCharge.Size = new Size(134, 27);
            txtBaseCharge.TabIndex = 13;
            // 
            // txtRate
            // 
            txtRate.BackColor = SystemColors.ControlLightLight;
            txtRate.Location = new Point(237, 54);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(134, 27);
            txtRate.TabIndex = 12;
            // 
            // txtOverdueDates
            // 
            txtOverdueDates.BackColor = SystemColors.ControlLightLight;
            txtOverdueDates.Location = new Point(237, 130);
            txtOverdueDates.Name = "txtOverdueDates";
            txtOverdueDates.ReadOnly = true;
            txtOverdueDates.Size = new Size(134, 27);
            txtOverdueDates.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(75, 173);
            label4.Name = "label4";
            label4.Size = new Size(154, 23);
            label4.TabIndex = 6;
            label4.Text = "Late Penalty (LKR) :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(104, 131);
            label11.Name = "label11";
            label11.Size = new Size(125, 23);
            label11.TabIndex = 3;
            label11.Text = "Overdue Date :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(112, 91);
            label12.Name = "label12";
            label12.Size = new Size(114, 23);
            label12.TabIndex = 2;
            label12.Text = "Base Charge :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(88, 55);
            label13.Name = "label13";
            label13.Size = new Size(138, 23);
            label13.TabIndex = 1;
            label13.Text = "Daily Rate (LKR) :";
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.Green;
            btnPay.Cursor = Cursors.Hand;
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.Location = new Point(670, 519);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(371, 38);
            btnPay.TabIndex = 20;
            btnPay.Text = "Proceed to Payment";
            btnPay.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(1047, 519);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(200, 38);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = SystemColors.MenuHighlight;
            btnReturn.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.Location = new Point(670, 563);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(577, 41);
            btnReturn.TabIndex = 22;
            btnReturn.Text = "Confirm Return";
            btnReturn.UseVisualStyleBackColor = false;
            // 
            // returnForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 660);
            Controls.Add(btnReturn);
            Controls.Add(btnClear);
            Controls.Add(btnPay);
            Controls.Add(groupBox2);
            Controls.Add(lblTotal);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "returnForm";
            Text = "Return Vehical";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            lblTotal.ResumeLayout(false);
            lblTotal.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem returnToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private GroupBox groupBox1;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;
        private Button bthShowAll;
        private DataGridView dataGridView1;
        private GroupBox lblTotal;
        private TextBox txtNo_Days;
        private Label label18;
        private Label lb;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox textBox2;
        private TextBox txtRentalID;
        private DateTimePicker dateTimeReturn;
        private Label label2;
        private DateTimePicker dateTimeExpected;
        private DateTimePicker dateTimeRental;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private TextBox txtPenaltyFee;
        private Label label3;
        private TextBox txtBaseCharge;
        private TextBox txtRate;
        private TextBox txtOverdueDates;
        private Label label4;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txtTotalFee;
        private Button btnPay;
        private Button btnClear;
        private Button btnReturn;
    }
}