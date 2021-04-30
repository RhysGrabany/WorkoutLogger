using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace WorkoutLoggerLibrary
{
    public static class Utility
    {

        /// <summary>
        /// This is used to find and return the path of a file when given a partial
        /// </summary>
        /// <param name="partial">This is a partial of a file path that needs to be found</param>
        /// <returns></returns>
        public static string FindFile(string partial, bool template)
        {

            string path = template ? Settings.Instance.TemplatesFolder : 
                Settings.Instance.DaysFolder;
            IEnumerable<string> files = Directory.GetFiles(path, $"*{ FileExtension() }", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                if (file.Contains(partial))
                {
                    return file;
                }
            }

            return null;

        }

        /// <summary>
        /// This is the method that deals with the filepath to the fileName
        /// </summary>
        /// <param name="fileName">The file that is going to have the filepath returned</param>
        /// <returns>Full file path</returns>
        public static string FullFilePath(this string fileName, bool template)
        {

            return template ? $"{ Settings.Instance.TemplatesFolder }\\{ fileName }"
                : $"{ Settings.Instance.DaysFolder }\\{ fileName }";
        }

        public static string FileExtension()
        {
            switch (Settings.Instance.DatabaseConnection)
            {
                case DatabaseType.JSON:
                    return ".json";
                case DatabaseType.XML:
                    return ".xml";
            }
            return ".xml";
        }
    }
}
