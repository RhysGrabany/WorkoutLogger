using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;
using WorkoutLoggerLibrary.DataAccess.XmlHelpers;
using System.Configuration;
using System.IO;

namespace WorkoutLoggerLibrary.DataAccess
{
    public class XmlConnector : IDataConnection
    {

        /// <summary>
        /// Saves a day to the textfile
        /// </summary>
        /// <param name="model">The day info</param>
        /// <returns>The day info</returns>
        public DateModel CreateDay(DateModel model)
        {

            DateTime dayName = DateTime.Today;
            string fileName = $"{ dayName.ToString("d").Replace("/", "_") }.xml";

            model.WriteFile(fileName);

            return model;

        }
    }
}
