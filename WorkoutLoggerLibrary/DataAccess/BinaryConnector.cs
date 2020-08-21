using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess
{
    class BinaryConnector : IDataConnection
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

        public DateModel LoadDate(string path)
        {
            throw new NotImplementedException();
        }

        public TemplateModel LoadTemplate(string path)
        {
            throw new NotImplementedException();
        }
    }
}
