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
        public DateTime Time { get; private set; }

        public TimePunch(DateTime time)
        {
            InitializeComponent();
            this.Time = time;

            SetControlBindings();
        }

        private void SetControlBindings()
        {
            this.timePicker.Value = this.Time;
        }

        private void SetPropertiesValues()
        {
            this.Time = this.timePicker.Value;
        }
        private void punch_Click(object sender, EventArgs e)
        {
            this.SetPropertiesValues();
            this.Close();
        }

        public void DisplayForTimePunch(DateTime time)
        {
            this.Time = time;
            this.SetControlBindings();

            this.ShowDialog();
        }
    }
}
