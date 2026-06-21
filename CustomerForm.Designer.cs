namespace Vehical_Rental_Management_System
{
    partial class frmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            menuStrip1 = new MenuStrip();
            backToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvCustomer = new DataGridView();
            grpCustomer = new GroupBox();
            btnSave = new Button();
            lblPhone = new Label();
            txtPhone = new TextBox();
            txtFullName = new TextBox();
            lblFullName = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            grpCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { backToolStripMenuItem, refreshToolStripMenuItem, exportToolStripMenuItem });
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
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(66, 24);
            exportToolStripMenuItem.Text = "Export";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.Info;
            btnAdd.Location = new Point(34, 55);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 40);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "➕ Add Customer";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ControlLight;
            btnEdit.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(255, 55);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(150, 40);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏ Edit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = SystemColors.Info;
            btnDelete.Location = new Point(425, 55);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(170, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑 Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(614, 64);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(65, 23);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(685, 61);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(268, 30);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = (Image)resources.GetObject("btnSearch.BackgroundImage");
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("Segoe UI Emoji", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(987, 58);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 40);
            btnSearch.TabIndex = 6;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvCustomer
            // 
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomer.BackgroundColor = SystemColors.ControlLightLight;
            dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomer.Location = new Point(34, 121);
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.ReadOnly = true;
            dgvCustomer.RowHeadersWidth = 51;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.Size = new Size(1341, 264);
            dgvCustomer.TabIndex = 7;
            dgvCustomer.CellContentClick += dgvCustomer_CellContentClick;
            // 
            // grpCustomer
            // 
            grpCustomer.BackColor = SystemColors.ActiveCaption;
            grpCustomer.Controls.Add(btnSave);
            grpCustomer.Controls.Add(lblPhone);
            grpCustomer.Controls.Add(txtPhone);
            grpCustomer.Controls.Add(txtFullName);
            grpCustomer.Controls.Add(lblFullName);
            grpCustomer.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCustomer.Location = new Point(34, 421);
            grpCustomer.Name = "grpCustomer";
            grpCustomer.Size = new Size(1341, 169);
            grpCustomer.TabIndex = 8;
            grpCustomer.TabStop = false;
            grpCustomer.Text = "Customer Details";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Highlight;
            btnSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.Window;
            btnSave.Location = new Point(34, 103);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 9;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhone.Location = new Point(793, 50);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(63, 23);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(871, 43);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(268, 30);
            txtPhone.TabIndex = 7;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.Location = new Point(232, 43);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(329, 30);
            txtFullName.TabIndex = 6;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFullName.Location = new Point(135, 50);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 23);
            lblFullName.TabIndex = 5;
            lblFullName.Text = "Full Name:";
            // 
            // frmCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1413, 640);
            Controls.Add(grpCustomer);
            Controls.Add(dgvCustomer);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Management";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            grpCustomer.ResumeLayout(false);
            grpCustomer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem backToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvCustomer;
        private GroupBox grpCustomer;
        private Label lblFullName;
        private Button btnSave;
        private Label lblPhone;
        private TextBox txtPhone;
        private TextBox txtFullName;
    }
}