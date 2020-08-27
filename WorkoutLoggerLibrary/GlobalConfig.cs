using System;
using System.Collections.Generic;
using System.Configuration;
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
        /// This is holding the data needed from the LoadDay window
        /// </summary>
        public static DateModel DayData { get; set; }

        public static IDataConnection Connection { get; private set; }

        public static void InitialiseConnections(DatabaseType db)
        {

            switch (db)
            {
                case DatabaseType.XML:
                    XmlConnector text = new XmlConnector();
                    Connection = text;
                    Settings.Instance.DatabaseConnection = DatabaseType.XML;
                    break;
                case DatabaseType.JSON:
                    JsonConnector json = new JsonConnector();
                    Connection = json;
                    Settings.Instance.DatabaseConnection = DatabaseType.JSON;
                    break;
                default:
                    break;
            }
        }
    }
}
