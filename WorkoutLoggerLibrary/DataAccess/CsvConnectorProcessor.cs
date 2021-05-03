using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WorkoutLoggerLibrary.Models;

namespace WorkoutLoggerLibrary.DataAccess
{
    public static class CsvConnectorProcessor
    {


        public static List<CacheInfoModel> CsvLoad(this string path)
        {
            throw new NotImplementedException();
        }

        public static void CsvWrite(this CacheInfoModel model, string fileName)
        {
            string fullFilePath = @"C:\data\WorkoutLogger\cache.csv";
            // TODO: Exception when file is open
            using (var fs = new FileStream(fullFilePath, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(model.CsvFormat());
                }
            }
        }

    }
}
