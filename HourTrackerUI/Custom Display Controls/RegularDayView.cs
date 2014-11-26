using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend;
using HourTrackerUI.Helper_Functions;
using HourTrackerUI.Popups;

namespace HourTrackerUI.Custom_Display_Controls
{
    public partial class RegularDayView : UserControl
    {
        private Backend.Day _dayDisplaying;

        public RegularDayView(Backend.Day dayToDisplay)
        {
            InitializeComponent();
            _dayDisplaying = dayToDisplay;
            SetUpDataBindings();
            UI_Functions.SetNoSelctionOnTextBoxes(this.timeInDisplay, this.timeOutDisplay, this.totalHoursDisplay);
        }

        #region Other Methods
        private void SetUpDataBindings()
        {
            SetText(this.timeInDisplay, _dayDisplaying.TimeIn.ToString("h:mm:ss tt"));
            SetText(this.timeOutDisplay, _dayDisplaying.TimeOut.ToString("h:mm:ss tt"));
            SetText(this.totalHoursDisplay, _dayDisplaying.TotalHours.Hours.ToString());

        }

        private void SetText(TextBox textbox, string text)
        {
            textbox.Text = text;
        }

        #endregion

        private void checkIn_Click(object sender, EventArgs e)
        {
            DateTime newTimeIn;
            DateTime newTimeOut;
            using (TimePunch newTimePuncher = new TimePunch(this._dayDisplaying.TimeIn, this._dayDisplaying.TimeOut))
            {
                newTimePuncher.ShowDialog();

                // try hust straight out doing checkin/ checkout
                // create function that clears current data
                // warn before using
                newTimeIn = newTimePuncher.TimeIn;
                newTimeOut = newTimePuncher.TimeOut;
            }
            if (this._dayDisplaying.TimeIn == default(DateTime))
            {
                try
                {
                    this._dayDisplaying.CheckIn(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                }
                catch (Backend.Exceptions.InvalidTimePunchException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            SetUpDataBindings();
        }
    }
}
