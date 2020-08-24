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
        public static string FullFilePath(this string fileName, bool template)
        {

            return template ? $"{ ConfigurationManager.AppSettings["tfilePath"] }\\{ fileName }"
                : $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        #region Writing to File

        /// <summary>
        /// This method writes the current passed model to an xml file
        /// </summary>
        /// <param name="model">The current model being written</param>
        /// <param name="fileName">The file location being written to</param>
        public static void XmlWrite<T>(this T model, string fileName)
        {

            Type type = typeof(T);
            bool template = true;
            if (type == typeof(DateModel)) template = false;

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            FileStream file = File.Create(FullFilePath(fileName, template));
            writer.Serialize(file, model);
            file.Close();

        }


        #endregion

        #region Loading from File

        /// <summary>
        /// Loads an xml file and parses it into a DateModel 
        /// </summary>
        /// <param name="file">The xml file being parsed</param>
        /// <returns></returns>
        public static T XmlLoad<T>(this string file)
        {

            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(T));
            StreamReader f = new StreamReader(file);
            T overview = (T)reader.Deserialize(f);
            f.Close();

            return overview;
        }

        #endregion 

    }
}
