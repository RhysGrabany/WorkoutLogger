using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        // TODO - Wire up the CreateDay for text files
        /// <summary>
        /// Saves a day to the textfile
        /// </summary>
        /// <param name="model">The day info</param>
        /// <returns>The day info, </returns>
        public DateModel CreateDay(DateModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
