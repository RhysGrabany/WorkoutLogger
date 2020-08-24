using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;
using WorkoutLoggerLibrary.DataAccess.JsonHelpers;

namespace WorkoutLoggerLibrary.DataAccess
{
    class JsonConnector : IDataConnection
    {
        // TODO - Wire up CreateDay for Binary files
        /// <summary>
        /// Saves a day to a binary file
        /// </summary>
        /// <param name="model">The day info</param>
        /// <returns>The day model with unique id</returns>
        public DateModel CreateDay(DateModel model)
        {
            return model;
        }

        public TemplateModel CreateTemplate(TemplateModel model)
        {
            return model;
        }

        public T Loading<T>(string path)
        {
            throw new NotImplementedException();
        }

    }
}
