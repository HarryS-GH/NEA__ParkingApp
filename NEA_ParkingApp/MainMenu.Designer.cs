namespace NEA_ParkingApp
{
    partial class MainMenu
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
            WelcomeLabel = new Label();
            ProfileLink = new LinkLabel();
            BookingCreate = new LinkLabel();
            ViewBookings = new LinkLabel();
            MapButton = new LinkLabel();
            LogoutLink = new LinkLabel();
            SuspendLayout();
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.AutoSize = true;
            WelcomeLabel.Font = new Font("SimSun", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WelcomeLabel.Location = new Point(21, 23);
            WelcomeLabel.Name = "WelcomeLabel";
            WelcomeLabel.Size = new Size(231, 36);
            WelcomeLabel.TabIndex = 0;
            WelcomeLabel.Text = "Hello, User!";
            // 
            // ProfileLink
            // 
            ProfileLink.AutoSize = true;
            ProfileLink.Location = new Point(935, 23);
            ProfileLink.Name = "ProfileLink";
            ProfileLink.Size = new Size(92, 25);
            ProfileLink.TabIndex = 1;
            ProfileLink.TabStop = true;
            ProfileLink.Text = "My Profile";
            // 
            // BookingCreate
            // 
            BookingCreate.AutoSize = true;
            BookingCreate.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BookingCreate.Location = new Point(21, 117);
            BookingCreate.Name = "BookingCreate";
            BookingCreate.Size = new Size(228, 38);
            BookingCreate.TabIndex = 2;
            BookingCreate.TabStop = true;
            BookingCreate.Text = "Create a Booking";
            BookingCreate.LinkClicked += BookingCreate_LinkClicked;
            // 
            // ViewBookings
            // 
            ViewBookings.AutoSize = true;
            ViewBookings.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ViewBookings.Location = new Point(21, 209);
            ViewBookings.Name = "ViewBookings";
            ViewBookings.Size = new Size(243, 38);
            ViewBookings.TabIndex = 3;
            ViewBookings.TabStop = true;
            ViewBookings.Text = "View my Bookings";
            ViewBookings.LinkClicked += ViewBookings_LinkClicked;
            // 
            // MapButton
            // 
            MapButton.AutoSize = true;
            MapButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MapButton.Location = new Point(21, 312);
            MapButton.Name = "MapButton";
            MapButton.Size = new Size(227, 38);
            MapButton.TabIndex = 4;
            MapButton.TabStop = true;
            MapButton.Text = "View Virtual Map";
            MapButton.LinkClicked += MapButton_LinkClicked;
            // 
            // LogoutLink
            // 
            LogoutLink.AutoSize = true;
            LogoutLink.Font = new Font("Segoe UI", 12F);
            LogoutLink.Location = new Point(21, 760);
            LogoutLink.Name = "LogoutLink";
            LogoutLink.Size = new Size(100, 32);
            LogoutLink.TabIndex = 5;
            LogoutLink.TabStop = true;
            LogoutLink.Text = "Log Out";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 808);
            Controls.Add(LogoutLink);
            Controls.Add(MapButton);
            Controls.Add(ViewBookings);
            Controls.Add(BookingCreate);
            Controls.Add(ProfileLink);
            Controls.Add(WelcomeLabel);
            MaximumSize = new Size(1061, 864);
            MinimumSize = new Size(1061, 864);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label WelcomeLabel;
        private LinkLabel ProfileLink;
        private LinkLabel BookingCreate;
        private LinkLabel ViewBookings;
        private LinkLabel MapButton;
        private LinkLabel LogoutLink;
    }
}