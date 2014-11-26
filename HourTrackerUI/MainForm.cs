using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend;
using HourTrackerUI.Handlers;

namespace HourTrackerUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SettingsHandler.LoadSettings();
            DataHandler.LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsHandler.SaveSettings();
            DataHandler.SaveData();
        }

        private void viewDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string chosenMonth = "";
            using (ChooseMonthToViewForm chooseForm = new ChooseMonthToViewForm(Globals.Months.Select(month => month.Value.Date.ToString("MM-yyyy")).ToList()))
            {
                chooseForm.ShowDialog();

                chosenMonth = chooseForm.ChosenMonth;
            }

            MonthDataForm form = new MonthDataForm(Globals.Months[chosenMonth]);
            form.MdiParent = this;
            form.Show();
        }
    }
}
