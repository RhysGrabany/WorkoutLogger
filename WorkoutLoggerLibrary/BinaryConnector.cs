using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary
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
            model.Id = 1;

            return model;
        }
    }
}
