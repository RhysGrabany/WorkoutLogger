using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;
using WorkoutLoggerLibrary.DataAccess.XmlHelpers;
using System.IO;

namespace WorkoutLoggerLibrary.DataAccess
{
    public class XmlConnector : IDataConnection
    {

        /// <summary>
        /// Creates a serialised date model for saving to file
        /// </summary>
        /// <param name="model">The date model that is to be serialised</param>
        /// <returns>Returns the passed in model</returns>
        public DateModel Creating(DateModel model)
        {

            DateTime dayName = DateTime.Today;
            string fileName = $"{ dayName.ToString("d").Replace("/", "_") }{ model.NameDay.Replace(" ", "") }.xml";

            model.XmlWrite<DateModel>(fileName);

            return model;

        }

        /// <summary>
        /// Creates a serialised template model for saving to file
        /// </summary>
        /// <param name="model">The template model that is to be serialised</param>
        /// <returns>Returns the passed in model</returns>
        public TemplateModel Creating(TemplateModel model)
        {
            DateTime dayName = DateTime.Today;
            string fileName = $"{ model.NameTemplate.Replace(" ", "") }.xml";


            model.XmlWrite<TemplateModel>(fileName);

            return model;
        }

        public T Loading<T>(string path)
        {
            return path.XmlLoad<T>();
        }

    }
}
