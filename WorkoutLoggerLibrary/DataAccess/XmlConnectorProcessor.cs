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
        
        #region Writing to File

        /// <summary>
        /// This method writes the current passed model to an xml file
        /// </summary>
        /// <typeparam name="T">The model being passed over to be written to file</typeparam>
        /// <param name="model">The current model being written</param>
        /// <param name="fileName">The file location being written to</param>
        public static void XmlWrite<T>(this T model, string fileName)
        {

            Type type = typeof(T);
            bool template = true;
            if (type == typeof(DateModel)) template = false;

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            FileStream file = File.Create(Utility.FullFilePath(fileName, template));
            writer.Serialize(file, model);
            file.Close();

        }

        #endregion

        #region Loading from File

        /// <summary>
        /// Loads an xml file and parses it into a DateModel 
        /// </summary>
        /// <param name="file">The xml file being parsed</param>
        /// <typeparam name="T">The model being loaded from file and being deserialised</typeparam>
        /// <returns>The deserialised object that can be used</returns>
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
