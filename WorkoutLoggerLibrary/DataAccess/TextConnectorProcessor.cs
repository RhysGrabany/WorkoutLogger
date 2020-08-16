using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace WorkoutLoggerLibrary.DataAccess.TextConnector
{
    public static class TextConnectorProcessor
    {

        public static string FullFilePath(string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

    }
}
