﻿using System;
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

            string path = template ? ConfigurationManager.AppSettings["tfilePath"] : 
                ConfigurationManager.AppSettings["filePath"];
            //TODO - Change this in future for BIN
            IEnumerable<string> files = Directory.GetFiles(path, $"*{ Utility.FileExtension() }", SearchOption.TopDirectoryOnly);

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

            return template ? $"{ ConfigurationManager.AppSettings["tfilePath"] }\\{ fileName }"
                : $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        public static string FileExtension()
        {
            switch (GlobalConfig.DatabaseUsed)
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
