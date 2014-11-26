using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using System.IO;
using HourTrackerUI.Properties;

namespace HourTrackerUI.Handlers
{
    public static class DataHandler
    {
        private static Settings programSettings = new Settings();

        public static void LoadData()
        {
            string dataFilesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Globals.ROOT_FOLDER, programSettings.DataFilesFolder);
            if ((!string.IsNullOrWhiteSpace(programSettings.DataFilesFolder)) &&
                    (Directory.Exists(dataFilesPath)))
            {
                string[] dataFiles = Directory.GetFiles(dataFilesPath, "*.dat.mez");

                foreach (var currFileName in dataFiles)
                {
                    Month currentMonth = Month.Load(currFileName); 
                    Globals.Months.Add(currentMonth.Date.ToString("MM-yyyy"), currentMonth);
                }
            }
        }

        public static void SaveData()
        {
            if (!string.IsNullOrWhiteSpace(programSettings.DataFilesFolder))
            {
                string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Globals.ROOT_FOLDER, programSettings.DataFilesFolder);

                if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                }

                foreach (Month currMonth in Globals.Months.Values)
                {
                    currMonth.SaveToFile(Path.Combine(fullPath, currMonth.Date.ToString("MM-yyyy") + ".dat.mez"));
                }
            }
        }
    }
}
