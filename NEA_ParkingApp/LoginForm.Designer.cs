namespace NEA_ParkingApp
{
    partial class LoginForm
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
            SignUpButton = new LinkLabel();
            InstructionLabel = new Label();
            UsernameBox = new TextBox();
            PasswordBox = new TextBox();
            LoginButton = new Button();
            ShowPassword = new LinkLabel();
            UserLabel = new Label();
            PassLabel = new Label();
            SuspendLayout();
            // 
            // SignUpButton
            // 
            SignUpButton.AutoSize = true;
            SignUpButton.Cursor = Cursors.Hand;
            SignUpButton.Location = new Point(271, 419);
            SignUpButton.Name = "SignUpButton";
            SignUpButton.Size = new Size(197, 25);
            SignUpButton.TabIndex = 0;
            SignUpButton.TabStop = true;
            SignUpButton.Text = "Don't have an account?";
            SignUpButton.LinkClicked += SignUpButton_LinkClicked;
            // 
            // InstructionLabel
            // 
            InstructionLabel.AutoSize = true;
            InstructionLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InstructionLabel.Location = new Point(164, 171);
            InstructionLabel.Name = "InstructionLabel";
            InstructionLabel.Size = new Size(656, 28);
            InstructionLabel.TabIndex = 1;
            InstructionLabel.Text = "Please enter your account details to continue:";
            InstructionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UsernameBox
            // 
            UsernameBox.Anchor = AnchorStyles.Top;
            UsernameBox.BackColor = SystemColors.Window;
            UsernameBox.Location = new Point(271, 291);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(395, 31);
            UsernameBox.TabIndex = 2;
            // 
            // PasswordBox
            // 
            PasswordBox.Anchor = AnchorStyles.Top;
            PasswordBox.Location = new Point(271, 365);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(395, 31);
            PasswordBox.TabIndex = 3;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(554, 414);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(112, 34);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // ShowPassword
            // 
            ShowPassword.AutoSize = true;
            ShowPassword.Location = new Point(672, 368);
            ShowPassword.Name = "ShowPassword";
            ShowPassword.Size = new Size(56, 25);
            ShowPassword.TabIndex = 5;
            ShowPassword.TabStop = true;
            ShowPassword.Text = "Show";
            ShowPassword.LinkClicked += ShowPassword_LinkClicked;
            // 
            // UserLabel
            // 
            UserLabel.AutoSize = true;
            UserLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserLabel.Location = new Point(127, 290);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(138, 28);
            UserLabel.TabIndex = 6;
            UserLabel.Text = "Username:";
            UserLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PassLabel
            // 
            PassLabel.AutoSize = true;
            PassLabel.Font = new Font("SimSun", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PassLabel.Location = new Point(127, 364);
            PassLabel.Name = "PassLabel";
            PassLabel.Size = new Size(138, 28);
            PassLabel.TabIndex = 7;
            PassLabel.Text = "Password:";
            PassLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 761);
            Controls.Add(PassLabel);
            Controls.Add(UserLabel);
            Controls.Add(ShowPassword);
            Controls.Add(LoginButton);
            Controls.Add(PasswordBox);
            Controls.Add(UsernameBox);
            Controls.Add(InstructionLabel);
            Controls.Add(SignUpButton);
            MaximumSize = new Size(959, 817);
            MinimumSize = new Size(959, 817);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel SignUpButton;
        private Label InstructionLabel;
        private TextBox UsernameBox;
        private TextBox PasswordBox;
        private Button LoginButton;
        private LinkLabel ShowPassword;
        private Label UserLabel;
        private Label PassLabel;
    }
}
