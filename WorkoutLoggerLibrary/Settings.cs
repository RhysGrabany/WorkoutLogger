using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WorkoutLoggerLibrary
{
    [Serializable]
    public class Settings
    {
        private static readonly XmlSerializer serial = new XmlSerializer(typeof(Settings));
        private static Settings instance = new Settings();
        private static string settingsFile = "settings.xml";
        private static string cacheObjectFile = "cache.csv";
        private static string folder = @"C:\data\WorkoutLogger";
        private static string settingsFilePath = $"{ folder }\\{ settingsFile }";

        /// <summary>
        /// This method is called on boot and will automatically set the values to the default
        /// if there is no settings.xml file. If there is a settings.xml file, then the method
        /// will take the info from the file for use in the program.
        /// </summary>
        public static void Boot()
        {

            if (!File.Exists(settingsFilePath))
            {
                // Create dir and settings file, then populate the settings file
                // with the needed info
                Directory.CreateDirectory(folder);

                InitialiseSettingsFile();
                InitialiseCacheFile();

                CreateFileAndClose(instance.DaysDataFile);
                CreateFileAndClose(instance.TemplatesDataFile);

                InitialiseXmlFiles();
            }
            else
            {
                StreamReader file = new StreamReader(settingsFilePath);
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

            if (File.Exists(settingsFilePath))
            {
                FileStream file = File.Create(settingsFilePath);
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

                using (StringReader reader = new StringReader(settingsFilePath)) return instance = (Settings)serial.Deserialize(reader);
            }
        }

        private static void InitialiseSettingsFile()
        {
            FileStream file = File.Create(settingsFilePath);

            instance.DaysDataFile = $"{ folder }\\days.xml";
            instance.TemplatesDataFile = $"{ folder }\\templates.xml";
            instance.DataFolder = folder;
            instance.CacheObjectFile = $"{ folder }\\{ cacheObjectFile }";

            instance.UnitSystem = UnitType.METRIC;
            instance.DatabaseConnection = DatabaseType.XML;

            serial.Serialize(file, instance);
            file.Close();

        }

        private static void InitialiseCacheFile()
        {
            using (var fs = new FileStream(instance.CacheObjectFile, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("id,name,date,template");
                }
            }
        }

        private static void InitialiseXmlFiles()
        {

            List<string> xmlFiles = new List<string>()
            { Settings.Instance.DaysDataFile, Settings.Instance.TemplatesDataFile };

            foreach (var file in xmlFiles)
            {
                using (var fs = new FileStream(file, FileMode.Append, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("<?xml version=\"1.0\"?>");
                    }
                }
            }

            using (XmlWriter wr = XmlWriter.Create(Settings.Instance.DaysDataFile))
            {
                wr.WriteStartElement("Days");
                wr.WriteEndElement();
                wr.Flush();
            }

        }

        private static void CreateFileAndClose(string fileName)
        {
            var fileStream = File.Create(fileName);
            fileStream.Close();
        }

        /// <summary>
        /// The folder to hold the information for Days
        /// </summary>
        public string DaysDataFile { get; set; } 

        /// <summary>
        /// The folder to hold the information for Templates
        /// </summary>
        public string TemplatesDataFile { get; set; }

        public string DataFolder { get; set; }

        /// <summary>
        /// The file that holds all the cache to templates and 
        /// days
        /// </summary>
        public string CacheObjectFile { get; set; }

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
