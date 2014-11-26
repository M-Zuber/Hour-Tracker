namespace HourTrackerUI.Popups
{
    partial class TimePunch
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
            this.timeIn = new System.Windows.Forms.DateTimePicker();
            this.timeOut = new System.Windows.Forms.DateTimePicker();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.punch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timeIn
            // 
            this.timeIn.CustomFormat = "HH:mm:ss";
            this.timeIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeIn.Location = new System.Drawing.Point(64, 18);
            this.timeIn.Name = "timeIn";
            this.timeIn.ShowUpDown = true;
            this.timeIn.Size = new System.Drawing.Size(77, 20);
            this.timeIn.TabIndex = 0;
            // 
            // timeOut
            // 
            this.timeOut.CustomFormat = "HH:mm:ss";
            this.timeOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeOut.Location = new System.Drawing.Point(219, 18);
            this.timeOut.Name = "timeOut";
            this.timeOut.ShowUpDown = true;
            this.timeOut.Size = new System.Drawing.Size(77, 20);
            this.timeOut.TabIndex = 1;
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.AutoSize = true;
            this.lblTimeIn.Location = new System.Drawing.Point(13, 18);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(45, 13);
            this.lblTimeIn.TabIndex = 2;
            this.lblTimeIn.Text = "Time In:";
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(160, 18);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(53, 13);
            this.lblTimeOut.TabIndex = 3;
            this.lblTimeOut.Text = "Time Out:";
            // 
            // punch
            // 
            this.punch.Location = new System.Drawing.Point(123, 50);
            this.punch.Name = "punch";
            this.punch.Size = new System.Drawing.Size(75, 23);
            this.punch.TabIndex = 4;
            this.punch.Text = "Time Punch";
            this.punch.UseVisualStyleBackColor = true;
            this.punch.Click += new System.EventHandler(this.punch_Click);
            // 
            // TimePunch
            // 
            this.AcceptButton = this.punch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 85);
            this.Controls.Add(this.punch);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.lblTimeIn);
            this.Controls.Add(this.timeOut);
            this.Controls.Add(this.timeIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TimePunch";
            this.Text = "TimePunch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker timeIn;
        private System.Windows.Forms.DateTimePicker timeOut;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.Button punch;
    }
}