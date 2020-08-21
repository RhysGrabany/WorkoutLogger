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
        /// Saves a day to the textfile
        /// </summary>
        /// <param name="model">The day info</param>
        /// <returns>The day info</returns>
        public DateModel CreateDay(DateModel model)
        {

            DateTime dayName = DateTime.Today;
            string fileName = $"{ dayName.ToString("d").Replace("/", "_") }{ model.NameDay.Replace(" ", "") }.xml";

            model.WriteFile(fileName);

            return model;

        }

        public TemplateModel CreateTemplate(TemplateModel model)
        {
            DateTime dayName = DateTime.Today;
            string fileName = $"{ dayName.ToString("d").Replace("/", "_") }{ model.NameTemplate.Replace(" ", "") }.xml";

            model.WriteFile(fileName);

            return model;
        }

        public DateModel LoadDate(string path)
        {
            return new DateModel();
        }

        public TemplateModel LoadTemplate(string path)
        {


            TemplateModel model = path.LoadFileTemplate();

            return model;

        }

    }
}
