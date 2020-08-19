using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using WorkoutLoggerLibrary.Models;

// Load textfile
// Convert text to List<DateModel>
// Find max Id
// Add new record with new ID ( max + 1 )
// Convert Dates to List<string>
// Save the List<string> to the text file


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

        public static void WriteFile(this DateModel model, string fileName)
        {

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DateModel));
            FileStream file = File.Create(FullFilePath(fileName));
            //FileStream file = File.Create("C:\\data\\WorkoutLogger\\DateModels.xml");
            writer.Serialize(file, model);
            file.Close();

        }
    }
}
