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
        private static string file = "settings.xml";
        private static string folder = "C:\\data\\WorkoutLogger";
        private static string fullFilePath = $"{ folder }\\{ file }";

        /// <summary>
        /// This method is called on boot and will aautomatically set the values to the default
        /// if there is no settings.xml file. If there is a settings.xml file, then the method
        /// will take the info from the file for use in the program.
        /// </summary>
        public static void Boot()
        {

            if (!File.Exists(fullFilePath))
            {
                Directory.CreateDirectory(folder);
                FileStream file = File.Create(fullFilePath);

                instance.DaysFolder = "C:\\data\\WorkoutLogger\\days";
                instance.TemplatesFolder = "C:\\data\\WorkoutLogger\\templates";
                instance.UnitSystem = UnitType.METRIC;
                instance.DatabaseConnection = DatabaseType.XML;

                serial.Serialize(file, instance);
                file.Close();
            }
            else
            {
                StreamReader file = new StreamReader(fullFilePath);
                instance = (Settings)serial.Deserialize(file);
                file.Close();
            }

        }
        /// <summary>
        /// After a setting is changed then this method is to be called
        /// after to actually make the change
        /// </summary>
        public static void Update()
        {

            if (File.Exists(fullFilePath))
            {
                FileStream file = File.Create(fullFilePath);
                serial.Serialize(file, instance);
                file.Close();
            }
        }
        /// <summary>
        /// Main entry point for accessing the info needed about user settings
        /// </summary>
        public static Settings Instance
        {
            get
            {
                if (instance != null) return instance;

                using (StringReader reader = new StringReader(fullFilePath)) return instance = (Settings)serial.Deserialize(reader);
            }
        }

        /// <summary>
        /// The folder to hold the information for Days
        /// </summary>
        public string DaysFolder { get; set; } 
        /// <summary>
        /// The folder to hold the information for Templates
        /// </summary>
        public string TemplatesFolder { get; set; } 
        /// <summary>
        /// The UnitType being used
        /// </summary>
        public UnitType UnitSystem { get; set; }
        /// <summary>
        /// The DatabaseConnection being used
        /// </summary>
        public DatabaseType DatabaseConnection { get; set; }
    }
}
