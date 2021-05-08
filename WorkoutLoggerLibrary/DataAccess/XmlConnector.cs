using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;
using WorkoutLoggerLibrary.DataAccess.XmlHelpers;
using System.IO;

namespace WorkoutLoggerLibrary.DataAccess
{
    //TODO: This class will get restructured when I fix serialising onto one file
    public class XmlConnector : IDataConnection
    {

        /// <summary>
        /// Creates a serialised date model for saving to file
        /// </summary>
        /// <param name="model">The date model that is to be serialised</param>
        public void Creating(DateModel model)
        {

            DateTime dayName = DateTime.Today;
            //string fileName = $"{ dayName.ToString("d").Replace("/", "_") }{ model.NameDay.Replace(" ", "") }.xml";
            model.XmlWrite<DateModel>(Settings.Instance.DaysDataFile, model.Id);
        }

        /// <summary>
        /// Creates a serialised template model for saving to file
        /// </summary>
        /// <param name="model">The template model that is to be serialised</param>
        public void Creating(TemplateModel model)
        {
            string fileName = $"{ model.NameTemplate.Replace(" ", "") }.xml";
            model.XmlWrite<TemplateModel>(fileName, model.Id);
        }

        /// <summary>
        /// Loading a file from memory that will then be
        /// deserialized for the program to work with
        /// </summary>
        /// <typeparam name="T">Model being deserialized</typeparam>
        /// <param name="path">The path to the serialized object file</param>
        /// <returns>The deserialized object that is ready to be used</returns>
        public T Loading<T>(string path, int id)
        {
            return path.XmlLoad<T>(id);
        }

    }
}
