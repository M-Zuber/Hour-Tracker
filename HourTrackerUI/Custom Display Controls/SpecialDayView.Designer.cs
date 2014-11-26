namespace HourTrackerUI.Custom_Display_Controls
{
    partial class SpecialDayView
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
            this.lblSpecialDayInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSpecialDayInfo
            // 
            this.lblSpecialDayInfo.AutoSize = true;
            this.lblSpecialDayInfo.Location = new System.Drawing.Point(3, 0);
            this.lblSpecialDayInfo.Name = "lblSpecialDayInfo";
            this.lblSpecialDayInfo.Size = new System.Drawing.Size(35, 13);
            this.lblSpecialDayInfo.TabIndex = 11;
            this.lblSpecialDayInfo.Text = "label1";
            // 
            // SpecialDayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSpecialDayInfo);
            this.Name = "SpecialDayView";
            this.Size = new System.Drawing.Size(144, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpecialDayInfo;
    }
}
