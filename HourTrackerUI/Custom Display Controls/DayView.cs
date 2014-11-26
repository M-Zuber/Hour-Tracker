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
using HourTrackerUI.Custom_Display_Controls;
using HourTrackerUI.Helper_Functions;

namespace HourTrackerUI
{
    public partial class DayView : UserControl
    {
        private const string NO_SELECT = "non-selectable";

        private Backend.Day _dayDisplaying;

        public DayView(Backend.Day dayToDisplay)
        {
            InitializeComponent();
            _dayDisplaying = dayToDisplay;
            SetUpDataBindings();
        }

        #region Event Methods

        #endregion

        #region Other Methods

        private void SetUpDataBindings()
        {
            this.dateDisplay.Text = _dayDisplaying.Date.ToString("dd-MM-yyyy");
            this.dayOfTheWeekDisplay.Text = _dayDisplaying.DayOfWeek.ToString();
            UserControl specificDayView = null;

            if (this._dayDisplaying.SpecialDay == null)
            {
                specificDayView = new RegularDayView(this._dayDisplaying);
            }
            else
            {
                specificDayView = new SpecialDayView(this._dayDisplaying);
            }

            specificDayView.Top = this.Top;
            specificDayView.Left = this.dayOfTheWeekDisplay.Right + 3;
            this.Controls.Add(specificDayView);
            this.Width += specificDayView.Width;

            UI_Functions.SetNoSelctionOnTextBoxes(this.dateDisplay, this.dayOfTheWeekDisplay);
        }

        #endregion
    }
}
