namespace NEA_ParkingApp
{
    partial class VirtualMap
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
            panel4 = new Panel();
            MapPanel = new Panel();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.Location = new Point(0, 599);
            panel4.Name = "panel4";
            panel4.Size = new Size(1562, 523);
            panel4.TabIndex = 2;
            // 
            // MapPanel
            // 
            MapPanel.AutoScroll = true;
            MapPanel.Location = new Point(0, -1);
            MapPanel.Name = "MapPanel";
            MapPanel.Size = new Size(2204, 1446);
            MapPanel.TabIndex = 3;
            MapPanel.Paint += MapPanel_Paint;
            // 
            // VirtualMap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(2202, 1445);
            Controls.Add(panel4);
            Controls.Add(MapPanel);
            Name = "VirtualMap";
            Text = "VirtualMap";
            ResumeLayout(false);
        }

        #endregion
        private Panel panel4;
        private Panel MapPanel;
    }
}