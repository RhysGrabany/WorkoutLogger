using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutLoggerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitialiseConnections(bool database, bool textFiles, bool binary)
        {
            if (database)
            {
                // TODO - Create the SQL connection
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                // TODO - Create the Text Connection
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }

            if (binary)
            {
                // TODO - Create the Binary Connection
                BinaryConnector bin = new BinaryConnector();
                Connections.Add(bin);
            }
        }
    }
}
