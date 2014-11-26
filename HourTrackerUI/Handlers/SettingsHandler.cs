using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HourTrackerUI.Properties;
using System.IO;

namespace HourTrackerUI.Handlers
{
    public static class SettingsHandler
    {
        private static Settings programSettings = new Settings();

        public static void LoadSettings()
        {
            if ((!string.IsNullOrWhiteSpace(programSettings.SettingFilesFolder)) &&
                (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Globals.ROOT_FOLDER,
                                                                            programSettings.SettingFilesFolder, Globals.SETTINGS_FILE))))
            {
                var allLines = File.ReadAllLines(
                                                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                                            Globals.ROOT_FOLDER,
                                                            programSettings.SettingFilesFolder,
                                                            Globals.SETTINGS_FILE))
                                .Select(line => line.Split(new string[] { ":" }, StringSplitOptions.None))
                                .ToDictionary(key => key[0], value => value[1]);

                programSettings.SettingFilesFolder = allLines[Globals.SETTINGS_FILE_LOCATION];
                programSettings.DataFilesFolder = allLines[Globals.DATA_FILE_LOCATION];
                programSettings.Save();
            }
        }

        public static void SaveSettings()
        {
            if (!string.IsNullOrWhiteSpace(programSettings.SettingFilesFolder))
            {
                string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Globals.ROOT_FOLDER, programSettings.SettingFilesFolder, Globals.SETTINGS_FILE);

                if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                }

                File.WriteAllLines(fullPath,
                    new List<string>()
                    {
                        string.Format("{0}:{1}", Globals.SETTINGS_FILE_LOCATION, programSettings.SettingFilesFolder),
                        string.Format("{0}:{1}",Globals.DATA_FILE_LOCATION, programSettings.DataFilesFolder)
                    });
            }
        }
    }
}
