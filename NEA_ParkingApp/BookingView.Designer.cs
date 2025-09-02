namespace NEA_ParkingApp
{
    partial class BookingView
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
            Edit = new Button();
            Cancel = new Button();
            Close = new Button();
            label1 = new Label();
            BookingList = new ListView();
            SuspendLayout();
            // 
            // Edit
            // 
            Edit.Location = new Point(40, 865);
            Edit.Name = "Edit";
            Edit.Size = new Size(206, 34);
            Edit.TabIndex = 1;
            Edit.Text = "Edit Booking";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(344, 865);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(206, 34);
            Cancel.TabIndex = 2;
            Cancel.Text = "Cancel Booking";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // Close
            // 
            Close.Location = new Point(436, 905);
            Close.Name = "Close";
            Close.Size = new Size(114, 34);
            Close.TabIndex = 3;
            Close.Text = "Close";
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(573, 36);
            label1.TabIndex = 4;
            label1.Text = "Here are your current bookings:";
            // 
            // BookingList
            // 
            BookingList.Location = new Point(40, 83);
            BookingList.Name = "BookingList";
            BookingList.Size = new Size(510, 755);
            BookingList.TabIndex = 5;
            BookingList.UseCompatibleStateImageBehavior = false;
            BookingList.View = View.List;
            BookingList.SelectedIndexChanged += BookingList_SelectedIndexChanged;
            // 
            // BookingView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 943);
            Controls.Add(BookingList);
            Controls.Add(label1);
            Controls.Add(Close);
            Controls.Add(Cancel);
            Controls.Add(Edit);
            Name = "BookingView";
            Text = "BookingView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Edit;
        private Button Cancel;
        private Button Close;
        private Label label1;
        private ListView BookingList;
    }
}