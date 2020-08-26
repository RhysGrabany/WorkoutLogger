using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WorkoutLoggerLibrary
{
    [Serializable]
    public class Settings
    {
        private static readonly XmlSerializer serial = new XmlSerializer(typeof(Settings));
        private static Settings instance = new Settings();
        public static void FirstBoot()
        {
            if (!File.Exists("C:\\data\\WorkoutLogger\\settings.xml"))
            {
                FileStream file = File.Create("C:\\data\\WorkoutLogger\\settings.xml");
                serial.Serialize(file, instance);
            }
        }
        public static Settings Instance
        {
            get
            {
                if (instance != null) return instance;
                string filename = "C:\\data\\WorkoutLogger\\settings.xml";

                using (StringReader reader = new StringReader(filename)) return instance = (Settings)serial.Deserialize(reader);
            }
        }

        public Settings()
        {
            DaysFolder = "C:\\data\\WorkoutLogger\\days";
            TemplatesFolder = "C:\\data\\WorkoutLogger\\templates";
            UnitSystem = UnitType.METRIC;
        }

        public string DaysFolder { get; set; } 
        public string TemplatesFolder { get; set; } 
        public UnitType UnitSystem { get; set; } 
    }
}
