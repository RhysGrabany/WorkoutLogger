using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
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
        public static void XmlWrite<T>(this T model, string fileName, int id)
        {
            //TODO: Obsolete?
            //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(type);
            //FileStream file = File.Create(Utility.FullFilePath(fileName, template));
            //writer.Serialize(file, model);
            //file.Close();

            string xmlString = SerialiseUtility.ModelToXml<T>(model);

            //using (var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            //{
            //    using (var sw = new StreamWriter(fs))
            //    {
            //        sw.Write(xmlString);
            //    }
            //}

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            XmlElement xmlId = xmlDoc.CreateElement("Id");
            xmlId.InnerText = id.ToString();

            XmlElement xmlModel = xmlDoc.CreateElement("Model");
            xmlModel.InnerText = xmlString;

            xmlId.AppendChild(xmlModel);

            xmlDoc.DocumentElement.AppendChild(xmlId);
            xmlDoc.Save(fileName);


        }

        #endregion

        #region Loading from File

        /// <summary>
        /// Loads an xml file and parses it into a DateModel 
        /// </summary>
        /// <param name="file">The xml file being parsed</param>
        /// <typeparam name="T">The model being loaded from file and being deserialised</typeparam>
        /// <returns>The deserialised object that can be used</returns>
        public static T XmlLoad<T>(this string file, int id)
        {
            // We need to grab the object based on the id
            // Need to change the way Xml saves to file, bugs out when multiple roots are available

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(File.ReadAllText(file));

            




            // TODO: Obsolete code?
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(T));
            StreamReader f = new StreamReader(file);
            T overview = (T)reader.Deserialize(f);
            f.Close();

            return overview;
        }

        #endregion 
    }
}
