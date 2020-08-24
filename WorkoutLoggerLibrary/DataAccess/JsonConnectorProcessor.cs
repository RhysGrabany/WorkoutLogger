using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess.JsonHelpers
{
    public static class JsonConnectorProcessor
    {

        #region Writing to File

        /// <summary>
        /// This method writes the current passed model to an xml file
        /// </summary>
        /// <param name="model">The current model being written</param>
        /// <param name="fileName">The file location being written to</param>
        public static void JsonWrite<T>(this T model, string fileName)
        {

            Type type = typeof(T);
            bool template = true;
            if (type == typeof(DateModel)) template = false;

            TextWriter writer = null;
            var contents = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            writer = new StreamWriter(Utility.FullFilePath(fileName, template));
            writer.Close();

        }


        #endregion

        #region Loading from File

        /// <summary>
        /// Loads an xml file and parses it into a DateModel 
        /// </summary>
        /// <param name="file">The xml file being parsed</param>
        /// <returns></returns>
        public static T JsonLoad<T>(this string file)
        {

            TextReader reader = new StreamReader(file);
            var contents = reader.ReadToEnd();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(contents);
            
        }

        #endregion 

    }
}
