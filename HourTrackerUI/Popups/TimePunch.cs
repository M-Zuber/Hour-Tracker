using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HourTrackerUI.Popups
{
    public partial class TimePunch : Form
    {
        public DateTime TimeIn { get; private set; }

        public DateTime TimeOut { get; private set; }

        public TimePunch(DateTime timeIn, DateTime timeOut)
        {
            InitializeComponent();
            this.TimeIn = timeIn;
            this.TimeOut = timeOut;
            SetControlBindings();
            SetDataBindings();
        }

        private void SetDataBindings()
        {
            this.timeIn.DataBindings.Add("MaxDate", this.timeOut, "Value");
            this.timeOut.DataBindings.Add("MinDate", this.timeIn, "Value");
        }

        private void SetControlBindings()
        {
            this.timeIn.Value = this.TimeIn;
            this.timeOut.Value = this.TimeOut;
        }

        private void SetPropertiesValues()
        {
            this.TimeIn = this.timeIn.Value;
            this.TimeOut = this.timeOut.Value;
        }
        private void punch_Click(object sender, EventArgs e)
        {
            this.SetPropertiesValues();
            this.Close();
        }
    }
}
