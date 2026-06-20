namespace Vehical_Rental_Management_System
{
    partial class LoginForm
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
            pnlCard           = new Panel();
            picLogo           = new PictureBox();
            lblTitle          = new Label();
            lblSubtitle       = new Label();
            lblDividerTop     = new Label();
            lblUsername       = new Label();
            txtUsername       = new TextBox();
            lblPassword       = new Label();
            txtPassword       = new TextBox();
            lblRole           = new Label();
            cmbRole           = new ComboBox();
            lblDividerBottom  = new Label();
            btnLogin          = new Button();
            btnClear          = new Button();
            lblFooter         = new Label();
            lblAttemptsWarn   = new Label();

            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();

            // ──────────────────────────────────────────
            // pnlCard  – white rounded card in the center
            // ──────────────────────────────────────────
            pnlCard.BackColor   = Color.White;
            pnlCard.BorderStyle = BorderStyle.None;
            pnlCard.Location    = new Point(200, 30);
            pnlCard.Name        = "pnlCard";
            pnlCard.Size        = new Size(400, 490);
            pnlCard.TabIndex    = 0;
            pnlCard.Paint      += pnlCard_Paint;

            pnlCard.Controls.Add(picLogo);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblDividerTop);
            pnlCard.Controls.Add(lblUsername);
            pnlCard.Controls.Add(txtUsername);
            pnlCard.Controls.Add(lblPassword);
            pnlCard.Controls.Add(txtPassword);
            pnlCard.Controls.Add(lblRole);
            pnlCard.Controls.Add(cmbRole);
            pnlCard.Controls.Add(lblDividerBottom);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Controls.Add(btnClear);
            pnlCard.Controls.Add(lblFooter);
            pnlCard.Controls.Add(lblAttemptsWarn);

            // ──────────────────────────────────────────
            // picLogo
            // ──────────────────────────────────────────
            picLogo.Image    = Properties.Resources.Car;
            picLogo.Location = new Point(136, 18);
            picLogo.Name     = "picLogo";
            picLogo.Size     = new Size(128, 72);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop  = false;

            // ──────────────────────────────────────────
            // lblTitle
            // ──────────────────────────────────────────
            lblTitle.AutoSize  = true;
            lblTitle.BackColor  = Color.Transparent;
            lblTitle.Font       = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor  = Color.FromArgb(30, 30, 30);
            lblTitle.Location   = new Point(90, 96);
            lblTitle.Name       = "lblTitle";
            lblTitle.Text       = "Vehicle Rental";
            lblTitle.TabIndex   = 1;

            // ──────────────────────────────────────────
            // lblSubtitle  (two-line: "Management System")
            // ──────────────────────────────────────────
            lblSubtitle           = new Label();
            lblSubtitle.AutoSize  = true;
            lblSubtitle.BackColor  = Color.Transparent;
            lblSubtitle.Font       = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSubtitle.ForeColor  = Color.FromArgb(30, 30, 30);
            lblSubtitle.Location   = new Point(83, 126);
            lblSubtitle.Name       = "lblSubtitle";
            lblSubtitle.Text       = "Management System";
            lblSubtitle.TabIndex   = 2;

            // ──────────────────────────────────────────
            // lblUniversity  (gray)
            // ──────────────────────────────────────────
            lblSubtitle.ForeColor = Color.FromArgb(50, 50, 50);

            Label lblUniversity       = new Label();
            lblUniversity.AutoSize   = true;
            lblUniversity.BackColor   = Color.Transparent;
            lblUniversity.Font        = new Font("Segoe UI", 8F, FontStyle.Regular);
            lblUniversity.ForeColor   = Color.Gray;
            lblUniversity.Location    = new Point(56, 154);
            lblUniversity.Name        = "lblUniversity";
            lblUniversity.Text        = "University of Kelaniya \u2013 Offline Desktop App";
            lblUniversity.TabIndex    = 3;
            pnlCard.Controls.Add(lblUniversity);

            // ──────────────────────────────────────────
            // lblDividerTop  (horizontal rule)
            // ──────────────────────────────────────────
            lblDividerTop.AutoSize  = false;
            lblDividerTop.BackColor = Color.FromArgb(220, 220, 225);
            lblDividerTop.Location  = new Point(30, 182);
            lblDividerTop.Name      = "lblDividerTop";
            lblDividerTop.Size      = new Size(340, 2);
            lblDividerTop.TabIndex  = 4;

            // ──────────────────────────────────────────
            // lblUsername
            // ──────────────────────────────────────────
            lblUsername.AutoSize  = true;
            lblUsername.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(55, 55, 55);
            lblUsername.Location  = new Point(32, 200);
            lblUsername.Name      = "lblUsername";
            lblUsername.Text      = "Username";
            lblUsername.TabIndex  = 5;

            // ──────────────────────────────────────────
            // txtUsername
            // ──────────────────────────────────────────
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font        = new Font("Segoe UI", 10F);
            txtUsername.Location    = new Point(140, 197);
            txtUsername.Name        = "txtUsername";
            txtUsername.Size        = new Size(215, 27);
            txtUsername.TabIndex    = 0;

            // ──────────────────────────────────────────
            // lblPassword
            // ──────────────────────────────────────────
            lblPassword.AutoSize  = true;
            lblPassword.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(55, 55, 55);
            lblPassword.Location  = new Point(32, 242);
            lblPassword.Name      = "lblPassword";
            lblPassword.Text      = "Password";
            lblPassword.TabIndex  = 6;

            // ──────────────────────────────────────────
            // txtPassword
            // ──────────────────────────────────────────
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font        = new Font("Segoe UI", 10F);
            txtPassword.Location    = new Point(140, 239);
            txtPassword.Name        = "txtPassword";
            txtPassword.PasswordChar = '\u2022'; // bullet character
            txtPassword.Size        = new Size(215, 27);
            txtPassword.TabIndex    = 1;

            // ──────────────────────────────────────────
            // lblRole
            // ──────────────────────────────────────────
            lblRole.AutoSize  = true;
            lblRole.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(55, 55, 55);
            lblRole.Location  = new Point(32, 286);
            lblRole.Name      = "lblRole";
            lblRole.Text      = "Role";
            lblRole.TabIndex  = 7;

            // ──────────────────────────────────────────
            // cmbRole
            // ──────────────────────────────────────────
            cmbRole.DropDownStyle    = ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle        = FlatStyle.Flat;
            cmbRole.Font             = new Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Manager", "Staff", "Viewer" });
            cmbRole.Location         = new Point(140, 282);
            cmbRole.Name             = "cmbRole";
            cmbRole.Size             = new Size(215, 27);
            cmbRole.TabIndex         = 2;

            // ──────────────────────────────────────────
            // lblDividerBottom
            // ──────────────────────────────────────────
            lblDividerBottom.AutoSize  = false;
            lblDividerBottom.BackColor = Color.FromArgb(220, 220, 225);
            lblDividerBottom.Location  = new Point(30, 322);
            lblDividerBottom.Name      = "lblDividerBottom";
            lblDividerBottom.Size      = new Size(340, 2);
            lblDividerBottom.TabIndex  = 8;

            // ──────────────────────────────────────────
            // lblAttemptsWarn
            // ──────────────────────────────────────────
            lblAttemptsWarn.AutoSize  = true;
            lblAttemptsWarn.Font      = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblAttemptsWarn.ForeColor = Color.Firebrick;
            lblAttemptsWarn.Location  = new Point(32, 330);
            lblAttemptsWarn.Name      = "lblAttemptsWarn";
            lblAttemptsWarn.Text      = "";
            lblAttemptsWarn.TabIndex  = 9;

            // ──────────────────────────────────────────
            // btnLogin  (blue filled)
            // ──────────────────────────────────────────
            btnLogin.BackColor         = Color.FromArgb(30, 115, 200);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle         = FlatStyle.Flat;
            btnLogin.Font              = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor         = Color.White;
            btnLogin.Location          = new Point(32, 360);
            btnLogin.Name              = "btnLogin";
            btnLogin.Size              = new Size(155, 42);
            btnLogin.TabIndex          = 3;
            btnLogin.Text              = "\uD83D\uDD13  Login";      // lock emoji + text
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Cursor            = Cursors.Hand;
            btnLogin.Click            += btnLogin_Click;

            // ──────────────────────────────────────────
            // btnClear  (light/outline style)
            // ──────────────────────────────────────────
            btnClear.BackColor         = Color.FromArgb(240, 242, 246);
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 205);
            btnClear.FlatAppearance.BorderSize  = 1;
            btnClear.FlatStyle         = FlatStyle.Flat;
            btnClear.Font              = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor         = Color.FromArgb(60, 60, 60);
            btnClear.Location          = new Point(210, 360);
            btnClear.Name              = "btnClear";
            btnClear.Size              = new Size(155, 42);
            btnClear.TabIndex          = 4;
            btnClear.Text              = "\u21BA  Clear";            // refresh arrow + text
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Cursor            = Cursors.Hand;
            btnClear.Click            += btnClear_Click;

            // ──────────────────────────────────────────
            // lblFooter
            // ──────────────────────────────────────────
            lblFooter.AutoSize  = true;
            lblFooter.BackColor = Color.Transparent;
            lblFooter.Font      = new Font("Segoe UI", 7.5F);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.Location  = new Point(110, 455);
            lblFooter.Name      = "lblFooter";
            lblFooter.Text      = "VehicleRentalDB \u2022 LocalDB";
            lblFooter.TabIndex  = 10;

            // ──────────────────────────────────────────
            // LoginForm  (the Form itself)
            // ──────────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(235, 238, 245);
            ClientSize          = new Size(800, 550);
            Controls.Add(pnlCard);
            FormBorderStyle     = FormBorderStyle.FixedSingle;
            MaximizeBox         = false;
            Name                = "LoginForm";
            StartPosition       = FormStartPosition.CenterScreen;
            Text                = "Vehicle Rental Management System - Login";
            Load               += LoginForm_Load;

            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // ── Control declarations ──────────────────────────────────────────────
        private Panel    pnlCard;
        private PictureBox picLogo;
        private Label    lblTitle;
        private Label    lblSubtitle;
        private Label    lblDividerTop;
        private Label    lblUsername;
        private TextBox  txtUsername;
        private Label    lblPassword;
        private TextBox  txtPassword;
        private Label    lblRole;
        private ComboBox cmbRole;
        private Label    lblDividerBottom;
        private Button   btnLogin;
        private Button   btnClear;
        private Label    lblFooter;
        private Label    lblAttemptsWarn;
    }
}