using System;
using System.Collections.Generic;
using System.Text;
using WorkoutLoggerLibrary.DataAccess;

namespace WorkoutLoggerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitialiseConnections(DatabaseType db)
        {

            switch (db)
            {
                case DatabaseType.SQL:
                    // TODO - Create the SQL connection
                    SqlConnector sql = new SqlConnector();
                    Connection = sql;
                    break;
                case DatabaseType.TEXTFILE:
                    // TODO - Create the Text Connection
                    TextConnector text = new TextConnector();
                    Connection = text;
                    break;
                case DatabaseType.BINARY:
                    // TODO - Create the Binary Connection
                    BinaryConnector bin = new BinaryConnector();
                    Connection = bin;
                    break;
                default:
                    break;
            }
        }
    }
}
