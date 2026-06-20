namespace Vehical_Rental_Management_System
{
    partial class bookingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bookingForm));
            menuStrip1 = new MenuStrip();
            backToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            lblLicence = new Label();
            lblNIC = new Label();
            lblPhone = new Label();
            lblName = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cmbCustomer = new ComboBox();
            label2 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
            lblTotal = new GroupBox();
            txtNote = new TextBox();
            txtTotal = new TextBox();
            txtDailyRate = new TextBox();
            txtNo_Days = new TextBox();
            dateTimeReturn = new DateTimePicker();
            label18 = new Label();
            lb = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            dateTimeRental = new DateTimePicker();
            groupBox3 = new GroupBox();
            cmbType = new ComboBox();
            panel2 = new Panel();
            label14 = new Label();
            lblYear = new Label();
            lblType = new Label();
            lblRate = new Label();
            lblStatus = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            cmbVehical = new ComboBox();
            label15 = new Label();
            label16 = new Label();
            groupBox2 = new GroupBox();
            btnClear = new Button();
            btnSave = new Button();
            dataGridView1 = new DataGridView();
            label17 = new Label();
            panel3 = new Panel();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            lblTotal.SuspendLayout();
            groupBox3.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { backToolStripMenuItem, refreshToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1413, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            backToolStripMenuItem.Name = "backToolStripMenuItem";
            backToolStripMenuItem.Size = new Size(54, 24);
            backToolStripMenuItem.Text = "Back";
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
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(cmbCustomer);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(30, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(712, 193);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Customer Selection";
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblLicence);
            panel1.Controls.Add(lblNIC);
            panel1.Controls.Add(lblPhone);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(6, 131);
            panel1.Name = "panel1";
            panel1.Size = new Size(696, 53);
            panel1.TabIndex = 5;
            // 
            // lblLicence
            // 
            lblLicence.AutoSize = true;
            lblLicence.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLicence.Location = new Point(489, 27);
            lblLicence.Name = "lblLicence";
            lblLicence.Size = new Size(50, 20);
            lblLicence.TabIndex = 7;
            lblLicence.Text = "label7";
            // 
            // lblNIC
            // 
            lblNIC.AutoSize = true;
            lblNIC.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNIC.Location = new Point(473, 7);
            lblNIC.Name = "lblNIC";
            lblNIC.Size = new Size(50, 20);
            lblNIC.TabIndex = 6;
            lblNIC.Text = "label7";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhone.Location = new Point(95, 27);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(50, 20);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "label7";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.Location = new Point(95, 7);
            lblName.Name = "lblName";
            lblName.Size = new Size(50, 20);
            lblName.TabIndex = 4;
            lblName.Text = "label7";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(404, 27);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 3;
            label6.Text = "|  Licence: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(404, 7);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 2;
            label5.Text = "|  NIC: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 27);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 1;
            label4.Text = "Phone: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 7);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 0;
            label3.Text = "Name: ";
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(145, 83);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(557, 28);
            cmbCustomer.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 83);
            label2.Name = "label2";
            label2.Size = new Size(93, 23);
            label2.TabIndex = 3;
            label2.Text = "Customer :";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Silver;
            txtSearch.Location = new Point(145, 42);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(246, 27);
            txtSearch.TabIndex = 2;
            txtSearch.Text = "Name or NIC...";
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = (Image)resources.GetObject("btnSearch.BackgroundImage");
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(411, 42);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 1;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 42);
            label1.Name = "label1";
            label1.Size = new Size(70, 23);
            label1.TabIndex = 0;
            label1.Text = "Search :";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.BackColor = SystemColors.Control;
            lblTotal.Controls.Add(txtNote);
            lblTotal.Controls.Add(txtTotal);
            lblTotal.Controls.Add(txtDailyRate);
            lblTotal.Controls.Add(txtNo_Days);
            lblTotal.Controls.Add(dateTimeReturn);
            lblTotal.Controls.Add(label18);
            lblTotal.Controls.Add(lb);
            lblTotal.Controls.Add(label10);
            lblTotal.Controls.Add(label9);
            lblTotal.Controls.Add(label8);
            lblTotal.Controls.Add(label7);
            lblTotal.Controls.Add(dateTimeRental);
            lblTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(765, 53);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(636, 336);
            lblTotal.TabIndex = 2;
            lblTotal.TabStop = false;
            lblTotal.Text = "Booking Details";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(197, 255);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(412, 55);
            txtNote.TabIndex = 11;
            // 
            // txtTotal
            // 
            txtTotal.BackColor = Color.FromArgb(192, 255, 192);
            txtTotal.ForeColor = Color.DarkGreen;
            txtTotal.Location = new Point(197, 212);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(134, 27);
            txtTotal.TabIndex = 10;
            // 
            // txtDailyRate
            // 
            txtDailyRate.BackColor = SystemColors.ControlLightLight;
            txtDailyRate.Location = new Point(197, 169);
            txtDailyRate.Name = "txtDailyRate";
            txtDailyRate.Size = new Size(134, 27);
            txtDailyRate.TabIndex = 9;
            // 
            // txtNo_Days
            // 
            txtNo_Days.BackColor = SystemColors.ControlLightLight;
            txtNo_Days.Location = new Point(197, 130);
            txtNo_Days.Name = "txtNo_Days";
            txtNo_Days.ReadOnly = true;
            txtNo_Days.Size = new Size(134, 27);
            txtNo_Days.TabIndex = 8;
            // 
            // dateTimeReturn
            // 
            dateTimeReturn.CustomFormat = "";
            dateTimeReturn.Format = DateTimePickerFormat.Short;
            dateTimeReturn.Location = new Point(197, 88);
            dateTimeReturn.Name = "dateTimeReturn";
            dateTimeReturn.Size = new Size(174, 27);
            dateTimeReturn.TabIndex = 7;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(134, 259);
            label18.Name = "label18";
            label18.Size = new Size(57, 23);
            label18.TabIndex = 6;
            label18.Text = "Note :";
            // 
            // lb
            // 
            lb.AutoSize = true;
            lb.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb.Location = new Point(62, 213);
            lb.Name = "lb";
            lb.Size = new Size(129, 23);
            lb.TabIndex = 5;
            lb.Text = "Est. Total (LKR) :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(53, 170);
            label10.Name = "label10";
            label10.Size = new Size(138, 23);
            label10.TabIndex = 4;
            label10.Text = "Daily Rate (LKR) :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(84, 131);
            label9.Name = "label9";
            label9.Size = new Size(107, 23);
            label9.TabIndex = 3;
            label9.Text = "No. of Days :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(47, 88);
            label8.Name = "label8";
            label8.Size = new Size(144, 23);
            label8.TabIndex = 2;
            label8.Text = "Expected Return :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(83, 51);
            label7.Name = "label7";
            label7.Size = new Size(108, 23);
            label7.TabIndex = 1;
            label7.Text = "Rental Date :";
            // 
            // dateTimeRental
            // 
            dateTimeRental.CustomFormat = "";
            dateTimeRental.Format = DateTimePickerFormat.Short;
            dateTimeRental.Location = new Point(197, 48);
            dateTimeRental.Name = "dateTimeRental";
            dateTimeRental.Size = new Size(174, 27);
            dateTimeRental.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.Control;
            groupBox3.Controls.Add(cmbType);
            groupBox3.Controls.Add(panel2);
            groupBox3.Controls.Add(cmbVehical);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label16);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(30, 266);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(712, 201);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Vehical Selection";
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(145, 41);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(246, 28);
            cmbType.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label14);
            panel2.Controls.Add(lblYear);
            panel2.Controls.Add(lblType);
            panel2.Controls.Add(lblRate);
            panel2.Controls.Add(lblStatus);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Location = new Point(6, 131);
            panel2.Name = "panel2";
            panel2.Size = new Size(696, 63);
            panel2.TabIndex = 5;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(22, 7);
            label14.Name = "label14";
            label14.Size = new Size(58, 20);
            label14.TabIndex = 8;
            label14.Text = "Status: ";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYear.Location = new Point(504, 7);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(50, 20);
            lblYear.TabIndex = 7;
            lblYear.Text = "label7";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblType.Location = new Point(313, 7);
            lblType.Name = "lblType";
            lblType.Size = new Size(50, 20);
            lblType.TabIndex = 6;
            lblType.Text = "label7";
            // 
            // lblRate
            // 
            lblRate.AutoSize = true;
            lblRate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRate.Location = new Point(104, 27);
            lblRate.Name = "lblRate";
            lblRate.Size = new Size(50, 20);
            lblRate.TabIndex = 5;
            lblRate.Text = "label7";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(82, 7);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "label7";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(438, 7);
            label11.Name = "label11";
            label11.Size = new Size(60, 20);
            label11.TabIndex = 3;
            label11.Text = "|  Year: ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(246, 7);
            label12.Name = "label12";
            label12.Size = new Size(61, 20);
            label12.TabIndex = 2;
            label12.Text = "|  Type: ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(22, 27);
            label13.Name = "label13";
            label13.Size = new Size(86, 20);
            label13.TabIndex = 1;
            label13.Text = "Daily Rate: ";
            // 
            // cmbVehical
            // 
            cmbVehical.FormattingEnabled = true;
            cmbVehical.Location = new Point(145, 83);
            cmbVehical.Name = "cmbVehical";
            cmbVehical.Size = new Size(557, 28);
            cmbVehical.TabIndex = 4;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(66, 83);
            label15.Name = "label15";
            label15.Size = new Size(73, 23);
            label15.TabIndex = 3;
            label15.Text = "Vehical :";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(46, 42);
            label16.Name = "label16";
            label16.Size = new Size(96, 23);
            label16.TabIndex = 0;
            label16.Text = "Filter Type :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnClear);
            groupBox2.Controls.Add(btnSave);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(765, 405);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(636, 78);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Actions";
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.Control;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.DodgerBlue;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Location = new Point(333, 29);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(297, 29);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderColor = Color.DodgerBlue;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.Location = new Point(23, 29);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(297, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Booking";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(36, 529);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1359, 99);
            dataGridView1.TabIndex = 5;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(43, 488);
            label17.Name = "label17";
            label17.Size = new Size(115, 20);
            label17.TabIndex = 6;
            label17.Text = "Active Booking";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DodgerBlue;
            panel3.Location = new Point(36, 511);
            panel3.Name = "panel3";
            panel3.Size = new Size(1354, 3);
            panel3.TabIndex = 7;
            // 
            // bookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1413, 640);
            Controls.Add(panel3);
            Controls.Add(label17);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(lblTotal);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "bookingForm";
            Text = "Rental Booking";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            lblTotal.ResumeLayout(false);
            lblTotal.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem backToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private GroupBox groupBox1;
        private GroupBox lblTotal;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;
        private Label label2;
        private ComboBox cmbCustomer;
        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lblLicence;
        private Label lblNIC;
        private Label lblPhone;
        private Label lblName;
        private GroupBox groupBox3;
        private Panel panel2;
        private Label lblYear;
        private Label lblType;
        private Label lblRate;
        private Label lblStatus;
        private Label label11;
        private Label label12;
        private Label label13;
        private ComboBox cmbVehical;
        private Label label15;
        private Label label16;
        private ComboBox cmbType;
        private Label label14;
        private DateTimePicker dateTimeRental;
        private DateTimePicker dateTimeReturn;
        private Label label18;
        private Label lb;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox txtTotal;
        private TextBox txtDailyRate;
        private TextBox txtNo_Days;
        private TextBox txtNote;
        private GroupBox groupBox2;
        private Button btnSave;
        private Button btnClear;
        private DataGridView dataGridView1;
        private Label label17;
        private Panel panel3;
    }
}
