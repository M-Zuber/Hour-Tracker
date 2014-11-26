using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HourTrackerUI.Custom_Display_Controls
{
    public partial class SpecialDayView : UserControl
    {
        private Backend.Day _dayDisplaying;

        public SpecialDayView(Backend.Day dayToDisplay)
        {
            InitializeComponent();
            _dayDisplaying = dayToDisplay;
            SetUpDataBindings();
        }

        #region Other Methods
        private void SetUpDataBindings()
        {
            SetText(this.lblSpecialDayInfo, _dayDisplaying.SpecialDay.Title);
        }

        private void SetText(Control control, string text)
        {
            control.Text = text;
        }

        #endregion
    }
}
