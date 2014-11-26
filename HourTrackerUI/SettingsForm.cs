using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HourTrackerUI.Properties;
using System.IO;

namespace HourTrackerUI
{
    public partial class SettingsForm : Form
    {
        /*
         * ---Settings---
         * #######################special dates file (this may need another class in the backend)
         * 
         * min hours for month (not really needed until adding reports and such -or other better features)
         * 
         */
        Settings programSettings = new Settings();

        public Dictionary<string, string> Settings { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            Settings = new Dictionary<string, string>();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(programSettings.SettingFilesFolder))
            {
                using (AlertInputForm alert = new AlertInputForm(Globals.SETTINGS_FILE_LOCATION))
                {
                    alert.ShowDialog();

                    if (!string.IsNullOrWhiteSpace(alert.InputText))
                    {
                        programSettings.SettingFilesFolder = alert.InputText;
                        programSettings.Save();
                    }
                }
            }
            string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Globals.ROOT_FOLDER, programSettings.SettingFilesFolder);

            if (File.Exists(Path.Combine(fullPath,Globals.SETTINGS_FILE)))
            {
                List<string> allLines = File.ReadAllLines(Path.Combine(fullPath, Globals.SETTINGS_FILE)).ToList();

                foreach (string line in allLines)
                {
                    string[] keyValue = line.Split(new string[] { ":" }, StringSplitOptions.None);
                    Settings.Add(keyValue[0], keyValue[1]);
                }
            }

            this.settingsTable.DataSource = this.Settings.ToList();
        }

        //edit button to allow editing of settings
    }
}
