using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourTrackerUI
{
    public class Globals
    {
        public const string SETTINGS_FILE = "Settings.mez";

        public const string SETTINGS_FILE_LOCATION = "Settings files folder";

        public const string DATA_FILE_LOCATION = "Data files folder";

        public const string ROOT_FOLDER = "HourTracker";

        public static Dictionary<string,Month> Months = new Dictionary<string,Month>();
    }
}
