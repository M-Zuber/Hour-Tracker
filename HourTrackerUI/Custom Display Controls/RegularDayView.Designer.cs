namespace HourTrackerUI.Custom_Display_Controls
{
    partial class RegularDayView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.totalHoursDisplay = new System.Windows.Forms.TextBox();
            this.lblTotalHoursDisplay = new System.Windows.Forms.Label();
            this.timeOutDisplay = new System.Windows.Forms.TextBox();
            this.lblTimeOutDisplay = new System.Windows.Forms.Label();
            this.timeInDisplay = new System.Windows.Forms.TextBox();
            this.lblTimeInDisplay = new System.Windows.Forms.Label();
            this.checkIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // totalHoursDisplay
            // 
            this.totalHoursDisplay.Location = new System.Drawing.Point(395, 3);
            this.totalHoursDisplay.Name = "totalHoursDisplay";
            this.totalHoursDisplay.ReadOnly = true;
            this.totalHoursDisplay.Size = new System.Drawing.Size(100, 20);
            this.totalHoursDisplay.TabIndex = 15;
            // 
            // lblTotalHoursDisplay
            // 
            this.lblTotalHoursDisplay.AutoSize = true;
            this.lblTotalHoursDisplay.Location = new System.Drawing.Point(327, 3);
            this.lblTotalHoursDisplay.Name = "lblTotalHoursDisplay";
            this.lblTotalHoursDisplay.Size = new System.Drawing.Size(62, 13);
            this.lblTotalHoursDisplay.TabIndex = 14;
            this.lblTotalHoursDisplay.Text = "Total Hours";
            // 
            // timeOutDisplay
            // 
            this.timeOutDisplay.Location = new System.Drawing.Point(217, 3);
            this.timeOutDisplay.Name = "timeOutDisplay";
            this.timeOutDisplay.ReadOnly = true;
            this.timeOutDisplay.Size = new System.Drawing.Size(100, 20);
            this.timeOutDisplay.TabIndex = 13;
            // 
            // lblTimeOutDisplay
            // 
            this.lblTimeOutDisplay.AutoSize = true;
            this.lblTimeOutDisplay.Location = new System.Drawing.Point(161, 3);
            this.lblTimeOutDisplay.Name = "lblTimeOutDisplay";
            this.lblTimeOutDisplay.Size = new System.Drawing.Size(50, 13);
            this.lblTimeOutDisplay.TabIndex = 12;
            this.lblTimeOutDisplay.Text = "Time Out";
            // 
            // timeInDisplay
            // 
            this.timeInDisplay.Location = new System.Drawing.Point(52, 3);
            this.timeInDisplay.Name = "timeInDisplay";
            this.timeInDisplay.ReadOnly = true;
            this.timeInDisplay.Size = new System.Drawing.Size(100, 20);
            this.timeInDisplay.TabIndex = 11;
            // 
            // lblTimeInDisplay
            // 
            this.lblTimeInDisplay.AutoSize = true;
            this.lblTimeInDisplay.Location = new System.Drawing.Point(4, 3);
            this.lblTimeInDisplay.Name = "lblTimeInDisplay";
            this.lblTimeInDisplay.Size = new System.Drawing.Size(42, 13);
            this.lblTimeInDisplay.TabIndex = 10;
            this.lblTimeInDisplay.Text = "Time In";
            // 
            // checkIn
            // 
            this.checkIn.Location = new System.Drawing.Point(502, -1);
            this.checkIn.Name = "checkIn";
            this.checkIn.Size = new System.Drawing.Size(75, 23);
            this.checkIn.TabIndex = 16;
            this.checkIn.Text = "Check In";
            this.checkIn.UseVisualStyleBackColor = true;
            this.checkIn.Click += new System.EventHandler(this.checkIn_Click);
            // 
            // RegularDayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkIn);
            this.Controls.Add(this.totalHoursDisplay);
            this.Controls.Add(this.lblTotalHoursDisplay);
            this.Controls.Add(this.timeOutDisplay);
            this.Controls.Add(this.lblTimeOutDisplay);
            this.Controls.Add(this.timeInDisplay);
            this.Controls.Add(this.lblTimeInDisplay);
            this.Name = "RegularDayView";
            this.Size = new System.Drawing.Size(634, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox totalHoursDisplay;
        private System.Windows.Forms.Label lblTotalHoursDisplay;
        private System.Windows.Forms.TextBox timeOutDisplay;
        private System.Windows.Forms.Label lblTimeOutDisplay;
        private System.Windows.Forms.TextBox timeInDisplay;
        private System.Windows.Forms.Label lblTimeInDisplay;
        private System.Windows.Forms.Button checkIn;
    }
}
