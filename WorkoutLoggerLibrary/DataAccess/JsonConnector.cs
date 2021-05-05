using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;
using WorkoutLoggerLibrary.DataAccess.JsonHelpers;

namespace WorkoutLoggerLibrary.DataAccess
{
    //TODO: This class will get restructured when I fix serialising onto one file
    public class JsonConnector : IDataConnection
    {
        /// <summary>
        /// Creates a serialised date model for saving to file
        /// </summary>
        /// <param name="model">The date model that is to be serialised</param>
        public void Creating(DateModel model)
        {

            DateTime dayName = DateTime.Today;
            string fileName = $"{ dayName.ToString("d").Replace("/", "_") }{ model.NameDay.Replace(" ", "") }.json";

            model.JsonWrite<DateModel>(fileName);

        }

        /// <summary>
        /// Creates a serialised template model for saving to file
        /// </summary>
        /// <param name="model">The template model that is to be serialised</param>
        /// <returns>Returns the passed in model</returns>
        public void Creating(TemplateModel model)
        {
            string fileName = $"{ model.NameTemplate.Replace(" ", "") }.json";

            model.JsonWrite<TemplateModel>(fileName);
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
            return path.JsonLoad<T>();
        }

    }
}
