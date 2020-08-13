﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary
{
    public class SqlConnector : IDataConnection
    {
        // TODO - Make the CreateDay method actually save to database 
        /// <summary>
        /// Saves a day to the database
        /// </summary>
        /// <param name="model">The day info</param>
        /// <returns>The day info, including the unique id</returns>
        public DateModel CreateDay(DateModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
