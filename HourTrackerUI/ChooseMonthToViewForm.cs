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
    public partial class ChooseMonthToViewForm : Form
    {
        private List<string> MonthsAvailble { get; set; }

        public string ChosenMonth { get; private set; }

        public ChooseMonthToViewForm(List<string> monthsAvailble)
        {
            InitializeComponent();

            this.MonthsAvailble = monthsAvailble;
        }

        private void ChooseMonthToViewForm_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = MonthsAvailble;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ChosenMonth = this.comboBox1.SelectedItem.ToString();
            this.Close();
        }
    }
}
