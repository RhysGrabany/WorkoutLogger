using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess.XmlHelpers
{
    public static class XmlConnectorProcessor
    {
        /// <summary>
        /// This is the method that deals with the filepath to the fileName
        /// </summary>
        /// <param name="fileName">The file that is going to have the filepath returned</param>
        /// <returns>Full file path</returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        /// <summary>
        /// Loads an xml file and parses it into a DateModel 
        /// </summary>
        /// <param name="file">The xml file being parsed</param>
        /// <returns></returns>
        public static DateModel LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new DateModel();
            }

            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(DateModel));
            StreamReader f = new StreamReader(FullFilePath("serializing.xml"));
            DateModel overview = (DateModel)reader.Deserialize(f);
            f.Close();

            return overview;
        }

        /// <summary>
        /// This method writes the current passed model to an xml file
        /// </summary>
        /// <param name="model">The current model being written</param>
        /// <param name="fileName">The file location being written to</param>
        public static void WriteFile(this DateModel model, string fileName)
        {

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DateModel));
            FileStream file = File.Create(FullFilePath(fileName));
            writer.Serialize(file, model);
            file.Close();

        }
    }
}
