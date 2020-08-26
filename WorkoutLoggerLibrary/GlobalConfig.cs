using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.DataAccess;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary
{
    public static class GlobalConfig
    {
        // Consts for the number of exercises and sets for the form
        // no real need having more unless push comes to shove
        public const int NoOfExercises = 10;
        public const int NoOfSets = 5;

        /// <summary>
        /// For using the correct DataConnection
        /// </summary>
        public static IDataConnection Connection { get; private set; }

        /// <summary>
        /// This holds the DatabaseType being used
        /// It's mostly for utility work and finding the file extension
        /// </summary>
        public static DatabaseType DatabaseUsed { get; set; }
        public static UnitType UnitUsed { get; set; }

        /// <summary>
        /// This is holding the data needed from the LoadDay window
        /// </summary>
        public static DateModel DayData { get; set; }



        public static void InitialiseConnections(DatabaseType db)
        {

            switch (db)
            {
                case DatabaseType.XML:
                    XmlConnector text = new XmlConnector();
                    Connection = text;
                    DatabaseUsed = DatabaseType.XML;
                    break;
                case DatabaseType.JSON:
                    JsonConnector json = new JsonConnector();
                    Connection = json;
                    DatabaseUsed = DatabaseType.JSON;
                    break;
                default:
                    break;
            }
        }
    }
}
