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

            string path = template ? ConfigurationManager.AppSettings["tfilePath"] : 
                ConfigurationManager.AppSettings["filePath"];
            //TODO - Change this in future for BIN
            IEnumerable<string> files = Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                if (file.Contains(partial))
                {
                    return file;
                }
            }

            return null;

        }



    }
}
