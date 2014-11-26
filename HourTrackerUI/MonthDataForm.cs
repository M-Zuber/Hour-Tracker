using Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HourTrackerUI
{
    public partial class MonthDataForm : Form
    {
        public Month MonthDisplaying { get; set; }

        public MonthDataForm(Month monthToDisplay)
        {
            InitializeComponent();
            MonthDisplaying = monthToDisplay;
        }

        private void MonthDataForm_Load(object sender, EventArgs e)
        {
            int nextTop = this.Top + 10;

            foreach (var item in MonthDisplaying.Days)
            {
                DayView dayDisplay = new DayView(item);

                dayDisplay.Top = nextTop;

                nextTop = dayDisplay.Bottom + 2;

                this.Controls.Add(dayDisplay);
            }

            this.WindowState = FormWindowState.Maximized;
        }

    }
}
