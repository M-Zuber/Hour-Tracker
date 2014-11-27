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

            using (TimePunch newTimePuncher = new TimePunch(this._dayDisplaying.TimeIn))
            {
                newTimePuncher.ShowDialog();
                newTimeIn = newTimePuncher.Time;
                bool checkedIn = false;

                while (!checkedIn)
                {
                    try
                    {

                        this._dayDisplaying.CheckIn(newTimeIn.Hour, newTimeIn.Minute, newTimeIn.Second);
                        checkedIn = true;
                    }
                    catch (Backend.Exceptions.InvalidTimePunchException ex)
                    {
                        MessageBox.Show(ex.Message);
                        newTimePuncher.DisplayForTimePunch(this._dayDisplaying.TimeIn);
                        newTimeIn = newTimePuncher.Time;
                    }
                }
            }

            SetUpDataBindings();
        }

        private void checkOut_Click(object sender, EventArgs e)
        {
            DateTime newTimeOut;

            using (TimePunch newTimePuncher = new TimePunch(this._dayDisplaying.TimeOut))
            {
                newTimePuncher.ShowDialog();
                newTimeOut = newTimePuncher.Time;
                bool checkedOut = false;

                while (!checkedOut)
                {
                    try
                    {

                        this._dayDisplaying.CheckOut(newTimeOut.Hour, newTimeOut.Minute, newTimeOut.Second);
                        checkedOut = true;
                    }
                    catch (Backend.Exceptions.InvalidTimePunchException ex)
                    {
                        MessageBox.Show(ex.Message);
                        newTimePuncher.DisplayForTimePunch(this._dayDisplaying.TimeOut);
                        newTimeOut = newTimePuncher.Time;
                    }
                }
            }

            SetUpDataBindings();
        }
    }
}
