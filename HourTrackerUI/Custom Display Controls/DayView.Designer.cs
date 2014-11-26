namespace HourTrackerUI
{
    partial class DayView
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
            this.lblDateDisplay = new System.Windows.Forms.Label();
            this.dateDisplay = new System.Windows.Forms.TextBox();
            this.lblDayOfWeekDisplay = new System.Windows.Forms.Label();
            this.dayOfTheWeekDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDateDisplay
            // 
            this.lblDateDisplay.AutoSize = true;
            this.lblDateDisplay.Location = new System.Drawing.Point(4, 4);
            this.lblDateDisplay.Name = "lblDateDisplay";
            this.lblDateDisplay.Size = new System.Drawing.Size(33, 13);
            this.lblDateDisplay.TabIndex = 0;
            this.lblDateDisplay.Text = "Date:";
            // 
            // dateDisplay
            // 
            this.dateDisplay.Location = new System.Drawing.Point(44, 4);
            this.dateDisplay.Name = "dateDisplay";
            this.dateDisplay.ReadOnly = true;
            this.dateDisplay.Size = new System.Drawing.Size(100, 20);
            this.dateDisplay.TabIndex = 1;
            this.dateDisplay.Tag = "\"\"";
            // 
            // lblDayOfWeekDisplay
            // 
            this.lblDayOfWeekDisplay.AutoSize = true;
            this.lblDayOfWeekDisplay.Location = new System.Drawing.Point(152, 4);
            this.lblDayOfWeekDisplay.Name = "lblDayOfWeekDisplay";
            this.lblDayOfWeekDisplay.Size = new System.Drawing.Size(91, 13);
            this.lblDayOfWeekDisplay.TabIndex = 2;
            this.lblDayOfWeekDisplay.Text = "Day of the Week:";
            // 
            // dayOfTheWeekDisplay
            // 
            this.dayOfTheWeekDisplay.Location = new System.Drawing.Point(249, 4);
            this.dayOfTheWeekDisplay.Name = "dayOfTheWeekDisplay";
            this.dayOfTheWeekDisplay.ReadOnly = true;
            this.dayOfTheWeekDisplay.Size = new System.Drawing.Size(100, 20);
            this.dayOfTheWeekDisplay.TabIndex = 3;
            // 
            // DayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dayOfTheWeekDisplay);
            this.Controls.Add(this.lblDayOfWeekDisplay);
            this.Controls.Add(this.dateDisplay);
            this.Controls.Add(this.lblDateDisplay);
            this.Name = "DayView";
            this.Size = new System.Drawing.Size(365, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateDisplay;
        private System.Windows.Forms.TextBox dateDisplay;
        private System.Windows.Forms.Label lblDayOfWeekDisplay;
        private System.Windows.Forms.TextBox dayOfTheWeekDisplay;

    }
}
