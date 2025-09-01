namespace NEA_ParkingApp
{
    partial class BookingCreationForm
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
            DatePicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            StartTimePicker = new DateTimePicker();
            EndTimePicker = new DateTimePicker();
            AvailableSpaces = new ListBox();
            FindSpaces = new Button();
            SelectedSpace = new Label();
            ViewSpaceButton = new Button();
            CreateBooking = new Button();
            CloseButton = new Button();
            SuspendLayout();
            // 
            // DatePicker
            // 
            DatePicker.Location = new Point(304, 51);
            DatePicker.Name = "DatePicker";
            DatePicker.ShowUpDown = true;
            DatePicker.Size = new Size(227, 31);
            DatePicker.TabIndex = 0;
            DatePicker.Value = new DateTime(2025, 8, 22, 21, 13, 13, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 15F);
            label1.Location = new Point(32, 50);
            label1.Name = "label1";
            label1.Size = new Size(208, 30);
            label1.TabIndex = 1;
            label1.Text = "Booking Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SimSun", 15F);
            label2.Location = new Point(32, 113);
            label2.Name = "label2";
            label2.Size = new Size(208, 30);
            label2.TabIndex = 2;
            label2.Text = "Arrival Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SimSun", 15F);
            label3.Location = new Point(32, 180);
            label3.Name = "label3";
            label3.Size = new Size(238, 30);
            label3.TabIndex = 3;
            label3.Text = "Departure Time:";
            // 
            // StartTimePicker
            // 
            StartTimePicker.CustomFormat = "HH:mm";
            StartTimePicker.Format = DateTimePickerFormat.Custom;
            StartTimePicker.Location = new Point(304, 114);
            StartTimePicker.Name = "StartTimePicker";
            StartTimePicker.ShowUpDown = true;
            StartTimePicker.Size = new Size(143, 31);
            StartTimePicker.TabIndex = 4;
            StartTimePicker.Value = new DateTime(2025, 8, 22, 21, 13, 13, 0);
            // 
            // EndTimePicker
            // 
            EndTimePicker.CustomFormat = "HH:mm";
            EndTimePicker.Format = DateTimePickerFormat.Custom;
            EndTimePicker.Location = new Point(304, 179);
            EndTimePicker.Name = "EndTimePicker";
            EndTimePicker.ShowUpDown = true;
            EndTimePicker.Size = new Size(143, 31);
            EndTimePicker.TabIndex = 5;
            EndTimePicker.Value = new DateTime(2025, 8, 22, 21, 25, 26, 0);
            // 
            // AvailableSpaces
            // 
            AvailableSpaces.AccessibleName = "";
            AvailableSpaces.FormattingEnabled = true;
            AvailableSpaces.ItemHeight = 25;
            AvailableSpaces.Location = new Point(32, 278);
            AvailableSpaces.Name = "AvailableSpaces";
            AvailableSpaces.ScrollAlwaysVisible = true;
            AvailableSpaces.Size = new Size(564, 404);
            AvailableSpaces.TabIndex = 6;
            AvailableSpaces.SelectedIndexChanged += AvailableSpaces_SelectedIndexChanged;
            // 
            // FindSpaces
            // 
            FindSpaces.Location = new Point(377, 238);
            FindSpaces.Name = "FindSpaces";
            FindSpaces.Size = new Size(219, 34);
            FindSpaces.TabIndex = 7;
            FindSpaces.Text = "Find Available Spaces";
            FindSpaces.UseVisualStyleBackColor = true;
            FindSpaces.Click += FindSpaces_Click;
            // 
            // SelectedSpace
            // 
            SelectedSpace.AutoSize = true;
            SelectedSpace.Font = new Font("SimSun", 15F);
            SelectedSpace.Location = new Point(32, 725);
            SelectedSpace.Name = "SelectedSpace";
            SelectedSpace.Size = new Size(313, 30);
            SelectedSpace.TabIndex = 8;
            SelectedSpace.Text = "Selected Space: None";
            // 
            // ViewSpaceButton
            // 
            ViewSpaceButton.Location = new Point(411, 721);
            ViewSpaceButton.Name = "ViewSpaceButton";
            ViewSpaceButton.Size = new Size(185, 34);
            ViewSpaceButton.TabIndex = 9;
            ViewSpaceButton.Text = "View Space";
            ViewSpaceButton.UseVisualStyleBackColor = true;
            ViewSpaceButton.Visible = false;
            ViewSpaceButton.Click += ViewSpaceButton_Click;
            // 
            // CreateBooking
            // 
            CreateBooking.Location = new Point(411, 1040);
            CreateBooking.Name = "CreateBooking";
            CreateBooking.Size = new Size(185, 34);
            CreateBooking.TabIndex = 10;
            CreateBooking.Text = "Book Space";
            CreateBooking.UseVisualStyleBackColor = true;
            CreateBooking.Click += CreateBooking_Click;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(602, 1040);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(185, 34);
            CloseButton.TabIndex = 11;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // BookingCreationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 1138);
            Controls.Add(CloseButton);
            Controls.Add(CreateBooking);
            Controls.Add(ViewSpaceButton);
            Controls.Add(SelectedSpace);
            Controls.Add(FindSpaces);
            Controls.Add(AvailableSpaces);
            Controls.Add(EndTimePicker);
            Controls.Add(StartTimePicker);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DatePicker);
            Name = "BookingCreationForm";
            Text = "BookingCreationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker DatePicker;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker StartTimePicker;
        private DateTimePicker EndTimePicker;
        private ListBox AvailableSpaces;
        private Button FindSpaces;
        private Label SelectedSpace;
        private Button ViewSpaceButton;
        private Button CreateBooking;
        private Button CloseButton;
    }
}