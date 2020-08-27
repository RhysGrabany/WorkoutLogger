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
        private static string filename = "C:\\data\\WorkoutLogger\\settings.xml";

        public static void Boot()
        {

            if (!File.Exists(filename))
            {
                FileStream file = File.Create(filename);

                instance.DaysFolder = "C:\\data\\WorkoutLogger\\days";
                instance.TemplatesFolder = "C:\\data\\WorkoutLogger\\templates";
                instance.UnitSystem = UnitType.METRIC;
                instance.DatabaseConnection = DatabaseType.XML;

                serial.Serialize(file, instance);
                file.Close();
            }
            else
            {
                StreamReader file = new StreamReader(filename);
                instance = (Settings)serial.Deserialize(file);
                file.Close();
            }

        }
        public static void Update()
        {

            if (File.Exists(filename))
            {
                FileStream file = File.Create(filename);
                serial.Serialize(file, instance);
                file.Close();
            }
        }
        public static Settings Instance
        {
            get
            {
                if (instance != null) return instance;

                using (StringReader reader = new StringReader(filename)) return instance = (Settings)serial.Deserialize(reader);
            }
        }

        public string DaysFolder { get; set; } 
        public string TemplatesFolder { get; set; } 
        public UnitType UnitSystem { get; set; }
        public DatabaseType DatabaseConnection { get; set; }
    }
}
