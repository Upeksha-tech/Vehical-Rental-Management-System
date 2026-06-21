namespace Vehical_Rental_Management_System
{
    partial class frmCustomer
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>Required method for Designer support.</summary>
        private void InitializeComponent()
        {
            // ── Declare all controls ──────────────────────────────────────
            menuStrip1                   = new System.Windows.Forms.MenuStrip();
            backToolStripMenuItem        = new System.Windows.Forms.ToolStripMenuItem();
            refreshToolStripMenuItem     = new System.Windows.Forms.ToolStripMenuItem();
            exportToolStripMenuItem      = new System.Windows.Forms.ToolStripMenuItem();

            pnlToolbar                   = new System.Windows.Forms.Panel();
            btnAdd                       = new System.Windows.Forms.Button();
            btnEdit                      = new System.Windows.Forms.Button();
            btnDelete                    = new System.Windows.Forms.Button();
            lblSearch                    = new System.Windows.Forms.Label();
            txtSearch                    = new System.Windows.Forms.TextBox();
            btnSearch                    = new System.Windows.Forms.Button();

            pnlMain                      = new System.Windows.Forms.Panel();
            dgvCustomer                  = new System.Windows.Forms.DataGridView();
            pnlDetails                   = new System.Windows.Forms.Panel();
            lblDetailsTitle              = new System.Windows.Forms.Label();
            divider                      = new System.Windows.Forms.Panel();

            lblFullName                  = new System.Windows.Forms.Label();
            txtFullName                  = new System.Windows.Forms.TextBox();
            lblNIC                       = new System.Windows.Forms.Label();
            txtNIC                       = new System.Windows.Forms.TextBox();
            lblPhone                     = new System.Windows.Forms.Label();
            txtPhone                     = new System.Windows.Forms.TextBox();
            lblAddress                   = new System.Windows.Forms.Label();
            txtAddress                   = new System.Windows.Forms.TextBox();
            lblLicense                   = new System.Windows.Forms.Label();
            txtLicense                   = new System.Windows.Forms.TextBox();
            lblRegistered                = new System.Windows.Forms.Label();
            txtRegistered                = new System.Windows.Forms.TextBox();
            lblActiveTitle               = new System.Windows.Forms.Label();
            lblfillActive                = new System.Windows.Forms.Label();
            btnSave                      = new System.Windows.Forms.Button();

            pnlHeader                    = new System.Windows.Forms.Panel();
            lblTitle                     = new System.Windows.Forms.Label();
            lblSubtitle                  = new System.Windows.Forms.Label();

            // ── Suspend layout ────────────────────────────────────────────
            menuStrip1.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            pnlDetails.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();

            // ─────────────────────────────────────────────────────────────
            // menuStrip1
            // ─────────────────────────────────────────────────────────────
            menuStrip1.BackColor         = System.Drawing.Color.FromArgb(30, 33, 48);
            menuStrip1.ForeColor         = System.Drawing.Color.White;
            menuStrip1.Font              = new System.Drawing.Font("Segoe UI", 10F);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                { backToolStripMenuItem, refreshToolStripMenuItem, exportToolStripMenuItem });
            menuStrip1.Location          = new System.Drawing.Point(0, 0);
            menuStrip1.Name              = "menuStrip1";
            menuStrip1.Size              = new System.Drawing.Size(1280, 30);
            menuStrip1.Renderer          = new System.Windows.Forms.ToolStripProfessionalRenderer(
                new MenuColorTable());

            // ← Back
            backToolStripMenuItem.Name       = "backToolStripMenuItem";
            backToolStripMenuItem.Text       = "← Back";
            backToolStripMenuItem.ForeColor  = System.Drawing.Color.White;

            // 🔄 Refresh
            refreshToolStripMenuItem.Name      = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Text      = "🔄 Refresh";
            refreshToolStripMenuItem.ForeColor = System.Drawing.Color.White;

            // 📤 Export
            exportToolStripMenuItem.Name      = "exportToolStripMenuItem";
            exportToolStripMenuItem.Text      = "📤 Export CSV";
            exportToolStripMenuItem.ForeColor = System.Drawing.Color.White;

            // ─────────────────────────────────────────────────────────────
            // pnlHeader  (blue-gray gradient header bar)
            // ─────────────────────────────────────────────────────────────
            pnlHeader.BackColor     = System.Drawing.Color.FromArgb(43, 54, 80);
            pnlHeader.Location      = new System.Drawing.Point(0, 30);
            pnlHeader.Name          = "pnlHeader";
            pnlHeader.Size          = new System.Drawing.Size(1280, 72);
            pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[]
                { lblTitle, lblSubtitle });

            lblTitle.AutoSize  = true;
            lblTitle.Location  = new System.Drawing.Point(20, 10);
            lblTitle.Name      = "lblTitle";
            lblTitle.Text      = "👥  Customer Management";
            lblTitle.Font      = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;

            lblSubtitle.AutoSize  = true;
            lblSubtitle.Location  = new System.Drawing.Point(22, 46);
            lblSubtitle.Name      = "lblSubtitle";
            lblSubtitle.Text      = "Add, edit, and manage your customer database";
            lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(190, 200, 220);

            // ─────────────────────────────────────────────────────────────
            // pnlToolbar
            // ─────────────────────────────────────────────────────────────
            pnlToolbar.BackColor   = System.Drawing.Color.FromArgb(245, 247, 250);
            pnlToolbar.Location    = new System.Drawing.Point(0, 102);
            pnlToolbar.Name        = "pnlToolbar";
            pnlToolbar.Size        = new System.Drawing.Size(1280, 64);
            pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[]
                { btnAdd, btnEdit, btnDelete, lblSearch, txtSearch, btnSearch });

            // btnAdd
            btnAdd.BackColor        = System.Drawing.Color.FromArgb(30, 120, 220);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.Font             = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            btnAdd.ForeColor        = System.Drawing.Color.White;
            btnAdd.Location         = new System.Drawing.Point(14, 12);
            btnAdd.Name             = "btnAdd";
            btnAdd.Size             = new System.Drawing.Size(165, 40);
            btnAdd.Text             = "➕  Add Customer";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Cursor           = System.Windows.Forms.Cursors.Hand;
            btnAdd.Click           += btnAdd_Click;

            // btnEdit
            btnEdit.BackColor       = System.Drawing.Color.FromArgb(224, 228, 238);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle       = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Font            = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            btnEdit.ForeColor       = System.Drawing.Color.FromArgb(33, 37, 41);
            btnEdit.Location        = new System.Drawing.Point(188, 12);
            btnEdit.Name            = "btnEdit";
            btnEdit.Size            = new System.Drawing.Size(110, 40);
            btnEdit.Text            = "✏  Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Cursor          = System.Windows.Forms.Cursors.Hand;

            // btnDelete
            btnDelete.BackColor     = System.Drawing.Color.FromArgb(214, 40, 57);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Font          = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            btnDelete.ForeColor     = System.Drawing.Color.White;
            btnDelete.Location      = new System.Drawing.Point(308, 12);
            btnDelete.Name          = "btnDelete";
            btnDelete.Size          = new System.Drawing.Size(110, 40);
            btnDelete.Text          = "🗑  Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Cursor        = System.Windows.Forms.Cursors.Hand;

            // lblSearch
            lblSearch.AutoSize  = true;
            lblSearch.Font      = new System.Drawing.Font("Segoe UI", 10F);
            lblSearch.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            lblSearch.Location  = new System.Drawing.Point(832, 22);
            lblSearch.Name      = "lblSearch";
            lblSearch.Text      = "Search:";

            // txtSearch
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Font        = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.Location    = new System.Drawing.Point(896, 19);
            txtSearch.Name        = "txtSearch";
            txtSearch.Size        = new System.Drawing.Size(230, 28);

            // btnSearch
            btnSearch.BackColor   = System.Drawing.Color.FromArgb(224, 228, 238);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle   = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font        = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            btnSearch.ForeColor   = System.Drawing.Color.FromArgb(33, 37, 41);
            btnSearch.Location    = new System.Drawing.Point(1136, 15);
            btnSearch.Name        = "btnSearch";
            btnSearch.Size        = new System.Drawing.Size(110, 36);
            btnSearch.Text        = "🔍  Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Cursor      = System.Windows.Forms.Cursors.Hand;

            // ─────────────────────────────────────────────────────────────
            // pnlMain  (holds dgvCustomer on the left, pnlDetails on right)
            // ─────────────────────────────────────────────────────────────
            pnlMain.BackColor   = System.Drawing.Color.FromArgb(240, 243, 248);
            pnlMain.Location    = new System.Drawing.Point(0, 166);
            pnlMain.Name        = "pnlMain";
            pnlMain.Size        = new System.Drawing.Size(1280, 620);
            pnlMain.Controls.AddRange(new System.Windows.Forms.Control[]
                { dgvCustomer, pnlDetails });

            // ─────────────────────────────────────────────────────────────
            // dgvCustomer
            // ─────────────────────────────────────────────────────────────
            dgvCustomer.BackgroundColor             = System.Drawing.Color.White;
            dgvCustomer.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCustomer.Location                    = new System.Drawing.Point(14, 14);
            dgvCustomer.Name                        = "dgvCustomer";
            dgvCustomer.RowHeadersWidth             = 51;
            dgvCustomer.Size                        = new System.Drawing.Size(820, 590);
            dgvCustomer.TabIndex                    = 10;
            dgvCustomer.ReadOnly                    = true;
            dgvCustomer.MultiSelect                 = false;
            dgvCustomer.CellContentClick           += dgvCustomer_CellContentClick;

            // ─────────────────────────────────────────────────────────────
            // pnlDetails  (right-hand customer info panel)
            // ─────────────────────────────────────────────────────────────
            pnlDetails.BackColor   = System.Drawing.Color.White;
            pnlDetails.Location    = new System.Drawing.Point(848, 14);
            pnlDetails.Name        = "pnlDetails";
            pnlDetails.Size        = new System.Drawing.Size(418, 590);
            pnlDetails.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblDetailsTitle, divider,
                lblFullName, txtFullName,
                lblNIC, txtNIC,
                lblPhone, txtPhone,
                lblAddress, txtAddress,
                lblLicense, txtLicense,
                lblRegistered, txtRegistered,
                lblActiveTitle, lblfillActive,
                btnSave
            });

            // Section header
            lblDetailsTitle.AutoSize  = true;
            lblDetailsTitle.Location  = new System.Drawing.Point(16, 16);
            lblDetailsTitle.Name      = "lblDetailsTitle";
            lblDetailsTitle.Text      = "CUSTOMER DETAILS";
            lblDetailsTitle.Font      = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(100, 110, 130);

            divider.BackColor  = System.Drawing.Color.FromArgb(220, 223, 230);
            divider.Location   = new System.Drawing.Point(16, 38);
            divider.Name       = "divider";
            divider.Size       = new System.Drawing.Size(386, 1);

            // Full Name
            AddLabel(lblFullName,   "Full Name *",     16,  52, pnlDetails);
            AddTextBox(txtFullName, "txtFullName",      16,  74, 386, pnlDetails);

            // NIC
            AddLabel(lblNIC,        "NIC Number *",    16, 118, pnlDetails);
            AddTextBox(txtNIC,      "txtNIC",           16, 140, 386, pnlDetails);

            // Phone
            AddLabel(lblPhone,      "Phone *",         16, 184, pnlDetails);
            AddTextBox(txtPhone,    "txtPhone",         16, 206, 386, pnlDetails);

            // Address
            AddLabel(lblAddress,    "Address *",       16, 250, pnlDetails);
            AddTextBox(txtAddress,  "txtAddress",       16, 272, 386, pnlDetails);

            // License
            AddLabel(lblLicense,    "License Number *",16, 316, pnlDetails);
            AddTextBox(txtLicense,  "txtLicense",       16, 338, 386, pnlDetails);

            // Date Registered
            AddLabel(lblRegistered, "Date Registered", 16, 382, pnlDetails);
            AddTextBox(txtRegistered,"txtRegistered",   16, 404, 386, pnlDetails);
            txtRegistered.PlaceholderText = "yyyy-MM-dd";

            // Active Rentals
            lblActiveTitle.AutoSize  = true;
            lblActiveTitle.Location  = new System.Drawing.Point(16, 448);
            lblActiveTitle.Name      = "lblActiveTitle";
            lblActiveTitle.Text      = "Active Rentals:";
            lblActiveTitle.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            lblActiveTitle.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);

            lblfillActive.AutoSize  = true;
            lblfillActive.Location  = new System.Drawing.Point(140, 448);
            lblfillActive.Name      = "lblfillActive";
            lblfillActive.Text      = "0 active rental";
            lblfillActive.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            lblfillActive.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);

            // btnSave
            btnSave.BackColor        = System.Drawing.Color.FromArgb(30, 170, 100);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            btnSave.Font             = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            btnSave.ForeColor        = System.Drawing.Color.White;
            btnSave.Location         = new System.Drawing.Point(16, 530);
            btnSave.Name             = "btnSave";
            btnSave.Size             = new System.Drawing.Size(386, 44);
            btnSave.Text             = "💾  Save Customer";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Cursor           = System.Windows.Forms.Cursors.Hand;
            btnSave.Enabled          = false;
            btnSave.Click           += btnSave_Click;

            // ─────────────────────────────────────────────────────────────
            // frmCustomer
            // ─────────────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            BackColor           = System.Drawing.Color.FromArgb(240, 243, 248);
            ClientSize          = new System.Drawing.Size(1280, 800);
            Controls.AddRange(new System.Windows.Forms.Control[]
                { pnlMain, pnlToolbar, pnlHeader, menuStrip1 });
            MainMenuStrip  = menuStrip1;
            MinimumSize    = new System.Drawing.Size(1100, 720);
            Name           = "frmCustomer";
            StartPosition  = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text           = "Customer Management";
            Font           = new System.Drawing.Font("Segoe UI", 9.5F);
            Load          += frmCustomer_Load;

            // ── Resume layout ────────────────────────────────────────────
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            pnlDetails.ResumeLayout(false);
            pnlDetails.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        // ── Helper: add a styled Label ────────────────────────────────────
        private static void AddLabel(System.Windows.Forms.Label lbl, string text, int x, int y,
            System.Windows.Forms.Control parent)
        {
            lbl.AutoSize  = true;
            lbl.Location  = new System.Drawing.Point(x, y);
            lbl.Text      = text;
            lbl.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            lbl.ForeColor = System.Drawing.Color.FromArgb(80, 90, 110);
            parent.Controls.Add(lbl);
        }

        // ── Helper: add a styled TextBox ─────────────────────────────────
        private static void AddTextBox(System.Windows.Forms.TextBox tb, string name, int x, int y, int w,
            System.Windows.Forms.Control parent)
        {
            tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tb.Font        = new System.Drawing.Font("Segoe UI", 10.5F);
            tb.Location    = new System.Drawing.Point(x, y);
            tb.Name        = name;
            tb.Size        = new System.Drawing.Size(w, 30);
            tb.ReadOnly    = true;
            tb.BackColor   = System.Drawing.Color.FromArgb(240, 242, 245);
            parent.Controls.Add(tb);
        }

        #endregion

        // ── Control declarations ──────────────────────────────────────────
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label  lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvCustomer;

        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Panel divider;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblNIC;
        private System.Windows.Forms.TextBox txtNIC;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Label lblRegistered;
        private System.Windows.Forms.TextBox txtRegistered;
        private System.Windows.Forms.Label lblActiveTitle;
        private System.Windows.Forms.Label lblfillActive;
        private System.Windows.Forms.Button btnSave;
    }

    // ── Custom menu colour table (dark theme menu bar) ────────────────────
    internal class MenuColorTable : System.Windows.Forms.ProfessionalColorTable
    {
        public override System.Drawing.Color MenuItemSelected =>
            System.Drawing.Color.FromArgb(60, 72, 100);
        public override System.Drawing.Color MenuItemBorder =>
            System.Drawing.Color.FromArgb(60, 72, 100);
        public override System.Drawing.Color MenuItemSelectedGradientBegin =>
            System.Drawing.Color.FromArgb(60, 72, 100);
        public override System.Drawing.Color MenuItemSelectedGradientEnd =>
            System.Drawing.Color.FromArgb(60, 72, 100);
        public override System.Drawing.Color MenuStripGradientBegin =>
            System.Drawing.Color.FromArgb(30, 33, 48);
        public override System.Drawing.Color MenuStripGradientEnd =>
            System.Drawing.Color.FromArgb(30, 33, 48);
    }
}