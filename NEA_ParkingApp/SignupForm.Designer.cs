namespace NEA_ParkingApp
{
    partial class SignupForm
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
            InstructionLabel = new Label();
            PassLabel = new Label();
            UserLabel = new Label();
            PasswordBox = new TextBox();
            UsernameBox = new TextBox();
            SurnameLabel = new Label();
            ForenameLabel = new Label();
            SurnameBox = new TextBox();
            ForenameBox = new TextBox();
            AccountTier = new ComboBox();
            TierLabel = new Label();
            ConfirmPassLabel = new Label();
            ConfirmPasswordBox = new TextBox();
            TierKeyLabel = new Label();
            TierKeyBox = new TextBox();
            SignupButton = new Button();
            ShowPassword = new LinkLabel();
            PasskeyShow = new LinkLabel();
            label1 = new Label();
            SuspendLayout();
            // 
            // InstructionLabel
            // 
            InstructionLabel.AutoSize = true;
            InstructionLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InstructionLabel.Location = new Point(43, 50);
            InstructionLabel.Name = "InstructionLabel";
            InstructionLabel.Size = new Size(852, 28);
            InstructionLabel.TabIndex = 2;
            InstructionLabel.Text = "Please fill in the following fields to create a new account:";
            InstructionLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // PassLabel
            // 
            PassLabel.AutoSize = true;
            PassLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PassLabel.Location = new Point(189, 219);
            PassLabel.Name = "PassLabel";
            PassLabel.Size = new Size(138, 28);
            PassLabel.TabIndex = 11;
            PassLabel.Text = "Password:";
            PassLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserLabel
            // 
            UserLabel.AutoSize = true;
            UserLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserLabel.Location = new Point(189, 145);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(138, 28);
            UserLabel.TabIndex = 10;
            UserLabel.Text = "Username:";
            UserLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PasswordBox
            // 
            PasswordBox.Anchor = AnchorStyles.Top;
            PasswordBox.Location = new Point(333, 220);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(395, 31);
            PasswordBox.TabIndex = 9;
            // 
            // UsernameBox
            // 
            UsernameBox.Anchor = AnchorStyles.Top;
            UsernameBox.BackColor = SystemColors.Window;
            UsernameBox.Location = new Point(333, 146);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(395, 31);
            UsernameBox.TabIndex = 8;
            // 
            // SurnameLabel
            // 
            SurnameLabel.AutoSize = true;
            SurnameLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SurnameLabel.Location = new Point(189, 503);
            SurnameLabel.Name = "SurnameLabel";
            SurnameLabel.Size = new Size(124, 28);
            SurnameLabel.TabIndex = 15;
            SurnameLabel.Text = "Surname:";
            SurnameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ForenameLabel
            // 
            ForenameLabel.AutoSize = true;
            ForenameLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForenameLabel.Location = new Point(189, 429);
            ForenameLabel.Name = "ForenameLabel";
            ForenameLabel.Size = new Size(138, 28);
            ForenameLabel.TabIndex = 14;
            ForenameLabel.Text = "Forename:";
            ForenameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SurnameBox
            // 
            SurnameBox.Anchor = AnchorStyles.Top;
            SurnameBox.Location = new Point(333, 504);
            SurnameBox.Name = "SurnameBox";
            SurnameBox.Size = new Size(395, 31);
            SurnameBox.TabIndex = 13;
            // 
            // ForenameBox
            // 
            ForenameBox.Anchor = AnchorStyles.Top;
            ForenameBox.BackColor = SystemColors.Window;
            ForenameBox.Location = new Point(333, 430);
            ForenameBox.Name = "ForenameBox";
            ForenameBox.Size = new Size(395, 31);
            ForenameBox.TabIndex = 12;
            // 
            // AccountTier
            // 
            AccountTier.FormattingEnabled = true;
            AccountTier.Items.AddRange(new object[] { "Guest", "Student", "Staff", "Admin" });
            AccountTier.Location = new Point(333, 640);
            AccountTier.Name = "AccountTier";
            AccountTier.Size = new Size(395, 33);
            AccountTier.TabIndex = 16;
            AccountTier.SelectedIndexChanged += AccountTier_SelectedIndexChanged;
            // 
            // TierLabel
            // 
            TierLabel.AutoSize = true;
            TierLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TierLabel.Location = new Point(119, 639);
            TierLabel.Name = "TierLabel";
            TierLabel.Size = new Size(194, 28);
            TierLabel.TabIndex = 17;
            TierLabel.Text = "Account Tier:";
            TierLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ConfirmPassLabel
            // 
            ConfirmPassLabel.AutoSize = true;
            ConfirmPassLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConfirmPassLabel.Location = new Point(77, 297);
            ConfirmPassLabel.Name = "ConfirmPassLabel";
            ConfirmPassLabel.Size = new Size(250, 28);
            ConfirmPassLabel.TabIndex = 19;
            ConfirmPassLabel.Text = "Confirm Password:";
            ConfirmPassLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ConfirmPasswordBox
            // 
            ConfirmPasswordBox.Anchor = AnchorStyles.Top;
            ConfirmPasswordBox.Location = new Point(333, 298);
            ConfirmPasswordBox.Name = "ConfirmPasswordBox";
            ConfirmPasswordBox.PasswordChar = '*';
            ConfirmPasswordBox.Size = new Size(395, 31);
            ConfirmPasswordBox.TabIndex = 18;
            // 
            // TierKeyLabel
            // 
            TierKeyLabel.AutoSize = true;
            TierKeyLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TierKeyLabel.Location = new Point(119, 711);
            TierKeyLabel.Name = "TierKeyLabel";
            TierKeyLabel.Size = new Size(194, 28);
            TierKeyLabel.TabIndex = 21;
            TierKeyLabel.Text = "Tier Passkey:";
            TierKeyLabel.TextAlign = ContentAlignment.MiddleCenter;
            TierKeyLabel.Visible = false;
            // 
            // TierKeyBox
            // 
            TierKeyBox.Anchor = AnchorStyles.Top;
            TierKeyBox.Location = new Point(333, 712);
            TierKeyBox.Name = "TierKeyBox";
            TierKeyBox.PasswordChar = '*';
            TierKeyBox.Size = new Size(395, 31);
            TierKeyBox.TabIndex = 20;
            TierKeyBox.Visible = false;
            // 
            // SignupButton
            // 
            SignupButton.Location = new Point(545, 793);
            SignupButton.Name = "SignupButton";
            SignupButton.Size = new Size(183, 34);
            SignupButton.TabIndex = 22;
            SignupButton.Text = "Create Account";
            SignupButton.UseVisualStyleBackColor = true;
            SignupButton.Click += SignupButton_Click;
            // 
            // ShowPassword
            // 
            ShowPassword.AutoSize = true;
            ShowPassword.Location = new Point(734, 223);
            ShowPassword.Name = "ShowPassword";
            ShowPassword.Size = new Size(56, 25);
            ShowPassword.TabIndex = 23;
            ShowPassword.TabStop = true;
            ShowPassword.Text = "Show";
            ShowPassword.LinkClicked += ShowPassword_LinkClicked;
            // 
            // PasskeyShow
            // 
            PasskeyShow.AutoSize = true;
            PasskeyShow.Location = new Point(734, 712);
            PasskeyShow.Name = "PasskeyShow";
            PasskeyShow.Size = new Size(56, 25);
            PasskeyShow.TabIndex = 24;
            PasskeyShow.TabStop = true;
            PasskeyShow.Text = "Show";
            PasskeyShow.LinkClicked += PasskeyShow_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(194, 28);
            label1.TabIndex = 25;
            label1.Text = "Tier Passkey:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Visible = false;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 965);
            Controls.Add(label1);
            Controls.Add(PasskeyShow);
            Controls.Add(ShowPassword);
            Controls.Add(SignupButton);
            Controls.Add(TierKeyLabel);
            Controls.Add(TierKeyBox);
            Controls.Add(ConfirmPassLabel);
            Controls.Add(ConfirmPasswordBox);
            Controls.Add(TierLabel);
            Controls.Add(AccountTier);
            Controls.Add(SurnameLabel);
            Controls.Add(ForenameLabel);
            Controls.Add(SurnameBox);
            Controls.Add(ForenameBox);
            Controls.Add(PassLabel);
            Controls.Add(UserLabel);
            Controls.Add(PasswordBox);
            Controls.Add(UsernameBox);
            Controls.Add(InstructionLabel);
            MaximumSize = new Size(959, 1021);
            MinimumSize = new Size(959, 1021);
            Name = "SignupForm";
            Text = "Create an Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label InstructionLabel;
        private Label PassLabel;
        private Label UserLabel;
        private TextBox PasswordBox;
        private TextBox UsernameBox;
        private Label SurnameLabel;
        private Label ForenameLabel;
        private TextBox SurnameBox;
        private TextBox ForenameBox;
        private ComboBox AccountTier;
        private Label TierLabel;
        private Label ConfirmPassLabel;
        private TextBox ConfirmPasswordBox;
        private Label TierKeyLabel;
        private TextBox TierKeyBox;
        private Button SignupButton;
        private LinkLabel ShowPassword;
        private LinkLabel PasskeyShow;
        private Label label1;
    }
}