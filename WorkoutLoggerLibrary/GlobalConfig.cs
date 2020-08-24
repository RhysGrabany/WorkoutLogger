using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.DataAccess;

namespace WorkoutLoggerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static DatabaseType DatabaseUsed { get; set; }

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
